namespace OpenConstructionSet.Core.DataModels;

public record struct RotationModel
{
    public float W, X, Y, Z;

    public RotationModel(float w, float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
}
