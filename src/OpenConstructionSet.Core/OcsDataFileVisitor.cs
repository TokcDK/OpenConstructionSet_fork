using OpenConstructionSet.Core.DataModels;

namespace OpenConstructionSet.Core;

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
            OnStartItem(itemIndex, reader.ReadItemHeader());

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
                OnReadFileValue(i, reader.ReadString(), reader.ReadString());
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
                    OnReadReference(i, reader.ReadReference());
                }

                OnCompleteReferences();
                OnCompleteReferenceCategory(categoryIndex);
            }
            #endregion

            #region Instances
            count = reader.ReadInt32();

            OnStartInstances(count);

            for (int i = 0; i < count; i++)
            {
                OnReadInstance(i, reader.ReadInstance());
            }

            OnCompleteInstances();

            OnCompleteReferenceCategories();

            OnCompleteItem(itemIndex);
            #endregion
        }

        OnCompleteItems();

        OnCompleteReading();
    }

    protected virtual void OnStartReading(string? name) { }
    protected virtual void OnReadFileVersion(int fileVersion) { }
    protected virtual void OnReadHeader(HeaderModel? header) { }
    protected virtual void OnReadLastId(int LastId) { }
    protected virtual void OnStartItems(int count) { }
    protected virtual void OnStartItem(int index, in ItemHeaderModel value) { }

    protected virtual void OnStartBoolValues(int count) { }
    protected virtual void OnReadBoolValue(int index, string key, in bool value) { }
    protected virtual void OnCompleteBoolValues() { }

    protected virtual void OnStartFloatValues(int count) { }
    protected virtual void OnReadFloatValue(int index, string key, in float value) { }
    protected virtual void OnCompleteFloatValues() { }

    protected virtual void OnStartIntValues(int count) { }
    protected virtual void OnReadIntValue(int index, string key, in int value) { }
    protected virtual void OnCompleteIntValues() { }

    protected virtual void OnStartVector3Values(int count) { }
    protected virtual void OnReadVector3Value(int index, string key, in Vector3Model value) { }
    protected virtual void OnCompleteVector3Values() { }

    protected virtual void OnStartVector4Values(int count) { }
    protected virtual void OnReadVector4Value(int index, string key, in Vector4Model value) { }
    protected virtual void OnCompleteVector4Values() { }

    protected virtual void OnStartStringValues(int count) { }
    protected virtual void ReadStringValue(int index, string key, string value) { }
    protected virtual void OnCompleteStringValues() { }

    protected virtual void OnStartFileValues(int count) { }
    protected virtual void OnReadFileValue(int index, string key, string value) { }
    protected virtual void OnCompleteFileValues() { }

    protected virtual void OnStartReferenceCategories(int count) { }

    protected virtual void OnStartReferenceCategory(int index, string name) { }

    protected virtual void OnStartReferences(int count) { }

    protected virtual void OnReadReference(int index, in ReferenceModel value) { }

    protected virtual void OnCompleteReferences() { }

    protected virtual void OnCompleteReferenceCategory(int index) { }

    protected virtual void OnCompleteReferenceCategories() { }

    protected virtual void OnStartInstances(int count) { }

    protected virtual void OnReadInstance(int index, in InstanceModel value) { }

    protected virtual void OnCompleteInstances() { }

    protected virtual void OnCompleteItem(int index) { }

    protected virtual void OnCompleteItems() { }

    protected virtual void OnCompleteReading() { }
}
