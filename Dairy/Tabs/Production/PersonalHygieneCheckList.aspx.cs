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
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mphcl = new MPersonalHygieneCheckList();
            bphcl = new BPersonalHygieneCheckList();
            int Result = 0;
            mphcl.PersonalHygieneCheckListId = 0;
            mphcl.PersonalHygieneCheckListDate = Convert.ToDateTime(txtDate.Text.ToString());
            mphcl.EmployeeName = string.IsNullOrEmpty(txtEmployeeName.Text) ? string.Empty : txtEmployeeName.Text;
            mphcl.DesignationOfEmp = string.IsNullOrEmpty(txtDesignationOfEmp.Text) ? string.Empty : txtDesignationOfEmp.Text;
            mphcl.UniformCleaning = string.IsNullOrEmpty(txtUniformCleaning.Text) ? string.Empty : txtUniformCleaning.Text;
            mphcl.Nail = string.IsNullOrEmpty(txtNail.Text) ? string.Empty : txtNail.Text;
            mphcl.Cap = string.IsNullOrEmpty(txtCap.Text) ? string.Empty : txtCap.Text;
            mphcl.ApronLab = string.IsNullOrEmpty(txtApronLab.Text) ? string.Empty : txtApronLab.Text;
            mphcl.BeardCrimp = string.IsNullOrEmpty(txtBeardCrimp.Text) ? string.Empty : txtBeardCrimp.Text;
            mphcl.HandGloves = string.IsNullOrEmpty(txtHandGloves.Text) ? string.Empty : txtHandGloves.Text;
            mphcl.Mask = string.IsNullOrEmpty(txtMask.Text) ? string.Empty : txtMask.Text;
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
            mphcl.EmployeeName = string.IsNullOrEmpty(txtEmployeeName.Text) ? string.Empty : txtEmployeeName.Text;
            mphcl.DesignationOfEmp = string.IsNullOrEmpty(txtDesignationOfEmp.Text) ? string.Empty : txtDesignationOfEmp.Text;
            mphcl.UniformCleaning = string.IsNullOrEmpty(txtUniformCleaning.Text) ? string.Empty : txtUniformCleaning.Text;
            mphcl.Nail = string.IsNullOrEmpty(txtNail.Text) ? string.Empty : txtNail.Text;
            mphcl.Cap = string.IsNullOrEmpty(txtCap.Text) ? string.Empty : txtCap.Text;
            mphcl.ApronLab = string.IsNullOrEmpty(txtApronLab.Text) ? string.Empty : txtApronLab.Text;
            mphcl.BeardCrimp = string.IsNullOrEmpty(txtBeardCrimp.Text) ? string.Empty : txtBeardCrimp.Text;
            mphcl.HandGloves = string.IsNullOrEmpty(txtHandGloves.Text) ? string.Empty : txtHandGloves.Text;
            mphcl.Mask = string.IsNullOrEmpty(txtMask.Text) ? string.Empty : txtMask.Text;
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
                        lblHeaderTab.Text = "Edit Bore Water Details";
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
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PersonalHygieneCheckListDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PersonalHygieneCheckListDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                txtEmployeeName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EmployeeName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EmployeeName"].ToString();
                txtDesignationOfEmp.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DesignationOfEmp"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DesignationOfEmp"].ToString();
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