using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategoria()
        {
            NegocioDB db = new NegocioDB();
            List<Categoria> categorias = new List<Categoria>();
            db.StoreProcedure("SP_ListarCategorias");
            db.Read();
            while(db.Reader.Read())
            {
                Categoria auxCategoria = new Categoria();

                if (!(db.Reader["Nombre"] is DBNull)) auxCategoria.Nombre = (string)db.Reader["Nombre"];
                if (!(db.Reader["Estado"] is DBNull)) auxCategoria.Estado = (bool)db.Reader["Estado"];
                if (!(db.Reader["ID_Categoria"] is DBNull)) auxCategoria.IDCategoria = (int)db.Reader["ID_Categoria"];
                categorias.Add(auxCategoria);
            }
            db.Close();
            return categorias;
        }

    }
}
