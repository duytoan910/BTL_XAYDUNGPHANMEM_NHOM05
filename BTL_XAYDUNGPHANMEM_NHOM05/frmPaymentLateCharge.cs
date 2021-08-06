using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_XAYDUNGPHANMEM_NHOM05
{
    public partial class frmPaymentLateCharge : Form
    {
        CustomerBLL bCus;
        LateChargeBLL bCharge;
        double sumMoney = 0;

        public frmPaymentLateCharge()
        {
            InitializeComponent();
        }


        private void frmPaymentLateCharge_Load(object sender, EventArgs e)
        {
            bCus = new CustomerBLL();
            bCharge = new LateChargeBLL();

            btnPay.Enabled = false;
            txtTotal.Text = "0";
        }

        void FormatDataGridview()
        {
            dgvLateCharge.Columns[0].Visible = false;
            dgvLateCharge.Columns[1].HeaderText = "Đĩa đã thuê";
            dgvLateCharge.Columns[1].Width = 400;
            dgvLateCharge.Columns[2].HeaderText = "Hạn trả";
            dgvLateCharge.Columns[2].Width = 150;
            dgvLateCharge.Columns[3].HeaderText = "Ngày trả";
            dgvLateCharge.Columns[3].Width = 150;
            dgvLateCharge.Columns[4].HeaderText = "Phí phạt";
            dgvLateCharge.Columns[5].HeaderText = "Chọn phí";
            dgvLateCharge.Columns[6].Visible = false;


            //Thêm cột trạng thái thanh toán + format
            dgvLateCharge.Columns.Add("Status", "Trạng thái");
            dgvLateCharge.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow Myrow in dgvLateCharge.Rows)
            {
                Myrow.Cells[4].Style.ForeColor = Color.Red;

                bool a = (bool)Myrow.Cells[5].Value;

                if (a == true)
                {
                    Myrow.Cells[7].Value = "Đã thanh toán";
                    Myrow.Cells[7].Style.ForeColor = Color.Green;
                    Myrow.ReadOnly = true;
                }
                else
                {
                    Myrow.Cells[7].Value = "Chưa thanh toán";
                    Myrow.Cells[7].Style.ForeColor = Color.Red;
                }
            }
        }
        
        //Update datagrid view
        void UpdateDataGridView()
        {
            this.dgvLateCharge.DataSource = null;
            dgvLateCharge.Rows.Clear();
            dgvLateCharge.Columns.Clear();

            int idCus = int.Parse(txtIDCus.Text);
            dgvLateCharge.DataSource = bCharge.getAllLateChargeByIDCus(idCus);

            FormatDataGridview();         
        }       
    
        //CHỨC NĂNG TÌM KIẾM          
        private void btnFindCus_Click(object sender, EventArgs e)
        {
            eCustomer c = bCus.findCustomer(int.Parse(txtIDCusFind.Text));

            if (c != null)
            {
                txtIDCus.Text = c.customerID.ToString();
                txtName.Text = c.customerName;
                txtAddress.Text = c.customerAddress;
                txtPhone.Text = c.customerPhone;

                UpdateDataGridView();

                btnPay.Enabled = false;
                txtTotal.Text = "0";
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //CHỨC NĂNG THANH TOÁN
        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xác nhận thanh toán ?", "Thanh toán", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Cập nhập trạng thái đã thanh toán cho các phí được chọn
                foreach (DataGridViewRow row in dgvLateCharge.Rows)
                {
                    string status = row.Cells[7].Value.ToString();
                    int id = int.Parse(row.Cells[0].Value.ToString());
                    bool a = (bool)row.Cells[5].Value;

                    if (a == true && status == "Chưa thanh toán")
                    {
                        // Chuyển thành trạng thái true: đã thanh toán
                        bCharge.setStatus(id, true);
                    }
                }
                MessageBox.Show("Các phí đã chọn thanh toán thành công !", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateDataGridView();
            }
        }

        //Chỉnh màu cho cột trong datagridview
        private void dgvDiskTitle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        
        }

        //Sự kiện click checkbox
        private void dgvLateCharge_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLateCharge.CommitEdit(DataGridViewDataErrorContexts.Commit);
            sumMoney = 0;
            foreach (DataGridViewRow row in dgvLateCharge.Rows)
            {
                string status = row.Cells[7].Value.ToString();
                bool a = (bool)row.Cells[5].Value;
                double money = double.Parse(row.Cells[4].Value.ToString());
                if (a == true && status=="Chưa thanh toán")
                {
                    sumMoney += money;
                }
            }

            txtTotal.Text = string.Format("{0:#,##}", Convert.ToDecimal(sumMoney.ToString()));
            btnPay.Enabled = true;
        }



        //----------------------------------------------------------------------------
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dgvTourList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvTourList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dgvDisk.SelectedRows.Count > 0)
            //{
            //    txtDiskID.Text = dgvDisk.SelectedRows[0].Cells[0].Value.ToString();
            //    cboDisk.Text = dgvDisk.SelectedRows[0].Cells[1].Value.ToString();
            //}
        }
        private void dgvLateCharge_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow Myrow in dgvLateCharge.Rows)
            //{
            //    Myrow.Cells[1].Value = "aaaa";
            //}
        }
    }
}
