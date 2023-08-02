namespace OpenConstructionSet.Core.DataModels;

public record struct ItemModel
{
    public ItemHeaderModel Header;
    public KeyValuePair<string, bool>[] BoolValues;
    public KeyValuePair<string, float>[] FloatValues;
    public KeyValuePair<string, int>[] IntValues;
    public KeyValuePair<string, Vector3Model>[] Vector3Values;
    public KeyValuePair<string, Vector4Model>[] Vector4Values;
    public KeyValuePair<string, string>[] StringValues;
    public KeyValuePair<string, string>[] FileValues;
    public ReferenceCategoryModel[] ReferenceCategories;
    public InstanceModel[] Instances;

    public ItemModel(ItemHeaderModel header,
                     KeyValuePair<string, bool>[] boolValues,
                     KeyValuePair<string, float>[] floatValues,
                     KeyValuePair<string, int>[] intValues,
                     KeyValuePair<string, Vector3Model>[] vector3Values,
                     KeyValuePair<string, Vector4Model>[] vector4Values,
                     KeyValuePair<string, string>[] stringValues,
                     KeyValuePair<string, string>[] fileValues,
                     ReferenceCategoryModel[] referenceCategories,
                     InstanceModel[] instances)
    {
        Header = header;
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

public record struct ItemHeaderModel
{
    public int InstanceCount;
    public int Type;
    public int Id;
    public string Name;
    public string StringId;
    public uint SaveData;

    public ItemHeaderModel(int instanceCount, int type, int id, string name, string stringId, uint saveData)
    {
        InstanceCount = instanceCount;
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        SaveData = saveData;
    }
}