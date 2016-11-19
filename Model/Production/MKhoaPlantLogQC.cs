using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MKhoaPlantLogQC
    {
        public int KhoaPlantLogQCId { get; set; }

        public int RMRId { get; set; }

        public DateTime KhoaPlantLogQCDate { get; set; }

        public int KhoaPlantLogQCShiftId { get; set; }

        public string TypeOfMilk { get; set; }

        public double SNF { get; set; }

        public double Acidity { get; set; }

        public double SugarAddedQuantity { get; set; }

        public double FinalProductQuantity { get; set; }

        public double BoilingTemperature { get; set; }

        public string QualityStartTime { get; set; }

        public string StartingTime { get; set; }

        public string EndTime { get; set; }

        public string CleanedBy { get; set; }

        public string ChemicalUsed { get; set; }

        public string Remarks { get; set; }

        public string PreparedBy { get; set; }

        public string CheckedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string flag { get; set; }
    }
}