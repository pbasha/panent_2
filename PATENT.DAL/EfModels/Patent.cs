using System;
using System.ComponentModel.DataAnnotations;

namespace patent.DAL.EFModels
{
    public class Patent
    {
        [Key]
        public int PatentID { get; set; }
        public string InventorName { get; set; }
        public string PatentName { get; set; }
        public DateTime CreatingData { get; set; } = new DateTime(2017, 12, 1);
    }
}
