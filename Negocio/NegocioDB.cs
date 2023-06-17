using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDB
    {
        private readonly string dbName;
        private readonly string dbServer;
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public NegocioDB()
        {
            dbName = "E_COMMERCE12";
            dbServer = ".\\SQLEXPRESS";
            conn = new SqlConnection($"server={dbServer}; database={dbName}; integrated security=true");
            cmd = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }

        public void SetParam(string nombre, object valor)
        {
            cmd.Parameters.AddWithValue(nombre, valor);
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

        public int RunQuery()
        {
            cmd.Connection = this.conn;
            try
            {
                int rowsAffected = 0;
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StoreProcedure(string storeProcedure)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = storeProcedure;
        }

        public void Close()
        {
            reader?.Close();
            conn.Close();
        }
    }
}
