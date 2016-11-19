using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MAdulterationConfirmationTastQC
    {
        public int AdulterationConfirmationTestQCId { get; set; }

        public int RMRId { get; set; }

        public DateTime AdulterationConfirmationTestQCDate { get; set; }

        public int AdulterationConfirmationTestQCShiftId { get; set; }

        public double Sugar { get; set; }

        public double Starch { get; set; }

        public double HydrogenPeroxide { get; set; }

        public double Neutralizer { get; set; }

        public string Remarks { get; set; }

        public int AdulterationConfirmationTestQCStatus { get; set; }

        public string flag { get; set; }
    }
}