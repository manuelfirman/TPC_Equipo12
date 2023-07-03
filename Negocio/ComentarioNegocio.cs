using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ComentarioNegocio
    {
        private NegocioDB Database { get; set; }

        public List<Comentario> ComentariosPorProducto(long IDProducto)
        {
            Database = new NegocioDB();
            List<Comentario> comentarios = new List<Comentario>();
            Comentario comentario;
            try
            {
                Database.SetQuery("SELECT C.ID_Comentario, C.ID_Producto, U.Nombre as NombreUsuario, C.ID_Usuario, C.Comentario, C.Fecha, C.Estado FROM Comentarios C INNER JOIN Usuarios U ON C.ID_Usuario = U.ID_Usuario  WHERE ID_Producto = @ID_Producto");
                Database.SetParam("@ID_Producto", IDProducto);
                Database.Read();
                while (Database.Reader.Read())
                {
                    comentario = new Comentario();
                    if (!(Database.Reader["ID_Comentario"] is DBNull)) comentario.IDComentario = (long)Database.Reader["ID_Comentario"];
                    if (!(Database.Reader["ID_Producto"] is DBNull)) comentario.IDProducto = (long)Database.Reader["ID_Producto"];
                    if (!(Database.Reader["ID_Usuario"] is DBNull)) comentario.IDProducto = (long)Database.Reader["ID_Usuario"];
                    if (!(Database.Reader["NombreUsuario"] is DBNull)) comentario.NombreUsuario = (string)Database.Reader["NombreUsuario"];
                    if (!(Database.Reader["Comentario"] is DBNull)) comentario.TextoComentario = (string)Database.Reader["Comentario"];
                    if (!(Database.Reader["Fecha"] is DBNull)) comentario.Fecha = (DateTime)Database.Reader["Fecha"];
                    if (!(Database.Reader["Estado"] is DBNull)) comentario.Estado = (bool)Database.Reader["Estado"];

                    comentarios.Add(comentario);
                }

                return comentarios;
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

        public List<Comentario> ComentariosPorUsuario(long IDUsuario)
        {
            return new List<Comentario>();
        }

        public bool CrearComentario(Comentario comentario)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("INSERT INTO Comentarios(ID_Producto, ID_Usuario, Comentario) VALUES(@ID_Producto, @ID_Usuario, @Comentario)");
                Database.SetParam("@Comentario", comentario.TextoComentario);
                Database.SetParam("@ID_Producto", comentario.IDProducto);
                Database.SetParam("@ID_Usuario", comentario.IDUsuario);

                if (Database.RunQuery() == 1)
                {
                    return true;
                }
                return false;
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

        public bool EliminarComentario(long IDComentario)
        {
            Database = new NegocioDB();
            try
            {
                Database.SetQuery("DELETE FROM Comentarios WHERE ID_Comentario = @IDComentario");
                Database.SetParam("@IDComentario", IDComentario);
                if(Database.RunQuery() == 1)
                {
                    return true;
                }
                return false;
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
