using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        private NegocioDB Database { get; set; }

        public List<Producto> ListarTodosLosProductos()
        {
            Database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto auxProducto;

            try
            {
                Database.StoreProcedure("SP_ListarTodosLosProductos");
                Database.Read();
                while (Database.Reader.Read())
                {
                    auxProducto = new Producto();
                    long IDProducto = (long)Database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(Database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)Database.Reader["Codigo"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)Database.Reader["Descripcion"];
                    if (!(Database.Reader["Stock"] is DBNull)) auxProducto.Stock = (int)Database.Reader["Stock"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)Database.Reader["Estado"];
                    if (!(Database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)Database.Reader["Precio"];

                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);

                    if (!(Database.Reader["IDMarca"] is DBNull))
                    {
                        auxProducto.Marca.Nombre = (string)Database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (long)Database.Reader["IDMarca"];
                    }

                    if (!(Database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria.Nombre = (string)Database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (long)Database.Reader["IDCategoria"];
                    }

                    lista.Add(auxProducto);
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

        public List<Producto> ProductosAlAzar(int cantidad)
        {
            Database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto auxProducto;

            try
            {
                Database.StoreProcedure("SP_ProductosAlAzar");
                Database.SetParam("@Cantidad", cantidad);
                Database.Read();
                while (Database.Reader.Read())
                {
                    auxProducto = new Producto();

                    long IDProducto = (long)Database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(Database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)Database.Reader["Codigo"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)Database.Reader["Descripcion"];
                    if (!(Database.Reader["Stock"] is DBNull)) auxProducto.Stock = (int)Database.Reader["Stock"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)Database.Reader["Estado"];
                    if (!(Database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)Database.Reader["Precio"];

                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);

                    if (!(Database.Reader["IDMarca"] is DBNull))
                    {

                        auxProducto.Marca.Nombre = (string)Database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (long)Database.Reader["IDMarca"];
                    }

                    if (!(Database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria.Nombre = (string)Database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (long)Database.Reader["IDCategoria"];
                    }

                    lista.Add(auxProducto);
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

        public Producto ProductoPorID(long IDProductoIn)
        {
            Database = new NegocioDB();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto auxProducto = new Producto();

            try
            {
                Database.StoreProcedure("SP_ProductoPorID");
                Database.SetParam("@IDProducto", IDProductoIn);
                Database.Read();
                if (Database.Reader.Read())
                {
                    long IDProducto = (long)Database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(Database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)Database.Reader["Codigo"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)Database.Reader["Descripcion"];
                    if (!(Database.Reader["Stock"] is DBNull)) auxProducto.Stock = (int)Database.Reader["Stock"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)Database.Reader["Estado"];
                    if (!(Database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)Database.Reader["Precio"];

                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);


                    if (!(Database.Reader["IDMarca"] is DBNull))
                    {
                        auxProducto.Marca.Nombre = (string)Database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (long)Database.Reader["IDMarca"];
                    }

                    if (!(Database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria.Nombre = (string)Database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (long)Database.Reader["IDCategoria"];
                    }

                }
                return auxProducto;
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

        public List<Producto> ListarPorTipo(string nombre, string tipo)
        {
            Database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto auxProducto;
            
            try
            {
                if (tipo == "Marca")
                {
                    Database.StoreProcedure("SP_ProductosPorMarca");
                    Database.SetParam("@Marca", nombre);
                }
                else
                {
                    Database.StoreProcedure("SP_ProductosPorCategoria");
                    Database.SetParam("@Categoria", nombre);
                }
                Database.Read();
                while (Database.Reader.Read())
                {
                    auxProducto = new Producto();

                    long IDProducto = (long)Database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(Database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)Database.Reader["Codigo"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)Database.Reader["Descripcion"];
                    if (!(Database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)Database.Reader["Precio"];

                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);

                    if (!(Database.Reader["IDMarca"] is DBNull))
                    {
                        auxProducto.Marca.Nombre = (string)Database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (long)Database.Reader["IDMarca"];
                    }

                    if (!(Database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria.Nombre = (string)Database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (long)Database.Reader["IDCategoria"];
                    }

                    lista.Add(auxProducto);
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

        public bool AgregarProducto(Producto producto)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"INSERT INTO Productos (ID_Categoria, ID_Marca, Codigo, Nombre, Descripcion, Precio, Stock, Estado) VALUES(@ID_Categoria, @ID_Marca, @Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Estado)");
                db.SetParam("@ID_Categoria", producto.Categoria.IDCategoria);
                db.SetParam("@ID_Marca", producto.Marca.IDMarca);
                db.SetParam("@Codigo", producto.Codigo);
                db.SetParam("@Nombre", producto.Nombre);
                db.SetParam("@Descripcion", producto.Descripcion);
                db.SetParam("@Precio", producto.Precio);
                db.SetParam("@Stock", producto.Stock);
                db.SetParam("@Estado", 1);
                if (db.RunQuery() == 1) return true;
                else return false;
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

        public bool ModificarProducto(Producto producto)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"UPDATE Productos SET ID_Categoria = @ID_Categoria, ID_Marca = @ID_Marca, Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, Estado = @Estado");
                db.SetParam("@ID_Categoria", producto.Categoria.IDCategoria);
                db.SetParam("@ID_Marca", producto.Marca.IDMarca);
                db.SetParam("@Codigo", producto.Codigo);
                db.SetParam("@Nombre", producto.Nombre);
                db.SetParam("@Descripcion", producto.Descripcion);
                db.SetParam("@Precio", producto.Precio);
                db.SetParam("@Stock", producto.Stock);
                db.SetParam("@Estado", 1);
                if (db.RunQuery() == 1) return true;
                else return false;
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

        public bool EstadoProducto(long ID_Producto, bool Estado)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"UPDATE Productos SET Estado = @Estado WHERE ID_Producto = @ID_Producto");
                db.SetParam("@Estado", Estado);
                db.SetParam("@ID_Producto", ID_Producto);
                if (db.RunQuery() == 1) return true;
                else return false;
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

        public bool EliminarProducto(long IDProducto)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"DELETE FROM Productos WHERE ID_Producto = @ID_Producto");
                db.SetParam("@ID_Producto", IDProducto);
                if (db.RunQuery() == 1) return true;
                else return false;
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

        public bool AgregarImagenes(Producto producto)
        {
            NegocioDB dB = new NegocioDB();
            int cantidad = producto.Imagenes.Count;
            int columnasAfectadas = 0;
            try
            {
                foreach (Imagen imagen in producto.Imagenes)
                {
                    dB.SetQuery($"INSERT INTO Imagenes (ID_Producto, ImagenURL, Descripcion, Estado) VALUES(@ID_Producto, @ImagenURL, @Descripcion, @Estado)");
                    dB.SetParam("@ID_Producto", producto.IDProducto);
                    dB.SetParam("@ImagenURL", imagen.Url);
                    dB.SetParam("@Descripcion", imagen.Descripcion);
                    dB.SetParam("@Estado", 1);
                    if (dB.RunQuery() == 1) columnasAfectadas++;
                }

                if (columnasAfectadas == cantidad) return true;
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dB.Close();
            }
        }

        public bool ModificarImagenes(Producto producto)
        {
            NegocioDB dB = new NegocioDB();
            int cantidad = producto.Imagenes.Count;
            int columnasAfectadas = 0;
            try
            {
                foreach (Imagen imagen in producto.Imagenes)
                {
                    dB.SetQuery($"UPDATE Imagenes SET ID_Producto = @ID_Producto, ImagenURL = @ImagenURL, Descripcion = @Descripcion, Estado = @Estado WHERE ID_Imagen = @ID_Imagen)");
                    dB.SetParam("@ID_Imagen", imagen.IDImagen);
                    dB.SetParam("@ID_Producto", producto.IDProducto);
                    dB.SetParam("@ImagenURL", imagen.Url);
                    dB.SetParam("@Descripcion", imagen.Descripcion);
                    dB.SetParam("@Estado", 1);
                    if (dB.RunQuery() == 1) columnasAfectadas++;
                }

                if (columnasAfectadas == cantidad) return true;
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dB.Close();
            }
        }

        public bool EstadoImagen(long ID_Imagen, bool Estado)
        {
            NegocioDB dB = new NegocioDB();
            try
            {
                dB.SetQuery($"UPDATE Imagenes SET Estado = @Estado WHERE ID_Imagen = @ID_Imagen)");
                dB.SetParam("@ID_Imagen", ID_Imagen);
                dB.SetParam("@Estado", Estado);
                if (dB.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dB.Close();
            }
        }

        public bool EliminarImagen(long ID_Imagen)
        {
            NegocioDB dB = new NegocioDB();
            try
            {
                dB.SetQuery($"DELETE FROM Imagenes WHERE ID_Imagen = @ID_Imagen)");
                dB.SetParam("@ID_Imagen", ID_Imagen);
                if (dB.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dB.Close();
            }
        }
    }
}

