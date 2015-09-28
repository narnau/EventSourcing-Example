using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingExample.Models;

namespace EventSourcingExample.Events
{
    public class ExitEvent : DomainEvent
    {
        private Car _car;
        private Parking _parking;

        public ExitEvent(DateTime dateTime, Car currentCar) : base(dateTime)
        {
            this._parking = new Parking(Parking.NONE);
            this._car = currentCar;
        }

        public override void Process()
        {
            this._car.Parking = this._parking;
        }
    }
}