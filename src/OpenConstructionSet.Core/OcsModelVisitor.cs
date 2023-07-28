using OpenConstructionSet.Core.Models;

namespace OpenConstructionSet.Core;

public class OcsModelVisitor : OcsDataFileVisitor
{
    private DataFile dataFile;

    private int itemIndex;

    private Item item;

    private int categoryIndex;

    private ReferenceCategory category;

    public DataFile DataFile { get => dataFile; }

    protected override void OnReadFileVersion(FileVersion fileVersion) => dataFile.Version = fileVersion;

    protected override void OnReadHeader(Header? header) => dataFile.Header = header;

    protected override void OnReadLastId(int LastId) => dataFile.LastId = LastId;

    protected override void OnStartItems(int count) => dataFile.Items = new Item[count];

    protected override void OnStartItem(int index,
                                        int instanceCount,
                                        ItemType type,
                                        int id,
                                        string name,
                                        string stringId,
                                        ItemSaveData saveData)
    {
        itemIndex = index;

        item = new()
        {
            InstanceCount = instanceCount,
            Type = type,
            Id = id,
            Name = name,
            StringId = stringId,
            SaveData = saveData
        };
    }

    #region Values
    protected override void OnStartBoolValues(int count) => item.BoolValues = new KeyValuePair<string, bool>[count];

    protected override void OnReadBoolValue(int index, string key, bool value) => item.BoolValues[index] = new KeyValuePair<string, bool>(key, value);

    protected override void OnStartFloatValues(int count) => item.FloatValues = new KeyValuePair<string, float>[count];

    protected override void OnReadFloatValue(int index, string key, float value) => item.FloatValues[index] = new KeyValuePair<string, float>(key, value);

    protected override void OnStartIntValues(int count) => item.IntValues = new KeyValuePair<string, int>[count];

    protected override void OnReadIntValue(int index, string key, int value) => item.IntValues[index] = new KeyValuePair<string, int>(key, value);

    protected override void OnStartVector3Values(int count) => item.Vector3Values = new KeyValuePair<string, Vector3>[count];

    protected override void OnReadVector3Value(int index, string key, Vector3 value) => item.Vector3Values[index] = new KeyValuePair<string, Vector3>(key, value);

    protected override void OnStartVector4Values(int count) => item.Vector4Values = new KeyValuePair<string, Vector4>[count];

    protected override void OnReadVector4Value(int index, string key, Vector4 value) => item.Vector4Values[index] = new KeyValuePair<string, Vector4>(key, value);

    protected override void OnStartStringValues(int count) => item.StringValues = new KeyValuePair<string, string>[count];

    protected override void ReadStringValue(int index, string key, string value) => item.StringValues[index] = new KeyValuePair<string, string>(key, value);

    protected override void OnStartFileValues(int count) => item.FileValues = new KeyValuePair<string, FileValue>[count];

    protected override void OnReadFileValue(int index, string key, FileValue value) => item.FileValues[index] = new KeyValuePair<string, FileValue>(key, value);
    #endregion

    protected override void OnStartReferenceCategories(int count) => item.ReferenceCategories = new ReferenceCategory[count];

    protected override void OnStartReferenceCategory(int index, string name)
    {
        categoryIndex = index;

        category = new()
        {
            Name = name
        };
    }

    protected override void OnStartReferences(int count) => category.References = new Reference[count];

    protected override void OnReadReference(int index,
                                        string targetId,
                                        int value0,
                                        int value1,
                                        int value2) => category.References[index] = new Reference(targetId,
                                                                                                  value0,
                                                                                                  value1,
                                                                                                  value2);

    protected override void OnCompleteReferenceCategory() => item.ReferenceCategories[categoryIndex] = category;

    protected override void OnStartInstances(int count) => item.Instances = new Instance[count];

    protected override void OnReadInstance(int index,
                                       string id,
                                       string targetId,
                                       Vector3 position,
                                       Rotation rotation,
                                       string[] states) => item.Instances[index] = new Instance(id,
                                                                                                targetId,
                                                                                                position,
                                                                                                rotation,
                                                                                                states);

    protected override void OnCompleteItem() => dataFile.Items[itemIndex] = item;
}
