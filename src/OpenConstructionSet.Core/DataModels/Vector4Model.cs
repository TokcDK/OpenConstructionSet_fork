namespace OpenConstructionSet.Core.DataModels;

public record struct Vector4Model
{
    public float X, Y, Z, W;

    public Vector4Model(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
}
