using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QL_KS
{
    class Connect
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        public Connect()
        {
            string conStr = "Data Source = PHAP\\MAYAO;Database=QL_KSans;Integrated Security = true";
            con = new SqlConnection(conStr);
        }
        public DataTable Execute(string sql)
        {
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExecuteNonQuery(string sql)
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
