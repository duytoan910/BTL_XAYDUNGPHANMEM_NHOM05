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
    public partial class frmIndicateLateCharge : Form
    {
        int idCus;
        double sumMoney = 0;
        LateChargeBLL bCharge;
        CustomerBLL bCus;

        public frmIndicateLateCharge()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public frmIndicateLateCharge(int id)
        {
            InitializeComponent();
            CenterToScreen();

            this.idCus = id;
            bCharge = new LateChargeBLL();
            bCus = new CustomerBLL();

            lblIDCus.Text = id.ToString();
            lblCusName.Text = bCus.findCustomer(id).customerName;

            dgvChargeList.DataSource = bCharge.getLateChargeByIDCus(id) ;
            FormatDataGridview();
            txtTotal.Text = sumMoney.ToString();
        }

        private void IndicateLateCharge_Load(object sender, EventArgs e)
        {

        }

        void FormatDataGridview()
        {
            dgvChargeList.Columns[0].Visible = false;
            dgvChargeList.Columns[1].HeaderText = "Đĩa đã thuê";
            dgvChargeList.Columns[1].Width = 400;
            dgvChargeList.Columns[2].HeaderText = "Ngày thuê";
            dgvChargeList.Columns[3].HeaderText = "Ngày trả";
            dgvChargeList.Columns[4].HeaderText = "Phí phạt";
            dgvChargeList.Columns[5].HeaderText = "Chọn phí";
            dgvChargeList.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChargeList.Columns[6].Visible = false;
        }      

        //Xử lý nút thanh toán
        private void btnConfirm_Click(object sender, EventArgs e)
        {                      
            DialogResult dialogResult = MessageBox.Show("Xác nhận thanh toán ?", "Thanh toán", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Cập nhập trạng thái đã thanh toán cho các phí được chọn
                foreach (DataGridViewRow row in dgvChargeList.Rows)
                {
                    int id = int.Parse(row.Cells[0].Value.ToString());
                    bool a = (bool)row.Cells[5].Value;

                    if (a == true)
                    {
                        // Chuyển thành trạng thái true: đã thanh toán
                        bCharge.setStatus(id, true);
                    }
                }
                MessageBox.Show("Các phí đã chọn thanh toán thành công !", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvChargeList.DataSource = bCharge.getLateChargeByIDCus(idCus);
            }
        }

        //Sự kiện click vào checkbox trên datagrid view
        private void dgvChargeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvChargeList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            sumMoney = 0;
            foreach (DataGridViewRow row in dgvChargeList.Rows)
            {
                bool a = (bool)row.Cells[5].Value;
                double money = double.Parse(row.Cells[4].Value.ToString());
                if (a == true)
                {
                    sumMoney += money;
                }
            }

            txtTotal.Text = string.Format("{0:#,##}", Convert.ToDecimal(sumMoney.ToString()));
        }

        private void dgvChargeList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow row in dgvChargeList.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[4];
            //    //bool a = (bool)row.Cells[4.Value;
            //    MessageBox.Show(row.Cells[4].Value.ToString());
            //}
        }

        private void dgvChargeList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvChargeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvChargeList.Rows)
            {
                Myrow.Cells[4].Style.ForeColor = Color.Red;
            }
        }
    }
}
