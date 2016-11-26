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
    public partial class AdulterationConfirmationTastQC : System.Web.UI.Page
    {
        MAdulterationConfirmationTastQC mactqc;
        BAdulterationConfirmationTastQC bactqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetAdulterationConfirmationTastQCDetails();
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

            DS = BindCommanData.BindCommanDropDwon("MachineConditionStatusId", "Status as Name", "Prod_MachineConditionStatus", "IsActive =1");
            dpStatusDetails.DataSource = DS;
            dpStatusDetails.DataBind();
            dpStatusDetails.Items.FindByText("OK").Enabled = false;
            dpStatusDetails.Items.FindByText("NOT").Enabled = false;
            dpStatusDetails.Items.Insert(0, new ListItem("--QC Status--", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mactqc = new MAdulterationConfirmationTastQC();
                bactqc = new BAdulterationConfirmationTastQC();
                int Result = 0;
                mactqc.AdulterationConfirmationTestQCId = 0;
                mactqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mactqc.AdulterationConfirmationTestQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mactqc.AdulterationConfirmationTestQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mactqc.Sugar = string.IsNullOrEmpty(txtSugar.Text) ? 0 : Convert.ToDouble(txtSugar.Text);
                mactqc.Starch = string.IsNullOrEmpty(txtStarch.Text) ? 0 : Convert.ToDouble(txtStarch.Text);
                mactqc.HydrogenPeroxide = string.IsNullOrEmpty(txtHydrogenPeroxide.Text) ? 0 : Convert.ToDouble(txtHydrogenPeroxide.Text);
                mactqc.Neutralizer = string.IsNullOrEmpty(txtNeutralizer.Text) ? 0 : Convert.ToDouble(txtNeutralizer.Text);
                mactqc.Remarks = txtRemarks.Text;
                mactqc.AdulterationConfirmationTestQCStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mactqc.flag = "Insert";
                Result = bactqc.adulterationqcdata(mactqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Adulteration Confirmation Tast QC Data Add  Successfully";
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

                mactqc = new MAdulterationConfirmationTastQC();
                bactqc = new BAdulterationConfirmationTastQC();
                int Result = 0;
                mactqc.AdulterationConfirmationTestQCId = 0;
                mactqc.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mactqc.AdulterationConfirmationTestQCDate = Convert.ToDateTime(txtDate.Text.ToString());
                mactqc.AdulterationConfirmationTestQCShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mactqc.Sugar = string.IsNullOrEmpty(txtSugar.Text) ? 0 : Convert.ToDouble(txtSugar.Text);
                mactqc.Starch = string.IsNullOrEmpty(txtStarch.Text) ? 0 : Convert.ToDouble(txtStarch.Text);
                mactqc.HydrogenPeroxide = string.IsNullOrEmpty(txtHydrogenPeroxide.Text) ? 0 : Convert.ToDouble(txtHydrogenPeroxide.Text);
                mactqc.Neutralizer = string.IsNullOrEmpty(txtNeutralizer.Text) ? 0 : Convert.ToDouble(txtNeutralizer.Text);
                mactqc.Remarks = txtRemarks.Text;
                mactqc.AdulterationConfirmationTestQCStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mactqc.flag = "Update";
                Result = bactqc.adulterationqcdata(mactqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Adulteration Confirmation Tast QC Data Add  Successfully";
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

        protected void rpAdulterationConfirmationTestQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetAdulterationConfirmationTastQCDetails(Id);

                        if (txtSugar.Text == "")
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

        public void GetAdulterationConfirmationTastQCDetails()
        {
            bactqc = new BAdulterationConfirmationTastQC();
            DataSet DS = new DataSet();
            DS = bactqc.GetAdulterationConfirmationTastQCDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpAdulterationConfirmationTestQC.DataSource = DS;
                rpAdulterationConfirmationTestQC.DataBind();
            }
        }

        public void GetAdulterationConfirmationTastQCDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bactqc = new BAdulterationConfirmationTastQC();
            DS = bactqc.GetAdulterationConfirmationTastQCDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCDate"].ToString();
                //DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                //dpShiftDetails.ClearSelection();
                //if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCShiftId"]).ToString()) != null)
                //{
                //    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCShiftId"]).ToString()).Selected = true;
                //}
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCDate"].ToString();
                if (DATE == "")
                {
                    txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                dpShiftDetails.ClearSelection();
                string ShiftDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCShiftId"].ToString();
                if (ShiftDetails == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCShiftId"]).ToString()).Selected = true;
                }

                
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtSugar.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Sugar"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Sugar"].ToString();
                txtStarch.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Starch"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Starch"].ToString();
                txtHydrogenPeroxide.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HydrogenPeroxide"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HydrogenPeroxide"].ToString();
                txtNeutralizer.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Neutralizer"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Neutralizer"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                dpStatusDetails.ClearSelection();
                string StatusDetails = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCStatus"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCStatus"].ToString();
                if (StatusDetails=="")
                {
                    dpStatusDetails.SelectedIndex = 0;
                }
                else
                {
                    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["AdulterationConfirmationTestQCStatus"]).ToString()).Selected = true;
                }
            }
        }
    }
}