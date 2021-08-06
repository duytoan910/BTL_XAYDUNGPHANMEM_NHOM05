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
    public partial class frmReservation : Form
    {
        DiskTitleBLL bDiskTitle;
        CustomerBLL bCus;
        ReservationBLL bRe;
        DiskBLL bDisk;

        public frmReservation()
        {
            InitializeComponent();
        }

        private void frmReservation_Load(object sender, EventArgs e)
        {
            bDiskTitle = new DiskTitleBLL();
            bCus = new CustomerBLL();
            bRe = new ReservationBLL();
            bDisk = new DiskBLL();

            dgvDiskTitle.DataSource = bDiskTitle.getAllDiskTitleForLoad();

            FormatDataGridview();
            FormatDataGridviewForCusRe();

            txtFindInfo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFindInfo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            rdoDiskTitleID.Checked = true;

            btnConfirm.Enabled = false;
        }

        void FormatDataGridview()
        {
            dgvDiskTitle.Columns[0].HeaderText = "Mã tựa đĩa";
            dgvDiskTitle.Columns[1].HeaderText = "Tên tựa đĩa";
            dgvDiskTitle.Columns[1].Width = 300;
            dgvDiskTitle.Columns[2].HeaderText = "Thể loại";
            dgvDiskTitle.Columns[2].Width = 150;
            dgvDiskTitle.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void FormatDataGridviewForCusRe()
        {
            dgvReservationList.Columns[0].HeaderText = "Mã KH";
            dgvReservationList.Columns[1].HeaderText = "Tên khách hàng";
            dgvReservationList.Columns[1].Width = 200;
            dgvReservationList.Columns[2].HeaderText = "Ngày đặt";
            dgvReservationList.Columns[2].Width = 150;
            dgvReservationList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvReservationList.Columns[3].Visible = false;
            dgvReservationList.Columns[4].HeaderText = "Đĩa đang chờ";
        }

        private void dgvTourList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDiskTitle.SelectedRows.Count > 0)
            {
                int titleID = int.Parse(dgvDiskTitle.SelectedRows[0].Cells[0].Value.ToString());
                dgvReservationList.DataSource = bRe.getAllCustomerReservations(titleID);
            }
        }

        //CHỨC NĂNG TÌM KIẾM
        //Tìm kiếm Auto Complete  
        void AutoComplete()
        {
            if (rdoDiskTitleName.Checked)
            {
                foreach (eDiskTitle tour in bDiskTitle.getAllDiskTitle())
                {
                    txtFindInfo.AutoCompleteCustomSource.Add(tour.diskTitleName);
                }
            }
        }

        private void rdoDiskTitleName_CheckedChanged(object sender, EventArgs e)
        {
            txtFindInfo.AutoCompleteCustomSource.Clear();
            AutoComplete();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFindInfo.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm !", "Không có dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string key = txtFindInfo.Text;
            int pos = search(key);
            if (pos >= 0)
            {
                if (dgvDiskTitle.SelectedRows.Count > 0)
                {
                    dgvDiskTitle.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvDiskTitle.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvDiskTitle.CurrentCell = dgvDiskTitle.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int search(string key)
        {
            if (rdoDiskTitleID.Checked)
            {
                string a = "";
                for (int i = 0; i < dgvDiskTitle.Rows.Count; i++)
                {
                    a = dgvDiskTitle.Rows[i].Cells[0].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else
            {
                string a = "";
                for (int i = 0; i < dgvDiskTitle.Rows.Count; i++)
                {
                    a = dgvDiskTitle.Rows[i].Cells[1].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            return -1;
        }

        private void btnFindCus_Click(object sender, EventArgs e)
        {
            eCustomer c = bCus.findCustomer(int.Parse(txtIDCusFind.Text));

            if (c != null)
            {
                txtIDCus.Text = c.customerID.ToString();
                txtName.Text = c.customerName;
                txtAddress.Text = c.customerAddress;
                txtPhone.Text = c.customerPhone;

                TurnOnOffPayButton();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLateCharge_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDCus.Text);
            frmIndicateLateCharge nForm = new frmIndicateLateCharge(id);
            nForm.Show();
        }

        void TurnOnOffPayButton()
        {
            if (txtIDCus.Text != "")
            {
                btnConfirm.Enabled = true;
            }
            else btnConfirm.Enabled = false;

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xác nhận đặt trước ?", "Đặt trước", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Thêm đặt trước cho khách hàng
                int titleID = int.Parse(dgvDiskTitle.SelectedRows[0].Cells[0].Value.ToString());
                int cusID = int.Parse(txtIDCus.Text);
                eReservation x = new eReservation();

                x.diskTitleId = titleID;
                x.customerID = cusID;
                x.dateOrder = DateTime.Now;

                bRe.addReservation(x);

                MessageBox.Show("Hoàn tất đặt trước cho khách hàng", "Đặt trước", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvReservationList.DataSource = bRe.getAllCustomerReservations(titleID);
            }
        }

        private void btnCancelRe_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xóa đặt trước của khách hàng này ?", "Xóa đặt trước", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Xóa đặt trước cho khách hàng
                int titleID = int.Parse(dgvDiskTitle.SelectedRows[0].Cells[0].Value.ToString());
                int reID = int.Parse(dgvReservationList.SelectedRows[0].Cells[3].Value.ToString());

                eReservation x = bRe.findReservation(reID);
                int? id = x.diskId;

                //Xóa đặt
                bRe.deleteReservation(reID);

                //Kiểm tra xem người đặt đã có đĩa hold hay chưa -> nếu có chuyển xuống người thứ 2 
                if (id != null)
                {
                    string title = dgvDiskTitle.SelectedRows[0].Cells[1].Value.ToString();
                    bool result = bRe.setOnHold(title, id);
                    if(result == false)
                    {
                        bDisk.setStatus(id, "Trên kệ");
                    }
                }
                MessageBox.Show("Hoàn tất xóa đặt trước", "Đặt trước", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvReservationList.DataSource = bRe.getAllCustomerReservations(titleID);
            }
        }

        //Chỉnh màu cho cột trong datagridview
        private void dgvDiskTitle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvDiskTitle.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Myrow.Cells[2].Value.Equals("Đĩa phim"))// Or your condition 
                {
                    Myrow.Cells[2].Style.ForeColor = Color.Green;
                }
                else
                {
                    Myrow.Cells[2].Style.ForeColor = Color.Blue;
                }
            }
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

        private void dgvReservationList_SelectionChanged(object sender, EventArgs e)
        {

        }


    }
}
