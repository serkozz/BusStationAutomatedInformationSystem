using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Npgsql.Schema;

namespace BusStationAutomatedInformationSystem
{
    public partial class AnalyticsPanel : Form
    {
        public MainForm MainForm { get; }
        public string SqlCommand { get; private set; }
        public AnalyticsPanel(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            TestTableParser();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            this.Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand = sqlTextBox.Text;
                resultTextBox.Text = GetData(SqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так: " + ex.Message, "Ошибочный запрос", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TestTableParser()
        {
            IEnumerable<Tuple<int, string, string>> utility_table =
            new[]
            {
            Tuple.Create(1, "connection_string", "connecting"),
            Tuple.Create(2, "rublesPerKilometer", "7"),
            };

            resultTextBox.Text += utility_table.ToStringTable(
            new[] {"Id", "Property", "Value"},
            a => a.Item1, a => a.Item2, a => a.Item3);
        }

        private string GetData(string sql)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            string resultString = string.Empty;

            if (reader.HasRows)
            {
                // Получаем схему колонок таблицы
                ReadOnlyCollection<NpgsqlDbColumn> columnSchema = reader.GetColumnSchema();
                
                foreach (NpgsqlDbColumn column in columnSchema)
                {
                    resultString += column.ColumnName;
                }

                resultString += "\n";

                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        switch (reader.GetFieldType(i).Name)
                        {
                            case "Int32":
                                resultString += reader.GetFieldValue<int>(i).ToString();
                                break;
                            case "String":
                                resultString += reader.GetFieldValue<string>(i).ToString();
                                break;
                            case "Boolean":
                                resultString += reader.GetFieldValue<bool>(i).ToString();
                                break;
                            case "DateTime":
                                resultString += reader.GetFieldValue<DateTime>(i).ToString();
                                break;
                            case "Float":
                                resultString += reader.GetFieldValue<float>(i).ToString();
                                break;
                            case "Double":
                                resultString += reader.GetFieldValue<double>(i).ToString();
                                break;
                        }
                        resultString += " --- ";
                    }
                    resultString += "\n";
                }
            }
            connection.Close();
            return resultString;
        }

        private void openCachedSqlButton_Click(object sender, EventArgs e)
        {

        }

        private void cacheSqlButton_Click(object sender, EventArgs e)
        {
            CasheSqlForm casheSqlForm = new CasheSqlForm(this);
            casheSqlForm.Location = this.Location;
            casheSqlForm.Show();
            this.Hide();
        }
    }
}
