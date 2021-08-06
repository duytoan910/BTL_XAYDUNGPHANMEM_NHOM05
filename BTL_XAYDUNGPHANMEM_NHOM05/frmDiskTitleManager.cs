using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entities;

namespace BTL_XAYDUNGPHANMEM_NHOM05
{
    public partial class frmDiskTitleManager : Form
    {
        DiskTitleBLL bDiskTitle;

        public frmDiskTitleManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> s = new List<String>() { "Đĩa game", "Đĩa phim"};
            cboDiskType.DataSource = s;

            bDiskTitle = new DiskTitleBLL();

            btnSave.Enabled = false;
            txtFindInfo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFindInfo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            rdoDiskTitleID.Checked = true;

            dgvDiskTitle.DataSource = bDiskTitle.getAllDiskTitleForLoad();
            FormatDataGridview();
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

        private void dgvTourList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDiskTitle.SelectedRows.Count > 0)
            {
                txtDiskTitleID.Text = dgvDiskTitle.SelectedRows[0].Cells[0].Value.ToString();
                txtDiskTitleName.Text = dgvDiskTitle.SelectedRows[0].Cells[1].Value.ToString();
                cboDiskType.Text = dgvDiskTitle.SelectedRows[0].Cells[2].Value.ToString();

                //THÔNG KÊ
                int id = int.Parse(dgvDiskTitle.SelectedRows[0].Cells[0].Value.ToString());
                lblDisk.Text = bDiskTitle.CountDisk(id).ToString();
                lblOnself.Text = bDiskTitle.CountInstock(id).ToString();
                lblOnRent.Text = bDiskTitle.CountRent(id).ToString();
                lblOnHold.Text = bDiskTitle.CountOnHold(id).ToString();
                lblReser.Text = bDiskTitle.CountReservation(id).ToString();
            }
        }

        void clearTextbox()
        {
            txtDiskTitleID.Text = "";
            txtDiskTitleName.Text = "";
            txtFindInfo.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearTextbox();
            if (!btnAdd.Text.Equals("Hủy"))
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu thêm";
                btnSave.BackColor = Color.FromArgb(36, 187, 116);
                btnAdd.Text = "Hủy";
                btnAdd.BackColor = Color.FromArgb(231, 62, 52);

                btnSave.ForeColor = Color.White;
                btnAdd.ForeColor = Color.White;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnAdd.Text = "Thêm";
                btnAdd.BackColor = Color.Gainsboro;
                label2.Text = "";

                btnSave.ForeColor = Color.Black;
                btnAdd.ForeColor = Color.Black;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
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

                btnSave.ForeColor = Color.White;
                btnUpdate.ForeColor = Color.White;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDiskTitleName.Text.Length == 0)
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bDiskTitle.checkTitleIfExist(txtDiskTitleName.Text))
            {
                MessageBox.Show("Tựa đề này đã có vui lòng nhập tựa khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            eDiskTitle d = new eDiskTitle();

            //d.diskTitleId = int.Parse(txtDiskTitleID.Text);
            d.diskTitleName = txtDiskTitleName.Text;
            d.DiskType = new eDiskType();
            d.DiskType.diskName = cboDiskType.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    bool result = bDiskTitle.addDiskTitle(d);
                    if (result == true)
                    {
                        clearTextbox();

                        btnSave.Enabled = false;
                        btnSave.Text = "Lưu";
                        btnSave.BackColor = Color.Gainsboro;
                        btnAdd.Text = "Thêm";
                        btnAdd.BackColor = Color.Gainsboro;

                        btnSave.ForeColor = Color.Black;
                        btnAdd.ForeColor = Color.Black;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;

                        MessageBox.Show("Thêm tựa đĩa mới thành công !", "Thêm tựa đĩa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDiskTitle.DataSource = bDiskTitle.getAllDiskTitleForLoad();
                    }
                    else
                        MessageBox.Show("Mã tựa đĩa bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                d.diskTitleId = int.Parse(txtDiskTitleID.Text);
                bDiskTitle.editDiskTitle(d);

                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

                MessageBox.Show("Cập nhập tựa đĩa thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDiskTitle.DataSource = bDiskTitle.getAllDiskTitleForLoad();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int TotalDisk = int.Parse(lblDisk.Text);
            if(TotalDisk > 0)
            {
                MessageBox.Show("Không thể xóa tựa này, đang có đĩa bản sao xài tựa này !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa tựa đĩa này ?",
                "Xóa tựa đĩa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bDiskTitle.deleteDiskTitle(int.Parse(txtDiskTitleID.Text));
                if (result == true)
                {
                    MessageBox.Show("Xóa tựa đĩa thành công !");
                    dgvDiskTitle.DataSource = bDiskTitle.getAllDiskTitleForLoad();
                }
                else
                {
                    MessageBox.Show("Lỗi !");
                }
            }
        }

        //CHỨC NĂNG TÌM KIẾM
        //Tìm kiếm Auto Complete
        void AutoComplete()
        {
            if (rdoDiskTitleID.Checked)
            {
                foreach (eDiskTitle tour in bDiskTitle.getAllDiskTitle())
                {
                    txtFindInfo.AutoCompleteCustomSource.Add(tour.diskTitleId.ToString());
                }
            }
            else
            {
                foreach (eDiskTitle tour in bDiskTitle.getAllDiskTitle())
                {
                    txtFindInfo.AutoCompleteCustomSource.Add(tour.diskTitleName);
                }
            }
        }

        private void rdoTourID_CheckedChanged(object sender, EventArgs e)
        {
            txtFindInfo.AutoCompleteCustomSource.Clear();
            AutoComplete();
        }

        private void rdoTourName_CheckedChanged(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvTourList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string tourID = dgvTourList.SelectedRows[0].Cells[0].Value.ToString();
            //frmContractDetail frm = new frmContractDetail(tourID);
            //frm.Show();
        }

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

        private void rdoDiskTitleID_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
