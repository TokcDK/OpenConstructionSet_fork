namespace OpenConstructionSet.Core.Models;

public record FileVersion(int Version)
{
    public bool HasMergeData => Version is 17;
    public bool IsModFile => Version is 16 or 17;
}
