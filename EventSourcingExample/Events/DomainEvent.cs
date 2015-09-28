using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Events
{
    public abstract class DomainEvent
    {
        public DateTime ocurred, recorded;

        internal DomainEvent(DateTime dateTime)
        {
            this.ocurred = dateTime;
            this.recorded = DateTime.Now;
        }

        public abstract void Process();
    }
}
