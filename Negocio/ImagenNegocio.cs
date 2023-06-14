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
            NegocioDB db = new NegocioDB();
            string query = $"INSERT INTO IMAGENES(ID_Producto, ImagenURL, Descripcion) VALUES(@IDProducto, @ImagenURL, @Descripcion); SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            try
            {
                db.SetParam("@IDProducto", IDProducto);
                db.SetParam("@ImagenURL", urlImagen);
                db.SetParam("@Descripcion", descripcion);
                db.SetQuery(query);
                db.Read();

                if (db.Reader.Read())
                {
                    idImagen = (int)db.Reader["ID"];
                }

                return idImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
            }
        }

        public int Modificar(int idImagen, string url, string descripcion)
        {
            NegocioDB db = new NegocioDB();
            string query = "UPDATE IMAGENES SET ImagenURL = @Url, Descripcion = @Descripcion  WHERE ID_Imagen = @IDImagen";
            int rowsAffected = 0;
            try
            {
                db.SetParam("@Url", url);
                db.SetParam("@IDImagen", idImagen);
                db.SetParam("@Descripcion", descripcion);
                db.SetQuery(query);
                rowsAffected = db.RunQuery();
                return rowsAffected;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
        public int Eliminar(int IDProductoImagen)
        {
            NegocioDB db = new NegocioDB();
            string query = "DELETE FROM IMAGENES WHERE ID_Producto = @IDProductoImagen";
            int rowsAffected = 0;
            try
            {
                db.SetParam("@IDProductoImagen", IDProductoImagen);
                db.SetQuery(query);
                rowsAffected = db.RunQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Imagen> ImagenesProducto(int IDProducto)
        {
            NegocioDB db = new NegocioDB();
            string query = "SELECT ID_Producto, ImagenURL, ID_Imagen, Descripcion, Estado FROM IMAGENES WHERE ID_Producto = @IDProducto";
            List<Imagen> imagenes = new List<Imagen>();

            try
            {
                db.SetParam("@IDProducto", IDProducto);
                db.SetQuery(query);
                db.Read();
                while (db.Reader.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.IDImagen = (int)db.Reader["ID_Imagen"];
                    imagen.Url = (string)db.Reader["ImagenURL"];
                    imagen.IDProducto = (int)db.Reader["ID_Producto"];
                    imagen.Descripcion = (string)db.Reader["Descripcion"];
                    imagen.Estado = (bool)db.Reader["Estado"];
                    imagenes.Add(imagen);
                }

                return imagenes;
            }
            catch (Exception ex)
            {
                throw ex;
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
