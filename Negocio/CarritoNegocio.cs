using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarritoNegocio
    {
        private Carrito Carrito { get; set; } = new Carrito();

        public int GetCantidad()
        {
            return Carrito.Elementos.Count;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            foreach(ElementoCarrito elemento in Carrito.Elementos) 
            {
                listaProductos.Add(elemento.Producto);
            }
            return listaProductos;
        }

        public List<ElementoCarrito> GetElementos()
        {
            return Carrito.Elementos;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            foreach (ElementoCarrito prod in Carrito.Elementos)
            {
                if (producto.IDProducto == prod.Producto.IDProducto)
                {
                    prod.Cantidad += cantidad;
                    return;
                }
            }

            ElementoCarrito elementoCarrito = new ElementoCarrito();
            elementoCarrito.Producto = producto;
            elementoCarrito.Cantidad = cantidad;
            Carrito.Elementos.Add(elementoCarrito);
        }

        public void QuitarProducto(long IDProducto)
        {
            ElementoCarrito elementoCarrito = Carrito.Elementos.FirstOrDefault(a => a.Producto.IDProducto == IDProducto);
            if (elementoCarrito != null)
            {
                Carrito.Elementos.Remove(elementoCarrito);
            }
        }

        public void SumarUnProducto(long IDProducto)
        {
            ElementoCarrito elementoCarrito = Carrito.Elementos.FirstOrDefault(a => a.Producto.IDProducto == IDProducto);
            if (elementoCarrito != null)
            {
                elementoCarrito.Cantidad++;
            }
        }

        public void RestarUnProducto(long IDProducto)
        {
            ElementoCarrito elementoCarrito = Carrito.Elementos.FirstOrDefault(a => a.Producto.IDProducto == IDProducto);
            if (elementoCarrito != null)
            {
                elementoCarrito.Cantidad--;
                if (elementoCarrito.Cantidad < 1) elementoCarrito.Cantidad = 1;
            }
        }

        public decimal PrecioTotal()
        {
            decimal total = 0;
            foreach(ElementoCarrito elemento in Carrito.Elementos)
            {
                total += (elemento.Producto.Precio * elemento.Cantidad);
            }

            return total;
        }
    }
}
