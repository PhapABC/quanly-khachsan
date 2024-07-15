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
    public partial class QL_PhongDV : UserControl
    {
        Rooms r = new Rooms();
        DichVu dv = new DichVu();

        public QL_PhongDV()
        {
            InitializeComponent();
        }
        //Hiển thị danh sách phòng
        void HienThiDSPH()
        {

            DataTable dt = r.LayDSPH();
            lsvRoom.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvRoom.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());

            }
        }
        //Hiển thị danh sách dịch vụ
        void HienThiDSDV()
        {

            DataTable dt = dv.LayDSDV();
            lsvDV.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvDV.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());

            }
        }
        //Hàm tìm phòng khi truyền vào mã phòng
        void SearchRoom()
        {

            DataTable dt = r.LaySearchPH(txtSearchRoom.Text);
            lsvRoom.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvRoom.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        //Hàm tìm dịch vụ khi truyền vào mã dịch vụ
        void SearchDV()
        {

            DataTable dt = dv.LaySearchDV(txtSearchDV.Text);
            lsvDV.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvDV.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }
        //Hiển thị dữ liệu khi Load
        private void QL_PhongDV_Load(object sender, EventArgs e)
        {
            HienThiDSPH();
            HienThiDSDV();
            txtTrangThai.Enabled = false;
        }
        //Hiện thông tin lên các textbox khi chọn vào một row trong ListView Phòng
        private void lsvRoom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(lsvRoom.SelectedIndices.Count > 0)
            {   
                //Ẩn mã phòng
                txtMaPH.Enabled = false;
                //Ẩn trạng thái phòng
                txtTrangThai.ReadOnly = false;
                //Lấy thông tin từ row lên textbox
                txtMaPH.Text = lsvRoom.SelectedItems[0].SubItems[0].Text;
                txtTenPH.Text = lsvRoom.SelectedItems[0].SubItems[1].Text;
                txtDonGia.Text = lsvRoom.SelectedItems[0].SubItems[2].Text;
                txtTrangThai.Text = lsvRoom.SelectedItems[0].SubItems[3].Text;
                //Ẩn button thêm phòng mới
                btnThemRoom.Enabled = false;
            }
        }
        //Hiện thông tin lên các textbox khi chọn vào một row trong ListView Dịch vụ
        private void lsvDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDV.SelectedIndices.Count > 0)
            {
                //Ân mã dịch vụ
                txtMaDV.Enabled = false;
                //Lấy thông tin từ row lên textbox
                txtMaDV.Text = lsvDV.SelectedItems[0].SubItems[0].Text;
                txtTenDV.Text = lsvDV.SelectedItems[0].SubItems[1].Text;
                txtDG.Text = lsvDV.SelectedItems[0].SubItems[2].Text;
                //ẩn button Thêm dịch vụ
                btnThemDV.Enabled = false;
            }
        }
    

        private void btnTimDV_Click(object sender, EventArgs e)
        {
            //Ẩn các button Thêm,Xóa,Sửa
            btnThemDV.Enabled = false;
            btnSuaDV.Enabled = false;
            btnXoaDV.Enabled = false;
            //Nếu textbox Search không rỗng
            if (txtSearchDV.Text != "")
            {
               // Hiển thị thông tin tìm được lên ListView Dịch Vụ
                SearchDV();

            }
            else
            {
                MessageBox.Show("Nhập mã phòng cần tìm");
            }

        }

        private void btnTimRoom_Click(object sender, EventArgs e)
        {
            //Ẩn các button Thêm,Xóa,Sửa
            btnThemRoom.Enabled = false;
            btnSuaRoom.Enabled = false;
            btnXoaRoom.Enabled = false;
            //Nếu textbox Search không rỗng
            if (txtSearchRoom.Text != "")
            {
                // Hiển thị thông tin tìm được lên ListView Phòng
                SearchRoom();

            }
            else
            {
                MessageBox.Show("Nhập mã phòng cần tìm");
            }
           
        }
        //Reset tất cả các textbox,button
        void setNullRoom()
        {
          
            txtSearchRoom.Text = "";
            txtSearchRoom.Enabled = true;
            txtTrangThai.Text = "";
            txtDonGia.Text = "";
            txtTenPH.Text = "";
            txtMaPH.Text = "";
            btnXoaRoom.Enabled = true;
            btnThemRoom.Enabled = true;
            btnSuaRoom.Enabled = true;
            txtMaPH.Enabled = true;
            lblCBRoom.Visible = false;
            txtTrangThai.Enabled = false;
            HienThiDSPH();
        }
        //Reset tất cả các textbox,button
        void setNullDV()
        {

            btnXoaDV.Enabled = true;
            btnThemDV.Enabled = true;
            btnSuaDV.Enabled = true;
            txtMaDV.Enabled = true;
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtDG.Text = "";
            txtSearchDV.Text = "";
            lblCBDV.Visible = false;
            HienThiDSDV();
        }
        //Check dữ liệu nhập vào đã tồn tại hay chưa
        int checktrung(ListView lsv, string s,string s1)
        {
            int chk = 0;
            for (int i = 0; i<lsv.Items.Count; i++)
            {
                if (lsv.Items[i].SubItems[0].Text == s || lsv.Items[i].SubItems[1].Text == s1 )
                {
                    chk = 1;
                    break;
                }
            }
            return chk;
        }
        //Check các textbox có rỗng hay không
        int checkrongDV()
        {
            int k = 0;
            if (txtMaDV.Text != ""&&txtTenDV.Text != "" && txtDG.Text != "")
            {
                k =1;

            }
            return k;

        }
        //Check các textbox có rỗng hay không
        int checkrongRoom()
        {
            int k = 0;
            if (txtMaPH.Text != ""&&txtTenPH.Text != "" && txtDonGia.Text != "")
            {
                k =1;

            }
            return k;

        }
        //Reset lại các button,textbox

        private void btnHuyDV_Click(object sender, EventArgs e)
        {
            setNullDV();
        }
        //Cập nhật lại dịch vụ
        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            //Nếu bạn đang chọn 1 row
            if (lsvDV.SelectedIndices.Count > 0)
            {
                //Cập nhật lại row đó với dữ liệu cập nhật trên các textbox
                dv.CapNhatDV(txtMaDV.Text, txtTenDV.Text, txtDG.Text);
                //Hiển thị cập nhật thành công
                MessageBox.Show("Cập nhật dịch vụ '"+txtMaDV.Text+"' thành công");
                //Load lại ListView và Reset các textbox
                HienThiDSDV();

                setNullDV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ muốn cập nhật");
            }

        }
        //Xóa 1 dịch vụ
        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            //Nếu bạn đang chọn 1 row
            if (lsvDV.SelectedIndices.Count >0)
            {
                //Xóa dòng đang chọn trong Database
                dv.XoaDV(lsvDV.SelectedItems[0].SubItems[0].Text);
                //Xóa dọng chọn trong listview
                lsvDV.Items.RemoveAt(lsvDV.SelectedIndices[0]);
                MessageBox.Show("Xóa dịch vụ '"+txtMaDV.Text+"' thành công!");
                //Reset các textbox
                setNullDV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa");
            }
        }
        //Thêm mới 1 dịch vụ
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            //Check rỗng
            if (checkrongDV() == 1)
            {
                //Check tồn tại
                if (checktrung(lsvDV,txtMaDV.Text,txtTenDV.Text) ==0)
                {
                    //Thêm mới 1 dịch vụ vào Database
                    dv.ThemDV(txtMaDV.Text,txtTenDV.Text,txtDG.Text);
                    //Thông báo
                    MessageBox.Show("Thêm mới dịch vụ '"+txtMaDV.Text+"' thành công");
                    //Load lại ListView và reset textbox
                    HienThiDSDV();
                    setNullDV();
                }
                else
                {
                    MessageBox.Show("Dịch vụ đã tồn tại");
                    txtMaDV.Focus();
                }
            }
            else
            {
                //Hiện cảnh báo chuea nhập đủ thông tin
                lblCBDV.Visible = true;
            }
        }
        //Reset tất cả các button,textbox
        private void btnHuyRoom_Click(object sender, EventArgs e)
        {
            
            setNullRoom();
        }
        //Cập nhật lại Phòng

        private void btnSuaRoom_Click(object sender, EventArgs e)
        {
            //Nếu bạn đang chọn 1 row
            if (lsvRoom.SelectedIndices.Count > 0)
            {
                //Cập nhật phòng với các dữ liệu trên textbox
                r.CapNhatPhong(txtMaPH.Text, txtTenPH.Text, txtDonGia.Text);
                //Thông báo
                MessageBox.Show("Cập nhật phòng '"+txtMaPH.Text+"' thành công");
                //Load listview và reset textbox
                HienThiDSPH();
                setNullRoom();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng muốn cập nhật");
            }

        }
        //Xóa 1 phòng
        private void btnXoaRoom_Click(object sender, EventArgs e)
        {
            //Nếu bạn đang chọn 1 row
            if (lsvRoom.SelectedIndices.Count >0)
            {
                //Xóa phòng trong Database
                r.XoaPhong(lsvRoom.SelectedItems[0].SubItems[0].Text);
                //Xóa row được chọn trong listview
                lsvRoom.Items.RemoveAt(lsvRoom.SelectedIndices[0]);
                //Thông báo
                MessageBox.Show("Xóa phòng '"+txtMaPH.Text+"' thành công!");
                //Reset textbox
                setNullRoom();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa");
            }

        }
        //Thêm mới 1 phòng
        private void btnThemRoom_Click(object sender, EventArgs e)
        {
            //Check rỗng
            if (checkrongRoom() == 1)
            {
                //Check tồn tại
                if (checktrung(lsvRoom, txtMaPH.Text, txtTenPH.Text) ==0)
                {
                    //Thêm mới 1 phòng với dữ liệu trên textbox
                    r.ThemPhong(txtMaPH.Text, txtTenPH.Text, txtDonGia.Text);
                    //Thông báo
                    MessageBox.Show("Thêm mới phòng '"+txtMaPH.Text+"' thành công");
                    //Load lại dữ liệu
                    HienThiDSPH();
                    setNullRoom();
                }
                else
                {
                    MessageBox.Show("Phòng đã tồn tại");
                    txtMaPH.Focus();
                }
            }
            //Hiện cảnh báo chưa nhập đủ thông tin
            else
            {

                lblCBRoom.Visible = true;
            }
        }
    }
}
