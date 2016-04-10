using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum OnOff
    {
        [Description("Starting")]
        Starting = 0,
        [Description("Running")]
        Running = 1,
        [Description("ShuttingDown")]
        ShuttingDown = 2,
        [Description("Stopped")]
        Stopped = 3
    }

    public enum PropellantsEnum
    {
        [Description("Jet_A")]
        Jet_A = 0,
        [Description("Jet_B")]
        Jet_B = 1,
        [Description("EtylAclohol")]
        EthylAlcohol = 2,
        [Description("RP_1")]
        RP_1 = 3,
        [Description("LH2")]
        LH2 = 4,
        [Description("Hydrazine")]
        Hydrazine = 5,
        [Description("MonoMethylHydrazine")]
        MonoMethylHydrazine = 6,
        [Description("UnSymmetricalDimethylHydrazine")]
        UnSymmetricalDimethylHydrazine = 7,
        [Description("Lithium")]
        Lithium = 8,
        [Description("Fluorine")]
        Fluorine = 9
    }

    public enum OxidisersEnum
    {
        [Description("GOX")]
        GOX = 0,
        [Description("LOX")]
        LOX = 1,
        [Description("DinitrogenTetroxide")]
        DinitrogenTetroxide = 2,
        [Description("High_TestPeroxide")]
        High_TestPeroxide = 3
    }
}
