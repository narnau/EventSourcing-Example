using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Events
{
    public abstract class DomainEvent
    {
        public DateTime Ocurred, Recorded;

        internal DomainEvent(DateTime ocurred)
        {
            this.Ocurred = ocurred;
            this.Recorded = DateTime.Now;
        }

        public abstract void Process();
    }
}
