using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModFileValue
{
    public required string Path { get; set; }

    public ModFileValue()
    {
    }

    [SetsRequiredMembers]
    public ModFileValue(string path)
    {
        Path = path;
    }
}