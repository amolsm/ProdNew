using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest
    {
        public int MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId { get; set; }

        public DateTime MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate { get; set; }

        public int MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId { get; set; }

        public string AreaOfExposure { get; set; }

        public string StartingTime { get; set; }

        public string EndTime { get; set; }

        public string TBCCount { get; set; }

        public string yeastAndMouldCount { get; set; }

        public string Merits { get; set; }

        public string Demerits { get; set; }

        public string CheckedBy { get; set; }

        public string VerifiedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string flag { get; set; }
    }
}