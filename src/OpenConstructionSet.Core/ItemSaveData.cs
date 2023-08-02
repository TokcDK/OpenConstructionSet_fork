namespace OpenConstructionSet.Core;

public record ItemSaveData(uint SaveCount, ItemChangeType ChangeType)
{
    public static explicit operator ItemSaveData(uint value) => new(value >> 4, (ItemChangeType)((int)value & 0xF));

    public static explicit operator uint(ItemSaveData value) => value.SaveCount << 4 | (uint)((int)value.ChangeType & 0xF);
}