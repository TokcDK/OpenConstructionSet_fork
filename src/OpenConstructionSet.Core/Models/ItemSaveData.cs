namespace OpenConstructionSet.Core.Models;

public struct ItemSaveData
{
    public ItemChangeType ChangeType;
    public uint SaveCount;

    public ItemSaveData(uint saveCount, ItemChangeType changeType)
    {
        SaveCount = saveCount;
        ChangeType = changeType;
    }

    public static explicit operator ItemSaveData(uint value) => new(value >> 4, (ItemChangeType)((int)value & 0xF));

    public static explicit operator uint(ItemSaveData value) => (value.SaveCount << 4) | ((uint)((int)value.ChangeType & 0xF));
}