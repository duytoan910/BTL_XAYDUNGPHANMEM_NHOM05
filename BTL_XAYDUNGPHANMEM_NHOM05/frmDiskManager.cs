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
    public partial class frmDiskManager : Form
    {
        DiskTitleBLL bDiskTitle;
        DiskBLL bDisk;
        ReservationBLL bRes;

        public frmDiskManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            bDiskTitle = new DiskTitleBLL();
            bDisk = new DiskBLL();
            bRes = new ReservationBLL();

            List<String> s = new List<String>();
            foreach (var d in bDiskTitle.getAllDiskTitle())
            {
                s.Add(d.diskTitleName);
            }
            cboDisk.DataSource = s;

            btnSave.Enabled = false;
            txtFindInfo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFindInfo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            rdoDiskTitleID.Checked = true;

            dgvDisk.DataSource = bDisk.getAllDiskForLoad();
            FormatDataGridview();
        }

        void FormatDataGridview()
        {
            dgvDisk.Columns[0].HeaderText = "Mã đĩa";
            dgvDisk.Columns[1].HeaderText = "Tên tựa đĩa";
            dgvDisk.Columns[1].Width = 450;
            dgvDisk.Columns[2].HeaderText = "Thể loại";
            dgvDisk.Columns[2].Width = 200;
            dgvDisk.Columns[3].HeaderText = "Ngày nhập";
            dgvDisk.Columns[3].Width = 200;
            dgvDisk.Columns[4].HeaderText = "Trạng thái";
            dgvDisk.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvTourList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDisk.SelectedRows.Count > 0)
            {
                txtDiskID.Text = dgvDisk.SelectedRows[0].Cells[0].Value.ToString();
                cboDisk.Text = dgvDisk.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        void clearTextbox()
        {
            txtDiskID.Text = "";
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
            eDisk d = new eDisk();

            //d.diskTitleId = int.Parse(txtDiskTitleID.Text);
            d.DiskTitle = new eDiskTitle();
            d.DiskTitle.diskTitleName = cboDisk.Text;
            d.dateAdd = DateTime.Now;
            d.status = "Trên kệ";

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    eDisk result = bDisk.addDisk(d);
                    if (result != null)
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

                        //Kiểm tra tựa đĩa vừa thêm có ai đặt hay không -> nếu có thì hold cho khách hàng đó
                        bool resultHold = bRes.setOnHold(result.DiskTitle.diskTitleName, result.diskId);

                        if (resultHold)
                        {
                            bDisk.setStatus(result.diskId, "Đang chờ");
                        }

                        MessageBox.Show("Thêm đĩa mới thành công !", "Thêm đĩa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDisk.DataSource = bDisk.getAllDiskForLoad();
                    }
                    else
                        MessageBox.Show("Mã đĩa bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                d.diskId = int.Parse(txtDiskID.Text);
                bDisk.editDisk(d);

                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

                MessageBox.Show("Cập nhập đĩa thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDisk.DataSource = bDisk.getAllDiskForLoad();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string status = dgvDisk.SelectedRows[0].Cells[4].Value.ToString();
            if(status == "Cho thuê" || status == "Đang chờ")
            {
                MessageBox.Show("Không thể xóa đĩa đang cho thuê hoặc đang chờ !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa đĩa này ?",
                "Xóa tựa đĩa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bDisk.deleteDisk(int.Parse(txtDiskID.Text));
                if (result == true)
                {
                    MessageBox.Show("Xóa đĩa thành công !");
                    dgvDisk.DataSource = bDisk.getAllDiskForLoad();
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
                foreach (eDisk d in bDisk.getAllDisk())
                {
                    txtFindInfo.AutoCompleteCustomSource.Add(d.diskId.ToString());
                }
            }
            else
            {
                foreach (eDiskTitle d in bDiskTitle.getAllDiskTitle())
                {
                    txtFindInfo.AutoCompleteCustomSource.Add(d.diskTitleName);
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
                if (dgvDisk.SelectedRows.Count > 0)
                {
                    dgvDisk.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvDisk.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvDisk.CurrentCell = dgvDisk.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
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
                for (int i = 0; i < dgvDisk.Rows.Count; i++)
                {
                    a = dgvDisk.Rows[i].Cells[0].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else
            {
                string a = "";
                for (int i = 0; i < dgvDisk.Rows.Count; i++)
                {
                    a = dgvDisk.Rows[i].Cells[1].Value.ToString();
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
            foreach (DataGridViewRow Myrow in dgvDisk.Rows)
            {   
                //Chỉnh cột 3        
                if (Myrow.Cells[2].Value.Equals("Đĩa phim"))
                {
                    Myrow.Cells[2].Style.ForeColor = Color.Green;
                }
                else
                {
                    Myrow.Cells[2].Style.ForeColor = Color.Blue;
                }

                //Chỉnh cột 5
                if (Myrow.Cells[4].Value.Equals("Trên kệ"))
                {
                    Myrow.Cells[4].Style.ForeColor = Color.Blue;
                }
                else if(Myrow.Cells[4].Value.Equals("Đang chờ"))
                {
                    Myrow.Cells[4].Style.ForeColor = Color.Red;
                }
                else
                {
                    Myrow.Cells[4].Style.ForeColor = Color.Green;
                }
            }
        }

        private void rdoDiskTitleID_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
