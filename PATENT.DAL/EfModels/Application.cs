using System.ComponentModel.DataAnnotations;

namespace patent.DAL.EFModels
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
        public int PatentID { get; set; }
    }
}
