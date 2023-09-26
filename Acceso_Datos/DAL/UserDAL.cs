using Acceso_Datos.Data;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos.DAL
{
    public class UserDAL
    {
        public User GetUser(int id)
        {
            var db = new DBProyectoContext();
            User u = new User();

            u = db.Users.FirstOrDefault(x => x.Id == id);

            return u;
        }

        public void CreateUser(User user)
        {
            var db = new DBProyectoContext();
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
