using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KS
{
    class ThanhToan
    {
        Connect con;
        public ThanhToan()
        {
            con = new Connect();
        }
        public DataTable LayDSHDCheckOut()
        {
            string sql = "EXEC dbo.LayDSHDCheckOut";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LayDSDVCheckOut(string mahd)
        {
            string sql = "EXEC dbo.LayDSDVCheckOut '"+mahd+"'";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public void CheckOut(string mahd)
        {
            string sql = "Update HoaDon set CongNo = 0 where MAHD = '"+mahd+"'";
            con.ExecuteNonQuery(sql);
        }
        
        public DataTable SearchHD(string mahd)
        {
            string sql = "SELECT * from fu_SearchDSHD('"+mahd+"')";
            DataTable dt = con.Execute(sql);
            return dt;
        }

    }
}
