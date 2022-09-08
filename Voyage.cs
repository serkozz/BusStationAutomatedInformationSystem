using System;
using System.Collections.Generic;

namespace BusStationAutomatedInformationSystem
{
    public class Voyage
    {
        public int Id { get; private set; }
        public int RouteId { get; private set; }
        public int BusId { get; private set; }
        public List<Ticket> TicketsList { get; private set; }
        public int TicketsCount { get; private set; }
        public DateTime DepartureTime { get; private set; }

        public Voyage(int id, Route route, int busId, int ticketsCount, DateTime departureTime)
        {
            RouteId = route.Id;
            BusId = busId;
            TicketsCount = ticketsCount;
            DepartureTime = departureTime.Add(TimeSpan.Parse(route.DepartureTime));
            Id = this.DropToDB();
        }
    }
}