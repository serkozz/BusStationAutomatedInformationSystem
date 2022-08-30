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
            this.pastTripsRadioButton = new System.Windows.Forms.RadioButton();
            this.futureTripsRadioButton = new System.Windows.Forms.RadioButton();
            this.tripHistoryGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tripHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(346, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "История поездок";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(790, 52);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(180, 120);
            this.backButton.TabIndex = 34;
            this.backButton.Text = "\r\n\r\n\r\nНазад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // pastTripsRadioButton
            // 
            this.pastTripsRadioButton.AutoSize = true;
            this.pastTripsRadioButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pastTripsRadioButton.Location = new System.Drawing.Point(12, 140);
            this.pastTripsRadioButton.Name = "pastTripsRadioButton";
            this.pastTripsRadioButton.Size = new System.Drawing.Size(272, 31);
            this.pastTripsRadioButton.TabIndex = 35;
            this.pastTripsRadioButton.TabStop = true;
            this.pastTripsRadioButton.Text = "Прошедшие поездки";
            this.pastTripsRadioButton.UseVisualStyleBackColor = true;
            this.pastTripsRadioButton.Click += new System.EventHandler(this.pastTripsRadioButton_Click);
            // 
            // futureTripsRadioButton
            // 
            this.futureTripsRadioButton.AutoSize = true;
            this.futureTripsRadioButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.futureTripsRadioButton.Location = new System.Drawing.Point(482, 140);
            this.futureTripsRadioButton.Name = "futureTripsRadioButton";
            this.futureTripsRadioButton.Size = new System.Drawing.Size(289, 31);
            this.futureTripsRadioButton.TabIndex = 36;
            this.futureTripsRadioButton.TabStop = true;
            this.futureTripsRadioButton.Text = "Предстоящие поездки";
            this.futureTripsRadioButton.UseVisualStyleBackColor = true;
            this.futureTripsRadioButton.Click += new System.EventHandler(this.futureTripsRadioButton_Click);
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
            this.tripHistoryGrid.Size = new System.Drawing.Size(958, 563);
            this.tripHistoryGrid.TabIndex = 37;
            // 
            // TripHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.tripHistoryGrid);
            this.Controls.Add(this.futureTripsRadioButton);
            this.Controls.Add(this.pastTripsRadioButton);
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
        private System.Windows.Forms.RadioButton pastTripsRadioButton;
        private System.Windows.Forms.RadioButton futureTripsRadioButton;
        private System.Windows.Forms.DataGridView tripHistoryGrid;
    }
}