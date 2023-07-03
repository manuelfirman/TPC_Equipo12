using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DomicilioNegocio
    {
        private NegocioDB Database { get; set; }

        public List<Provincia> ListarProvincias()
        {
            Database = new NegocioDB();
            List<Provincia> listaProvincias = new List<Provincia>();
            Provincia provincia;

            try
            {
                Database.SetQuery("SELECT ID_Provincia, Nombre FROM Provincias");
                Database.Read();
                while(Database.Reader.Read())
                {
                    provincia = new Provincia();
                    if (!(Database.Reader["ID_Provincia"] is DBNull)) provincia.IDProvincia = (long)Database.Reader["ID_Provincia"];
                    if (!(Database.Reader["Nombre"] is DBNull)) provincia.Nombre = (string)Database.Reader["Nombre"];
                    listaProvincias.Add(provincia);
                }

                return listaProvincias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Database?.Close();
            }

        }

        public List<Domicilio> DomiciliosUsuario(long IDUsuario)
        {
            Database = new NegocioDB();
            List<Domicilio> domicilios = new List<Domicilio>();
            Domicilio auxDomicilio;

            try
            {
                Database.SetQuery("SELECT ID_Usuario, ID_Domicilio, Localidad, Calle, Numero, CodigoPostal, Piso, Referencia, Alias, Estado, P.ID_Provincia, P.Nombre as Provincia FROM Domicilios D INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia WHERE ID_Usuario = @ID_Usuario");
                Database.SetParam("@ID_Usuario", IDUsuario);
                Database.Read();
                while (Database.Reader.Read()) 
                {
                    auxDomicilio = new Domicilio();

                    if (!(Database.Reader["ID_Usuario"] is DBNull)) auxDomicilio.IDDomicilio = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["ID_Domicilio"] is DBNull)) auxDomicilio.IDDomicilio = (long)Database.Reader["ID_Domicilio"];
                    if (!(Database.Reader["Localidad"] is DBNull)) auxDomicilio.Localidad = (string)Database.Reader["Localidad"];
                    if (!(Database.Reader["Calle"] is DBNull)) auxDomicilio.Calle = (string)Database.Reader["Calle"];
                    if (!(Database.Reader["Numero"] is DBNull)) auxDomicilio.Altura = (string)Database.Reader["Numero"];
                    if (!(Database.Reader["CodigoPostal"] is DBNull)) auxDomicilio.CodigoPostal = (string)Database.Reader["CodigoPostal"];
                    if (!(Database.Reader["Piso"] is DBNull)) auxDomicilio.Piso = (string)Database.Reader["Piso"];
                    if (!(Database.Reader["Referencia"] is DBNull)) auxDomicilio.Referencia = (string)Database.Reader["Referencia"];
                    if (!(Database.Reader["Alias"] is DBNull)) auxDomicilio.Alias = (string)Database.Reader["Alias"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxDomicilio.Estado = (bool)Database.Reader["Estado"];
                    auxDomicilio.Provincia = new Provincia();
                    if (!(Database.Reader["ID_Provincia"] is DBNull)) auxDomicilio.Provincia.IDProvincia = (long)Database.Reader["ID_Provincia"];
                    if (!(Database.Reader["Provincia"] is DBNull)) auxDomicilio.Provincia.Nombre = (string)Database.Reader["Provincia"];

                    domicilios.Add(auxDomicilio);
                }

                return domicilios;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
