using OneOf;
using OpenConstructionSet.Core.DataModels;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Core.Mod.Entities;
public class ModItem
{
    [SetsRequiredMembers]
    public ModItem(string name, ItemType type, Dictionary<string, OneOf<bool, float, int, ModVector3, ModVector4, string, ModFileValue>> values, Dictionary<string, ModReferenceCategory> referenceCategories, Dictionary<string, ModInstance> instances, uint saveCount = 0)
    {
        Name = name;
        Type = type;
        Values = values;
        ReferenceCategories = referenceCategories;
        Instances = instances;
        SaveCount = saveCount;
    }

    [SetsRequiredMembers]
    public ModItem(string name, ItemType type, uint saveCount = 0) : this(name, type, new(), new(), new(), saveCount)
    {
    }


    [SetsRequiredMembers]
    public ModItem(ItemHeaderModel model) : this(model.Name, (ItemType)model.Type, ((ItemSaveData)model.SaveData).SaveCount)
    {
    }

    public ModItem()
    {
    }

    public required string Name { get; set; }

    public required ItemType Type { get; set; }

    public required Dictionary<string, OneOf<bool, float, int, ModVector3, ModVector4, string, ModFileValue>> Values { get; set; }

    public required Dictionary<string, ModReferenceCategory> ReferenceCategories { get; set; }

    public required Dictionary<string, ModInstance> Instances { get; set; }

    public uint SaveCount { get; set; }
}
