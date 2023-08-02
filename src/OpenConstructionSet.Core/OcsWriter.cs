using OpenConstructionSet.Core.DataModels;
using System.Text;

namespace OpenConstructionSet.Core;

public class OcsWriter : BinaryWriter
{
    public OcsWriter(Stream output) : base(output)
    {
    }

    public void Write(HeaderModel? value, int version)
    {
        if (!value.HasValue) return;

        if (FileVersionHelper.HasMergeData(version)) WriteHeaderWithMergeData(value.Value);
        else WriteHeader(value.Value);
    }

    private void WriteHeader(HeaderModel value)
    {
        Write(value.Version);
        Write(value.Author);
        Write(value.Description);
        Write(value.Dependencies);
        Write(value.References);
    }

    private void WriteHeaderWithMergeData(HeaderModel value)
    {
        // Header length will rewrite later
        Write(int.MaxValue);

        long start = BaseStream.Position;

        WriteHeader(value);

        Write(value.SaveCount);
        Write(value.LastMerge);
        Write(value.MergeEntries);

        long length = BaseStream.Position - start;

        // Seek one int before the start of the header and write its length
        BaseStream.Seek(start - 4, SeekOrigin.Begin);
        Write((int)length);

        // Seek back to end of header
        BaseStream.Seek(length, SeekOrigin.Current);
    }

    public void Write(MergeEntry value)
    {
        Write(value.Key);
        Write(value.SaveCounter1);
        Write(value.SaveCounter2);
    }

    public void Write(MergeEntry[] values)
    {
        Write((byte)values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(Vector3Model value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

    public void Write(RotationModel value)
    {
        Write(value.W);
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
    }

    public void Write(Vector4Model value)
    {
        Write(value.X);
        Write(value.Y);
        Write(value.Z);
        Write(value.W);
    }

    public void Write(InstanceModel value)
    {
        Write(value.Id);
        Write(value.TargetId);
        Write(value.Position);
        Write(value.Rotation);
        Write(value.States);
    }

    public void Write(InstanceModel[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(ReferenceModel value)
    {
        Write(value.TargetId);
        Write(value.Value0);
        Write(value.Value1);
        Write(value.Value2);
    }

    public void Write(ReferenceModel[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(ReferenceCategoryModel value)
    {
        Write(value.Name);
        Write(value.References);
    }

    public void Write(ReferenceCategoryModel[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write<T>(KeyValuePair<string, T>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write<T>(KeyValuePair<string, T> value)
    {
        Write(value.Key);
        switch (value)
        {
            case KeyValuePair<string, bool> v: Write(v.Value); break;
            case KeyValuePair<string, float> v: Write(v.Value); break;
            case KeyValuePair<string, int> v: Write(v.Value); break;
            case KeyValuePair<string, Vector3Model> v: Write(v.Value); break;
            case KeyValuePair<string, Vector4Model> v: Write(v.Value); break;
            case KeyValuePair<string, string> v: Write(v.Value); break;
            default: throw new NotSupportedException($"Type {typeof(T).FullName} cannot be written");
        };
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

    public void Write(ItemModel[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(ItemModel value)
    {
        Write(value.Header);  
        Write(value.BoolValues);
        Write(value.FloatValues);
        Write(value.IntValues);
        Write(value.Vector3Values);
        Write(value.Vector4Values);
        Write(value.StringValues);
        Write(value.FileValues);
        Write(value.ReferenceCategories);
        Write(value.Instances);
    }

    public void Write(ItemHeaderModel value)
    {
        Write(value.InstanceCount);
        Write(value.Type);
        Write(value.Id);
        Write(value.Name);
        Write(value.StringId);
        Write(value.SaveData);
    }

    public void Write(DataModel value)
    {
        Write(value.Version);
        Write(value.Header, value.Version);
        Write(value.LastId);
        Write(value.Items);
    }
}