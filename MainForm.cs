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
            RouteForm routeForm = new RouteForm(this, this.Profile);
        }
    }
}
