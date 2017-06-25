using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PATENT.DAL.DataProvider;
using PATENT.DAL.EFModels;
using PATENT.DAL.EfModels;
using System.Threading;
using System;
using System.Collections.Generic;

namespace PATENT.Controllers
{
    public class CopyrightsController : Controller
    {
        private ServiceDBContext db = new ServiceDBContext();

        // GET: Copyrights
        public ActionResult Index()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return View(db.Copyrights.ToList());
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Copyrights/Details/5
        public ActionResult Details(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Copyright copyright = db.Copyrights.Find(id);
                if (copyright == null)
                {
                    return HttpNotFound();
                }
                return View(copyright);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpGet]
        public ActionResult GetCopyrightsBetweenDate(DateTime? dateFrom, DateTime? dateTo)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var copyrights = new List<Copyright>();

                if (dateFrom == null && dateTo == null)
                {
                    copyrights.AddRange(db.Copyrights.ToList());
                }
                else if (dateFrom != null && dateTo == null)
                {
                    copyrights.AddRange(db.Copyrights
                        .Where(item => item.RequestDate >= dateFrom)
                        .ToList());
                }
                else if (dateTo != null && dateFrom == null)
                {
                    copyrights.AddRange(db.Copyrights
                        .Where(item => item.RequestDate <= dateTo)
                        .ToList());
                }
                else
                {
                    copyrights.AddRange(db.Copyrights
                        .Where(item => item.RequestDate >= dateFrom && item.RequestDate <= dateTo)
                        .ToList());
                }

                return View("~/Views/Copyrights/Index.cshtml", model: copyrights);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }


        // GET: Copyrights/Create
        public ActionResult Create()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Copyright newCop = new Copyright();
                db.Copyrights.Add(newCop);
                db.SaveChanges();

                return RedirectToAction("Edit", "Copyrights", new { id = newCop.CopyrightID});
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Copyrights/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Copyright copyright)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Copyrights.Add(copyright);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(copyright);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpPost]
        public ActionResult CreateCopyrightPayment(int id, Payment appPayment)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Copyright copyright = db.Copyrights
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.CopyrightID == id);

                copyright.Payments.Add(appPayment);
                db.SaveChanges();

                return View("~/Views/Copyright/Details.cshtml", model: copyright);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpPost]
        public ActionResult CreateCopyrightComment(int id, Comment appComment)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Copyright copyright = db.Copyrights
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.CopyrightID == id);

                copyright.Comments.Add(appComment);
                db.SaveChanges();

                return View("~/Views/Copyright/Details.cshtml", model: copyright);
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
                Copyright copyright = db.Copyrights
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.CopyrightID == id);
                if(copyright == null)
                {
                    string str_model = "Помилка при створенні автора. Авторське право не знайдено.";
                    return View("~/Views/Shared/WriteStringView.cshtml", model: str_model);
                }

                try
                {
                    copyright.Authors.Add(author);
                    db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                //return View("~/Views/Applications/Edit.cshtml", model: application);
                return RedirectToAction("Edit", "Copyrights", new { id = copyright.CopyrightID });
            }
            else
            {
                string str_model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: str_model);
            }
        }

        // GET: Copyright/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Copyright copyright = db.Copyrights.Find(id);
                if (copyright == null)
                {
                    return HttpNotFound();
                }
                return View(copyright);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Copyrights/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Copyright copyright)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(copyright).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(copyright);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Copyrights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Copyright copyright = db.Copyrights.Find(id);
                if (copyright == null)
                {
                    return HttpNotFound();
                }
                return View(copyright);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Copyrights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Copyright copyright = db.Copyrights.Find(id);
                db.Copyrights.Remove(copyright);
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