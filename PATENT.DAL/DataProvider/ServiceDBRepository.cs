using patent.DAL.EFModels;
using System.Collections.Generic;
using System.Linq;

namespace patent.DAL.DataProvider
{
    public class ServiceDBRepository
    {
        #region private filds

        private ServiceDBContext context;

        #endregion

        #region constructor

        public ServiceDBRepository()
        {
            context = new ServiceDBContext();
        }

        #endregion

        #region patents

        public Patent AddPatent(Patent item)
        {
            context.Patents.Add(item);
            context.SaveChanges();
            return item;
        }

        public Patent GetPatentById(int patent_id)
        {
            return context.Patents.Where(r => r.PatentID == patent_id).FirstOrDefault();
        }

        public IEnumerable<Patent> GetAllPatents()
        {
            return context.Patents;
        }

        public void DeletePatent(int patent_id)
        {
            Patent item = GetPatentById(patent_id);
            if (item != null)
            {
                context.Patents.Remove(item);
                context.SaveChanges();
            }
        }

        public bool UpdatePatent(Patent item)
        {
            Patent storedItem = GetPatentById(item.PatentID);

            if (storedItem != null)
            {
                storedItem.PatentName = item.PatentName;
                storedItem.InventorName = item.InventorName;
                storedItem.CreatingData = item.CreatingData;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region applications

        public Application AddApplication(Application item)
        {
            context.Applications.Add(item);
            context.SaveChanges();
            return item;
        }

        public Application GetApplicationById(int Application_id)
        {
            return context.Applications.Where(r => r.ApplicationID == Application_id).FirstOrDefault();
        }

        public IEnumerable<Application> GetAllApplications()
        {
            return context.Applications;
        }

        public void DeleteApplication(int Application_id)
        {
            Application item = GetApplicationById(Application_id);
            if (item != null)
            {
                context.Applications.Remove(item);
                context.SaveChanges();
            }
        }

        public bool UpdateApplication(Application item)
        {
            Application storedItem = GetApplicationById(item.ApplicationID);

            if (storedItem != null)
            {
                storedItem.PatentID = item.PatentID;

                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
