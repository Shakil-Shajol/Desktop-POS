namespace PointOfSales
{
    partial class frmCustomerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpCustomerInfo = new System.Windows.Forms.GroupBox();
            this.btnProcedSales = new System.Windows.Forms.Button();
            this.txtContactGrp = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpNodataFound = new System.Windows.Forms.GroupBox();
            this.btnCustomerEntry = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grpCustomerInfo.SuspendLayout();
            this.grpNodataFound.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact No :";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(105, 34);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(194, 25);
            this.txtContact.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(306, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpCustomerInfo
            // 
            this.grpCustomerInfo.Controls.Add(this.btnProcedSales);
            this.grpCustomerInfo.Controls.Add(this.txtContactGrp);
            this.grpCustomerInfo.Controls.Add(this.txtAddress);
            this.grpCustomerInfo.Controls.Add(this.txtName);
            this.grpCustomerInfo.Controls.Add(this.label4);
            this.grpCustomerInfo.Controls.Add(this.label3);
            this.grpCustomerInfo.Controls.Add(this.label2);
            this.grpCustomerInfo.Location = new System.Drawing.Point(16, 67);
            this.grpCustomerInfo.Name = "grpCustomerInfo";
            this.grpCustomerInfo.Size = new System.Drawing.Size(373, 210);
            this.grpCustomerInfo.TabIndex = 3;
            this.grpCustomerInfo.TabStop = false;
            this.grpCustomerInfo.Text = "Customer Info";
            this.grpCustomerInfo.Visible = false;
            // 
            // btnProcedSales
            // 
            this.btnProcedSales.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcedSales.Location = new System.Drawing.Point(122, 175);
            this.btnProcedSales.Name = "btnProcedSales";
            this.btnProcedSales.Size = new System.Drawing.Size(134, 29);
            this.btnProcedSales.TabIndex = 2;
            this.btnProcedSales.Text = "Proceed To Sales";
            this.btnProcedSales.UseVisualStyleBackColor = true;
            this.btnProcedSales.Click += new System.EventHandler(this.btnProcedSales_Click);
            // 
            // txtContactGrp
            // 
            this.txtContactGrp.Location = new System.Drawing.Point(99, 59);
            this.txtContactGrp.Name = "txtContactGrp";
            this.txtContactGrp.ReadOnly = true;
            this.txtContactGrp.Size = new System.Drawing.Size(255, 25);
            this.txtContactGrp.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(99, 90);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(255, 66);
            this.txtAddress.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 28);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(255, 25);
            this.txtName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contact No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name :";
            // 
            // grpNodataFound
            // 
            this.grpNodataFound.Controls.Add(this.btnCustomerEntry);
            this.grpNodataFound.Controls.Add(this.label5);
            this.grpNodataFound.Location = new System.Drawing.Point(16, 65);
            this.grpNodataFound.Name = "grpNodataFound";
            this.grpNodataFound.Size = new System.Drawing.Size(373, 141);
            this.grpNodataFound.TabIndex = 3;
            this.grpNodataFound.TabStop = false;
            this.grpNodataFound.Text = "Customer Info";
            this.grpNodataFound.Visible = false;
            // 
            // btnCustomerEntry
            // 
            this.btnCustomerEntry.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerEntry.Location = new System.Drawing.Point(122, 93);
            this.btnCustomerEntry.Name = "btnCustomerEntry";
            this.btnCustomerEntry.Size = new System.Drawing.Size(134, 26);
            this.btnCustomerEntry.TabIndex = 1;
            this.btnCustomerEntry.Text = "Customer Entry";
            this.btnCustomerEntry.UseVisualStyleBackColor = true;
            this.btnCustomerEntry.Click += new System.EventHandler(this.btnCustomerEntry_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 55);
            this.label5.TabIndex = 0;
            this.label5.Text = "No Data Found!\r\nEnter new customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmCustomerInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(401, 285);
            this.Controls.Add(this.grpCustomerInfo);
            this.Controls.Add(this.grpNodataFound);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Information";
            this.grpCustomerInfo.ResumeLayout(false);
            this.grpCustomerInfo.PerformLayout();
            this.grpNodataFound.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpCustomerInfo;
        private System.Windows.Forms.Button btnProcedSales;
        private System.Windows.Forms.TextBox txtContactGrp;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpNodataFound;
        private System.Windows.Forms.Button btnCustomerEntry;
        private System.Windows.Forms.Label label5;
    }
}