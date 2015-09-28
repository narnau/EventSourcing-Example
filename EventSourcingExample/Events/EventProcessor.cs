using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Events
{
    public class EventProcessor
    {
        public IList<DomainEvent> Log = new List<DomainEvent>();

        public void Process(DomainEvent ev)
        {
            ev.Process();
            Log.Add(ev);
        }
    }
}
