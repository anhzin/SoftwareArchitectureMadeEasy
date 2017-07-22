using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DataContracts;
using Contracts;
using Website.ViewModels;
using UnityResolver;

namespace Website.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
      
            return View();

        }

        [HttpPost]
        public ActionResult Create(List<Attendee> Attendees)
        {
            //List<Attendee> attendees = new List<Attendee>();
            //attendees.Add(attendee);
            //IRegistrationManager regManager = UnityCache.ResolveDefault<IRegistrationManager>();
            //UserContext uc = new UserContext();
            //uc.AuditUserName = "KEN";

            //uc.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //Registration reg = regManager.ProcessRegistration(uc, attendees);
            //return View();       
        
            IRegistrationManager regManager = UnityCache.ResolveDefault<IRegistrationManager>();
            UserContext uc = new UserContext();
            uc.AuditUserName = "KEN";

            uc.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //Registration reg = regManager.ProcessRegistration(uc, attendee);
            return View();
        }
    }
}