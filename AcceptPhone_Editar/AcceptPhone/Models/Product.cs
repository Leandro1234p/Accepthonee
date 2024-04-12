using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using AcceptPhone.Models;

namespace AcceptPhone.Models
{
    // La clase Product se utiliza para representar un producto en la aplicación.
    public class Product
    {
        public string Name { get; set; }  // Propiedad para el nombre del producto.
        public string Description { get; set; }  // Propiedad para la descripción del producto.
        public decimal Price { get; set; }  // Propiedad para el precio del producto.

        // Puedes agregar otras propiedades aquí, como información adicional sobre el producto.

        // Esta clase se utiliza para definir la estructura de un producto en la aplicación.
    }
}
