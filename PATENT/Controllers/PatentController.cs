using patent.DAL.DataProvider;
using patent.DAL.EFModels;
using System.Threading;
using System.Web.Mvc;

namespace PATENT.Controllers
{
    //[Authorize]
    public class PatentController : Controller
    {
        #region constructor

        public PatentController()
        {
            repositiry = new ServiceDBRepository();
        }

        #endregion

        #region get

        public ActionResult Get()
        {
            var model = (Thread.CurrentPrincipal.Identity.IsAuthenticated) ? repositiry.GetAllPatents() : null;

            return PartialView("~/Views/Patent/_partialPatentsList.cshtml", model:model);
        }

        #endregion

        #region post

        public void Post(Patent newPatent)
        {
            repositiry.AddPatent(newPatent);
        }

        #endregion

        #region private logic

        ServiceDBRepository repositiry;

        #endregion
    }
}