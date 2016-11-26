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
    public partial class PersonalHygieneCheckList : System.Web.UI.Page
    {
        MPersonalHygieneCheckList mphcl;
        BPersonalHygieneCheckList bphcl;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetPersonalHygieneCheckListDetails();
                btnUpdate.Visible = false;
                bindDropDown();
                bindDropDownDesig();
            }
        }

        private void bindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "EmployeeName as Name", "employeemaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {


                dpEmployee.DataSource = DS;
                dpEmployee.DataBind();
                dpEmployee.Items.Insert(0, new ListItem("--Select Employee  --", "0"));



            }
        }

        private void bindDropDownDesig()
        {
            DS = BindCommanData.BindCommanDropDwon("EmployeeID", "Designation as Name", "employeemaster", "IsActive=1");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {


                dpDesignation.DataSource = DS;
                dpDesignation.DataBind();
                dpDesignation.Items.Insert(0, new ListItem("--Select Designation  --", "0"));



            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mphcl = new MPersonalHygieneCheckList();
            bphcl = new BPersonalHygieneCheckList();
            int Result = 0;
            mphcl.PersonalHygieneCheckListId = 0;
            mphcl.PersonalHygieneCheckListDate = Convert.ToDateTime(txtDate.Text.ToString());
            mphcl.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            mphcl.DesignationId = Convert.ToInt32(dpDesignation.SelectedItem.Value);
            if (chkUniform.Checked)
                mphcl.UniformCleaning = true;
            else
                mphcl.UniformCleaning=false;

            if(chkBeardCrimp.Checked)
                mphcl.BeardCrimp = true;
            else
                mphcl.BeardCrimp = false;

            if (chkNail.Checked)
                mphcl.Nail = true;
            else
                mphcl.Nail = false;

            if (chkCap.Checked)
            {
                mphcl.Cap = true;
            }
            else
            {
                mphcl.Cap = false;
            }

            if (chkApronLab.Checked)
                mphcl.ApronLab = true;
            else
                mphcl.ApronLab = false;

            if (chkHandGloves.Checked)
                mphcl.HandGloves = true;
            else
                mphcl.HandGloves = false;

            if (chkMask.Checked)
                mphcl.Mask = true;
            else
                mphcl.Mask = false;

            mphcl.flag = "insert";
            Result = bphcl.personalhygienedata(mphcl);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Personal Hygiene CheckList Data Added  Successfully";
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
            mphcl = new MPersonalHygieneCheckList();
            bphcl = new BPersonalHygieneCheckList();
            int Result = 0;
            mphcl.PersonalHygieneCheckListId =string.IsNullOrEmpty(hId.Value)?0:Convert.ToInt32(hId.Value);
            mphcl.PersonalHygieneCheckListDate = Convert.ToDateTime(txtDate.Text.ToString());
            mphcl.EmployeeId = Convert.ToInt32(dpEmployee.SelectedItem.Value);
            mphcl.DesignationId = Convert.ToInt32(dpDesignation.SelectedItem.Value);
            if (chkUniform.Checked)
                mphcl.UniformCleaning = true;
            else
                mphcl.UniformCleaning = false;

            if (chkBeardCrimp.Checked)
                mphcl.BeardCrimp = true;
            else
                mphcl.BeardCrimp = false;

            if (chkNail.Checked)
                mphcl.Nail = true;
            else
                mphcl.Nail = false;

            if (chkCap.Checked)
            {
                mphcl.Cap = true;
            }
            else
            {
                mphcl.Cap = false;
            }

            if (chkApronLab.Checked)
                mphcl.ApronLab = true;
            else
                mphcl.ApronLab = false;

            if (chkHandGloves.Checked)
                mphcl.HandGloves = true;
            else
                mphcl.HandGloves = false;

            if (chkMask.Checked)
                mphcl.Mask = true;
            else
                mphcl.Mask = false;

            mphcl.flag = "Update";
            Result = bphcl.personalhygienedata(mphcl);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Personal Hygiene CheckList Data Updated  Successfully";
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

        protected void rpPersonalHygieneCheckList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Personal Hygiene CheckList Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetPersonalHygieneCheckListDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetPersonalHygieneCheckListDetails()
        {
            bphcl = new BPersonalHygieneCheckList();
            DataSet DS = new DataSet();
            DS = bphcl.GetPersonalHygieneCheckListDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpPersonalHygieneCheckList.DataSource = DS;
                rpPersonalHygieneCheckList.DataBind();
            }
        }

        public void GetPersonalHygieneCheckListDetails(int PersonalHygieneCheckListId)
        {
            DataSet DS = new DataSet();
            bphcl = new BPersonalHygieneCheckList();
            DS = bphcl.GetPersonalHygieneCheckListDetailsById(PersonalHygieneCheckListId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PersonalHygieneCheckListDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PersonalHygieneCheckListDate"].ToString();
                //DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));

                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PersonalHygieneCheckListDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PersonalHygieneCheckListDate"].ToString();
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