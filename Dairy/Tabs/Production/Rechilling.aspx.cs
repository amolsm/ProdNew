﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Model.Production;
using System.Data;
using DataAccess.Production;
using Bussiness.Production;
using System.Text;
using Comman;
using Dairy.App_code;
using Dairy;
using Bussiness;

namespace Dairy.Tabs.Production
{
    public partial class Rechilling : System.Web.UI.Page
    {
        MRechilling RData;
        BRechilling BData;
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                //ClearField();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                btnUpdate.Visible = false;
                //GetReachlingDetails();

            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("QCId", "Status as Name", "QCDetails", "IsActive =1");

            dpRechillStatus.DataSource = DS;
            dpRechillStatus.DataBind();
            //dpRechillStatus.Items.FindByText("Rejected").Enabled = false;
            //dpRechillStatus.Items.FindByText("Re-Chilling").Enabled = false;
            dpRechillStatus.Items.Insert(0, new ListItem("--Select Status--", "0"));
        }

        protected void btnAddRechilling_Click(object sender, EventArgs e)
        {
            RData = new MRechilling();
            BData = new BRechilling();
            int Result = 0;
            RData.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            foreach (RepeaterItem item in rpRechillingList.Items)
            {
                HiddenField hdfID2 = item.FindControl("hfQualityId") as HiddenField;
                if (hdfID2 != null)
                {
                    RData.QualityId = string.IsNullOrEmpty(hdfID2.Value) ? 0 : Convert.ToInt32(hdfID2.Value);
                }
            }
            RData.BatchNo = string.IsNullOrEmpty(txtBatchNO.Text) ? string.Empty : txtBatchNO.Text;
            RData.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            RData.Date = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            RData.SiloNo = Convert.ToInt32(txtSiloNo.Text);
            RData.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text;
            RData.Quantity = Convert.ToDouble(txtQuantity.Text);
            RData.IBTInTemperature = Convert.ToDouble(txtIBTInTemperature.Text);
            RData.IBTOutTemperature = Convert.ToDouble(txtIBTOutTemperature.Text);
            RData.MilkInTemperature = Convert.ToDouble(txtMilkInTemperature.Text);
            RData.MilkOutTemperature = Convert.ToDouble(txtMilkOutTemperature.Text);
            RData.RechilledBy = string.IsNullOrEmpty(txtRechilledBy.Text) ? string.Empty : txtRechilledBy.Text;
            RData.RechillStatusId = Convert.ToInt32(dpRechillStatus.SelectedItem.Value);
            RData.flag = "Insert";
            Result = BData.RechillingData(RData);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Rechilling Data Add  Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                pnlError.Update();
                string dates;
                dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                GetReachlingDetails(dates);
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblSuccess.Text = "Something went wrong plz contact site admin";
                pnlError.Update();
            }

            //return Result;
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                MRechilling RData = new MRechilling();
                BRechilling BData = new BRechilling();
                int Result = 0;
                RData.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                 RData.BatchNo = string.IsNullOrEmpty(txtBatchNO.Text) ? string.Empty : txtBatchNO.Text;
            RData.ShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            RData.Date = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            RData.SiloNo = Convert.ToInt32(txtSiloNo.Text);
            RData.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text;
            RData.Quantity = Convert.ToDouble(txtQuantity.Text);
            RData.IBTInTemperature = Convert.ToDouble(txtIBTInTemperature.Text);
            RData.IBTOutTemperature = Convert.ToDouble(txtIBTOutTemperature.Text);
            RData.MilkInTemperature = Convert.ToDouble(txtMilkInTemperature.Text);
            RData.MilkOutTemperature = Convert.ToDouble(txtMilkOutTemperature.Text);
            RData.RechilledBy = string.IsNullOrEmpty(txtRechilledBy.Text) ? string.Empty : txtRechilledBy.Text;
                RData.RechillStatusId = Convert.ToInt32(dpRechillStatus.SelectedItem.Value);
                RData.flag = "Update";

                Result = BData.RechillingData(RData);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Rechilling Data Updated  Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    ClearField();
                    string dates;
                    dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    GetReachlingDetails(dates);
                    uprouteList.Update();
                }
                else
                {
                    divDanger.Visible = false;
                    divwarning.Visible = true;
                    divSusccess.Visible = false;
                    lblSuccess.Text = "Something went wrong plz contact site admin";
                    pnlError.Update();
                }
            }
        }

        public void GetRechillingDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            BRechilling BData = new BRechilling();
            DS = BData.GetRechillingDataById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RMRDate"].ToString();

                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));

                    dpShiftDetails.ClearSelection();
                    string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RMRShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RMRShiftId"].ToString();
                    if(ShiftDetails=="")
                    {
                        dpShiftDetails.SelectedIndex = 0;
                    }
                    else
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RMRShiftId"]).ToString()).Selected = true;
                    }
                    //dpShiftDetails.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ShiftId"].ToString();
                    txtBatchNO.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                    txtSiloNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SiloNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SiloNo"].ToString();
                    txtTypeOfMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                    txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Qty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Qty"].ToString();
                    
                    txtIBTInTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IBTInTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IBTInTemperature"].ToString();
                    txtIBTOutTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IBTOutTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IBTOutTemperature"].ToString();
                    txtMilkInTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInTemperature"].ToString();
                    txtMilkOutTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkOutTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkOutTemperature"].ToString();
                    txtRechilledBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RechilledBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RechilledBy"].ToString();
                    dpRechillStatus.ClearSelection();
                    string RechillStatus = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RechillStatusId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RechillStatusId"].ToString();
                    if(RechillStatus=="")
                    {
                        dpRechillStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        dpRechillStatus.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["RechillStatusId"]).ToString()).Selected = true;
                    }
                }
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        public void GetReachlingDetails(string dates)
        {
            DataSet DS = new DataSet();
            BRechilling BData = new BRechilling();
            DS = BData.GetRechillingDetails(dates);

            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRechillingList.DataSource = DS;
                rpRechillingList.DataBind();
            }
            else
            {
                DS.Clear();
                rpRechillingList.DataSource = DS;
                rpRechillingList.DataBind();
            }

        }

        //public void GetRechillingDetailsbyID(int Id)
        //{
        //    DataSet DS = new DataSet();
        //    DARechilling dadata = new DARechilling();
        //    DS = dadata.GetRechillingDetailsbyID(Id);

        //    if (!Comman.Comman.IsDataSetEmpty(DS))
        //    {


        //    }
        //}
        protected void rpRechillingList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdfID2 = e.Item.FindControl("hfQualityId") as HiddenField;

            ClearField();
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int RMRId = 0;
            RMRId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Rechilling";
                        hId.Value = RMRId.ToString();
                        RMRId = Convert.ToInt32(hId.Value);
                        GetRechillingDetails(RMRId);
                        //GetRechillingDetailsbyID(Id);
                        //hfrid.Value = Id.ToString();
                        if(dpRechillStatus.SelectedIndex==2)
                        {
                            btnAddRechilling.Visible = false;
                            btnUpdate.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        else
                        {
                            btnAddRechilling.Visible = true;
                            btnUpdate.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        }
                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }

            }
        }

        public void ClearField()
        {
            txtSiloNo.Text = string.Empty;
            txtIBTInTemperature.Text =string.Empty;
            txtIBTOutTemperature.Text = string.Empty;
            txtMilkInTemperature.Text = string.Empty;
            txtMilkOutTemperature.Text = string.Empty;
            txtRechilledBy.Text = string.Empty;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
            GetReachlingDetails(dates);
        }
    }
}