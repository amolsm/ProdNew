using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MIceCreamMixProcessing
    {
        public int IceCreamMixProcessingId { get; set; }

        public int RMRId { get; set; }

        public DateTime IceCreamMixProcessingDate { get; set; }

        public int IceCreamMixProcessingShiftId { get; set; }

        public string StartingTime { get; set; }

        public string EndTime { get; set; }

        public double BatchQuantity { get; set; }

        public double HeatTemperature { get; set; }

        public double homogenizerPressureStage1 { get; set; }

        public double HomogenizerPressureStage2 { get; set; }

        public double ChillingTemperature { get; set; }

        public string AGINGStartingTime { get; set; }

        public string AGINGEndTime { get; set; }

        public double FinalTemperatureInAGINGVAT { get; set; }

        public string OperatedBy { get; set; }

        public string TechnicianName { get; set; }

        public string Remarks { get; set; }

        public string flag { get; set; }
    }
}