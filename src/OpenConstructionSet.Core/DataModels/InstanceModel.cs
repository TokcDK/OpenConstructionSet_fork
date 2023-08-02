namespace OpenConstructionSet.Core.DataModels;

public record struct InstanceModel
{
    public string Id, TargetId;

    public Vector3Model Position;

    public RotationModel Rotation;

    public string[] States;

    public InstanceModel(string id, string targetId, Vector3Model position, RotationModel rotation, string[] states)
    {
        Id = id;
        TargetId = targetId;
        Position = position;
        Rotation = rotation;
        States = states;
    }

    public bool Deleted => string.IsNullOrEmpty(TargetId);
}