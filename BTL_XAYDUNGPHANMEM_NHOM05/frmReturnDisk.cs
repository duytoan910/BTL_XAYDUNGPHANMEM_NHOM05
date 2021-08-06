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
    public partial class frmReturnDisk : Form
    {
        DiskBLL bDisk;
        RentalBillBLL bRent;
        LateChargeBLL bCharge;
        ReservationBLL bRes;

        public frmReturnDisk()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bDisk = new DiskBLL();
            bRent = new RentalBillBLL();
            bCharge = new LateChargeBLL();
            bRes = new ReservationBLL();

            dgvDisk.DataSource = bRent.getRentalBillDetail();
            FormatDataGridview();
            InsertColumnsListView();

            btnPay.Enabled = false;
        }

        void FormatDataGridview()
        {
            dgvDisk.Columns[0].HeaderText = "Mã đĩa";
            dgvDisk.Columns[1].HeaderText = "Tên tựa đĩa";
            dgvDisk.Columns[1].Width = 400;
            dgvDisk.Columns[2].HeaderText = "Trạng thái";
            dgvDisk.Columns[2].Width = 150;
            dgvDisk.Columns[3].HeaderText = "Khách hàng thuê";
            dgvDisk.Columns[3].Width = 150;
            dgvDisk.Columns[4].HeaderText = "Ngày thuê";
            dgvDisk.Columns[4].Width = 150;
            dgvDisk.Columns[5].HeaderText = "Hạn thuê";
            dgvDisk.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDisk.Columns[6].Visible = false;
            dgvDisk.Columns[7].Visible = false;
        }

        void InsertColumnsListView()
        {
            this.listViewDisk.Columns.Add("Mã đĩa", 100);
            this.listViewDisk.Columns.Add("Tựa đĩa", 400);
            this.listViewDisk.Columns.Add("Trạng thái", 150);
            this.listViewDisk.Columns.Add("Khách hàng thuê", 200);
            this.listViewDisk.Columns.Add("Ngày thuê", 200);
            this.listViewDisk.Columns.Add("Hạn thuê", 200);
            this.listViewDisk.Columns.Add("ID Bill", 0);
            this.listViewDisk.Columns.Add("Charge", 0);

            this.listViewDisk.View = View.Details;
            this.listViewDisk.GridLines = true;
            this.listViewDisk.FullRowSelect = true;
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

        //XỬ LÝ CÁC NÚT TRONG FORM
        private void btnChooseDisk_Click(object sender, EventArgs e)
        {
            string id = dgvDisk.SelectedRows[0].Cells[0].Value.ToString();

            //Kiểm tra list view đã tồn tại đĩa đã chọn hay không
            for (int i = 0; i < listViewDisk.Items.Count; i++)
            {
                string diskIDLv = listViewDisk.Items[i].SubItems[0].Text;
                if (id == diskIDLv)
                {
                    MessageBox.Show("Đĩa này đã được chọn, vui lòng chọn đĩa khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string name = dgvDisk.SelectedRows[0].Cells[1].Value.ToString();
            string status = dgvDisk.SelectedRows[0].Cells[2].Value.ToString();
            string customerHire = dgvDisk.SelectedRows[0].Cells[3].Value.ToString();
            string hireDate = dgvDisk.SelectedRows[0].Cells[4].Value.ToString();
            string paymentTerm = dgvDisk.SelectedRows[0].Cells[5].Value.ToString();
            string billID = dgvDisk.SelectedRows[0].Cells[6].Value.ToString();
            string charge = dgvDisk.SelectedRows[0].Cells[7].Value.ToString();

            ListViewItem lvi;
            lvi = new ListViewItem(new string[] { id, name, status, customerHire, hireDate, paymentTerm, billID, charge });
            this.listViewDisk.Items.Add(lvi);
            TurnOnOffPayButton();
        }

        //Kích hoạt nút thanh toán
        void TurnOnOffPayButton()
        {
            if (listViewDisk.Items.Count > 0)
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
            TurnOnOffPayButton();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            listViewDisk.Clear();
            InsertColumnsListView();
            TurnOnOffPayButton();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xác nhận trả đĩa ?", "Trả đĩa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < listViewDisk.Items.Count; i++)
                {
                    string title = listViewDisk.Items[i].SubItems[1].Text;
                    int diskID = int.Parse(listViewDisk.Items[i].SubItems[0].Text);
                    int billID = int.Parse(listViewDisk.Items[i].SubItems[6].Text);
                    double charge = double.Parse(listViewDisk.Items[i].SubItems[7].Text);
                    DateTime paymentTerm = DateTime.Parse(listViewDisk.Items[i].SubItems[5].Text);

                    bool resultHold = bRes.setOnHold(title, diskID);

                    if (resultHold)
                    {
                        bDisk.setStatus(diskID, "Đang chờ");
                    }
                    else
                    {
                        bDisk.setStatus(diskID, "Trên kệ");
                    }

                    //Set ngày trả đĩa
                    bRent.setPayDate(billID);
                    dgvDisk.DataSource = bRent.getRentalBillDetail();

                    //Cập nhập phí trễ 
                    int result = DateTime.Compare(paymentTerm, DateTime.Now);//So sánh hạn trễ với ngày trễ
                    if (result < 0)
                    {
                        eLateCharge x = new eLateCharge();
                        x.lateFee = charge;
                        x.status = false;
                        x.rentalBillId = billID;

                        bCharge.addLateCharge(x);
                    }
                }

                listViewDisk.Clear();
                InsertColumnsListView();
                MessageBox.Show("Hoàn tất trả đĩa", "Trả đĩa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Chỉnh màu cho cột trong datagridview
        private void dgvDiskTitle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvDisk.Rows)
            {
                Myrow.Cells[2].Style.ForeColor = Color.Red;
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
        private void dgvTourList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dgvDisk.SelectedRows.Count > 0)
            //{
            //    txtDiskID.Text = dgvDisk.SelectedRows[0].Cells[0].Value.ToString();
            //    cboDisk.Text = dgvDisk.SelectedRows[0].Cells[1].Value.ToString();
            //}
        }
    }
}
