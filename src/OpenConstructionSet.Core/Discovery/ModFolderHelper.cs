namespace OpenConstructionSet.Core.Discovery;

public static class ModFolderHelper
{
    public static IEnumerable<ModFile> ModFiles(ModFolder folder) => folder.Type switch
    {
        ModFolderType.Data => DataModFiles(folder.Location),
        ModFolderType.Mod => ModsModFiles(folder.Location),
        _ => ContentModFiles(folder.Location),
    };

    static IEnumerable<ModFile> DataModFiles(string folder) => new DirectoryInfo(folder).EnumerateFiles().Where(f => f.Extension.ToLower() is ".mod" or ".base").Select(f => new ModFile(f.FullName));

    static IEnumerable<ModFile> ModsModFiles(string folder)
    {
        var directory = new DirectoryInfo(folder);

        foreach (var child in directory.EnumerateDirectories())
        {
            var file = new FileInfo(Path.Combine(child.FullName, $"{child.Name}.mod"));

            if (file.Exists)
            {
                yield return new(file.FullName);
            }
        }
    }

    static IEnumerable<ModFile> ContentModFiles(string folder)
    {
        var directory = new DirectoryInfo(folder);

        foreach (var child in directory.EnumerateDirectories())
        {
            var mod = child.EnumerateFiles("*.mod").FirstOrDefault();

            if (mod is not null) yield return new(mod.FullName);
        }
    }
}