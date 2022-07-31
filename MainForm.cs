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
        private Profile _profile;
        public MainForm(User user, Profile profile)
        {
            _user = user;
            _profile = profile;
            InitializeComponent();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(this, _profile);
            profileForm.Location = this.Location;
            profileForm.Show();
            this.Hide();
        }

        private void adminPanelButton_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(this);
            adminPanel.Location = this.Location;
            adminPanel.Show();
            this.Hide();
        }

        public void UpdateProfileData(Profile profile)
        {
            _profile = profile;
        }
    }
}
