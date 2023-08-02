using OpenConstructionSet.Core.Discovery;
using OpenConstructionSet.Core.Mod.Entities;

namespace OpenConstructionSet.Core.Mod;

public class ModContextBuilder : IModContextBuilder
{
    readonly string[] gameDataMods = new[] { "gamedata.base", "Newwworld.mod", "Dialogue.mod", "rebirth.mod" };

    public ModContextBuilder()
    {
    }

    public ModContext Build(Installation installation, ModHeader? header, string? activeModName = null)
    {
        List<string> baseMods = new();

        var data = LoadMods(installation.Data);
        var mods = LoadMods(installation.Mods);

        // override mods folder mods with content
        foreach (var mod in LoadMods(installation.Content))
        {
            mods[mod.Key] = mod.Value;
        }

        var visitor = new OcsModVisitor();

        // add game data
        foreach (var gameData in gameDataMods)
        {
            if (data.TryGetValue(gameData, out var mod))
            {
                LoadMod(mod.Location);
            }
        }

        // read load order
        var loadOrder = File.ReadAllLines(installation.LoadOrder);

        // loop mods in load order and add
        foreach (var loadOrderMod in loadOrder)
        {
            if (mods.TryGetValue(loadOrderMod, out var mod))
            {
                LoadMod(mod.Location);
            }
        }

        visitor.ActiveMode = true;

        LoadMod(ActiveModLocation());

        return new(header ?? visitor.Header ?? new(), visitor.LastId, visitor.BaseItems, visitor.Items);

        Dictionary<string, ModFile> LoadMods(ModFolder? folder)
        {
            if (folder is null) return new();

            return ModFolderHelper.ModFiles(installation.Mods).ToDictionary(m => m.Name);
        }

        void LoadMod(string? location)
        {
            if (string.IsNullOrWhiteSpace(location)) return;

            using var reader = new OcsReader(File.OpenRead(location));

            visitor.Execute(reader);
        }

        string? ActiveModLocation()
        {
            if (string.IsNullOrWhiteSpace(activeModName)) return null;

            if (mods.TryGetValue(activeModName, out var activeMod)) return activeMod.Location;
            else return null;
        }
    }
}