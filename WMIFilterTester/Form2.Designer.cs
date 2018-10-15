namespace WMIFilterTester
{
    partial class frmQueryEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Query:";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(56, 40);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(552, 20);
            this.txtQuery.TabIndex = 1;
            // 
            // cmdValidate
            // 
            this.cmdValidate.Location = new System.Drawing.Point(226, 81);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(75, 23);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.Text = "Validate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(319, 81);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmQueryEntry
            // 
            this.AcceptButton = this.cmdValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 116);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Name = "frmQueryEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMI Filter Validation Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Button cmdCancel;
    }
}