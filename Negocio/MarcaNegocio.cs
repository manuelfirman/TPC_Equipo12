using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            NegocioDB db = new NegocioDB();
            List<Marca> marcas = new List<Marca>();

            db.StoreProcedure("SP_ListarMarcas");
            db.Read();
            while (db.Reader.Read())
            {
                Marca auxMarca = new Marca();

                if (!(db.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)db.Reader["Nombre"];
                if (!(db.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)db.Reader["Estado"];
                if (!(db.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca = (long)db.Reader["ID_Marca"];
                marcas.Add(auxMarca);
            }

            db.Close();
            return marcas;
        }

        public List<Marca> MarcasRandom(int cantidad)
        {
            NegocioDB database = new NegocioDB();
            List<Marca> lista = new List<Marca>();
            try
            {
                database.StoreProcedure("SP_MarcasRandom");
                database.SetParam("@Cantidad", cantidad);
                database.Read();
                while (database.Reader.Read())
                {
                Marca auxMarca = new Marca();
                    if (!(database.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca = (long)database.Reader["ID_Marca"];
                    if (!(database.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)database.Reader["Nombre"];
                    if (!(database.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)database.Reader["Estado"];

                    lista.Add(auxMarca);
            }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                database.Close();
            }
        }


    }
}
