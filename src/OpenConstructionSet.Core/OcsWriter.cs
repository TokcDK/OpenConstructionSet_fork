using OpenConstructionSet.Core.Models;
using System.Text;

namespace OpenConstructionSet.Core;

public class OcsWriter : BinaryWriter
{
    public OcsWriter(Stream output) : base(output)
    {
    }

    public void Write(Header? value)
    {
        if (value is null) return;

        if (value.HasMergeData) WriteHeaderWithMergeData(value);
        else WriteHeader(value);
    }

    private void WriteHeader(Header value)
    {
        Write(value.Version);
        Write(value.Author);
        Write(value.Description);
        Write(value.Dependencies);
        Write(value.References);
    }

    private void WriteHeaderWithMergeData(Header value)
    {
        // Header length will rewrite later
        Write(int.MaxValue);

        long start = BaseStream.Position;

        WriteHeader(value);

        Write(value.SaveCount);
        Write(value.LastMerge);
        Write(value.MergeData);

        long length = BaseStream.Position - start;

        // Seek one int before the start of the header and write its length
        BaseStream.Seek(start - 4, SeekOrigin.Begin);
        Write((int)length);

        // Seek back to end of header
        BaseStream.Seek(length, SeekOrigin.Current);
    }

    public void Write(MergeData value)
    {
        Write(value.Key);
        Write(value.SaveCounter1);
        Write(value.SaveCounter2);
    }

    public void Write(MergeData[] values)
    {
        Write((byte)values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    } 

    public void Write(Vector3 value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

    public void Write(Rotation value)
    {
        Write(value.W);
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

    public void Write(Vector4 value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
        Write(value.W);
    }

    public void Write(string[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public override void Write(string value)
    {
        var data = Encoding.UTF8.GetBytes(value);

        Write(data.Length);
        Write(data);
    }
}