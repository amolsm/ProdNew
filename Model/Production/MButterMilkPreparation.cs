using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MButterMilkPreparation
    {
        public int ButterMilkPreparationId { get; set; }

        public int RMRId { get; set; }

        public DateTime ButterMilkPreparationDate { get; set; }

        public int ButterMilkPreparationShiftId { get; set; }

        public double CurdQuantity { get; set; }

        public double GingerQuantity { get; set; }

        public double ChillyQuantity { get; set; }

        public double Salt { get; set; }

        public double CurryLeaves { get; set; }

        public double CorianderLeaves { get; set; }

        public double Lemon { get; set; }

        public double TotalPouchProduction { get; set; }

        public double Damage { get; set; }

        public string MixedAndTastedBy { get; set; }

        public string TastedAndMonitoredBy { get; set; }

        public string flag { get; set; }
    }
}