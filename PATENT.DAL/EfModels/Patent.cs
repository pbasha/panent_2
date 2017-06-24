using PATENT.DAL.EfModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PATENT.DAL.EFModels
{
    public class Patent
    {
        [Key]
        public int PatentID { get; set; }       //ключевое поле для патента, не выводится
        [DisplayName("№ п/п")]
        public string PPNumber { get; set; }    //№ п/п
        [DisplayName("№ дела")]
        public string BusinessNumber { get; set; }  //Номер дела (!)
        [DisplayName("Год")]
        public int Year { get; set; }           //год
        [DisplayName("Тип патента")]
        public PatentType PatentType { get; set; } //тип патента

        [DisplayName("№ патента")]
        public int PatentNumber { get; set; }       //патент №
        [DisplayName("Страна")]
        public string Country { get; set; }         //страна выдачи
        [DisplayName("Номер заявки")]
        public string ApplicationNumber { get; set; }// регистр. номер заявки
        [DisplayName("Приоритет")]
        public string Priority { get; set; }      //приоритет (дата подачи заявки)
        [DisplayName("Дата начала действия")]
        public DateTime StartDate { get; set; }     //дата начала действия патента
            = new DateTime(2017, 12, 1);
        [DisplayName("Дата публикации")]
        public DateTime PublicationDate { get; set; }//дата публикации
            = new DateTime(2017, 12, 1);
        [DisplayName("№ Бюл.")]
        public int BulNumber { get; set; }       //№ бюл.

        [DisplayName("Название темы")]
        public string PatentName { get; set; }      //название патента
        [DisplayName("Авторы")]
        public virtual List<Author> Authors { get; set; }
            = new List<Author>(); //авторы
        [DisplayName("Заявитель")]
        public string Applicant { get; set; }       //заявитель
        [DisplayName("Собственник")]
        public string PatentOwner { get; set; }     //собственник патента


        //1------------------------------------

        [DisplayName("Факультет")]
        public string Faculty { get; set; }     //факультет
        [DisplayName("Кафедра")]
        public string Department { get; set; }  //кафедра
        [DisplayName("Тематика")]
        public string Subjects { get; set; }    //тематика
        [DisplayName("№ темы")]
        public int TopicNumber { get; set; }    //номер темы

        //таблица сборов за действия, относящиеся к охране права
        public virtual List<Payment> Payments { get; set; }
            = new List<Payment>();

        //таблица комментариев по данной заявке
        public virtual List<Comment> Comments { get; set; }
            = new List<Comment>();

    }
}
