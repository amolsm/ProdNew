using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MClosingStockForMilkInSiloAndAllProducts
    {
        public int ClosingStockForMilkInSiloAndAllProductsId { get; set; }

        public int RMRId { get; set; }

        public DateTime ClosingStockForMilkInSiloAndAllProductsDate { get; set; }

        public int ClosingStockForMilkInSiloAndAllProductsShiftId { get; set; }

        public int SiloNo { get; set; }

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

        public int ClosingStockForMilkInSiloAndAllProductsStatus { get; set; }

        public string Status { get; set; }

        public string flag { get; set; }
    }
}