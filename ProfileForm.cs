using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class ProfileForm : Form
    {
        private const string _connectionString = "Host=localhost;Username=postgres;Password=password;Database=AIS";

        private NpgsqlConnection _connection;
        private MainForm mainForm;
        public Profile Profile { get; private set; }
        public Address Address { get; private set; }
        public Passport Passport { get; private set; }
        public ProfileForm(MainForm form, Profile profile)
        {
            _connection = new NpgsqlConnection(_connectionString);
            mainForm = form;
            Profile = profile;
            Passport = Passport.GetPassportById(Profile.PassportId);
            Address = Address.GetAddressById(profile.AddressId);
            InitializeComponent();
            OnFormLoad();
        }

        private void OnFormLoad()
        {
            nameTextBox.Text = Profile.Name;
            surnameTextBox.Text = Profile.Surname;
            midnameTextBox.Text = Profile.Midname;
            pasportSeriesTextBox.Text = Passport.Series.ToString();
            passportNumberTextBox.Text = Passport.Number.ToString();
            addressCityTextBox.Text = Address.City;
            addressStreetTextBox.Text = Address.Street;
            addressHouseTextBox.Text = Address.House.ToString();
            phoneNumberTextBox.Text = Profile.PhoneNumber.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Passport = new Passport(Int32.Parse(pasportSeriesTextBox.Text), Int32.Parse(passportNumberTextBox.Text));
                int passportId = Passport.DropToDB();
                Address = new Address(this.addressCityTextBox.Text, this.addressStreetTextBox.Text, Convert.ToInt32(this.addressHouseTextBox.Text));
                int addressId = Address.DropToDB();
                Profile = new Profile(Profile.Id, Profile.UserId, passportId, addressId, surnameTextBox.Text, nameTextBox.Text, midnameTextBox.Text, Int64.Parse(phoneNumberTextBox.Text));
                Profile.DropToDB();
                MessageBox.Show("Данные профиля успешно обновлены!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Данные профиля не были обновлены!!!" + ex.Message, "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxWithOnlyTextHandler(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void TextBoxWithOnlyNumbersHandler(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else if (pasportSeriesTextBox.Text.Length == 4)
                e.Handled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Location = this.Location;
            mainForm.Show();
            this.Close();
        }
    }
}
