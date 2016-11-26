using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MPersonalHygieneCheckList
    {
        public int PersonalHygieneCheckListId { get; set; }

        public DateTime PersonalHygieneCheckListDate { get; set; }

        public int EmployeeId { get; set; }

        public int DesignationId { get; set; }

        public bool  UniformCleaning { get; set; }

        public bool Nail { get; set; }

        public bool Cap { get; set; }

        public bool ApronLab { get; set; }

        public bool BeardCrimp { get; set; }

        public bool HandGloves { get; set; }

        public bool Mask { get; set; }

        public string flag { get; set; }
    }
}