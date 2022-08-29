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
    public partial class AdminPermissionForm : Form
    {
        private MainForm mainForm;
        private string adminPassword; 
        public AdminPermissionForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            adminPassword = Utility.GetParameterValueByName("adminPassword");
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == adminPassword)
            {
                AdminPanel adminPanel = new AdminPanel(mainForm, mainForm.Profile);
                adminPanel.Location = mainForm.Location;
                adminPanel.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введен неверный пароль!", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}
