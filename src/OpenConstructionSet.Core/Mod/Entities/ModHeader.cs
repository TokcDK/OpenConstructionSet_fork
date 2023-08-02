using OpenConstructionSet.Core.DataModels;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModHeader
{
    public ModHeader()
    {
    }

    public ModHeader(HeaderModel model)
    {
        Version = model.Version;
        Author = model.Author;
        Description = model.Description;

        Dependencies = new(model.Dependencies.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));
        References = new(model.References.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));

        SaveCount = model.SaveCount;
        LastMerge = model.LastMerge;

        MergeEntries = model.MergeEntries.ToList();
    }

    public int Version { get; set; } = 1;

    public string Author { get; set; } = "";

    public string Description { get; set; } = "";

    public HashSet<string> Dependencies { get; set; } = new();

    public HashSet<string> References { get; set; } = new();

    public uint SaveCount {  get; set; }

    public uint LastMerge { get; set; }

    public List<MergeEntry> MergeEntries { get; set; } = new();
}
