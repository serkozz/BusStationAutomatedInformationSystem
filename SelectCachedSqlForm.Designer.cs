namespace BusStationAutomatedInformationSystem
{
    partial class SelectCachedSqlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCachedSqlForm));
            this.findButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.sqlKeySentenceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlComboBox = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.Location = new System.Drawing.Point(436, 315);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(173, 123);
            this.findButton.TabIndex = 30;
            this.findButton.Text = "\r\n\r\n\r\nПоиск";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(257, 315);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(173, 123);
            this.backButton.TabIndex = 29;
            this.backButton.Text = "\r\n\r\n\r\nНазад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // sqlKeySentenceTextBox
            // 
            this.sqlKeySentenceTextBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sqlKeySentenceTextBox.Location = new System.Drawing.Point(246, 64);
            this.sqlKeySentenceTextBox.Name = "sqlKeySentenceTextBox";
            this.sqlKeySentenceTextBox.Size = new System.Drawing.Size(542, 34);
            this.sqlKeySentenceTextBox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 36);
            this.label2.TabIndex = 31;
            this.label2.Text = "Имя запроса: ";
            // 
            // sqlComboBox
            // 
            this.sqlComboBox.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sqlComboBox.FormattingEnabled = true;
            this.sqlComboBox.Location = new System.Drawing.Point(7, 203);
            this.sqlComboBox.Name = "sqlComboBox";
            this.sqlComboBox.Size = new System.Drawing.Size(781, 35);
            this.sqlComboBox.TabIndex = 33;
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.Location = new System.Drawing.Point(615, 315);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(173, 123);
            this.selectButton.TabIndex = 34;
            this.selectButton.Text = "\r\n\r\n\r\nВыбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(246, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 36);
            this.label1.TabIndex = 35;
            this.label1.Text = "Коллекция запросов: ";
            // 
            // SelectCachedSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.sqlComboBox);
            this.Controls.Add(this.sqlKeySentenceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.backButton);
            this.Name = "SelectCachedSqlForm";
            this.Text = "SelectCachedSqlForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox sqlKeySentenceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sqlComboBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label1;
    }
}