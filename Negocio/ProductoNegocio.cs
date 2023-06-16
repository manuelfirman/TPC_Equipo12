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

            database.Close();
            return lista;
        }

        public List<Producto> ProductosAlAzar(int cantidad)
        {
            NegocioDB database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
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

            database.Close();
            return lista;
        }


       public List<Producto> listarPorTipo(string nombre, string tipo) {
            NegocioDB database = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            if(tipo == "Marca")
            {
                database.StoreProcedure("SP_ProductosPorMarca");
                database.SetParam("@Marca", nombre);
            }
            else
            {
                database.StoreProcedure("SP_ProductosPorCategoria");
                database.SetParam("@Categoria", nombre);
            }
            database.Read();
            while(database.Reader.Read()) {
                Producto auxProducto = new Producto();

                int IDProducto = (int)database.Reader["IDProducto"];
                auxProducto.IDProducto = IDProducto;
                if (!(database.Reader["Codigo"] is DBNull)) auxProducto.Codigo = (string)database.Reader["Codigo"];
                if (!(database.Reader["Nombre"] is DBNull)) auxProducto.Nombre = (string)database.Reader["Nombre"];
                if (!(database.Reader["Descripcion"] is DBNull)) auxProducto.Descripcion = (string)database.Reader["Descripcion"];
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

    } 
}

