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


        public bool RegistroUsuario(Usuario usuario)
        {
            return true;
        }

        public bool LoginUsuario(string email, string password)
        {
            return true;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            return true;
        }

        public bool EliminarUsuario(long IDUsuario)
        {
            return true;
        }

        public string PassPorEmail(string email)
        {
            Database = new NegocioDB();
            Usuario usuario = new Usuario();
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

                return hashPass;
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

        public Usuario UsuarioPorID(int IDUsuario)
        {
            Database = new NegocioDB();
            Usuario usuario = new Usuario();
            try
            {
                Database.StoreProcedure("SP_UsuarioPorID");
                Database.SetParam("@IDUsuario", IDUsuario);
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
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Database.Close();
            }


        }

        public Usuario UsuarioPorEmail(string email)
        {
            Database = new NegocioDB();
            Usuario usuario = new Usuario();
            try
            {
                Database.SetQuery("SELECT ID_Usuario, ID_TipoUsuario, TU.Nombre as TipoUsuario, Dni, U.Nombre, Apellido, Email, Telefono, FechaNacimiento, U.Estado, D.ID_Domicilio, D.ID_Provincia as ID_Provincia, P.Nombre as Provincia, D.Localidad, D.Calle, D.Numero, D.CodigoPostal, D.Piso, D.Referencia, D.Alias, D.Estado as EstadoDomicilio FROM Usuarios U INNER JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo INNER JOIN Domicilios D ON U.ID_Domicilio = D.ID_Domicilio INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia WHERE Email = @Email");
                Database.SetParam("@Email", email);
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

                    if (!(Database.Reader["ID_TipoUsuario"] is DBNull)) usuario.TipoUser.IDTipo = (long)Database.Reader["ID_TipoUsuario"];
                    if (!(Database.Reader["TipoUsuario"] is DBNull)) usuario.TipoUser.Nombre = (string)Database.Reader["TipoUsuario"];

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
