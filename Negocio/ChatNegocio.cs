using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ChatNegocio
    {
        private NegocioDB Database { get; set; }

        public List<Chat> ChatPorVenta(long IDVenta)
        {
            Database = new NegocioDB();
            List<Chat> lista = new List<Chat>();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Chat chat;
            try
            {
                Database.SetQuery("SELECT ID_Mensaje, ID_Venta, ID_Remitente, Mensaje, Fecha, ID_Vendedor FROM Chat WHERE ID_Venta = @ID_Venta");
                Database.SetParam("@ID_Venta", IDVenta);
                Database.Read();
                while(Database.Reader.Read())
                {
                    chat = new Chat();
                    long IDRemitente = 0;
                    if (!(Database.Reader["ID_Mensaje"] is DBNull)) chat.IDMensaje = (long)Database.Reader["ID_Mensaje"];
                    if (!(Database.Reader["ID_Venta"] is DBNull)) chat.IDVenta = (long)Database.Reader["ID_Venta"];
                    if (!(Database.Reader["ID_Vendedor"] is DBNull)) chat.IDVendedor = (long)Database.Reader["ID_Vendedor"];
                    if (!(Database.Reader["Mensaje"] is DBNull)) chat.Mensaje = (string)Database.Reader["Mensaje"];
                    if (!(Database.Reader["Fecha"] is DBNull)) chat.Fecha = (DateTime)Database.Reader["Fecha"];
                    if (!(Database.Reader["ID_Remitente"] is DBNull)) IDRemitente = (long)Database.Reader["ID_Remitente"];
                    if(IDRemitente != 0) chat.Remitente = usuarioNegocio.UsuarioPorID(IDRemitente);
                    lista.Add(chat);
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CrearMensaje(Chat mensaje)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("INSERT INTO Chat(ID_Venta, ID_Remitente, Mensaje, ID_Vendedor) VALUES(@ID_Venta, @ID_Remitente, @Mensaje, @ID_Vendedor)");
                Database.SetParam("@ID_Vendedor", mensaje.IDVendedor);
                Database.SetParam("@ID_Venta", mensaje.IDVenta);
                Database.SetParam("@ID_Remitente", mensaje.Remitente.IDUsuario);
                Database.SetParam("@Mensaje", mensaje.Mensaje);
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
    }
}
