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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            LoadForClerk();
        }

        void LoadForClerk()
        {
            đăngNhậpQuảnTrịToolStripMenuItem.Text = "Đăng nhập";
            danhMụcToolStripMenuItem.Enabled = false;
            xóaPhíTrễToolStripMenuItem.Enabled = false;
            xóaKháchHàngMToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Visible = false;
            báoCáoKháchHàngToolStripMenuItem.Visible = false;
        }

        void LoadForManager()
        {
            đăngNhậpQuảnTrịToolStripMenuItem.Text = "Đăng nhập: Manager";
            danhMụcToolStripMenuItem.Enabled = true;
            xóaPhíTrễToolStripMenuItem.Enabled = true;
            xóaKháchHàngMToolStripMenuItem.Enabled = true;
            đăngXuấtToolStripMenuItem.Visible = true;
            báoCáoKháchHàngToolStripMenuItem.Visible = true;
        }
    
        private void đăngNhậpQuảnTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (đăngNhậpQuảnTrịToolStripMenuItem.Text == "Đăng nhập: Manager")
                return;
            using (frmLogin form2 = new frmLogin())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    LoadForManager();
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new frmMenu();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void tựaĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "QUẢN LÝ TỰA ĐĨA";
            frmDiskTitleManager frm = new frmDiskTitleManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void đĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "QUẢN LÝ ĐĨA";
            frmDiskManager frm = new frmDiskManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void thuêĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "LẬP PHIẾU THUÊ";
            frmRentDisk frm = new frmRentDisk();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void trảĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG TRẢ ĐĨA";
            frmReturnDisk frm = new frmReturnDisk();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void đặtChỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG ĐẶT TRƯỚC";
            frmReservation frm = new frmReservation();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void thanhToánPhíTrễToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG THANH TOÁN";
            frmPaymentLateCharge frm = new frmPaymentLateCharge();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void xóaPhíTrễToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG XÓA PHÍ TRỄ HẠN";
            frmDeleteLateCharge frm = new frmDeleteLateCharge();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void thêmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "THÊM KHÁCH HÀNG";
            frmCustomerManager frm = new frmCustomerManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void xóaKháchHàngMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "XÓA KHÁCH HÀNG";
            frmDeleteCustomer frm = new frmDeleteCustomer();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void loạiĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "QUẢN LÝ LOẠI ĐĨA";
            frmDiskTypeManager frm = new frmDiskTypeManager();
            frm.Show();
        }

        private void báoCáoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "BÁO CÁO KHÁCH HÀNG";
            frmCustomerReport frm = new frmCustomerReport();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
