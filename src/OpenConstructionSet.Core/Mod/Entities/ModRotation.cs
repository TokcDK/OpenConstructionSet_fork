using OpenConstructionSet.Core.DataModels;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModRotation
{
    public float W { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public ModRotation()
    {
    }

    public ModRotation(RotationModel value) : this(value.W, value.X, value.Y, value.Z)
    {
    }

    public ModRotation(float w, float x, float y, float z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }
}
