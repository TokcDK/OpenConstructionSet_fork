using OpenConstructionSet.Core.Models;

namespace OpenConstructionSet.Core;
internal class OcsModelWriter : OcsWriter
{
    public OcsModelWriter(Stream output) : base(output)
    {
    }

    public void Write(DataFile value)
    {
        Write(value.Version.Version);
        Write(value.Header);
        Write(value.LastId);
        Write(value.Items);
    }

    public void Write(Item value)
    {
        Write(value.InstanceCount);
        Write((int)value.Type);
        Write(value.Id);
        Write(value.Name);
        Write(value.StringId);
        Write((uint)value.SaveData);
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

    public void Write(Item[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(Instance value)
    {
        Write(value.Id);
        Write(value.TargetId);
        Write(value.Position);
        Write(value.Rotation);
        Write(value.States);
    }

    public void Write(Instance[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(Reference value)
    {
        Write(value.TargetId);
        Write(value.Value0);
        Write(value.Value1);
        Write(value.Value2);
    }

    public void Write(Reference[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(ReferenceCategory value)
    {
        Write(value.Name);
        Write(value.References);
    }

    public void Write(ReferenceCategory[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i]);
        }
    }

    public void Write(KeyValuePair<string, bool>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value);
        }
    }

    public void Write(KeyValuePair<string, int>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value);
        }
    }

    public void Write(KeyValuePair<string, float>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value);
        }
    }

    public void Write(KeyValuePair<string, string>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value);
        }
    }

    public void Write(KeyValuePair<string, FileValue>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value.Path);
        }
    }

    public void Write(KeyValuePair<string, Vector4>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value);
        }
    }

    public void Write(KeyValuePair<string, Vector3>[] values)
    {
        Write(values.Length);

        for (int i = 0; i < values.Length; i++)
        {
            Write(values[i].Key);
            Write(values[i].Value);
        }
    }
}
