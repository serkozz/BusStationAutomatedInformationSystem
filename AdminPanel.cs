using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
	public partial class AdminPanel : Form
	{
		private MainForm mainForm;
		private Profile profile;
		private NpgsqlConnection connection;
		private NpgsqlDataAdapter dataAdapter;
		private NpgsqlCommandBuilder commandBuilder;
		private DataSet dataSet;
		private bool newRowAdding = false;
		private Table currentTable;

		public AdminPanel(MainForm form, Profile profile)
		{
			mainForm = form;
			this.profile = profile;
			InitializeComponent();
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			mainForm.Location = this.Location;
			//mainForm.UpdateProfileData();
			mainForm.Show();
			this.Close();
		}

		private void AdminPanel_Load(object sender, EventArgs e)
		{
			connection = new NpgsqlConnection(Constants._connectionString);
			connection.Open();
			currentTable = new Table("users");
			tableComboBox.SelectedValue = "users";
			FIllComboboxWithTables();
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				dataAdapter = new NpgsqlDataAdapter(@$"Select *, 'Delete' AS Command FROM {currentTable.TableName}", connection);
				commandBuilder = new NpgsqlCommandBuilder(dataAdapter);

				commandBuilder.GetInsertCommand();
				commandBuilder.GetUpdateCommand();
				commandBuilder.GetDeleteCommand();

				dataSet = new DataSet();

				dataAdapter.Fill(dataSet, currentTable.TableName);
				dataGridView1.DataSource = dataSet.Tables[currentTable.TableName];

				for (var i = 0; i < dataGridView1.Rows.Count; i++)
				{
					DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

					dataGridView1[currentTable.ColumnsCount, i] = linkCell;
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == currentTable.ColumnsCount)
				{
					string task = dataGridView1.Rows[e.RowIndex].Cells[currentTable.ColumnsCount].Value.ToString();

					if (task == "Delete")
					{
						if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							int rowIndex = e.RowIndex;
							dataGridView1.Rows.RemoveAt(rowIndex);
							dataSet.Tables[currentTable.TableName].Rows[rowIndex].Delete();
							int result = dataAdapter.Update(dataSet, currentTable.TableName);
						}
					}
					else if (task == "Insert")
					{
						int rowIndex = dataGridView1.Rows.Count - 2; // - 2 was
						DataRow row = dataSet.Tables[currentTable.TableName].NewRow();

						for (var i = 0; i < currentTable.ColumnsCount; i++)
						{
							if (currentTable.TableName == "users" && i == 2)
								row[currentTable.ColumnsNames[2]] = Utility.GetSHA256(dataGridView1.Rows[rowIndex].Cells[currentTable.ColumnsNames[2]].Value.ToString());
							else
								row[currentTable.ColumnsNames[i]] = dataGridView1.Rows[rowIndex].Cells[currentTable.ColumnsNames[i]].Value;
						}

						dataSet.Tables[currentTable.TableName].Rows.Add(row);
						dataSet.Tables[currentTable.TableName].Rows.RemoveAt(dataSet.Tables[currentTable.TableName].Rows.Count - 1);
						dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
						dataGridView1.Rows[e.RowIndex].Cells[currentTable.ColumnsCount].Value = "Delete";

						int result = dataAdapter.Update(dataSet, currentTable.TableName);
						newRowAdding = false;
					}

					else if (task == "Update")
					{
						int rowIndex = e.RowIndex;

						foreach (string columnName in currentTable.ColumnsNames)
						{
							dataSet.Tables[currentTable.TableName].Rows[rowIndex][columnName] = dataGridView1.Rows[rowIndex].Cells[columnName].Value;
						}

						if (currentTable.TableName == "users")
							dataSet.Tables["users"].Rows[rowIndex]["password"] = Utility.GetSHA256(dataGridView1.Rows[rowIndex].Cells["password"].Value.ToString());

						int result = dataAdapter.Update(dataSet, currentTable.TableName);
						dataGridView1.Rows[e.RowIndex].Cells[currentTable.ColumnsCount].Value = "Delete";
					}
					LoadData(); /////////// Reload data was
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
					dataGridView1[currentTable.ColumnsCount, lastRow] = linkCell;
					row.Cells["Command"].Value = "Insert";
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (newRowAdding == false)
				{
					int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

					DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
					DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
					dataGridView1[currentTable.ColumnsCount, rowIndex] = linkCell; // columns count of datagrid != columns of tables (added command column in datagrid)
					editingRow.Cells["Command"].Value = "Update";
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
		}

		private void Column_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void FIllComboboxWithTables()
		{
			try
			{
				tableComboBox.Items.Clear();
				NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
				_connection.Open();
				string getTablesNamesCmd = @$"select table_name from information_schema.tables where table_schema = 'public'";
				var _cmd = new NpgsqlCommand(getTablesNamesCmd, _connection);
				NpgsqlDataReader reader = _cmd.ExecuteReader();

				if (reader.HasRows) // если есть данные
				{
					while (reader.Read()) // построчно считываем данные
					{
						string tableName = reader.GetValue(0).ToString();
						tableComboBox.Items.Add(tableName);
					}
				}
				_connection.Close();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentTable = new Table((string)tableComboBox.SelectedItem.ToString());
			LoadData();
		}

		private void voyageManagementButton_Click(object sender, EventArgs e)
		{
			VoyageManagementForm voyageManagementForm = new VoyageManagementForm(this);
			voyageManagementForm.Location = this.Location;
			voyageManagementForm.Show();
			this.Hide();
		}
	}

	public class Table
	{
		public string TableName { get; }
		public int ColumnsCount { get; }
		public string[] ColumnsNames { get; }

		public Table(string name)
		{
			TableName = name;
			ColumnsCount = GetColumnsCount();
			ColumnsNames = GetColumnsNames();
		}

		private int GetColumnsCount()
		{
			try
			{
				NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
				_connection.Open();
				string cmdText = @$"SELECT COUNT(*) FROM information_schema.columns where table_name = '{TableName}';";
				var _cmd = new NpgsqlCommand(cmdText, _connection);
				int count = Int32.Parse(_cmd.ExecuteScalar().ToString());
				_connection.Close();
				return count;
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
		}

		private string[] GetColumnsNames()
		{
			try
			{
				List<string> columnsNames = new List<string>();

				NpgsqlConnection _connection = new NpgsqlConnection(Constants._connectionString);
				_connection.Open();
				string cmdText = @$"SELECT column_name FROM information_schema.columns where table_name = '{TableName}';";
				var _cmd = new NpgsqlCommand(cmdText, _connection);
				NpgsqlDataReader reader = _cmd.ExecuteReader();

				if (reader.HasRows) // если есть данные
				{
					while (reader.Read()) // построчно считываем данные
					{
						string columnName = reader.GetValue(0).ToString();
						columnsNames.Add(columnName);
					}
				}

				_connection.Close();
				return columnsNames.ToArray();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Произошла ошибка!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	}
}
