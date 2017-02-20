using DerekDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DerekDemo.Model;

namespace DerekDemo.Controllers
{
    public class TestController : Controller
    {
        private readonly IUserService _userService;
        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Test
        public ActionResult Index()
        {
            List<User> users = _userService.GetAll().ToList();
            var next = "1";
            if (users.Any())
            {
                next = (int.Parse(users.OrderByDescending(x => x.UserName).First().UserName.Replace("User", "")) + 1).ToString();
            }
            var user = new User()
            {
                UserName = $"User{next}"
            };

            _userService.Add(user);
            _userService.SaveChanges();

            users.Add(user);

            return View(users);
        }
    }
}