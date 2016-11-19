using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMicrobiologicalAnalysisForMilkAndMilkProductsQC
    {
        public int MicrobiologicalAnalysisForMilkAndMilkProductsQCId { get; set; }

        public DateTime MicrobiologicalAnalysisForMilkAndMilkProductsQCDate { get; set; }

        public int MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId { get; set; }

        public string TestedBy { get; set; }

        public string ActionTakenBy { get; set; }

        public string VerifiedBy { get; set; }

        public string SampleTakenPlace { get; set; }

        public string SampleTestingTime { get; set; }

        public string ColiForm { get; set; }

        public string TBCCFUAndML { get; set; }

        public string YeastAndMouldCFUAndML { get; set; }

        public string CorrectiveActionRequired { get; set; }

        public string Remarks { get; set; }

        public string flag { get; set; }
    }
}