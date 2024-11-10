using SagarMobileShopy.Models;
using SagarMobileShopy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SagarMobileShopy.Controllers
{
    public class HomeController : Controller
    {
        readonly CustRepository _empRepo = null;

        public HomeController()
        {
            _empRepo = new CustRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLogin login)
        {
            try
            {
           

                    if (_empRepo.CustLogin(login))
                    {
                        TempData["msg"] = "Login successfully";
                        return RedirectToAction("Dashbord");
                    }
                    else
                    {
                        TempData["msg"] = "Incorrect credentials";
                        return View();
                    }
               
              
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Exception - "+ex.Message;
                return View();
            }

           
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }


        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult Registration(Registration Regi)
        {
            try
            {

                if (!_empRepo.CheckEmailIDIsExist(Regi))
                {
                    _empRepo.AddCustDetails(Regi);
                    ViewBag.Message = "Registration successfully";
                }
                else {
                    ViewBag.Msg = "Email Id already exist!";
                }
              

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashbord()
        {
            return View();
        }
    }

}