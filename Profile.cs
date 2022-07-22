using System.Numerics;

namespace BusStationAutomatedInformationSystem
{
    public class Profile
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int? PassportId { get; private set; }
        public int? AddressId { get; private set; }
        #nullable enable
        public string? Surname { get; private set; }
        #nullable enable
        public string? Name { get; private set; }
        #nullable enable
        public string? Midname { get; private set; }
        #nullable enable
        public long? PhoneNumber { get; private set; }
        #nullable enable
        // public User? User { get; private set; }
        // #nullable enable
        // public Passport? Passport { get; private set; }
        // #nullable enable
        // public Address? Address { get; private set; }


        #region Constructors
        public Profile(int id, int userId, int? passportId, int? addressId,
                        string? surname, string? name, string? midname, long? phoneNumber)
        {
            Id = id; UserId = userId; PassportId = passportId;
            AddressId = addressId; Surname = surname; Name = name;
            Midname = midname; PhoneNumber = phoneNumber;
        }

        #endregion

        // public void UpdateProfileInfo(int? passportId, int? addressId, string surname, string name, string midname, long phoneNumber)
        // {
        //     Surname = surname; Name = name; Midname = midname; PhoneNumber = phoneNumber;
        // }

        // public void UpdateIds(int passportId, int addressId)
        // {
        //     AddressId = addressId;
        //     PassportId = passportId;
        // }
    }
}