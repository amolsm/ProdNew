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
    public partial class MicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest : System.Web.UI.Page
    {
        MMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest mmaoamcspt;
        BMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest bmaoamcspt;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails();
                txtStartingTime.Text = Convert.ToString(DateTime.Now.ToString("HH:mm"));
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
            mmaoamcspt = new MMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            bmaoamcspt = new BMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            int Result = 0;
            mmaoamcspt.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId = 0;
            mmaoamcspt.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmaoamcspt.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmaoamcspt.AreaOfExposure = string.IsNullOrEmpty(txtAreaOfExposure.Text) ? string.Empty : txtAreaOfExposure.Text;
            mmaoamcspt.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mmaoamcspt.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mmaoamcspt.TBCCount = string.IsNullOrEmpty(txtTBCCount.Text) ? string.Empty : txtTBCCount.Text;
            mmaoamcspt.yeastAndMouldCount = string.IsNullOrEmpty(txtyeastAndMouldCount.Text) ? string.Empty : txtyeastAndMouldCount.Text;
            mmaoamcspt.Merits = string.IsNullOrEmpty(txtMerits.Text) ? string.Empty : txtMerits.Text;
            mmaoamcspt.Demerits = string.IsNullOrEmpty(txtDemerits.Text) ? string.Empty : txtDemerits.Text;
            mmaoamcspt.CheckedBy = string.IsNullOrEmpty(txtCheckedBy.Text) ? string.Empty : txtCheckedBy.Text;
            mmaoamcspt.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mmaoamcspt.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mmaoamcspt.flag = "insert";
            Result = bmaoamcspt.MicrobiologicalCountSettlePlateTest(mmaoamcspt);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Microbiological Analysis Of Aerobic Microbial Count Settle Plate Test Data Added  Successfully";
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
            mmaoamcspt = new MMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            bmaoamcspt = new BMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            int Result = 0;
            mmaoamcspt.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mmaoamcspt.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmaoamcspt.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmaoamcspt.AreaOfExposure = string.IsNullOrEmpty(txtAreaOfExposure.Text) ? string.Empty : txtAreaOfExposure.Text;
            mmaoamcspt.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mmaoamcspt.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mmaoamcspt.TBCCount = string.IsNullOrEmpty(txtTBCCount.Text) ? string.Empty : txtTBCCount.Text;
            mmaoamcspt.yeastAndMouldCount = string.IsNullOrEmpty(txtyeastAndMouldCount.Text) ? string.Empty : txtyeastAndMouldCount.Text;
            mmaoamcspt.Merits = string.IsNullOrEmpty(txtMerits.Text) ? string.Empty : txtMerits.Text;
            mmaoamcspt.Demerits = string.IsNullOrEmpty(txtDemerits.Text) ? string.Empty : txtDemerits.Text;
            mmaoamcspt.CheckedBy = string.IsNullOrEmpty(txtCheckedBy.Text) ? string.Empty : txtCheckedBy.Text;
            mmaoamcspt.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mmaoamcspt.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mmaoamcspt.flag = "Update";
            Result = bmaoamcspt.MicrobiologicalCountSettlePlateTest(mmaoamcspt);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Microbiological Analysis Of Aerobic Microbial Count Settle Plate Test Data Updated  Successfully";
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

        protected void rpMicrobiologicalAnalysisofSettlePlateTest_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Microbiological Analysis Of Aerobic Microbial Count Settle Plate Test Data Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails()
        {
            bmaoamcspt = new BMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            DataSet DS = new DataSet();
            DS = bmaoamcspt.GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMicrobiologicalAnalysisofSettlePlateTest.DataSource = DS;
                rpMicrobiologicalAnalysisofSettlePlateTest.DataBind();
            }
        }

        public void GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails(int MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId)
        {
            DataSet DS = new DataSet();
            bmaoamcspt = new BMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            DS = bmaoamcspt.GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetailsById(MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId"]).ToString()).Selected = true;
                }
                txtAreaOfExposure.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AreaOfExposure"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AreaOfExposure"].ToString();
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartingTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtTBCCount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TBCCount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TBCCount"].ToString();
                txtyeastAndMouldCount.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["yeastAndMouldCount"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["yeastAndMouldCount"].ToString();
                txtMerits.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Merits"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Merits"].ToString();
                txtDemerits.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Demerits"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Demerits"].ToString();
                txtCheckedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CheckedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CheckedBy"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString();
                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApprovedBy"].ToString();
            }
        }
    }
}