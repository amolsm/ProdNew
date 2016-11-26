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
    public partial class EffluentTreatmentPlant : System.Web.UI.Page
    {
        MEffluentTreatmentPlant mftp;
        BEffluentTreatmentPlant bftp;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetEffluentTreatmentPlantDetails();
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
            mftp = new MEffluentTreatmentPlant();
            bftp = new BEffluentTreatmentPlant();
            int Result = 0;
            mftp.EffluentTreatmentPlantId = 0;
            mftp.EffluentTreatmentPlantDate = Convert.ToDateTime(txtDate.Text.ToString());
            mftp.EffluentTreatmentPlantShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mftp.OperatedBy = string.IsNullOrEmpty(txtOperatedBy.Text) ? string.Empty : txtOperatedBy.Text;
            mftp.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
            mftp.CollectionPumpAStartingTime = string.IsNullOrEmpty(txtAStartingTime.Text) ? string.Empty : txtAStartingTime.Text;
            mftp.CollectionPumpAEndTime = string.IsNullOrEmpty(txtAEndTime.Text) ? string.Empty : txtAEndTime.Text;
            mftp.CollectionPumpATotalRunningHours = string.IsNullOrEmpty(txtATotalHours.Text) ? string.Empty : txtATotalHours.Text;
            mftp.CollectionPumpBStartingTime = string.IsNullOrEmpty(txtBStartingTime.Text) ? string.Empty : txtBStartingTime.Text;
            mftp.CollectionPumpBEndTime = string.IsNullOrEmpty(txtBEndTime.Text) ? string.Empty : txtBEndTime.Text;
            mftp.CollectionPumpBTotalRunningHours = string.IsNullOrEmpty(txtBTotalHours.Text) ? string.Empty : txtBTotalHours.Text;
            mftp.AERATORStartingTime = string.IsNullOrEmpty(txtAERATORStartingTime.Text) ? string.Empty : txtAERATORStartingTime.Text;
            mftp.AERATOREndTime = string.IsNullOrEmpty(txtAERATOREndTime.Text) ? string.Empty : txtAERATOREndTime.Text;
            mftp.AERATORTotalRunningHours = string.IsNullOrEmpty(txtAERATORTotalHours.Text) ? string.Empty : txtAERATORTotalHours.Text;
            mftp.BLOWERAStartingTime = string.IsNullOrEmpty(txtBLOWERAStartingTime.Text) ? string.Empty : txtBLOWERAStartingTime.Text;
            mftp.BLOWERAEndTime = string.IsNullOrEmpty(txtBLOWERAEndTime.Text) ? string.Empty : txtBLOWERAEndTime.Text;
            mftp.BLOWERATotalRunningHours = string.IsNullOrEmpty(txtBLOWERATotalHours.Text) ? string.Empty : txtBLOWERATotalHours.Text;
            mftp.BLOWERBStartingTime = string.IsNullOrEmpty(txtBLOWERBStartingTime.Text) ? string.Empty : txtBLOWERBStartingTime.Text;
            mftp.BLOWERBEndTime = string.IsNullOrEmpty(txtBLOWERBEndTime.Text) ? string.Empty : txtBLOWERBEndTime.Text;
            mftp.BLOWERBTotalRunningHours = string.IsNullOrEmpty(txtBLOWERBTotalHours.Text) ? string.Empty : txtBLOWERBTotalHours.Text;
            mftp.ClarifierMechanismStartingTime = string.IsNullOrEmpty(txtClarifierMechanismStartingTime.Text) ? string.Empty : txtClarifierMechanismStartingTime.Text;
            mftp.ClarifierMechanismEndTime = string.IsNullOrEmpty(txtClarifierMechanismEndTime.Text) ? string.Empty : txtClarifierMechanismEndTime.Text;
            mftp.ClarifierMechanismTotalRunningHours = string.IsNullOrEmpty(txtClarifierMechanismTotalHours.Text) ? string.Empty : txtClarifierMechanismTotalHours.Text;
            mftp.SludgeReCirculationPumpAStartingTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpAStartingTime.Text) ? string.Empty : txtSludgeReCirculationpumpAStartingTime.Text;
            mftp.SludgeReCirculationPumpAEndTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpAEndTime.Text) ? string.Empty : txtSludgeReCirculationpumpAEndTime.Text;
            mftp.SludgeReCirculationPumpATotalRunningHours = string.IsNullOrEmpty(txtSludgeReCirculationpumpATotalHours.Text) ? string.Empty : txtSludgeReCirculationpumpATotalHours.Text;
            mftp.SludgeReCirculationPumpBStartingTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpBStartingTime.Text) ? string.Empty : txtSludgeReCirculationpumpBStartingTime.Text;
            mftp.SludgeReCirculationPumpBEndTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpBEndTime.Text) ? string.Empty : txtSludgeReCirculationpumpBEndTime.Text;
            mftp.SludgeReCirculationPumpBTotalRunningHours = string.IsNullOrEmpty(txtSludgeReCirculationpumpBTotalHours.Text) ? string.Empty : txtSludgeReCirculationpumpBTotalHours.Text;
            mftp.flag = "insert";
            Result = bftp.effluntplantdata(mftp);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Effluent Treatment Plant Data Added  Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx2').removeClass('collapsed-box');", true);
                pnlError.Update();
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
            mftp = new MEffluentTreatmentPlant();
            bftp = new BEffluentTreatmentPlant();
            int Result = 0;
            mftp.EffluentTreatmentPlantId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mftp.EffluentTreatmentPlantDate = Convert.ToDateTime(txtDate.Text.ToString());
            mftp.EffluentTreatmentPlantShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mftp.OperatedBy = string.IsNullOrEmpty(txtOperatedBy.Text) ? string.Empty : txtOperatedBy.Text;
            mftp.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
            mftp.CollectionPumpAStartingTime = string.IsNullOrEmpty(txtAStartingTime.Text) ? string.Empty : txtAStartingTime.Text;
            mftp.CollectionPumpAEndTime = string.IsNullOrEmpty(txtAEndTime.Text) ? string.Empty : txtAEndTime.Text;
            mftp.CollectionPumpATotalRunningHours = string.IsNullOrEmpty(txtATotalHours.Text) ? string.Empty : txtATotalHours.Text;
            mftp.CollectionPumpBStartingTime = string.IsNullOrEmpty(txtBStartingTime.Text) ? string.Empty : txtBStartingTime.Text;
            mftp.CollectionPumpBEndTime = string.IsNullOrEmpty(txtBEndTime.Text) ? string.Empty : txtBEndTime.Text;
            mftp.CollectionPumpBTotalRunningHours = string.IsNullOrEmpty(txtBTotalHours.Text) ? string.Empty : txtBTotalHours.Text;
            mftp.AERATORStartingTime = string.IsNullOrEmpty(txtAERATORStartingTime.Text) ? string.Empty : txtAERATORStartingTime.Text;
            mftp.AERATOREndTime = string.IsNullOrEmpty(txtAERATOREndTime.Text) ? string.Empty : txtAERATOREndTime.Text;
            mftp.AERATORTotalRunningHours = string.IsNullOrEmpty(txtAERATORTotalHours.Text) ? string.Empty : txtAERATORTotalHours.Text;
            mftp.BLOWERAStartingTime = string.IsNullOrEmpty(txtBLOWERAStartingTime.Text) ? string.Empty : txtBLOWERAStartingTime.Text;
            mftp.BLOWERAEndTime = string.IsNullOrEmpty(txtBLOWERAEndTime.Text) ? string.Empty : txtBLOWERAEndTime.Text;
            mftp.BLOWERATotalRunningHours = string.IsNullOrEmpty(txtBLOWERATotalHours.Text) ? string.Empty : txtBLOWERATotalHours.Text;
            mftp.BLOWERBStartingTime = string.IsNullOrEmpty(txtBLOWERBStartingTime.Text) ? string.Empty : txtBLOWERBStartingTime.Text;
            mftp.BLOWERBEndTime = string.IsNullOrEmpty(txtBLOWERBEndTime.Text) ? string.Empty : txtBLOWERBEndTime.Text;
            mftp.BLOWERBTotalRunningHours = string.IsNullOrEmpty(txtBLOWERBTotalHours.Text) ? string.Empty : txtBLOWERBTotalHours.Text;
            mftp.ClarifierMechanismStartingTime = string.IsNullOrEmpty(txtClarifierMechanismStartingTime.Text) ? string.Empty : txtClarifierMechanismStartingTime.Text;
            mftp.ClarifierMechanismEndTime = string.IsNullOrEmpty(txtClarifierMechanismEndTime.Text) ? string.Empty : txtClarifierMechanismEndTime.Text;
            mftp.ClarifierMechanismTotalRunningHours = string.IsNullOrEmpty(txtClarifierMechanismTotalHours.Text) ? string.Empty : txtClarifierMechanismTotalHours.Text;
            mftp.SludgeReCirculationPumpAStartingTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpAStartingTime.Text) ? string.Empty : txtSludgeReCirculationpumpAStartingTime.Text;
            mftp.SludgeReCirculationPumpAEndTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpAEndTime.Text) ? string.Empty : txtSludgeReCirculationpumpAEndTime.Text;
            mftp.SludgeReCirculationPumpATotalRunningHours = string.IsNullOrEmpty(txtSludgeReCirculationpumpATotalHours.Text) ? string.Empty : txtSludgeReCirculationpumpATotalHours.Text;
            mftp.SludgeReCirculationPumpBStartingTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpBStartingTime.Text) ? string.Empty : txtSludgeReCirculationpumpBStartingTime.Text;
            mftp.SludgeReCirculationPumpBEndTime = string.IsNullOrEmpty(txtSludgeReCirculationpumpBEndTime.Text) ? string.Empty : txtSludgeReCirculationpumpBEndTime.Text;
            mftp.SludgeReCirculationPumpBTotalRunningHours = string.IsNullOrEmpty(txtSludgeReCirculationpumpBTotalHours.Text) ? string.Empty : txtSludgeReCirculationpumpBTotalHours.Text;
            mftp.flag = "Update";
            Result = bftp.effluntplantdata(mftp);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Effluent Treatment Plant Data Updated  Successfully";
                pnlError.Update();
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

        protected void rpEffluentTreatmentPlant_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Bore Water Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetEffluentTreatmentPlantDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetEffluentTreatmentPlantDetails()
        {
            bftp = new BEffluentTreatmentPlant();
            DataSet DS = new DataSet();
            DS = bftp.GetEffluentTreatmentPlantDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpEffluentTreatmentPlant.DataSource = DS;
                rpEffluentTreatmentPlant.DataBind();
            }
        }

        public void GetEffluentTreatmentPlantDetails(int EffluentTreatmentPlantId)
        {
            DataSet DS = new DataSet();
            bftp = new BEffluentTreatmentPlant();
            DS = bftp.GetEffluentTreatmentPlantDetailsById(EffluentTreatmentPlantId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EffluentTreatmentPlantDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EffluentTreatmentPlantDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["EffluentTreatmentPlantShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["EffluentTreatmentPlantShiftId"]).ToString()).Selected = true;
                }
                txtOperatedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OperatedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OperatedBy"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                txtAStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CollectionPumpAStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CollectionPumpAStartingTime"].ToString();
                txtAEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CollectionPumpAEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CollectionPumpAEndTime"].ToString();
                txtATotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CollectionPumpATotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CollectionPumpATotalRunningHours"].ToString();
                txtBStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CollectionPumpBStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CollectionPumpBStartingTime"].ToString();
                txtBEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CollectionPumpBEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CollectionPumpBEndTime"].ToString();
                txtBTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CollectionPumpBTotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CollectionPumpBTotalRunningHours"].ToString();
                txtAERATORStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AERATORStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AERATORStartingTime"].ToString();
                txtAERATOREndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AERATOREndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AERATOREndTime"].ToString();
                txtAERATORTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AERATORTotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AERATORTotalRunningHours"].ToString();
                txtBLOWERAStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BLOWERAStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BLOWERAStartingTime"].ToString();
                txtBLOWERAEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BLOWERAEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BLOWERAEndTime"].ToString();
                txtBLOWERATotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BLOWERATotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BLOWERATotalRunningHours"].ToString();
                txtBLOWERBStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BLOWERBStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BLOWERBStartingTime"].ToString();
                txtBLOWERBEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BLOWERBEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BLOWERBEndTime"].ToString();
                txtBLOWERBTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BLOWERBTotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BLOWERBTotalRunningHours"].ToString();
                txtClarifierMechanismStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClarifierMechanismStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClarifierMechanismStartingTime"].ToString();
                txtClarifierMechanismEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClarifierMechanismEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClarifierMechanismEndTime"].ToString();
                txtClarifierMechanismTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClarifierMechanismTotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClarifierMechanismTotalRunningHours"].ToString();
                txtSludgeReCirculationpumpAStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SludgeReCirculationPumpAStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SludgeReCirculationPumpAStartingTime"].ToString();
                txtSludgeReCirculationpumpAEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SludgeReCirculationPumpAEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SludgeReCirculationPumpAEndTime"].ToString();
                txtSludgeReCirculationpumpATotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SludgeReCirculationPumpATotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SludgeReCirculationPumpATotalRunningHours"].ToString();
                txtSludgeReCirculationpumpBStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SludgeReCirculationPumpBStartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SludgeReCirculationPumpBStartingTime"].ToString();
                txtSludgeReCirculationpumpBEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SludgeReCirculationPumpBEndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SludgeReCirculationPumpBEndTime"].ToString();
                txtSludgeReCirculationpumpBTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SludgeReCirculationPumpBTotalRunningHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SludgeReCirculationPumpBTotalRunningHours"].ToString();
            }
        }
    }
}