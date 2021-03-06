﻿using System.Collections.Generic;
using System.Linq;
using Domain;
using Factories;
using Interfaces;
using Moq;
using NUnit.Framework;

namespace Test.HeavierThanAirAircraftFactory
{
    [TestFixture]
    public abstract class HeavierThanAirAircraftFactoryFixture
    {
        private Factories.HeavierThanAirAircraftFactory heavierThanAirAircraftFactory;
        private Mock<IAddEngines> engineaddition;

        [SetUp]
        public void HeavierThanAirAircraftFactoryFixtureSetUp()
        {
            engineaddition = new Mock<IAddEngines>();
            heavierThanAirAircraftFactory = new Factories.HeavierThanAirAircraftFactory(engineaddition.Object);
        }

        [TestFixture]
        public class EngineDecoratorfixture : HeavierThanAirAircraftFactoryFixture
        {
            private object[] testdata2 = new object[]
            {
                new RotorCraft(2, new List<RotorBlade> {new RotorBlade(true, 6, 34, "carbon fibre")}, "singular",
                    new List<Engine>(), 56, "linx", "generic model", 12000, 0, "test SN")

            };

            [Test, TestCaseSource(nameof(testdata2))]
            public void ItShouldCallAddTurboshaftEngines(RotorCraft rotorCraft)
            {
                engineaddition.Setup(dec => dec.AddTurboshaftEngines(It.IsAny<RotorCraft>())).Returns((RotorCraft rotorCraftarg) => rotorCraftarg);

                var somecraft = heavierThanAirAircraftFactory.TryMakeRotorCraft(rotorCraft.SerialNumber, rotorCraft.RotorBlades.ToList(), "singular", 2, 56, "linx", 12000);

                engineaddition.Verify(dec => dec.AddTurboshaftEngines(somecraft), Times.Once);
            }

            [Test, TestCaseSource(nameof(testdata2))]
            public void ItShouldReturnExpectedValue(RotorCraft rotorCraft)
            {
                engineaddition.Setup(dec => dec.AddTurboshaftEngines(It.IsAny<RotorCraft>())).Returns(() => rotorCraft);
                var somecraft = heavierThanAirAircraftFactory.TryMakeRotorCraft(rotorCraft.SerialNumber, rotorCraft.RotorBlades.ToList(), "singular", 2, 56, "linx", 12000);

                Assert.AreEqual(rotorCraft.ToString(), somecraft.ToString());
            }
        }
    }
}