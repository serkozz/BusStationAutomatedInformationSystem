namespace BusStationAutomatedInformationSystem
{
    partial class TripHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripHistoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.tripHistoryGrid = new System.Windows.Forms.DataGridView();
            this.displayPastTripsCheckBox = new System.Windows.Forms.CheckBox();
            this.sellTicketButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tripHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(554, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "История поездок";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(1190, 52);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(180, 120);
            this.backButton.TabIndex = 34;
            this.backButton.Text = "\r\n\r\n\r\nНазад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tripHistoryGrid
            // 
            this.tripHistoryGrid.AllowUserToDeleteRows = false;
            this.tripHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tripHistoryGrid.Location = new System.Drawing.Point(12, 178);
            this.tripHistoryGrid.Name = "tripHistoryGrid";
            this.tripHistoryGrid.ReadOnly = true;
            this.tripHistoryGrid.RowHeadersWidth = 51;
            this.tripHistoryGrid.RowTemplate.Height = 29;
            this.tripHistoryGrid.Size = new System.Drawing.Size(1358, 563);
            this.tripHistoryGrid.TabIndex = 37;
            this.tripHistoryGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tripHistoryGrid_CellClick);
            this.tripHistoryGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tripHistoryGrid_RowHeaderMouseClick);
            // 
            // displayPastTripsCheckBox
            // 
            this.displayPastTripsCheckBox.AutoSize = true;
            this.displayPastTripsCheckBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.displayPastTripsCheckBox.Location = new System.Drawing.Point(12, 122);
            this.displayPastTripsCheckBox.Name = "displayPastTripsCheckBox";
            this.displayPastTripsCheckBox.Size = new System.Drawing.Size(522, 31);
            this.displayPastTripsCheckBox.TabIndex = 38;
            this.displayPastTripsCheckBox.Text = "Отображать только завершенные поездки";
            this.displayPastTripsCheckBox.UseVisualStyleBackColor = true;
            this.displayPastTripsCheckBox.CheckedChanged += new System.EventHandler(this.displayPastTripsCheckBox_CheckedChanged);
            // 
            // sellTicketButton
            // 
            this.sellTicketButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sellTicketButton.Image = ((System.Drawing.Image)(resources.GetObject("sellTicketButton.Image")));
            this.sellTicketButton.Location = new System.Drawing.Point(1004, 52);
            this.sellTicketButton.Name = "sellTicketButton";
            this.sellTicketButton.Size = new System.Drawing.Size(180, 120);
            this.sellTicketButton.TabIndex = 39;
            this.sellTicketButton.Text = "\r\n\r\n\r\nСдать билет";
            this.sellTicketButton.UseVisualStyleBackColor = true;
            this.sellTicketButton.Click += new System.EventHandler(this.sellTicketButton_Click);
            // 
            // TripHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.sellTicketButton);
            this.Controls.Add(this.displayPastTripsCheckBox);
            this.Controls.Add(this.tripHistoryGrid);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Name = "TripHistoryForm";
            this.Text = "TripHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.tripHistoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridView tripHistoryGrid;
        private System.Windows.Forms.CheckBox displayPastTripsCheckBox;
        private System.Windows.Forms.Button sellTicketButton;
    }
}