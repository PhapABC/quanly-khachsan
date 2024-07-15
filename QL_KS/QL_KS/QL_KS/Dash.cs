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
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
        }

        private void Dash_Load(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = false;
            qL_KhachHang1.Visible = false;
            qL_PhongDV1.Visible = false;
            nhanSu1.Visible = false;
            baoCao1.Visible = false;
            checkOut1.Visible = false;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = false;
            qL_KhachHang1.Visible = false;
            qL_PhongDV1.Visible = false;
            nhanSu1.Visible = true;
            baoCao1.Visible = false;
            checkOut1.Visible = false;
            btnUser.BringToFront();

        }

        private void btnRoomDV_Click(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = false;
            qL_KhachHang1.Visible = false;
            qL_PhongDV1.Visible = true;
            nhanSu1.Visible = false;
            checkOut1.Visible = false;
            baoCao1.Visible = false;
            btnRoomDV.BringToFront();
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = true;
            qL_KhachHang1.Visible = false;
            qL_PhongDV1.Visible = false;
            nhanSu1.Visible = false;
            baoCao1.Visible = false;
            checkOut1.Visible = false;
            btnHD.BringToFront();
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = false;
            qL_KhachHang1.Visible = false;
            qL_PhongDV1.Visible = false;
            nhanSu1.Visible = false;
            checkOut1.Visible = false;
            baoCao1.Visible = true;
            btnBC.BringToFront();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = false;
            qL_KhachHang1.Visible = true;
            qL_PhongDV1.Visible = false;
            nhanSu1.Visible = false;
            baoCao1.Visible = false;
            checkOut1.Visible = false;
            btnKH.BringToFront();

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            qL_HoaDon1.Visible = false;
            qL_KhachHang1.Visible = true;
            qL_PhongDV1.Visible = false;
            nhanSu1.Visible = false;
            baoCao1.Visible = false;
            checkOut1.Visible = true;
            btnCheckOut.BringToFront();
        }

        private void checkOut1_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
