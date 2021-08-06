using BLL;
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
    public partial class frmCustomerReport : Form
    {
        CustomerBLL bCus;
        RentalBillBLL bRent;
        LateChargeBLL bLateCharge;

        public frmCustomerReport()
        {
            InitializeComponent();
        }


        private void frmCustomerReport_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            rdoAllCus.Checked = true;

            bCus = new CustomerBLL();
            bRent = new RentalBillBLL();
            bLateCharge = new LateChargeBLL();

            //Load dữ liệu datagridview
            dgvCusList.DataSource = bCus.getCustomer();

            FormatDataGridview();
            FormatDataGridviewForRentDisk();
            FormatDataGridviewForOverdueRentDisk();
            FormatDataGridviewLateCharge();
        }

        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            bCus = new CustomerBLL();
            bRent = new RentalBillBLL();
            bLateCharge = new LateChargeBLL();
            if (dgvCusList.SelectedRows.Count > 0)
            {
                int cusID = int.Parse(dgvCusList.SelectedRows[0].Cells[0].Value.ToString());
                dgvDiskRent.DataSource = bRent.getRentalBillDetailByID(cusID);
                dgvOverdueDisk.DataSource = bRent.getOverdueRentalBillByID(cusID);
                dgvLateCharge.DataSource = bLateCharge.getLateChargeByIDCus(cusID);
            }
        }

        //Update datagrid view

        private void rdoAllCus_CheckedChanged(object sender, EventArgs e)
        {
            bCus = new CustomerBLL();
            dgvCusList.DataSource = bCus.getCustomer();
        }

        private void rdoCusWithDisk_CheckedChanged(object sender, EventArgs e)
        {
            dgvCusList.DataSource = bCus.getCustomerByOverdueDisk();
        }

        private void rdoCusWithLateCharge_CheckedChanged(object sender, EventArgs e)
        {
            dgvCusList.DataSource = bCus.getCustomerByLateCharge();
        }

        private void dgvDiskRent_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        void FormatDataGridview()
        {
            dgvCusList.Columns[0].HeaderText = "Mã KH";
            dgvCusList.Columns[1].HeaderText = "Tên khách hàng";
            dgvCusList.Columns[1].Width = 150;
            dgvCusList.Columns[2].HeaderText = "Địa chỉ";
            dgvCusList.Columns[2].Width = 250;
            dgvCusList.Columns[3].HeaderText = "Số điện thoại";
            dgvCusList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCusList.Columns[4].Visible = false;
            dgvCusList.Columns[5].Visible = false;
        }

        void FormatDataGridviewForRentDisk()
        {
            dgvDiskRent.Columns[0].HeaderText = "Mã đĩa";
            dgvDiskRent.Columns[1].HeaderText = "Tựa đĩa";
            dgvDiskRent.Columns[1].Width = 200;
            dgvDiskRent.Columns[2].HeaderText = "Ngày thuê";
            dgvDiskRent.Columns[3].HeaderText = "Hạn trả";
            dgvDiskRent.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void FormatDataGridviewForOverdueRentDisk()
        {
            dgvOverdueDisk.Columns[0].HeaderText = "Mã đĩa";
            dgvOverdueDisk.Columns[1].HeaderText = "Tựa đĩa";
            dgvOverdueDisk.Columns[1].Width = 200;
            dgvOverdueDisk.Columns[2].HeaderText = "Ngày thuê";
            dgvOverdueDisk.Columns[3].HeaderText = "Hạn trả";
            dgvOverdueDisk.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void FormatDataGridviewLateCharge()
        {
            dgvLateCharge.Columns[0].Visible = false;
            dgvLateCharge.Columns[1].HeaderText = "Đĩa đã thuê";
            dgvLateCharge.Columns[1].Width = 300;
            dgvLateCharge.Columns[2].HeaderText = "Ngày thuê";
            dgvLateCharge.Columns[3].HeaderText = "Ngày trả";
            dgvLateCharge.Columns[4].HeaderText = "Phí phạt";
            dgvLateCharge.Columns[5].HeaderText = "Chọn phí";
            dgvLateCharge.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLateCharge.Columns[6].Visible = false;
        }



        //-------------------------------------------------------------------------------------------
        private void dgvEmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEmpList_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
