using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Matrimonial_Website.Models;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace Matrimonial_Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult home()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult privacy()
        {
            return View();
        }
        public ActionResult terms_condition()
        {
            return View();
        }
        public ActionResult services()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult register(Registration reg)
        {
            try
            {
                Matrimonial_WebsiteEntities db = new Matrimonial_WebsiteEntities();
                user_profile ud = new user_profile();
                ud.u_id = reg.u_id;
                ud.pass = reg.pass;
                ud.F_name = reg.F_name;
                ud.L_name = reg.L_name;
                ud.gender = reg.gender;
                ud.religion = reg.religion;
                db.user_profile.Add(ud);
                db.SaveChanges();
                ViewBag.successmessage = "Successfully resgistered";
                return RedirectToAction("Register");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(login lg)
        {
            using (Matrimonial_WebsiteEntities db = new Matrimonial_WebsiteEntities())
            {
                var userdetails = db.user_profile.Where(x => x.u_id == lg.u_id && x.pass == lg.pass).FirstOrDefault();
                if(userdetails == null)
                {
                    lg.loginerror_msg = "Invalid userid or password";
                    return View("error", lg);
                }
                else
                {
                    Session["u_id"] = lg.u_id;
                    return RedirectToAction("home","Home");

                  //  return View("Success",lg);
                }
                return View();
            }
            
        }
        public ActionResult logout()
        {
            int userid = (int)Session["u_id"];
            Session.Abandon();
            return RedirectToAction("home", "Home");
        }

        public ActionResult view_profile()
        {
            return View();
        }
    }
}