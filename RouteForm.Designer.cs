namespace BusStationAutomatedInformationSystem
{
    partial class RouteForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteForm));
            this.label1 = new System.Windows.Forms.Label();
            this.routeGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.findRouteButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.departurePointCityComboBox = new System.Windows.Forms.ComboBox();
            this.destinatrionPointCityComboBox = new System.Windows.Forms.ComboBox();
            this.destinatrionPointStreetComboBox = new System.Windows.Forms.ComboBox();
            this.departurePointStreetComboBox = new System.Windows.Forms.ComboBox();
            this.routeNumberComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(402, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Маршруты";
            // 
            // routeGrid
            // 
            this.routeGrid.AllowUserToAddRows = false;
            this.routeGrid.AllowUserToDeleteRows = false;
            this.routeGrid.AllowUserToOrderColumns = true;
            this.routeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeGrid.Location = new System.Drawing.Point(12, 261);
            this.routeGrid.Name = "routeGrid";
            this.routeGrid.ReadOnly = true;
            this.routeGrid.RowHeadersWidth = 51;
            this.routeGrid.RowTemplate.Height = 29;
            this.routeGrid.Size = new System.Drawing.Size(958, 480);
            this.routeGrid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Точка отправки: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "Точка прибытия: ";
            // 
            // findRouteButton
            // 
            this.findRouteButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.findRouteButton.Image = ((System.Drawing.Image)(resources.GetObject("findRouteButton.Image")));
            this.findRouteButton.Location = new System.Drawing.Point(788, 135);
            this.findRouteButton.Name = "findRouteButton";
            this.findRouteButton.Size = new System.Drawing.Size(180, 120);
            this.findRouteButton.TabIndex = 10;
            this.findRouteButton.Text = "\r\n\r\n\r\nПоиск";
            this.findRouteButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(788, 9);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(180, 120);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "\r\n\r\n\r\nНа главную";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(366, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 36);
            this.label5.TabIndex = 12;
            this.label5.Text = "Город";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(606, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 36);
            this.label6.TabIndex = 13;
            this.label6.Text = "Улица";
            // 
            // departurePointCityComboBox
            // 
            this.departurePointCityComboBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departurePointCityComboBox.FormattingEnabled = true;
            this.departurePointCityComboBox.Location = new System.Drawing.Point(300, 152);
            this.departurePointCityComboBox.Name = "departurePointCityComboBox";
            this.departurePointCityComboBox.Size = new System.Drawing.Size(238, 35);
            this.departurePointCityComboBox.TabIndex = 15;
            // 
            // destinatrionPointCityComboBox
            // 
            this.destinatrionPointCityComboBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.destinatrionPointCityComboBox.FormattingEnabled = true;
            this.destinatrionPointCityComboBox.Location = new System.Drawing.Point(300, 193);
            this.destinatrionPointCityComboBox.Name = "destinatrionPointCityComboBox";
            this.destinatrionPointCityComboBox.Size = new System.Drawing.Size(238, 35);
            this.destinatrionPointCityComboBox.TabIndex = 16;
            // 
            // destinatrionPointStreetComboBox
            // 
            this.destinatrionPointStreetComboBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.destinatrionPointStreetComboBox.FormattingEnabled = true;
            this.destinatrionPointStreetComboBox.Location = new System.Drawing.Point(544, 193);
            this.destinatrionPointStreetComboBox.Name = "destinatrionPointStreetComboBox";
            this.destinatrionPointStreetComboBox.Size = new System.Drawing.Size(238, 35);
            this.destinatrionPointStreetComboBox.TabIndex = 18;
            // 
            // departurePointStreetComboBox
            // 
            this.departurePointStreetComboBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departurePointStreetComboBox.FormattingEnabled = true;
            this.departurePointStreetComboBox.Location = new System.Drawing.Point(544, 152);
            this.departurePointStreetComboBox.Name = "departurePointStreetComboBox";
            this.departurePointStreetComboBox.Size = new System.Drawing.Size(238, 35);
            this.departurePointStreetComboBox.TabIndex = 17;
            // 
            // routeNumberComboBox
            // 
            this.routeNumberComboBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.routeNumberComboBox.FormattingEnabled = true;
            this.routeNumberComboBox.Location = new System.Drawing.Point(138, 109);
            this.routeNumberComboBox.Name = "routeNumberComboBox";
            this.routeNumberComboBox.Size = new System.Drawing.Size(156, 35);
            this.routeNumberComboBox.TabIndex = 14;
            // 
            // RouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.routeNumberComboBox);
            this.Controls.Add(this.destinatrionPointStreetComboBox);
            this.Controls.Add(this.departurePointStreetComboBox);
            this.Controls.Add(this.destinatrionPointCityComboBox);
            this.Controls.Add(this.departurePointCityComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.findRouteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.routeGrid);
            this.Controls.Add(this.label1);
            this.Name = "RouteForm";
            this.Text = "RouteForm";
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView routeGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button findRouteButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox departurePointCityComboBox;
        private System.Windows.Forms.ComboBox destinatrionPointCityComboBox;
        private System.Windows.Forms.ComboBox destinatrionPointStreetComboBox;
        private System.Windows.Forms.ComboBox departurePointStreetComboBox;
        private System.Windows.Forms.ComboBox routeNumberComboBox;
    }
}