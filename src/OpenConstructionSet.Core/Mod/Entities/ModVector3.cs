using OpenConstructionSet.Core.DataModels;
namespace OpenConstructionSet.Core.Mod.Entities;

public class ModVector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public ModVector3()
    {

    }

    public ModVector3(Vector3Model value) : this(value.X, value.Y, value.Z)
    {
    }

    public ModVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
