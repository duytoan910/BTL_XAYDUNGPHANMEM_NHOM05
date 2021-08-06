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
    public partial class frmDeleteCustomer : Form
    {
        CustomerBLL bCus;
        RentalBillBLL bRent;

        public frmDeleteCustomer()
        {
            InitializeComponent();
        }

        private void frmDeleteCustomer_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bCus = new CustomerBLL();
            bRent = new RentalBillBLL();

            txtFindInfo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFindInfo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            rdoCusID.Checked = true;

            //Load dữ liệu datagridview
            dgvCusList.DataSource = bCus.getCustomer();
            FormatDataGridview();
        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCusList.SelectedRows.Count > 0)
            {
                txtCusID.Text = dgvCusList.SelectedRows[0].Cells[0].Value.ToString();
                txtCusName.Text = dgvCusList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvCusList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvCusList.SelectedRows[0].Cells[3].Value.ToString();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            int cusID = int.Parse(dgvCusList.SelectedRows[0].Cells[0].Value.ToString());
            if(bRent.getRentalBillDetailByID(cusID).Count > 0)
            {
                MessageBox.Show("Không thể xóa khách hàng này, khách hàng này đang có đĩa cho thuê !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này ?",
                "Xóa KH", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bCus.deleteCustomer(int.Parse(txtCusID.Text));
                if (result == true)
                {
                    dgvCusList.DataSource = bCus.getCustomer();
                }
                else
                {
                    MessageBox.Show("Lỗi !");
                }
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
