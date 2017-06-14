using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PATENT.DAL.EfModels
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [DisplayName("Выполенный % работы")]
        public int PercentOwnership { get; set; }
    }
}
