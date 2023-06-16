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
        public List<Producto> ListarTodosLosProductos()
        {
            NegocioDB database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            try
            {
                database.StoreProcedure("SP_ListarTodosLosProductos");
                database.Read();
                while (database.Reader.Read())
                {
                    Producto auxProducto = new Producto();

                    int IDProducto = (int)database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)database.Reader["Codigo"];
                    if (!(database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)database.Reader["Nombre"];
                    if (!(database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)database.Reader["Descripcion"];
                    if (!(database.Reader["Stock"] is DBNull)) auxProducto.Stock = (int)database.Reader["Stock"];
                    if (!(database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)database.Reader["Estado"];
                    if (!(database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)database.Reader["Precio"];
                    auxProducto.Precio = Math.Round(auxProducto.Precio);

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);


                    if (!(database.Reader["IDMarca"] is DBNull))
                    {
                        auxProducto.Marca = new Marca();
                        auxProducto.Marca.Nombre = (string)database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (int)database.Reader["IDMarca"];
                    }

                    if (!(database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria = new Categoria();
                        auxProducto.Categoria.Nombre = (string)database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (int)database.Reader["IDCategoria"];
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
                database.Close();
            }
        }

        public List<Producto> ProductosAlAzar(int cantidad)
        {
            NegocioDB database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            try
            {
                database.StoreProcedure("SP_ProductosAlAzar");
                database.SetParam("@Cantidad", cantidad);
                database.Read();
                while (database.Reader.Read())
                {
                    Producto auxProducto = new Producto();

                    int IDProducto = (int)database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)database.Reader["Codigo"];
                    if (!(database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)database.Reader["Nombre"];
                    if (!(database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)database.Reader["Descripcion"];
                    if (!(database.Reader["Stock"] is DBNull)) auxProducto.Stock = (int)database.Reader["Stock"];
                    if (!(database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)database.Reader["Estado"];
                    if (!(database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)database.Reader["Precio"];
                    auxProducto.Precio = Math.Round(auxProducto.Precio, 2);

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);


                    if (!(database.Reader["IDMarca"] is DBNull))
                    {
                        auxProducto.Marca = new Marca();
                        auxProducto.Marca.Nombre = (string)database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (int)database.Reader["IDMarca"];
                    }

                    if (!(database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria = new Categoria();
                        auxProducto.Categoria.Nombre = (string)database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (int)database.Reader["IDCategoria"];
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
                database.Close();
            }
        }

        public Producto ProductoPorID(int IDProductoIn)
        {
            NegocioDB database = new NegocioDB();
            Producto auxProducto = new Producto();
            try
            {
                database.StoreProcedure("SP_ProductoPorID");
                database.SetParam("@IDProducto", IDProductoIn);
                database.Read();
                if (database.Reader.Read())
                {
                    int IDProducto = (int)database.Reader["IDProducto"];
                    auxProducto.IDProducto = IDProducto;
                    if (!(database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)database.Reader["Codigo"];
                    if (!(database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)database.Reader["Nombre"];
                    if (!(database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)database.Reader["Descripcion"];
                    if (!(database.Reader["Stock"] is DBNull)) auxProducto.Stock = (int)database.Reader["Stock"];
                    if (!(database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)database.Reader["Estado"];
                    if (!(database.Reader["Precio"] is DBNull)) auxProducto.Precio = (decimal)database.Reader["Precio"];
                    auxProducto.Precio = Math.Round(auxProducto.Precio);

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    auxProducto.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);


                    if (!(database.Reader["IDMarca"] is DBNull))
                    {
                        auxProducto.Marca = new Marca();
                        auxProducto.Marca.Nombre = (string)database.Reader["Marca"];
                        auxProducto.Marca.IDMarca = (int)database.Reader["IDMarca"];
                    }

                    if (!(database.Reader["IDCategoria"] is DBNull))
                    {
                        auxProducto.Categoria = new Categoria();
                        auxProducto.Categoria.Nombre = (string)database.Reader["Categoria"];
                        auxProducto.Categoria.IDCategoria = (int)database.Reader["IDCategoria"];
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
                database.Close();
            }
        }



    } 
}

