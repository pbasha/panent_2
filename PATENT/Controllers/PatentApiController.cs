using patent.DAL.DataProvider;
using patent.DAL.EFModels;
using System.Collections.Generic;
using System.Web.Http;

namespace PATENT.Controllers
{
    [Authorize]
    public class PatentApiController : ApiController
    {
        #region constructor

        public PatentApiController()
        {
            repositiry = new ServiceDBRepository();
        }

        #endregion

        #region get

        public IEnumerable<Patent> Get()
        {
            return repositiry.GetAllPatents();
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
