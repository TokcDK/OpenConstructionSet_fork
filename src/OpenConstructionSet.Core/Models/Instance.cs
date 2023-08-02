namespace OpenConstructionSet.Core.Models;

public record Instance(string Id, string TargetId, Vector3 Position, Rotation Rotation, IReadOnlyCollection<string> States);