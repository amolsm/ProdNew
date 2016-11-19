using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MBoreWater
    {
        public int BoreWaterId { get; set; }

        public DateTime BoreWaterDate { get; set; }

        public int BoreWaterShiftId { get; set; }

        public string OperatedBy { get; set; }

        public string StartingTime { get; set; }

        public string EndTime { get; set; }

        public string TotalHours { get; set; }

        public string flag { get; set; }
    }
}