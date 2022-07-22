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
            new ProfileForm(_profile).Show();
            this.Hide();
        }
    }
}
