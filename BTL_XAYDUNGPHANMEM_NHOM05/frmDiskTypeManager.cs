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
    public partial class frmDiskTypeManager : Form
    {
        DiskTypeBLL bDiskType;

        public frmDiskTypeManager()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void frmDiskTypeManager_Load(object sender, EventArgs e)
        {
            bDiskType = new DiskTypeBLL();

            btnSave.Enabled = false;
            rdoGameDisk.Checked = true;
            txtRentalCharge.ReadOnly = true;
            txtLateFee.ReadOnly = true;
            txtRentalPeriod.ReadOnly = true;

            LoadToTextBox();
        }

        void LoadToTextBox()
        {
            eDiskType x = new eDiskType();

            if(rdoGameDisk.Checked == true)
            {
                x = bDiskType.getGameType();
            }
            else 
            {
                x = bDiskType.getMovieType();
            }

            txtRentalCharge.Text = x.rentalCharge.ToString();
            txtLateFee.Text = x.lateFee.ToString();
            txtRentalPeriod.Text = x.rentalPeriod.ToString();
        }

        private void rdoGameDisk_CheckedChanged(object sender, EventArgs e)
        {
            LoadToTextBox();
        }

        private void rdoMovieDisk_CheckedChanged(object sender, EventArgs e)
        {
            LoadToTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!btnUpdate.Text.Equals("Hủy"))
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu sửa";
                btnUpdate.Text = "Hủy";

                txtRentalCharge.ReadOnly = false;
                txtLateFee.ReadOnly = false;
                txtRentalPeriod.ReadOnly = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnUpdate.Text = "Sửa";
                txtRentalCharge.ReadOnly = true;
                txtLateFee.ReadOnly = true;
                txtRentalPeriod.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRentalCharge.Text.Length == 0 || txtLateFee.Text.Length == 0 || txtRentalPeriod.Text.Length == 0)
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtLateFee.Text.CheckPositiveNumber() == false || txtRentalCharge.Text.CheckPositiveNumber() == false || txtRentalPeriod.Text.CheckPositiveNumber() == false)
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eDiskType x = new eDiskType();

            x.rentalCharge = double.Parse(txtRentalCharge.Text);
            x.lateFee = double.Parse(txtLateFee.Text);
            x.rentalPeriod = int.Parse(txtRentalPeriod.Text);

            if(rdoGameDisk.Checked)
            {
                x.diskTypeId = "GAMES";
                bDiskType.editDiskType(x);
            }
            else
            {
                x.diskTypeId = "MOVIES";
                bDiskType.editDiskType(x);
            }
            LoadToTextBox();
            btnSave.Enabled = false;
            btnSave.Text = "Lưu";
            btnUpdate.Text = "Sửa";
            txtRentalCharge.ReadOnly = true;
            txtLateFee.ReadOnly = true;
            txtRentalPeriod.ReadOnly = true;
            MessageBox.Show("Cập nhập thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
