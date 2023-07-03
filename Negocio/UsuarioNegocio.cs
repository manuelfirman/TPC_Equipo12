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
            catch (Exception ex)
            {
                throw ex;
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
                Database.SetQuery("UPDATE TABLE Usuarios SET ID_TipoUsuario = @ID_TipoUsuario, Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, FechaNacimiento = @FechaNacimiento, Estado = @Estado WHERE ID_Usuario = @ID_Usuario");
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
            catch (Exception ex)
            {
                throw ex;
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
                Database.SetQuery("INSERT INTO TABLE Domicilios (ID_Usuario, ID_Provincia, Localidad, Calle, Numero, CodigoPostal, Piso, Referencia, Alias, Estado) VALUES(@ID_Usuario, @ID_Provincia, @Localidad, @Calle, @Numero, @CodigoPostal, @Piso, @Referencia, @Alias, @Estado)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;");
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Database.Close();
            }
        }

        public bool ActualizarDomicilio(long IDUsuario, Domicilio domicilio)
        {
            Database = new NegocioDB();
            DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
            try
            {
                if(domicilioNegocio.DomiciliosUsuario(IDUsuario).Count == 0)
                {
                    if (CrearDomicilio(IDUsuario, domicilio)) return true;
                    else return false;
                }
                else
                {
                    Database.SetQuery("UPDATE Domicilios SET ID_Provincia = @ID_Provincia, Localidad = @Localidad, Calle = @Calle, Numero = @Numero, CodigoPostal = @CodigoPostal, Piso = @Piso, Referencia = @Referencia, Alias = @Alias, Estado = @Estado WHERE ID_Domicilio = @ID_Domicilio");
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
