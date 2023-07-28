namespace OpenConstructionSet.Core.Models;

public struct Item
{
    public int InstanceCount;

    public ItemType Type;
    public int Id;
    public string Name;
    public string StringId;
    public ItemSaveData SaveData;

    public KeyValuePair<string, bool>[] BoolValues;
    public KeyValuePair<string, float>[] FloatValues;
    public KeyValuePair<string, int>[] IntValues;
    public KeyValuePair<string, Vector3>[] Vector3Values;
    public KeyValuePair<string, Vector4>[] Vector4Values;
    public KeyValuePair<string, string>[] StringValues;
    public KeyValuePair<string, FileValue>[] FileValues;

    public ReferenceCategory[] ReferenceCategories;
    public Instance[] Instances;

    public Item(int instanceCount,
                ItemType type,
                int id,
                string name,
                string stringId,
                ItemSaveData saveData,
                KeyValuePair<string, bool>[] boolValues,
                KeyValuePair<string, float>[] floatValues,
                KeyValuePair<string, int>[] intValues,
                KeyValuePair<string, Vector3>[] vector3Values,
                KeyValuePair<string, Vector4>[] vector4Values,
                KeyValuePair<string, string>[] stringValues,
                KeyValuePair<string, FileValue>[] fileValues,
                ReferenceCategory[] referenceCategories,
                Instance[] instances)
    {
        InstanceCount = instanceCount;
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        SaveData = saveData;
        BoolValues = boolValues;
        FloatValues = floatValues;
        IntValues = intValues;
        Vector3Values = vector3Values;
        Vector4Values = vector4Values;
        StringValues = stringValues;
        FileValues = fileValues;
        ReferenceCategories = referenceCategories;
        Instances = instances;
    }
}