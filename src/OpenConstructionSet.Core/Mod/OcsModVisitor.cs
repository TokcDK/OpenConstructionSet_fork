using OneOf;
using OpenConstructionSet.Core.DataModels;
using OpenConstructionSet.Core.Mod.Entities;

namespace OpenConstructionSet.Core.Mod;

public class OcsModVisitor : OcsDataFileVisitor
{
    public Dictionary<string, ModItem> BaseItems { get; } = new();
    public Dictionary<string, ModItem> Items { get; } = new();

    public int LastId { get; private set; }

    ModItem currentItem;
    ModItem? currentBaseItem;

    ModReferenceCategory currentCategory;
    ModReferenceCategory? currentBaseCategory;

    bool itemRemoved;

    public ModHeader? Header { get; private set; }
    
    public bool ActiveMode { get; set; }

    protected override void OnReadLastId(int lastId)
    {
        if (ActiveMode) this.LastId = lastId;
    }

    protected override void OnReadHeader(HeaderModel? header)
    {
        if (header is not null && ActiveMode) this.Header = new(header.Value);
    }

    protected override void OnStartItems(int count)
    {
        if (!ActiveMode) BaseItems.EnsureCapacity(count);

        Items.EnsureCapacity(count);
    }

    protected override void OnStartItem(int index, in ItemHeaderModel value)
    {
        if (!Items.ContainsKey(value.StringId))
        {
            currentItem = Create(Items, value);
            currentBaseItem = !ActiveMode ? Create(BaseItems, value) : null;
        }
        else
        {
            currentItem = Update(Items, value)!;
            currentBaseItem = !ActiveMode ? Update(BaseItems, value) : null;
        }

        itemRemoved = false;

        static ModItem Create(Dictionary<string, ModItem> items, in ItemHeaderModel value)
        {
            var item = new ModItem(value);

            items[value.StringId] = item;

            return item;
        }

        static ModItem Update(Dictionary<string, ModItem> items, in ItemHeaderModel value)
        {
            var item = items[value.StringId];

            item.Name = value.Name;
            item.Type = (ItemType)value.Type;
            item.SaveCount = ((ItemSaveData)value.SaveData).SaveCount;

            return item;
        }
    }

    #region Values
    protected override void OnReadBoolValue(int index, string key, in bool value)
    {
        if (itemRemoved) return;

        if (key == "REMOVED" && value)
        {
            itemRemoved = true;

            Items.Remove(key);
            BaseItems.Remove(key);
        }
        else
        {
            SetValue(key, value);
        }
    }

    protected override void OnReadFloatValue(int index, string key, in float value) => SetValue(key, value);

    protected override void OnReadIntValue(int index, string key, in int value) => SetValue(key, value);

    protected override void OnReadVector3Value(int index, string key,in Vector3Model value) => SetValue(key, new ModVector3(value));

    protected override void OnReadVector4Value(int index, string key,in Vector4Model value) => SetValue(key, new ModVector4(value));

    protected override void ReadStringValue(int index, string key, string value) => SetValue(key, value);

    protected override void OnReadFileValue(int index, string key, string value) => SetValue(key, new ModFileValue(value));

    void SetValue(string key, OneOf<bool, float, int, ModVector3, ModVector4, string, ModFileValue> value)
    {
        if (itemRemoved) return;

        currentItem.Values[key] = value;

        if (currentBaseItem != null) currentBaseItem.Values[key] = value;
    }
    #endregion

    protected override void OnStartReferenceCategories(int count)
    {
        if (itemRemoved) return;

        currentItem.ReferenceCategories.EnsureCapacity(count);

        currentBaseItem?.ReferenceCategories.EnsureCapacity(count);
    }

    protected override void OnStartReferenceCategory(int index, string name)
    {
        if (itemRemoved) return;

        currentCategory = new();

        currentItem.ReferenceCategories[name] = currentCategory;

        if (currentBaseItem != null)
        {
            currentBaseCategory = new();
            currentBaseItem.ReferenceCategories[name] = currentBaseCategory;
        }
    }

    protected override void OnStartReferences(int count)
    {
        if (itemRemoved) return;

        currentCategory.References.EnsureCapacity(count);

        currentBaseCategory?.References.EnsureCapacity(count);
    }

    protected override void OnReadReference(int index, in ReferenceModel value)
    {
        if (itemRemoved) return;

        if (value.Deleted)
        {
            currentCategory.References.Remove(value.TargetId);
            currentBaseCategory?.References.Remove(value.TargetId);
        }
        else
        {
            currentCategory.References[value.TargetId] = new ModReference(value);

            if (currentBaseCategory != null)
            {
                currentBaseCategory.References[value.TargetId] = new ModReference(value);
            }
        }
    }

    protected override void OnStartInstances(int count)
    {
        if (itemRemoved) return;

        currentItem.Instances.EnsureCapacity(count);
        currentBaseItem?.Instances.EnsureCapacity(count);
    }

    protected override void OnReadInstance(int index, in InstanceModel value)
    {
        if (itemRemoved) return;

        if (value.Deleted)
        {
            currentItem.Instances.Remove(value.Id);
            currentBaseItem?.Instances.Remove(value.Id);
        }
        else
        {
            currentItem.Instances[value.Id] = new(value);

            if (currentBaseItem != null)
            {
                currentBaseItem.Instances[value.Id] = new(value);
            }
        }
    }
}
