using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Models
{
    public class Parking
    {
        public string Name;
        public static string NONE = "none";

        public Parking(string name)
        {
            this.Name = name;
        }
    }
}
