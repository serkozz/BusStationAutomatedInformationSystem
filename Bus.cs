namespace BusStationAutomatedInformationSystem
{
    public class Bus
    {
        public int Id { get; private set; }
        public int BusNumber { get; private set; }
        public string ModelName { get; private set; }
        public int DriverEmployeeId { get; private set; }
        public Bus(int id, int busNumber, string modelName, int driverEmployeeId)
        {
            Id = id;
            BusNumber = busNumber;
            ModelName = modelName;
            DriverEmployeeId = driverEmployeeId;
        }
    }
}