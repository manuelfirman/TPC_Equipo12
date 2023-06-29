using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoUsuarioNegocio
    {
        TipoUsuario tipoUsuario;
        private NegocioDB Database { get; set; } = new NegocioDB();

        public TipoUsuarioNegocio()
        {
            tipoUsuario = new TipoUsuario();
        }

        public List<TipoUsuario> ListarTiposUsuario()
        {
            Database = new NegocioDB();
            List<TipoUsuario> tiposUsuario = new List<TipoUsuario>();
            TipoUsuario tipo;
            try
            {
                Database.SetQuery("SELECT ID_Tipo, Nombre FROM TipoUsuario");
                Database.Read();
                if (Database.Reader.Read())
                {
                    tipo = new TipoUsuario();

                    if (!(Database.Reader["ID_Tipo"] is DBNull)) tipoUsuario.IDTipo = (long)Database.Reader["ID_Tipo"];
                    if (!(Database.Reader["Nombre"] is DBNull)) tipoUsuario.Nombre = (string)Database.Reader["Nombre"];

                    tiposUsuario.Add(tipo);
                }

                return tiposUsuario;
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
    }
}
