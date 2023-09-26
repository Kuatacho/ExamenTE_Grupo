using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//esta parte la hize
namespace Entidades.Models
{
    public class Product
    {
        //id del producto
        public int Id { get; set; } 
        //nombre del producto
        public string Nombre { get; set; } 
        // precio del producto
        public decimal Precio { get; set; } 
    }
}
