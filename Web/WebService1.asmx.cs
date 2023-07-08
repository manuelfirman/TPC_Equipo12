
using System.Threading.Tasks;
using System.Web.Services;
using Negocio;
using Newtonsoft.Json.Linq;

namespace Web
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public async Task<JObject> PaypalFunction(string precio, string IDVenta)
        {
            var negocio = new PaypalNegocio();
            return await negocio.Paypalfunction(precio, IDVenta);
        }
    }


}
