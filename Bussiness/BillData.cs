﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;
namespace Bussiness
{
    public class BillData
    {
        DBBill dbbill = new DBBill();
        public DataSet  GenrateBillByDate(string Date,int routeID,int salesid)
        {
            return dbbill.GenrateBillByDate(Date, routeID, salesid);
        }
        public DataSet BoothSalesAnalysis(string Date, int boothid, int brandid)
        {
            return dbbill.BoothSalesAnalysis(Date, boothid, brandid);
        }
        public DataSet BoothSalesAnalysisUser(string Date, int boothid, int userid, int brandid)
        {
            return dbbill.BoothSalesAnalysisUser(Date, boothid, userid, brandid);
        }
        public DataSet GenrateBIllDetailsID(int orderID)
        {
            return dbbill.GenrateBIllDetailsID(orderID);
        }
        public DataSet SalesAnalysisitemwiseByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            return dbbill.SalesAnalysisitemwiseByDate(StartDate, EndDate, routeID, BrandID);
        }
        public DataSet BillwiseSalesSummaryByDate(string StartDate, string EndDate, int routeID)
        {
            return dbbill.BillwiseSalesSummaryByDate(StartDate, EndDate, routeID);
        }
        public DataSet AgentSchemeDetails(int routeID)
        {
            return dbbill.AgentSchemeDetails( routeID);
        }

