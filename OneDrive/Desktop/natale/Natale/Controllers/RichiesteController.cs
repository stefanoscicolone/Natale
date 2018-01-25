using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Natale.Classes;
using Natale.Models;
using NataleMongoDB = Natale.Classes.MongoDB;

namespace Natale.Controllers
{
    public class RichiesteController : Controller
    {
        // GET: RequestKid
        public ActionResult Index()
        {
            NataleMongoDB db = new NataleMongoDB();
            var requests_kids = db.GetAllRequestKid();
            Richeste model = new Richeste();
            model.EntityList = requests_kids.ToList();
            //popolo la lista dei giocattoli richiesti dal bambino
            foreach (var toy in model.EntityList)
            {
                model.ToyList = toy.ToyKids;
                
            }

            return View(model);
        }

        public ActionResult Details(string id)
        {
            NataleMongoDB db = new NataleMongoDB();
            var request_kid = db.GetRequest(id);
            Richeste model = new Richeste();
            ViewBag.KidName = request_kid.KidName;
            ViewBag.Date = request_kid.Date.ToString("dd-MMM-yyyy");
            if(request_kid.Status.ToString() == "0")
            {
                ViewBag.Status = "In Progress";
            }
            
           
            model.ToyList = request_kid.ToyKids;
            
            return View(model);
        }
    }
}