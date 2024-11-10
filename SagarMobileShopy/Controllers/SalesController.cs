using sagar.mobile.shopy.business.Models;
using sagar.mobile.shopy.business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SagarMobileShopy.Controllers
{
    public class SalesController : Controller
    {
        readonly SalesRepository _salesRepo = null;

        public SalesController()
        {
            _salesRepo = new SalesRepository();
        }
        // GET: Sale
        public ActionResult Sales()
        {
            return View();
        }
        public JsonResult Search(string imei)
        {           
            return Json(_salesRepo.GetIMEIData(imei), JsonRequestBehavior.AllowGet);
        }

        public JsonResult searchCompany(string company)
        {
            return Json(_salesRepo.GetCompanyData(company), JsonRequestBehavior.AllowGet);
        }

        public JsonResult searchModel(string Model)
        {
            return Json(_salesRepo.GetModelData(Model), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBillNo(string Model)
        {
            return Json(_salesRepo.GenerateBillNo(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddBill(Bill billDetails)
        {
            return Json(_salesRepo.AddBill(billDetails), JsonRequestBehavior.AllowGet);
        }
    }
}