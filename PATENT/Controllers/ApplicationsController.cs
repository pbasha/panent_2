using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PATENT.DAL.DataProvider;
using PATENT.DAL.EFModels;
using PATENT.DAL.EfModels;
using System.Threading;

namespace PATENT.Controllers
{
    public class ApplicationsController : Controller
    {
        private ServiceDBContext db = new ServiceDBContext();

        // GET: Applications
        public ActionResult Index()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return View(db.Applications.ToList());
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Application application = db.Applications.Find(id);
                if (application == null)
                {
                    return HttpNotFound();
                }
                return View(application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Application newApp = new Application();
                db.Applications.Add(newApp);
                db.SaveChanges();

                //send existing Application to Edit method
                return RedirectToAction("Edit", "Applications", new { id = newApp.ApplicationID });
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpGet]
        public ActionResult GetApplicationsBetweenDate(DateTime? dateFrom, DateTime? dateTo)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var applications = new List<Application>();

                if (dateFrom != null)
                {
                    applications.AddRange(db.Applications
                        .Where(item => item.RequestDate >= dateFrom)
                        .ToList());
                }
                if (dateTo != null)
                {
                    applications.AddRange(db.Applications
                        .Where(item => item.RequestDate <= dateTo)
                        .ToList());
                }

                return View("~/Views/Applications/Index.cshtml", 
                    model: (dateFrom == null && dateTo == null) ? db.Applications.ToList() : applications );
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application application)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Applications.Add(application);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpPost]
        public ActionResult CreateApplicationPayment(int id, Payment appPayment)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Application application = db.Applications
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.ApplicationID == id);

                application.Payments.Add(appPayment);
                db.SaveChanges();

                return View("~/Views/Applications/Details.cshtml", model: application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpPost]
        public ActionResult CreateApplicationComment(int id, Comment appComment)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Application application = db.Applications
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.ApplicationID == id);

                application.Comments.Add(appComment);
                db.SaveChanges();

                return View("~/Views/Applications/Details.cshtml", model: application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpPost]
        public ActionResult CreateAuthor(int id, Author author)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Application application = db.Applications
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.ApplicationID == id);

                application.Authors.Add(author);
                db.SaveChanges();

                //return View("~/Views/Applications/Edit.cshtml", model: application);
                return RedirectToAction("Edit", "Applications", new { id = application.ApplicationID });
            }
            else
            {
                string str_model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: str_model);
            }
        }

        [HttpGet]
        public ActionResult TryGetPatent(string businessNumber)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Patent patent = db.Patents
                                .SingleOrDefault(m => m.BusinessNumber == businessNumber);

                if (patent == null)
                {
                    string model = "Sorry, but there are not specific patent.";

                    return View("~/Views/Shared/WriteStringView.cshtml", model: model);
                }

                return View("~/Views/Patents/Details.cshtml", model: patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Application application = db.Applications.Find(id);
                if (application == null)
                {
                    return HttpNotFound();
                }
                return View(application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Application application)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(application).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Application application = db.Applications.Find(id);
                if (application == null)
                {
                    return HttpNotFound();
                }
                return View(application);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Application application = db.Applications.Find(id);
                db.Applications.Remove(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}