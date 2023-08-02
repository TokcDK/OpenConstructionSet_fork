namespace OpenConstructionSet.Core.DataModels;

public record struct Vector3Model
{
    public float X, Y, Z;

    public Vector3Model(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
