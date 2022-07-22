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
    public partial class AdminPanel : Form
    {
        private MainForm mainForm;
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter dataAdapter;
        private NpgsqlCommandBuilder commandBuilder;
        private DataSet dataSet;
        private bool newRowAdding = false;
        public AdminPanel(MainForm form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.Location = this.Location;
            mainForm.Show();
            this.Close();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(Constants._connectionString);
            connection.Open();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataAdapter = new NpgsqlDataAdapter("Select *, 'Delete' AS Delete FROM users", connection);
                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

                commandBuilder.GetInsertCommand();
                commandBuilder.GetUpdateCommand();
                commandBuilder.GetDeleteCommand();
                
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "users");
                dataGridView1.DataSource = dataSet.Tables["users"];

                for (var i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[3, i] = linkCell;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["users"].Clear();
                dataAdapter.Fill(dataSet, "users");
                dataGridView1.DataSource = dataSet.Tables["users"];

                for (var i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[3, i] = linkCell;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["users"].Rows[rowIndex].Delete();
                            dataAdapter.Update(dataSet, "users");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["users"].NewRow();

                        row["login"] = dataGridView1.Rows[rowIndex].Cells["login"].Value;
                        row["password"] = Utility.GetSHA256(dataGridView1.Rows[rowIndex].Cells["password"].Value.ToString());

                        dataSet.Tables["users"].Rows.Add(row);
                        dataSet.Tables["users"].Rows.RemoveAt(dataSet.Tables["users"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";

                        dataAdapter.Update(dataSet, "users");
                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {

                    }
                    ReloadData();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView1.Rows.Count - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, lastRow] = linkCell;
                    row.Cells["Delete"].Value = "Insert";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
