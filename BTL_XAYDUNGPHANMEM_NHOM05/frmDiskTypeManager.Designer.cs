namespace BTL_XAYDUNGPHANMEM_NHOM05
{
    partial class frmDiskTypeManager
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
            this.rdoGameDisk = new System.Windows.Forms.RadioButton();
            this.rdoMovieDisk = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtLateFee = new System.Windows.Forms.TextBox();
            this.txtRentalPeriod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRentalCharge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ LOẠI ĐĨA";
            // 
            // rdoGameDisk
            // 
            this.rdoGameDisk.AutoSize = true;
            this.rdoGameDisk.Location = new System.Drawing.Point(115, 51);
            this.rdoGameDisk.Name = "rdoGameDisk";
            this.rdoGameDisk.Size = new System.Drawing.Size(74, 19);
            this.rdoGameDisk.TabIndex = 1;
            this.rdoGameDisk.TabStop = true;
            this.rdoGameDisk.Text = "Đĩa game";
            this.rdoGameDisk.UseVisualStyleBackColor = true;
            this.rdoGameDisk.CheckedChanged += new System.EventHandler(this.rdoGameDisk_CheckedChanged);
            // 
            // rdoMovieDisk
            // 
            this.rdoMovieDisk.AutoSize = true;
            this.rdoMovieDisk.Location = new System.Drawing.Point(292, 51);
            this.rdoMovieDisk.Name = "rdoMovieDisk";
            this.rdoMovieDisk.Size = new System.Drawing.Size(72, 19);
            this.rdoMovieDisk.TabIndex = 1;
            this.rdoMovieDisk.TabStop = true;
            this.rdoMovieDisk.Text = "Đĩa phim";
            this.rdoMovieDisk.UseVisualStyleBackColor = true;
            this.rdoMovieDisk.CheckedChanged += new System.EventHandler(this.rdoMovieDisk_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtLateFee);
            this.groupBox1.Controls.Add(this.txtRentalPeriod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRentalCharge);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoMovieDisk);
            this.groupBox1.Controls.Add(this.rdoGameDisk);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 291);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CÀI ĐẶT LOẠI ĐĨA";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(115, 226);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtLateFee
            // 
            this.txtLateFee.Location = new System.Drawing.Point(115, 133);
            this.txtLateFee.Name = "txtLateFee";
            this.txtLateFee.Size = new System.Drawing.Size(249, 22);
            this.txtLateFee.TabIndex = 3;
            // 
            // txtRentalPeriod
            // 
            this.txtRentalPeriod.Location = new System.Drawing.Point(115, 170);
            this.txtRentalPeriod.Name = "txtRentalPeriod";
            this.txtRentalPeriod.Size = new System.Drawing.Size(249, 22);
            this.txtRentalPeriod.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phí phạt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hạn thuê (ngày):";
            // 
            // txtRentalCharge
            // 
            this.txtRentalCharge.Location = new System.Drawing.Point(115, 93);
            this.txtRentalCharge.Name = "txtRentalCharge";
            this.txtRentalCharge.Size = new System.Drawing.Size(249, 22);
            this.txtRentalCharge.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phí thuê:";
            // 
            // frmDiskTypeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 388);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmDiskTypeManager";
            this.Text = "DiskTypeManager";
            this.Load += new System.EventHandler(this.frmDiskTypeManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoGameDisk;
        private System.Windows.Forms.RadioButton rdoMovieDisk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtLateFee;
        private System.Windows.Forms.TextBox txtRentalPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRentalCharge;
        private System.Windows.Forms.Label label2;
    }
}