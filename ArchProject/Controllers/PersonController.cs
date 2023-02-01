using ArchProject.Models;
using ArchProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArchProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ICountryService _countryService;

        public PersonController(IPersonService personService, ICountryService countryService)
        {
            this._personService = personService;
            this._countryService = countryService;
        }
        // GET: Person
        public ActionResult Index()
        {
            return View(_personService.GetAll());
        }

        // GET: Person/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _personService.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,State,CountryId")] Person person)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _personService.Create(person);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _personService.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address,State,CountryId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.Update(person);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _personService.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Person person = _personService.GetById(id);
            _personService.Delete(person);
            return RedirectToAction("Index");
        }
    }
}
