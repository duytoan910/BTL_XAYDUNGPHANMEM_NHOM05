namespace BTL_XAYDUNGPHANMEM_NHOM05
{
    partial class frmReservation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDiskTitle = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFindInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.grbFind = new System.Windows.Forms.GroupBox();
            this.btnFindCus = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIDCus = new System.Windows.Forms.TextBox();
            this.txtIDCusFind = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvReservationList = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelRe = new System.Windows.Forms.Button();
            this.rdoDiskTitleName = new System.Windows.Forms.RadioButton();
            this.rdoDiskTitleID = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiskTitle)).BeginInit();
            this.grbFind.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservationList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoDiskTitleName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoDiskTitleID);
            this.groupBox1.Controls.Add(this.dgvDiskTitle);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtFindInfo);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 590);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH TỰA ĐĨA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhập mã đĩa:";
            // 
            // dgvDiskTitle
            // 
            this.dgvDiskTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiskTitle.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiskTitle.Location = new System.Drawing.Point(6, 75);
            this.dgvDiskTitle.MultiSelect = false;
            this.dgvDiskTitle.Name = "dgvDiskTitle";
            this.dgvDiskTitle.ReadOnly = true;
            this.dgvDiskTitle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiskTitle.Size = new System.Drawing.Size(582, 509);
            this.dgvDiskTitle.TabIndex = 0;
            this.dgvDiskTitle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTourList_CellDoubleClick);
            this.dgvDiskTitle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDiskTitle_CellFormatting);
            this.dgvDiskTitle.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvTourList_RowStateChanged_1);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(513, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFindInfo
            // 
            this.txtFindInfo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindInfo.Location = new System.Drawing.Point(88, 23);
            this.txtFindInfo.Name = "txtFindInfo";
            this.txtFindInfo.Size = new System.Drawing.Size(419, 21);
            this.txtFindInfo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(601, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ THUÊ ĐĨA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(119, 256);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(300, 46);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "ĐẶT TRƯỚC";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // grbFind
            // 
            this.grbFind.Controls.Add(this.btnFindCus);
            this.grbFind.Controls.Add(this.txtPhone);
            this.grbFind.Controls.Add(this.txtAddress);
            this.grbFind.Controls.Add(this.btnConfirm);
            this.grbFind.Controls.Add(this.txtName);
            this.grbFind.Controls.Add(this.txtIDCus);
            this.grbFind.Controls.Add(this.txtIDCusFind);
            this.grbFind.Controls.Add(this.label4);
            this.grbFind.Controls.Add(this.label8);
            this.grbFind.Controls.Add(this.label7);
            this.grbFind.Controls.Add(this.label6);
            this.grbFind.Controls.Add(this.label5);
            this.grbFind.Controls.Add(this.label3);
            this.grbFind.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFind.Location = new System.Drawing.Point(612, 324);
            this.grbFind.Name = "grbFind";
            this.grbFind.Size = new System.Drawing.Size(529, 325);
            this.grbFind.TabIndex = 5;
            this.grbFind.TabStop = false;
            this.grbFind.Text = "TÌM KIẾM KHÁCH HÀNG";
            // 
            // btnFindCus
            // 
            this.btnFindCus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindCus.Location = new System.Drawing.Point(425, 27);
            this.btnFindCus.Name = "btnFindCus";
            this.btnFindCus.Size = new System.Drawing.Size(75, 23);
            this.btnFindCus.TabIndex = 3;
            this.btnFindCus.Text = "Tìm kiếm";
            this.btnFindCus.UseVisualStyleBackColor = true;
            this.btnFindCus.Click += new System.EventHandler(this.btnFindCus_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(117, 213);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(302, 22);
            this.txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(117, 173);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(302, 22);
            this.txtAddress.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(117, 133);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(302, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtIDCus
            // 
            this.txtIDCus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCus.Location = new System.Drawing.Point(117, 93);
            this.txtIDCus.Name = "txtIDCus";
            this.txtIDCus.ReadOnly = true;
            this.txtIDCus.Size = new System.Drawing.Size(302, 22);
            this.txtIDCus.TabIndex = 2;
            // 
            // txtIDCusFind
            // 
            this.txtIDCusFind.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCusFind.Location = new System.Drawing.Point(117, 27);
            this.txtIDCusFind.Name = "txtIDCusFind";
            this.txtIDCusFind.Size = new System.Drawing.Size(302, 22);
            this.txtIDCusFind.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(78, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "SĐT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(64, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Địa chỉ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tên KH:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mã KH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhập mã KH:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(113)))), ((int)(((byte)(197)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 45);
            this.panel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelRe);
            this.groupBox2.Controls.Add(this.dgvReservationList);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(612, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 259);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DANH SÁCH KHÁCH HÀNG ĐÃ ĐẶT";
            // 
            // dgvReservationList
            // 
            this.dgvReservationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservationList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReservationList.Location = new System.Drawing.Point(7, 21);
            this.dgvReservationList.MultiSelect = false;
            this.dgvReservationList.Name = "dgvReservationList";
            this.dgvReservationList.ReadOnly = true;
            this.dgvReservationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservationList.Size = new System.Drawing.Size(647, 207);
            this.dgvReservationList.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(114, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "( *Khách hàng có phí trễ hạn chưa thanh toán)";
            // 
            // btnCancelRe
            // 
            this.btnCancelRe.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelRe.Location = new System.Drawing.Point(543, 230);
            this.btnCancelRe.Name = "btnCancelRe";
            this.btnCancelRe.Size = new System.Drawing.Size(111, 23);
            this.btnCancelRe.TabIndex = 3;
            this.btnCancelRe.Text = "Hủy đặt trước";
            this.btnCancelRe.UseVisualStyleBackColor = true;
            this.btnCancelRe.Click += new System.EventHandler(this.btnCancelRe_Click);
            // 
            // rdoDiskTitleName
            // 
            this.rdoDiskTitleName.AutoSize = true;
            this.rdoDiskTitleName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiskTitleName.Location = new System.Drawing.Point(180, 50);
            this.rdoDiskTitleName.Name = "rdoDiskTitleName";
            this.rdoDiskTitleName.Size = new System.Drawing.Size(87, 19);
            this.rdoDiskTitleName.TabIndex = 7;
            this.rdoDiskTitleName.TabStop = true;
            this.rdoDiskTitleName.Text = "Tìm theo tên";
            this.rdoDiskTitleName.UseVisualStyleBackColor = true;
            this.rdoDiskTitleName.CheckedChanged += new System.EventHandler(this.rdoDiskTitleName_CheckedChanged);
            // 
            // rdoDiskTitleID
            // 
            this.rdoDiskTitleID.AutoSize = true;
            this.rdoDiskTitleID.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiskTitleID.Location = new System.Drawing.Point(88, 50);
            this.rdoDiskTitleID.Name = "rdoDiskTitleID";
            this.rdoDiskTitleID.Size = new System.Drawing.Size(86, 19);
            this.rdoDiskTitleID.TabIndex = 8;
            this.rdoDiskTitleID.TabStop = true;
            this.rdoDiskTitleID.Text = "Tìm theo mã";
            this.rdoDiskTitleID.UseVisualStyleBackColor = true;
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbFind);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReservation";
            this.Text = "ĐẶT CHỖ";
            this.Load += new System.EventHandler(this.frmReservation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiskTitle)).EndInit();
            this.grbFind.ResumeLayout(false);
            this.grbFind.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservationList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtFindInfo;
        private System.Windows.Forms.GroupBox grbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDiskTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindCus;
        private System.Windows.Forms.TextBox txtIDCusFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIDCus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvReservationList;
        private System.Windows.Forms.Button btnCancelRe;
        private System.Windows.Forms.RadioButton rdoDiskTitleName;
        private System.Windows.Forms.RadioButton rdoDiskTitleID;
    }
}