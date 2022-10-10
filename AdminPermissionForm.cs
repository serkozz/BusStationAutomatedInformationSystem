using System;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
    public partial class AdminPermissionForm : Form
    {
        private MainForm MainForm { get; }
        public FormRequiringPassword FormRequringPassword { get; }
        public string AdminPassword { get; }

        public AdminPermissionForm(MainForm mainForm, FormRequiringPassword formRequiringPassword)
        {
            MainForm = mainForm;
            FormRequringPassword = formRequiringPassword;
            AdminPassword = Utility.GetParameterValueByName("adminPassword");
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == AdminPassword && FormRequringPassword == FormRequiringPassword.AdminPanel)
            {
                AdminPanel adminPanel = new AdminPanel(MainForm, MainForm.Profile);
                adminPanel.Location = MainForm.Location;
                adminPanel.Show();
                this.Close();
            }
            else if (passwordBox.Text == AdminPassword && FormRequringPassword == FormRequiringPassword.AnalyticsPanel)
            {
                AnalyticsPanel analyticsPanel = new AnalyticsPanel(MainForm);
                analyticsPanel.Location = MainForm.Location;
                analyticsPanel.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введен неверный пароль!", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            this.Close();
        }
    }

    public enum FormRequiringPassword
    {
        AdminPanel,
        AnalyticsPanel
    }
}
