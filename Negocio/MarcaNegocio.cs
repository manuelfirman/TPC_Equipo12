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
        private NegocioDB Database { get; set; }

        public List<Marca> ListarMarcas()
        {
            Database = new NegocioDB();
            List<Marca> marcas = new List<Marca>();

            Database.StoreProcedure("SP_ListarMarcas");
            Database.Read();
            while (Database.Reader.Read())
            {
                Marca auxMarca = new Marca();

                if (!(Database.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)Database.Reader["Nombre"];
                if (!(Database.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)Database.Reader["Estado"];
                if (!(Database.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca = (long)Database.Reader["ID_Marca"];
                marcas.Add(auxMarca);
            }

            Database.Close();
            return marcas;
        }

        public List<Marca> MarcasRandom(int cantidad)
        {
            Database = new NegocioDB();
            List<Marca> lista = new List<Marca>();
            try
            {
                Database.StoreProcedure("SP_MarcasRandom");
                Database.SetParam("@Cantidad", cantidad);
                Database.Read();
                while (Database.Reader.Read())
                {
                Marca auxMarca = new Marca();
                    if (!(Database.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca = (long)Database.Reader["ID_Marca"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)Database.Reader["Estado"];

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
                Database.Close();
            }
        }

        public bool AgregarMarca(Marca marca)
        {
            return true;
        }

        public bool ModificarMarca(Marca marca)
        {
            return true;
        }

        public bool EliminarMarca(long IDMarca)
        {
            return true;
        }
    }
}
