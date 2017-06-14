using System;
using System.ComponentModel.DataAnnotations;

namespace PATENT.DAL.EfModels
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentName { get; set; }
        public float Amount { get; set; }
        public int PayNumber { get; set; }
        public DateTime Date { get; set; } = new DateTime(2017, 12, 1);
        public float TopicPart { get; set; }
    }
}
