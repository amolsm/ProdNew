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
    public partial class FumigationQC : System.Web.UI.Page
    {
        MFumigationQC mfqc;
        BFumigationQC bfqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //string date = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetFumigationQCDetails(dates);
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
            mfqc = new MFumigationQC();
            bfqc = new BFumigationQC();
            int Result = 0;
            mfqc.FumigationQCId = 0;
            mfqc.FumigationQCDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            mfqc.FumigationQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mfqc.AreaOfExposure = string.IsNullOrEmpty(txtAreaOfExposure.Text) ? string.Empty : txtAreaOfExposure.Text;
            mfqc.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mfqc.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mfqc.ChemicalUsed = string.IsNullOrEmpty(txtChemicalUsed.Text) ? string.Empty : txtChemicalUsed.Text;
            mfqc.Merits = string.IsNullOrEmpty(txtMerits.Text) ? string.Empty : txtMerits.Text;
            mfqc.Demerits = string.IsNullOrEmpty(txtDemerits.Text) ? string.Empty : txtDemerits.Text;
            mfqc.DoneBy = string.IsNullOrEmpty(txtDoneBy.Text) ? string.Empty : txtDoneBy.Text;
            mfqc.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mfqc.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mfqc.flag = "Insert";
            Result = bfqc.FumigationQCdata(mfqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "FumigationQC Data Added  Successfully";
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
            mfqc = new MFumigationQC();
            bfqc = new BFumigationQC();
            int Result = 0;
            mfqc.FumigationQCId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mfqc.FumigationQCDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
            mfqc.FumigationQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mfqc.AreaOfExposure = string.IsNullOrEmpty(txtAreaOfExposure.Text) ? string.Empty : txtAreaOfExposure.Text;
            mfqc.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mfqc.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mfqc.ChemicalUsed = string.IsNullOrEmpty(txtChemicalUsed.Text) ? string.Empty : txtChemicalUsed.Text;
            mfqc.Merits = string.IsNullOrEmpty(txtMerits.Text) ? string.Empty : txtMerits.Text;
            mfqc.Demerits = string.IsNullOrEmpty(txtDemerits.Text) ? string.Empty : txtDemerits.Text;
            mfqc.DoneBy = string.IsNullOrEmpty(txtDoneBy.Text) ? string.Empty : txtDoneBy.Text;
            mfqc.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mfqc.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mfqc.flag = "Update";
            Result = bfqc.FumigationQCdata(mfqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "FumigationQC Data Updated  Successfully";
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

        protected void rpFumigationQC_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int FumigationQCId = 0;
            FumigationQCId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        lblHeaderTab.Text = "Edit FumigationQC Data Details";
                        hId.Value = FumigationQCId.ToString();
                        FumigationQCId = Convert.ToInt32(hId.Value);
                        GetFumigationQCDetails(FumigationQCId);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetFumigationQCDetails(string dates)
        {
            bfqc = new BFumigationQC();
            DataSet DS = new DataSet();
            DS = bfqc.GetFumigationQCDetails(dates);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpFumigationQC.DataSource = DS;
                rpFumigationQC.DataBind();
            }
            else
            {
                DS.Clear();
                rpFumigationQC.DataSource = DS;
                rpFumigationQC.DataBind();
            }
        }

        public void GetFumigationQCDetails(int FumigationQCId)
        {
            DataSet DS = new DataSet();
            bfqc = new BFumigationQC();
            DS = bfqc.GetFumigationQCDetailsById (FumigationQCId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FumigationQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FumigationQCDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FumigationQCShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["FumigationQCShiftId"]).ToString()).Selected = true;
                }
                txtAreaOfExposure.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AreaOfExposure"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AreaOfExposure"].ToString();
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartingTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtChemicalUsed.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ChemicalUsed"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ChemicalUsed"].ToString();
                txtMerits.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Merits"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Merits"].ToString();
                txtDemerits.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Demerits"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Demerits"].ToString();
                txtDoneBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DoneBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DoneBy"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString();
                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApprovedBy"].ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
            GetFumigationQCDetails(dates);

        }

    }
}