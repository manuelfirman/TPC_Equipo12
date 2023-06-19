using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        private NegocioDB Database { get; set; }


        public List<Imagen> ImagenesProducto(long IDProducto)
        {
            Database = new NegocioDB();
            string query = "SELECT ID_Producto, ImagenURL, ID_Imagen, Descripcion, Estado FROM Imagenes WHERE ID_Producto = @IDProducto";
            List<Imagen> imagenes = new List<Imagen>();
            Imagen imagen;

            try
            {
                Database.SetParam("@IDProducto", IDProducto);
                Database.SetQuery(query);
                Database.Read();
                while (Database.Reader.Read())
                {
                    imagen = new Imagen();
                    imagen.IDImagen = (long)Database.Reader["ID_Imagen"];
                    imagen.Url = (string)Database.Reader["ImagenURL"];
                    imagen.IDProducto = (long)Database.Reader["ID_Producto"];
                    imagen.Descripcion = (string)Database.Reader["Descripcion"];
                    imagen.Estado = (bool)Database.Reader["Estado"];
                    imagenes.Add(imagen);
                }

                return imagenes;
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

        public List<Imagen> ImagenesAlAzar(int cantidad)
        {
            Database = new NegocioDB();
            List<Imagen> lista = new List<Imagen>();
            Imagen imagen;

            try
            {
                Database.StoreProcedure("SP_ImagenesAlAzar");
                Database.SetParam("@Cantidad", cantidad);
                Database.Read();
                while (Database.Reader.Read())
                {
                    imagen = new Imagen();
                    if (!(Database.Reader["ID_Producto"] is DBNull)) imagen.IDProducto = (long)Database.Reader["ID_Producto"];
                    if (!(Database.Reader["ID_Imagen"] is DBNull)) imagen.IDImagen = (long)Database.Reader["ID_Imagen"];
                    if (!(Database.Reader["ImagenURL"] is DBNull)) imagen.Url = (string)Database.Reader["ImagenURL"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) imagen.Descripcion = (string)Database.Reader["Descripcion"];
                    if (!(Database.Reader["Estado"] is DBNull)) imagen.Estado = (bool)Database.Reader["Estado"];

                    lista.Add(imagen);
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

        public List<Imagen> ImagenesRandomPorCategoria(int cantidad, string categoria)
        {
            Database = new NegocioDB();
            List<Imagen> lista = new List<Imagen>();
            Imagen imagen;

            try
            {
                Database.StoreProcedure("SP_ImagenesRandomPorCategoria");
                Database.SetParam("@Cantidad", cantidad);
                Database.SetParam("@Categoria", categoria);
                Database.Read();
                while (Database.Reader.Read())
                {
                    imagen = new Imagen();
                    if (!(Database.Reader["ID_Producto"] is DBNull)) imagen.IDProducto = (long)Database.Reader["ID_Producto"];
                    if (!(Database.Reader["ID_Imagen"] is DBNull)) imagen.IDImagen = (long)Database.Reader["ID_Imagen"];
                    if (!(Database.Reader["ImagenURL"] is DBNull)) imagen.Url = (string)Database.Reader["ImagenURL"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) imagen.Descripcion = (string)Database.Reader["Descripcion"];

                    lista.Add(imagen);
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

        public List<Imagen> ImagenesRandomPorMarca(int cantidad, string marca)
        {
            Database = new NegocioDB();
            List<Imagen> lista = new List<Imagen>();
            Imagen imagen;

            try
            {
                Database.StoreProcedure("SP_ImagenesRandomPorMarca");
                Database.SetParam("@Cantidad", cantidad);
                Database.SetParam("@Marca", marca);
                Database.Read();
                while (Database.Reader.Read())
                {
                    imagen = new Imagen();
                    if (!(Database.Reader["ID_Producto"] is DBNull)) imagen.IDProducto = (long)Database.Reader["ID_Producto"];
                    if (!(Database.Reader["ID_Imagen"] is DBNull)) imagen.IDImagen = (long)Database.Reader["ID_Imagen"];
                    if (!(Database.Reader["ImagenURL"] is DBNull)) imagen.Url = (string)Database.Reader["ImagenURL"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) imagen.Descripcion = (string)Database.Reader["Descripcion"];

                    lista.Add(imagen);
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

        public long Guardar(Imagen imagen)
        {
            Database = new NegocioDB();
            long idImagen = -1;
            long IDProducto = imagen.IDProducto;
            string urlImagen = imagen.Url;
            string descripcion = imagen.Descripcion;
            string query = $"INSERT INTO IMAGENES(ID_Producto, ImagenURL, Descripcion) VALUES(@IDProducto, @ImagenURL, @Descripcion); SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            try
            {
                Database.SetParam("@IDProducto", IDProducto);
                Database.SetParam("@ImagenURL", urlImagen);
                Database.SetParam("@Descripcion", descripcion);
                Database.SetQuery(query);
                Database.Read();

                if (Database.Reader.Read())
                {
                    idImagen = (int)Database.Reader["ID"];
                }

                return idImagen;
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

        public int Modificar(long idImagen, string url, string descripcion)
        {
            Database = new NegocioDB();
            string query = "UPDATE IMAGENES SET ImagenURL = @Url, Descripcion = @Descripcion  WHERE ID_Imagen = @IDImagen";
            try
            {
                int rowsAffected = 0;
                Database.SetParam("@Url", url);
                Database.SetParam("@IDImagen", idImagen);
                Database.SetParam("@Descripcion", descripcion);
                Database.SetQuery(query);
                rowsAffected = Database.RunQuery();
                return rowsAffected;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Close();
            }
        }

        public int Eliminar(long IDProductoImagen)
        {
            Database = new NegocioDB();
            string query = "DELETE FROM IMAGENES WHERE ID_Producto = @IDProductoImagen";
            try
            {
                int rowsAffected = 0;
                Database.SetParam("@IDProductoImagen", IDProductoImagen);
                Database.SetQuery(query);
                rowsAffected = Database.RunQuery();
                return rowsAffected;
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

        public bool VerificarUrlImagen(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "HEAD";
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        return response.StatusCode == HttpStatusCode.OK;
                    }
                }
                catch (WebException)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
