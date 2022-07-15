using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public static class SQL
    {
        public const string connectionString = "Host=localhost;Username=postgres;Password=password;Database=AIS";

/*        public static NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }*/

        /// <summary>
        /// Возвращает созданное подключение к БД в случае успеха
        /// </summary>
        /// <returns>connection if success
        ///          null if fail</returns>
        public static NpgsqlConnection OpenConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Open)
                return connection;
            else
                return null;
        }
    }
}
