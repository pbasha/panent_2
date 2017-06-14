using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATENT.Models
{
    public class HelpRequestObject
    {
        //patent
        public bool IsNewModel { get; set; }
        public bool HaveInvLevel { get; set; }
        public bool IsIndastryUsable { get; set; }
        public bool IsProcessOrMethor { get; set; }
        public bool IsProdact { get; set; }
        public bool IsDesignOnly { get; set; }
        public bool IsProcessSecurity { get; set; }

        //copyright
        public bool DoYouWantToShare { get; set; }
        public bool IsIdea { get; set; }
    }
}