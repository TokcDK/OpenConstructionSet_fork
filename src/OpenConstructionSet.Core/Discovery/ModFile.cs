namespace OpenConstructionSet.Core.Discovery;

public class ModFile
{
    public ModFile(string path) : this(path, Path.GetFileName(path))
    {
    }

    public ModFile(string location, string name)
    {
        Location = location;
        Name = name;
    }

    public string Location { get; }

    public string Name { get; }
}
