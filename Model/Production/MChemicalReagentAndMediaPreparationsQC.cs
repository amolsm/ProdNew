using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MChemicalReagentAndMediaPreparationsQC
    {
        public int ChemicalReagentAndMediaPreparationsQCId { get; set; }

        public DateTime ChemicalReagentAndMediaPreparationsQCDate { get; set; }

        public DateTime ReagentMfgDate { get; set; }

        public DateTime ReagentExpDate { get; set; }

        public DateTime SolutionPreparationDate { get; set; }

        public DateTime SolutionExpDate { get; set; }

        public double Phosphatase { get; set; }

        public string Media { get; set; }

        public double MBRT { get; set; }

        public double RosalicAcid { get; set; }

        public double Neutrilizer { get; set; }

        public double SodiumHydrogenCarbonate { get; set; }

        public double SodiumCarbonateAnHydrous { get; set; }

        public double ParanitrophenylPhosphataseDisodiumSalt { get; set; }

        public double DistilledWater { get; set; }

        public double ReagentQuantity { get; set; }

        public double PreparationQuantity { get; set; }

        public double ReagentLotNo { get; set; }

        public string Others { get; set; }

        public string PreparedBy { get; set; }

        public string VarifiedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string flag { get; set; }
    }
}