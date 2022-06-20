using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BusStationAutomatedInformationSystem
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            //AddAdminUser();
            LoadUsers(); // Метод десериализует класс пользователей.
        }

        /* Переменные, которые будут хранить на протяжение работы программы логин и пароль. */
        public string Login { get; private set; } = String.Empty;
        public string Password { get; private set; } = String.Empty;
        public Users Users { get; private set; } = new Users(); // Экземпляр класса пользователей.

/*        private void AddAdminUser()
        {
            Users.Logins.Add("admin");
            Users.Passwords.Add(SHA256Hash(SHA256Hash("password")));
        }*/
        private void LoadUsers()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\Repositories\\BusStationAutomatedInformationSystem\\Data\\Users.txt");
                string jsonString = sr.ReadToEnd();

                if (jsonString == String.Empty)
                {
                    sr.Close();
                    return;
                }
                Users = (Users)JsonConvert.DeserializeObject<Users>(jsonString);
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Вызвано исключение: " + ex.Message);
                return;
            }
        }

        private void LoginUser()
        {
            bool isFinded = false;

            for (int i = 0; i < Users.Logins.Count; i++) // Ищем пользователя и проверяем правильность пароля.
            {
                string shaPassword = SHA256Hash(SHA256Hash(passwordTextBox.Text)); 

                if (Users.Logins[i] == loginTextBox.Text && Users.Passwords[i] == shaPassword)
                {
                    Login = Users.Logins[i];
                    Password = Users.Passwords[i];

                    MessageBox.Show("Вы вошли в систему!");
                    //this.Close();
                    isFinded = true;
                    break;
                }
                else if (Users.Logins[i] == loginTextBox.Text && shaPassword != Users.Passwords[i])
                {
                    Login = Users.Logins[i];
                    MessageBox.Show("Неверный пароль!");
                    isFinded = true;
                    break;
                }
            }
            if (!isFinded) { MessageBox.Show("Пользователь " + loginTextBox.Text + " не найден!"); }
        }

        private void RegisterUser() // Регистрируем нового пользователя.
        {
            if (loginTextBox.Text == "" || passwordTextBox.Text == "") { MessageBox.Show("Не введен логин или пароль!"); return; }

            int loginsCount = Users.Logins.Count();
            bool isRegistered = false;

            for (int i = 0; i < loginsCount; i++)
            {
                if (!IsUserAlreadyExists(loginsCount))
                {
                    string shaPassword = SHA256Hash(SHA256Hash(passwordTextBox.Text));

                    Users.Logins.Add(loginTextBox.Text);
                    Users.Passwords.Add(shaPassword);

                    StreamReader sr = new StreamReader("C:\\Repositories\\BusStationAutomatedInformationSystem\\Data\\Users.txt");
                    string resultString = JsonConvert.SerializeObject(Users);
                    sr.Close();

                    StreamWriter sw = new StreamWriter("C:\\Repositories\\BusStationAutomatedInformationSystem\\Data\\Users.txt");
                    sw.Write(resultString);
                    sw.Close();

                    Login = loginTextBox.Text;
                    MessageBox.Show("Успешная регистрация!");
                    isRegistered = true;
                }
            }
            if(!isRegistered) { MessageBox.Show("Пользователь с таким логином уже существует"); }
        }

        public static String SHA256Hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        private bool IsUserAlreadyExists(int loginsCount)
        {
            for (int i = 0; i < loginsCount; i++) // Ищем пользователя и проверяем правильность пароля.
            {
                if (Users.Logins[i] == loginTextBox.Text)
                    return true;
            }
            return false;
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Login == "" | Password == "") { Application.Exit(); }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginUser();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }
    }
}
