using OpenConstructionSet.Core.DataModels;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModVector4
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float W { get; set; }

    public ModVector4()
    {

    }

    public ModVector4(Vector4Model value) : this(value.X, value.Y, value.Z, value.W)
    {
    }

    public ModVector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
}
