using ArchProject.Models;
using ArchProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchProject.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }
        // GET: Country
        public ActionResult Index()
        {
            return View(_countryService.GetAll());
        }

        public ActionResult Details(int id)
        {
            var country = _countryService.GetById(id);
            return View(country);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Create(country);
                return RedirectToAction("index");
            }
            return View(country);
        }
        // Get : Country/Edit/5
        public ActionResult Edit(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        // Post: Country/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Update(country);
                return RedirectToAction("index");
            }
            return View(country);
        }

        // GET: /Country/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _countryService.GetById(id);
            if(country == null)
            {
                return HttpNotFound();
            }

            return View(country);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            var country = _countryService.GetById(id);
            _countryService.Delete(country);
            return RedirectToAction("index");
        }
    }
}