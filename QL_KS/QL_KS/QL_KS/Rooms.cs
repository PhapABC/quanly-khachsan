using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KS
{
    class Rooms
    {
        Connect con;
        public Rooms()
        {
            con = new Connect();
        }
        public DataTable LayDSPH()
        {
            string sql = "EXEC dbo.LayDSPH";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LayDSDP()
        {
            string sql = "EXEC dbo.LayDSDP";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LaySearchPH(string maph)
        {
            string sql = "EXEC dbo.LayDSPHTheoMa '"+maph+"'";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public void ThemPhong(string maph, string ten, string dg)
        {
            string sql = "INSERT INTO Phong(MaPhong,TenPhong,DonGia) VALUES('"+maph+"',N'"+ten+"','"+dg+"')";
            con.ExecuteNonQuery(sql);

        }
        public void CapNhatPhong(string maph, string ten, string dg)
        {
            string sql = "UPDATE Phong SET TenPhong = N'"+ten+"',DonGia ='"+dg+"' WHERE MaPhong = '"+maph+"'";
            con.ExecuteNonQuery(sql);

        }
        public void XoaPhong(string maph)
        {
            string sql = "DELETE Phong WHERE MaPhong = '"+maph+"'";
            con.ExecuteNonQuery(sql);

        }
    }
}
