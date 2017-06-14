using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using patent.DAL.DataProvider;
using patent.DAL.EFModels;
using System.Threading;
using PATENT.DAL.EfModels;
using System.Web.Http.Filters;

namespace PATENT.Controllers
{
    public class PatentsController : Controller
    {
        private ServiceDBContext db = new ServiceDBContext();

        // GET: Patents
        [Authorize]
        public ActionResult Index()
        {
            if(Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return View(db.Patents.ToList());
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Patents/Details/5
        public ActionResult Details(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Patent patent = db.Patents.Find(id);
                if (patent == null)
                {
                    return HttpNotFound();
                }
                return View(patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }

            
        }

        // GET: Patents/Create
        public ActionResult Create()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Patent newPatent = new Patent();
                db.Patents.Add(newPatent);
                db.SaveChanges();

                //send existing Application to Edit method
                return RedirectToAction("Edit", "Patents", new { id = newPatent.PatentID });
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Patents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patent patent)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Patents.Add(patent);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // GET: Patents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Patent patent = db.Patents.Find(id);
                if (patent == null)
                {
                    return HttpNotFound();
                }
                return View(patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Patents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patent patent)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(patent).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }

            
        }

        [HttpPost]
        public ActionResult CreatePatentPayment(int id, Payment appPayment)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Patent patent = db.Patents
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.PatentID == id);

                patent.Payments.Add(appPayment);
                db.SaveChanges();

                return View("~/Views/Patents/Details.cshtml", model: patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpPost]
        public ActionResult CreatePatentComment(int id, Comment appComment)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Patent patent = db.Patents
                                .Include(m => m.Comments)
                                .SingleOrDefault(m => m.PatentID == id);

                patent.Comments.Add(appComment);
                db.SaveChanges();

                return View("~/Views/Patents/Details.cshtml", model: patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        [HttpGet]
        public ActionResult TryGetApplication(string businessNumber)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Application application = db.Applications
                                .SingleOrDefault(m => m.BusinessNumber == businessNumber);

                if(application == null)
                {
                    string model = "Sorry, but there are not specific application.";

                    return View("~/Views/Shared/WriteStringView.cshtml", model: model);
                }

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
                Patent patent = db.Patents
                                .Include(m => m.Payments)
                                .SingleOrDefault(m => m.PatentID == id);

                patent.Authors.Add(author);
                db.SaveChanges();

                //return View("~/Views/Applications/Edit.cshtml", model: application);
                return RedirectToAction("Edit", "Patents", new { id = patent.PatentID });
            }
            else
            {
                string str_model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: str_model);
            }
        }

        // GET: Patents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Patent patent = db.Patents.Find(id);
                if (patent == null)
                {
                    return HttpNotFound();
                }
                return View(patent);
            }
            else
            {
                string model = "You must be authenticated for this action. Please log in.";

                return View("~/Views/Shared/WriteStringView.cshtml", model: model);
            }
        }

        // POST: Patents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Patent patent = db.Patents.Find(id);
                db.Patents.Remove(patent);
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
