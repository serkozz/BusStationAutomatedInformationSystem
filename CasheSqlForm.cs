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
    public partial class CasheSqlForm : Form
    {
        public AnalyticsPanel AnalyticsPanel { get; }
        public string SQL { get; private set; }
        public string KeySentence { get; private set; }

        public CasheSqlForm(AnalyticsPanel analyticsPanel)
        {
            InitializeComponent();
            AnalyticsPanel = analyticsPanel;
            SQL = AnalyticsPanel.SqlCommand;
            sqlTextBox.Text = SQL;
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SQL = sqlTextBox.Text.ToLower();
            KeySentence = keySequenceTextBox.Text.ToLower();

            if (ValidateSQL(SQL) && KeySentence.Length > 5)
            {
                if (CacheSQL() == 1)
                    MessageBox.Show("SQL запрос успешно закеширован!!", "Успех!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (CacheSQL() == 0)
                    MessageBox.Show("SQL запрос с подобным ключом или телом уже существует!!", "Неудача!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("SQL запрос не был закеширован!!!", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AnalyticsPanel.Show();
            this.Close();
        }

        private int CacheSQL()
        {
            try
            {
                NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string duplicateCheck = @$"select (id) from cached_sql where key_sentence = '{KeySentence}' OR sql_string = '{SQL}'";
                string cmdText = @$"insert into cached_sql (key_sentence,sql_string) values ('{KeySentence}', '{SQL}') returning id";
                var _cmd = new NpgsqlCommand(duplicateCheck, connection);
                var result = _cmd.ExecuteScalar();

                if (result != null) // Найден дубликат, ничего не добавляем
                {
                    connection.Close();
                    return 0;
                }
                else
                {
                    _cmd = new NpgsqlCommand(cmdText, connection);
                    result = (int)_cmd.ExecuteScalar();
                    connection.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось кэшировать запрос" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private bool ValidateSQL(string sql)
        {
            try
            {
                NpgsqlConnection connection = new Npgsql.NpgsqlConnection(Constants._connectionString);
                connection.Open();
                var _cmd = new NpgsqlCommand(sql, connection);
                var result = _cmd.ExecuteScalar();

                if (result != null) // Запрос выполняется и есть результат
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось валидировать запрос" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
