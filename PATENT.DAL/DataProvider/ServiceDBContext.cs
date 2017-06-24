
using PATENT.DAL.EFModels;
using System.Data.Entity;

namespace PATENT.DAL.DataProvider
{
    public class ServiceDBContext : DbContext
    {
        public ServiceDBContext() { }

        public DbSet<Patent> Patents { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Copyright> Copyrights { get; set; }
    }
}
