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
    public partial class TripHistoryForm : Form
    {
        public Profile Profile { get; set; }
        public ProfileForm ProfileForm { get; set; }

        public TripHistoryForm(Profile profile, ProfileForm profileForm)
        {
            Profile = profile;
            ProfileForm = profileForm;

            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ProfileForm.Show();
        }
    }
}
