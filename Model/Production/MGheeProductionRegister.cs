using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MGheeProductionRegister
    {
        public int GheeProductionRegisterId { get; set; }

        public int RMRId { get; set; }

        public DateTime GheeProductionRegisterDate { get; set; }

        public int GheeProductionRegisterShiftId { get; set; }

        public string CreamQualityPhysical { get; set; }

        public string CreamQualityOthers { get; set; }

        public string CreamQualityCheckedBy { get; set; }

        public string CreamApprovedBy { get; set; }

        public double HeatingTemperature { get; set; }

        public string BoilingStartingTime { get; set; }

        public string BoilingEndTime { get; set; }

        public string SettingStartTime { get; set; }

        public string SettingEndTime { get; set; }

        public double ResidueQuantity { get; set; }

        public string VesselsCleaning { get; set; }

        public string InoculationcultureQualityandAcidityFlavour { get; set; }

        public string InoculationcultureQualityandAciditySetting { get; set; }

        public double InoculationcultureQualityandAcidityTemperature { get; set; }

        public string QualityBeforePackingAppearing { get; set; }

        public string QualityBeforePackingFlavour { get; set; }

        public double FinalProductionQuantity { get; set; }

        public string InspectedBy { get; set; }

        public string VerifiedBy { get; set; }

        public string ApprovedBy { get; set; }

        public string flag { get; set; }
    }
}