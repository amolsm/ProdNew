using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MMachineComplaintsAndRectifiedRecord
    {
        public int MachineComplaintsAndRectifiedRecordId { get; set; }

        public DateTime MachineComplaintsAndRectifiedRecordDate { get; set; }

        public int MachineComplaintsAndRectifiedRecordShiftId { get; set; }

        public string MachineName { get; set; }

        public string IdentifiedBy { get; set; }

        public string RectifiedBy { get; set; }

        public DateTime RectifiedDate { get; set; }

        public int MachineRectifiedStatus { get; set; }

        public string flag { get; set; }

        public string Status { get; set; }
    }
}