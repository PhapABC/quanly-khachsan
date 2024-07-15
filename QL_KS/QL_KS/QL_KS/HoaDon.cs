using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KS
{
    class HoaDon
    {
        Connect con;
        public HoaDon()
        {
            con = new Connect();
        }
        public DataTable LayDSHD()
        {
            string sql = "EXEC dbo.LayDSHD";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public void ThemDatPhong(string madp, string maph,string ngaydat, string ngaynhan,string ngaytra,string thanhtien)
        {
            string sql = "INSERT INTO DatPhong VALUES('"+madp+"','"+maph+"','"+ngaydat+"','"+ngaynhan+"','"+ngaytra+"','"+thanhtien+"')";
            con.ExecuteNonQuery(sql);

        }
        public void ThemDatDV(string madv, string madp, string sl, string thanhtien)
        {
            string sql = "INSERT INTO DatDichVu VALUES('"+madv+"','"+madp+"','"+sl+"','"+thanhtien+"')";
            con.ExecuteNonQuery(sql);

        }
        public void ThemHD(string mahd, string madp,string makh, string tongtien,string giamgia,string tiencoc,string ngaylap,string manv)
        {
            string sql = "INSERT INTO HoaDon(MaHD,MaDatPhong,MAKH,TongTien,Giamgia,TienCoc,NgayLap,MANV) VALUES('"+mahd+"','"+madp+"','"+makh+"','"+tongtien+"','"+giamgia+"','"+tiencoc+"','"+ngaylap+"','"+manv+"')";
            con.ExecuteNonQuery(sql);

        }
      

    }
}
