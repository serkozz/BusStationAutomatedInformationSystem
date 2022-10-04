namespace BusStationAutomatedInformationSystem
{
    partial class AnalyticsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyticsPanel));
            this.cancelButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sqlTextBox = new System.Windows.Forms.TextBox();
            this.cacheSqlButton = new System.Windows.Forms.Button();
            this.openCachedSqlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(618, 618);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(173, 123);
            this.cancelButton.TabIndex = 26;
            this.cancelButton.Text = "\r\n\r\n\r\nНа главную";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.Location = new System.Drawing.Point(797, 618);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(173, 123);
            this.findButton.TabIndex = 28;
            this.findButton.Text = "\r\n\r\n\r\nПоиск";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(12, 180);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(958, 432);
            this.resultTextBox.TabIndex = 29;
            this.resultTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(44, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 34);
            this.label7.TabIndex = 32;
            this.label7.Text = "Запрос:";
            // 
            // sqlTextBox
            // 
            this.sqlTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sqlTextBox.Location = new System.Drawing.Point(178, 73);
            this.sqlTextBox.Name = "sqlTextBox";
            this.sqlTextBox.Size = new System.Drawing.Size(792, 40);
            this.sqlTextBox.TabIndex = 33;
            // 
            // cacheSqlButton
            // 
            this.cacheSqlButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cacheSqlButton.Image = ((System.Drawing.Image)(resources.GetObject("cacheSqlButton.Image")));
            this.cacheSqlButton.Location = new System.Drawing.Point(439, 618);
            this.cacheSqlButton.Name = "cacheSqlButton";
            this.cacheSqlButton.Size = new System.Drawing.Size(173, 123);
            this.cacheSqlButton.TabIndex = 34;
            this.cacheSqlButton.Text = "\r\n\r\n\r\nКэшировать";
            this.cacheSqlButton.UseVisualStyleBackColor = true;
            this.cacheSqlButton.Click += new System.EventHandler(this.cacheSqlButton_Click);
            // 
            // openCachedSqlButton
            // 
            this.openCachedSqlButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.openCachedSqlButton.Image = ((System.Drawing.Image)(resources.GetObject("openCachedSqlButton.Image")));
            this.openCachedSqlButton.Location = new System.Drawing.Point(260, 618);
            this.openCachedSqlButton.Name = "openCachedSqlButton";
            this.openCachedSqlButton.Size = new System.Drawing.Size(173, 123);
            this.openCachedSqlButton.TabIndex = 35;
            this.openCachedSqlButton.Text = "\r\n\r\n\r\nСписок";
            this.openCachedSqlButton.UseVisualStyleBackColor = true;
            this.openCachedSqlButton.Click += new System.EventHandler(this.openCachedSqlButton_Click);
            // 
            // AnalyticsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.openCachedSqlButton);
            this.Controls.Add(this.cacheSqlButton);
            this.Controls.Add(this.sqlTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "AnalyticsPanel";
            this.Text = "AnalyticsPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sqlTextBox;
        private System.Windows.Forms.Button cacheSqlButton;
        private System.Windows.Forms.Button openCachedSqlButton;
    }
}