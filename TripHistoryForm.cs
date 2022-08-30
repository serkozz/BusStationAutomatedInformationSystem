using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class TripHistoryForm : Form
    {
        public Profile Profile { get; set; }
        public ProfileForm ProfileForm { get; set; }
        public List<Route> RoutesList { get; private set; }
        public List<Tuple<Route,DateTime>> RoutesDateTimeList { get; private set; }
        public bool IsPastTripsDisplayed { get; private set; } = true;
        private DataSet userTripHistoryDataSet = new DataSet("user_trip_history");
        private DataTable userTripHistoryDataTable = new DataTable("user_trip_history");

        public TripHistoryForm(Profile profile, ProfileForm profileForm)
        {
            Profile = profile;
            ProfileForm = profileForm;
            RoutesList = new List<Route>();
            InitializeComponent();
            GetProfileRoutesInfoFromDB();
        }

        private void GetProfileRoutesInfoFromDB()
        {
            try
            {
                NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
                _connection.Open();
                string cmdText = @$"SELECT * from user_trip_history where profile_id = {Profile.Id};";
                var _cmd = new NpgsqlCommand(cmdText, _connection);
                NpgsqlDataReader reader = _cmd.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        RoutesList.Add(new Route((int)reader.GetValue(2)));
                        RoutesDateTimeList.Add(new Tuple<Route, DateTime>(RoutesList.Last(), DateTime.Parse(reader.GetValue(3).ToString())));
                    }
                }
                _connection.Close();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDataGridViewFromRoutesList()
        {
            // добавляем таблицу в dataset
            userTripHistoryDataSet.Tables.Add(userTripHistoryDataTable);

            // создаем столбцы для таблицы userTripHistory
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            DataColumn routeNumber = new DataColumn("Номер_маршрута", Type.GetType("System.Int32"));
            DataColumn departurePointName = new DataColumn("Точка_отправления", Type.GetType("System.String"));
            DataColumn destinationPointName = new DataColumn("Точка_прибытия", Type.GetType("System.String"));
            DataColumn departureDate = new DataColumn("Дата_отправления", Type.GetType("System.String"));
            DataColumn departureTime = new DataColumn("Время_отправления", Type.GetType("System.String"));
            DataColumn destinationTime = new DataColumn("Время_прибытия", Type.GetType("System.String"));

            userTripHistoryDataTable.Columns.Add(idColumn);
            userTripHistoryDataTable.Columns.Add(routeNumber);
            userTripHistoryDataTable.Columns.Add(departurePointName);
            userTripHistoryDataTable.Columns.Add(destinationPointName);
            userTripHistoryDataTable.Columns.Add(departureDate);
            userTripHistoryDataTable.Columns.Add(departureTime);
            userTripHistoryDataTable.Columns.Add(destinationTime);

            // определяем первичный ключ таблицы
            userTripHistoryDataTable.PrimaryKey = new DataColumn[] { userTripHistoryDataTable.Columns["Id"] };

            // filteredDataTable = routeDataTable.Clone();
            // filteredDataTable.TableName = "filtered";
            // filteredDataTable.Clear();

            // routeDataSet.Tables.Add(filteredDataTable);

            foreach (var route in RoutesList)
            {
                userTripHistoryDataTable.Rows.Add(null, route.RouteNumber, route.DeparturePointString,
                    route.DestinationPointString, RoutesDateTimeList.Find(x => x.Item1.Id == route.Id), route.DepartureTime, route.DestinationTime);
            }

            tripHistoryGrid.DataSource = userTripHistoryDataSet.Tables["user_trip_history"];
            tripHistoryGrid.Sort(tripHistoryGrid.Columns[4], System.ComponentModel.ListSortDirection.Ascending);
            
            // DataGrid width = 1158
            // routeGrid.Columns[0].Width = 100;
            // routeGrid.Columns[1].Width = 139;
            // routeGrid.Columns[2].Width = 289;
            // routeGrid.Columns[3].Width = 289;
            // routeGrid.Columns[4].Width = 154;
            // routeGrid.Columns[5].Width = 133;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ProfileForm.Show();
        }

        private void pastTripsRadioButton_Click(object sender, EventArgs e)
        {
            IsPastTripsDisplayed = true;
        }

        private void futureTripsRadioButton_Click(object sender, EventArgs e)
        {
            IsPastTripsDisplayed = false;
        }
    }
}
