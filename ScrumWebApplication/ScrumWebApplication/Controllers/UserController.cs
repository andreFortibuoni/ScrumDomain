using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumWebApplication.Models;

namespace ScrumWebApplication.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            using (var session = MvcApplication.RavenDbDocumentStore.OpenSession())
            {
                var items = session.Query<Item>().ToList();
                return View(items);
            }
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            using (var session = MvcApplication.RavenDbDocumentStore.OpenSession())
            {
                var item = session.Load<Item>(id);
                return View(item);
            }
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                using (var session = MvcApplication.RavenDbDocumentStore.OpenSession())
                {
                    session.Store(item);
                    session.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                using (var session = MvcApplication.RavenDbDocumentStore.OpenSession())
                {
                    var myItem = session.Load<Item>(id);
                    myItem.Id = item.Id;
                    myItem.Priority = item.Priority;
                    myItem.TakenOver = item.TakenOver;
                    session.Store(myItem);
                    session.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Item deleted)
        {
            try
            {
                using (var session = MvcApplication.RavenDbDocumentStore.OpenSession())
                {
                    var item = session.Load<Item>(id);
                    session.Delete(item);
                    session.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
