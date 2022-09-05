using System;

namespace BusStationAutomatedInformationSystem
{
    public class TicketListItem
    {
        public int Id { get; private set; }
        public int RouteId { get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; private set; }
        public Route Route { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public TicketListItem(int id, int routeId, int ticketId, DateTime departureTime)
        {
            Id = id;
            RouteId = routeId;
            TicketId = ticketId;
            DepartureTime = departureTime;
        }

        public TicketListItem(Ticket ticket)
        {
            TicketId = ticket.Id;
            Ticket = ticket;
            RouteId = ticket.RouteId;
            Route = new Route(RouteId);
            DateTime departureDateParsed = DateTime.Parse(Route.DepartureTime);
            DepartureTime = new DateTime(ticket.TripDate.Year, ticket.TripDate.Month, ticket.TripDate.Day,
                                        departureDateParsed.Hour, departureDateParsed.Minute,
                                        departureDateParsed.Second);
            //Id = this.DropToDB();
        }

    }
}