using System;
using System.Collections.Generic;

namespace BusStationAutomatedInformationSystem
{
    public class Voyage
    {
        public int Id { get; private set; }
        public int RouteId { get; private set; }
        public int BusId { get; private set; }
        public Route Route { get; private set; }
        public List<Ticket> TicketsList { get; private set; }
        public int TicketsCount { get; private set; }
        public DateTime DepartureTime { get; private set; }

        public Voyage(int routeId, int busId, int ticketsCount, DateTime departureTime)
        {
            RouteId = routeId;
            BusId = busId;
            Route = new Route(routeId);
            TicketsCount = ticketsCount;
            DepartureTime = departureTime;
            Id = this.DropToDB();
        }
    }
}