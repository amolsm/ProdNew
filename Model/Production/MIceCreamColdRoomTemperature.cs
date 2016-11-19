using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MIceCreamColdRoomTemperature
    {
        public int IceCreamColdRoomTemperatureId { get; set; }

        public int RMRId { get; set; }

        public DateTime IceCreamColdRoomTemperatureDate { get; set; }

        public int IceCreamColdRoomTemperatureShiftId { get; set; }

        public string HardeningRoom { get; set; }

        public string AgingTank { get; set; }

        public string CandyTank { get; set; }

        public string ColdStorageRoom { get; set; }

        public double IBTTemperature { get; set; }

        public string CheckedBy { get; set; }

        public string verifierBy { get; set; }

        public int StatusId { get; set; }

        public string BreakAndDownServices { get; set; }

        public string flag { get; set; }
    }
}