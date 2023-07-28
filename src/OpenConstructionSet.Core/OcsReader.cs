﻿using System;
using System.Text;

namespace OpenConstructionSet.Core.Models;

public class OcsReader : BinaryReader
{
    public OcsReader(Stream input) : base(input)
    {
    }

    public Header? ReadHeader(FileVersion fileVersion) => fileVersion switch
    {
        { HasMergeData: true } => ReadHeaderWithMergeData(),
        { IsModFile: true } => ReadHeader(),
        _ => null
    };

    private Header ReadHeader() => new(ReadInt32(), ReadString(), ReadString(), ReadString(), ReadString(), 1, 0, Array.Empty<MergeData>(), false);

    private Header ReadHeaderWithMergeData()
    {
        var end = ReadInt32() + BaseStream.Position;

        var value = new Header(ReadInt32(), ReadString(), ReadString(), ReadString(), ReadString(), ReadUInt32(), ReadUInt32(), ReadMergeDataCollection(), true);

        BaseStream.Seek(end, SeekOrigin.Begin);

        return value;
    }

    public MergeData ReadMergeData() => new MergeData(ReadString(), ReadUInt32(), ReadUInt32());

    public MergeData[] ReadMergeDataCollection()
    {
        var values = new MergeData[ReadByte()];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = ReadMergeData();
        }

        return values;
    }

    public FileVersion ReadFileVersion() => new(ReadInt32());

    public FileValue ReadFileValue() => new(ReadString());

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

    public Vector3 ReadVector3() => new(ReadSingle(), ReadSingle(), ReadSingle());

    public Rotation ReadRotation() => new(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());

    public Vector4 ReadVector4() => new(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
}