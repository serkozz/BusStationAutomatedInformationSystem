using System;
using System.Collections.Generic;
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
					return result.ToString();
				else
					return string.Empty;
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
		public static int GetRouteIdByNumber(int number)
		{
			try
			{
				//GET
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string _sql = @$"select (id) from route WHERE route_number = {number}";
				var _cmd = new NpgsqlCommand(_sql, connection);
				var result = _cmd.ExecuteScalar();
				return Int32.Parse(result.ToString());
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Не удалось получить id маршрута по его номеру!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return -1;  
			}
		}
		
		public static List<object> GetRouteByID(this Route route, int id)
		{
			try
			{
				//GET
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string _sql = @$"select * from route WHERE id = {id}";
				var _cmd = new NpgsqlCommand(_sql, connection);
				NpgsqlDataReader reader = _cmd.ExecuteReader();
				List<object> returned = new List<object>();
				
				if (reader.HasRows) // если есть данные
				{
					while (reader.Read())
					{
						returned.Add(Int32.Parse(reader.GetValue(0).ToString()));
						returned.Add(Int32.Parse(reader.GetValue(1).ToString()));
						returned.Add(Int32.Parse(reader.GetValue(2).ToString()));
						returned.Add(Int32.Parse(reader.GetValue(3).ToString()));
						returned.Add(reader.GetValue(4).ToString());
						returned.Add(Single.Parse(reader.GetValue(5).ToString()));
					}
					return returned;
				}
				else
				{
					connection.Close();
					return returned;
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Не удалось получить маршрут по Id!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return null;  
			}
		}

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
				string duplicateCheck = @$"SELECT (id) from ticket WHERE profile_id = {ticket.ProfileId}
					AND route_id = {ticket.RouteId}
					AND trip_date = '{ticket.TripDate.Year.ToString()}-{ticket.TripDate.Month.ToString()}-{ticket.TripDate.Day.ToString()}'
					AND price = {ticket.Price};";

				var _cmd = new NpgsqlCommand(duplicateCheck, connection);
				object result = _cmd.ExecuteScalar();

				if (result != null)
				{
					connection.Close();
					return (int)result;
				}
				else
				{
					string _sql = @$"insert into ticket (profile_id,route_id,trip_date,price) values ({ticket.ProfileId}, {ticket.RouteId}, '{ticket.TripDate.Year.ToString()}-{ticket.TripDate.Month.ToString()}-{ticket.TripDate.Day.ToString()}', {ticket.Price}) RETURNING id";
					_cmd = new NpgsqlCommand(_sql, connection);
					result = _cmd.ExecuteScalar();
					connection.Close();

					if (result != null)
						return (int)result;
					else
						return -1;
				}

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Не удалось обновить данные о билете!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return -1;  
			}
		}

		public static bool RemoveFromDB(this Ticket ticket)
		{
			try
			{
				//GET
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string _sql = @$"DELETE FROM ticket WHERE id = {ticket.Id} RETURNING id";
				var _cmd = new NpgsqlCommand(_sql, connection);
				object result = _cmd.ExecuteScalar();
				connection.Close();

				if (result != null)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Не удалось обновить данные о билете!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return false;  
			}
		}
		
		public static List<Ticket> GetAllTicketsByDate(DateTime date)
		{
			try
			{
				List<Ticket> dateTiketsList = new List<Ticket>();
				
				NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
				_connection.Open();
				string cmdText = @$"SELECT * from ticket where trip_date = '{date.ToString()}';";
				var _cmd = new NpgsqlCommand(cmdText, _connection);
				NpgsqlDataReader reader = _cmd.ExecuteReader();

				// Формируем полный список всех билетов на определенную дату
				if (reader.HasRows) // если есть данные
				{
					while (reader.Read()) // построчно считываем данные
					{
						dateTiketsList.Add(new Ticket(Int32.Parse(reader.GetValue(0).ToString()),
														Int32.Parse(reader.GetValue(1).ToString()),
														Int32.Parse(reader.GetValue(2).ToString()),
														DateTime.Parse(reader.GetValue(3).ToString()),
														Single.Parse(reader.GetValue(4).ToString())));
					}
				}
				
				_connection.Close();
				
				return dateTiketsList;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return null;
			}
		}
		
		public static List<DateTime> GetAllDatesWithTickets()
		{
			try
			{
				List<DateTime> dateTiketsList = new List<DateTime>();
				
				NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
				_connection.Open();
				string cmdText = @$"SELECT (trip_date) from ticket;";
				var _cmd = new NpgsqlCommand(cmdText, _connection);
				NpgsqlDataReader reader = _cmd.ExecuteReader();

				// Формируем полный список всех билетов на определенную дату
				if (reader.HasRows) // если есть данные
				{
					while (reader.Read()) // построчно считываем данные
					{
						dateTiketsList.Add(DateTime.Parse(reader.GetValue(0).ToString()));
					}
				}
				_connection.Close();
				
				return dateTiketsList;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return null;
			}
		}
	}
	
	public static class VoyageExtensions
	{
		public static int DropToDB(this Voyage voyage)
		{
			try
			{
				//GET
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string duplicateCheckSql = $"SELECT id FROM voyage WHERE route_id ={voyage.RouteId} AND bus_id ={voyage.BusId} AND tickets_count ={voyage.TicketsCount} AND departure_time = '{voyage.DepartureTime}'";
				var duplicateCheckCommand = new NpgsqlCommand(duplicateCheckSql, connection);
				var duplicateResult = duplicateCheckCommand.ExecuteScalar();

				if (duplicateResult != null)
					return - 1;

				string _sql = @$"insert into voyage (route_id,bus_id,tickets_count,departure_time) values ({voyage.RouteId}, {voyage.BusId}, {voyage.TicketsCount}, '{voyage.DepartureTime}') RETURNING id";
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

		public static List<Tuple<int,string,string,DateTime,int>> GetDriverRoutesHistory(int driverProfileId)
		{
			List<Tuple<int,string,string,DateTime,int>> resultList = new List<Tuple<int, string, string, DateTime, int>>();
			NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
			connection.Open();
			string sql = @$"select (route_number,a1.city,a1.street,a1.house,a2.city,a2.street,a2.house,voyage.departure_time,voyage.tickets_count) FROM voyage
						LEFT JOIN bus ON voyage.bus_id = bus.id
						LEFT JOIN employee ON driver_emloyee_id = employee.id
						LEFT JOIN route ON route_id = route.id
						LEFT JOIN address AS a1 ON departure_point_id = a1.id
						LEFT JOIN address AS a2 ON destination_point_id = a2.id
						WHERE profile_id = {driverProfileId};";
			var _cmd = new NpgsqlCommand(sql, connection);
			NpgsqlDataReader reader = _cmd.ExecuteReader();

			if (reader.HasRows) // если есть данные
			{
				while (reader.Read()) // построчно считываем данные
				{
					object[] resArray = reader.GetValue(0) as object[];
					int number = (int)resArray[0];
					string fromString = string.Empty + resArray[1].ToString() + " " + resArray[2].ToString() + " " + resArray[3].ToString();
					string toString = string.Empty + resArray[4].ToString() + " " + resArray[5].ToString() + " " + resArray[6].ToString();
					DateTime dateTime = (DateTime)resArray[7];
					int ticketsCount = (int)resArray[8];

					resultList.Add(Tuple.Create(number, fromString, toString, dateTime, ticketsCount));
				}
			}

			return resultList;
		}
	}

	public static class BusExtensions
	{
		public static object[] GetBusDriverArrayByBusNumber(int busNumber)
		{
			try
			{
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string _sql = @$"SELECT (bus_number,surname,name,midname) FROM bus LEFT JOIN employee ON bus.driver_emloyee_id = employee.id LEFT JOIN profile ON employee.profile_id = profile.id WHERE bus_number = {busNumber};";
				var _cmd = new NpgsqlCommand(_sql, connection);
				var res = _cmd.ExecuteScalar();
				return res as object[];

			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return null;
			}
		}

		public static int GetBusIdByNumberAndDriverName(int busNumber, string driverFullName)
		{
			try
			{
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string[] fullNameSplitted = driverFullName.Split(' ', 3);
				string _sql = $"SELECT bus.id FROM bus LEFT JOIN employee ON bus.driver_emloyee_id = employee.id LEFT JOIN profile ON employee.profile_id = profile.id WHERE bus.bus_number = {busNumber} AND profile.surname = '{fullNameSplitted[0]}' AND profile.name = '{fullNameSplitted[1]}' AND profile.midname = '{fullNameSplitted[2]}';";
				var _cmd = new NpgsqlCommand(_sql, connection);
				var res = _cmd.ExecuteScalar();
				return (int)res;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return -1;
			}
		}
	}

	public static class EmployeeExtensions
	{
		public static bool IsProfileADriver(int profile_id)
		{
			try
			{
				NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
				connection.Open();
				string _sql = @$"SELECT (id) FROM employee WHERE profile_id = {profile_id}";
				var _cmd = new NpgsqlCommand(_sql, connection);
				var res = _cmd.ExecuteScalar();
				if (res != null)
					return true;
				else
					return false;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
		}
	}
}
