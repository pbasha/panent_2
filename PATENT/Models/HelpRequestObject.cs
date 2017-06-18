using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATENT.Models
{
    public class HelpRequestObject
    {
        //patent
        public bool IsNewModel { get; set; }    //model
        public bool HaveInvLevel { get; set; }  //model
        public bool IsIndastryUsable { get; set; }
        public bool IsProcessOrMethor { get; set; }     //invention
        public bool IsNotDesignOnly { get; set; }          //invention

        //copyright
        public bool DoYouWantToShare { get; set; }
        public bool IsIdea { get; set; }
    }
}