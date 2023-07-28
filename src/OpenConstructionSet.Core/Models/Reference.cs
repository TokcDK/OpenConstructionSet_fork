namespace OpenConstructionSet.Core.Models;

public struct Reference
{
    public string TargetId;

    public int Value0, Value1, Value2;

    public Reference(string targetId, int value0, int value1, int value2)
    {
        TargetId = targetId;
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }
}
