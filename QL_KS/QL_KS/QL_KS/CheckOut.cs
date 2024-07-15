using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace QL_KS
{
    public partial class CheckOut : UserControl
    {
        ThanhToan tt = new ThanhToan();
        DataTable dt = new DataTable();
        public CheckOut()
        {
            InitializeComponent();
        }
        void HienThiHD()
        {
            dt = tt.LayDSHDCheckOut();
            lsv_HD.Items.Clear();
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsv_HD.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }
        void HienThiDV(string s)
        {
            dt = tt.LayDSDVCheckOut(s);
            lsvHDDV.Items.Clear();
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvHDDV.Items.Add((i+1).ToString());
                lvi.SubItems.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }
        private void CheckOut_Load(object sender, EventArgs e)
        {

            HienThiHD();
        }

        private void lsv_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsv_HD.SelectedIndices.Count > 0)
            {
                DataTable dt = tt.LayDSHDCheckOut();
                for(int i = 0;i<dt.Rows.Count;i++)
                {
                    if(dt.Rows[i][0].ToString() == lsv_HD.SelectedItems[0].SubItems[0].Text)
                    {
                        txtNV.Text = dt.Rows[i][8].ToString();
                        txtMaPH.Text = dt.Rows[i][2].ToString();
                        txtGG.Text = dt.Rows[i][7].ToString();
                        txtTenKH.Text = dt.Rows[i][6].ToString();
                        txtTongTien.Text = dt.Rows[i][4].ToString();
                        txtMaDP.Text = dt.Rows[i][1].ToString();
                        dtNgaylap.Value = DateTime.Parse(dt.Rows[i][5].ToString());

                    }    
                }    
                HienThiDV(lsv_HD.SelectedItems[0].SubItems[0].Text);
            }    
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(lsv_HD.SelectedIndices.Count > 0)
            {
                tt.CheckOut(lsv_HD.SelectedItems[0].SubItems[0].Text);
                
                MessageBox.Show("Thanh toán thành công");
                HienThiHD();
                lsvHDDV.Items.Clear();
                txtGG.Text = "";
                dtNgaylap.ResetText();
                txtMaPH.Text = "";
                txtMaDP.Text = "";
                txtNV.Text = "";
                txtTenKH.Text = "";
                txtTongTien.Text = "";
            }  
            else
            {
                MessageBox.Show("Chọn hóa đơn cần thanh toán");
            }    
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lsvHDDV.Items.Clear();
            txtGG.Text = "";
            dtNgaylap.ResetText();
            txtMaPH.Text = "";
            txtMaDP.Text = "";
            txtNV.Text = "";
            txtTenKH.Text = "";
            txtTongTien.Text = "";
            txtSearch.Text = "";
            HienThiHD();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                dt = tt.SearchHD(txtSearch.Text);
                lsv_HD.Items.Clear();
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    ListViewItem lvi = lsv_HD.Items.Add(dt.Rows[i][0].ToString());
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    lvi.SubItems.Add(dt.Rows[i][4].ToString());
                    lvi.SubItems.Add(dt.Rows[i][5].ToString());
                }
            }    
        }
    }
}