        public DataSet GenrateItemwiseSalesSummaryByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            return dbbill.GenrateItemwiseSalesSummaryByDate(StartDate, EndDate, routeID, BrandID);
        }
        public DataSet GenrateReportByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            return dbbill.GenrateReportByDate(StartDate, EndDate, routeID, BrandID);
        }
        public DataSet getStockforbooth(int boothid)
        {
            return dbbill.getStockforbooth(boothid);
        }
        public DataSet getStockforboothViewStock(int boothid, int brandid)
        {
            return dbbill.getStockforboothViewStock(boothid, brandid);
        }
        public DataSet getStockforboothLanding(int boothid, int userid, string ShiftDate)
        {
            return dbbill.getStockforboothLanding(boothid, userid, ShiftDate);
        }
        public DataSet getBoothUserSales(int boothid, int userid, string ShiftDate, int brandid)
        {
            return dbbill.getBoothUserSales(boothid, userid, ShiftDate, brandid);
        }
        public DataSet getEmployeeByUserId( int userid)
        {
            return dbbill.getEmployeeByUserId( userid);
        }
        public int EndBoothStockUser(int boothid, int userid, string shiftDate, string EndTime)
        {
            return dbbill.EndBoothStockUser(boothid, userid, shiftDate, EndTime);
        }
        public DataSet GenerateRoteSalesSummary(string StartDate, string EndDate, int routeID, int BrandID)
        {
            return dbbill.GenerateRoteSalesSummary(StartDate, EndDate, routeID, BrandID);
        }

        public DataSet GenrateBillForBoothByDate(string Date, int routeID)
        {
            return dbbill.GenrateBillForBoothByDate(Date, routeID);
        }

        public DataSet UpdatePrintedBillByDate(string Date, int routeID, int salesid)
        {
            return dbbill.UpdatePrintedBillByDate(Date, routeID, salesid);
        }
        public DataSet GenrateAgencyDuplicateBillByDate(string Date, int routeID, string StartBillNo, string EndBillNo)
        {
            return dbbill.GenrateAgencyDuplicateBillByDate(Date, routeID, StartBillNo, EndBillNo);
        }
        public DataSet GenrateRatewiseOrderSummaryByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            return dbbill.GenrateRatewiseOrderSummaryByDate(StartDate, EndDate, routeID, BrandID);
        }
        public DataSet BoothItemwiseSalesSummaryByDate(string StartDate, string EndDate, int AgentID, int BrandID)
        {
            return dbbill.BoothItemwiseSalesSummaryByDate(StartDate, EndDate, AgentID, BrandID);
        }

        public DataSet BoothBillwiseSalesSummaryByDate(string StartDate, int boothid, int userid)
        {
            return dbbill.BoothBillwiseSalesSummaryByDate(StartDate, boothid, userid);
        }

        public DataSet BoothLocalBillwiseSalesSummaryByDate(string StartDate, int boothid, int userid)
        {
            return dbbill.BoothLocalBillwiseSalesSummaryByDate(StartDate, boothid, userid);
        }

        public DataSet BoothSalesAnalysisitemwiseByDate(string StartDate, string EndDate, int AgentID, int BrandID)
        {
            return dbbill.BoothSalesAnalysisitemwiseByDate(StartDate, EndDate, AgentID, BrandID);
        }

        public DataSet BoothSalesAnalysisitemwise2ByDate(string StartDate, string EndDate, int AgentID, int BrandID)
        {
            return dbbill.BoothSalesAnalysisitemwise2ByDate(StartDate, EndDate, AgentID, BrandID);
        }

        public DataSet GenerateBoothRoteSalesSummary(string Date, int BoothID, int BrandID)
        {
            return dbbill.GenerateBoothRoteSalesSummary(Date, BoothID, BrandID);
        }

        public DataSet GetSchemeAmountForBillwiseSalesSummary(dynamic BillNo)
        {
            return dbbill.GetSchemeAmountForBillwiseSalesSummary(BillNo);
        }
        public DataSet GetSchemeAmountForBoothBillwiseSalesSummary(dynamic BillNo)
        {
            return dbbill.GetSchemeAmountForBoothBillwiseSalesSummary(BillNo);
        }


          //Marketing module

        public DataSet SalesComparisionreportbyDate(string StartDate, string EndDate,string Start2Date,string End2Date,  int routeID, int BrandID,int TypeID,int CommodityID)
        {
            return dbbill.SalesComparisionreportbyDate(StartDate, EndDate, Start2Date, End2Date, routeID, BrandID, TypeID, CommodityID);
        }

        public DataSet DespatchComparisionreportbyDate(string Start1Date, string End1Date, string Start2Date, string End2Date, int routeID, int BrandID)
        {
            return dbbill.DespatchComparisionreportbyDate(Start1Date, End1Date, Start2Date, End2Date, routeID, BrandID);
        }

        public DataSet ReturnComparisionreportbyDate(string Start1Date, string End1Date, string Start2Date, string End2Date, int routeID, int AgentID, int BrandID)
        {
            return dbbill.ReturnComparisionreportbyDate(Start1Date, End1Date, Start2Date, End2Date, routeID,AgentID, BrandID);
        }
        public DataSet SpotDamageComparisionreportbyDate(string Start1Date, string End1Date, string Start2Date, string End2Date, int routeID, int BrandID)
        {
            return dbbill.SpotDamageComparisionreportbyDate(Start1Date, End1Date, Start2Date, End2Date, routeID, BrandID);
        }
        public DataSet MarketingBillwiseSalesSummarybyDate(string StartDate, string EndDate, int RouteID,int AgentID)
        {
            return dbbill.MarketingBillwiseSalesSummarybyDate(StartDate, EndDate, RouteID,  AgentID);
        }

        public DataSet MarketingItemWiseSalesSummarybyDate(string StartDate, string EndDate, int AgentID)
        {
            return dbbill.MarketingItemWiseSalesSummarybyDate(StartDate, EndDate, AgentID);
        }

        public DataSet StaffAccountSalesSummarybyDate(string StartDate, string EndDate)
        {
            return dbbill.StaffAccountSalesSummarybyDate(StartDate, EndDate);
        }

        public DataSet PartywiseIncentiveSummary(string StartDate, string EndDate, int RouteID,int BrandID, int TypeID, int CommodityID)
        {
            return dbbill.PartywiseIncentiveSummary(StartDate, EndDate, RouteID, BrandID, TypeID, CommodityID);
        }

        public DataSet MarketingReportForSalesAnalysisitemwiseByDate(string StartDate, string EndDate, int routeID, int BrandID)
        {
            return dbbill.MarketingReportForSalesAnalysisitemwiseByDate(StartDate, EndDate, routeID, BrandID);
        }
    }
    }
