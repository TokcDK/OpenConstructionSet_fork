namespace OpenConstructionSet.Core;

public static class FileVersionHelper
{
    public static bool IsModFile(int version) => version is 16 or 17;

    public static bool HasMergeData(int version) => version is 17;
}
