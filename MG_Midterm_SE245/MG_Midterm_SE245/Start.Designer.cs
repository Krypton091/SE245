namespace MG_Midterm_SE245
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
            this.chooseAdd = new System.Windows.Forms.Button();
            this.chooseSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseAdd
            // 
            this.chooseAdd.Location = new System.Drawing.Point(186, 181);
            this.chooseAdd.Name = "chooseAdd";
            this.chooseAdd.Size = new System.Drawing.Size(150, 50);
            this.chooseAdd.TabIndex = 0;
            this.chooseAdd.Text = "Add Person";
            this.chooseAdd.UseVisualStyleBackColor = true;
            this.chooseAdd.Click += new System.EventHandler(this.chooseAdd_Click);
            // 
            // chooseSearch
            // 
            this.chooseSearch.Location = new System.Drawing.Point(457, 181);
            this.chooseSearch.Name = "chooseSearch";
            this.chooseSearch.Size = new System.Drawing.Size(150, 50);
            this.chooseSearch.TabIndex = 1;
            this.chooseSearch.Text = "Search Records";
            this.chooseSearch.UseVisualStyleBackColor = true;
            this.chooseSearch.Click += new System.EventHandler(this.chooseSearch_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chooseSearch);
            this.Controls.Add(this.chooseAdd);
            this.Name = "Start";
            this.Text = "Start Screen";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chooseAdd;
        private System.Windows.Forms.Button chooseSearch;
    }
}