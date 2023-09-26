using Acceso_Datos.DAL;
using Entidades.Models;
using System;

namespace Logica_Del_Negocia.Classes
{
    public class UserBLL
    {
        private UserDAL _DAL;

        public UserBLL()
        {
            _DAL = new UserDAL();
        }

        public User GetUser(int id) 
        {
            var data = _DAL.GetUser(id);
            return data;
        }

        public void CreateUser(User user)
        {
            _DAL.CreateUser(user);
        }
    }
}
