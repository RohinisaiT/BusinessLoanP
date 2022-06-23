using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DataService;
using BL.UI.Repositories;

namespace BL.UI.Controllers
{
    [Route("controller")]
    public class UserController : Controller
    {
        public UserRepository userRepository;

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
            return RedirectToAction("Index");
        }
        public ActionResult Details(int userId)
        {
            User user = userRepository.GetUserById(userId);
            return View(user);
        }
        public ActionResult Delete(int userId)
        {
            userRepository.DeleteUser(userId);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int userId)
        {
            User user = userRepository.GetUserById(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            userRepository.EditUser(user);
            return RedirectToAction("Index");
        }
    }
}