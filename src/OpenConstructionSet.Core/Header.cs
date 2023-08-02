using OpenConstructionSet.Core.Models;

namespace OpenConstructionSet.Core;

public record Header(int Version,
                     string Author,
                     string Description,
                     string Dependencies,
                     string References,
                     uint SaveCount,
                     uint LastMerge,
                     MergeEntry[] MergeEntries,
                     bool HasMergeData);