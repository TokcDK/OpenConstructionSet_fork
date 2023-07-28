namespace OpenConstructionSet.Core.Models;

public class OcsDataFileVisitor
{
    public void Execute(OcsReader reader, string? filename = null)
    {
        OnStartReading(filename);

        var fileVersion = reader.ReadFileVersion();

        OnReadFileVersion(fileVersion);

        OnReadHeader(reader.ReadHeader(fileVersion));

        OnReadLastId(reader.ReadInt32());

        int itemCount = reader.ReadInt32();

        OnStartItems(itemCount);

        for (int itemIndex = 0; itemIndex < itemCount; itemIndex++)
        {
            OnStartItem(itemIndex,
                        reader.ReadInt32(),
                        (ItemType)reader.ReadInt32(),
                        reader.ReadInt32(),
                        reader.ReadString(),
                        reader.ReadString(),
                        (ItemSaveData)reader.ReadUInt32());

            #region Values
            var count = reader.ReadInt32();
            OnStartBoolValues(count);

            for (int i = 0; i < count; i++)
            {
                OnReadBoolValue(i, reader.ReadString(), reader.ReadBoolean());
            }

            count = reader.ReadInt32();
            OnStartFloatValues(count);

            for (int i = 0; i < count; i++)
            {
                OnReadFloatValue(i, reader.ReadString(), reader.ReadSingle());
            }

            count = reader.ReadInt32();
            OnStartIntValues(count);

            for (int i = 0; i < count; i++)
            {
                OnReadIntValue(i, reader.ReadString(), reader.ReadInt32());
            }

            count = reader.ReadInt32();
            OnStartVector3Values(count);

            for (int i = 0; i < count; i++)
            {
                OnReadVector3Value(i, reader.ReadString(), reader.ReadVector3());
            }

            count = reader.ReadInt32();
            OnStartVector4Values(count);

            for (int i = 0; i < count; i++)
            {
                OnReadVector4Value(i, reader.ReadString(), reader.ReadVector4());
            }

            count = reader.ReadInt32();
            OnStartStringValues(count);

            for (int i = 0; i < count; i++)
            {
                ReadStringValue(i, reader.ReadString(), reader.ReadString());
            }

            count = reader.ReadInt32();
            OnStartFileValues(count);

            for (int i = 0; i < count; i++)
            {
                OnReadFileValue(i, reader.ReadString(), reader.ReadFileValue());
            }
            #endregion

            #region References
            count = reader.ReadInt32();

            OnStartReferenceCategories(count);

            for (int categoryIndex = 0; categoryIndex < count; categoryIndex++)
            {
                OnStartReferenceCategory(categoryIndex, reader.ReadString());

                var referenceCount = reader.ReadInt32();

                OnStartReferences(referenceCount);

                for (int i = 0; i < referenceCount; i++)
                {
                    OnReadReference(i,
                                reader.ReadString(),
                                reader.ReadInt32(),
                                reader.ReadInt32(),
                                reader.ReadInt32());
                }

                OnCompleteReferences();
                OnCompleteReferenceCategory();
            }
            #endregion

            #region Instances
            count = reader.ReadInt32();

            OnStartInstances(count);

            for (int i = 0; i < count; i++)
            {
                OnReadInstance(i,
                           reader.ReadString(),
                           reader.ReadString(),
                           reader.ReadVector3(),
                           reader.ReadRotation(),
                           reader.ReadStrings());
            }

            OnCompleteInstances();

            OnCompleteReferenceCategories();

            OnCompleteItem(); 
            #endregion
        }

        OnCompleteItems();

        OnCompleteReading();
    }

    protected virtual void OnStartReading(string? name) { }
    protected virtual void OnReadFileVersion(FileVersion fileVersion) { }
    protected virtual void OnReadHeader(Header? header) { }
    protected virtual void OnReadLastId(int LastId) { }
    protected virtual void OnStartItems(int count) { }
    protected virtual void OnStartItem(int index,
                                       int instanceCount,
                                       ItemType type,
                                       int id,
                                       string name,
                                       string stringId,
                                       ItemSaveData saveData)
    { }

    protected virtual void OnStartBoolValues(int count) { }
    protected virtual void OnReadBoolValue(int index, string key, bool value) { }
    protected virtual void OnCompleteBoolValues() { }

    protected virtual void OnStartFloatValues(int count) { }
    protected virtual void OnReadFloatValue(int index, string key, float value) { }
    protected virtual void OnCompleteFloatValues() { }


    protected virtual void OnStartIntValues(int count) { }
    protected virtual void OnReadIntValue(int index, string key, int value) { }
    protected virtual void OnCompleteIntValues() { }

    protected virtual void OnStartVector3Values(int count) { }
    protected virtual void OnReadVector3Value(int index, string key, Vector3 value) { }
    protected virtual void OnCompleteVector3Values() { }

    protected virtual void OnStartVector4Values(int count) { }
    protected virtual void OnReadVector4Value(int index, string key, Vector4 value) { }
    protected virtual void OnCompleteVector4Values() { }

    protected virtual void OnStartStringValues(int count) { }
    protected virtual void ReadStringValue(int index, string key, string value) { }
    protected virtual void OnCompleteStringValues() { }

    protected virtual void OnStartFileValues(int count) { }
    protected virtual void OnReadFileValue(int index, string key, FileValue value) { }
    protected virtual void OnCompleteFileValues() { }

    protected virtual void OnStartReferenceCategories(int count) { }

    protected virtual void OnStartReferenceCategory(int index, string name) { }

    protected virtual void OnStartReferences(int count) { }

    protected virtual void OnReadReference(int index, string targetId, int value0, int value1, int value2) { }

    protected virtual void OnCompleteReferences() { }

    protected virtual void OnCompleteReferenceCategory() { }

    protected virtual void OnCompleteReferenceCategories() { }

    protected virtual void OnStartInstances(int count) { }

    protected virtual void OnReadInstance(int index, string id, string targetId, Vector3 position, Rotation rotation, string[] states) { }

    protected virtual void OnCompleteInstances() { }

    protected virtual void OnCompleteItem() { }

    protected virtual void OnCompleteItems() { }

    protected virtual void OnCompleteReading() { }
}
