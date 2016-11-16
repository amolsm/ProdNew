﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAcess;
using Model;

namespace DataAccess
{
    public class DBMarketing
    {
        DataSet DS = new DataSet();
        DBHelper _DBHelper = new DBHelper();
        public DataSet GetAgentInfoForSchemeRefund(int AgentID)
        {
           
          
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID ", AgentID));
                DS = _DBHelper.ExecuteDataSet("mk_getagenttotalscheme", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public DataSet GetSchemeRefundInfo(Marketings marketing)
        {
            DS = new DataSet();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@AgentID", marketing.AgentID));
                paramCollection.Add(new DBParameter("@CreatedBy", marketing.CreatedBy));
                paramCollection.Add(new DBParameter("@TokanId", marketing.TokanNo));
                DS = _DBHelper.ExecuteDataSet("mk_GetAgentSchemeRefund", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }

        public int AddSchemeRefund(Marketings marketing)
        {
            int result = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RouteID", marketing.RouteID));
                paramCollection.Add(new DBParameter("@AgentID", marketing.AgentID));
                paramCollection.Add(new DBParameter("@TotalSchemeAmt", marketing.TotalSchemeAmt));
                paramCollection.Add(new DBParameter("@SchemerefundAmt", marketing.SchemerefundAmt));
                paramCollection.Add(new DBParameter("@balanceAmt", marketing.balanceAmt));
                paramCollection.Add(new DBParameter("@requestdate", marketing.requestdate));
                paramCollection.Add(new DBParameter("@refunddate", marketing.refunddate));
                paramCollection.Add(new DBParameter("@CreatedBy", marketing.CreatedBy));
                paramCollection.Add(new DBParameter("@TokanId", marketing.TokanNo));
                result = _DBHelper.ExecuteNonQuery("mk_AddSchemeRefund", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                string meassage = ex.ToString();

            }
            return result;
        }

        public DataSet AgentRefundSchemeSummary(string StartDate, string EndDate, int RouteID, int AgentID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RefundBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@RefundEndDate", EndDate));
            paramCollection.Add(new DBParameter("@RouteID", RouteID));
            paramCollection.Add(new DBParameter("@AgentID", AgentID));
            return _DBHelper.ExecuteDataSet("mk_AgentRefundSchemeSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet ItemWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@EmployeeID", EmployeID));

            return _DBHelper.ExecuteDataSet("mk_GetMarketingReportStaffItemwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet BillWiseStaffSalesSummarybyDate(string StartDate, string EndDate, int EmployeID)
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DispatchBeginDate", StartDate));
            paramCollection.Add(new DBParameter("@DispatchEndDate", EndDate));
            paramCollection.Add(new DBParameter("@EmployeeID", EmployeID));

            return _DBHelper.ExecuteDataSet("mk_StaffBillwiseSalesSummary", paramCollection, CommandType.StoredProcedure);
        }

        public int AddAgentDamageReplacementRateSetup(string agentId, int routeid, int categoryid, int typeid, int commodityid, string damagereplacementrate, bool isActive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@agentId ", agentId));
                paramCollection.Add(new DBParameter("@routeid ", routeid));
                paramCollection.Add(new DBParameter("@categoryid", categoryid));
                paramCollection.Add(new DBParameter("@typeid", typeid));
                paramCollection.Add(new DBParameter("@commodityid", commodityid));
                paramCollection.Add(new DBParameter("@damagereplacementrate", damagereplacementrate));
                paramCollection.Add(new DBParameter("@isActive ", isActive));

                result = _DBHelper.ExecuteNonQuery("mk_AddAgentDamageReplacementRateSetup", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return result;

        }
    }
    }
  
