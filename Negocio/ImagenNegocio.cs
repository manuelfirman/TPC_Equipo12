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
        public int Guardar(Imagen imagen)
        {
            int idImagen = -1;
            int IDProducto = imagen.IDProducto;
            string urlImagen = imagen.Url;
            string descripcion = imagen.Descripcion;
            NegocioDB database = new NegocioDB();
            string query = $"INSERT INTO IMAGENES(ID_Producto, ImagenURL, Descripcion) VALUES(@IDProducto, @ImagenURL, @Descripcion); SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            try
            {
                database.SetParam("@IDProducto", IDProducto);
                database.SetParam("@ImagenURL", urlImagen);
                database.SetParam("@Descripcion", descripcion);
                database.SetQuery(query);
                database.Read();

                if (database.Reader.Read())
                {
                    idImagen = (int)database.Reader["ID"];
                }

                return idImagen;
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

        public int Modificar(int idImagen, string url, string descripcion)
        {
            NegocioDB database = new NegocioDB();
            string query = "UPDATE IMAGENES SET ImagenURL = @Url, Descripcion = @Descripcion  WHERE ID_Imagen = @IDImagen";
            int rowsAffected = 0;
            try
            {
                database.SetParam("@Url", url);
                database.SetParam("@IDImagen", idImagen);
                database.SetParam("@Descripcion", descripcion);
                database.SetQuery(query);
                rowsAffected = database.RunQuery();
                return rowsAffected;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                database.Close();
            }
        }

        public int Eliminar(int IDProductoImagen)
        {
            NegocioDB database = new NegocioDB();
            string query = "DELETE FROM IMAGENES WHERE ID_Producto = @IDProductoImagen";
            int rowsAffected = 0;
            try
            {
                database.SetParam("@IDProductoImagen", IDProductoImagen);
                database.SetQuery(query);
                rowsAffected = database.RunQuery();
                return rowsAffected;
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

        public List<Imagen> ImagenesProducto(int IDProducto)
        {
            NegocioDB database = new NegocioDB();
            string query = "SELECT ID_Producto, ImagenURL, ID_Imagen, Descripcion, Estado FROM IMAGENES WHERE ID_Producto = @IDProducto";
            List<Imagen> imagenes = new List<Imagen>();

            try
            {
                database.SetParam("@IDProducto", IDProducto);
                database.SetQuery(query);
                database.Read();
                while (database.Reader.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.IDImagen = (int)database.Reader["ID_Imagen"];
                    imagen.Url = (string)database.Reader["ImagenURL"];
                    imagen.IDProducto = (int)database.Reader["ID_Producto"];
                    imagen.Descripcion = (string)database.Reader["Descripcion"];
                    imagen.Estado = (bool)database.Reader["Estado"];
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
                database.Close();
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

        public List<Imagen> ImagenesAlAzar(int cantidad)
        {
            NegocioDB database = new NegocioDB();
            List<Imagen> lista = new List<Imagen>();
            try
            {
                database.StoreProcedure("SP_ImagenesAlAzar");
                database.SetParam("@Cantidad", cantidad);
                database.Read();
                while (database.Reader.Read())
                {
                    Imagen imagen = new Imagen();
                    if (!(database.Reader["ID_Producto"] is DBNull)) imagen.IDProducto = (int)database.Reader["ID_Producto"];
                    if (!(database.Reader["ID_Imagen"] is DBNull)) imagen.IDImagen = (int)database.Reader["ID_Imagen"];
                    if (!(database.Reader["ImagenURL"] is DBNull)) imagen.Url = (string)database.Reader["ImagenURL"];
                    if (!(database.Reader["Descripcion"] is DBNull)) imagen.Descripcion = (string)database.Reader["Descripcion"];

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
                database.Close();
            }
        }
    }
}
