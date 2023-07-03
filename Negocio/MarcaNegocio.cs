using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        private NegocioDB Database { get; set; }

        public List<Marca> ListarMarcas()
        {
            Database = new NegocioDB();
            List<Marca> marcas = new List<Marca>();

            Database.SetQuery("SELECT M.Estado, M.Nombre, M.ID_Marca FROM Marcas AS M");
            Database.Read();
            while (Database.Reader.Read())
            {
                Marca auxMarca = new Marca();

                if (!(Database.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)Database.Reader["Nombre"];
                if (!(Database.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)Database.Reader["Estado"];
                if (!(Database.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca = (long)Database.Reader["ID_Marca"];
                marcas.Add(auxMarca);
            }

            Database.Close();
            return marcas;
        }

        public List<Marca> MarcasRandom(int cantidad)
        {
            Database = new NegocioDB();
            List<Marca> lista = new List<Marca>();
            try
            {
                Database.SetQuery("SELECT TOP (@Cantidad) M.ID_Marca, M.Nombre, M.Estado FROM Marcas M ORDER BY NEWID()");
                Database.SetParam("@Cantidad", cantidad);
                Database.Read();
                while (Database.Reader.Read())
                {
                Marca auxMarca = new Marca();
                    if (!(Database.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca = (long)Database.Reader["ID_Marca"];
                    if (!(Database.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)Database.Reader["Estado"];

                    lista.Add(auxMarca);
            }

                return lista;
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

        public Marca MarcaPorID(long IDMarca)
        {
            Database = new NegocioDB();
            Marca auxMarca = new Marca();

            try
            {
                Database.SetQuery($"SELECT Nombre, Estado, ID_Marca FROM Marcas WHERE ID_Marca = @ID_Marca");
                Database.SetParam("ID_Marca", IDMarca);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)Database.Reader["Nombre"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)Database.Reader["Estado"];
                    if (!(Database.Reader["Estado"] is DBNull)) auxMarca.IDMarca = (long)Database.Reader["ID_Marca"];


                }
                return auxMarca;
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

        public bool AgregarMarca(Marca marca)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"INSERT INTO Marcas (Nombre, Estado) VALUES (@Marca, @Estado)");
                db.SetParam("@Marca", marca.Nombre);
                db.SetParam("@Estado", marca.Estado);
                if (db.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                db.Close();
            }
        }

        public bool ModificarMarca(Marca marca)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"UPDATE Marcas SET Nombre = @NOMBRE, Estado = @Estado WHERE ID_Marca = @ID_Marca");
                db.SetParam("@NOMBRE", marca.Nombre);
                db.SetParam("@ID_Marca", marca.IDMarca);
                db.SetParam("@Estado", marca.Estado);
                if (db.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                db.Close();
            }
        }

        //METODO PARA MODIFICAR EL ESTADO, YA SEA PARA QUE APAREZCA ACTIVO O NO
        public bool EstadoMarca(long IDMarca, bool Estado)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"UPDATE Marcas SET Estado = @Estado WHERE ID_Marca = @ID_Marca");
                db.SetParam("@ID_Marca", IDMarca);
                db.SetParam("@Estado", Estado);
                if (db.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                db.Close();
            }
        }

        public bool EliminarMarca(long ID_Marca)
        {
            NegocioDB db = new NegocioDB();
            try
            {
                db.SetQuery($"DELETE FROM Marcas WHERE ID_Marca = @ID_Marca");
                db.SetParam("@ID_Marca", ID_Marca);
                if (db.RunQuery() == 1) return true;
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
