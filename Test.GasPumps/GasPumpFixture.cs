using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NUnit.Framework;

namespace Test.GasPumps
{
    [TestFixture]
    public abstract class LighterThanAirAircraftFixture
    {
        protected LighterThanAirAircraft lighterThanAirAircraft;
        protected static object[] Testargs;
        protected static int Maxindex;

        [SetUp]
        public void GasPumpFixtureSetUp()
        {
            lighterThanAirAircraft = new LighterThanAirAircraft(new GasPumpManager(), 200, "HE", new List<GasCompartment> { new GasCompartment(200, 180), new GasCompartment(200, 180) },
                                                                new List<Engine>(), 56, "TEST", "TEST Model", 1000, 100, "TEST SN");
            Maxindex = lighterThanAirAircraft.Compartments.Count;
            Testargs = new object[]
                    {
                        new object[] {0, Maxindex},
                        new object[] {Maxindex, 0},
                        new object[] {-1, 0},
                        new object[] {0, -1},
                        new object[] {Maxindex, Maxindex}
                    };
        }

        [TestFixture]
        public abstract class ShiftGasFixture : LighterThanAirAircraftFixture
        {
            [TestFixture]
            public class WhenItContainsGasPumpManager : ShiftGasFixture
            {
                [SetUp]
                public void WhenItContainsGasPumpManagerSetUp()
                {
                    GasPumpFixtureSetUp();
                    lighterThanAirAircraft.GasManager = new GasPumpManager();
                    Testargs = new object[]
                    {
                        new object[] {0, Maxindex},
                        new object[] {Maxindex, 0},
                        new object[] {-1, 0},
                        new object[] {0, -1}
                    };
                }

                [TestCase()]
                public void ItShouldThrowOnEqualCompartmentIndices()
                {
                    Assert.Throws<ArgumentException>(() => lighterThanAirAircraft.ShiftGas(0, 0, 1));
                }

                [TestCase(0, 5)]
                [TestCase(5, 0)]
                [TestCase(-5, 0)]
                [TestCase(0, -5)]
                public void ItShouldThrowOnNonexistentCompartmentIndices(int first, int second)
                {
                    WhenItContainsGasPumpManagerSetUp();
                    Assert.Throws<GasCompartmentsNotFoundException>(() => lighterThanAirAircraft.ShiftGas(first, second, 1));
                }
            }

            [TestFixture]
            public class WhenItContainsSafeGasPumpManager : ShiftGasFixture
            {
                private static object[] testargs2;

                [SetUp]
                public void WhenItContainsGasPumpManagerSetUp()
                {
                    GasPumpFixtureSetUp();
                    lighterThanAirAircraft.GasManager = new SafeGasPumpManager();
                    float fivePercent = lighterThanAirAircraft.Compartments[0].Capacity / 20;
                    testargs2 = new object[]
                    {
                        new object[] {0, 1, 1f},
                        new object[]
                        {0, 1, (float) lighterThanAirAircraft.Compartments[0].CurrentVolume - fivePercent*0.5}
                    };
                }

                [Test]
                public void ItShouldThrowOnEqualCompartmentIndices()
                {
                    Assert.Throws<ArgumentException>(() => lighterThanAirAircraft.ShiftGas(0, 0, 1));
                    WhenItContainsGasPumpManagerSetUp();
                }

                
                [TestCase(0, 5)]
                [TestCase(5, 0)]
                [TestCase(-5, 0)]
                [TestCase(0, -5)]
                public void ItShouldThrowOnNonexistentCompartmentIndices(int first, int second)
                {
                    Assert.Throws<GasCompartmentsNotFoundException>(() => lighterThanAirAircraft.ShiftGas(first, second, 1));
                    WhenItContainsGasPumpManagerSetUp();
                }
                
                [TestCase(0,1, 175)]
                public void ItShouldThrowOnAttemptToLeaveLessThanFivePercentinCompartment(int first, int second,
                    float third)
                {
                    Assert.Throws<GasCompartmentsNotFoundException>(() => lighterThanAirAircraft.ShiftGas(first, second, third));
                    WhenItContainsGasPumpManagerSetUp();
                }
            }

            [TestFixture]
            public class WhenItContainsNonMovableGasManager : ShiftGasFixture
            {
                [SetUp]
                public void WhenItContainsGasPumpManagerSetUp()
                {
                    GasPumpFixtureSetUp();
                    lighterThanAirAircraft.GasManager = new NonMovableGasManager();
                }

                [Test]
                public void ItDoesNotThrow()
                {
                    Assert.DoesNotThrow(() => lighterThanAirAircraft.ShiftGas(0, 0, 0));
                }
            }
        }
    }
}