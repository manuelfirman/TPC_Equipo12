using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Database.SetQuery("SELECT C.ID_Categoria, C.Nombre, C.Estado FROM Categorias AS C");
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
                Database.SetQuery("SELECT TOP (@Cantidad) C.ID_Categoria, C.Nombre, C.Estado FROM Categorias C ORDER BY NEWID()");
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
                Database?.Close();
            }
        }

        public Categoria CategoriaPorID(long IDCategoria)
        {
            Database = new NegocioDB();
            Categoria auxCategoria = new Categoria();

            try
            {
                Database.SetQuery($"SELECT Nombre, Estado, ID_Categoria FROM Categorias WHERE ID_Categoria = @ID_Categoria");
                Database.SetParam("ID_Categoria", IDCategoria);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["Nombre"] is DBNull)) auxCategoria.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxCategoria.Estado = (bool)Database.Reader["Estado"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxCategoria.IDCategoria = (long)Database.Reader["ID_Categoria"];


                }
                return auxCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Database?.Close();
            }
        }

        public bool AgregarCategoria(Categoria categoria)
        {
            Database = new NegocioDB();
            try
            {
                Database.SetQuery("INSERT INTO Categorias(Nombre, Estado) VALUES(@Nombre, @Estado)");
                Database.SetParam("@Nombre", categoria.Nombre);
                Database.SetParam("@Estado", categoria.Estado);
                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Database?.Close();
            }
        }

        public bool ModificarCategoria(Categoria categoria)
        {
            Database = new NegocioDB();
            try
            {
                Database.SetQuery("UPDATE Categorias SET Nombre = @Nombre, Estado = @Estado WHERE ID_Categoria = @ID_Categoria");
                Database.SetParam("@Nombre", categoria.Nombre);
                Database.SetParam("@ID_Categoria", categoria.IDCategoria);
                Database.SetParam("@Estado", categoria.Estado);

                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Database?.Close();
            }
        }

        public bool EstadoCategoria(long IDCategoria, bool Estado)
        {
            Database = new NegocioDB();
            try
            {
                Database.SetQuery($"UPDATE Categorias SET Estado = @Estado WHERE ID_Categoria = @ID_Categoria");
                Database.SetParam("@ID_Categoria", IDCategoria);
                Database.SetParam("@Estado", Estado);
                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Database?.Close();
            }
        }

        public bool EliminarCategoria(long IDCategoria)
        {
            Database = new NegocioDB();
            try
            {
                Database.SetQuery("DELETE FROM Categorias WHERE ID_Categoria = @ID_Categoria");
                Database.SetParam("@ID_Categoria", IDCategoria);
                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Database?.Close();
            }
        }

    }
}
