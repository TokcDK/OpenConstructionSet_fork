namespace OpenConstructionSet.Core.Models;

public struct ReferenceCategory
{
    public string Name;

    public Reference[] References;

    public ReferenceCategory(string name, Reference[] references)
    {
        Name = name;
        References = references;
    }
}