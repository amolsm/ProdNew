using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MOpeningStockForMilkAndAllProducts
    {
        public int OpeningStockForMilkAndAllProductsId { get; set; }

        public int RMRId { get; set; }

        public DateTime OpeningStockForMilkAndAllProductsDate { get; set; }

        public int OpeningStockForMilkAndAllProductsShiftId { get; set; }

        public int SiloNoForMilk { get; set; }

        public string MilkType { get; set; }

        public double Quantity { get; set; }

        public double FAT { get; set; }

        public double SNF { get; set; }

        public double CLR { get; set; }

        public double Temperature { get; set; }

        public double Acidity { get; set; }

        public double MBRT { get; set; }

        public double HomoEfficiency { get; set; }

        public string Remarks { get; set; }

        public int OpeningStockForMilkAndAllProductsStatus { get; set; }

        public string Status { get; set; }

        public string flag { get; set; }
    }
}