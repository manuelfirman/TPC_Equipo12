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
            NegocioDB db = new NegocioDB();
            List<Producto> lista = new List<Producto>();
            db.StoreProcedure("SP_ListarTodosLosProductos");
            while (db.Reader.Read())
            {
                Producto aux = new Producto();

                int IDProducto = (int)db.Reader["IDProducto"];
                aux.IDProducto = IDProducto;
                if (!(db.Reader["Codigo"] is DBNull)) aux.Codigo = (string)db.Reader["Codigo"];
                if (!(db.Reader["Nombre"] is DBNull)) aux.Nombre = (string)db.Reader["Nombre"];
                if (!(db.Reader["Descripcion"] is DBNull)) aux.Descripcion = (string)db.Reader["Descripcion"];
                if (!(db.Reader["Precio"] is DBNull)) aux.Precio = (decimal)db.Reader["Precio"];
                aux.Precio = Math.Round(aux.Precio);

                ImagenNegocio imagenNegocio = new ImagenNegocio();
                aux.Imagenes = imagenNegocio.ImagenesProducto(IDProducto);


                if (!(db.Reader["IDMarca"] is DBNull))
                {
                    aux.Marca = new Marca();
                    aux.Marca.Nombre = (string)db.Reader["Marca"];
                    aux.Marca.IDMarca = (int)db.Reader["IDMarca"];

                }

                if (!(db.Reader["IDCategoria"] is DBNull))
                {
                    aux.Categoria = new Categoria();
                    aux.Categoria.Nombre = (string)db.Reader["Categoria"];
                    aux.Categoria.IDCategoria = (int)db.Reader["IDCategoria"];
                }

                lista.Add(aux);
            }

            db.Close();
            return lista;
        }


    }
}
