using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KS
{
    public partial class QL_KhachHang : UserControl
    {
        Customer ct = new Customer();
        public QL_KhachHang()
        {
            InitializeComponent();
        }
        void HienThiDSKH()
        {

            DataTable dt = ct.LayDSKH();
            lsvKH.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvKH.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            


            }
        }
        void setNull()
        {
            txtSearch.Text = "";
            txtPhone.Text = "";
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtMaKH.Focus();
        }
        private void QL_KhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSKH();
        }

        private void lsvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {

                btnThem.Enabled = false;
                btnSearch.Enabled = false;
                txtSearch.Enabled = false;
                txtMaKH.Enabled = false;
                txtMaKH.Text = lsvKH.SelectedItems[0].SubItems[0].Text;
                txtHoTen.Text = lsvKH.SelectedItems[0].SubItems[1].Text;
                txtPhone.Text = lsvKH.SelectedItems[0].SubItems[2].Text;
                txtDiaChi.Text = lsvKH.SelectedItems[0].SubItems[3].Text;
                txtEmail.Text = lsvKH.SelectedItems[0].SubItems[4].Text;
                LayDSHDTheoKH(lsvKH.SelectedItems[0].SubItems[0].Text);
            }
        }
        void TimKhachHang()
        {
            lsvKH.Items.Clear();
            DataTable dt = ct.LaySearchKH(txtSearch.Text);
            if (dt.Rows.Count == 0)
            {
                lblKhongTimThay.Visible = true;
            }
            else
            {
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    ListViewItem lvi = lsvKH.Items.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    lvi.SubItems.Add(dt.Rows[i][4].ToString());

                }
            }


        }
        void LayDSHDTheoKH(string s)
        {
            DataTable dt = ct.LayHDTheoKH(s);
            cbo_HD.DataSource = dt;
            cbo_HD.DisplayMember = "MAHD";
            cbo_HD.ValueMember = "MAHD";
            cbo_HD.SelectedIndex = -1;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXem.Enabled = false;
            if(txtSearch.Text != "")
            {
                TimKhachHang();
            }
            else
            {
                MessageBox.Show("Nhập mã khách hàng cần tìm");
            }
        }
        int checktrung()
        {
            int chk = 0;
            for (int i = 0; i<lsvKH.Items.Count; i++)
            {
                if (lsvKH.Items[i].SubItems[0].Text == txtMaKH.Text || lsvKH.Items[i].SubItems[1].Text == txtHoTen.Text)
                {
                    chk = 1;
                    break;
                }
            }
            return chk;
        }
        int checkrong()
        {
            int k = 0;
            if (txtMaKH.Text != ""&&txtHoTen.Text != "" && txtDiaChi.Text != ""&& txtPhone.Text !=""&&txtEmail.Text != "")
            {
                k =1;

            }
            return k;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(checkrong() == 1)
            {
                if(checktrung() ==0)
                {
                    ct.ThemKH(txtMaKH.Text, txtHoTen.Text, txtDiaChi.Text, txtPhone.Text, txtEmail.Text);
                    MessageBox.Show("Thêm mới Khách hàng '"+txtMaKH.Text+"' thành công");
                    HienThiDSKH();
                }
                else
                {
                    MessageBox.Show("Khách hàng đã tồn tại");
                    txtMaKH.Focus();
                }
            }    
            else
            {
                lblCB.Visible = true;
            }    
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lsvKH.SelectedIndices.Count >0)
            {
                ct.XoaKH(lsvKH.SelectedItems[0].SubItems[0].Text);
                lsvKH.Items.RemoveAt(lsvKH.SelectedIndices[0]);
                MessageBox.Show("Xóa khách hàng '"+txtMaKH.Text+"' thành công!");
                setNull();
            }    
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa");
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvKH.SelectedIndices.Count > 0)
            {

                ct.CapNhatKH(txtMaKH.Text, txtHoTen.Text,txtDiaChi.Text, txtPhone.Text, txtEmail.Text);
                MessageBox.Show("Cập nhật nhân viên '"+txtMaKH.Text+"' thành công");
                HienThiDSKH();
                setNull();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng muốn cập nhật");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setNull();
            txtMaKH.Enabled = true;
            btnSearch.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtSearch.Enabled = true;

        }
    }
}
