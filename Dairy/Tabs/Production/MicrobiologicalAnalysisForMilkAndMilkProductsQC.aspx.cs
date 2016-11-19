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
    public partial class MicrobiologicalAnalysisForMilkAndMilkProductsQC : System.Web.UI.Page
    {
        MMicrobiologicalAnalysisForMilkAndMilkProductsQC mmbafmampqc;
        BMicrobiologicalAnalysisForMilkAndMilkProductsQC bmbafmampqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails();
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
                mmbafmampqc = new MMicrobiologicalAnalysisForMilkAndMilkProductsQC();
                bmbafmampqc = new BMicrobiologicalAnalysisForMilkAndMilkProductsQC();
                int Result = 0;
                mmbafmampqc.MicrobiologicalAnalysisForMilkAndMilkProductsQCId = 0;
                mmbafmampqc.MicrobiologicalAnalysisForMilkAndMilkProductsQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mmbafmampqc.MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmbafmampqc.TestedBy=string.IsNullOrEmpty(txtTestedBy.Text)?string.Empty :txtTestedBy.Text;
                mmbafmampqc.ActionTakenBy = string.IsNullOrEmpty(txtActionTakenBy.Text) ? string.Empty : txtActionTakenBy.Text;
                mmbafmampqc.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
                mmbafmampqc.SampleTakenPlace = string.IsNullOrEmpty(txtSampleTakenPlace.Text) ? string.Empty : txtSampleTakenPlace.Text;
                mmbafmampqc.SampleTestingTime=string.IsNullOrEmpty(txtSampleTestingTime.Text)?string.Empty :txtSampleTestingTime.Text;
                mmbafmampqc.ColiForm = string.IsNullOrEmpty(txtColiForm.Text) ? string.Empty : txtColiForm.Text;
                mmbafmampqc.TBCCFUAndML = string.IsNullOrEmpty(txtTBCCFUML.Text) ? string.Empty : txtTBCCFUML.Text;
                mmbafmampqc.YeastAndMouldCFUAndML = string.IsNullOrEmpty(txtYeastMouldCFUML.Text) ? string.Empty : txtYeastMouldCFUML.Text;
                mmbafmampqc.CorrectiveActionRequired = string.IsNullOrEmpty(txtCorrectiveActionRequired.Text) ? string.Empty : txtCorrectiveActionRequired.Text;
                mmbafmampqc.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
                mmbafmampqc.flag = "Insert";
                Result = bmbafmampqc.microbiologicalmilkproductdata(mmbafmampqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;  
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Microbiological Analysis For Milk And Milk ProductsQC Added  Successfully";
                    pnlError.Update();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);

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
            mmbafmampqc = new MMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            bmbafmampqc = new BMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            int Result = 0;
            mmbafmampqc.MicrobiologicalAnalysisForMilkAndMilkProductsQCId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mmbafmampqc.MicrobiologicalAnalysisForMilkAndMilkProductsQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmbafmampqc.MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmbafmampqc.TestedBy = string.IsNullOrEmpty(txtTestedBy.Text) ? string.Empty : txtTestedBy.Text;
            mmbafmampqc.ActionTakenBy = string.IsNullOrEmpty(txtActionTakenBy.Text) ? string.Empty : txtActionTakenBy.Text;
            mmbafmampqc.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mmbafmampqc.SampleTakenPlace = string.IsNullOrEmpty(txtSampleTakenPlace.Text) ? string.Empty : txtSampleTakenPlace.Text;
            mmbafmampqc.SampleTestingTime = string.IsNullOrEmpty(txtSampleTestingTime.Text) ? string.Empty : txtSampleTestingTime.Text;
            mmbafmampqc.ColiForm = string.IsNullOrEmpty(txtColiForm.Text) ? string.Empty : txtColiForm.Text;
            mmbafmampqc.TBCCFUAndML = string.IsNullOrEmpty(txtTBCCFUML.Text) ? string.Empty : txtTBCCFUML.Text;
            mmbafmampqc.YeastAndMouldCFUAndML = string.IsNullOrEmpty(txtYeastMouldCFUML.Text) ? string.Empty : txtYeastMouldCFUML.Text;
            mmbafmampqc.CorrectiveActionRequired = string.IsNullOrEmpty(txtCorrectiveActionRequired.Text) ? string.Empty : txtCorrectiveActionRequired.Text;
            mmbafmampqc.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
            mmbafmampqc.flag = "Update";
            Result = bmbafmampqc.microbiologicalmilkproductdata(mmbafmampqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Microbiological Analysis For Milk And Milk ProductsQC Updated  Successfully";
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

            //return Result
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpMicrobiologicalAnalysisForMilkQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails(Id);



                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails()
        {
            bmbafmampqc = new BMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            DataSet DS = new DataSet();
            DS = bmbafmampqc.GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMicrobiologicalAnalysisForMilkQC.DataSource = DS;
                rpMicrobiologicalAnalysisForMilkQC.DataBind();
            }
        }

        public void GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails(int MicrobiologicalAnalysisForMilkAndMilkProductsQCId)
        {
            DataSet DS = new DataSet();
            bmbafmampqc = new BMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            DS = bmbafmampqc.GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetailsById(MicrobiologicalAnalysisForMilkAndMilkProductsQCId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MicrobiologicalAnalysisForMilkAndMilkProductsQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MicrobiologicalAnalysisForMilkAndMilkProductsQCDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId"]).ToString()).Selected = true;
                }
                txtTestedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TestedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TestedBy"].ToString();
                txtActionTakenBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ActionTakenBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ActionTakenBy"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString();
                txtSampleTakenPlace.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SampleTakenPlace"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SampleTakenPlace"].ToString();
                txtSampleTestingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SampleTestingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SampleTestingTime"].ToString();
                txtColiForm.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColiForm"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColiForm"].ToString();
                txtTBCCFUML.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TBCCFUAndML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TBCCFUAndML"].ToString();
                txtYeastMouldCFUML.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["YeastAndMouldCFUAndML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["YeastAndMouldCFUAndML"].ToString();
                txtCorrectiveActionRequired.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CorrectiveActionRequired"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CorrectiveActionRequired"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
    }
}