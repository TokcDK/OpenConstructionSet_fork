using OpenConstructionSet.Core.Mod.Entities;

namespace OpenConstructionSet.Core.Mod;

public class ModContext
{
    private readonly Dictionary<string, ModItem> baseItems;

    public ModContext(ModHeader header, int lastId, Dictionary<string, ModItem> baseItems, Dictionary<string, ModItem> items)
    {
        this.Header = header;
        LastId = lastId;
        this.baseItems = baseItems;
        Items = items;
    }

    public ModHeader Header { get; }
    public int LastId { get; set; }

    public Dictionary<string, ModItem> Items { get; set; }
}
