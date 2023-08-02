namespace OpenConstructionSet.Core.DataModels;

public record struct MergeEntry
{
    public string Key;

    public uint SaveCounter1, SaveCounter2;

    public MergeEntry(string key, uint saveCounter1, uint saveCounter2)
    {
        Key = key;
        SaveCounter1 = saveCounter1;
        SaveCounter2 = saveCounter2;
    }
}
