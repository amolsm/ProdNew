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
    public partial class PersonalHygieneCheckListQC : System.Web.UI.Page
    {
        MPersonalHygieneCheckListQC mphcqc;
        BPersonalHygieneCheckListQC bphcqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetPersonalHygieneCheckListQCDetails();
                btnUpdate.Visible = false;
                bindDropDownEmp();
                bindDropDownDesig();
            }
        }

        private void bindDropDownEmp()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+EmployeeName as Name", "employeemaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {


                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee  --", "0"));

            }
        }

        private void bindDropDownDesig()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeCode+' '+Designation as Name", "employeemaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {


                dpDesignation.DataSource = DS;
                dpDesignation.DataBind();
                dpDesignation.Items.Insert(0, new ListItem("--Select Designation  --", "0"));

            }
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            mphcqc = new MPersonalHygieneCheckListQC();
            bphcqc = new BPersonalHygieneCheckListQC();
            int Result = 0;
            mphcqc.PersonalHygieneCheckListQCId = 0;
            mphcqc.PersonalHygieneCheckListQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mphcqc.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            mphcqc.DesignationId = Convert.ToInt32(dpDesignation.SelectedItem.Value);
            if (chkUniform.Checked)
            {
                mphcqc.UniformCleaning = true;
            }
            else
            {

                mphcqc.UniformCleaning = false;
            }

            if (chkNail.Checked)
            {
                mphcqc.Nail = true;
            }
            else
            {
                mphcqc.Nail = false;
            }

            if (chkCap.Checked)
            {
                mphcqc.Cap = true;
            }
            else
            {
                mphcqc.Cap = false;
            }

            if (chkApronLab.Checked)
            {
                mphcqc.ApronLab = true;
            }
            else
            {
                mphcqc.ApronLab = false;
            }

            if (chkBeardCrimp.Checked)
            {
                mphcqc.BeardCrimp = true;
            }
            else
            {

                mphcqc.BeardCrimp = false;
            }

            if (chkHandGloves.Checked)
            {
                mphcqc.HandGloves = true;
            }
            else
            {
                mphcqc.HandGloves = false;
            }

            if (chkMask.Checked)
            {
                mphcqc.Mask = true;
            }
            else
            {
                mphcqc.Mask = false;
            }

            mphcqc.flag="Insert";
            Result = bphcqc.personalhygieneqcdata(mphcqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Personal Hygiene CheckListQC Data Added  Successfully";
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


        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            mphcqc = new MPersonalHygieneCheckListQC();
            bphcqc = new BPersonalHygieneCheckListQC();
            int Result = 0;
            mphcqc.PersonalHygieneCheckListQCId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mphcqc.PersonalHygieneCheckListQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mphcqc.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            mphcqc.DesignationId = Convert.ToInt32(dpDesignation.SelectedItem.Value);
            if (chkUniform.Checked)
            {
                mphcqc.UniformCleaning = true;
            }
            else
            {

                mphcqc.UniformCleaning = false;
            }

            if (chkNail.Checked)
            {
                mphcqc.Nail = true;
            }
            else
            {
                mphcqc.Nail = false;
            }

            if (chkCap.Checked)
            {
                mphcqc.Cap = true;
            }
            else
            {
                mphcqc.Cap = false;
            }

            if (chkApronLab.Checked)
            {
                mphcqc.ApronLab = true;
            }
            else
            {
                mphcqc.ApronLab = false;
            }

            if (chkBeardCrimp.Checked)
            {
                mphcqc.BeardCrimp = true;
            }
            else
            {

                mphcqc.BeardCrimp = false;
            }

            if (chkHandGloves.Checked)
            {
                mphcqc.HandGloves = true;
            }
            else
            {
                mphcqc.HandGloves = false;
            }

            if (chkMask.Checked)
            {
                mphcqc.Mask = true;
            }
            else
            {
                mphcqc.Mask = false;
            }

            mphcqc.flag = "Update";
            Result = bphcqc.personalhygieneqcdata(mphcqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Personal Hygiene CheckListQC Data Updated  Successfully";
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

        protected void btnRefresh_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpPersonalHygieneCheckListQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Personal Hygiene CheckList QC Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetPersonalHygieneCheckListQCDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetPersonalHygieneCheckListQCDetails()
        {
            bphcqc = new BPersonalHygieneCheckListQC();
            DataSet DS = new DataSet();
            DS = bphcqc.GetPersonalHygieneCheckListQCDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpPersonalHygieneCheckListQC.DataSource = DS;
                rpPersonalHygieneCheckListQC.DataBind();
            }
        }


        public void GetPersonalHygieneCheckListQCDetails(int PersonalHygieneCheckListQCId)
        {
            DataSet DS = new DataSet();
            bphcqc = new BPersonalHygieneCheckListQC();
            DS = bphcqc.GetPersonalHygieneCheckListQCDetailsById(PersonalHygieneCheckListQCId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PersonalHygieneCheckListQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PersonalHygieneCheckListQCDate"].ToString();
                if (DATE == "")
                {
                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                dpEmployee.ClearSelection();
                if (dpEmployee.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["EmployeeId"]).ToString()) != null)
                {
                    dpEmployee.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["EmployeeId"]).ToString()).Selected = true;
                }

                dpDesignation.ClearSelection();
                if (dpDesignation.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DesignationId"]).ToString()) != null)
                {
                    dpDesignation.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["DesignationId"]).ToString()).Selected = true;
                }

                txtUniformCleaning.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["UniformCleaning"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["UniformCleaning"].ToString();
                txtNail.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Nail"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Nail"].ToString();
                txtCap.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cap"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cap"].ToString();
                txtApronLab.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApronLab"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApronLab"].ToString();
                txtBeardCrimp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BeardCrimp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BeardCrimp"].ToString();
                txtHandGloves.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HandGloves"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HandGloves"].ToString();
                txtMask.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Mask"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Mask"].ToString();
            }
        }
    }
}