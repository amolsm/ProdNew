using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MFumigationQC
    {
        public int FumigationQCId { get; set; }

        public DateTime FumigationQCDate { get; set; }

        public int FumigationQCShiftId { get; set; }

        public string AreaOfExposure { get; set; }

        public string StartingTime { get; set; }

        public string EndTime { get; set; }

        public string ChemicalUsed { get; set; }

        public string Merits { get; set; }

        public string Demerits { get; set; }

        public string DoneBy { get; set; }

        public string VerifiedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string flag { get; set; }
    }
}