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
        private Car _car;
        private Parking _parking;

        public EntryEvent(DateTime dateTime, Parking currentParking, Car currentCar) : base(dateTime)
        {
            this._parking = currentParking;
            this._car = currentCar;
        }

        public override void Process()
        {
            this._car.Parking = this._parking;
        }
    }
}
