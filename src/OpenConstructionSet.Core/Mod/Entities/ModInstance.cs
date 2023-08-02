using OpenConstructionSet.Core.DataModels;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModInstance
{
    required public string TargetId { get; set; }
    required public ModVector3 Position { get; set; }
    required public ModRotation Rotation { get; set; }
    public List<string> States { get; } = new();

    public ModInstance()
    {
    }

    [SetsRequiredMembers]
    public ModInstance(InstanceModel model) : this(model.TargetId, new(model.Position), new(model.Rotation), model.States)
    {
        
    }

    [SetsRequiredMembers]
    public ModInstance(string targetId, ModVector3 position, ModRotation rotation, IEnumerable<string>? states = null)
    {
        TargetId = targetId;
        Position = position;
        Rotation = rotation;

        if (states is not null) States = new(states);
    }
}
