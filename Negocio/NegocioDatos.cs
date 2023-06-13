using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDatos
    {
        private string dbName;
        private string dbServer;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public NegocioDatos()
        {
            dbName = "E-COMMERCE";
            dbServer = ".\\SQLEXPRESS";
            conn = new SqlConnection($"server={dbServer}; database={dbName}; integrated security=true");
            cmd = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }

        public void Read()
        {
            cmd.Connection = this.conn;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetParam(string nombre, object valor)
        {
            cmd.Parameters.AddWithValue(nombre, valor);
        }

        public int RunQuery()
        {
            cmd.Connection = this.conn;
            int rowsAffected = 0;
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            if (reader != null)
            {
                reader.Close();
            }
            conn.Close();
        }
    }
}
