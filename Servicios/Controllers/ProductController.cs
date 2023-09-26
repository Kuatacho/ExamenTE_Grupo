using Entidades.Models;
using Logica_Del_Negocia.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.DataContract;
using Servicios.DataContract.Requests;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductBLL _BLL;

        public ProductController()
        {
            _BLL = new ProductBLL();
        }
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] CreateProductRequest newProduct)
        {
            Response response = new Response();
            Product product = new Product();

            try
            {
                
                product.Nombre = newProduct.Nombre;
                product.Precio = newProduct.Precio;

                _BLL.CreateProduct(product);

                response.Code = 0;
                response.Message = "Producto creado correctamente";
            }
            catch (Exception ex)
            {
                response.Code = Convert.ToSByte(-1);
                response.Message = ex.ToString();
            }

            return Ok(response);
        }



        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct([FromBody] DeleteProductRequest newProduct)
        {
            Response response = new Response();
            Product product = new Product();

            try
            {

               product.Id= newProduct.Id;

                _BLL.DeleteProduct(product);

                response.Code = 0;
                response.Message = "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                response.Code = Convert.ToSByte(-1);
                response.Message = ex.ToString();
            }

            return Ok(response);
        }
    }
}

