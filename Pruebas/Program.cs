using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserBusiness userBusiness = new UserBusiness();

            User user = new User();

            user.name = "hola";
            user.email = "hola@gmail.com";
            user.password = "hola";
            user.surname = "hola";

            userBusiness.register(user);
        }
    }
}
