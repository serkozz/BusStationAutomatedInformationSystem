using System.Linq;
using System.Data;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
	public partial class VoyageManagementForm : Form
	{
		public AdminPanel AdminPanel { get; }
		public List<DateTime> DateWithTicketsBought { get; private set; }
		public DateTime SelectedDate { get; private set; }
		public List<Ticket> SelectedDateTickets { get; private set; } = new List<Ticket>();
		public List<Route> SelectedDateRoutes { get; private set; } = new List<Route>();

		public int BusNumber { get; private set; }
		public string DriverFullName { get; private set; }
		public string DeparturePointName { get; private set; }
		public string DestinationPointName { get; private set; }
		public int TicketsCount { get; private set; }
		public DateTime DepartureTime { get; private set; }

		private DataSet DataSet = new DataSet("info");
		private DataTable DataTable = new DataTable("info");

		public VoyageManagementForm(AdminPanel adminPanel)
		{
			AdminPanel = adminPanel;
			InitializeComponent();
			applyButton.Enabled = false;
			OnFormLoad();
		}

		private void OnFormLoad()
		{
			DateWithTicketsBought = TicketExtensions.GetAllDatesWithTickets();
			
			if (DateWithTicketsBought != null)
			{
				foreach (var date in DateWithTicketsBought)
				{
					calendar.AddBoldedDate(date);
				}
			}
			calendar.Update();
			CreateInfoGrid();
			
			// Выгрузить в календарь все даты, на которые есть хотя бы один билет
			// При выборе нужной даты должен подсасываться автобус который ходит по этому маршруту, и по нажатию на кнопку назначить,
			// должна содаваться запись в таблице voyage содержащая автобус  маршрут и список билетов (по дбдиаграм ио)
		}

		private void CreateInfoGrid()
		{
			// Загружать в грид инфу при выборе определенного дня и определенного маршрутаю
			// Инфа в гриде должна быть о водителе, автобусе, самом рейсе а также список билетов на рейс (айдишники) и дата отправления
			// добавляем таблицу в dataset
            DataSet.Tables.Add(DataTable);

            // создаем столбцы для таблицы route
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
			idColumn.AutoIncrementSeed = 0;
			idColumn.AutoIncrement = true;
			idColumn.AutoIncrementStep = 1;

            DataColumn routeNumber = new DataColumn("Маршрут", Type.GetType("System.Int32"));
            DataColumn driverName = new DataColumn("Водитель", Type.GetType("System.String"));
            DataColumn departurePointName = new DataColumn("Точка_отправления", Type.GetType("System.String"));
            DataColumn destinationPointName = new DataColumn("Точка_прибытия", Type.GetType("System.String"));
            DataColumn departureTime = new DataColumn("Время_отправления", Type.GetType("System.String"));
            DataColumn ticketsCount = new DataColumn("Количество_пассажиров", Type.GetType("System.Int32"));

            DataTable.Columns.Add(idColumn);
            DataTable.Columns.Add(routeNumber);
            DataTable.Columns.Add(driverName);
            DataTable.Columns.Add(departurePointName);
            DataTable.Columns.Add(destinationPointName);
            DataTable.Columns.Add(departureTime);
            DataTable.Columns.Add(ticketsCount);

            // определяем первичный ключ таблицы
            DataTable.PrimaryKey = new DataColumn[] { DataTable.Columns["Id"] };

			DataTable.Rows.Add(null, BusNumber, DriverFullName, DeparturePointName, DestinationPointName, DepartureTime.ToString(), TicketsCount);

            infoGrid.DataSource = DataSet.Tables["info"];            

            infoGrid.Columns[0].Width = 50;
            infoGrid.Columns[1].Width = 100;
            infoGrid.Columns[2].Width = 200;
            infoGrid.Columns[3].Width = 300;
            infoGrid.Columns[4].Width = 300;
            infoGrid.Columns[5].Width = 150;
            infoGrid.Columns[6].Width = 100;
		}

		private void UpdateInfoGrid()
		{
			DataTable.Rows.Clear();
			DataTable.Rows.Add(null, BusNumber, DriverFullName, DeparturePointName, DestinationPointName, DepartureTime.ToString(), TicketsCount);
			infoGrid.DataSource = DataSet.Tables["info"];
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			this.Close();
			AdminPanel.Show();
		}

		private void calendar_DateSelected(object sender, DateRangeEventArgs e)
		{
			SelectedDate = e.Start;
			SelectedDateTickets.Clear();
			SelectedDateTickets = TicketExtensions.GetAllTicketsByDate(SelectedDate);
			GetSelectedDateRoutesBySelectedDateTickets();
			FillBusComboBox();
			DataTable.Rows.Clear();
			infoGrid.Update();
		}

        private void applyButton_Click(object sender, EventArgs e)
        {
			try
			{
				Route rt = SelectedDateRoutes.Find(x => x.RouteNumber == BusNumber);
				Voyage voyage = new Voyage(rt.Id,
				BusExtensions.GetBusIdByNumberAndDriverName(rt.RouteNumber, DriverFullName),
				TicketsCount, DepartureTime);
                MessageBox.Show("Автобус назначен на маршрут!!!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception ex)
			{
                MessageBox.Show($"Автобус не был назначен на маршрут!!! + {ex.Message}", "Неудача!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		/// <summary>
		/// Возвращает список маршрутов с НЕПОВТОРЯЮЩИМИСЯ ЭЛЕМЕНТАМИ имея список билетов
		/// </summary>
		private void GetSelectedDateRoutesBySelectedDateTickets()
		{
			SelectedDateRoutes.Clear();
			List<int> routeIdsList = new List<int>();
			foreach (var ticket in SelectedDateTickets)
			{
				if (!routeIdsList.Contains(ticket.RouteId))
					routeIdsList.Add(ticket.RouteId);
			}

			foreach (var id in routeIdsList)
			{
				SelectedDateRoutes.Add(new Route(id));
			}
		}

		private void FillBusComboBox()
		{
			busComboBox.Items.Clear();

			foreach (var route in SelectedDateRoutes)
			{
				var result = BusExtensions.GetBusDriverArrayByBusNumber(route.RouteNumber);
                string resultString = $"{result[0].ToString()}#{result[1].ToString()} {result[2].ToString()} {result[3].ToString()}";

                busComboBox.Items.Add(resultString);
			}
		}

        private void busComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			ComboBox cb = sender as ComboBox;
			string busDriverString = (sender as ComboBox).SelectedItem.ToString();
			string driverNamePattern = "(?<=#).*";
			DriverFullName = new Regex(driverNamePattern).Match(busDriverString).Value;
			string busNumberPattern = "^[^#]*";
			BusNumber = Int32.Parse(new Regex(busNumberPattern).Match(busDriverString).Value);
			DeparturePointName = SelectedDateRoutes.Find(x => x.RouteNumber == BusNumber).DeparturePointString;
			DestinationPointName = SelectedDateRoutes.Find(x => x.RouteNumber == BusNumber).DestinationPointString;
			DepartureTime = SelectedDate.Add(TimeSpan.Parse(SelectedDateRoutes.Find(x => x.DeparturePointString == DeparturePointName && x.DestinationPointString == DestinationPointName && x.RouteNumber == BusNumber).DepartureTime));
			TicketsCount = SelectedDateTickets.FindAll(x => x.TripDate == SelectedDate && x.RouteId == RouteExtensions.GetRouteIdByNumber(BusNumber)).Count;
			UpdateInfoGrid();
        }

        private void infoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			applyButton.Enabled = false;
        }

        private void infoGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
			applyButton.Enabled = true;
        }
    }
}
