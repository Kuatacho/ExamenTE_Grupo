namespace Servicios.DataContract.Requests
{
    public class CreateProductRequest:Request
    {
        
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
