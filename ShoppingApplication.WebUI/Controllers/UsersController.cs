using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingApplication.WebUI.Models;

namespace ShoppingApplication.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection data)
        {
            User user = new User();
            user.Name = data["Name"];
            user.Email = data["Email"];
            user.Password = data["Password"];
            user.PhoneNumber = data["PhoneNumber"];
            user.JoinedOn = DateTime.UtcNow.AddHours(5);
            user.RoleId = 1;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var user=db.Users.Find(Id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection data)
        {
            string Id = data["Id"];
            User user = db.Users.Find(Convert.ToInt32(Id));
            user.Name = data["Name"];
            user.Email = data["Email"];
            user.Password = data["Password"];
            user.PhoneNumber = data["PhoneNumber"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
