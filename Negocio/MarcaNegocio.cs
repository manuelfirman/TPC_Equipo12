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
        public List<Marca> listarMarcas()
        {
            NegocioDB db = new NegocioDB();
            List<Marca> marcas = new List<Marca>();

            db.StoreProcedure("SP_ListarMarcas");
            db.Read();
            while(db.Reader.Read())
            {
                Marca auxMarca = new Marca();

                if (!(db.Reader["Nombre"] is DBNull)) auxMarca.Nombre = (string)db.Reader["Nombre"];
                if (!(db.Reader["Estado"] is DBNull)) auxMarca.Estado = (bool)db.Reader["Estado"];
                if (!(db.Reader["ID_Marca"] is DBNull)) auxMarca.IDMarca= (int)db.Reader["ID_Marca"];
                marcas.Add(auxMarca);
            }

            db.Close();
            return marcas;
        }


    }
}
