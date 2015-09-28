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
        private Car car;
        private Parking parking;

        public ExitEvent(DateTime dateTime, Car currentCar) : base(dateTime)
        {
            this.parking = new Parking(Parking.NONE);
            this.car = currentCar;
        }

        public override void Process()
        {
            this.car.Parking = this.parking;
        }
    }
}