using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregate
{
    public enum TicketState
    {
        ACCEPTED,
        PREPARING
    }
    public class TicketLineItem
    { 
    }

    /// <summary>
    /// Entity
    /// </summary>
    public class Ticket
    {
        public int Id { get; set; }
        public TicketState State { get; set; }
        public int RestaurantId { get; set; }
        public List<TicketLineItem> LineItems { get; set; }
        public DateTime ReadyBy { get; set; }
        public DateTime AcceptTime { get; set; }
        public DateTime PreparingTime { get; set; }
        public DateTime PickedUpTime { get; set; }
        public DateTime ReadyForPickupTime { get; set; }

        public static ResultWithAggregateEvents<Ticket, TicketDomainEvent> Create(int id, TicketDetails details)
        {
            return new ResultWithAggregateEvents(new Ticket(id, details), new TickerCreatedEvent(id, details);
        }

        public List<TicketPreparationStartedEvent> Preparing() {
            switch (State)
            {
                case ACCEPTED:
                    State = TicketState.PREPARING;
                    PreparingTime = DateTime.UtcNow;
                    return SingltonList(new TicketPreparationStartedEvent());
                default:
                    throw new UnsupportedStartTransitionExccption(steate);

            }
        }

        public List<TicketDomainEvent> Cancel()
        {
            switch (State)
            {
                case CREATED:
                    case TicketState.ACCEPTED
            }
        }
    }
}
