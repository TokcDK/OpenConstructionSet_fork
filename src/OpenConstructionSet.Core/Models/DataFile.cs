namespace OpenConstructionSet.Core.Models;
public struct DataFile
{
    public FileVersion Version;

    public Header? Header;

    public int LastId;

    public Item[] Items;

    public DataFile(FileVersion version, Header? header, int lastId, Item[] items)
    {
        Version = version;
        Header = header;
        LastId = lastId;
        Items = items;
    }
}