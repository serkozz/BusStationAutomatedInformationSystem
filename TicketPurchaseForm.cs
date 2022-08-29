using System.Globalization;
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
    public partial class TicketPurchaseForm : Form
    {
        public Profile Profile { get; }
        public RouteFormNew RouteForm { get; }
        private float rublesPerKilometer = 0f;
        private float tripPrice = 0f;
        private DateTime selectedDate = DateTime.Today;
        private bool isTicketAlreadyBought = false;

        System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
        System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");

        public TicketPurchaseForm(Profile profile, RouteFormNew routeForm)
        {
            Profile = profile;
            RouteForm = routeForm;
            float.TryParse(Utility.GetParameterValueByName("rublesPerKilometer"), style, culture, out rublesPerKilometer);
            InitializeComponent();
            CalculateTripPrice();
        }

        private void CalculateTripPrice()
        {
            tripPrice = RouteForm.SelectedRoute.TripDistance * rublesPerKilometer;
            ticketPriceLabel.Text = @$"{tripPrice.ToString()} Руб.";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            RouteForm.Show();
            this.Close();
        }

        private void buyTicketButton_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket(Profile.Id, RouteForm.SelectedRoute.Id, selectedDate, tripPrice);
            isTicketAlreadyBought = true;
            buyTicketButton.Enabled = false;
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day);
        }
    }
}
