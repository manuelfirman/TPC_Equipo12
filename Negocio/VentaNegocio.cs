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


        public long CrearFactura(List<ElementoCarrito> productos)
        {
            Database = new NegocioDB();
            long IDFactura = -1;
            
            try
            {
                Database.SetQuery("INSERT INTO Facturas (Pago, Cancelada) VALUES(0, 0)" + "SELECT CAST(SCOPE_IDENTITY() AS BIGINT) AS ID");
                Database.Read();
                if(Database.Reader.Read())
                {
                    IDFactura = (long)Database.Reader["ID"];

                    this.RegistrarProductosFactura(IDFactura, productos);
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

        public bool RegistrarProductosFactura(long IDFactura, List<ElementoCarrito> productos)
        {
            int registros = productos.Count;
            int rowsAffected = 0;
            try
            {
                
                foreach (ElementoCarrito elemento in productos)
                {
                    Database = new NegocioDB();
                    Database.SetQuery("INSERT INTO Productos_x_Factura(ID_Factura, ID_Producto, Cantidad) VALUES(@ID_Factura, @ID_Producto, @Cantidad)");
                    Database.SetParam("@ID_Factura", IDFactura);
                    Database.SetParam("@ID_Producto", elemento.Producto.IDProducto);
                    Database.SetParam("@Cantidad", elemento.Cantidad);
                    
                    if (Database.RunQuery() == 1) rowsAffected++;

                    Database.Close();
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
            NegocioDB db = new NegocioDB();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<ElementoCarrito> listaProductos = new List<ElementoCarrito>();

            try
            {
                db.SetQuery("SELECT ID_Producto, Cantidad FROM Productos_x_Factura WHERE ID_Factura = @ID_Factura");
                db.SetParam("@ID_Factura", IDFactura);
                db.Read();
                while(db.Reader.Read())
                {
                    long IDProducto = -1;
                    int cantidad = -1;
                    Producto producto = new Producto();
                    ElementoCarrito elemento = new ElementoCarrito();
                    if (!(db.Reader["ID_Producto"] is DBNull)) IDProducto = (long)db.Reader["ID_Producto"];
                    if (!(db.Reader["Cantidad"] is DBNull)) cantidad = (int)db.Reader["Cantidad"];

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
                db.Close();
            }
        }

        public Factura FacturaPorID(long IDFactura)
        {
            NegocioDB db = new NegocioDB();
            Factura factura = new Factura();
            try
            {
                db.SetQuery("SELECT ID_Factura, Pago, Cancelada FROM Facturas WHERE ID_Factura = @ID_Factura");
                db.SetParam("@ID_Factura", IDFactura);
                db.Read();
                if(db.Reader.Read())
                {
                    if (!(db.Reader["ID_Factura"] is DBNull)) factura.IDFactura = (long)db.Reader["ID_Factura"];
                    if (!(db.Reader["Pago"] is DBNull)) factura.Pago = (bool)db.Reader["Pago"];
                    if (!(db.Reader["Cancelada"] is DBNull)) factura.Cancelada = (bool)db.Reader["Cancelada"];

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
                db.Close();
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

        public EstadoVenta ObtenerEstadoVenta(string estado)
        {
            Database = new NegocioDB();
            EstadoVenta estadoVenta = new EstadoVenta();
            try
            {
                Database.SetQuery("SELECT ID_Estado, Estado FROM EstadoVenta WHERE Estado = @Estado");
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

        public List<EstadoVenta> ListarEstadosVenta()
        {
            Database = new NegocioDB();
            EstadoVenta estadoVenta;
            List<EstadoVenta> listaEstados = new List<EstadoVenta>();
            try
            {
                Database.SetQuery("SELECT ID_Estado, Estado FROM EstadoVenta");
                Database.Read();
                while (Database.Reader.Read())
                {
                    estadoVenta = new EstadoVenta();
                    if (!(Database.Reader["ID_Estado"] is DBNull)) estadoVenta.IDEstado = (long)Database.Reader["ID_Estado"];
                    if (!(Database.Reader["Estado"] is DBNull)) estadoVenta.Estado = (string)Database.Reader["Estado"];

                    listaEstados.Add(estadoVenta);
                }

                return listaEstados;
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
            NegocioDB db = new NegocioDB();
            EstadoVenta estadoVenta = new EstadoVenta();
            try
            {
                db.SetQuery("SELECT ID_Estado, Estado FROM EstadoVenta WHERE ID_Estado = @ID_Estado");
                db.SetParam("@ID_Estado", IDEstado);
                db.Read();
                if (db.Reader.Read())
                {
                    if (!(db.Reader["ID_Estado"] is DBNull)) estadoVenta.IDEstado = (long)db.Reader["ID_Estado"];
                    if (!(db.Reader["Estado"] is DBNull)) estadoVenta.Estado = (string)db.Reader["Estado"];
                }

                return estadoVenta;
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

        public bool ModificarEstadoVenta(long IDVenta, long IDEstado)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Ventas SET ID_Estado = @Estado WHERE ID_Venta = @ID_Venta");
                Database.SetParam("@ID_Venta", IDVenta);
                Database.SetParam("@Estado", IDEstado);
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

        public long GenerarVenta(long IDFactura, long IDUsuario, decimal monto)
        {
            Database = new NegocioDB();
            long IDVenta = -1;
            try
            {
                EstadoVenta estadoVenta = this.ObtenerEstadoVenta("PAGO PENDIENTE");

                Database.SetQuery("INSERT INTO Ventas(ID_Factura, ID_Usuario, ID_Estado, Monto) VALUES(@ID_Factura, @ID_Usuario, @ID_Estado, @Monto)" + "SELECT CAST(SCOPE_IDENTITY() AS BIGINT) AS ID");
                Database.SetParam("@ID_Factura", IDFactura);
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.SetParam("@ID_Estado", estadoVenta.IDEstado);
                Database.SetParam("@Monto", monto);
                Database.Read();
                if (Database.Reader.Read())
                {
                    IDVenta = (long)Database.Reader["ID"];
                }

                return IDVenta;
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                Database.Close();
            }
        }

        public bool PagoVenta(long IDVenta)
        {
            Database = new NegocioDB();

            try
            {
                Venta venta = this.VentaPorID(IDVenta);

                // Descontar cantidad de productos al stock
                foreach(ElementoCarrito elemento in venta.Factura.Productos)
                {
                    if(!this.DescontarStock(elemento)) return false;
                }

                // Pasar factura a pago = 1
                venta.Factura.Pago = true;
                venta.Factura.Cancelada = false;
                this.ModificarFactura(venta.Factura);

                // Guardar registro de venta
                EstadoVenta estadoVenta = this.ObtenerEstadoVenta("PAGADO");

                Database.SetQuery("UPDATE Ventas SET ID_Estado = @ID_Estado WHERE ID_Venta = @ID_Venta");
                Database.SetParam("@ID_Venta", IDVenta);
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

        public Venta VentaPorID(long IDVenta)
        {
            NegocioDB db = new NegocioDB();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Venta venta = new Venta();

            try
            {
                db.SetQuery("SELECT ID_Venta, ID_Factura, ID_Usuario, ID_Estado, Fecha, Monto FROM Ventas WHERE ID_Venta = @ID_Venta");
                db.SetParam("@ID_Venta", IDVenta);
                db.Read();
                if (db.Reader.Read())
                {
                    venta = new Venta();
                    long IDFactura = -1;
                    long IDUsuario = -1;
                    long IDEstado = -1;

                    if (!(db.Reader["ID_Factura"] is DBNull)) IDFactura = (long)db.Reader["ID_Factura"];
                    if (!(db.Reader["ID_Usuario"] is DBNull)) IDUsuario = (long)db.Reader["ID_Usuario"];
                    if (!(db.Reader["ID_Estado"] is DBNull)) IDEstado = (long)db.Reader["ID_Estado"];

                    if (!(db.Reader["ID_Venta"] is DBNull)) venta.IDVenta = (long)db.Reader["ID_Venta"];
                    if (!(db.Reader["Fecha"] is DBNull)) venta.Fecha = (DateTime)db.Reader["Fecha"];
                    if (!(db.Reader["Monto"] is DBNull)) venta.Monto = (decimal)db.Reader["Monto"];

                    if (IDFactura != -1 && IDUsuario != -1 && IDEstado != -1)
                    {
                        venta.Factura = this.FacturaPorID(IDFactura);
                        venta.Usuario = usuarioNegocio.UsuarioPorID(IDUsuario);
                        venta.Estado = this.EstadoVentaPorID(IDEstado);
                    }
                }

                return venta;
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

        public List<Venta> ListarVentas()
        {
            NegocioDB db = new NegocioDB();
            DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
            List<Venta> listaVentas = new List<Venta>();
            Venta venta;

            try
            {
                db.SetQuery("SELECT V.ID_Venta, V.ID_Usuario, V.ID_Estado, EV.Estado as EstadoVenta, V.Monto, V.Fecha, F.Cancelada, F.Pago, F.ID_Factura, U.ID_Usuario, U.ID_TipoUsuario, TU.Nombre AS TipoUsuario, U.Dni, U.Nombre, U.Apellido, U.Email, U.Telefono, U.FechaNacimiento, U.Estado AS EstadoUsuario, D.ID_Domicilio, D.Localidad, D.Calle, D.Numero, D.CodigoPostal, D.Piso, D.Referencia, D.Alias, D.Estado AS EstadoDomicilio, P.ID_Provincia, P.Nombre as Provincia FROM Ventas V INNER JOIN Facturas F ON V.ID_Factura = F.ID_Factura INNER JOIN Usuarios U ON V.ID_Usuario = U.ID_Usuario INNER JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo INNER JOIN EstadoVenta EV ON V.ID_Estado = EV.ID_Estado INNER JOIN Domicilios D ON U.ID_Usuario = D.ID_Usuario INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia");
                db.Read();

                while(db.Reader.Read())
                {
                    venta = new Venta();
                    // Venta
                    if (!(db.Reader["ID_Venta"] is DBNull)) venta.IDVenta = (long)db.Reader["ID_Venta"];
                    if (!(db.Reader["Fecha"] is DBNull)) venta.Fecha = (DateTime)db.Reader["Fecha"];
                    if (!(db.Reader["Monto"] is DBNull)) venta.Monto = (decimal)db.Reader["Monto"];

                    if (!(db.Reader["EstadoVenta"] is DBNull)) venta.Estado.Estado = (string)db.Reader["EstadoVenta"];
                    if (!(db.Reader["ID_Estado"] is DBNull)) venta.Estado.IDEstado = (long)db.Reader["ID_Estado"];

                    // Factura
                    if (!(db.Reader["ID_Factura"] is DBNull)) venta.Factura.IDFactura = (long)db.Reader["ID_Factura"];
                    if (!(db.Reader["Pago"] is DBNull)) venta.Factura.Pago = (bool)db.Reader["Pago"];
                    if (!(db.Reader["Cancelada"] is DBNull)) venta.Factura.Cancelada = (bool)db.Reader["Cancelada"];

                    // Productos Factura
                    venta.Factura.Productos = this.ProductosFactura(venta.Factura.IDFactura);   

                    // Usuario
                    if (!(db.Reader["ID_Usuario"] is DBNull)) venta.Usuario.IDUsuario = (long)db.Reader["ID_Usuario"];
                    if (!(db.Reader["Dni"] is DBNull)) venta.Usuario.DNI = (string)db.Reader["Dni"];
                    if (!(db.Reader["Nombre"] is DBNull)) venta.Usuario.Nombre = (string)db.Reader["Nombre"];
                    if (!(db.Reader["Apellido"] is DBNull)) venta.Usuario.Apellido = (string)db.Reader["Apellido"];
                    if (!(db.Reader["Telefono"] is DBNull)) venta.Usuario.Telefono = (string)db.Reader["Telefono"];
                    if (!(db.Reader["Email"] is DBNull)) venta.Usuario.Email = (string)db.Reader["Email"];
                    if (!(db.Reader["FechaNacimiento"] is DBNull)) venta.Usuario.FechaNacimiento = (DateTime)db.Reader["FechaNacimiento"];
                    if (!(db.Reader["EstadoUsuario"] is DBNull)) venta.Usuario.Estado = (bool)db.Reader["EstadoUsuario"];

                    // Tipo usuario Usuario
                    if (!(db.Reader["ID_TipoUsuario"] is DBNull)) venta.Usuario.TipoUser.IDTipo = (long)db.Reader["ID_TipoUsuario"];
                    if (!(db.Reader["TipoUsuario"] is DBNull)) venta.Usuario.TipoUser.Nombre = (string)db.Reader["TipoUsuario"];

                    // Domicilio Usuario
                    venta.Usuario.Domicilios = new List<Domicilio>
                    {
                        new Domicilio()
                    };

                    if (!(db.Reader["ID_Usuario"] is DBNull)) venta.Usuario.Domicilios[0].IDUsuario = (long)db.Reader["ID_Usuario"];
                    if (!(db.Reader["ID_Domicilio"] is DBNull)) venta.Usuario.Domicilios[0].IDDomicilio = (long)db.Reader["ID_Domicilio"];
                    if (!(db.Reader["ID_Provincia"] is DBNull)) venta.Usuario.Domicilios[0].Provincia.IDProvincia = (long)db.Reader["ID_Provincia"];
                    if (!(db.Reader["Provincia"] is DBNull)) venta.Usuario.Domicilios[0].Provincia.Nombre = (string)db.Reader["Provincia"];
                    if (!(db.Reader["Localidad"] is DBNull)) venta.Usuario.Domicilios[0].Localidad = (string)db.Reader["Localidad"];
                    if (!(db.Reader["Calle"] is DBNull)) venta.Usuario.Domicilios[0].Calle = (string)db.Reader["Calle"];
                    if (!(db.Reader["Numero"] is DBNull)) venta.Usuario.Domicilios[0].Altura = (string)db.Reader["Numero"];
                    if (!(db.Reader["CodigoPostal"] is DBNull)) venta.Usuario.Domicilios[0].CodigoPostal = (string)db.Reader["CodigoPostal"];
                    if (!(db.Reader["Piso"] is DBNull)) venta.Usuario.Domicilios[0].Piso = (string)db.Reader["Piso"];
                    if (!(db.Reader["Referencia"] is DBNull)) venta.Usuario.Domicilios[0].Referencia = (string)db.Reader["Referencia"];
                    if (!(db.Reader["Alias"] is DBNull)) venta.Usuario.Domicilios[0].Alias = (string)db.Reader["Alias"];
                    if (!(db.Reader["EstadoDomicilio"] is DBNull)) venta.Usuario.Domicilios[0].Estado = (bool)db.Reader["EstadoDomicilio"];

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

                db.Close();
            }
        }

        //public List<Venta> VentasPorUsuario(long IDUsuario)
        //{
        //    NegocioDB db = new NegocioDB();
        //    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        //    List<Venta> listaVentas = new List<Venta>();
        //    Venta venta;

        //    try
        //    {
        //        db.SetQuery("SELECT ID_Venta, ID_Factura, ID_Usuario, ID_Estado, Fecha FROM Ventas WHERE ID_Usuario = @ID_Usuario");
        //        db.SetParam("@ID_Usuario", IDUsuario);
        //        db.Read();
        //        while (db.Reader.Read())
        //        {
        //            venta = new Venta();
        //            long IDFactura = -1;
        //            long IDUser = -1;
        //            long IDEstado = -1;

        //            if (!(db.Reader["ID_Factura"] is DBNull)) IDFactura = (long)db.Reader["ID_Factura"];
        //            if (!(db.Reader["ID_Usuario"] is DBNull)) IDUser = (long)db.Reader["ID_Usuario"];
        //            if (!(db.Reader["ID_Estado"] is DBNull)) IDEstado = (long)db.Reader["ID_Estado"];

        //            if (!(db.Reader["ID_Venta"] is DBNull)) venta.IDVenta = (long)db.Reader["ID_Venta"];
        //            if (!(db.Reader["Fecha"] is DBNull)) venta.Fecha = (DateTime)db.Reader["Fecha"];

        //            if (IDFactura != -1) venta.Factura = this.FacturaPorID(IDFactura);
        //            if (IDUser != -1) venta.Usuario = usuarioNegocio.UsuarioPorID(IDUser);
        //            if (IDEstado != -1) venta.Estado = this.EstadoVentaPorID(IDEstado);

        //            listaVentas.Add(venta);
        //        }
        //        return listaVentas;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}

    }
}
