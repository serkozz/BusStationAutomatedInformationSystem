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
        public string SqlCommand { get; set; }
        public AnalyticsPanel(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            // TestTableParser();
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

        public void UpdateSQLTextBox()
        {
            sqlTextBox.Text = SqlCommand;
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
            a => a.Item1, a => a.Item2, a => a.Item3) + "\n";
        }

        private string GetData(string sql)
        {
            try
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
                    int count = 0;
                    
                    foreach (NpgsqlDbColumn column in columnSchema)
                    {
                        if (count < columnSchema.Count - 1)
                            resultString += column.ColumnName + "   ---   ";
                        else
                            resultString += column.ColumnName;
                        count++;
                    }

                    resultString += "\n";

                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            bool isOneColumnAnswer = true;

                            switch (reader.GetFieldType(i).Name)
                            {
                                case "Int32":
                                    isOneColumnAnswer = false;
                                    resultString += (reader.GetFieldValue<int?>(i) ?? -1).ToString();
                                    break;
                                case "String":
                                    try
                                    {
                                        # nullable enable
                                        isOneColumnAnswer = false;
                                        string? nullableValue  = reader.GetFieldValue<string?>(i);
                                        resultString += nullableValue;
                                    }
                                    catch (Exception)
                                    {
                                        resultString += "NULL";
                                    }
                                    break;
                                case "Boolean":
                                    isOneColumnAnswer = false;
                                    resultString += reader.GetFieldValue<bool>(i).ToString();
                                    break;
                                case "DateTime":
                                    isOneColumnAnswer = false;
                                    resultString += (reader.GetFieldValue<DateTime?>(i) ?? DateTime.MinValue).ToString();
                                    break;
                                case "Float":
                                    isOneColumnAnswer = false;
                                    resultString += (reader.GetFieldValue<float?>(i) ?? float.NaN).ToString();
                                    break;
                                case "Double":
                                    isOneColumnAnswer = false;
                                    resultString += (reader.GetFieldValue<double?>(i) ?? double.NaN).ToString();
                                    break;
                            }

                            if (isOneColumnAnswer)
                            {
                                object[]? resArray = reader.GetValue(0) as object[];
                                int counter = 0;

                                if (resArray is not null)
                                {
                                    foreach (var item in resArray)
                                    {
                                        if (counter < resArray.Length - 1)
                                            resultString += item.ToString() + "   ---   ";
                                        else
                                            resultString += item.ToString();
                                        counter++;
                                    }
                                }
                            }
                            else
                                resultString += "   ---   ";
                        }
                        resultString += "\n";
                    }
                }
                connection.Close();
                return resultString;
            }
            catch (Exception ex)
            {
				MessageBox.Show("Не удалось получить данные!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void openCachedSqlButton_Click(object sender, EventArgs e)
        {
            SelectCachedSqlForm selectCachedSqlForm = new SelectCachedSqlForm(this);
            selectCachedSqlForm.Location = this.Location;
            selectCachedSqlForm.Show();
            this.Hide();
        }

        private void cacheSqlButton_Click(object sender, EventArgs e)
        {
            SqlCommand = sqlTextBox.Text;
            CacheSqlForm casheSqlForm = new CacheSqlForm(this);
            casheSqlForm.Location = this.Location;
            casheSqlForm.Show();
            this.Hide();
        }
    }
}
