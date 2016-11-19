using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMachineAirCompressors
    {
        public int MachineAirCompressorsId { get; set; }

        public DateTime MachineAirCompressorsDate { get; set; }

        public int MachineAirCompressorsShiftId { get; set; }

        public string StartingTime { get; set; }

        public string EndTime { get; set; }

        public string TotalHours { get; set; }

        public string flag { get; set; }
    }
}