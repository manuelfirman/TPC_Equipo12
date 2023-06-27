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
            try
            {
                Database.SetQuery($"SELECT ID_Usuario, ID_TipoUsuario, TU.Nombre as TipoUsuario, Dni, U.Nombre, Apellido, Email, Telefono, FechaNacimiento, U.Estado, D.ID_Domicilio, D.ID_Provincia as ID_Provincia, P.Nombre as Provincia, D.Localidad, D.Calle, D.Numero, D.CodigoPostal, D.Piso, D.Referencia, D.Alias, D.Estado as EstadoDomicilio FROM Usuarios U LEFT JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo LEFT JOIN Domicilios D ON U.ID_Domicilio = D.ID_Domicilio LEFT JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia WHERE {tipo} = @{tipo}");
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

                    usuario.Domicilio = new Domicilio();
                    if (!(Database.Reader["ID_Domicilio"] is DBNull)) usuario.Domicilio.IDDomicilio = (long)Database.Reader["ID_Domicilio"];
                    if (!(Database.Reader["Localidad"] is DBNull)) usuario.Domicilio.Localidad = (string)Database.Reader["Localidad"];
                    if (!(Database.Reader["Calle"] is DBNull)) usuario.Domicilio.Calle = (string)Database.Reader["Calle"];
                    if (!(Database.Reader["Numero"] is DBNull)) usuario.Domicilio.Altura = (string)Database.Reader["Numero"];
                    if (!(Database.Reader["CodigoPostal"] is DBNull)) usuario.Domicilio.CodigoPostal = (string)Database.Reader["CodigoPostal"];
                    if (!(Database.Reader["Piso"] is DBNull)) usuario.Domicilio.Piso = (string)Database.Reader["Piso"];
                    if (!(Database.Reader["Referencia"] is DBNull)) usuario.Domicilio.Referencia = (string)Database.Reader["Referencia"];
                    if (!(Database.Reader["Alias"] is DBNull)) usuario.Domicilio.Alias = (string)Database.Reader["Alias"];
                    if (!(Database.Reader["EstadoDomicilio"] is DBNull)) usuario.Domicilio.Estado = (bool)Database.Reader["EstadoDomicilio"];
                    usuario.Domicilio.Provincia = new Provincia();
                    if (!(Database.Reader["ID_Provincia"] is DBNull)) usuario.Domicilio.Provincia.IDProvincia = (long)Database.Reader["ID_Provincia"];
                    if (!(Database.Reader["Provincia"] is DBNull)) usuario.Domicilio.Provincia.Nombre = (string)Database.Reader["Provincia"];

                }

                return usuario;
            }
            catch (Exception)
            {

                throw;
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
                Database.SetQuery("UPDATE TABLE Usuarios SET ID_TipoUsuario = @ID_TipoUsuario, ID_Domicilio = @ID_Domicilio, Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Contrasena = @Contraseña, Telefono = @Telefono, FechaNacimiento = @FechaNacimiento, Estado = @Estado WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", usuario.IDUsuario);
                Database.SetParam("@ID_TipoUsuario", usuario.TipoUser.IDTipo);
                Database.SetParam("@ID_Domicilio", usuario.Domicilio.IDDomicilio);
                Database.SetParam("@Dni", usuario.DNI);
                Database.SetParam("@Nombre", usuario.Nombre);
                Database.SetParam("@Apellido", usuario.Apellido);
                Database.SetParam("@Email", usuario.Email);
                Database.SetParam("@Contrasena", usuario.Contraseña);
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
                Database.SetQuery("INSERT INTO TABLE Domicilios (ID_Provincia, Localidad, Calle, Numero, CodigoPostal, Piso, Referencia, Alias, Estado) VALUES(@ID_Provincia, @Localidad, @Calle, @Numero, @CodigoPostal, @Piso, @Referencia, @Alias, @Estado)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;");
                Database.SetParam("@ID_Provincia", domicilio.Provincia.IDProvincia);
                Database.SetParam("@Localidad", domicilio.Localidad);
                Database.SetParam("@Calle", domicilio.Calle);
                Database.SetParam("@Numero", domicilio.Altura);
                Database.SetParam("@CodigoPostal", domicilio.CodigoPostal);
                Database.SetParam("@Piso", domicilio.Piso);
                Database.SetParam("@Referencia", domicilio.Referencia);
                Database.SetParam("@Alias", domicilio.Alias);
                Database.SetParam("@Estado", domicilio.Estado);
                if (Database.RunQuery() == 1)
                {
                    long IDDomicilio = (int)Database.Reader["ID"];

                    Database.SetQuery("UPDATE TABLE Usuarios SET ID_Domicilio = @ID_Domicilio WHERE ID_Usuario = @ID_Usuario");
                    Database.SetParam("@ID_Usuario", IDUsuario);
                    Database.SetParam("@ID_Domicilio", IDDomicilio);
                    if (Database.RunQuery() == 1) return true;
                    else return false;
                }

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

        public bool ActualizarDomicilio(Domicilio domicilio)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE TABLE Domicilios SET ID_Provincia = @ID_Provincia, Localidad = @Localidad, Calle = @Calle, Numero = @Numero, CodigoPostal = @CodigoPostal, Piso = @Piso, Referencia = @Referencia, Alias = @Alias, Estado = @Estado WHERE ID_Domicilio = @ID_Domicilio");
                Database.SetParam("@ID_Domicilio", domicilio.IDDomicilio);
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

        public bool EstadoUsuario(long IDUsuario, int estado)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE TABLE Usuarios SET Estado = @Estado WHERE ID_Usuario = @ID_Usuario");
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
