using System.Text;
using OpenConstructionSet.Core.DataModels;

namespace OpenConstructionSet.Core;

public class OcsReader : BinaryReader
{
    public OcsReader(Stream input) : base(input)
    {
    }

    public HeaderModel? ReadHeader(int fileVersion)
    {
        if (FileVersionHelper.HasMergeData(fileVersion)) return ReadHeaderWithMergeData();
        else return FileVersionHelper.IsModFile(fileVersion) ? ReadHeader() : null;
    }

    private HeaderModel ReadHeader() => new(ReadInt32(), ReadString(), ReadString(), ReadString(), ReadString(), 1, 0, Array.Empty<MergeEntry>());

    private HeaderModel ReadHeaderWithMergeData()
    {
        var end = ReadInt32() + BaseStream.Position;

        var value = new HeaderModel(ReadInt32(), ReadString(), ReadString(), ReadString(), ReadString(), ReadUInt32(), ReadUInt32(), ReadMergeEntries());

        BaseStream.Seek(end, SeekOrigin.Begin);

        return value;
    }

    public MergeEntry ReadMergeEntry() => new(ReadString(), ReadUInt32(), ReadUInt32());

    public MergeEntry[] ReadMergeEntries()
    {
        var values = new MergeEntry[ReadByte()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadMergeEntry();
        }

        return values;
    }

    public int ReadFileVersion() => ReadInt32();

    public string ReadFileValue() => ReadString();

    public override string ReadString() => Encoding.UTF8.GetString(ReadBytes(ReadInt32()));

    public string[] ReadStrings()
    {
        var values = new string[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadString();
        }

        return values;
    }

    public Vector3Model ReadVector3() => new(ReadSingle(), ReadSingle(), ReadSingle());

    public RotationModel ReadRotation() => new(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());

    public Vector4Model ReadVector4() => new(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());

    public InstanceModel ReadInstance() => new(ReadString(), ReadString(), ReadVector3(), ReadRotation(), ReadStrings());

    public InstanceModel[] ReadInstances()
    {
        var values = new InstanceModel[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadInstance();
        }

        return values;
    }

    public ReferenceModel ReadReference() => new(ReadString(), ReadInt32(), ReadInt32(), ReadInt32());

    public ReferenceModel[] ReadReferences()
    {
        var values = new ReferenceModel[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadReference();
        }

        return values;
    }

    public ReferenceCategoryModel[] ReadReferenceCategories()
    {
        var values = new ReferenceCategoryModel[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadReferenceCategory();
        }

        return values;
    }

    public ReferenceCategoryModel ReadReferenceCategory() => new(ReadString(), ReadReferences());

    public KeyValuePair<string,bool>[] ReadBoolValues()
    {
        var values = new KeyValuePair<string, bool>[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadBoolValue();
        }

        return values;
    }

    public KeyValuePair<string, bool> ReadBoolValue() => new(ReadString(), ReadBoolean());

    public KeyValuePair<string, float>[] ReadFloatValues()
    {
        var values = new KeyValuePair<string, float>[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadFloatValue();
        }

        return values;
    }

    public KeyValuePair<string, float> ReadFloatValue() => new(ReadString(), ReadSingle());

    public KeyValuePair<string, int>[] ReadIntValues()
    {
        var values = new KeyValuePair<string, int>[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadIntValue();
        }

        return values;
    }

    public KeyValuePair<string, int> ReadIntValue() => new(ReadString(), ReadInt32());

    public KeyValuePair<string, Vector3Model>[] ReadVector3Values()
    {
        var values = new KeyValuePair<string, Vector3Model>[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadVector3Value();
        }

        return values;
    }

    public KeyValuePair<string, Vector3Model> ReadVector3Value() => new(ReadString(), ReadVector3());

    public KeyValuePair<string, Vector4Model>[] ReadVector4Values()
    {
        var values = new KeyValuePair<string, Vector4Model>[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadVector4Value();
        }

        return values;
    }

    public KeyValuePair<string, Vector4Model> ReadVector4Value() => new(ReadString(), ReadVector4());

    public KeyValuePair<string, string>[] ReadStringValues()
    {
        var values = new KeyValuePair<string, string>[ReadInt32()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadStringValue();
        }

        return values;
    }

    public KeyValuePair<string, string> ReadStringValue() => new(ReadString(), ReadString());

    public ItemModel[] ReadItems()
    {
        var values = new ItemModel[ReadInt32()];

        for(int i = 0;i < values.Length;i++)
        {
            values[i] = ReadItem();
        }

        return values;
    }

    public ItemModel ReadItem() => new(ReadItemHeader(),
                                       ReadBoolValues(),
                                       ReadFloatValues(),
                                       ReadIntValues(),
                                       ReadVector3Values(),
                                       ReadVector4Values(),
                                       ReadStringValues(),
                                       ReadStringValues(),
                                       ReadReferenceCategories(),
                                       ReadInstances());

    public ItemHeaderModel ReadItemHeader() => new(ReadInt32(), ReadInt32(), ReadInt32(), ReadString(), ReadString(), ReadUInt32());

    public DataModel ReadData()
    {
        var version = ReadInt32();

        return new DataModel(version, ReadHeader(version), ReadInt32(), ReadItems());
    }
}