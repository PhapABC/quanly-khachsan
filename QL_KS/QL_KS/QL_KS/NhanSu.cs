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
    public partial class NhanSu : UserControl
    {
        NhanVien nv = new NhanVien();
        public NhanSu()
        {
            InitializeComponent();
        }
        void HienThiDSNS()
        {

            DataTable dt = nv.LayDSNV();
            lsvNhanVien1.Items.Clear();
            for(int i=0;i< dt.Rows.Count;i++)
            {
                ListViewItem lvi = lsvNhanVien1.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(String.Format("{0:dd/MM/yyyy}",dt.Rows[i][2].ToString()));
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(dt.Rows[i][7].ToString());
                lvi.SubItems.Add(dt.Rows[i][8].ToString());


            }    
        }
        void LayDSQuyen()
        {
            DataTable dt = nv.LayDSQuyen();
            cbo_Role.DataSource = dt;
            cbo_Role.DisplayMember = "TENQUYEN";
            cbo_Role.ValueMember = "ID";
            cbo_Role.SelectedIndex = -1;
                
        }
        private void NhanSu_Load(object sender, EventArgs e)
        {
            cbo_Gender.Items.Clear();
            cbo_Gender.Items.Add("Nam");
            cbo_Gender.Items.Add("Nữ");
            cbo_Gender.SelectedIndex = -1;
            LayDSQuyen();
            HienThiDSNS();

        }

        private void lsvNhanVien1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsvNhanVien1.SelectedIndices.Count > 0)
            {
                txtMaNV.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                txtMaNV.Text = lsvNhanVien1.SelectedItems[0].SubItems[0].Text;
                txtHoTen.Text = lsvNhanVien1.SelectedItems[0].SubItems[1].Text;
                dtNgaySinh.Value =DateTime.Parse(lsvNhanVien1.SelectedItems[0].SubItems[2].Text);
                cbo_Role.SelectedIndex = cbo_Role.FindString(lsvNhanVien1.SelectedItems[0].SubItems[8].Text);
                cbo_Gender.SelectedIndex = cbo_Gender.FindString(lsvNhanVien1.SelectedItems[0].SubItems[5].Text);
                txtUserName.Text = lsvNhanVien1.SelectedItems[0].SubItems[6].Text;
                txtPass.Text = lsvNhanVien1.SelectedItems[0].SubItems[7].Text;
                txtDiaChi.Text = lsvNhanVien1.SelectedItems[0].SubItems[4].Text;
                txtPhone.Text = lsvNhanVien1.SelectedItems[0].SubItems[3].Text;
                
            }    
        }
        void setNull()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dtNgaySinh.ResetText();
            txtPass.Text = "";
            txtPhone.Text = "";
            txtUserName.Text = "";
            txtSearch.Text = "";
            cbo_Gender.SelectedIndex = -1;
            cbo_Role.SelectedIndex = -1;
        }
        int checktrung()
        {
            int chk = 0;
            for(int i =0;i<lsvNhanVien1.Items.Count;i++)
            {
                if(lsvNhanVien1.Items[i].SubItems[0].Text == txtMaNV.Text || lsvNhanVien1.Items[i].SubItems[1].Text == txtHoTen.Text)
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
            if (txtMaNV.Text != ""&&txtHoTen.Text != "" && txtDiaChi.Text != ""&& txtPhone.Text !=""&&txtUserName.Text!= ""&&txtPass.Text !=""&&cbo_Gender.SelectedIndex != -1&& cbo_Role.SelectedIndex != -1)
                {
                k =1;

                 }
            return k;

        }
        
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(checkrong()==1)
            {
                if(checktrung() == 0)
                {
                   
                    nv.ThemNV(txtMaNV.Text, txtHoTen.Text, dtNgaySinh.Value.ToShortDateString(), txtDiaChi.Text,cbo_Gender.Text, txtPhone.Text, txtUserName.Text, txtPass.Text, cbo_Role.SelectedValue.ToString());
                    MessageBox.Show("Thêm mới nhân viên '"+txtMaNV.Text+"' thành công!");
                    setNull();
                    HienThiDSNS();
                }  
                else
                {
                    MessageBox.Show("Nhân viên đã tồn tại");
                    txtMaNV.Focus();
                }    
                
            }
            else
            {
                lblCB.Visible = true;

            }    
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lsvNhanVien1.SelectedIndices.Count > 0)
            {
                nv.XoaNV(lsvNhanVien1.SelectedItems[0].SubItems[0].Text);
                lsvNhanVien1.Items.RemoveAt(lsvNhanVien1.SelectedIndices[0]);
                MessageBox.Show("Xóa nhân viên '"+txtMaNV.Text+"' thành công!");
                setNull();
            }  
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa");
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setNull();
            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            lblKhongTimThay.Visible = false;
            HienThiDSNS();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(lsvNhanVien1.SelectedIndices.Count > 0)
            {
               
                nv.CapNhatNV(txtMaNV.Text, txtHoTen.Text, dtNgaySinh.Value.ToShortDateString(), txtDiaChi.Text,cbo_Gender.Text, txtPhone.Text, txtUserName.Text, txtPass.Text, cbo_Role.SelectedValue.ToString());
                MessageBox.Show("Cập nhật nhân viên '"+txtMaNV.Text+"' thành công");
                HienThiDSNS();
                setNull();
            }    
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn cập nhật");
            }    
        }
        void TimNhanVien()
        {
            lsvNhanVien1.Items.Clear();
            DataTable dt = nv.LaySearchNV(txtSearch.Text);
            if(dt.Rows.Count == 0)
            {
                lblKhongTimThay.Visible = true;
            }
            else
            {
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    ListViewItem lvi = lsvNhanVien1.Items.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(String.Format("{0:dd/MM/yyyy}", dt.Rows[i][2].ToString()));
                    lvi.SubItems.Add(dt.Rows[i][5].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    lvi.SubItems.Add(dt.Rows[i][4].ToString());
                    lvi.SubItems.Add(dt.Rows[i][6].ToString());
                    lvi.SubItems.Add(dt.Rows[i][7].ToString());
                    lvi.SubItems.Add(dt.Rows[i][8].ToString());
                }
            }
              

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            if(txtSearch.Text != "")
            {
                TimNhanVien();
            }   
            else
            {
                MessageBox.Show("Nhập mã nhân viên cần tìm");
            }    
        }
    }
}
