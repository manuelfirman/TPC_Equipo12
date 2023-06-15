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
        public List<Categoria> listarCategoria()
        {
            NegocioDB db = new NegocioDB();
            List<Categoria> categorias = new List<Categoria>();
            db.StoreProcedure("SP_ListarCategorias");
            db.Read();
            while (db.Reader.Read())
            {
                Categoria auxCategoria = new Categoria();

                if (!(db.Reader["Nombre"] is DBNull)) auxCategoria.Nombre = (string)db.Reader["Nombre"];
                if (!(db.Reader["Estado"] is DBNull)) auxCategoria.Estado = (bool)db.Reader["Estado"];
                if (!(db.Reader["ID_Categoria"] is DBNull)) auxCategoria.IDCategoria = (int)db.Reader["ID_Categoria"];
                categorias.Add(auxCategoria);
            }
            db.Close();
            return categorias;
        }

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
