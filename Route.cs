using Npgsql;

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
        public string DestinationTime { get; set; }

        public Route(int id, int routeNumber, int departurePointId, int destinationPointId, string departureTime, string destinationTime)
        {
            Id = id;
            RouteNumber = routeNumber;
            DeparturePointId = departurePointId;
            DestinationPointId = destinationPointId;
            DepartureTime = departureTime;
            DestinationTime = destinationTime;
            DeparturePointString = this.GetDeparturePointNameById();
            DestinationPointString = this.GetDestinationPointNameById();
        }
    }
}