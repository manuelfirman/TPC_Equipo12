using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private NegocioDB Database { get; set; }
        private Crypt Crypt { get; set; } = new Crypt();

        public Usuario BuscarUsuario(string tipo, string valor)
        {
            Database = new NegocioDB();
            Usuario usuario = new Usuario();
            DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
            try
            {
                Database.SetQuery($"SELECT U.ID_Usuario, U.ID_TipoUsuario, TU.Nombre as TipoUsuario, U.Dni, U.Nombre, U.Apellido, U.Email, U.Telefono, U.FechaNacimiento, U.Estado FROM Usuarios U LEFT JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo WHERE {tipo} = @{tipo}");
                Database.SetParam($"@{tipo}", valor);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) usuario.IDUsuario = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["Dni"] is DBNull)) usuario.DNI = (string)Database.Reader["Dni"];
                    if (!(Database.Reader["Nombre"] is DBNull)) usuario.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Apellido"] is DBNull)) usuario.Apellido = (string)Database.Reader["Apellido"];
                    if (!(Database.Reader["Email"] is DBNull)) usuario.Email = (string)Database.Reader["Email"];
                    if (!(Database.Reader["Telefono"] is DBNull)) usuario.Telefono = (string)Database.Reader["Telefono"];
                    if (!(Database.Reader["FechaNacimiento"] is DBNull)) usuario.FechaNacimiento = (DateTime)Database.Reader["FechaNacimiento"];
                    if (!(Database.Reader["Estado"] is DBNull)) usuario.Estado = (bool)Database.Reader["Estado"];

                    usuario.TipoUser = new TipoUsuario();
                    if (!(Database.Reader["ID_TipoUsuario"] is DBNull)) usuario.TipoUser.IDTipo = (long)Database.Reader["ID_TipoUsuario"];
                    if (!(Database.Reader["TipoUsuario"] is DBNull)) usuario.TipoUser.Nombre = (string)Database.Reader["TipoUsuario"];

                    usuario.Domicilios = new List<Domicilio>();
                    usuario.Domicilios = domicilioNegocio.DomiciliosUsuario(usuario.IDUsuario);

                }

                return usuario;
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

        public Usuario UsuarioPorID(long IDUsuario)
        {
            Database = new NegocioDB();
            Usuario usuario = new Usuario();
            DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
            try
            {
                Database.SetQuery($"SELECT U.ID_Usuario, U.ID_TipoUsuario, TU.Nombre as TipoUsuario, U.Dni, U.Nombre, U.Apellido, U.Email, U.Telefono, U.FechaNacimiento, U.Estado FROM Usuarios U LEFT JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam($"@ID_Usuario", IDUsuario);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) usuario.IDUsuario = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["Dni"] is DBNull)) usuario.DNI = (string)Database.Reader["Dni"];
                    if (!(Database.Reader["Nombre"] is DBNull)) usuario.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Apellido"] is DBNull)) usuario.Apellido = (string)Database.Reader["Apellido"];
                    if (!(Database.Reader["Email"] is DBNull)) usuario.Email = (string)Database.Reader["Email"];
                    if (!(Database.Reader["Telefono"] is DBNull)) usuario.Telefono = (string)Database.Reader["Telefono"];
                    if (!(Database.Reader["FechaNacimiento"] is DBNull)) usuario.FechaNacimiento = (DateTime)Database.Reader["FechaNacimiento"];
                    if (!(Database.Reader["Estado"] is DBNull)) usuario.Estado = (bool)Database.Reader["Estado"];

                    usuario.TipoUser = new TipoUsuario();
                    if (!(Database.Reader["ID_TipoUsuario"] is DBNull)) usuario.TipoUser.IDTipo = (long)Database.Reader["ID_TipoUsuario"];
                    if (!(Database.Reader["TipoUsuario"] is DBNull)) usuario.TipoUser.Nombre = (string)Database.Reader["TipoUsuario"];

                    usuario.Domicilios = new List<Domicilio>();
                    usuario.Domicilios = domicilioNegocio.DomiciliosUsuario(usuario.IDUsuario);

                }

                return usuario;
            }
            catch (Exception)
            {
                return usuario;
            }
            finally
            {
                Database.Close();
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            Database = new NegocioDB();
            List<Usuario> listaUsuarios = new List<Usuario>();
            Usuario usuario;
            DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
            try
            {
                Database.SetQuery($"SELECT U.ID_Usuario, U.ID_TipoUsuario, TU.Nombre as TipoUsuario, U.Dni, U.Nombre, U.Apellido, U.Email, U.Telefono, U.FechaNacimiento, U.Estado FROM Usuarios U INNER JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo");
                Database.Read();
                while (Database.Reader.Read())
                {
                    usuario = new Usuario();
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) usuario.IDUsuario = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["Dni"] is DBNull)) usuario.DNI = (string)Database.Reader["Dni"];
                    if (!(Database.Reader["Nombre"] is DBNull)) usuario.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Apellido"] is DBNull)) usuario.Apellido = (string)Database.Reader["Apellido"];
                    if (!(Database.Reader["Email"] is DBNull)) usuario.Email = (string)Database.Reader["Email"];
                    if (!(Database.Reader["Telefono"] is DBNull)) usuario.Telefono = (string)Database.Reader["Telefono"];
                    if (!(Database.Reader["FechaNacimiento"] is DBNull)) usuario.FechaNacimiento = (DateTime)Database.Reader["FechaNacimiento"];
                    if (!(Database.Reader["Estado"] is DBNull)) usuario.Estado = (bool)Database.Reader["Estado"];

                    usuario.TipoUser = new TipoUsuario();
                    if (!(Database.Reader["ID_TipoUsuario"] is DBNull)) usuario.TipoUser.IDTipo = (long)Database.Reader["ID_TipoUsuario"];
                    if (!(Database.Reader["TipoUsuario"] is DBNull)) usuario.TipoUser.Nombre = (string)Database.Reader["TipoUsuario"];

                    usuario.Domicilios = new List<Domicilio>();
                    usuario.Domicilios = domicilioNegocio.DomiciliosUsuario(usuario.IDUsuario);

                    listaUsuarios.Add(usuario);
                }

                return listaUsuarios;
            }
            catch (Exception)
            {
                return listaUsuarios;
            }
            finally
            {
                Database.Close();
            }
        }

        public bool RegistroUsuario(Usuario usuario)
        {
            Database = new NegocioDB();
            try
            {
                string hashPass = Crypt.GenerarHash(usuario.Contraseña);
                Database.SetQuery($"INSERT INTO Usuarios (ID_TipoUsuario, Dni, Nombre, Apellido, Email, Contrasena) VALUES(@ID_TipoUsuario, @Dni, @Nombre, @Apellido, @Email, @Contrasena)");
                Database.SetParam("@Nombre", usuario.Nombre);
                Database.SetParam("@Apellido", usuario.Apellido);
                Database.SetParam("@Email", usuario.Email);
                Database.SetParam("@Dni", usuario.DNI);
                Database.SetParam("@ID_TipoUsuario", usuario.TipoUser.IDTipo);
                Database.SetParam("@Contrasena", hashPass);

                if (Database.RunQuery() > 0) return true;
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

        public bool LoginUsuario(string email, string password)
        {
            Database = new NegocioDB();
            string hashPass = "";
            try
            {
                Database.SetQuery("SELECT Contrasena FROM Usuarios WHERE Email = @Email");
                Database.SetParam("@Email", email);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["Contrasena"] is DBNull)) hashPass = (string)Database.Reader["Contrasena"];
                }

                if (Crypt.VerificarPassword(password, hashPass)) return true;

                return false;
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

        public bool ActualizarUsuario(Usuario usuario)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Usuarios SET ID_TipoUsuario = @ID_TipoUsuario, Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, FechaNacimiento = @FechaNacimiento, Estado = @Estado WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", usuario.IDUsuario);
                Database.SetParam("@ID_TipoUsuario", usuario.TipoUser.IDTipo);
                Database.SetParam("@Dni", usuario.DNI);
                Database.SetParam("@Nombre", usuario.Nombre);
                Database.SetParam("@Apellido", usuario.Apellido);
                Database.SetParam("@Email", usuario.Email);
                Database.SetParam("@Telefono", usuario.Telefono);
                Database.SetParam("@FechaNacimiento", usuario.FechaNacimiento);
                Database.SetParam("@Estado", usuario.Estado);
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

        public bool CrearDomicilio(long IDUsuario, Domicilio domicilio)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("INSERT INTO Domicilios (ID_Usuario, ID_Provincia, Localidad, Calle, Numero, CodigoPostal, Piso, Referencia, Alias, Estado) VALUES(@ID_Usuario, @ID_Provincia, @Localidad, @Calle, @Numero, @CodigoPostal, @Piso, @Referencia, @Alias, @Estado)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;");
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.SetParam("@ID_Provincia", domicilio.Provincia.IDProvincia);
                Database.SetParam("@Localidad", domicilio.Localidad);
                Database.SetParam("@Calle", domicilio.Calle);
                Database.SetParam("@Numero", domicilio.Altura);
                Database.SetParam("@CodigoPostal", domicilio.CodigoPostal);
                Database.SetParam("@Piso", domicilio.Piso);
                Database.SetParam("@Referencia", domicilio.Referencia);
                Database.SetParam("@Alias", domicilio.Alias);
                Database.SetParam("@Estado", domicilio.Estado);
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

        public bool ActualizarDomicilio(long IDUsuario, Domicilio domicilio)
        {
            Database = new NegocioDB();
            try
            {
                if(domicilio.IDDomicilio == -1)
                {
                    if (CrearDomicilio(IDUsuario, domicilio)) return true;
                    else return false;
                }
                else
                {
                    Database.SetQuery("UPDATE Domicilios SET ID_Provincia = @ID_Provincia, Localidad = @Localidad, Calle = @Calle, Numero = @Numero, CodigoPostal = @CodigoPostal, Piso = @Piso, Referencia = @Referencia, Alias = @Alias, Estado = @Estado WHERE ID_Domicilio = @ID_Domicilio AND ID_Usuario = @ID_Usuario");
                    Database.SetParam("@ID_Domicilio", domicilio.IDDomicilio);
                    Database.SetParam("@ID_Usuario", IDUsuario);
                    Database.SetParam("@ID_Provincia", domicilio.Provincia.IDProvincia);
                    Database.SetParam("@Localidad", domicilio.Localidad);
                    Database.SetParam("@Calle", domicilio.Calle);
                    Database.SetParam("@Numero", domicilio.Altura);
                    Database.SetParam("@CodigoPostal", domicilio.CodigoPostal);
                    Database.SetParam("@Piso", domicilio.Piso);
                    Database.SetParam("@Referencia", domicilio.Referencia);
                    Database.SetParam("@Alias", domicilio.Alias);
                    Database.SetParam("@Estado", domicilio.Estado);
                    if (Database.RunQuery() == 1) return true;
                    else return false;
                }
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

        public bool CambiarContraseña(long IDUsuario, string nuevaContraseña)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Usuarios SET Contrasena = @Contraseña WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.SetParam("@Contraseña", nuevaContraseña);

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

        public bool EstadoUsuario(long IDUsuario, int estado)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Usuarios SET Estado = @Estado WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.SetParam("@Estado", estado);

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

        public bool EliminarUsuario(long IDUsuario)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("DELETE FROM Usuarios WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", IDUsuario);

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

        public Venta UltimaCompra(long IDUsuario)
        {
            Database = new NegocioDB();
            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta venta = new Venta();
            try
            {
                Database.SetQuery("SELECT TOP 1 V.ID_Venta, V.ID_Usuario, V.ID_Estado, EV.Estado as EstadoVenta, V.Monto, V.Fecha, F.Cancelada, F.Pago, F.ID_Factura, U.ID_Usuario, U.ID_TipoUsuario, TU.Nombre AS TipoUsuario, U.Dni, U.Nombre, U.Apellido, U.Email, U.Telefono, U.FechaNacimiento, U.Estado AS EstadoUsuario, D.ID_Domicilio, D.Localidad, D.Calle, D.Numero, D.CodigoPostal, D.Piso, D.Referencia, D.Alias, D.Estado AS EstadoDomicilio, P.ID_Provincia, P.Nombre as Provincia FROM Ventas V INNER JOIN Facturas F ON V.ID_Factura = F.ID_Factura INNER JOIN Usuarios U ON V.ID_Usuario = U.ID_Usuario INNER JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo INNER JOIN EstadoVenta EV ON V.ID_Estado = EV.ID_Estado INNER JOIN Domicilios D ON U.ID_Usuario = D.ID_Usuario INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia WHERE V.ID_Usuario = @ID_Usuario ORDER BY V.Fecha DESC");
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.Read();
                if(Database.Reader.Read())
                {
                    // Venta
                    if (!(Database.Reader["ID_Venta"] is DBNull)) venta.IDVenta = (long)Database.Reader["ID_Venta"];
                    if (!(Database.Reader["Fecha"] is DBNull)) venta.Fecha = (DateTime)Database.Reader["Fecha"];
                    if (!(Database.Reader["Monto"] is DBNull)) venta.Monto = (decimal)Database.Reader["Monto"];

                    if (!(Database.Reader["EstadoVenta"] is DBNull)) venta.Estado.Estado = (string)Database.Reader["EstadoVenta"];
                    if (!(Database.Reader["ID_Estado"] is DBNull)) venta.Estado.IDEstado = (long)Database.Reader["ID_Estado"];

                    // Factura
                    if (!(Database.Reader["ID_Factura"] is DBNull)) venta.Factura.IDFactura = (long)Database.Reader["ID_Factura"];
                    if (!(Database.Reader["Pago"] is DBNull)) venta.Factura.Pago = (bool)Database.Reader["Pago"];
                    if (!(Database.Reader["Cancelada"] is DBNull)) venta.Factura.Cancelada = (bool)Database.Reader["Cancelada"];

                    // Productos Factura
                    venta.Factura.Productos = ventaNegocio.ProductosFactura(venta.Factura.IDFactura);

                    // Usuario
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) venta.Usuario.IDUsuario = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["Dni"] is DBNull)) venta.Usuario.DNI = (string)Database.Reader["Dni"];
                    if (!(Database.Reader["Nombre"] is DBNull)) venta.Usuario.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Apellido"] is DBNull)) venta.Usuario.Apellido = (string)Database.Reader["Apellido"];
                    if (!(Database.Reader["Telefono"] is DBNull)) venta.Usuario.Telefono = (string)Database.Reader["Telefono"];
                    if (!(Database.Reader["Email"] is DBNull)) venta.Usuario.Email = (string)Database.Reader["Email"];
                    if (!(Database.Reader["FechaNacimiento"] is DBNull)) venta.Usuario.FechaNacimiento = (DateTime)Database.Reader["FechaNacimiento"];
                    if (!(Database.Reader["EstadoUsuario"] is DBNull)) venta.Usuario.Estado = (bool)Database.Reader["EstadoUsuario"];

                    // Tipo usuario Usuario
                    if (!(Database.Reader["ID_TipoUsuario"] is DBNull)) venta.Usuario.TipoUser.IDTipo = (long)Database.Reader["ID_TipoUsuario"];
                    if (!(Database.Reader["TipoUsuario"] is DBNull)) venta.Usuario.TipoUser.Nombre = (string)Database.Reader["TipoUsuario"];

                    // Domicilio Usuario
                    venta.Usuario.Domicilios = new List<Domicilio>
                    {
                        new Domicilio()
                    };

                    if (!(Database.Reader["ID_Usuario"] is DBNull)) venta.Usuario.Domicilios[0].IDUsuario = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["ID_Domicilio"] is DBNull)) venta.Usuario.Domicilios[0].IDDomicilio = (long)Database.Reader["ID_Domicilio"];
                    if (!(Database.Reader["ID_Provincia"] is DBNull)) venta.Usuario.Domicilios[0].Provincia.IDProvincia = (long)Database.Reader["ID_Provincia"];
                    if (!(Database.Reader["Provincia"] is DBNull)) venta.Usuario.Domicilios[0].Provincia.Nombre = (string)Database.Reader["Provincia"];
                    if (!(Database.Reader["Localidad"] is DBNull)) venta.Usuario.Domicilios[0].Localidad = (string)Database.Reader["Localidad"];
                    if (!(Database.Reader["Calle"] is DBNull)) venta.Usuario.Domicilios[0].Calle = (string)Database.Reader["Calle"];
                    if (!(Database.Reader["Numero"] is DBNull)) venta.Usuario.Domicilios[0].Altura = (string)Database.Reader["Numero"];
                    if (!(Database.Reader["CodigoPostal"] is DBNull)) venta.Usuario.Domicilios[0].CodigoPostal = (string)Database.Reader["CodigoPostal"];
                    if (!(Database.Reader["Piso"] is DBNull)) venta.Usuario.Domicilios[0].Piso = (string)Database.Reader["Piso"];
                    if (!(Database.Reader["Referencia"] is DBNull)) venta.Usuario.Domicilios[0].Referencia = (string)Database.Reader["Referencia"];
                    if (!(Database.Reader["Alias"] is DBNull)) venta.Usuario.Domicilios[0].Alias = (string)Database.Reader["Alias"];
                    if (!(Database.Reader["EstadoDomicilio"] is DBNull)) venta.Usuario.Domicilios[0].Estado = (bool)Database.Reader["EstadoDomicilio"];
                }

                return venta;
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
