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
    

        public ActionResult Details(string SerialNumber, string Registration, DateTime RegistrationDate)
        {
            try
            {
                ViewData.Model = rep.First(x => x.SerialNumber == SerialNumber && x.AircraftRegistrationEntry == Registration && x.RegistrationDate == RegistrationDate);
            }
            catch (Exception e)
            {
                return View("Error");
            }

            return View();
        }

        public ActionResult List()
        {
            if (rep != null)
                ViewData.Model = rep;
            else
                return View("Error");

            return View();
        }

        public ActionResult Edit(string SerialNumber, string Registration, DateTime RegistrationDate, bool HasCrashed)
        {
            //rep.Where(
            //    x =>
            //        x.SerialNumber == SerialNumber && x.AircraftRegistrationEntry == Registration &&
            //        x.RegistrationDate == RegistrationDate && x.HasCrashed == HasCrashed);

            return View();
        }


        public ActionResult Delete(string serialnumber, string registration, DateTime registrationdate, bool hascrashed)
        {
            rep.RemoveAll(x =>
                x.SerialNumber == serialnumber && x.AircraftRegistrationEntry == registration &&
                x.RegistrationDate == registrationdate && x.HasCrashed == hascrashed);

            return View();
        }
    }
}