﻿using Dominio;
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

        public bool ModificarFactura(Factura factura)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Facturas SET Pago = @Pago, Cancelada = @Cancelada WHERE ID_Factura = @ID_Factura");
                Database.SetParam("@ID_Factura", factura.IDFactura);
                Database.SetParam("@Pago", factura.Pago);
                Database.SetParam("@Cancelada", factura.Cancelada);
                if (Database.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
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

        public Factura FacturaPorID(long IDFactura)
        {
            Database = new NegocioDB();
            Factura factura = new Factura();
            try
            {
                Database.SetQuery("SELECT ID_Factura, Pago, Cancelada WHERE ID_Factura = @ID_Factura");
                Database.SetParam("@ID_Factura", IDFactura);
                Database.Read();
                if(Database.Reader.Read())
                {
                    if (!(Database.Reader["ID_Factura"] is DBNull)) factura.IDFactura = (long)Database.Reader["ID_Factura"];
                    if (!(Database.Reader["Pago"] is DBNull)) factura.Pago = (bool)Database.Reader["Pago"];
                    if (!(Database.Reader["Cancelada"] is DBNull)) factura.Cancelada = (bool)Database.Reader["Cancelada"];

                    factura.Productos = this.ProductosFactura(IDFactura);
                }

                return factura;
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
            ProductoNegocio productoNegocio = new ProductoNegocio();


            try
            {
                Producto producto = productoNegocio.ProductoPorID(elemento.Producto.IDProducto);
                producto.Stock -= elemento.Cantidad;
                if (producto.Stock < 0) return false;

                Database.SetQuery("UPDATE Productos SET Stock = @Stock WHERE ID_Producto = @ID_Producto");
                Database.SetParam("@ID_Producto", elemento.Producto.IDProducto);
                Database.SetParam("@Stock", producto.Stock);
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

        public EstadoVenta EstadoVenta(string estado)
        {
            Database = new NegocioDB();
            EstadoVenta estadoVenta = new EstadoVenta();
            try
            {
                Database.SetQuery("SELECT ID_Estado, Estado FROM EstadosVenta WHERE Estado = @Estado");
                Database.SetParam("@Estado", estado);
                Database.Read();
                if(Database.Reader.Read())
                {
                    if (!(Database.Reader["ID_Estado"] is DBNull)) estadoVenta.IDEstado = (long)Database.Reader["ID_Estado"];
                    if (!(Database.Reader["Estado"] is DBNull)) estadoVenta.Estado = (string)Database.Reader["Estado"];
                }

                return estadoVenta;
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


        public EstadoVenta EstadoVentaPorID(long IDEstado)
        {
            Database = new NegocioDB();
            EstadoVenta estadoVenta = new EstadoVenta();
            try
            {
                Database.SetQuery("SELECT ID_Estado, Estado FROM EstadosVenta WHERE ID_Estado = @ID_Estado");
                Database.SetParam("@ID_Estado", IDEstado);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["ID_Estado"] is DBNull)) estadoVenta.IDEstado = (long)Database.Reader["ID_Estado"];
                    if (!(Database.Reader["Estado"] is DBNull)) estadoVenta.Estado = (string)Database.Reader["Estado"];
                }

                return estadoVenta;
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

        public bool GenerarVenta(long IDFactura, long IDUsuario)
        {
            Database = new NegocioDB();

            try
            {
                Factura factura = this.FacturaPorID(IDFactura);

                // Descontar cantidad de productos al stock
                foreach(ElementoCarrito elemento in factura.Productos)
                {
                    this.DescontarStock(elemento);
                }

                // Pasar factura a pago = 1
                factura.Pago = true;
                factura.Cancelada = false;
                this.ModificarFactura(factura);

                // Guardar registro de venta
                EstadoVenta estadoVenta = this.EstadoVenta("PAGADO");

                Database.SetQuery("INSERT INTO Ventas(ID_Factura, ID_Usuario, ID_Estado) VALUES(@ID_Factura, @ID_Usuario, @ID_Estado)");
                Database.SetParam("@ID_Factura", IDFactura);
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.SetParam("@ID_Estado", estadoVenta.IDEstado);
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


        public List<Venta> ListarVentas()
        {
            Database = new NegocioDB();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Venta> listaVentas = new List<Venta>();
            Venta venta;

            try
            {
                Database.SetQuery("SELECT ID_Venta, ID_Factura, ID_Usuario, ID_Estado, Fecha FROM Ventas");
                Database.Read();
                while(Database.Reader.Read())
                {
                    venta = new Venta();
                    long IDFactura = -1;
                    long IDUsuario = -1;
                    long IDEstado = -1;

                    if (!(Database.Reader["ID_Factura"] is DBNull)) IDFactura = (long)Database.Reader["ID_Factura"];
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) IDUsuario = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["ID_Estado"] is DBNull)) IDEstado = (long)Database.Reader["ID_Estado"];

                    if (!(Database.Reader["ID_Venta"] is DBNull)) venta.IDVenta = (long)Database.Reader["ID_Venta"];
                    if (!(Database.Reader["Fecha"] is DBNull)) venta.Fecha = (DateTime)Database.Reader["Fecha"];

                    if(IDFactura != -1) venta.Factura = this.FacturaPorID(IDFactura);
                    if(IDUsuario != -1) venta.Usuario = usuarioNegocio.UsuarioPorID(IDUsuario);
                    if(IDEstado != -1) venta.Estado = this.EstadoVentaPorID(IDEstado);

                    listaVentas.Add(venta);
                }
                return listaVentas;
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

        public List<Venta> VentasPorUsuario(long IDUsuario)
        {
            Database = new NegocioDB();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Venta> listaVentas = new List<Venta>();
            Venta venta;

            try
            {
                Database.SetQuery("SELECT ID_Venta, ID_Factura, ID_Usuario, ID_Estado, Fecha FROM Ventas WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.Read();
                while (Database.Reader.Read())
                {
                    venta = new Venta();
                    long IDFactura = -1;
                    long IDUser = -1;
                    long IDEstado = -1;

                    if (!(Database.Reader["ID_Factura"] is DBNull)) IDFactura = (long)Database.Reader["ID_Factura"];
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) IDUser = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["ID_Estado"] is DBNull)) IDEstado = (long)Database.Reader["ID_Estado"];

                    if (!(Database.Reader["ID_Venta"] is DBNull)) venta.IDVenta = (long)Database.Reader["ID_Venta"];
                    if (!(Database.Reader["Fecha"] is DBNull)) venta.Fecha = (DateTime)Database.Reader["Fecha"];

                    if (IDFactura != -1) venta.Factura = this.FacturaPorID(IDFactura);
                    if (IDUser != -1) venta.Usuario = usuarioNegocio.UsuarioPorID(IDUser);
                    if (IDEstado != -1) venta.Estado = this.EstadoVentaPorID(IDEstado);

                    listaVentas.Add(venta);
                }
                return listaVentas;
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