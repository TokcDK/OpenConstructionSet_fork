namespace OpenConstructionSet.Core.Models;

public struct MergeData
{
    public string Key;
    public uint SaveCounter1, SaveCounter2;

    public MergeData(string key, uint saveCounter1, uint saveCounter2)
    {
        Key = key;
        SaveCounter1 = saveCounter1;
        SaveCounter2 = saveCounter2;
    }
}