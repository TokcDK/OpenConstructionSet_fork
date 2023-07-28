namespace OpenConstructionSet.Core.Models;

public struct Instance
{
    public string Id;
    public string TargetId;
    public Vector3 Position;
    public Rotation Rotation;
    public string[] States;

    public Instance(string id, string targetId, Vector3 position, Rotation rotation, string[] states)
    {
        Id = id;
        TargetId = targetId;
        Position = position;
        Rotation = rotation;
        States = states;
    }
}