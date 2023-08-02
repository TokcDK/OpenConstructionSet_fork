namespace OpenConstructionSet.Core.Models;
public class OcsModelWriter : OcsWriter
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

    public void Write(IReadOnlyCollection<Item> values)
    {
        Write(values.Count);

        foreach (var value in values)
        {
            Write(value);
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

    public void Write(IReadOnlyCollection<Instance> values)
    {
        Write(values.Count);

        foreach (var value in values)
        {
            Write(value);
        }
    }

    public void Write(Reference value)
    {
        Write(value.TargetId);
        Write(value.Value0);
        Write(value.Value1);
        Write(value.Value2);
    }

    public void Write(IReadOnlyCollection<string> values)
    {
        Write(values.Count);

        foreach (var value in values)
        {
            Write(value);
        }
    }

    public void Write(IReadOnlyCollection<Reference> values)
    {
        Write(values.Count);

        foreach (var value in values)
        {
            Write(value);
        }
    }

    public void Write(ReferenceCategory value)
    {
        Write(value.Name);
        Write(value.References);
    }

    public void Write(IReadOnlyCollection<ReferenceCategory> values)
    {
        Write(values.Count);

        foreach (var value in values)
        {
            Write(value);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, bool>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, int>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, float>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, string>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, FileValue>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value.Path);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, Vector4>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value);
        }
    }

    public void Write(IReadOnlyCollection<KeyValuePair<string, Vector3>> values)
    {
        Write(values.Count);

        foreach (var pair in values)
        {
            Write(pair.Key);
            Write(pair.Value);
        }
    }
}
