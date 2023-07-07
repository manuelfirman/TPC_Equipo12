using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        private NegocioDB Database { get; set; }


        public long CrearFactura()
        {
            Database = new NegocioDB();
            long IDFactura = -1;
            
            try
            {
                Database.SetQuery("INSERT INTO Facturas (Pago, Cancelada) VALUES(0, 0)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;");
                Database.Read();
                if(Database.Reader.Read())
                {
                    IDFactura = (long)Database.Reader["ID"];
                }

                return IDFactura;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                Database?.Close();
            }
        }

        public bool RegistrarProductosFactura(Factura factura)
        {
            Database = new NegocioDB();
            int registros = factura.Productos.Count;
            int rowsAffected = 0;
            try
            {
                foreach (ElementoCarrito elemento in factura.Productos)
                {
                    Database.SetQuery("INSERT INTO Productos_x_Factura(ID_Factura, ID_Producto, Cantidad) VALUES(@ID_Factura, @ID_Producto, @Cantidad)");
                    Database.SetParam("@ID_Factura", factura.IDFactura);
                    Database.SetParam("@ID_Producto", elemento.IDElementoCarrito);
                    Database.SetParam("@Cantidad", elemento.Cantidad);
                    
                    if (Database.RunQuery() == 1) rowsAffected++;
                }

                if (rowsAffected == registros) return true;
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

        public List<ElementoCarrito> ProductosFactura(long IDFactura)
        {
            Database = new NegocioDB();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<ElementoCarrito> listaProductos = new List<ElementoCarrito>();


            try
            {
                Database.SetQuery("SELECT ID_Producto, Cantidad FROM Productos_x_Factura WHERE ID_Factura = @ID_Factura");
                Database.SetParam("@ID_Factura", IDFactura);
                Database.Read();
                while(Database.Reader.Read())
                {
                    long IDProducto = -1;
                    int cantidad = -1;
                    Producto producto = new Producto();
                    ElementoCarrito elemento = new ElementoCarrito();
                    if (!(Database.Reader["ID_Producto"] is DBNull)) IDProducto = (long)Database.Reader["ID_Producto"];
                    if (!(Database.Reader["Cantidad"] is DBNull)) cantidad = (int)Database.Reader["Cantidad"];

                    if(cantidad != -1 && IDProducto != -1)
                    {
                        producto = productoNegocio.ProductoPorID(IDProducto);
                        elemento.Producto = producto;
                        elemento.Cantidad = cantidad;
                        listaProductos.Add(elemento);
                    }
                }

                return listaProductos;
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

        public List<Factura> ListarFacturas()
        {
            Database = new NegocioDB();
            List<Factura> listaFacturas = new List<Factura>();
            Factura factura;

            try
            {
                Database.SetQuery("SELECT ID_Factura, Pago, Cancelada FROM Facturas");
                Database.Read();
                while(Database.Reader.Read())
                {
                    factura = new Factura();
                    if (!(Database.Reader["ID_Factura"] is DBNull)) factura.IDFactura = (long)Database.Reader["ID_Factura"];
                    if (!(Database.Reader["Pago"] is DBNull)) factura.Pago = (bool)Database.Reader["Pago"];
                    if (!(Database.Reader["Cancelada"] is DBNull)) factura.Cancelada = (bool)Database.Reader["Cancelada"];

                    factura.Productos = this.ProductosFactura(factura.IDFactura);

                    listaFacturas.Add(factura);
                }


                return listaFacturas;
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

        public bool DescontarStock(ElementoCarrito elemento)
        {
            Database = new NegocioDB();

            try
            {
                return true;
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

        public bool GenerarVenta(long IDFactura)
        {
            return false;
        }


        public List<Venta> ListarVentas()
        {
            return new List<Venta>();
        }









    }
}
