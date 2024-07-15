using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QL_KS
{
    class NhanVien
    {
        Connect con;
        public NhanVien()
        {
            con = new Connect();
        }
        public DataTable LayDSNV()
        {
            string sql = "EXEC dbo.LayDSNV";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LayDSQuyen()
        {
            string sql = "select * from QUYEN";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LaySearchNV(string manv)
        {
            string sql = "EXEC dbo.LayDSNVTheoMa '"+manv+"'";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public void ThemNV(string manv,string ten,string ns,string dc,string gt,string sdt,string username,string pass,string index_quyen)
        {
            string sql = "INSERT INTO NHANSU VALUES('"+manv+"',N'"+ten+"','"+ns+"',N'"+dc+"',N'"+gt+"','"+sdt+"','"+username+"','"+pass+"','"+index_quyen+"')";
            con.ExecuteNonQuery(sql);
         
        }
        public void CapNhatNV(string manv, string ten, string ns, string dc, string gt, string sdt, string username, string pass, string index_quyen)
        {
            string sql = "UPDATE NHANSU SET TENNV = N'"+ten+"', NgaySinh = '"+ns+"',DiaChi = N'"+dc+"',GT = N'"+gt+"',SDT = '"+sdt+"',USERNAME = '"+username+"',PASS = '"+pass+"',QUYEN = '"+index_quyen+"' WHERE MANV = '"+manv+"'";
            con.ExecuteNonQuery(sql);

        }
        public void XoaNV(string manv)
        {
            string sql = "DELETE NHANSU WHERE MANV = '"+manv+"'";
            con.ExecuteNonQuery(sql);

        }
    }
}
