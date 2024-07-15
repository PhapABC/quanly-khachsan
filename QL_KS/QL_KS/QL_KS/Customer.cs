using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QL_KS
{
    class Customer
    {
        Connect con;
        public Customer()
        {
            con = new Connect();
        }
        public DataTable LayDSKH()
        {
            string sql = "EXEC dbo.LayDSKH";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LayHDTheoKH(string makh)
        {
            string sql = "EXEC dbo.LayDSHDCuaKH '"+makh+"'";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LaySearchKH(string makh)
        {
            string sql = "EXEC dbo.LayDSKHTheoMa '"+makh+"'";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public void ThemKH(string makh, string ten, string dc, string sdt, string email)
        {
            string sql = "INSERT INTO KHACHHANG VALUES('"+makh+"',N'"+ten+"','"+dc+"',N'"+sdt+"',N'"+email+"')";
            con.ExecuteNonQuery(sql);

        }
        public void CapNhatKH(string makh, string ten, string dc, string sdt, string email)
        {
            string sql = "UPDATE KHACHHANG SET TENKHACH = N'"+ten+"',DiaChi = N'"+dc+"',SDT = '"+sdt+"' ,email = '"+email+"' WHERE MAKH = '"+makh+"'";
            con.ExecuteNonQuery(sql);

        }
        public void XoaKH(string makh)
        {
            string sql = "DELETE KHACHHANG WHERE MAKH = '"+makh+"'";
            con.ExecuteNonQuery(sql);

        }
    }
}
