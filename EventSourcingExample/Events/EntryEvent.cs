using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingExample.Models;

namespace EventSourcingExample.Events
{
    public class EntryEvent : DomainEvent
    {
        private Car car;
        private Parking parking;

        public EntryEvent(DateTime dateTime, Parking currentParking, Car currentCar) : base(dateTime)
        {
            this.parking = currentParking;
            this.car = currentCar;
        }

        public override void Process()
        {
            this.car.Parking = this.parking;
        }
    }
}
