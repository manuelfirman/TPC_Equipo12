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
    }
}
