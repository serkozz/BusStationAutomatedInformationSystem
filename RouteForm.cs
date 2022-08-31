using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class RouteForm : Form
    {
        public MainForm MainForm { get; }
        public Profile Profile { get; }
        private List<int> route_numbers = new List<int>();
        private List<int> route_departure_points_id = new List<int>();
        private List<int> route_destination_points_id = new List<int>();

        public RouteForm(MainForm mainForm, Profile profile)
        {
            MainForm = mainForm;
            Profile = profile;
            InitializeComponent();
            GetRoutesInfoFromDB();
            FillComboBoxesWithValues();
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
                        route_numbers.Add(Int32.Parse(reader.GetValue(1).ToString()));
                        route_departure_points_id.Add(Int32.Parse(reader.GetValue(2).ToString()));
                        route_destination_points_id.Add(Int32.Parse(reader.GetValue(3).ToString()));
                    }
                }
                _connection.Close();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillComboBoxesWithValues()
        {
            try
            {

            NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
            _connection.Open();

            foreach (var number in route_numbers)
            {
                string cmdText = @$"SELECT route_number from route where route_number = {number.ToString()};";
                var _cmd = new NpgsqlCommand(cmdText, _connection);
                string routeNumberString = _cmd.ExecuteScalar().ToString();
                routeNumberComboBox.Items.Add(routeNumberString);
            }

            foreach (var departure_point_id in route_departure_points_id)
            {
                string cmdText = @$"SELECT * from address where id = {departure_point_id.ToString()};";
                var _cmd = new NpgsqlCommand(cmdText, _connection);
                NpgsqlDataReader reader = _cmd.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        departurePointCityComboBox.Items.Add(reader.GetValue(1).ToString());
                        departurePointStreetComboBox.Items.Add(reader.GetValue(2).ToString());
                    }
                }
                reader.Close();
            }

            foreach (var destination_point_id in route_destination_points_id)
            {
                string cmdText = @$"SELECT * from address where id = {destination_point_id.ToString()};";
                var _cmd = new NpgsqlCommand(cmdText, _connection);
                NpgsqlDataReader reader = _cmd.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        destinatrionPointCityComboBox.Items.Add(reader.GetValue(1).ToString());
                        destinatrionPointStreetComboBox.Items.Add(reader.GetValue(2).ToString());
                    }
                }
                reader.Close();
            }
            _connection.Close();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
