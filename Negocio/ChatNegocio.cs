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
            Chat chat;
            try
            {
                Database.SetQuery("SELECT ID_Mensaje, ID_Venta, ID_Remitente, Mensaje, Fecha FROM Chat WHERE ID_Venta = @ID_Venta");
                Database.SetParam("@ID_Venta", IDVenta);
                Database.Read();
                while(Database.Reader.Read())
                {
                    chat = new Chat();
                    if (!(Database.Reader["ID_Mensaje"] is DBNull)) chat.IDMensaje = (long)Database.Reader["ID_Mensaje"];
                    if (!(Database.Reader["ID_Venta"] is DBNull)) chat.IDVenta = (long)Database.Reader["ID_Venta"];
                    if (!(Database.Reader["ID_Remitente"] is DBNull)) chat.IDRemitente = (long)Database.Reader["ID_Remitente"];
                    if (!(Database.Reader["Mensaje"] is DBNull)) chat.Mensaje = (string)Database.Reader["Mensaje"];
                    if (!(Database.Reader["Fecha"] is DBNull)) chat.Fecha = (DateTime)Database.Reader["Fecha"];
                    lista.Add(chat);
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
