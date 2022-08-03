using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.midnameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.passportSeriesTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.passportNumberTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.addressStreetTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.addressCityTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.addressHouseTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.routesHistoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(350, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваш профиль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(163, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия:";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.surnameTextBox.Location = new System.Drawing.Point(328, 156);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(416, 40);
            this.surnameTextBox.TabIndex = 2;
            this.surnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyTextHandler);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameTextBox.Location = new System.Drawing.Point(328, 202);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(416, 40);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyTextHandler);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(237, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 34);
            this.label3.TabIndex = 3;
            this.label3.Text = "Имя:";
            // 
            // midnameTextBox
            // 
            this.midnameTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.midnameTextBox.Location = new System.Drawing.Point(328, 248);
            this.midnameTextBox.Name = "midnameTextBox";
            this.midnameTextBox.Size = new System.Drawing.Size(416, 40);
            this.midnameTextBox.TabIndex = 6;
            this.midnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyTextHandler);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(162, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "Отчество:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(750, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 34);
            this.label5.TabIndex = 7;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(750, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 34);
            this.label6.TabIndex = 8;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(112, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 34);
            this.label7.TabIndex = 9;
            this.label7.Text = "Паспорт:";
            // 
            // passportSeriesTextBox
            // 
            this.passportSeriesTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passportSeriesTextBox.Location = new System.Drawing.Point(350, 326);
            this.passportSeriesTextBox.MaxLength = 4;
            this.passportSeriesTextBox.Name = "passportSeriesTextBox";
            this.passportSeriesTextBox.Size = new System.Drawing.Size(149, 40);
            this.passportSeriesTextBox.TabIndex = 10;
            this.passportSeriesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyNumbersHandler);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(264, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 24);
            this.label8.TabIndex = 11;
            this.label8.Text = "Серия:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(505, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 24);
            this.label9.TabIndex = 13;
            this.label9.Text = "Номер:";
            // 
            // passportNumberTextBox
            // 
            this.passportNumberTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passportNumberTextBox.Location = new System.Drawing.Point(595, 326);
            this.passportNumberTextBox.MaxLength = 6;
            this.passportNumberTextBox.Name = "passportNumberTextBox";
            this.passportNumberTextBox.Size = new System.Drawing.Size(149, 40);
            this.passportNumberTextBox.TabIndex = 12;
            this.passportNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyNumbersHandler);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(508, 409);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 24);
            this.label10.TabIndex = 18;
            this.label10.Text = "Улица:";
            // 
            // addressStreetTextBox
            // 
            this.addressStreetTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addressStreetTextBox.Location = new System.Drawing.Point(595, 393);
            this.addressStreetTextBox.Name = "addressStreetTextBox";
            this.addressStreetTextBox.Size = new System.Drawing.Size(149, 40);
            this.addressStreetTextBox.TabIndex = 17;
            this.addressStreetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyTextHandler);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(266, 409);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 24);
            this.label11.TabIndex = 16;
            this.label11.Text = "Город:";
            // 
            // addressCityTextBox
            // 
            this.addressCityTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addressCityTextBox.Location = new System.Drawing.Point(350, 393);
            this.addressCityTextBox.Name = "addressCityTextBox";
            this.addressCityTextBox.Size = new System.Drawing.Size(149, 40);
            this.addressCityTextBox.TabIndex = 15;
            this.addressCityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyTextHandler);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(146, 399);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 34);
            this.label12.TabIndex = 14;
            this.label12.Text = "Адрес:";
            // 
            // addressHouseTextBox
            // 
            this.addressHouseTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addressHouseTextBox.Location = new System.Drawing.Point(595, 461);
            this.addressHouseTextBox.MaxLength = 5;
            this.addressHouseTextBox.Name = "addressHouseTextBox";
            this.addressHouseTextBox.Size = new System.Drawing.Size(149, 40);
            this.addressHouseTextBox.TabIndex = 19;
            this.addressHouseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyNumbersHandler);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(530, 477);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 24);
            this.label13.TabIndex = 20;
            this.label13.Text = "Дом:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(146, 551);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(271, 34);
            this.label14.TabIndex = 21;
            this.label14.Text = "Номер телефона:";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.phoneNumberTextBox.Location = new System.Drawing.Point(423, 548);
            this.phoneNumberTextBox.MaxLength = 11;
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(321, 40);
            this.phoneNumberTextBox.TabIndex = 22;
            this.phoneNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWithOnlyNumbersHandler);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(571, 618);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(173, 123);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "\r\n\r\n\r\nСохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(392, 618);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(173, 123);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "\r\n\r\n\r\nНа главную";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(750, 554);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 34);
            this.label15.TabIndex = 25;
            this.label15.Text = "*";
            // 
            // routesHistoryButton
            // 
            this.routesHistoryButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.routesHistoryButton.Image = ((System.Drawing.Image)(resources.GetObject("routesHistoryButton.Image")));
            this.routesHistoryButton.Location = new System.Drawing.Point(112, 618);
            this.routesHistoryButton.Name = "routesHistoryButton";
            this.routesHistoryButton.Size = new System.Drawing.Size(173, 123);
            this.routesHistoryButton.TabIndex = 23;
            this.routesHistoryButton.Text = "\r\n\r\n\r\nИстория";
            this.routesHistoryButton.UseVisualStyleBackColor = true;
            // 
            // ProfileForm
            // 
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.routesHistoryButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.addressHouseTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.addressStreetTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.addressCityTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.passportNumberTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.passportSeriesTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.midnameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private TextBox surnameTextBox;
        private TextBox nameTextBox;
        private Label label3;
        private TextBox midnameTextBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox passportSeriesTextBox;
        private Label label8;
        private Label label9;
        private TextBox passportNumberTextBox;
        private Label label10;
        private TextBox addressStreetTextBox;
        private Label label11;
        private TextBox addressCityTextBox;
        private Label label12;
        private TextBox addressHouseTextBox;
        private Label label13;
        private Label label14;
        private TextBox phoneNumberTextBox;
        private Button saveButton;
        private Button cancelButton;
        private Label label15;
        private Button routesHistoryButton;
    }
}