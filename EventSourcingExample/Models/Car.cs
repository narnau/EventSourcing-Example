using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Models
{
    public class Car
    {
        private string name;

        public Car(string name)
        {
            this.name = name;
        }

        public Parking Parking { get; set; }
    }
}
