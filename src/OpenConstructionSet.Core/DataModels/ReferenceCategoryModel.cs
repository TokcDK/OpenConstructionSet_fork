namespace OpenConstructionSet.Core.DataModels;

public record struct ReferenceCategoryModel
{
    public string Name;

    public ReferenceModel[] References;

    public ReferenceCategoryModel(string name, ReferenceModel[] references)
    {
        Name = name;
        References = references;
    }
}
