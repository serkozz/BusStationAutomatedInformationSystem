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
        private Ticket SelectedTicket;
        private DataSet userTripHistoryDataSet = new DataSet("user_trip_history");
        private DataTable userTripHistoryDataTable = new DataTable("user_trip_history");
        private DataTable userPastTripHistoryDataTable = new DataTable("user_past_trip_history");

        public TripHistoryForm(Profile profile, ProfileForm profileForm)
        {
            Profile = profile;
            ProfileForm = profileForm;
            UserTripList = new List<Ticket>();
            UserPastTripList = new List<Ticket>();
            InitializeComponent();
            sellTicketButton.Enabled = false;
            GetProfileRoutesInfoFromDB();
            CreateDataGridViewFromTripsList();
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

        private void CreateDataGridViewFromTripsList()
        {
            // добавляем таблицу в dataset
            userTripHistoryDataSet.Tables.Add(userTripHistoryDataTable);

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
            userPastTripHistoryDataTable = userTripHistoryDataTable.Clone();
            userPastTripHistoryDataTable.Clear();
            userPastTripHistoryDataTable.TableName = "user_past_trip_history";
            userTripHistoryDataSet.Tables.Add(userPastTripHistoryDataTable);

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

            tripHistoryGrid.DataSource = userTripHistoryDataSet.Tables["user_trip_history"];
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
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ProfileForm.Show();
        }

        private void displayPastTripsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (displayPastTripsCheckBox.Checked)
                tripHistoryGrid.DataSource = userTripHistoryDataSet.Tables["user_past_trip_history"];
            else
                tripHistoryGrid.DataSource = userTripHistoryDataSet.Tables["user_trip_history"];
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
    }
}
