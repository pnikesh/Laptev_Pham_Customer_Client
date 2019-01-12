using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptev_Pham_Customer_Client.Controllers
{
    public class FlightsController : Controller
    {
        // GET: Flights
        public ActionResult Index()
        {
            return View();
        }

        // GET: Flights/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flights/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flights/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(); // hello
            }
        }
    }
}
