namespace OpenConstructionSet.Core.DataModels;

public record struct HeaderModel
{
    public int Version;
    public string Author;
    public string Description;
    public string Dependencies;
    public string References;
    public uint SaveCount;
    public uint LastMerge;
    public MergeEntry[] MergeEntries;

    public HeaderModel(int version, string author, string description, string dependencies, string references, uint saveCount, uint lastMerge, MergeEntry[] mergeEntries)
    {
        Version = version;
        Author = author;
        Description = description;
        Dependencies = dependencies;
        References = references;
        SaveCount = saveCount;
        LastMerge = lastMerge;
        MergeEntries = mergeEntries;
    }
}