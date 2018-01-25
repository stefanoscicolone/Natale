using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Natale.Classes;
using NataleMongoDB = Natale.Classes.MongoDB;
namespace Natale.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Utente user)
        {
            NataleMongoDB db = new NataleMongoDB();
            var account = db.GetUser(user);
            if (account != null)
            {
                Session["Email"] = account.Email.ToString();
                Session["ID"] = account.ID.ToString();
                Session["ScreenName"] = account.ScreenName.ToString();
                Session["IsAdmin"] = account.isAdmin.ToString();
                return RedirectToAction($"../Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or Password Error");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["ID"] != null)
            {
                Session.Clear();
                return RedirectToAction("Logout");
            }
            return View();
        }

        public ActionResult LoginFacebook(Utente user)
        {
            NataleMongoDB db = new NataleMongoDB();
            var account = db.GetUser(user);
            if (account != null)
            {
                Session["Email"] = account.Email.ToString();
                Session["ID"] = account.ID.ToString();
                return RedirectToAction("../Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or Password Error");
            }
            return View();
        }
    }
}