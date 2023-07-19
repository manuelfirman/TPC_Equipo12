using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoDestacadoNegocio
    {
        private NegocioDB Database { get; set; }

        public List<ProductoDestacado> ListarProductos()
        {
            Database = new NegocioDB();
            List<ProductoDestacado> lista = new List<ProductoDestacado>();
            ProductoDestacado destacado;
            try
            {
                Database.SetQuery("SELECT PD.ID_Producto_Destacado, PD.Estado, P.Nombre, P.ID_Producto FROM Productos_Desctacados AS PD INNER JOIN Productos AS P ON PD.ID_Producto = P.ID_Producto");
                Database.Read();
                while (Database.Reader.Read())
                {
                    destacado = new ProductoDestacado();
                    if (!(Database.Reader["ID_Producto_Destacado"] is DBNull)) destacado.IDProductoDestacado= (long)Database.Reader["ID_Producto_Destacado"];
                    if (!(Database.Reader["ID_Producto"] is DBNull)) destacado.IDProducto = (long)Database.Reader["ID_Producto"];
                    if (!(Database.Reader["Estado"] is DBNull)) destacado.Estado = (bool)Database.Reader["Estado"];
                    lista.Add(destacado);
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

        public bool ModificarProductoDestacado(long IDProductoDestacado, ProductoDestacado destacado)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Productos_Desctacados SET ID_Producto = @ID_Producto, Estado = @Estado WHERE ID_Producto_Destacado = @IDProductoDestacado");
                Database.SetParam("@IDProductoDestacado",IDProductoDestacado);
                Database.SetParam("@ID_Producto", destacado.IDProducto);
                Database.SetParam("@Estado", destacado.Estado);
                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                Database.Close();
            }
        }

        public bool AgregarProductoDestacado(ProductoDestacado destacado)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("INSERT INTO Productos_Desctacados(ID_Producto, Estado) VALUES(@ID_Producto, @Estado)");
                
                Database.SetParam("@ID_Producto", destacado.IDProducto);
                Database.SetParam("@Estado", destacado.Estado);
                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                Database.Close();
            }
        }

        public ProductoDestacado ProductoPorID(long IDProductoin)
        {
            Database = new NegocioDB();
            ProductoDestacado auxProducto = new ProductoDestacado();

            try
            {
                Database.SetQuery("SELECT ID_Producto_Destacado, Estado, ID_Producto FROM Productos_Desctacados WHERE ID_Producto = @IDProducto");
                Database.SetParam("@IDProducto", IDProductoin);
                Database.Read();
                if (Database.Reader.Read())
                {
                    long IDProductoDes = (long)Database.Reader["ID_Producto_Destacado"];
                    long IDProducto = (long)Database.Reader["ID_Producto"];
                    auxProducto.IDProductoDestacado = IDProductoDes;
                    auxProducto.IDProducto = IDProducto;
                    if (!(Database.Reader["Estado"] is DBNull)) auxProducto.Estado = (bool)Database.Reader["Estado"];

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
    }
}
