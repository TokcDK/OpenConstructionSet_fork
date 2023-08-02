using System.IO;

namespace OpenConstructionSet.Core.Discovery;
public class Installation
{
    const string DefaultLoadOrder = @"data/mods.cfg";
    const string DefaultDataFolder = "data";
    const string DefaultModsFolder = "mods";

    public Installation(string id, string path, ModFolder? content = null) : this(id,
                                                                                  path,
                                                                                  Path.Combine(path, DefaultLoadOrder),
                                                                                  new ModFolder(Path.Combine(path, DefaultDataFolder), ModFolderType.Data),
                                                                                  new ModFolder(Path.Combine(path, DefaultModsFolder), ModFolderType.Mod),
                                                                                  content)
    {
    }

    public Installation(string id, string path, string loadOrder, ModFolder data, ModFolder mods, ModFolder? content)
    {
        Id = id;
        Root = path;
        LoadOrder = loadOrder;
        Data = data;
        Mods = mods;
        Content = content;
    }

    public string Id { get; }

    public string Root { get; }

    public string LoadOrder { get; }

    public ModFolder Data { get; }

    public ModFolder Mods { get; set; }

    public ModFolder? Content { get; set; }
}
