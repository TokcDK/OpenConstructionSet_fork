namespace OpenConstructionSet.Core.Models;

public record ReferenceCategory(string Name, IReadOnlyCollection<Reference> References);
