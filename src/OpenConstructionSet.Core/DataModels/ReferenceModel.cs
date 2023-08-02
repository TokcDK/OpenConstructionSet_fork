namespace OpenConstructionSet.Core.DataModels;

public record struct ReferenceModel
{
    public string TargetId;

    public int Value0, Value1, Value2;

    public ReferenceModel(string targetId, int value0, int value1, int value2)
    {
        TargetId = targetId;
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }

    public bool Deleted => Value0 == int.MaxValue && Value1 == int.MaxValue && Value2 == int.MaxValue;
}
