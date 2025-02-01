using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models; //added by umer

namespace WebApplication1.Controllers
{
    public class loginController : Controller
    {
        DapperHelper db;

        public loginController()
        {
            db = new DapperHelper();
        }


        public ActionResult Index()
        {
            return View();
        }


        // **GET: Show Registration Page**
        public ActionResult Create()
        {
            return View();
        }

        // **POST: Handle Form Submission**
        [HttpPost]
        public ActionResult Create(AppUsers user)
        {
            if (ModelState.IsValid)
            {
                db.InsertUser(user);
                ViewBag.Message = "Account Created Successfully!";
            }
            return View();
        }
    }
}
