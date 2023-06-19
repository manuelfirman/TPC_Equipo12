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
        private NegocioDB Database { get; set; }

        public List<Categoria> ListarCategoria()
        {
            Database = new NegocioDB();
            List<Categoria> categorias = new List<Categoria>();
            Database.StoreProcedure("SP_ListarCategorias");
            Database.Read();
            while (Database.Reader.Read())
            {
                Categoria auxCategoria = new Categoria();

                if (!(Database.Reader["Nombre"] is DBNull)) auxCategoria.Nombre = (string)Database.Reader["Nombre"];
                if (!(Database.Reader["Estado"] is DBNull)) auxCategoria.Estado = (bool)Database.Reader["Estado"];
                if (!(Database.Reader["ID_Categoria"] is DBNull)) auxCategoria.IDCategoria = (long)Database.Reader["ID_Categoria"];
                categorias.Add(auxCategoria);
            }
            Database.Close();
            return categorias;
        }

        public List<Categoria> CategoriasRandom(int cantidad)
        {
            Database = new NegocioDB();
            List<Categoria> lista = new List<Categoria>();
            Categoria auxCategoria;
            try
            {
                Database.StoreProcedure("SP_CategoriasRandom");
                Database.SetParam("@Cantidad", cantidad);
                Database.Read();
                while (Database.Reader.Read())
                {
                    auxCategoria = new Categoria();
                    if (!(Database.Reader["ID_Categoria"] is DBNull)) auxCategoria.IDCategoria = (long)Database.Reader["ID_Categoria"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxCategoria.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxCategoria.Estado = (bool)Database.Reader["Estado"];

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
                Database.Close();
            }
        }

        public bool AgregarCategoria(Categoria categoria)
        {
            return true;
        }

        public bool ModificarCategoria(Categoria categoria)
        {
            return true;
        }

        public bool EliminarCategoria(long IDCategoria)
        {
            return true;
        }

    }
}
