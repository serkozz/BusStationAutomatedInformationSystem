using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationAutomatedInformationSystem
{
    public class User
    {
        string login = string.Empty;
        string password = string.Empty;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

    }
}
