using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModReferenceCategory
{
    [SetsRequiredMembers]
    public ModReferenceCategory()
    {
        References = new();
    }

    [SetsRequiredMembers]
    public ModReferenceCategory(Dictionary<string, ModReference> references)
    {
        References = references;
    }

    public required Dictionary<string, ModReference> References { get; set; }
}
