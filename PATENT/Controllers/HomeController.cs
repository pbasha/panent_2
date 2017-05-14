using System.Threading;
using System.Web.Mvc;

namespace PATENT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Main Page";
            string model = null;

            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                model = Thread.CurrentPrincipal.Identity.Name;

            return View(model: model);
        }

        public ActionResult Register()
        { 
            return PartialView("~/Views/ContentViews/_partialRegisterPage.cshtml");
        }

        public ActionResult Login()
        {
            return PartialView("~/Views/ContentViews/_partialLoginPage.cshtml");
        }
    }
}
