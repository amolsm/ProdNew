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

    public partial class KhoaPlantLogQC : System.Web.UI.Page
    {
        MKhoaPlantLogQC mkplqc;
        BKhoaPlantLogQC bkplqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetKhoaPlantlogQCDetails();
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
            mkplqc = new MKhoaPlantLogQC();
            bkplqc = new BKhoaPlantLogQC();
            int Result = 0;
            mkplqc.KhoaPlantLogQCId = 0;
            mkplqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mkplqc.KhoaPlantLogQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mkplqc.KhoaPlantLogQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mkplqc.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text;
            mkplqc.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            mkplqc.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            mkplqc.SugarAddedQuantity = string.IsNullOrEmpty(txtSugarAddedQuantity.Text) ? 0 : Convert.ToDouble(txtSugarAddedQuantity.Text);
            mkplqc.FinalProductQuantity = string.IsNullOrEmpty(txtFinalProductQuantity.Text) ? 0 : Convert.ToDouble(txtFinalProductQuantity.Text);
            mkplqc.BoilingTemperature = string.IsNullOrEmpty(txtBoilingTemperature.Text) ? 0 : Convert.ToDouble(txtBoilingTemperature.Text);
            mkplqc.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mkplqc.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mkplqc.CleanedBy = string.IsNullOrEmpty(txtCleanedBy.Text) ? string.Empty : txtCleanedBy.Text;
            mkplqc.ChemicalUsed = string.IsNullOrEmpty(txtChemicalUsed.Text) ? string.Empty : txtChemicalUsed.Text;
            mkplqc.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
            mkplqc.PreparedBy = string.IsNullOrEmpty(txtPreparedBy.Text) ? string.Empty : txtPreparedBy.Text;
            mkplqc.CheckedBy = string.IsNullOrEmpty(txtCheckedBy.Text) ? string.Empty : txtCheckedBy.Text;
            mkplqc.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mkplqc.flag = "Insert";
            Result = bkplqc.khoadata(mkplqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Khoa Plant Log QC Data Added  Successfully";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            mkplqc = new MKhoaPlantLogQC();
            bkplqc = new BKhoaPlantLogQC();
            int Result = 0;
            mkplqc.KhoaPlantLogQCId = 0;
            mkplqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mkplqc.KhoaPlantLogQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mkplqc.KhoaPlantLogQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mkplqc.TypeOfMilk = string.IsNullOrEmpty(txtTypeOfMilk.Text) ? string.Empty : txtTypeOfMilk.Text;
            mkplqc.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
            mkplqc.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
            mkplqc.SugarAddedQuantity = string.IsNullOrEmpty(txtSugarAddedQuantity.Text) ? 0 : Convert.ToDouble(txtSugarAddedQuantity.Text);
            mkplqc.FinalProductQuantity = string.IsNullOrEmpty(txtFinalProductQuantity.Text) ? 0 : Convert.ToDouble(txtFinalProductQuantity.Text);
            mkplqc.BoilingTemperature = string.IsNullOrEmpty(txtBoilingTemperature.Text) ? 0 : Convert.ToDouble(txtBoilingTemperature.Text);
            mkplqc.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mkplqc.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mkplqc.CleanedBy = string.IsNullOrEmpty(txtCleanedBy.Text) ? string.Empty : txtCleanedBy.Text;
            mkplqc.ChemicalUsed = string.IsNullOrEmpty(txtChemicalUsed.Text) ? string.Empty : txtChemicalUsed.Text;
            mkplqc.Remarks = string.IsNullOrEmpty(txtRemarks.Text) ? string.Empty : txtRemarks.Text;
            mkplqc.PreparedBy = string.IsNullOrEmpty(txtPreparedBy.Text) ? string.Empty : txtPreparedBy.Text;
            mkplqc.CheckedBy = string.IsNullOrEmpty(txtCheckedBy.Text) ? string.Empty : txtCheckedBy.Text;
            mkplqc.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mkplqc.flag = "Update";
            Result = bkplqc.khoadata(mkplqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Khoa Plant Log QC Data Updated  Successfully";
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

        protected void rpKhoaPlantLogQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetKhoaPlantlogQCDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);

                        if (dpShiftDetails.SelectedIndex == 0 && txtTypeOfMilk.Text == "")
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

        public void GetKhoaPlantlogQCDetails()
        {
            bkplqc = new BKhoaPlantLogQC();
            DataSet DS = new DataSet();
            DS = bkplqc.GetKhoaPlantlogQCDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpKhoaPlantLogQC.DataSource = DS;
                rpKhoaPlantLogQC.DataBind();
            }
        }

        public void GetKhoaPlantlogQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bkplqc = new BKhoaPlantLogQC();
            DS =bkplqc.GetKhoaPlantlogQCDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
               string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KhoaPlantLogQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KhoaPlantLogQCDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KhoaPlantLogQCShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KhoaPlantLogQCShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {

                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["KhoaPlantLogQCShiftId"]).ToString()).Selected = true;
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtTypeOfMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TypeOfMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TypeOfMilk"].ToString();
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString();
                txtSugarAddedQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SugarAddedQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SugarAddedQuantity"].ToString();
                txtFinalProductQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FinalProductQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FinalProductQuantity"].ToString();
                txtBoilingTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BoilingTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BoilingTemperature"].ToString();
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartingTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtCleanedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CleanedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CleanedBy"].ToString();
                txtChemicalUsed.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ChemicalUsed"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ChemicalUsed"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                txtPreparedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PreparedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PreparedBy"].ToString();
                txtCheckedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CheckedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CheckedBy"].ToString();
                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApprovedBy"].ToString();

            }
        }
    }
}