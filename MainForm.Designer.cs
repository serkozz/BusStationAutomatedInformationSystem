namespace BusStationAutomatedInformationSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.profileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.routeButton = new System.Windows.Forms.Button();
            this.adminPanelButton = new System.Windows.Forms.Button();
            this.analyticsPanelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // profileButton
            // 
            this.profileButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.profileButton.Image = ((System.Drawing.Image)(resources.GetObject("profileButton.Image")));
            this.profileButton.Location = new System.Drawing.Point(12, 133);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(465, 275);
            this.profileButton.TabIndex = 0;
            this.profileButton.Text = "\r\n\r\n\r\n\r\n\r\nПрофиль";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(350, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "АИС \"Автовокзал\"";
            // 
            // routeButton
            // 
            this.routeButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.routeButton.Image = ((System.Drawing.Image)(resources.GetObject("routeButton.Image")));
            this.routeButton.Location = new System.Drawing.Point(12, 414);
            this.routeButton.Name = "routeButton";
            this.routeButton.Size = new System.Drawing.Size(465, 327);
            this.routeButton.TabIndex = 10;
            this.routeButton.Text = "\r\n\r\n\r\n\r\n\r\nМаршруты";
            this.routeButton.UseVisualStyleBackColor = true;
            this.routeButton.Click += new System.EventHandler(this.routeButton_Click);
            // 
            // adminPanelButton
            // 
            this.adminPanelButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.adminPanelButton.Image = ((System.Drawing.Image)(resources.GetObject("adminPanelButton.Image")));
            this.adminPanelButton.Location = new System.Drawing.Point(506, 133);
            this.adminPanelButton.Name = "adminPanelButton";
            this.adminPanelButton.Size = new System.Drawing.Size(465, 275);
            this.adminPanelButton.TabIndex = 12;
            this.adminPanelButton.Text = "\r\n\r\n\r\n\r\n\r\nАдминистрирование";
            this.adminPanelButton.UseVisualStyleBackColor = true;
            this.adminPanelButton.Click += new System.EventHandler(this.adminPanelButton_Click);
            // 
            // analyticsPanelButton
            // 
            this.analyticsPanelButton.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.analyticsPanelButton.Image = ((System.Drawing.Image)(resources.GetObject("analyticsPanelButton.Image")));
            this.analyticsPanelButton.Location = new System.Drawing.Point(506, 414);
            this.analyticsPanelButton.Name = "analyticsPanelButton";
            this.analyticsPanelButton.Size = new System.Drawing.Size(465, 327);
            this.analyticsPanelButton.TabIndex = 13;
            this.analyticsPanelButton.Text = "\r\n\r\n\r\n\r\n\r\nАналитика";
            this.analyticsPanelButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.analyticsPanelButton);
            this.Controls.Add(this.adminPanelButton);
            this.Controls.Add(this.routeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.profileButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "BusStationAutomatedInformationSystem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button routeButton;
        private System.Windows.Forms.Button adminPanelButton;
        private System.Windows.Forms.Button analyticsPanelButton;
    }
}

