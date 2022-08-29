using System;
using System.Text;
using System.Security.Cryptography;
using Npgsql;
namespace BusStationAutomatedInformationSystem
{
    public static class Constants
    {
        public const string _connectionString = "Host=localhost;Username=postgres;Password=password;Database=AIS";
    }

    public static class Utility
    {
        public static string GetSHA256(string input)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(input));

                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static string GetParameterValueByName(string paramName)
        {
            try
            {
                Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string cmdText = @$"select parameter_value from utility_table where parameter = '{paramName}'";
                var _cmd = new Npgsql.NpgsqlCommand(cmdText, connection);
                var result = _cmd.ExecuteScalar();
                connection.Close();

                if (result != null) // Найден дубликат, ничего не добавляем, обновляем уже существующий экземпляр
                {
                    return result.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(@$"Не удалось получить значение параметра: {paramName} -----" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }

    public static class ProfileExtensions
    {
        /// <summary>
        /// Вставляет данные в таблицу profile БД в случае отсутствия дубликата, в другом случае обновляет данные
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>Id экземпляра в таблице profile из БД</returns>
        public static int DropToDB(this Profile profile)
        {
            try
            {
                Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string uniqueCheckCmd = @$"select (id) from profile where user_id = {profile.UserId}";
                string cmdText = @$"insert into profile (user_id,passport_id,address_id,surname,name,midname,phone_number) values ({profile.UserId}, {profile.PassportId}, {profile.AddressId}, '{profile.Surname}', '{profile.Name}', '{profile.Midname}', {profile.PhoneNumber}) RETURNING id";
                var _cmd = new Npgsql.NpgsqlCommand(uniqueCheckCmd, connection);
                var uniqueCheckResultId = _cmd.ExecuteScalar();

                if (uniqueCheckResultId != null) // Найден дубликат, ничего не добавляем, обновляем уже существующий экземпляр
                {
                    string updateValuesCmd = @$"update profile set passport_id = {profile.PassportId.ToString()}, address_id = {profile.AddressId.ToString()}, surname = '{profile.Surname.ToString()}', name = '{profile.Name.ToString()}', midname = '{profile.Midname.ToString()}', phone_number = {profile.PhoneNumber.ToString()} where id = {(int)uniqueCheckResultId}";
                    _cmd = new NpgsqlCommand(updateValuesCmd, connection);
                    _cmd.ExecuteScalar();
                    connection.Close();
                    return (int)uniqueCheckResultId;
                }
                else
                {
                    _cmd = new Npgsql.NpgsqlCommand(cmdText, connection);
                    int instanceId = (int)_cmd.ExecuteScalar();
                    connection.Close();
                    return instanceId;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось обновить данные о профиле!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return -1;
            }
        }
    }

    public static class AddressExtensions
    {
        /// <summary>
        /// Вставляет данные в таблицу address БД в случае отсутствия дубликата
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Id экземпляра в таблице address из БД</returns>
        public static int DropToDB(this Address address)
        {
            try
            {
                Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string uniqueCheckCmd = @$"select (id) from address where city = '{address.City}' and street = '{address.Street}' and house = {address.House}";
                string cmdText = @$"insert into address (city, street, house) values ('{address.City}', '{address.Street}', {address.House}) RETURNING id";
                var _cmd = new Npgsql.NpgsqlCommand(uniqueCheckCmd, connection);
                var uniqueCheckResultId = _cmd.ExecuteScalar();

                if (uniqueCheckResultId != null) // Найден дубликат, ничего не добавляем, возвращаем айди дубликата
                {
                    connection.Close();
                    return (int)uniqueCheckResultId;
                }
                else
                {
                    _cmd = new Npgsql.NpgsqlCommand(cmdText, connection);
                    int instanceId = (int)_cmd.ExecuteScalar();
                    connection.Close();
                    return instanceId;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось обновить данные об адресе!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return -1;
            }
        }

        public static Address GetAddressById(this Address address, int? id)
        {
            try
            {
                if (id == null)
                    return new Address(null, null, null);
                
                //GET
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string _sql = @$"select (city,street,house) from address WHERE id = {id}";
                var _cmd = new NpgsqlCommand(_sql, connection);
                object addressResult = _cmd.ExecuteScalar();
                object[] addressArray = addressResult as object[];
                connection.Close();

                if (addressResult != null)
                    return new Address(addressArray[0].ToString(), addressArray[1].ToString(), (int)addressArray[2]);
                else
                    return new Address(null, null, null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить данные о адресе по Id!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;  
            }
        }
    }

    public static class PassportExtensions
    {
        /// <summary>
        /// Вставляет данные в таблицу passport БД в случае отсутствия дубликата
        /// </summary>
        /// <param name="passport"></param>
        /// <returns>Id экземпляра в таблице passport из БД</returns>
        public static int DropToDB(this Passport passport)
        {
            try
            {
                Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string uniqueCheckCmd = @$"select (id) from passport where series = {passport.Series} and number = {passport.Number}";
                string cmdText = @$"insert into passport (series,number) values ({passport.Series}, {passport.Number}) RETURNING id";
                var _cmd = new Npgsql.NpgsqlCommand(uniqueCheckCmd, connection);
                var uniqueCheckResultId = _cmd.ExecuteScalar();

                if (uniqueCheckResultId != null) // Найден дубликат, ничего не добавляем, возвращаем айди дубликата
                {
                    connection.Close();
                    return (int)uniqueCheckResultId;
                }
                else
                {
                    _cmd = new Npgsql.NpgsqlCommand(cmdText, connection);
                    int instanceId = (int)_cmd.ExecuteScalar();
                    connection.Close();
                    return instanceId;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось обновить данные о паспорте!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return -1;
            }
        }

        public static Passport GetPassportById(this Passport passport, int? id)
        {
            try
            {
                if (id == null)
                    return new Passport(null, null);
                
                //GET
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string _sql = @$"select (series,number) from passport WHERE id = {id}";
                var _cmd = new NpgsqlCommand(_sql, connection);
                object passportResult = _cmd.ExecuteScalar();
                object[] passportArray = passportResult as object[];
                connection.Close();

                if (passportResult != null)
                    return new Passport((int)passportArray[0], (int)passportArray[1]);
                else
                    return new Passport(null, null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить данные о паспорте по Id!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;  
            }
        }
    }

    public static class RouteExtensions
    {
        public static string GetDeparturePointNameById(this Route route)
        {
            try
            {
                //GET
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string _sql = @$"select (city,street,house) from address WHERE id = {route.DeparturePointId}";
                var _cmd = new NpgsqlCommand(_sql, connection);
                object result = _cmd.ExecuteScalar();
                object[] resultArray = result as object[];
                connection.Close();

                if (resultArray != null)
                    return @$"{resultArray[0].ToString()} {resultArray[1].ToString()} {resultArray[2].ToString()}";
                else
                    return @$"Неопределено";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить название точки отправления по Id!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "Ошибка";  
            }
        }

        public static string GetDestinationPointNameById(this Route route)
        {
            try
            {
                //GET
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string _sql = @$"select (city,street,house) from address WHERE id = {route.DestinationPointId}";
                var _cmd = new NpgsqlCommand(_sql, connection);
                object result = _cmd.ExecuteScalar();
                object[] resultArray = result as object[];
                connection.Close();

                if (resultArray != null)
                    return @$"{resultArray[0].ToString()} {resultArray[1].ToString()} {resultArray[2].ToString()}";
                else
                    return @$"Неопределено";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить название точки отправления по Id!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "Ошибка";  
            }
        }

        public static string GetTripDistanceById(this Route route)
        {
            try
            {
                //GET
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string _sql = @$"select trip_distance from route WHERE id = {route.Id}";
                var _cmd = new NpgsqlCommand(_sql, connection);
                object result = _cmd.ExecuteScalar();
                object[] resultArray = result as object[];
                connection.Close();

                if (resultArray != null)
                    return @$"{resultArray[0].ToString()} {resultArray[1].ToString()} {resultArray[2].ToString()}";
                else
                    return @$"Неопределено";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить название точки отправления по Id!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "Ошибка";  
            }
        }
    }

    public static class TicketExtensions
    {
        public static int DropToDB(this Ticket ticket)
        {
            try
            {
                //GET
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string _sql = @$"insert into ticket (profile_id,route_id,trip_date,price) values ({ticket.ProfileId}, {ticket.RouteId}, '{ticket.TripDate.Year.ToString()}-{ticket.TripDate.Month.ToString()}-{ticket.TripDate.Day.ToString()}', {ticket.Price}) RETURNING id";
                var _cmd = new NpgsqlCommand(_sql, connection);
                object result = _cmd.ExecuteScalar();
                connection.Close();

                if (result != null)
                    return (int)result;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось обновить данные о билете!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return -1;  
            }
            }
        }
}
