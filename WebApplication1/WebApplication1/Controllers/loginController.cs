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
        //[HttpPost]
        //  public ActionResult login(string username, string password)

        // //public ActionResult login(string username, string password)
        //{
        //    //int r = db.Connection.Execute("Insert Into usertable (Username, Password, Name) Values (@Username, @Password, @Name)", user);
        //  var existingUser = db.Connection.QueryFirstOrDefault<AppUsers>("SELECT * FROM usertable WHERE Username = @Username", new { username = username });


        //   if (existingUser != null && existingUser.password == user.password)
        //  //  if (username == "admin" && password == "admin")
        //    {
        //        // User authenticated successfully
        //        ViewBag.Message = "Login Successful!";
        //        // You can redirect to another page or store user session info here.
        //        //return RedirectToAction("login","Index"); // Example: Redirecting to a dashboard.
        //        return View();            
        //    }

        //    else
        //    {
        //        // Invalid credentials
        //        ViewBag.Message = "Invalid Username or Password.";
        //       // return RedirectToAction("Index", "Login");
        //       return View();
        //    }
        //}
        [HttpPost]
        public ActionResult login(string username, string password)
        {
            try
            {
                // Fetch the user from the database
                var existingUser = db.Connection.QueryFirstOrDefault<AppUsers>(
                    "SELECT * FROM usertable WHERE Username = @Username",
                    new { Username = username }
                );

                // Check if the user exists
                if (existingUser != null)
                {
                    // Compare the password
                    if (existingUser.password == password)
                    {
                        ViewBag.Message = "Login Successful!";
                        return View(); // Redirect to dashboard if needed
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Password.";
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid Username.";
                }
            }
            catch (Exception ex)
            {
                // If an error happens, display it
                ViewBag.Message = "An error occurred: " + ex.Message;
            }

            return View();
        }

    }
}