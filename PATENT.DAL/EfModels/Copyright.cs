using PATENT.DAL.EfModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PATENT.DAL.EFModels
{
    public class Copyright
    {
        [Key]
        public int CopyrightID { get; set; }        //ключевое поле для заявки, не выводится
        [DisplayName("№ дела")]
        public string BusinessNumber { get; set; }  //Номер дела (!)
        [DisplayName("Год")]
        public int Year { get; set; }               //год

        //1------------------------------------
        [DisplayName("Факультет")]
        public string Faculty { get; set; }     //факультет
        [DisplayName("Кафедра")]
        public string Department { get; set; }  //кафедра
        [DisplayName("Тематика")]
        public string Subjects { get; set; }    //тематика
        [DisplayName("№ темы")]
        public int TopicNumber { get; set; }    //номер темы

        //2------------------------------------
        [DisplayName("Название темы")]
        public string Name { get; set; }    //название темы

        //3------------------------------------
        [DisplayName("Авторы")]
        public virtual List<Author> Authors { get; set; }
            = new List<Author>(); //авторы

        //4------------------------------------
        [DisplayName("№ договора")]
        public int ContractNumber { get; set; }     //номер договора
        [DisplayName("Дата договора")]
        public DateTime ContractDate { get; set; }  //дата договора (от какого числа)
            = new DateTime(2017, 12, 1);

        //5.6------------------------------------
        [DisplayName("Страна")]
        public string Country { get; set; }         //страна
        [DisplayName("Адресат")]
        public string Destination { get; set; }     //адресат
        [DisplayName("Дата заявки")]
        public DateTime RequestDate { get; set; }   //дата заявки
            = new DateTime(2017, 12, 1);
        [DisplayName("Вых. №")]
        public int OutputNumber { get; set; }       //вых. номер

        //7.8------------------------------------

        //------------------------------------
        [DisplayName("Номер заявки")]
        public string ApplicationNumber { get; set; }   //номер заявки (пример: u2010 06622)
        [DisplayName("Приоритет")]
        public string Priority { get; set; }            //приоритет

        //таблица сборов за действия, относящиеся к охране права
        public virtual List<Payment> Payments { get; set; } 
            = new List<Payment>();

        //таблица комментариев по данной заявке
        public virtual List<Comment> Comments { get; set; } 
            = new List<Comment>();
    }
}
