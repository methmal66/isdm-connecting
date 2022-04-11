using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace isdm_connecting
{
    internal class DB
    {
        string conString;
        SqlConnection con;

        public DB()
        {
            conString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
            con = new SqlConnection(conString);
        }

        public bool execute(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() == 1)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public DataTable getTable(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            con.Close();
            return table;
        }
    }
}
