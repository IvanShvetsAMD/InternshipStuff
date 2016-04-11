using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;


namespace Web.Controllers
{
    public class AircraftRegistryController : Controller
    {
        //TEST
        private List<AircraftRegistry> rep = new List<AircraftRegistry>()
        {
            new AircraftRegistry("VH-HYR", false, new DateTime(1996, 10, 10), "622"),
            new AircraftRegistry("ER-AXV", false, new DateTime(2003, 9, 22), "622"),
            new AircraftRegistry("N452TA", false, new DateTime(1997, 11, 28), "741"),
            new AircraftRegistry("ER-AXP", false, new DateTime(2011, 11, 3), "741"),
            new AircraftRegistry("B-6156", false, new DateTime(2006, 8, 3), "2849"),
            new AircraftRegistry("ER-AXL", false, new DateTime(2015, 6, 5), "2849"),
            new AircraftRegistry("D-ASSY", false, new DateTime(1997, 3, 26), "666"),
            new AircraftRegistry("SX-BHT", false, new DateTime(2014, 5, 31), "666"),
            new AircraftRegistry("F-OSUD", false, new DateTime(2007, 12, 4), "19000130"),
            new AircraftRegistry("ER-ECC", false, new DateTime(2013, 3, 29), "19000130")
        };


        public ActionResult Details(string serialNumber, string registration, DateTime registrationDate)
        {
            try
            {
                ViewData.Model = rep.First(x => x.SerialNumber == serialNumber && x.AircraftRegistrationEntry == registration && x.RegistrationDate == registrationDate);
            }
            catch (Exception e)
            {
                //ViewBag.Message = e.Message;
                return View("Error");
            }

            return View();
        }

        public ActionResult List()
        {


            if (rep == null)
            {
                return View("Error");
            }
            if (rep.Count == 0)
            {
                return View("ErrorNoData");
            }

            ViewData.Model = rep;

            return View();
        }

        //public ActionResult Edit(string serialNumber, string registration, DateTime registrationDate, bool hasCrashed)
        //{
        //    //rep.Where(
        //    //    x =>
        //    //        x.serialNumber == serialNumber && x.AircraftRegistrationEntry == registration &&
        //    //        x.registrationDate == registrationDate && x.HasCrashed == hasCrashed);

        //    return View();
        //}


        //public ActionResult Delete(string serialnumber, string registration, DateTime registrationdate, bool hascrashed)
        //{
        //    int n = rep.RemoveAll(x =>
        //        x.SerialNumber == serialnumber && x.AircraftRegistrationEntry == registration &&
        //        x.RegistrationDate == registrationdate && x.HasCrashed == hascrashed);

        //    ViewData.Model = n;

        //    return View("ObjectsRemoved");
        //}
    }
}