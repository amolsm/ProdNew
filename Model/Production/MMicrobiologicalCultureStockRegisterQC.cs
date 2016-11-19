using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMicrobiologicalCultureStockRegisterQC
    {
        public int MicrobiologicalCultureStockRegisterQCId { get; set; }

        public DateTime MicrobiologicalStockDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime PackingDate { get; set; }

        public double OpeningStock { get; set; }

        public string Receipt { get; set; }

        public string Issue { get; set; }

        public string Damage { get; set; }

        public string Returned { get; set; }

        public double ClosingStock { get; set; }

        public string CultureUsed { get; set; }

        public string VerifiedBy { get; set; }

        public string flag { get; set; }

    }
}