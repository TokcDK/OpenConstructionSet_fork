namespace OpenConstructionSet.Core.Models;

public struct FileVersion
{
    public readonly int Version;

    public FileVersion(int version)
    {
        Version = version;
    }

    public readonly bool HasMergeData => Version is 17;
    public readonly bool IsModFile => Version is 16 or 17;
}