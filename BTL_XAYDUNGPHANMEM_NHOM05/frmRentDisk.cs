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
using Entities;

namespace BTL_XAYDUNGPHANMEM_NHOM05
{
    public partial class frmRentDisk : Form
    {
        DiskTitleBLL bDiskTitle;
        DiskBLL bDisk;
        CustomerBLL bCus;
        RentalBillBLL bRent;
        LateChargeBLL bCharge;
        ReservationBLL bRe;

        public frmRentDisk()
        {
            InitializeComponent();
        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            bDiskTitle = new DiskTitleBLL();
            bDisk = new DiskBLL();
            bCus = new CustomerBLL();
            bRent = new RentalBillBLL();
            bCharge = new LateChargeBLL();
            bRe = new ReservationBLL();

            dgvDisk.DataSource = bDisk.getAllDiskForLoadOnShelf();
            FormatDataGridview();
            InsertColumnsListView();

            btnPay.Enabled = false;
            txtTotal.Text = "0";

            UpdateCusChange();
        }

        void UpdateCusChange()
        {
            btnOnHoldDisk.Text = "Đĩa đặt trước";
            btnLateCharge.Enabled = false;
            btnOnHoldDisk.Enabled = false;
            lblNotify.Text = "";
            label10.Text = "";

            dgvDisk.DataSource = bDisk.getAllDiskForLoadOnShelf();
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
            dgvDisk.Columns[5].HeaderText = "Phí thuê";
            dgvDisk.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDisk.Columns[6].Visible = false;
        }

        void InsertColumnsListView()
        {
            this.listViewDisk.Columns.Add("Mã đĩa", 100);
            this.listViewDisk.Columns.Add("Tựa đĩa", 350);
            this.listViewDisk.Columns.Add("Loại đĩa", 150);
            this.listViewDisk.Columns.Add("Phí thuê", 150);
            this.listViewDisk.Columns.Add("Hạn thuê", 0);


            this.listViewDisk.View = View.Details;
            this.listViewDisk.GridLines = true;
            this.listViewDisk.FullRowSelect = true;
        }

