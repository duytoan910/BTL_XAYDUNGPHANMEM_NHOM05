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
    public partial class frmCustomerManager : Form
    {
        CustomerBLL bCus;
        RentalBillBLL bRent;

        public frmCustomerManager()
        {
            InitializeComponent();
        }

        private void frmCustomerManager_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bCus = new CustomerBLL();
            bRent = new RentalBillBLL();          

            btnSave.Enabled = false;
            txtCusID.Enabled = false;
            label2.Text = "";

            txtFindInfo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFindInfo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            rdoCusID.Checked = true;

            //Load dữ liệu datagridview
            dgvCusList.DataSource = bCus.getCustomer();
            FormatDataGridview();
            FormatDataGridviewForRentDisk();

            setOnOffEditTextbox(0);

        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCusList.SelectedRows.Count > 0)
            {
                txtCusID.Text = dgvCusList.SelectedRows[0].Cells[0].Value.ToString();
                txtCusName.Text = dgvCusList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvCusList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvCusList.SelectedRows[0].Cells[3].Value.ToString();

                int cusID = int.Parse(dgvCusList.SelectedRows[0].Cells[0].Value.ToString());
                dgvDiskRent.DataSource = bRent.getRentalBillDetailByID(cusID);
            }
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

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtCusID.ReadOnly = true;
                txtCusID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtCusName.ReadOnly = true;
                txtCusName.BackColor = System.Drawing.SystemColors.Window;
                txtAddress.ReadOnly = true;
                txtAddress.BackColor = System.Drawing.SystemColors.Window;
                txtPhone.ReadOnly = true;
                txtPhone.BackColor = System.Drawing.SystemColors.Window;
            }
            else if (c == 1)
            {
                txtCusID.ReadOnly = false;
                txtCusName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
            }
        }

        void clearTextbox()
        {
            txtCusID.Text = "";
            txtCusName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }

        void UpdateControl_On()
        {
            btnSave.Enabled = true;
            btnSave.Text = "Lưu thêm";
            btnSave.BackColor = Color.FromArgb(36, 187, 116);
            btnNew.Text = "Hủy";
            btnNew.BackColor = Color.FromArgb(231, 62, 52);
            label2.Text = "*Nhập thông tin khách hàng mới";
            setOnOffEditTextbox(1);


            btnSave.ForeColor = Color.White;
            btnNew.ForeColor = Color.White;
            btnUpdate.Enabled = false;
        }

        void UpdateControl_Off()
        {
            btnSave.Enabled = false;
            btnSave.Text = "Lưu";
            btnSave.BackColor = Color.Gainsboro;
            btnNew.Text = "Thêm";
            btnNew.BackColor = Color.Gainsboro;
            label2.Text = "";
            setOnOffEditTextbox(0);

            btnSave.ForeColor = Color.Black;
            btnNew.ForeColor = Color.Black;
            btnUpdate.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearTextbox();
            if (!btnNew.Text.Equals("Hủy"))
            {
                UpdateControl_On();
            }
            else
            {
                UpdateControl_Off();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCusName.Text.Length == 0 || txtPhone.Text.Length == 0 || txtAddress.Text.Length == 0)
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPhone.Text.CheckPhoneNumber() == false)
            {
                MessageBox.Show("Số điện thoại phải ít nhất có 9 số và lớn nhất 15 ký tự ( bao gồm ký tự +,-) !", "SĐT không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eCustomer cus = new eCustomer();

            cus.customerName = txtCusName.Text;
            cus.customerAddress = txtAddress.Text;
            cus.customerPhone = txtPhone.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    bCus.addCustomer(cus);

                    clearTextbox();
                    UpdateControl_Off();

                    MessageBox.Show("Thêm khách hàng mới thành công !", "Thêm thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCusList.DataSource = bCus.getCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                cus.customerID = int.Parse(txtCusID.Text);
                bCus.editCustomer(cus);

                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;
                label2.Text = "";
                setOnOffEditTextbox(0);

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnNew.Enabled = true;

                MessageBox.Show("Cập nhập khách hàng thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCusList.DataSource = bCus.getCustomer();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!btnUpdate.Text.Equals("Hủy"))
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu sửa";
                btnSave.BackColor = Color.FromArgb(36, 187, 116);
                btnUpdate.Text = "Hủy";
                btnUpdate.BackColor = Color.FromArgb(231, 62, 52);
                label2.Text = "*Cập nhập thông tin khách hàng";
                setOnOffEditTextbox(1);

                btnSave.ForeColor = Color.White;
                btnUpdate.ForeColor = Color.White;
                btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;
                label2.Text = "";
                setOnOffEditTextbox(0);

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnNew.Enabled = true;
            }
        }

        //CHỨC NĂNG TÌM KIẾM
        void AutoComplete()
        {
            if (rdoCusName.Checked)
            {
                foreach (eCustomer x in bCus.getCustomer())
                {
                    txtFindInfo.AutoCompleteCustomSource.Add(x.customerName);
                }
            }
        }

        private void rdoCusName_CheckedChanged(object sender, EventArgs e)
        {
            txtFindInfo.AutoCompleteCustomSource.Clear();
            AutoComplete();
        }     

        private void btnFind_Click_1(object sender, EventArgs e)
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
                if (dgvCusList.SelectedRows.Count > 0)
                {
                    dgvCusList.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvCusList.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvCusList.CurrentCell = dgvCusList.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int search(string key)
        {
            if (rdoCusID.Checked)
            {
                string a = "";
                for (int i = 0; i < dgvCusList.Rows.Count; i++)
                {
                    a = dgvCusList.Rows[i].Cells[0].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else
            {
                string a = "";
                for (int i = 0; i < dgvCusList.Rows.Count; i++)
                {
                    a = dgvCusList.Rows[i].Cells[1].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            return -1;
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
