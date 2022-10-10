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
    public partial class SelectCachedSqlForm : Form
    {
        public AnalyticsPanel AnalyticsPanel { get; }
        public List<CachedSql> SQLList { get; private set; }
        public List<CachedSql> MatchSqlList { get; private set; }
        public CachedSql SelectedSQL { get; private set; }

        public SelectCachedSqlForm(AnalyticsPanel analyticsPanel)
        {
            InitializeComponent();
            AnalyticsPanel = analyticsPanel;
            SQLList = new List<CachedSql>();
            GetAllCachedSQL();
            UpdateComboBox();
        }

        private void GetAllCachedSQL()
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string sql = "select (key_sentence,sql_string) from cached_sql";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object[] resArray = reader.GetValue(0) as object[];
                        SQLList.Add(new CachedSql(resArray[0].ToString(), resArray[1].ToString()));
                    }
                }

                connection.Close();
                MatchSqlList = SQLList;

            }
            catch (Exception ex)
            {
				MessageBox.Show("Не удалось получить данные о кэшированных запросах!!!" + ex.Message, "Неудача", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void FillComboBoxWithValues(List<CachedSql> listToFillCb)
        {
            sqlComboBox.Items.Clear();

            foreach (var sql in listToFillCb)
            {
                sqlComboBox.Items.Add(sql.KeySentence);
            }

            if (listToFillCb.Count != 0)
                sqlComboBox.SelectedItem = listToFillCb[0];

        }

        private void UpdateComboBox()
        {
            if (sqlKeySentenceTextBox.Text.Length != 0)
            {
                MatchSqlList = SQLList.FindAll( x => x.KeySentence.ToLower().Contains(sqlKeySentenceTextBox.Text.ToLower()));
                FillComboBoxWithValues(MatchSqlList);
            }
            else
                FillComboBoxWithValues(SQLList);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SelectedSQL = new CachedSql(sqlComboBox.SelectedItem.ToString(), isStringAKeySentence: true);
            AnalyticsPanel.SqlCommand = SelectedSQL.SQL;
            AnalyticsPanel.UpdateSQLTextBox();
            AnalyticsPanel.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AnalyticsPanel.Show();
            this.Close();
        }
    }
}