        private void dgvTourList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dgvDisk.SelectedRows.Count > 0)
            //{
            //    txtDiskID.Text = dgvDisk.SelectedRows[0].Cells[0].Value.ToString();
            //    cboDisk.Text = dgvDisk.SelectedRows[0].Cells[1].Value.ToString();
            //}
        }   

        //CHỨC NĂNG TÌM KIẾM
        //Tìm kiếm Auto Complete      
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
            string a = "";
            for (int i = 0; i < dgvDisk.Rows.Count; i++)
            {
                a = dgvDisk.Rows[i].Cells[0].Value.ToString();
                if (a.Equals(key))
                    return i;
            }           
            return -1;
        }

        private void btnFindCus_Click(object sender, EventArgs e)
        {
            UpdateCusChange();

            eCustomer c = bCus.findCustomer(int.Parse(txtIDCusFind.Text));

            if(c!=null)
            {
                txtIDCus.Text = c.customerID.ToString();
                txtName.Text = c.customerName;
                txtAddress.Text = c.customerAddress;
                txtPhone.Text = c.customerPhone;

                //Thông báo có phí trễ hạn chưa thanh toán
                TurnOnOffPayButton();
                if (bCharge.getLateChargeByIDCus(int.Parse(c.customerID.ToString())).Count != 0)
                {
                    btnLateCharge.Enabled = true;
                    lblNotify.Text = "( *Khách hàng có phí trễ hạn chưa thanh toán )";
                }

                if(bRe.getDiskOnHod(int.Parse(txtIDCusFind.Text)).Count > 0)
                {
                    btnOnHoldDisk.Enabled = true;
                    label10.Text = "( *Có đĩa đang chờ của khách hàng đặt trước)";
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       //XỬ LÝ CÁC NÚT TRONG FORM
        private void btnChooseDisk_Click(object sender, EventArgs e)
        {
            string id = dgvDisk.SelectedRows[0].Cells[0].Value.ToString();

            //Kiểm tra list view đã tồn tại đĩa đã chọn hay không
            for (int i = 0; i < listViewDisk.Items.Count; i++)
            {
                string diskIDLv =listViewDisk.Items[i].SubItems[0].Text;
                if (id == diskIDLv)
                {
                    MessageBox.Show("Đĩa này đã được chọn, vui lòng chọn đĩa khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } 
            
            string name = dgvDisk.SelectedRows[0].Cells[1].Value.ToString();
            string type = dgvDisk.SelectedRows[0].Cells[2].Value.ToString();
            string charge = dgvDisk.SelectedRows[0].Cells[5].Value.ToString();
            string rentalPeriod = dgvDisk.SelectedRows[0].Cells[6].Value.ToString();

            ListViewItem lvi;
            lvi = new ListViewItem(new string[] { id, name, type, charge, rentalPeriod });
            this.listViewDisk.Items.Add(lvi);
            sumMoney();
            TurnOnOffPayButton();
        }

        private void btnLateCharge_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDCus.Text);
            frmIndicateLateCharge nForm = new frmIndicateLateCharge(id);
            nForm.Show();
        }

        //Tính tổng tiền
        void sumMoney()
        {
            double tongtien = 0;
            for (int i = 0; i < listViewDisk.Items.Count; i++)
            {
                tongtien += double.Parse(listViewDisk.Items[i].SubItems[3].Text);
            }
            txtTotal.Text = string.Format("{0:#,##}", Convert.ToDecimal(tongtien.ToString()));
        }

        //Kích hoạt nút thanh toán
        void TurnOnOffPayButton()
        {
            if (listViewDisk.Items.Count > 0 && txtIDCus.Text != "")
            {
                btnPay.Enabled = true;
            }
            else btnPay.Enabled = false;

        }

        private void btnDeleteDisk_Click(object sender, EventArgs e)
        {
            if (this.listViewDisk.SelectedItems.Count > 0)
            {
                foreach (ListViewItem eachItem in listViewDisk.SelectedItems)
                {
                    listViewDisk.Items.Remove(eachItem); //Xóa item khỏi list view
                }

            }
            sumMoney(); // Tính lại thành tiền
            TurnOnOffPayButton();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            listViewDisk.Clear();
            InsertColumnsListView();
            sumMoney();
            TurnOnOffPayButton();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {          
            DialogResult dialogResult = MessageBox.Show("Xác nhận thanh toán ?", "Thanh toán", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                eRentalBill rent = new eRentalBill();

                //Thêm chi tiết vào hóa đơn đã tạo
                for (int i = 0; i < listViewDisk.Items.Count; i++)
                {
                    int diskID = int.Parse(listViewDisk.Items[i].SubItems[0].Text);
                    int rentalPeriod = int.Parse(listViewDisk.Items[i].SubItems[4].Text);

                    //Lập phiếu thuê cho từng đĩa
                    rent.diskId = diskID;
                    rent.customerID = int.Parse(txtIDCus.Text);
                    rent.hireDate = DateTime.Now;
                    rent.paymentTerm = DateTime.Now.AddDays(rentalPeriod); // Cộng thêm ngày cho thuê
                    rent.payDate = DateTime.Now;

                    bRent.addRentalBill(rent);

                    //Kiểm tra nếu có đĩa on hold thì xóa khách trong hàng đợi
                    if(bDisk.checkStatus(diskID,"Đang chờ"))
                    {
                        bRe.deleteReservationByDiskID(diskID);
                    }

                    //Cập nhập trạng thái cho từng đĩa
                    bDisk.setStatus(diskID, "Cho thuê");
                    dgvDisk.DataSource = bDisk.getAllDiskForLoadOnShelf();
                }
                btnOnHoldDisk.Text = "Đĩa đặt trước";
                btnOnHoldDisk.Enabled = false;
                label10.Text = "";
                if (bRe.getDiskOnHod(int.Parse(txtIDCusFind.Text)).Count > 0)
                {
                    btnOnHoldDisk.Enabled = true;
                    label10.Text = "( *Có đĩa đang chờ của khách hàng đặt trước)";
                }
                listViewDisk.Clear();
                InsertColumnsListView();
                txtTotal.Text = "0";
                MessageBox.Show("Phiếu thuê tạo thành công", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOnHoldDisk_Click(object sender, EventArgs e)
        {
            if(btnOnHoldDisk.Text == "Đĩa đặt trước")
            {
                this.dgvDisk.DataSource = null;
                dgvDisk.Rows.Clear();
                dgvDisk.Columns.Clear();

                dgvDisk.DataSource = bRe.getDiskOnHod(int.Parse(txtIDCusFind.Text));
                FormatDataGridview();

                btnOnHoldDisk.Text = "Trở lại";
            }
            else
            {
                this.dgvDisk.DataSource = null;
                dgvDisk.Rows.Clear();
                dgvDisk.Columns.Clear();

                dgvDisk.DataSource = bDisk.getAllDiskForLoadOnShelf();
                FormatDataGridview();

                btnOnHoldDisk.Text = "Đĩa đặt trước";
            }
        }

        //Chỉnh màu cho cột trong datagridview
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
                else if (Myrow.Cells[4].Value.Equals("Đang chờ"))
                {
                    Myrow.Cells[4].Style.ForeColor = Color.Red;
                }
                else
                {
                    Myrow.Cells[4].Style.ForeColor = Color.Green;
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

    }
}
