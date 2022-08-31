using System;

namespace BusStationAutomatedInformationSystem
{
    public class Ticket
    {

        public int Id { get; private set; }
        public int ProfileId { get; set; }
        public int RouteId { get; set; }
        public DateTime TripDate { get; set; }
        public float Price { get; set; }

        public Ticket(int profileId, int routeId, DateTime tripDate, float price)
        {
            ProfileId = profileId;
            RouteId = routeId;
            TripDate = tripDate;
            Price = price;
            Id = this.DropToDB();
        }

        public Ticket(int id, int profileId, int routeId, DateTime tripDate, float price)
        {
            Id = id;
            ProfileId = profileId;
            RouteId = routeId;
            TripDate = tripDate;
            Price = price;
        }

    }
}