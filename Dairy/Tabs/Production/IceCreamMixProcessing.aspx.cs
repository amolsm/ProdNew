using System;
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
    public partial class IceCreamMixProcessing : System.Web.UI.Page
    {
        MIceCreamMixProcessing mimp;
        BIceCreamMixProcessing bimp;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetIceCreamMixProcessingDetails();
                btnUpdate.Visible = false;
                txtBatchNo.ReadOnly = true;
            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mimp = new MIceCreamMixProcessing();
                bimp = new BIceCreamMixProcessing();
                int Result = 0;
                mimp.IceCreamMixProcessingId = 0;
                mimp.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mimp.IceCreamMixProcessingDate = Convert.ToDateTime(txtDate.Text.ToString());
                mimp.IceCreamMixProcessingShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mimp.StartingTime = txtStartingTime.Text;
                mimp.EndTime = txtEndTime.Text;
                mimp.BatchQuantity = string.IsNullOrEmpty(txtBatchQuantity.Text) ? 0 : Convert.ToDouble(txtBatchQuantity.Text);
                mimp.HeatTemperature = string.IsNullOrEmpty(txtHeatTemperature.Text) ? 0 : Convert.ToDouble(txtHeatTemperature.Text);
                mimp.homogenizerPressureStage1 = string.IsNullOrEmpty(txthomogenizerPressureStage1.Text) ? 0 : Convert.ToDouble(txthomogenizerPressureStage1.Text);
                mimp.HomogenizerPressureStage2 = string.IsNullOrEmpty(txtHomogenizerPressureStage2.Text) ? 0 : Convert.ToDouble(txtHomogenizerPressureStage2.Text);
                mimp.ChillingTemperature = string.IsNullOrEmpty(txtChillingTemperature.Text) ? 0 : Convert.ToDouble(txtChillingTemperature.Text);
                mimp.AGINGStartingTime = txtAGINGStartingTime.Text;
                mimp.AGINGEndTime = txtAGINGEndTime.Text;
                mimp.FinalTemperatureInAGINGVAT = string.IsNullOrEmpty(txtFinalTemperatureInAGINGVAT.Text) ? 0 : Convert.ToDouble(txtFinalTemperatureInAGINGVAT.Text);
                mimp.OperatedBy = txtOperatedBy.Text;
                mimp.TechnicianName = txtTechnicianName.Text;
                mimp.Remarks = txtRemarks.Text;
                mimp.flag = "Insert";
                Result =bimp.icecreamdata(mimp);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Ice Cream Mix Processing Data Add  Successfully";
                    pnlError.Update();
                    // GetPastDetails();
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mimp = new MIceCreamMixProcessing();
                bimp = new BIceCreamMixProcessing();
                int Result = 0;
                mimp.IceCreamMixProcessingId = 0;
                mimp.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mimp.IceCreamMixProcessingDate = Convert.ToDateTime(txtDate.Text.ToString());
                mimp.IceCreamMixProcessingShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mimp.StartingTime = txtStartingTime.Text;
                mimp.EndTime = txtEndTime.Text;
                mimp.BatchQuantity = string.IsNullOrEmpty(txtBatchQuantity.Text) ? 0 : Convert.ToDouble(txtBatchQuantity.Text);
                mimp.HeatTemperature = string.IsNullOrEmpty(txtHeatTemperature.Text) ? 0 : Convert.ToDouble(txtHeatTemperature.Text);
                mimp.homogenizerPressureStage1 = string.IsNullOrEmpty(txthomogenizerPressureStage1.Text) ? 0 : Convert.ToDouble(txthomogenizerPressureStage1.Text);
                mimp.HomogenizerPressureStage2 = string.IsNullOrEmpty(txtHomogenizerPressureStage2.Text) ? 0 : Convert.ToDouble(txtHomogenizerPressureStage2.Text);
                mimp.ChillingTemperature = string.IsNullOrEmpty(txtChillingTemperature.Text) ? 0 : Convert.ToDouble(txtChillingTemperature.Text);
                mimp.AGINGStartingTime = txtAGINGStartingTime.Text;
                mimp.AGINGEndTime = txtAGINGEndTime.Text;
                mimp.FinalTemperatureInAGINGVAT = string.IsNullOrEmpty(txtFinalTemperatureInAGINGVAT.Text) ? 0 : Convert.ToDouble(txtFinalTemperatureInAGINGVAT.Text);
                mimp.OperatedBy = txtOperatedBy.Text;
                mimp.TechnicianName = txtTechnicianName.Text;
                mimp.Remarks = txtRemarks.Text;
                mimp.flag = "Update";
                Result = bimp.icecreamdata(mimp);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Ice Cream Mix Processing Data Update  Successfully";
                    pnlError.Update();
                    // GetPastDetails();
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
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpIceCreamMixProcessing_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int Id = 0;
            Id = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit Traceability Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetIceCreamMixProcessingDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);


                        if (dpShiftDetails.SelectedIndex == 0 && txtStartingTime.Text == "")
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                        }
                        else
                        {
                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                        }

                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetIceCreamMixProcessingDetails()
        {
            bimp = new BIceCreamMixProcessing();
            DataSet DS = new DataSet();
            DS =bimp.GetIceCreamMixProcessingDetails ();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpIceCreamMixProcessing.DataSource = DS;
                rpIceCreamMixProcessing.DataBind();
            }
        }

        public void GetIceCreamMixProcessingDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bimp = new BIceCreamMixProcessing();
            DS =bimp.GetIceCreamMixProcessingDetailsById (RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamMixProcessingDate"].ToString()) ? string.Empty : Convert.ToDateTime(DS.Tables[0].Rows[0]["IceCreamMixProcessingDate"]).ToString("yyyy-MM-dd");
                //txtDate.Text = DATE;
                //dpShiftDetails.ClearSelection();
                //if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IceCreamMixProcessingShiftId"]).ToString()) != null)
                //{
                //    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IceCreamMixProcessingShiftId"]).ToString()).Selected = true;
                //}

                //string DATE=string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamMixProcessingDate"].ToString())?string.Empty: DS.Tables[0].Rows[0]   ["IceCreamMixProcessingDate"].ToString() ;
                //if (DATE == "")
                //{
                //    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-mm-dd"));
                //}
                //else
                //{
                //    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-pk").DateTimeFormat);
                //    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-mm-dd"));
                //}


                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamMixProcessingDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceCreamMixProcessingDate"].ToString();
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                dpShiftDetails.ClearSelection();
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamMixProcessingShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceCreamMixProcessingShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IceCreamMixProcessingShiftId"]).ToString()).Selected = true;
                }

                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartingTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtBatchQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchQuantity"].ToString();
                txtHeatTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HeatTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HeatTemperature"].ToString();
                txthomogenizerPressureStage1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["homogenizerPressureStage1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["homogenizerPressureStage1"].ToString();
                txtHomogenizerPressureStage2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomogenizerPressureStage2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HomogenizerPressureStage2"].ToString();
                txtChillingTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ChillingTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ChillingTemperature"].ToString();
                txtAGINGStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AGINGStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AGINGStartingTime"].ToString();
                txtAGINGEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AGINGEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AGINGEndTime"].ToString();

                txtFinalTemperatureInAGINGVAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FinalTemperatureInAGINGVAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FinalTemperatureInAGINGVAT"].ToString();
                txtOperatedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OperatedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OperatedBy"].ToString();
                txtTechnicianName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TechnicianName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TechnicianName"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();


            }
        }
    }
}