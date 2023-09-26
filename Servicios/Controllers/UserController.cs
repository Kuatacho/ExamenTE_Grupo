using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Data;
using Servicios.DataContract;
using Servicios.DataContract.Requests;
using Entidades.Models;
using Logica_Del_Negocia.Classes;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBLL _BLL;

        public UserController() 
        {
            _BLL = new UserBLL();
        }

        [HttpGet("SignIn")]
        public IActionResult SignIn(SignInRequest userSignIn)
        {
            Response response = new Response();

            try
            {
                var result = _BLL.GetUser(userSignIn.Session_Id);

                if (result == null)
                {
                    response.Code = Convert.ToSByte(-1);
                    response.Message = "Usuario no encontrado";
                }

                response.Code = 0;
                response.Message = "Inicio de sesión correcto";
            }
            catch (Exception ex)
            {
                response.Code = Convert.ToSByte(-1);
                response.Message = ex.ToString();
            }

            return Ok(response);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserRequest newUser)
        {
            Response response = new Response();
            User user = new User();

            try
            {
                user.CI = newUser.CI;
                user.U_Name = newUser.U_Name;
                user.U_Password = newUser.U_Password;

                _BLL.CreateUser(user);

                response.Code = 0;
                response.Message = "Usuario creado correctamente";
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
