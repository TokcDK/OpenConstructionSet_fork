using OpenConstructionSet.Core.Discovery;
using OpenConstructionSet.Core.Mod.Entities;

namespace OpenConstructionSet.Core.Mod;
public interface IModContextBuilder
{
    ModContext Build(Installation installation, ModHeader? header, string? activeModName = null);
}