using EventSourcingExample.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Restore
{
    public class AppRepairer
    {
        private IList<DomainEvent> log;
        private EventProcessor eventProcessor;

        public AppRepairer(IList<DomainEvent> log, EventProcessor eventProcessor)
        {
            this.log = log;
            this.eventProcessor = eventProcessor;
        }

        public void RepairApplication()
        {
            foreach (var domainEvent in this.log)
            {
                eventProcessor.Process(domainEvent);
            }
        }
    }
}
