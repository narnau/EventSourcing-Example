using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventSourcingExample.Models;
using EventSourcingExample.Events;

namespace EventSourcingExampleTest
{
    [TestClass]
    public class EventProcessorTest
    {
        Parking parkingBarcelona;
        Parking parkingParis;
        Car newCar;
        Car oldCar;
        EventProcessor eProc;

        [TestInitialize]
        public void TestInitialize()
        {
            parkingBarcelona = new Parking("Barcelona");
            parkingParis = new Parking("Paris");
            newCar = new Car("NewCar");
            oldCar = new Car("OldCar");
        }

        [TestMethod]
        public void EntrySetCarLocation()
        {
            eProc = new EventProcessor();
            EntryEvent ev = new EntryEvent(new DateTime(2015, 09, 01), parkingBarcelona, newCar);
            eProc.Process(ev);
            Assert.AreEqual(parkingBarcelona, newCar.Parking);
        }

        [TestMethod]
        public void CheckEventsOnLog()
        {
            eProc = new EventProcessor();
            EntryEvent ev = new EntryEvent(new DateTime(2015, 09, 01), parkingBarcelona, newCar);
            eProc.Process(ev);
            
            Assert.AreEqual(eProc.log[0], ev);
        }

        [TestMethod]
        public void CheckEventOcurredTime()
        {
            eProc = new EventProcessor();
            DateTime ocurred = new DateTime(2015, 09, 01);
            EntryEvent ev = new EntryEvent(ocurred, parkingBarcelona, newCar);
            eProc.Process(ev);

            Assert.AreEqual(ocurred, ev.ocurred);
        }

        [TestMethod]
        public void ExitSetCarLocationToNone()
        {
            eProc = new EventProcessor();
            Parking park = new Parking(Parking.NONE);
            ExitEvent ev = new ExitEvent(new DateTime(2015, 09, 01), newCar);
            eProc.Process(ev);
            Assert.AreEqual(park.Name, newCar.Parking.Name);
        }
    }
}
