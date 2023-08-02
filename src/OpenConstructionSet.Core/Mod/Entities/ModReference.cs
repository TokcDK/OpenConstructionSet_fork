using OpenConstructionSet.Core.DataModels;
using System.Drawing;

namespace OpenConstructionSet.Core.Mod.Entities;

public class ModReference
{
    public int Value0 { get; set; }
    public int Value1 { get; set; }
    public int Value2 { get; set; }

    public ModReference()
    {
    }

    public ModReference(ReferenceModel model) : this(model.Value0, model.Value1, model.Value2)
    {
        
    }

    public ModReference(int value0, int value1, int value2)
    {
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }
}