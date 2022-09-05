namespace BusStationAutomatedInformationSystem
{
    public class Passport
    {
        public int? Series { get; private set; }
        public int? Number { get; private set; }
        
        public Passport(int? series, int? number)
        {
            Series = series;
            Number = number;
        }

        // Drop data to db extension method in ExtensionMethods class
    }
}