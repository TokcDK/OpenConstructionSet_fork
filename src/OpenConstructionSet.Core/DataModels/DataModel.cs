namespace OpenConstructionSet.Core.DataModels;

public record struct DataModel
{
    public int Version;
    public HeaderModel? Header;
    public int LastId;
    public ItemModel[] Items;

    public DataModel(int version, HeaderModel? header, int lastId, ItemModel[] items)
    {
        Version = version;
        Header = header;
        LastId = lastId;
        Items = items;
    }
}