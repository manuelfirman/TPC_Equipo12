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
            return true;
        }

        public bool ModificarProducto(Producto producto)
        {
            return true;
        }

        public bool EliminarProducto(long IDProducto)
        {
            return true;
        }
    }
}

