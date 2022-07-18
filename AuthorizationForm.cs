using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
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
                _connection.Open();
                _sql = @"select * from user_login (:_login, :_password)";
                _cmd = new NpgsqlCommand(_sql, _connection);

                _cmd.Parameters.AddWithValue("_login", loginTextBox.Text);
                _cmd.Parameters.AddWithValue("_password", Utility.GetSHA256(passwordTextBox.Text));

                int result = (int)_cmd.ExecuteScalar();

                _connection.Close();

                if (result == 1)
                {
                    new MainForm(new User(loginTextBox.Text, passwordTextBox.Text)).Show();
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
                    _sql = @$"insert into users (login, password) values ('{loginTextBox.Text}', '{Utility.GetSHA256(passwordTextBox.Text)}');";
                    _cmd = new NpgsqlCommand(_sql, _connection);
                    _cmd.ExecuteScalar();
                    _connection.Close();
                    new MainForm(new User(loginTextBox.Text, passwordTextBox.Text)).Show();
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
    }
}
