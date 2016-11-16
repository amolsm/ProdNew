using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;
using Model;

namespace Bussiness
{
    public class MarketingData
    {
        DataSet DS = new DataSet();
     
        DBMarketing dbMarketing = new DBMarketing();
        public DataSet GetAgentInfoForSchemeRefund(int AgentID)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.GetAgentInfoForSchemeRefund(AgentID);
        }

        public DataSet GetSchemeRefundInfo(Marketings marketing)
        {

            dbMarketing = new DBMarketing();
            DS = new DataSet();

            try
            {
                DS = dbMarketing.GetSchemeRefundInfo(marketing);
                return DS;
            }
            catch (Exception)
            {

                throw;
            }


       
        }

        public int AddSchemeRefund(Marketings marketing)
        {
            dbMarketing = new DBMarketing();
            int Result = 0;
            try
            {
                Result = dbMarketing.AddSchemeRefund(marketing);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet AgentRefundSchemeSummary(string StartDate, string EndDate, int RouteID, int AgentID)
        {
            return dbMarketing.AgentRefundSchemeSummary(StartDate, EndDate, RouteID, AgentID);
        }

        public DataSet ItemWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            return dbMarketing.ItemWiseStaffSalesSummarybyDate(StartDate, EndDate, EmployeID);
        }

        public DataSet BillWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            return dbMarketing.BillWiseStaffSalesSummarybyDate(StartDate, EndDate, EmployeID);
        }

        public int AddAgentDamageReplacementRateSetup(string agentId, int routeid, int categoryid, int typeid, int commodityid, string damagereplacementrate, bool isActive)
        {
            dbMarketing = new DBMarketing();
            return dbMarketing.AddAgentDamageReplacementRateSetup(agentId, routeid, categoryid, typeid, commodityid, damagereplacementrate, isActive);
        }
    }
}