namespace OpenConstructionSet.Core.Models;

public class OcsModelVisitor : OcsDataFileVisitor
{
    FileVersion version;
    Header? header;
    int lastId;

    private Item[] items;

    private Item item;
    int instanceCount;
    ItemType type;
    int id;
    string name;
    string stringId;
    ItemSaveData saveData;
    private KeyValuePair<string, bool>[] boolValues;
    private KeyValuePair<string, float>[] floatValues;
    private KeyValuePair<string, int>[] intValues;
    private KeyValuePair<string, Vector3>[] vector3Values;
    private KeyValuePair<string, Vector4>[] vector4Values;
    private KeyValuePair<string, string>[] stringValues;
    private KeyValuePair<string, FileValue>[] fileValues;

    private ReferenceCategory[] referenceCategories;

    private string categoryName;
    private Reference[] references;

    private Instance[] instances;

    public DataFile DataFile { get; private set; }

    protected override void OnReadFileVersion(FileVersion fileVersion) => version = fileVersion;

    protected override void OnReadHeader(Header? header) => this.header = header;

    protected override void OnReadLastId(int LastId) => lastId = LastId;

    protected override void OnStartItems(int count) => items = new Item[count];

    protected override void OnStartItem(int index,
                                        int instanceCount,
                                        ItemType type,
                                        int id,
                                        string name,
                                        string stringId,
                                        ItemSaveData saveData)
    {
        this.instanceCount = instanceCount;
        this.type = type;
        this.id = id;
        this.name = name;
        this.stringId = stringId;
        this.saveData = saveData;
    }

    #region Values
    protected override void OnStartBoolValues(int count) => boolValues = new KeyValuePair<string, bool>[count];

    protected override void OnReadBoolValue(int index, string key, bool value) => boolValues[index] = new KeyValuePair<string, bool>(key, value);

    protected override void OnStartFloatValues(int count) => floatValues = new KeyValuePair<string, float>[count];

    protected override void OnReadFloatValue(int index, string key, float value) => floatValues[index] = new KeyValuePair<string, float>(key, value);

    protected override void OnStartIntValues(int count) => intValues = new KeyValuePair<string, int>[count];

    protected override void OnReadIntValue(int index, string key, int value) => intValues[index] = new KeyValuePair<string, int>(key, value);

    protected override void OnStartVector3Values(int count) => vector3Values = new KeyValuePair<string, Vector3>[count];

    protected override void OnReadVector3Value(int index, string key, Vector3 value) => vector3Values[index] = new KeyValuePair<string, Vector3>(key, value);

    protected override void OnStartVector4Values(int count) => vector4Values = new KeyValuePair<string, Vector4>[count];

    protected override void OnReadVector4Value(int index, string key, Vector4 value) => vector4Values[index] = new KeyValuePair<string, Vector4>(key, value);

    protected override void OnStartStringValues(int count) => stringValues = new KeyValuePair<string, string>[count];

    protected override void ReadStringValue(int index, string key, string value) => stringValues[index] = new KeyValuePair<string, string>(key, value);

    protected override void OnStartFileValues(int count) => fileValues = new KeyValuePair<string, FileValue>[count];

    protected override void OnReadFileValue(int index, string key, FileValue value) => fileValues[index] = new KeyValuePair<string, FileValue>(key, value);
    #endregion

    protected override void OnStartReferenceCategories(int count) => referenceCategories = new ReferenceCategory[count];

    protected override void OnStartReferenceCategory(int index, string name) => categoryName = name;

    protected override void OnStartReferences(int count) => references = new Reference[count];

    protected override void OnReadReference(int index,
                                        string targetId,
                                        int value0,
                                        int value1,
                                        int value2) => references[index] = new Reference(targetId,
                                                                                         value0,
                                                                                         value1,
                                                                                         value2);

    protected override void OnCompleteReferenceCategory(int index) => referenceCategories[index] = new(categoryName, references);

    protected override void OnStartInstances(int count) => instances = new Instance[count];

    protected override void OnReadInstance(int index,
                                           string id,
                                           string targetId,
                                           Vector3 position,
                                           Rotation rotation,
                                           string[] states) => instances[index] = new Instance(id,
                                                                                               targetId,
                                                                                               position,
                                                                                               rotation,
                                                                                               states);

    protected override void OnCompleteItem(int index) => items[index] = new(instanceCount,
                                                                            type,
                                                                            id,
                                                                            name,
                                                                            stringId,
                                                                            saveData,
                                                                            boolValues,
                                                                            floatValues,
                                                                            intValues,
                                                                            vector3Values,
                                                                            vector4Values,
                                                                            stringValues,
                                                                            fileValues,
                                                                            referenceCategories,
                                                                            instances);

    protected override void OnCompleteReading() => DataFile = new(version, header, lastId, items);
}
