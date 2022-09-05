namespace BusStationAutomatedInformationSystem
{
    public class Address
    {
        #nullable enable
        public string? City { get; private set; }
        public string? Street { get; private set; }
        public int? House { get; private set; }

        public Address(string? city, string? street, int? house)
        {
            City = city;
            Street = street;
            House = house;
        }

        // Data to DB method as extension in ExtensionsMethods class
    }
}