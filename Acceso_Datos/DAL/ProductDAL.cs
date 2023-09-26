using Acceso_Datos.Data;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos.DAL
{
    public class ProductDAL
    {
        public void CreateProduct(Product product)
        {
            var db = new DBProyectoContext();
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
   
}
