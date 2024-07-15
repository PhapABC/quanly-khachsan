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
    public partial class QL_HoaDon : UserControl
    {
        HoaDon hd = new HoaDon();
        Rooms r = new Rooms();
        Customer ct = new Customer();
        DichVu dv = new DichVu();
        NhanVien nv = new NhanVien();
        public QL_HoaDon()
        {
            InitializeComponent();
        }

        private void lsv_HD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        void HienThiDSHD()
        {

            DataTable dt = hd.LayDSHD();
            lsv_HD.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsv_HD.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());



            }
        }
        void HienThiDSDV()
        {

            DataTable dt =dv.LayDSDV();
            lsvDSDV.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvDSDV.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());


            }
        }
        void LayDSPH()
        {
            DataTable dt = r.LayDSPH();
            cbo_MaPH.DataSource = dt;
            cbo_MaPH.DisplayMember = "MaPhong";
            cbo_MaPH.ValueMember = "TenPhong";
            cbo_MaPH.SelectedIndex = -1;
        }
        void LayDSKH()
        {
            DataTable dt = ct.LayDSKH();
            cbo_KH.DataSource = dt;
            cbo_KH.DisplayMember = "TenKhach";
            cbo_KH.ValueMember = "MaKH";
            cbo_KH.SelectedIndex = -1;
        }
        void LayDSNV()
        {
            DataTable dt = nv.LayDSNV();
            cbo_NV.DataSource = dt;
            cbo_NV.DisplayMember = "TenNV";
            cbo_NV.ValueMember = "MaNV";
            cbo_NV.SelectedIndex = -1;
        }
        void LayMaDV()
        {
            DataTable dt = dv.LayDSDV();
            cboMADV.DataSource = dt;
            cboMADV.DisplayMember = "MaDichVu";
            cboMADV.ValueMember = "TenDichVu";
            cboMADV.SelectedIndex = -1;
        }
        private void QL_HoaDon_Load(object sender, EventArgs e)
        {
            HienThiDSHD();
            LayDSPH();
            LayDSKH();
            HienThiDSDV();
            LayDSNV();
            LayMaDV();
            txtDGP.Text = "";
            txtTongTienHD.Text = "";
            cboPhanTramGG.SelectedIndex = -1;
        }
        
        private void cbo_MaPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cbo_MaPH.SelectedIndex != -1)
            {
               
                txtTenPhong.Text = cbo_MaPH.SelectedValue.ToString();
                
                DataTable dt = r.LaySearchPH(cbo_MaPH.Text);
                if(dt.Rows.Count > 0)
                {
                   txtDGP.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    txtDGP.Text = "";
                }
                if (lsvHDDV.Items.Count == 0)
                {
                    txtTTienDP.Text = txtDGP.Text;
                }


            }   
            else
            {
                txtTenPhong.Text = "";
                txtTTienDP.Text = "";
            }
            txtTongTienHD.Text = txtTTienDP.Text;
            
        }

        private void lsvDSDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMADV.SelectedIndex = -1;
            if(lsvDSDV.SelectedIndices.Count > 0)
            {
                cboMADV.SelectedIndex = cboMADV.FindString(lsvDSDV.SelectedItems[0].SubItems[0].Text);
            }
            
        }

        private void cboMADV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cboMADV.Items.ToString() != "")
            {

                DataTable dt = dv.LaySearchDV(cboMADV.Text);
                if(dt.Rows.Count > 0)
                {
                    txtDGDV.Text = dt.Rows[0][2].ToString();
                    txtTenDV.Text = cboMADV.SelectedValue.ToString();
                }
                else
                {
                    txtDGDV.Text = "";
                    txtTenDV.Text = "";
                }
            }




        }
        void setnullhddv()
        {
            cboMADV.SelectedIndex = -1;
            txtTenDV.Text = "";
            txtSLDV.Text = "";
            txtDGDV.Text = "";
        }
        void setNull()
        {
            txtMahd.Text = "";
            txtMADP.Text = "";
           
            txtTenDV.Text = "";
            txtTenPhong.Text = "";
            txtTienCoc.Text = "";
            txtTongTienHD.Text = "";
            txtTTienDP.Text = "";
            lsvHDDV.Items.Clear();
            txtDGP.Text = "";
           
            dtNgayban.ResetText();
            dtNgayDat.ResetText();
            dtNgayNhan.ResetText();
            dtNgayTra.ResetText();
            txtSearchDV.Text = "";
            txtConLai.Text = "";
            setnullhddv();

        }
        float CapNhatThanhTien()
        {
            float tiendv = 0;
            if(lsvHDDV.Items.Count > 0)
            {
                for (int i = 0; i < lsvHDDV.Items.Count; i++)
                {
                    tiendv += float.Parse(lsvHDDV.Items[i].SubItems[5].Text);
                }
                return tiendv;

            }
            else
            {
                tiendv = 0;
            }
            return tiendv;

        }
        int checkmadv()
        {
            int c = 0;
            for(int i = 0; i< lsvHDDV.Items.Count;i++)
            {
                if(cboMADV.Text == lsvHDDV.Items[i].SubItems[1].Text)
                {
                    c = 1;
                    break;
                }
            }
            return c;
        }
        private void btnThemDDV_Click(object sender, EventArgs e)
        {
            if(cboMADV.SelectedIndex != -1 && cbo_KH.SelectedIndex != -1 && txtMADP.Text != ""&& cbo_KH.SelectedIndex != -1)
            {
                if (txtSLDV.Text != "" && cboMADV.SelectedIndex != -1)
                {
                    if(checkmadv() == 0)
                    {
                        ListViewItem lvi = lsvHDDV.Items.Add((lsvHDDV.Items.Count + 1).ToString());
                        lvi.SubItems.Add(cboMADV.Text);
                        lvi.SubItems.Add(txtTenDV.Text);
                        lvi.SubItems.Add(txtSLDV.Text);
                        lvi.SubItems.Add(txtDGDV.Text);
                        float thanhtien = float.Parse(txtDGDV.Text)*int.Parse(txtSLDV.Text);
                        lvi.SubItems.Add(thanhtien.ToString());
                       
                        txtTTienDP.Text = "";
                        txtTTienDP.Text = (CapNhatThanhTien() + float.Parse(txtDGP.Text)).ToString();

                    }
                    else
                    {
                        for(int i =0;i< lsvHDDV.Items.Count;i++)
                        {
                            if(lsvHDDV.Items[i].SubItems[1].Text == cboMADV.Text)
                            {
                                lsvHDDV.Items[i].SubItems[3].Text = (int.Parse(lsvHDDV.Items[i].SubItems[3].Text) + int.Parse(txtSLDV.Text)).ToString();
                            }
                        }
                    }
                    setnullhddv();
                    
                    
                }
                else
                {
                    MessageBox.Show("Chọn dịch vụ và nhập số lượng");
                    txtSLDV.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin đặt phòng");
                setnullhddv();
            }
           
           
            if (chkGiamGia.Checked == true && cboPhanTramGG.SelectedIndex != -1)
            {
                txtTongTienHD.Text = (float.Parse(txtTTienDP.Text) - (float.Parse(txtTTienDP.Text)*float.Parse(cboPhanTramGG.Text)/100)).ToString();
            }
            if(chkGiamGia.Checked == false)
            {
                txtTongTienHD.Text = txtTTienDP.Text;
            }



        }

        private void btnXoaDDV_Click(object sender, EventArgs e)
        {
            if(lsvHDDV.SelectedIndices.Count > 0)
            {
                lsvHDDV.Items.RemoveAt(lsvHDDV.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Chọn dòng bạn muốn xóa");
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkGiamGia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiamGia.Checked == true)
            {
                cboPhanTramGG.Enabled = true;
            }
            else
            {
                cboPhanTramGG.Enabled = false;
                txtTongTienHD.Text = txtTTienDP.Text;
            }
               
        }

        private void cboPhanTramGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkGiamGia.Checked == true && cboPhanTramGG.SelectedIndex != -1)
            {
                txtTongTienHD.Text = (float.Parse(txtTTienDP.Text) - (float.Parse(txtTTienDP.Text)*float.Parse(cboPhanTramGG.Text)/100)).ToString();
            }
           if(chkGiamGia.Checked == false)
            {
                txtTongTienHD.Text = txtTTienDP.Text;
            }
        }
        void SearchDV()
        {

            DataTable dt = dv.LaySearchDV(txtSearchDV.Text);
            lsvDSDV.Items.Clear();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvDSDV.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }
        private void btnSearchDV_Click(object sender, EventArgs e)
        {
           
            if(txtSearchDV.Text != "")
            {
                SearchDV();
            }
            else
            {
                MessageBox.Show("Nhập mã dịch vụ cần tìm");
            }
        }

        private void btnHuyDDV_Click(object sender, EventArgs e)
        {
            txtDGDV.Text = "";
            txtTenDV.Text = "";
            txtSLDV.Text = "";
            cboMADV.SelectedIndex = -1;
        }

        private void btnSuaDDV_Click(object sender, EventArgs e)
        {
            if(lsvHDDV.SelectedIndices.Count > 0)
            {
                lsvHDDV.SelectedItems[0].SubItems[1].Text = cboMADV.Text;
                lsvHDDV.SelectedItems[0].SubItems[2].Text = txtTenDV.Text;
                lsvHDDV.SelectedItems[0].SubItems[3].Text = txtSLDV.Text;
                lsvHDDV.SelectedItems[0].SubItems[1].Text = txtDGDV.Text;
               
                lsvHDDV.SelectedItems[0].SubItems[1].Text = (float.Parse(txtDGDV.Text)*int.Parse(txtSLDV.Text)).ToString();


            }
            else
            {
                MessageBox.Show("Chọn dòng cần sửa");
            }
        }
        int checkrong()
        {
            int k = 0;
            if(txtMahd.Text != ""&&txtMADP.Text !=""&&cbo_KH.SelectedIndex != -1&&cbo_MaPH.SelectedIndex != -1)
            {
                k =1;
            }

            return k;
        }
        int checkHD()
        {
            int k = 0;
            for(int i = 0;i<lsv_HD.Items.Count;i++)
            {
                if(lsv_HD.Items[i].SubItems[0].Text == txtMahd.Text)
                {
                    k =1;
                    break;
                }
            }
            return k;
        }
        int checkDP()
        {
            int k = 0;
            DataTable dt = r.LayDSDP();
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == txtMADP.Text)
                {
                    k =1;
                    break;
                }
            }
            return k;
        }
        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if(checkrong() == 1)
            {
                if(checkHD()== 0)
                {
                    if(checkDP()==0)
                    {
                        hd.ThemDatPhong(txtMADP.Text, cbo_MaPH.Text, dtNgayDat.Value.ToString(), dtNgayNhan.Value.ToString(), dtNgayTra.Value.ToString(), txtTTienDP.Text);
                        if(lsvHDDV.Items.Count > 0)
                        {
                            for(int i = 0;i< lsvHDDV.Items.Count; i++)
                            {
                                hd.ThemDatDV(lsvHDDV.Items[i].SubItems[1].Text, txtMADP.Text, lsvHDDV.Items[i].SubItems[3].Text, lsvHDDV.Items[i].SubItems[5].Text);
                            }
                        }
                        float tiengiam = float.Parse(txtTTienDP.Text) - float.Parse(txtTongTienHD.Text);
                        hd.ThemHD(txtMahd.Text, txtMADP.Text, cbo_KH.SelectedValue.ToString(), txtTongTienHD.Text, tiengiam.ToString(), txtTienCoc.Text,DateTime.Now.ToString(),cbo_NV.SelectedValue.ToString());
                       
                        MessageBox.Show("Lưu thành công hóa đơn");
                        HienThiDSHD();
                    }
                    else
                    {
                        MessageBox.Show("Mã đặt phòng đã tồn tại");
                    }
                }
                else
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại");
                }
            }
            setNull();
           
            
        }

        private void txtTienCoc_TextChanged(object sender, EventArgs e)
        {
            if(txtTienCoc.Text !="")
            {
                txtConLai.Text = (float.Parse(txtTongTienHD.Text) - float.Parse(txtTienCoc.Text)).ToString();
            }
            else
            {
                txtConLai.Text = "";
            }
            
        }

        private void cbo_KH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            setNull();
            HienThiDSHD();
        }

        private void txtMahd_TextChanged(object sender, EventArgs e)
        {
            LayDSNV();
            LayDSPH();
            LayDSKH();
            LayMaDV();
            HienThiDSDV();
        }
    }
}




