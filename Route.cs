using System;
using Npgsql;
using System.Collections.Generic;
namespace BusStationAutomatedInformationSystem
{
    public class Route
    {
        public int Id { get; set; }
        public int RouteNumber { get; set; }
        public int DeparturePointId { get; set; }
        public string DeparturePointString { get; set; }
        public int DestinationPointId { get; set; }
        public string DestinationPointString { get; set; }
        public string DepartureTime { get; set; }
        public float TripDistance { get; set; }

        public Route(int id, int routeNumber, int departurePointId, int destinationPointId, string departureTime, float tripDistance)
        {
            Id = id;
            RouteNumber = routeNumber;
            DeparturePointId = departurePointId;
            DestinationPointId = destinationPointId;
            DepartureTime = departureTime;
            DeparturePointString = this.GetDeparturePointNameById();
            DestinationPointString = this.GetDestinationPointNameById();
            TripDistance = tripDistance;
        }

        public Route(int id)
        {
            List<object> tempRoute = this.GetRouteByID(id);
            Id = (int)tempRoute[0];
            RouteNumber = (int)tempRoute[1];
            DeparturePointId = (int)tempRoute[2];
            DestinationPointId = (int)tempRoute[3];
            DepartureTime = tempRoute[4].ToString();
            DeparturePointString = this.GetDeparturePointNameById();
            DestinationPointString = this.GetDestinationPointNameById();
            TripDistance = (float)tempRoute[5];
        }
    }
}