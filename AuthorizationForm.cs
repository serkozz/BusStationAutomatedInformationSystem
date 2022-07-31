using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public partial class AuthorizationForm : Form
    {
        private const string _connectionString = "Host=localhost;Username=postgres;Password=password;Database=AIS";
        private NpgsqlConnection _connection;
        private NpgsqlCommand _cmd;
        private string _sql = string.Empty;

        public AuthorizationForm()
        {
            InitializeComponent();
            _connection = new NpgsqlConnection(_connectionString);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                //GET
                _connection.Open();
                _sql = @$"select (id,login,password) from users WHERE login = '{loginTextBox.Text}' AND password = '{Utility.GetSHA256(passwordTextBox.Text)}';";
                _cmd = new NpgsqlCommand(_sql, _connection);
                object userResult = _cmd.ExecuteScalar();
                object[] userArray = userResult as object[];
                _connection.Close();
                
                if (userResult != null)
                {
                    _connection.Open();
                    _sql = @$"select (id, user_id, passport_id, address_id, surname, name, midname, phone_number) from profile WHERE user_id = {(int)userArray[0]};";
                    _cmd = new NpgsqlCommand(_sql, _connection);
                    object profileResult = _cmd.ExecuteScalar();
                    object[] profileArray = profileResult as object[]; 
                    _connection.Close();

                    User user = new User((int)userArray[0], userArray[1].ToString(), userArray[2].ToString());
                    Profile profile = new Profile((int)profileArray[0], (int)profileArray[1], profileArray[2] as int?, profileArray[3] as int?,
                    profileArray[4] as string, profileArray[5] as string, profileArray[6] as string, profileArray[7] as long?);

                    new MainForm(user, profile).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!!!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так: " + ex.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                string existCheckSql = $@"SELECT EXISTS(SELECT * FROM users WHERE login = '{loginTextBox.Text}')";
                NpgsqlCommand isUserExistCommand = new NpgsqlCommand(existCheckSql, _connection);
                bool isUserAlreadyExist = (bool)isUserExistCommand.ExecuteScalar();

                if (!isUserAlreadyExist)
                {
                    //INSERT into users
                    _sql = @$"insert into users (login, password) values ('{loginTextBox.Text}', '{Utility.GetSHA256(passwordTextBox.Text)}') RETURNING (id,login,password);";
                    _cmd = new NpgsqlCommand(_sql, _connection);
                    object userResult = _cmd.ExecuteScalar();
                    object[] userArray = userResult as object[];

                    _sql = @$"insert into profile (user_id) values ({(int)userArray[0]}) RETURNING (id, user_id, passport_id, address_id, surname, name, midname, phone_number)";
                    _cmd = new NpgsqlCommand(_sql, _connection);
                    object profileResult = _cmd.ExecuteScalar();
                    object[] profileArray = profileResult as object[];
                    _connection.Close();

                    User user = new User((int)userArray[0], userArray[1].ToString(), userArray[2].ToString());
                    Profile profile = new Profile((int)profileArray[0], (int)profileArray[1], null, null, null, null, null, null);

                    new MainForm(user, profile).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь уже зарегистрирован!!!", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _connection.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так: " + ex.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
