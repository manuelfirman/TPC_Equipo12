using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> CategoriasRandom(int cantidad)
        {
            NegocioDB database = new NegocioDB();
            List<Categoria> lista = new List<Categoria>();
            try
            {
                database.StoreProcedure("SP_CategoriasRandom");
                database.SetParam("@Cantidad", cantidad);
                database.Read();
                while (database.Reader.Read())
                {
                    Categoria auxCategoria = new Categoria();
                    if (!(database.Reader["ID_Categoria"] is DBNull)) auxCategoria.IDCategoria = (int)database.Reader["ID_Categoria"];
                    if (!(database.Reader["Nombre"] is DBNull)) auxCategoria.Nombre = (string)database.Reader["Nombre"];
                    if (!(database.Reader["Estado"] is DBNull)) auxCategoria.Estado = (bool)database.Reader["Estado"];

                    lista.Add(auxCategoria);
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
