using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
    public partial class MainForm : Form
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=password;Database=AISDepot";

        public MainForm()
        {
            InitializeComponent();
        }

        private string GetConnectionString()
        {
            return connectionString;
        }

        private static NpgsqlConnection CreateConnection(string connectionString) // Используется для получения доступа к PostgreSQL
        {
            return new NpgsqlConnection(connectionString);
        }

        private static async void DatabaseConnect() // Подключение к базе данных
        {
            await using (NpgsqlConnection connection = CreateConnection(connectionString))
            {
                await connection.OpenAsync(); // Асинхронное подключение к базе данных

                if (connection.State == ConnectionState.Open) // Если соединение установлено
                {
                    MessageBox.Show("Подключение успешно! \nСтатус подключения: " + connection.State
                        + "\n Информация подключении:\n 1) Имя базы данных: " + connection.Database
                        + "\n 2) Хост базы данных: " + connection.Host + "\n 3) Порт базы данных: " + connection.Port, "Соединение установлено!!!");
                }
                else // Если соединение не установлено
                    MessageBox.Show("Подключение не удалось! \nСтатус подключения: " + connection.State
                        + "\n Информация подключении:\n 1) Имя базы данных: " + connection.Database
                        + "\n 2) Хост базы данных: " + connection.Host + "\n 3) Порт базы данных: " + connection.Port, "Соединение не установлено!!!");
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            DatabaseConnect(); // Подключение к базе данных
        }
    }
}
