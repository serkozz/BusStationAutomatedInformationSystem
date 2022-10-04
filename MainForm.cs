using System;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
	public partial class MainForm : Form
	{
		private User _user;
		public Profile Profile { get; private set; }
		public MainForm(User user, Profile profile)
		{
			_user = user;
			Profile = profile;
			InitializeComponent();
		}

		private void profileButton_Click(object sender, EventArgs e)
		{
			ProfileForm profileForm = new ProfileForm(this, Profile);
			profileForm.Location = this.Location;
			profileForm.Show();
			this.Hide();
		}

		private void adminPanelButton_Click(object sender, EventArgs e)
		{
			AdminPermissionForm adminPermissionForm = new AdminPermissionForm(this);
			adminPermissionForm.Location = this.Location;
			adminPermissionForm.Show();
			this.Hide();
		}
		public void UpdateProfileData(Profile profile)
		{
			Profile = profile;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void routeButton_Click(object sender, EventArgs e)
		{
			RouteFormNew routeFormNew = new RouteFormNew(this, this.Profile);
			routeFormNew.Location = this.Location;
			routeFormNew.Show();
			this.Hide();
		}

		private void analyticsPanelButton_Click(object sender, EventArgs e)
		{
			AnalyticsPanel analyticsPanel = new AnalyticsPanel(this);
			analyticsPanel.Location = this.Location;
			analyticsPanel.Show();
			this.Hide();
		}
	}
}
