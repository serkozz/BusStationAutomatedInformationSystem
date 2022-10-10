namespace BusStationAutomatedInformationSystem
{
    partial class CacheSqlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheSqlForm));
            this.sqlTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.keySequenceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sqlTextBox
            // 
            this.sqlTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sqlTextBox.Location = new System.Drawing.Point(160, 38);
            this.sqlTextBox.Name = "sqlTextBox";
            this.sqlTextBox.Size = new System.Drawing.Size(792, 40);
            this.sqlTextBox.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(26, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 34);
            this.label7.TabIndex = 34;
            this.label7.Text = "Запрос:";
            // 
            // keySequenceTextBox
            // 
            this.keySequenceTextBox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.keySequenceTextBox.Location = new System.Drawing.Point(385, 101);
            this.keySequenceTextBox.Name = "keySequenceTextBox";
            this.keySequenceTextBox.Size = new System.Drawing.Size(567, 40);
            this.keySequenceTextBox.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 34);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ключевое выражение:";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(26, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(173, 123);
            this.cancelButton.TabIndex = 38;
            this.cancelButton.Text = "\r\n\r\n\r\nНазад";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(779, 167);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(173, 123);
            this.saveButton.TabIndex = 39;
            this.saveButton.Text = "\r\n\r\n\r\nСохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // CasheSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 306);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.keySequenceTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqlTextBox);
            this.Controls.Add(this.label7);
            this.Name = "CasheSqlForm";
            this.Text = "CasheSqlForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sqlTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox keySequenceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}