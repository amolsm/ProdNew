using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Production
{
    public class MEffluentTreatmentPlant
    {
        public int EffluentTreatmentPlantId { get; set; }

        public DateTime EffluentTreatmentPlantDate { get; set; }

        public int EffluentTreatmentPlantShiftId { get; set; }

        public string OperatedBy { get; set; }

        public string Remarks { get; set; }

        public string CollectionPumpAStartingTime { get; set; }

        public string CollectionPumpAEndTime { get; set; }

        public string CollectionPumpATotalRunningHours { get; set; }

        public string CollectionPumpBStartingTime { get; set; }

        public string CollectionPumpBEndTime { get; set; }

        public string CollectionPumpBTotalRunningHours { get; set; }

        public string AERATORStartingTime { get; set; }

        public string AERATOREndTime { get; set; }

        public string AERATORTotalRunningHours { get; set; }

        public string BLOWERAStartingTime { get; set; }

        public string BLOWERAEndTime { get; set; }

        public string BLOWERATotalRunningHours { get; set; }

        public string BLOWERBStartingTime { get; set; }

        public string BLOWERBEndTime { get; set; }

        public string BLOWERBTotalRunningHours { get; set; }

        public string ClarifierMechanismStartingTime { get; set; }

        public string ClarifierMechanismEndTime { get; set; }

        public string ClarifierMechanismTotalRunningHours { get; set; }

        public string SludgeReCirculationPumpAStartingTime { get; set; }

        public string SludgeReCirculationPumpAEndTime { get; set; }

        public string SludgeReCirculationPumpATotalRunningHours { get; set; }

        public string SludgeReCirculationPumpBStartingTime { get; set; }

        public string SludgeReCirculationPumpBEndTime { get; set; }

        public string SludgeReCirculationPumpBTotalRunningHours { get; set; }

        public string flag { get; set; }
    }
 }