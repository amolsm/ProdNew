using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMixPreparationIncrediantsAdded
    {
        public int MixPreparationIncrediantsAddedId { get; set; }

        public int RMRId { get; set; }

        public DateTime MixPreparationIncrediantsAddedDate { get; set; }

        public int MixPreparationIncrediantsAddedShiftId { get; set; }

        public double SMP { get; set; }

        public double Cream { get; set; }

        public string Milk { get; set; }

        public double Sugar { get; set; }

        public double Stabilizer { get; set; }

        public double Emulsifier { get; set; }

        public double TotalMixQty { get; set; }

        public string Remarks { get; set; }

        public string flag { get; set; }

    }
}