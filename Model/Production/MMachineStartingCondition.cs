using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMachineStartingCondition
    {
        public int MachineStartingConditionId { get; set; }

        public int RMRId { get; set; }

        public DateTime MachineStartingConditiondDate { get; set; }

        public int MachineStartingConditionShiftId { get; set; }

        public string MachineName { get; set; }

        public double Pasteurizer1 { get; set; }

        public double Pasteurizer2 { get; set; }

        public double Homogenizer1 { get; set; }

        public double Homogenizer2 { get; set; }

        public string SeparatorPump { get; set; }

        public string BDTill { get; set; }

        public string Report { get; set; }

        public string Service { get; set; }

        public string Pending { get; set; }

        public int MachineConditionStatus { get; set; }

        public string flag { get; set; }
    }
}