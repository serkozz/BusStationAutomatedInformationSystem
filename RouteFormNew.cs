using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class RouteFormNew : Form
    {
        public MainForm MainForm { get; }
        public Profile Profile { get; }
        public List<Route> RoutesList { get; private set; } = new List<Route>();
        private DataTable routeDataTable = new DataTable("route");
        private DataTable filteredDataTable;
        private DataSet routeDataSet = new DataSet("route");
        public Route SelectedRoute { get; private set; }

        public RouteFormNew(MainForm mainForm, Profile profile)
        {
            MainForm = mainForm;
            Profile = profile;
            InitializeComponent();
            GetRoutesInfoFromDB();
            CreateDataGridViewFromRoutesList();
            // Отключение кнопки покупки билета при отсутствии выделения строки маршрута
            buyTicketButton.Enabled = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            this.Close();
        }

        private void GetRoutesInfoFromDB()
        {
            try
            {
                NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
                _connection.Open();
                string cmdText = @$"SELECT * from route;";
                var _cmd = new NpgsqlCommand(cmdText, _connection);
                NpgsqlDataReader reader = _cmd.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        RoutesList.Add(new Route(Int32.Parse(reader.GetValue(0).ToString()),
                                    Int32.Parse(reader.GetValue(1).ToString()),
                                    Int32.Parse(reader.GetValue(2).ToString()),
                                    Int32.Parse(reader.GetValue(3).ToString()),
                                    reader.GetValue(4).ToString(), float.Parse(reader.GetValue(5).ToString())));
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
            routeDataSet.Tables.Add(routeDataTable);

            // создаем столбцы для таблицы route
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            // idColumn.AutoIncrement = true; // будет автоинкрементироваться
            // idColumn.AutoIncrementSeed = 1; // начальное значение
            // idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            DataColumn routeNumber = new DataColumn("Номер_маршрута", Type.GetType("System.Int32"));
            DataColumn departurePointName = new DataColumn("Точка_отправления", Type.GetType("System.String"));
            DataColumn destinationPointName = new DataColumn("Точка_прибытия", Type.GetType("System.String"));
            DataColumn departureTime = new DataColumn("Время_отправления", Type.GetType("System.String"));

            routeDataTable.Columns.Add(idColumn);
            routeDataTable.Columns.Add(routeNumber);
            routeDataTable.Columns.Add(departurePointName);
            routeDataTable.Columns.Add(destinationPointName);
            routeDataTable.Columns.Add(departureTime);

            // определяем первичный ключ таблицы
            routeDataTable.PrimaryKey = new DataColumn[] { routeDataTable.Columns["Id"] };

            filteredDataTable = routeDataTable.Clone();
            filteredDataTable.TableName = "filtered";
            filteredDataTable.Clear();

            routeDataSet.Tables.Add(filteredDataTable);

            foreach (var route in RoutesList)
            {
                routeDataTable.Rows.Add(route.Id, route.RouteNumber, route.DeparturePointString,
                    route.DestinationPointString, route.DepartureTime);
            }

            routeGrid.DataSource = routeDataSet.Tables["route"];
            routeGrid.Sort(routeGrid.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
            
            // DataGrid width = 1158
            routeGrid.Columns[0].Width = 100;
            routeGrid.Columns[1].Width = 139;
            routeGrid.Columns[2].Width = 300;
            routeGrid.Columns[3].Width = 300;
            routeGrid.Columns[4].Width = 155;
        }

        private void findRouteButton_Click(object sender, EventArgs e)
        {
            try
            {
                routeGrid.DataSource = routeDataTable;
                filteredDataTable.Rows.Clear();

                string selectCommand = string.Empty;
                int parsedNumber = 0;
                int argumentsNumber = 0;
                
                Int32.TryParse(routeNumberTextBox.Text, out parsedNumber);

                if (parsedNumber != 0)
                {
                    if (argumentsNumber != 0)
                        selectCommand += @$" AND Номер_маршрута = {parsedNumber}";
                    else
                        selectCommand +=@$"Номер_маршрута = {parsedNumber}";

                    argumentsNumber++;
                }

                if (departurePointTextBox.TextLength != 0)
                {
                    if (argumentsNumber != 0)
                        selectCommand += @$" AND Точка_отправления LIKE '%{departurePointTextBox.Text}%'";
                    else
                        selectCommand += @$"Точка_отправления LIKE '%{departurePointTextBox.Text}%'";

                    argumentsNumber++;
                }

                if (destinationPointTextBox.TextLength != 0)
                {
                    if (argumentsNumber != 0)
                        selectCommand += @$" AND Точка_прибытия LIKE '%{destinationPointTextBox.Text}%'";
                    else
                        selectCommand += @$"Точка_прибытия LIKE '%{destinationPointTextBox.Text}%'";

                    argumentsNumber++;
                }

                DataRow[] results = routeDataTable.Select(selectCommand);

                foreach (var result in results)
                {
                    filteredDataTable.Rows.Add((int)result.ItemArray[0], (int)result.ItemArray[1],
                    result.ItemArray[2].ToString(), result.ItemArray[3].ToString(),
                    result.ItemArray[4].ToString());
                }

                routeGrid.DataSource = filteredDataTable;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            routeGrid.DataSource = routeDataTable;
            filteredDataTable.Clear();
        }

        private void buyTicketButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = routeGrid.SelectedRows;

            SelectedRoute = RoutesList.Find(x => x.Id == Int32.Parse(selected[0].Cells[0].Value.ToString()));
            this.Hide();
            TicketPurchaseForm ticketPurchaseForm = new TicketPurchaseForm(Profile, this);
            ticketPurchaseForm.Location = this.Location;
            ticketPurchaseForm.Show();
        }

        // Включает кнопку покупки билета при выделении строки маршрута
        private void routeGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (routeGrid.SelectedRows.Count == 0)
                buyTicketButton.Enabled = false;
            else
                buyTicketButton.Enabled = true;
        }

        // Отключает кнопку покупки билета если не выделена строка нужного маршрута
        private void routeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buyTicketButton.Enabled = false;
        }
    }
}
