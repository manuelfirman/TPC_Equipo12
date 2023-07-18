using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BannerNegocio
    {
        private NegocioDB Database { get; set; }

        public List<Banner> ListarBanners()
        {
            Database = new NegocioDB();
            List<Banner> lista = new List<Banner>();
            Banner banner;

            try
            {
                Database.SetQuery("SELECT ID_Banner, Titulo, Texto, Referencia, ImagenURL FROM Banners");
                Database.Read();
                while (Database.Reader.Read())
                {
                    banner = new Banner();
                    if (!(Database.Reader["ID_Banner"] is DBNull)) banner.IDBanner = (long)Database.Reader["ID_Banner"];
                    if (!(Database.Reader["Titulo"] is DBNull)) banner.Titulo = (string)Database.Reader["Titulo"];
                    if (!(Database.Reader["Texto"] is DBNull)) banner.Texto = (string)Database.Reader["Texto"];
                    if (!(Database.Reader["Referencia"] is DBNull)) banner.Referencia= (string)Database.Reader["Referencia"];
                    if (!(Database.Reader["ImagenURL"] is DBNull)) banner.ImagenUrl = (string)Database.Reader["ImagenURL"];
                    lista.Add(banner);
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

        public Banner BannerPorID(long IDBanner)
        {
            Database = new NegocioDB();
            Banner banner = new Banner();

            try
            {
                Database.SetQuery("SELECT ID_Banner, Titulo, Texto, Referencia, ImagenURL FROM Banners WHERE ID_Banner = @ID_Banner");
                Database.SetParam("@ID_Banner", IDBanner);
                Database.Read();
                if (Database.Reader.Read())
                {
                    if (!(Database.Reader["ID_Banner"] is DBNull)) banner.IDBanner = (long)Database.Reader["ID_Banner"];
                    if (!(Database.Reader["Titulo"] is DBNull)) banner.Titulo = (string)Database.Reader["Titulo"];
                    if (!(Database.Reader["Texto"] is DBNull)) banner.Texto = (string)Database.Reader["Texto"];
                    if (!(Database.Reader["Referencia"] is DBNull)) banner.Referencia = (string)Database.Reader["Referencia"];
                    if (!(Database.Reader["ImagenURL"] is DBNull)) banner.ImagenUrl = (string)Database.Reader["ImagenURL"];
                }

                return banner;
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

        public bool ModificarBanner(long IDBanner, Banner banner)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("UPDATE Banners SET Texto = @Texto, Titulo = @Titulo, Referencia = @Referencia, ImagenURL = @ImagenURL, Estado = @Estado WHERE ID_Banner = @ID_Banner");
                Database.SetParam("@Texto", banner.Texto);
                Database.SetParam("@Titulo", banner.Titulo);
                Database.SetParam("@Referencia", banner.Referencia);
                Database.SetParam("@ImagenURL", banner.ImagenUrl);
                Database.SetParam("@Estado", banner.Estado);
                Database.SetParam("@ID_Banner", IDBanner);
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

        public bool AgregarBanner(Banner banner)
        {
            Database = new NegocioDB();

            try
            {
                Database.SetQuery("INSERT INTO Banners(Texto, Titulo, Referencia, ImagenURL) VALUES(@Texto, @Titulo, @Referencia, @ImagenURL)");
                Database.SetParam("@Texto", banner.Texto);
                Database.SetParam("@Titulo", banner.Titulo);
                Database.SetParam("@Referencia", banner.Referencia);
                Database.SetParam("@ImagenURL", banner.ImagenUrl);
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
