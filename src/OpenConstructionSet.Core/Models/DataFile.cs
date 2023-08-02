namespace OpenConstructionSet.Core.Models;
public record DataFile(FileVersion Version, Header? Header, int LastId, IReadOnlyCollection<Item> Items);