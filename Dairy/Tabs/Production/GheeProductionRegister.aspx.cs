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
    public partial class GheeProductionRegister : System.Web.UI.Page
    {

        MGheeProductionRegister mgpr;
        BGheeProductionRegister bgpr;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetGheeProductionRegisterDetails();
                txtBatchNo.ReadOnly = true;
                btnUpdate.Visible = false;
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
            mgpr = new MGheeProductionRegister();
            bgpr = new BGheeProductionRegister();
            int Result = 0;
            mgpr.GheeProductionRegisterId = 0;
            mgpr.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mgpr.GheeProductionRegisterDate = Convert.ToDateTime(txtDate.Text.ToString());
            mgpr.GheeProductionRegisterShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mgpr.CreamQualityPhysical = string.IsNullOrEmpty(txtCreamQualityPhysical.Text) ? string.Empty : txtCreamQualityPhysical.Text;
            mgpr.CreamQualityOthers = string.IsNullOrEmpty(txtCreamQualityOthers.Text) ? string.Empty : txtCreamQualityOthers.Text;
            mgpr.CreamQualityCheckedBy = string.IsNullOrEmpty(txtCreamQualityCheckedBy.Text) ? string.Empty : txtCreamQualityCheckedBy.Text; ;
            mgpr.CreamApprovedBy = string.IsNullOrEmpty(txtCreamApprovedBy.Text) ? string.Empty:txtCreamApprovedBy.Text;
            mgpr.HeatingTemperature =string.IsNullOrEmpty(txtHeatingTemp.Text)?0 :Convert.ToDouble(txtHeatingTemp.Text);
            mgpr.BoilingStartingTime = string.IsNullOrEmpty(txtBoilingStartingTime.Text) ? string.Empty : txtBoilingStartingTime.Text;
            mgpr.BoilingEndTime = string.IsNullOrEmpty(txtBoilingEndTime.Text) ? string.Empty : txtBoilingEndTime.Text;
            mgpr.SettingStartTime = string.IsNullOrEmpty(txtSettingStartTime.Text) ? string.Empty : txtSettingStartTime.Text;
            mgpr.SettingEndTime = string.IsNullOrEmpty(txtSetEndTime.Text) ? string.Empty : txtSetEndTime.Text;
            mgpr.ResidueQuantity = string.IsNullOrEmpty(txtResidueQuantity.Text) ? 0 : Convert.ToDouble(txtResidueQuantity.Text);
            mgpr.VesselsCleaning = string.IsNullOrEmpty(txtVesselsCleaning.Text) ? string.Empty : txtVesselsCleaning.Text;
            mgpr.InoculationcultureQualityandAcidityFlavour = string.IsNullOrEmpty(txtInoculationFlavour.Text) ? string.Empty : txtInoculationFlavour.Text;
            mgpr.InoculationcultureQualityandAciditySetting = string.IsNullOrEmpty(txtInoculationSetting.Text) ? string.Empty : txtInoculationSetting.Text;
            mgpr.InoculationcultureQualityandAcidityTemperature = string.IsNullOrEmpty(txtInoculationTemperature.Text) ? 0 : Convert.ToDouble(txtInoculationTemperature.Text);
            mgpr.QualityBeforePackingAppearing = string.IsNullOrEmpty(txtQualityBeforePackingAppearing.Text) ? string.Empty : txtQualityBeforePackingAppearing.Text;
            mgpr.QualityBeforePackingFlavour = string.IsNullOrEmpty(txtQualityBeforePackingFlavour.Text) ? string.Empty : txtQualityBeforePackingFlavour.Text;
            mgpr.FinalProductionQuantity = string.IsNullOrEmpty(txtFinalProductionQuantity.Text) ? 0 : Convert.ToDouble(txtFinalProductionQuantity.Text);
            mgpr.InspectedBy = string.IsNullOrEmpty(txtInspectedBy.Text) ? string.Empty : txtInspectedBy.Text;
            mgpr.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mgpr.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mgpr.flag = "Insert";
            Result =bgpr.gheedata(mgpr);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Ghee Production Register Data Added  Successfully";
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

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            mgpr = new MGheeProductionRegister();
            bgpr = new BGheeProductionRegister();
            int Result = 0;
            mgpr.GheeProductionRegisterId = 0;
            mgpr.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mgpr.GheeProductionRegisterDate = Convert.ToDateTime(txtDate.Text.ToString());
            mgpr.GheeProductionRegisterShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mgpr.CreamQualityPhysical = string.IsNullOrEmpty(txtCreamQualityPhysical.Text) ? string.Empty : txtCreamQualityPhysical.Text;
            mgpr.CreamQualityOthers = string.IsNullOrEmpty(txtCreamQualityOthers.Text) ? string.Empty : txtCreamQualityOthers.Text;
            mgpr.CreamQualityCheckedBy = string.IsNullOrEmpty(txtCreamQualityCheckedBy.Text) ? string.Empty : txtCreamQualityCheckedBy.Text; ;
            mgpr.CreamApprovedBy = string.IsNullOrEmpty(txtCreamApprovedBy.Text) ? string.Empty : txtCreamApprovedBy.Text;
            mgpr.HeatingTemperature = string.IsNullOrEmpty(txtHeatingTemp.Text) ? 0 : Convert.ToDouble(txtHeatingTemp.Text);
            mgpr.BoilingStartingTime = string.IsNullOrEmpty(txtBoilingStartingTime.Text) ? string.Empty : txtBoilingStartingTime.Text;
            mgpr.BoilingEndTime = string.IsNullOrEmpty(txtBoilingEndTime.Text) ? string.Empty : txtBoilingEndTime.Text;
            mgpr.SettingStartTime = string.IsNullOrEmpty(txtSettingStartTime.Text) ? string.Empty : txtSettingStartTime.Text;
            mgpr.SettingEndTime = string.IsNullOrEmpty(txtSetEndTime.Text) ? string.Empty : txtSetEndTime.Text;
            mgpr.ResidueQuantity = string.IsNullOrEmpty(txtResidueQuantity.Text) ? 0 : Convert.ToDouble(txtResidueQuantity.Text);
            mgpr.VesselsCleaning = string.IsNullOrEmpty(txtVesselsCleaning.Text) ? string.Empty : txtVesselsCleaning.Text;
            mgpr.InoculationcultureQualityandAcidityFlavour = string.IsNullOrEmpty(txtInoculationFlavour.Text) ? string.Empty : txtInoculationFlavour.Text;
            mgpr.InoculationcultureQualityandAciditySetting = string.IsNullOrEmpty(txtInoculationSetting.Text) ? string.Empty : txtInoculationSetting.Text;
            mgpr.InoculationcultureQualityandAcidityTemperature = string.IsNullOrEmpty(txtInoculationTemperature.Text) ? 0 : Convert.ToDouble(txtInoculationTemperature.Text);
            mgpr.QualityBeforePackingAppearing = string.IsNullOrEmpty(txtQualityBeforePackingAppearing.Text) ? string.Empty : txtQualityBeforePackingAppearing.Text;
            mgpr.QualityBeforePackingFlavour = string.IsNullOrEmpty(txtQualityBeforePackingFlavour.Text) ? string.Empty : txtQualityBeforePackingFlavour.Text;
            mgpr.FinalProductionQuantity = string.IsNullOrEmpty(txtFinalProductionQuantity.Text) ? 0 : Convert.ToDouble(txtFinalProductionQuantity.Text);
            mgpr.InspectedBy = string.IsNullOrEmpty(txtInspectedBy.Text) ? string.Empty : txtInspectedBy.Text;
            mgpr.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mgpr.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mgpr.flag = "Update";
            Result = bgpr.gheedata(mgpr);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Ghee Production Register Data Updated  Successfully";
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

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpGheeProductionRegister_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit FilmData Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetGheeProductionRegisterDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);


                        if (dpShiftDetails.SelectedIndex == 0 && txtCreamQualityPhysical.Text == "")
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

        public void GetGheeProductionRegisterDetails()
        {
            bgpr = new BGheeProductionRegister();
            DataSet DS = new DataSet();
            DS = bgpr.GetGheeProductionRegisterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpGheeProductionRegister.DataSource = DS;
                rpGheeProductionRegister.DataBind();
            }
        }

        public void GetGheeProductionRegisterDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bgpr = new BGheeProductionRegister();
            DS =  bgpr.GetGheeProductionRegisterDetailsById (RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["GheeProductionRegisterDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["GheeProductionRegisterDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["GheeProductionRegisterShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["GheeProductionRegisterShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["GheeProductionRegisterShiftId"]).ToString()).Selected = true;
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtCreamQualityPhysical.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamQualityPhysical"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamQualityPhysical"].ToString();
                txtCreamQualityOthers.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamQualityOthers"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamQualityOthers"].ToString();
                txtCreamQualityCheckedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamQualityCheckedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamQualityCheckedBy"].ToString();
                txtCreamApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamApprovedBy"].ToString();
                txtHeatingTemp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HeatingTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HeatingTemperature"].ToString();
                txtBoilingStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BoilingStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BoilingStartingTime"].ToString();
                txtBoilingEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BoilingEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BoilingEndTime"].ToString();
                txtSettingStartTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SettingStartTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SettingStartTime"].ToString();
                txtSetEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SettingEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SettingEndTime"].ToString();
                txtResidueQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ResidueQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ResidueQuantity"].ToString();
                txtVesselsCleaning.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VesselsCleaning"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VesselsCleaning"].ToString();
                txtInoculationFlavour.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InoculationcultureQualityandAcidityFlavour"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InoculationcultureQualityandAcidityFlavour"].ToString();
                txtInoculationSetting.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InoculationcultureQualityandAciditySetting"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InoculationcultureQualityandAciditySetting"].ToString();
                txtInoculationTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InoculationcultureQualityandAcidityTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InoculationcultureQualityandAcidityTemperature"].ToString();
                txtQualityBeforePackingAppearing.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityBeforePackingAppearing"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QualityBeforePackingAppearing"].ToString();
                txtQualityBeforePackingFlavour.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["QualityBeforePackingFlavour"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["QualityBeforePackingFlavour"].ToString();
                txtFinalProductionQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FinalProductionQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FinalProductionQuantity"].ToString();
                txtInspectedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["InspectedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["InspectedBy"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString();
                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApprovedBy"].ToString();

            }
        }
    }
}