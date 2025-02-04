using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper; //added by teacher
using System.Data; //added by teacher
using WebApplication1.Models; //added by teacher


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

        // **POST: Handle Form Submission**
        [HttpPost]
        public ActionResult Index(AppUsers user)
        {
            int r = db.Connection.Execute("Insert Into usertable (Username, Password, Name) Values (@Username, @Password, @Name)", user);

            if (r > 0)
            {
                ViewBag.Message = "Account Created Successfully!";
            }
            else
            {
                ViewBag.Message = "Error creating account.";
            }

            return View();
        }

        //--------------------------------------------
        public ActionResult login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult login(string username, string password)
        {
            //int r = db.Connection.Execute("Insert Into usertable (Username, Password, Name) Values (@Username, @Password, @Name)", user);
          var existingUser = db.Connection.QueryFirstOrDefault<AppUsers>("SELECT * FROM usertable WHERE Username = @Username and Password = @Password", new { Username = username, Password = password });

           if (existingUser != null)
            {
                // User authenticated successfully
                ViewBag.Message = "Login Successful!";
                // You can redirect to another page or store user session info here.
                //return RedirectToAction("login","Index"); // Example: Redirecting to a dashboard.
                return View();
    }

            else
            {
                // Invalid credentials
                ViewBag.Message = "Invalid Username or Password.";
               // return RedirectToAction("Index", "Login");
               return View();
}
        }
       

        

    }
}