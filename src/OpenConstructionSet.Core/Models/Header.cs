namespace OpenConstructionSet.Core.Models;

public record class Header(int Version,
                           string Author,
                           string Description,
                           string Dependencies,
                           string References,
                           uint SaveCount,
                           uint LastMerge,
                           MergeData[] MergeData,
                           bool HasMergeData);