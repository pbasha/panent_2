using System;
using System.ComponentModel.DataAnnotations;

namespace PATENT.DAL.EfModels
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string TextData { get; set; }
        public DateTime Date { get; set; }
    }
}
