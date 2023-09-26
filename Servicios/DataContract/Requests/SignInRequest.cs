namespace Servicios.DataContract.Requests
{
    public class SignInRequest:Request
    {
        public string U_Name { get; set; }
        public string U_Password { get; set; }
    }
}
