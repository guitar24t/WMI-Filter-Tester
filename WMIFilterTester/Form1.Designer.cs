namespace WMIFilterTester
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;

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
            this.components = new System.ComponentModel.Container();
            this.listView_WMIFilters = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu_Validate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_DomainName = new System.Windows.Forms.TextBox();
            this.button_GetDomain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCustomQuery = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu_Validate.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_WMIFilters
            // 
            this.listView_WMIFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView_WMIFilters.ContextMenuStrip = this.contextMenu_Validate;
            this.listView_WMIFilters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView_WMIFilters.FullRowSelect = true;
            this.listView_WMIFilters.GridLines = true;
            this.listView_WMIFilters.Location = new System.Drawing.Point(0, 50);
            this.listView_WMIFilters.MultiSelect = false;
            this.listView_WMIFilters.Name = "listView_WMIFilters";
            this.listView_WMIFilters.ShowItemToolTips = true;
            this.listView_WMIFilters.Size = new System.Drawing.Size(893, 637);
            this.listView_WMIFilters.TabIndex = 0;
            this.listView_WMIFilters.UseCompatibleStateImageBehavior = false;
            this.listView_WMIFilters.View = System.Windows.Forms.View.Details;
            this.listView_WMIFilters.SelectedIndexChanged += new System.EventHandler(this.listView_WMIFilters_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "WMI Filter Name";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "WMI Query String";
            this.columnHeader3.Width = 263;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Linked to GPO(s)";
            this.columnHeader4.Width = 193;
            // 
            // contextMenu_Validate
            // 
            this.contextMenu_Validate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateToolStripMenuItem});
            this.contextMenu_Validate.Name = "contextMenu_Validate";
            this.contextMenu_Validate.Size = new System.Drawing.Size(117, 26);
            // 
            // validateToolStripMenuItem
            // 
            this.validateToolStripMenuItem.Name = "validateToolStripMenuItem";
            this.validateToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.validateToolStripMenuItem.Text = "Validate";
            this.validateToolStripMenuItem.Click += new System.EventHandler(this.validateToolStripMenuItem_Click);
            // 
            // textBox_DomainName
            // 
            this.textBox_DomainName.Location = new System.Drawing.Point(255, 14);
            this.textBox_DomainName.Name = "textBox_DomainName";
            this.textBox_DomainName.Size = new System.Drawing.Size(214, 20);
            this.textBox_DomainName.TabIndex = 1;
            // 
            // button_GetDomain
            // 
            this.button_GetDomain.Location = new System.Drawing.Point(486, 12);
            this.button_GetDomain.Name = "button_GetDomain";
            this.button_GetDomain.Size = new System.Drawing.Size(75, 23);
            this.button_GetDomain.TabIndex = 2;
            this.button_GetDomain.Text = "Get Filters";
            this.button_GetDomain.UseVisualStyleBackColor = true;
            this.button_GetDomain.Click += new System.EventHandler(this.button_GetDomain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Domain Naming Context (DC=example,DC=com):";
            // 
            // cmdCustomQuery
            // 
            this.cmdCustomQuery.Location = new System.Drawing.Point(743, 12);
            this.cmdCustomQuery.Name = "cmdCustomQuery";
            this.cmdCustomQuery.Size = new System.Drawing.Size(138, 23);
            this.cmdCustomQuery.TabIndex = 4;
            this.cmdCustomQuery.Text = "Validate Custom Query";
            this.cmdCustomQuery.UseVisualStyleBackColor = true;
            this.cmdCustomQuery.Click += new System.EventHandler(this.cmdCustomQuery_Click);
            // 
            // cmdValidate
            // 
            this.cmdValidate.Enabled = false;
            this.cmdValidate.Location = new System.Drawing.Point(638, 12);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(99, 23);
            this.cmdValidate.TabIndex = 5;
            this.cmdValidate.Text = "Validate Query";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Result";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 687);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.cmdCustomQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_GetDomain);
            this.Controls.Add(this.textBox_DomainName);
            this.Controls.Add(this.listView_WMIFilters);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMI Filter Validation Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenu_Validate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_WMIFilters;
        private System.Windows.Forms.TextBox textBox_DomainName;
        private System.Windows.Forms.Button button_GetDomain;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Validate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
        private System.Windows.Forms.Button cmdCustomQuery;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

