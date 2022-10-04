using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class TripHistoryForm : Form
    {
        public Profile Profile { get; set; }
        public ProfileForm ProfileForm { get; set; }
        public bool IsPastTripsDisplayed { get; private set; } = true;
        public List<Ticket> UserTripList { get; private set; } // Все маршруты данного пользователя
        public List<Ticket> UserPastTripList { get; private set; } // Только завершенные маршруты пользователя
        public Ticket SelectedTicket { get; private set; }
        List<Tuple<int,string,string,DateTime,int>> DriverTripList;
        private DataSet tripHistoryDataSet = new DataSet("trip_history");

        public TripHistoryForm(Profile profile, ProfileForm profileForm)
        {
            Profile = profile;
            ProfileForm = profileForm;
            UserTripList = new List<Ticket>();
            UserPastTripList = new List<Ticket>();
            InitializeComponent();
            sellTicketButton.Enabled = false;
            GetProfileRoutesInfoFromDB();
            CreateDataGridViewFromUserTripsList();
        }

        private void GetProfileRoutesInfoFromDB()
        {
            try
            {
                NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
                _connection.Open();
                string cmdText = @$"SELECT * from ticket where profile_id = {Profile.Id};";
                var _cmd = new NpgsqlCommand(cmdText, _connection);
                NpgsqlDataReader reader = _cmd.ExecuteReader();

                // Формируем полный список всех поездок
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        UserTripList.Add(new Ticket(Int32.Parse(reader.GetValue(0).ToString()),
                                                        Int32.Parse(reader.GetValue(1).ToString()),
                                                        Int32.Parse(reader.GetValue(2).ToString()),
                                                        DateTime.Parse(reader.GetValue(3).ToString()),
                                                        Single.Parse(reader.GetValue(4).ToString())));
                    }
                }
                _connection.Close();
                
                // Выделяем из всех поездок только прошедшие
                foreach (var trip in UserTripList)
                {
                    Route route = new Route(trip.RouteId);
                    DateTime selectedRouteDateTime = trip.TripDate.Add(TimeSpan.Parse(route.DepartureTime));

                    if (selectedRouteDateTime.Subtract(DateTime.Now) < TimeSpan.Zero)
                    {
                        UserPastTripList.Add(trip);
                    }
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDataGridViewFromUserTripsList()
        {
            if (tripHistoryDataSet.Tables.Contains("user_trip_history"))
            {
                tripHistoryDataSet.Tables.Clear();
            }

            DataTable userTripHistoryDataTable = new DataTable("user_trip_history");
            // добавляем таблицу в dataset
            tripHistoryDataSet.Tables.Add(userTripHistoryDataTable);

            // создаем столбцы для таблицы userTripHistory
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null

            DataColumn routeNumber = new DataColumn("Номер_маршрута", Type.GetType("System.Int32"));
            DataColumn departurePointName = new DataColumn("Точка_отправления", Type.GetType("System.String"));
            DataColumn destinationPointName = new DataColumn("Точка_прибытия", Type.GetType("System.String"));
            DataColumn departureDate = new DataColumn("Дата_отправления", Type.GetType("System.String"));
            DataColumn departureTime = new DataColumn("Время_отправления", Type.GetType("System.String"));
            DataColumn price = new DataColumn("Цена", Type.GetType("System.Single"));

            userTripHistoryDataTable.Columns.Add(idColumn);
            userTripHistoryDataTable.Columns.Add(routeNumber);
            userTripHistoryDataTable.Columns.Add(departurePointName);
            userTripHistoryDataTable.Columns.Add(destinationPointName);
            userTripHistoryDataTable.Columns.Add(departureDate);
            userTripHistoryDataTable.Columns.Add(departureTime);
            userTripHistoryDataTable.Columns.Add(price);

            // определяем первичный ключ таблицы
            userTripHistoryDataTable.PrimaryKey = new DataColumn[] { userTripHistoryDataTable.Columns["Id"] };

            // Таблица содержащая только прошедшие поездки
            DataTable userPastTripHistoryDataTable = userTripHistoryDataTable.Clone();
            userPastTripHistoryDataTable.Clear();
            userPastTripHistoryDataTable.TableName = "user_past_trip_history";
            tripHistoryDataSet.Tables.Add(userPastTripHistoryDataTable);

            // Формируем таблицу данных из списка со всеми поездками
            foreach (var userTrip in UserTripList)
            {
                Route route = new Route(userTrip.RouteId);
                userTripHistoryDataTable.Rows.Add(userTrip.Id, route.RouteNumber, route.DeparturePointString,
                    route.DestinationPointString,
                    @$"{userTrip.TripDate.Day.ToString()}-{userTrip.TripDate.Month.ToString()}-{userTrip.TripDate.Year.ToString()}",
                    route.DepartureTime, userTrip.Price.ToString());
            }

            foreach (var userTrip in UserPastTripList)
            {
                Route route = new Route(userTrip.RouteId);
                userPastTripHistoryDataTable.Rows.Add(userTrip.Id, route.RouteNumber, route.DeparturePointString,
                    route.DestinationPointString,
                    @$"{userTrip.TripDate.Day.ToString()}-{userTrip.TripDate.Month.ToString()}-{userTrip.TripDate.Year.ToString()}",
                    route.DepartureTime, userTrip.Price.ToString());
            }

            tripHistoryGrid.DataSource = tripHistoryDataSet.Tables["user_trip_history"];
            tripHistoryGrid.Sort(tripHistoryGrid.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
            
            string width = tripHistoryGrid.Width.ToString();

            tripHistoryGrid.Columns[0].Width = 75;
            tripHistoryGrid.Columns[1].Width = 139;
            tripHistoryGrid.Columns[2].Width = 315;
            tripHistoryGrid.Columns[3].Width = 315;
            tripHistoryGrid.Columns[4].Width = 154;
            tripHistoryGrid.Columns[5].Width = 153;
            tripHistoryGrid.Columns[6].Width = 153;
        }

        private void CreateDataGridViewFromDriversTripList()
        {
            if (EmployeeExtensions.IsProfileADriver(Profile.Id))
            {
                if (tripHistoryDataSet.Tables.Contains("driver_trip_history"))
                {
                    tripHistoryDataSet.Tables.Clear();
                }

                DriverTripList = VoyageExtensions.GetDriverRoutesHistory(Profile.Id);

                DataTable driverTripHistoryDataTable = new DataTable("driver_trip_history");
                // добавляем таблицу в dataset
                tripHistoryDataSet.Tables.Add(driverTripHistoryDataTable);

                DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
                idColumn.Unique = true; // столбец будет иметь уникальное значение
                idColumn.AllowDBNull = false; // не может принимать null

                DataColumn routeNumber = new DataColumn("Номер_маршрута", Type.GetType("System.Int32"));
                DataColumn departurePointName = new DataColumn("Точка_отправления", Type.GetType("System.String"));
                DataColumn destinationPointName = new DataColumn("Точка_прибытия", Type.GetType("System.String"));
                DataColumn departureTime = new DataColumn("Время_отправления", Type.GetType("System.DateTime"));
                DataColumn passangersCount = new DataColumn("Пассажиры", Type.GetType("System.Single"));

                driverTripHistoryDataTable.Columns.Add(idColumn);
                driverTripHistoryDataTable.Columns.Add(routeNumber);
                driverTripHistoryDataTable.Columns.Add(departurePointName);
                driverTripHistoryDataTable.Columns.Add(destinationPointName);
                driverTripHistoryDataTable.Columns.Add(departureTime);
                driverTripHistoryDataTable.Columns.Add(passangersCount);

                // определяем первичный ключ таблицы
                driverTripHistoryDataTable.PrimaryKey = new DataColumn[] { driverTripHistoryDataTable.Columns["Id"] };

                //Таблица содержащая только прошедшие поездки
                DataTable driverPastTripHistoryDataTable = driverTripHistoryDataTable.Clone();
                driverPastTripHistoryDataTable.Clear();
                driverPastTripHistoryDataTable.TableName = "driver_past_trip_history";
                tripHistoryDataSet.Tables.Add(driverPastTripHistoryDataTable);

                int counter = 1;

                foreach (Tuple<int,string,string,DateTime,int> driverTrip in DriverTripList)
                {
                    driverTripHistoryDataTable.Rows.Add(counter, driverTrip.Item1, driverTrip.Item2,
                    driverTrip.Item3, driverTrip.Item4, driverTrip.Item5);
                    counter++;
                }

                tripHistoryGrid.DataSource = tripHistoryDataSet.Tables["driver_trip_history"];
                tripHistoryGrid.Sort(tripHistoryGrid.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
                
                int width = tripHistoryGrid.Width;

                tripHistoryGrid.Columns[0].Width = 75;
                tripHistoryGrid.Columns[1].Width = 139;
                tripHistoryGrid.Columns[2].Width = 390;
                tripHistoryGrid.Columns[3].Width = 390;
                tripHistoryGrid.Columns[4].Width = 154;
                tripHistoryGrid.Columns[5].Width = 153;
            }
            else
            MessageBox.Show("Данный профиль не является водительским профилем!!!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ProfileForm.Show();
        }

        private void displayPastTripsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (displayPastTripsCheckBox.Checked)
            {
                if (iAmDriverCheckBox.Checked)
                    tripHistoryGrid.DataSource = tripHistoryDataSet.Tables["driver_past_trip_history"];
                else
                    tripHistoryGrid.DataSource = tripHistoryDataSet.Tables["user_past_trip_history"];
            }
            else
            {
                if (iAmDriverCheckBox.Checked)
                    tripHistoryGrid.DataSource = tripHistoryDataSet.Tables["driver_trip_history"];
                else
                    tripHistoryGrid.DataSource = tripHistoryDataSet.Tables["user_trip_history"];
            }
        }

        private void sellTicketButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedTicket = tripHistoryGrid.SelectedRows;
            SelectedTicket = UserTripList.Except(UserPastTripList).ToList().Find(x => x.Id == Int32.Parse(selectedTicket[0].Cells[0].Value.ToString()));

            if (SelectedTicket.RemoveFromDB())
                MessageBox.Show("Билет успешно возвращен !!!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tripHistoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sellTicketButton.Enabled = false;
        }

        private void tripHistoryGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (tripHistoryGrid.SelectedRows.Count == 0)
                sellTicketButton.Enabled = false;
            else
                sellTicketButton.Enabled = true;
        }

        private void iAmDriverCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (iAmDriverCheckBox.Checked)
            {
                CreateDataGridViewFromDriversTripList();
                displayPastTripsCheckBox.Enabled = false;
                sellTicketButton.Enabled = false;
            }
            else
            {
                displayPastTripsCheckBox.Enabled = true;
                sellTicketButton.Enabled = true;
                CreateDataGridViewFromUserTripsList();
            }
        }
    }
}
