using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KS
{
    class DichVu
    {
        Connect con;
        public DichVu()
        {
            con = new Connect();
        }
        public DataTable LayDSDV()
        {
            string sql = "EXEC dbo.LayDSDV";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LaySearchDV(string madv)
        {
            string sql = "EXEC dbo.LayDSDVTheoMa '"+madv+"'";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public void ThemDV(string madv, string ten, string dg)
        {
            string sql = "INSERT INTO DichVu VALUES('"+madv+"',N'"+ten+"','"+dg+"')";
            con.ExecuteNonQuery(sql);

        }
        public void CapNhatDV(string madv, string ten, string dg)
        {
            string sql = "UPDATE DichVu SET TenDichVu = N'"+ten+"',GiaDichVu = '"+dg+"' WHERE MaDichVu = '"+madv+"'";
            con.ExecuteNonQuery(sql);

        }
        public void XoaDV(string madv)
        {
            string sql = "DELETE DichVu WHERE MaDichVu = '"+madv+"'";
            con.ExecuteNonQuery(sql);

        }
    }
}
