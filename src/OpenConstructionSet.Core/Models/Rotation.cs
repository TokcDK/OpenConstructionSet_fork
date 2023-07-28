namespace OpenConstructionSet.Core.Models;

public struct Rotation
{
    public float W, X, Y, Z;

    public Rotation(float w, float x, float y, float z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }
}