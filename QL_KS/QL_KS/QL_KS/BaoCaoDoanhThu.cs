using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KS
{
    class BaoCaoDoanhThu
    {
        Connect con;
        public BaoCaoDoanhThu()
        {
            con = new Connect();
        }
        public DataTable LayDSHDBC()
        {
            string sql = "EXEC dbo.LayDSHDBC";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable LayDSHDDVBC()
        {
            string sql = "EXEC dbo.LayDSHDDVBC";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable SLPhongDuocThue()
        {
            string sql = "EXEC dbo.DemSLPhongDuocThue";
            DataTable dt = con.Execute(sql);
            return dt;
        }
        public DataTable SLKH()
        {
            string sql = "EXEC dbo.DemSLKH";
            DataTable dt = con.Execute(sql);
            return dt;
        }
    }
}
