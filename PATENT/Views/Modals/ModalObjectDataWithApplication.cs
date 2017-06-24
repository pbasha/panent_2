using PATENT.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATENT.Views.Modals
{
    public class ModalObjectDataWithApplication
    {
        public Object Model { get; set; }
        public string Controller { get; set; }
        public string ControllerMethod { get; set; }
    }
}