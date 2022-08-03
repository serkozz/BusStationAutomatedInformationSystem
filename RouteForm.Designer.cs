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
            this.routeNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.departurePointCityTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.destinationPointCityTextBox = new System.Windows.Forms.TextBox();
            this.findRouteButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.destinationPointStreetTextBox = new System.Windows.Forms.TextBox();
            this.departurePointStreetTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            // routeNumberTextBox
            // 
            this.routeNumberTextBox.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.routeNumberTextBox.Location = new System.Drawing.Point(155, 110);
            this.routeNumberTextBox.Name = "routeNumberTextBox";
            this.routeNumberTextBox.Size = new System.Drawing.Size(139, 35);
            this.routeNumberTextBox.TabIndex = 2;
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
            // departurePointCityTextBox
            // 
            this.departurePointCityTextBox.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departurePointCityTextBox.Location = new System.Drawing.Point(300, 153);
            this.departurePointCityTextBox.Name = "departurePointCityTextBox";
            this.departurePointCityTextBox.Size = new System.Drawing.Size(238, 35);
            this.departurePointCityTextBox.TabIndex = 4;
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
            // destinationPointCityTextBox
            // 
            this.destinationPointCityTextBox.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.destinationPointCityTextBox.Location = new System.Drawing.Point(300, 194);
            this.destinationPointCityTextBox.Name = "destinationPointCityTextBox";
            this.destinationPointCityTextBox.Size = new System.Drawing.Size(238, 35);
            this.destinationPointCityTextBox.TabIndex = 6;
            // 
            // findRouteButton
            // 
            this.findRouteButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.findRouteButton.Image = ((System.Drawing.Image)(resources.GetObject("findRouteButton.Image")));
            this.findRouteButton.Location = new System.Drawing.Point(788, 135);
            this.findRouteButton.Name = "findRouteButton";
            this.findRouteButton.Size = new System.Drawing.Size(180, 120);
            this.findRouteButton.TabIndex = 8;
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
            // 
            // destinationPointStreetTextBox
            // 
            this.destinationPointStreetTextBox.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.destinationPointStreetTextBox.Location = new System.Drawing.Point(544, 194);
            this.destinationPointStreetTextBox.Name = "destinationPointStreetTextBox";
            this.destinationPointStreetTextBox.Size = new System.Drawing.Size(238, 35);
            this.destinationPointStreetTextBox.TabIndex = 11;
            // 
            // departurePointStreetTextBox
            // 
            this.departurePointStreetTextBox.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departurePointStreetTextBox.Location = new System.Drawing.Point(544, 153);
            this.departurePointStreetTextBox.Name = "departurePointStreetTextBox";
            this.departurePointStreetTextBox.Size = new System.Drawing.Size(238, 35);
            this.departurePointStreetTextBox.TabIndex = 10;
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
            // RouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.destinationPointStreetTextBox);
            this.Controls.Add(this.departurePointStreetTextBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.findRouteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.destinationPointCityTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.departurePointCityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.routeNumberTextBox);
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
        private System.Windows.Forms.TextBox routeNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox departurePointCityTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox destinationPointCityTextBox;
        private System.Windows.Forms.Button findRouteButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox destinationPointStreetTextBox;
        private System.Windows.Forms.TextBox departurePointStreetTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}