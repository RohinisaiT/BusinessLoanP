using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DataService;
using BL.UI.Repositories;
using System.Web.SessionState;

namespace BL.UI.Controllers
{
    [Route("controller")]
    public class UserController : Controller
    {
        public UserRepository userRepository;
        BusinessLoanEntities db = new BusinessLoanEntities();

        public UserController()
        {
            userRepository = new UserRepository();
        }
        [Route("GetAllUsers")]
        public ActionResult Index()
        {
            List<User> users = userRepository.GetUsers();
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            userRepository.addUser(user);
            Session["userId"] = user.UserId;
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            User user = userRepository.GetUserById(id);
            return View(user);
        }
        public ActionResult Delete(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            User user = userRepository.GetUserById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            userRepository.EditUser(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Login login = new Login();
            login.email = email;
            login.password = password;

            AuthController ac = new AuthController();

            bool isUserPresent = ac.isUserPresent(login);

            if (isUserPresent)
            {
                User user = db.Users.SingleOrDefault(x => x.email == email);
                Session["userId"] = user.UserId;
                return RedirectToRoute(new { controller = "Loan", action = "getLoans" });
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}