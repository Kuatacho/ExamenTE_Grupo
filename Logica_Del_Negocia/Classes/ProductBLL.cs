using Acceso_Datos.DAL;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Del_Negocia.Classes
{
    public class ProductBLL
    {
        private ProductDAL _DAL;

        public ProductBLL()
        {
            _DAL = new ProductDAL();
        }
        public void CreateProduct(Product product)
        {
            _DAL.CreateProduct(product);
        }
    }

}

