using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain;
using Repository.Interfaces;


namespace Web.Controllers
{
    public class AircraftRegistryController : Controller
    {
        IAircraftRegistryRepository aircraftRegistryRepository;

        public ActionResult Details(long id)
        {
            AircraftRegistry ar;
            try
            {
                //ViewData.Model = rep.First(x => x.SerialNumber == serialNumber && x.AircraftRegistrationEntry == registration && x.RegistrationDate == registrationDate);
                ar = aircraftRegistryRepository.LoadEntity<AircraftRegistry>(id);
            }
            catch (Exception e)
            {
                //ViewBag.Message = e.Message;
                return View("Error");
            }

            ViewData.Model = ar;
            return View();
        }

        public ActionResult List()
        {
            List<AircraftRegistry> rep;

            try
            {
                rep = aircraftRegistryRepository.GetAllAircraftRegistries();
            }
            catch (Exception e)
            {
                return View("Error");
            }

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

        [HttpGet]
        public ActionResult Edit(long id)
        {
            AircraftRegistry ar = aircraftRegistryRepository.LoadEntity<AircraftRegistry>(id);

            ViewData.Model = ar;

            return View("Edit");
        }

        [HttpPost]
        public ActionResult Edit(long id, string serialNumber, string registration, DateTime registrationDate, bool hasCrashed)
        {
            if (ModelState.IsValid)
            {
                AircraftRegistry ar = aircraftRegistryRepository.LoadEntity<AircraftRegistry>(id);

                ar.HasCrashed = hasCrashed;

                aircraftRegistryRepository.Save(ar);

                return RedirectToAction("List");
            }

            return View("Edit");
        }

        public ActionResult Delete(long id)
        {
            aircraftRegistryRepository.DeleteById(id);

            return View("ObjectsRemoved");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(string serialNumber, string registration, DateTime registrationDate, bool hasCrashed)
        {
            AircraftRegistry ar = new AircraftRegistry(registration, hasCrashed, registrationDate, serialNumber);

            aircraftRegistryRepository.Save(ar);

            return RedirectToAction("List");
        }

        public AircraftRegistryController(IAircraftRegistryRepository aircraftRegistryRepository)
        {
            this.aircraftRegistryRepository = aircraftRegistryRepository;
        }
    }
}