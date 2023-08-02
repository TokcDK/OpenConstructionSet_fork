namespace OpenConstructionSet.Core.Models;

public record Item(int InstanceCount,
                   ItemType Type,
                   int Id,
                   string Name,
                   string StringId,
                   ItemSaveData SaveData,
                   IReadOnlyCollection<KeyValuePair<string, bool>> BoolValues,
                   IReadOnlyCollection<KeyValuePair<string, float>> FloatValues,
                   IReadOnlyCollection<KeyValuePair<string, int>> IntValues,
                   IReadOnlyCollection<KeyValuePair<string, Vector3>> Vector3Values,
                   IReadOnlyCollection<KeyValuePair<string, Vector4>> Vector4Values,
                   IReadOnlyCollection<KeyValuePair<string, string>> StringValues,
                   IReadOnlyCollection<KeyValuePair<string, FileValue>> FileValues,
                   IReadOnlyCollection<ReferenceCategory> ReferenceCategories,
                   IReadOnlyCollection<Instance> Instances);
