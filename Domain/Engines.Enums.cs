using System.Security.Cryptography.X509Certificates;

namespace Domain
{
    public enum OnOff
    {
        Running,
        Stopped
    }

    public enum Propellants
    {
        Jet_A,
        Jet_B,
        EthylAlcohol,
        RP_1,
        LH2,
        Hydrazine,
        MonoMethylHydrazine,
        UnSymmetricalDimethylHydrazine,
        Lithium,
        Fluorine
    }

    public enum Oxidisers
    {
        GOX,
        LOX,
        DinitrogenTetroxide,
        High_TestPeroxide
    }
}