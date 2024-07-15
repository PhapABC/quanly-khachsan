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
    public partial class BaoCao : UserControl
    {
        DataTable dt = new DataTable();
        BaoCaoDoanhThu bc = new BaoCaoDoanhThu();
        public BaoCao()
        {
            InitializeComponent();
        }
        void HienThiDSHD()
        {
            dt = bc.LayDSHDBC();
            lsvDSHD.Items.Clear();
            for(int i = 0; i<dt.Rows.Count;i++)
            {
                ListViewItem lvi = lsvDSHD.Items.Add((i+1).ToString());
                lvi.SubItems.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }

        }
        void HienThiDSHDDV()
        {
            dt = bc.LayDSHDDVBC();
            lsvDDV.Items.Clear();
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvDDV.Items.Add((i+1).ToString());
                lvi.SubItems.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }

        }
        void laydanhthuVaTongHD()
        {
            float dts = 0;
            if(lsvDSHD.Items.Count > 0)
            {
                for(int i =0;i<lsvDSHD.Items.Count;i++)
                {
                    dts += float.Parse(lsvDSHD.Items[i].SubItems[5].Text);
                }
                txtDoanhThu.Text = dts.ToString();
                txtSLHD.Text = dt.Rows.Count.ToString();
            }
            else
            {
                txtDoanhThu.Text = "";
                txtSLHD.Text = "";
            }
            
        }
        void SLPhongThue()
        {
            dt = bc.SLPhongDuocThue();
            txtDonThuePhong.Text = dt.Rows.Count.ToString();
        }
        void SLKH()
        {
            dt = bc.SLKH();
            txtSoKH.Text = dt.Rows.Count.ToString();
        }
        private void BaoCao_Load(object sender, EventArgs e)
        {
            HienThiDSHD();
            HienThiDSHDDV();
            laydanhthuVaTongHD();
            SLPhongThue();
            SLKH();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {

        }
    }
}
