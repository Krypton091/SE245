namespace MG_FinalExam_SE245
{
    partial class Start
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
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnSearchRecord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(107, 96);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(135, 50);
            this.btnAddRecord.TabIndex = 0;
            this.btnAddRecord.Text = "Add Record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnSearchRecord
            // 
            this.btnSearchRecord.Location = new System.Drawing.Point(330, 96);
            this.btnSearchRecord.Name = "btnSearchRecord";
            this.btnSearchRecord.Size = new System.Drawing.Size(135, 50);
            this.btnSearchRecord.TabIndex = 1;
            this.btnSearchRecord.Text = "Search/Update/Delete Records";
            this.btnSearchRecord.UseVisualStyleBackColor = true;
            this.btnSearchRecord.Click += new System.EventHandler(this.btnSearchRecord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 266);
            this.Controls.Add(this.btnSearchRecord);
            this.Controls.Add(this.btnAddRecord);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnSearchRecord;
    }
}

