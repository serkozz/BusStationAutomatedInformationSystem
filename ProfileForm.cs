using System;
using System.Windows.Forms;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class ProfileForm : Form
    {
        private NpgsqlConnection _connection;
        private MainForm mainForm;
        public Profile Profile { get; private set; }
        public Address Address { get; private set; }
        public Passport Passport { get; private set; }
        public ProfileForm(MainForm form, Profile profile)
        {
            _connection = new NpgsqlConnection(Constants._connectionString);
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
            passportSeriesTextBox.Text = Passport.Series.ToString();
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
                int? passportId = null;

                if (passportSeriesTextBox.Text != string.Empty && passportSeriesTextBox.Text.Length == 4 && passportNumberTextBox.Text != string.Empty && passportNumberTextBox.Text.Length == 6)
                {
                    Passport = new Passport(Int32.Parse(passportSeriesTextBox.Text), Int32.Parse(passportNumberTextBox.Text));
                    passportId = Passport.DropToDB();
                }

                int? addressId = null;

                if (addressCityTextBox.Text != string.Empty && addressStreetTextBox.Text != string.Empty && addressHouseTextBox.Text != string.Empty)
                {
                    Address = new Address(this.addressCityTextBox.Text, this.addressStreetTextBox.Text, Convert.ToInt32(this.addressHouseTextBox.Text));
                    addressId = Address.DropToDB();
                }
                if (addressId == null || passportId == null)
                    MessageBox.Show(@$"Данные о паспорте или об адресе не были обновлены, так как указан неверный формат данных!!! addressId = {addressId}, passportId = {passportId}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            else if (passportSeriesTextBox.Text.Length == 4)
                e.Handled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Location = this.Location;
            mainForm.UpdateProfileData(Profile);
            mainForm.Show();
            this.Close();
        }

        private void routesHistoryButton_Click(object sender, EventArgs e)
        {
            TripHistoryForm tripHistoryForm = new TripHistoryForm(Profile, this);
            tripHistoryForm.Location = this.Location;
            tripHistoryForm.Show();
            this.Hide();
        }
    }
}
