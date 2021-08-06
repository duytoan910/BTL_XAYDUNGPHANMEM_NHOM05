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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string pass = txtPass.Text;

            if (id == "admin" && pass == "123")
            {
                this.Hide();
                DialogResult = DialogResult.OK;
            }
            //Kiểm tra dữ liệu nhập
            else if (id == "" || pass == "")
            {
                MessageBox.Show("Dữ liệu không được bỏ trống !", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng !", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
