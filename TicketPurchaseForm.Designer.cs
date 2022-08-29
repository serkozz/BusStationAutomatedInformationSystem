namespace BusStationAutomatedInformationSystem
{
    partial class TicketPurchaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketPurchaseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.buyTicketButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.ticketPriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(275, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Купить билет";
            // 
            // buyTicketButton
            // 
            this.buyTicketButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buyTicketButton.Image = ((System.Drawing.Image)(resources.GetObject("buyTicketButton.Image")));
            this.buyTicketButton.Location = new System.Drawing.Point(590, 421);
            this.buyTicketButton.Name = "buyTicketButton";
            this.buyTicketButton.Size = new System.Drawing.Size(180, 120);
            this.buyTicketButton.TabIndex = 34;
            this.buyTicketButton.Text = "\r\n\r\n\r\nКупить";
            this.buyTicketButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(12, 421);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(180, 120);
            this.backButton.TabIndex = 33;
            this.backButton.Text = "\r\n\r\n\r\nНазад";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 36);
            this.label2.TabIndex = 35;
            this.label2.Text = "Дата поездки: ";
            // 
            // Calendar
            // 
            this.Calendar.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.Calendar.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Calendar.Location = new System.Drawing.Point(309, 109);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(25, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 36);
            this.label3.TabIndex = 38;
            this.label3.Text = "Стоимость поездки: ";
            // 
            // ticketPriceLabel
            // 
            this.ticketPriceLabel.AutoSize = true;
            this.ticketPriceLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ticketPriceLabel.Location = new System.Drawing.Point(368, 342);
            this.ticketPriceLabel.Name = "ticketPriceLabel";
            this.ticketPriceLabel.Size = new System.Drawing.Size(108, 36);
            this.ticketPriceLabel.TabIndex = 39;
            this.ticketPriceLabel.Text = "0 Руб.";
            // 
            // TicketPurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.ticketPriceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buyTicketButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Name = "TicketPurchaseForm";
            this.Text = "TicketPurchaseForm";
            this.Load += new System.EventHandler(this.TicketPurchaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buyTicketButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ticketPriceLabel;
    }
}