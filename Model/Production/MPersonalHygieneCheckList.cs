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

        public string EmployeeName { get; set; }

        public string DesignationOfEmp { get; set; }

        public string UniformCleaning { get; set; }

        public string Nail { get; set; }

        public string Cap { get; set; }

        public string ApronLab { get; set; }

        public string BeardCrimp { get; set; }

        public string HandGloves { get; set; }

        public string Mask { get; set; }

        public string flag { get; set; }
    }
}