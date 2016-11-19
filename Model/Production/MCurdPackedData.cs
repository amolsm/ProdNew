using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MCurdPackedData
    {
        public int CurdPackedDataId { get; set; }

        public int RMRId { get; set; }

        public int CurdShiftId { get; set; }

        public DateTime CurdPackedDate { get; set; }

        public string PackingOperatorName { get; set; }

        public string ReceivedBy { get; set; }

        public double CurdCupQty { get; set; }

        public double Curd500MLQty { get; set; }

        public double Curd450MLQty { get; set; }

        public double ButterMilk200ML { get; set; }

        public double TotalQtyOfCurd { get; set; }

        public string ColdRoomNo { get; set; }

        public string flag { get; set; }
    }
}