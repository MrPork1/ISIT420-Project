﻿using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class QueryController : Controller
    {
        // GET: QueryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QueryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QueryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QueryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QueryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QueryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QueryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QueryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
