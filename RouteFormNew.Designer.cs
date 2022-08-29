namespace BusStationAutomatedInformationSystem
{
    partial class RouteFormNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteFormNew));
            this.label5 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.findRouteButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.routeGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.routeNumberTextBox = new System.Windows.Forms.TextBox();
            this.departurePointTextBox = new System.Windows.Forms.TextBox();
            this.destinationPointTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.buyTicketButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(512, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 36);
            this.label5.TabIndex = 26;
            this.label5.Text = "Адрес";
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.Location = new System.Drawing.Point(990, 136);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(180, 120);
            this.resetButton.TabIndex = 24;
            this.resetButton.Text = "\r\n\r\n\r\nСброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // findRouteButton
            // 
            this.findRouteButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.findRouteButton.Image = ((System.Drawing.Image)(resources.GetObject("findRouteButton.Image")));
            this.findRouteButton.Location = new System.Drawing.Point(990, 10);
            this.findRouteButton.Name = "findRouteButton";
            this.findRouteButton.Size = new System.Drawing.Size(180, 120);
            this.findRouteButton.TabIndex = 25;
            this.findRouteButton.Text = "\r\n\r\n\r\nПоиск";
            this.findRouteButton.UseVisualStyleBackColor = true;
            this.findRouteButton.Click += new System.EventHandler(this.findRouteButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 36);
            this.label4.TabIndex = 23;
            this.label4.Text = "Точка прибытия: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 36);
            this.label3.TabIndex = 22;
            this.label3.Text = "Точка отправки: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 36);
            this.label2.TabIndex = 21;
            this.label2.Text = "Номер: ";
            // 
            // routeGrid
            // 
            this.routeGrid.AllowUserToAddRows = false;
            this.routeGrid.AllowUserToDeleteRows = false;
            this.routeGrid.AllowUserToOrderColumns = true;
            this.routeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeGrid.Location = new System.Drawing.Point(12, 262);
            this.routeGrid.Name = "routeGrid";
            this.routeGrid.ReadOnly = true;
            this.routeGrid.RowHeadersWidth = 51;
            this.routeGrid.RowTemplate.Height = 29;
            this.routeGrid.Size = new System.Drawing.Size(1158, 480);
            this.routeGrid.TabIndex = 20;
            this.routeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.routeGrid_CellClick);
            this.routeGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.routeGrid_RowHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(474, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 36);
            this.label1.TabIndex = 19;
            this.label1.Text = "Маршруты";
            // 
            // routeNumberTextBox
            // 
            this.routeNumberTextBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.routeNumberTextBox.Location = new System.Drawing.Point(143, 110);
            this.routeNumberTextBox.Name = "routeNumberTextBox";
            this.routeNumberTextBox.Size = new System.Drawing.Size(265, 34);
            this.routeNumberTextBox.TabIndex = 28;
            // 
            // departurePointTextBox
            // 
            this.departurePointTextBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departurePointTextBox.Location = new System.Drawing.Point(300, 150);
            this.departurePointTextBox.Name = "departurePointTextBox";
            this.departurePointTextBox.Size = new System.Drawing.Size(482, 34);
            this.departurePointTextBox.TabIndex = 29;
            // 
            // destinationPointTextBox
            // 
            this.destinationPointTextBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.destinationPointTextBox.Location = new System.Drawing.Point(300, 193);
            this.destinationPointTextBox.Name = "destinationPointTextBox";
            this.destinationPointTextBox.Size = new System.Drawing.Size(482, 34);
            this.destinationPointTextBox.TabIndex = 30;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(804, 10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(180, 120);
            this.backButton.TabIndex = 31;
            this.backButton.Text = "\r\n\r\n\r\nНа главную";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // buyTicketButton
            // 
            this.buyTicketButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buyTicketButton.Image = ((System.Drawing.Image)(resources.GetObject("buyTicketButton.Image")));
            this.buyTicketButton.Location = new System.Drawing.Point(804, 136);
            this.buyTicketButton.Name = "buyTicketButton";
            this.buyTicketButton.Size = new System.Drawing.Size(180, 120);
            this.buyTicketButton.TabIndex = 32;
            this.buyTicketButton.Text = "\r\n\r\n\r\nКупить";
            this.buyTicketButton.UseVisualStyleBackColor = true;
            this.buyTicketButton.Click += new System.EventHandler(this.buyTicketButton_Click);
            // 
            // RouteFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.buyTicketButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.destinationPointTextBox);
            this.Controls.Add(this.departurePointTextBox);
            this.Controls.Add(this.routeNumberTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.findRouteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.routeGrid);
            this.Controls.Add(this.label1);
            this.Name = "RouteFormNew";
            this.Text = "RouteFormNew";
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button findRouteButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox routeNumberTextBox;
        private System.Windows.Forms.TextBox departurePointTextBox;
        private System.Windows.Forms.TextBox destinationPointTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button buyTicketButton;
        public System.Windows.Forms.DataGridView routeGrid;
    }
}