using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DataService;
using BL.UI.Repositories;

namespace BL.UI.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        public BusinessLoanEntities dbEntities;
        public AuthController()
        {
            dbEntities = new BusinessLoanEntities();
        }
        [HttpPost]
        [Route("isUserPresent")]
        public bool isUserPresent(Login login)
        {
            Login inTable = dbEntities.Logins.Find(login.email);
            if (inTable == null)
            {
                return false;
            }

            if (login.password==inTable.password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("isAdminPresent")]
        public bool isAdminPresent(Login data)
        {
            User user = dbEntities.Users.Where(x => x.email == data.email).First();
            if (user.userRole == "admin")
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        [Route("saveUser")]
        public string saveUser(User user)
        {
            Login login = new Login();
            login.email = user.email;
            login.password = user.password;

            dbEntities.Users.Add(user);
            dbEntities.SaveChanges();

            dbEntities.Logins.Add(login);
            dbEntities.SaveChanges();

            return "user added";
        }
        [HttpPost]
        [Route("saveAdmin")]
        public string saveAdmin(User user)
        {
            return saveUser(user);
        }


    }
}