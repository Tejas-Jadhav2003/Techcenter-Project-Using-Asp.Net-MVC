using sagar.mobile.shopy.business.Models;
using sagar.mobile.shopy.business.Repository;
using SagarMobileShopy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SagarMobileShopy.Controllers
{
    public class PurchaseController : Controller
    {
        readonly PurchaseRepository _purchaseRepo = null;
        string message = string.Empty;


        public PurchaseController()
        {
            _purchaseRepo = new PurchaseRepository();
        }

        [HttpGet]
        public ActionResult Purchase()
        {            
            return View();
        }           
        public JsonResult Purchase_List(int purchaseId)
        {
            return Json(_purchaseRepo.PurchaseGetList(),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPurchase(Purchase pur)
        {
            try
            {                
        
                if (_purchaseRepo.PurchaseAdd(pur))
                {
                     message  = "Add successfully!";
                }
                else
                {
                    message = "EMEI No already exist!";
                    
                }

                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex,JsonRequestBehavior.AllowGet);
            }
        }

        
        
        public JsonResult GetbyID(int ID)
        {
                    var data = _purchaseRepo.PurchaseGetList().Find(x => x.id.Equals(ID));
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Purchase pur)
        {
            return Json(_purchaseRepo.PurchaseUpdate(pur), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(_purchaseRepo.PurchaseDelete(ID), JsonRequestBehavior.AllowGet);
        }


    }
}