using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventSourcingExample.Models;
using EventSourcingExample.Events;
using EventSourcingExample.Restore;
using System.Collections.Generic;
using System.Linq;

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
            
            Assert.AreEqual(eProc.Log[0], ev);
        }

        [TestMethod]
        public void CheckEventOcurredTime()
        {
            eProc = new EventProcessor();
            DateTime ocurred = new DateTime(2015, 09, 01);
            EntryEvent ev = new EntryEvent(ocurred, parkingBarcelona, newCar);
            eProc.Process(ev);

            Assert.AreEqual(ocurred, ev.Ocurred);
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

        [TestMethod]
        public void RestoreApplicationToCertainEvent()
        {
            eProc = new EventProcessor();
            IList<DomainEvent> log = new List<DomainEvent>()
            {
                new EntryEvent(new DateTime(2015, 08, 01), parkingBarcelona, newCar),
                new ExitEvent(new DateTime(2015, 09, 01), newCar),
                new EntryEvent(new DateTime(2015, 09, 01), parkingParis, oldCar),
                new ExitEvent(new DateTime(2015, 09, 01), oldCar)
            };

            AppRepairer appRepairer = new AppRepairer(log, eProc);

            appRepairer.RepairApplication();

            Assert.IsTrue(log.SequenceEqual(eProc.Log));
        }
    }
}
