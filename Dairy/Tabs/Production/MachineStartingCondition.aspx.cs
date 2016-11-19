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
    public partial class MachineStartingCondition : System.Web.UI.Page
    {
        MMachineStartingCondition mmachine;
        BMachineStartingCondition bmachine;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMachineStartingConditionDetails();
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
            dpStatusDetails.Items.FindByText("Accepted").Enabled = false;
            dpStatusDetails.Items.FindByText("Rejected").Enabled = false;
            dpStatusDetails.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mmachine = new MMachineStartingCondition();
            bmachine = new BMachineStartingCondition();
            int Result = 0;
            mmachine.MachineStartingConditionId = 0;
            mmachine.MachineStartingConditiondDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmachine.MachineStartingConditionShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmachine.MachineName = txtMachineName.Text;
            mmachine.Pasteurizer1 = string.IsNullOrEmpty(txtPasteurizer1.Text) ? 0 : Convert.ToInt32(txtPasteurizer1.Text);
            mmachine.Pasteurizer2 = string.IsNullOrEmpty(txtPasteurizer2.Text) ? 0 : Convert.ToInt32(txtPasteurizer2.Text);
            mmachine.Homogenizer1 = string.IsNullOrEmpty(txtHomogenizer1.Text) ? 0 : Convert.ToInt32(txtHomogenizer1.Text);
            mmachine.Homogenizer2 = string.IsNullOrEmpty(txtHomogenizer2.Text) ? 0 : Convert.ToInt32(txtHomogenizer2.Text);
            mmachine.SeparatorPump = txtSeparatorPump.Text;
            mmachine.BDTill = txtBDTill.Text;
            mmachine.Service = txtService.Text;
            mmachine.Pending = txtPending.Text;
            mmachine.Report = txtReport.Text;
            mmachine.MachineConditionStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
            mmachine.flag = "Insert";
            Result = bmachine.machinedata(mmachine);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Machine Starting Condition Data Add  Successfully";
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            mmachine = new MMachineStartingCondition();
            bmachine = new BMachineStartingCondition();
            int Result = 0;
            mmachine.MachineStartingConditionId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mmachine.MachineStartingConditiondDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmachine.MachineStartingConditionShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmachine.MachineName = txtMachineName.Text;
            mmachine.Pasteurizer1 = string.IsNullOrEmpty(txtPasteurizer1.Text) ? 0 : Convert.ToInt32(txtPasteurizer1.Text);
            mmachine.Pasteurizer2 = string.IsNullOrEmpty(txtPasteurizer2.Text) ? 0 : Convert.ToInt32(txtPasteurizer2.Text);
            mmachine.Homogenizer1 = string.IsNullOrEmpty(txtHomogenizer1.Text) ? 0 : Convert.ToInt32(txtHomogenizer1.Text);
            mmachine.Homogenizer2 = string.IsNullOrEmpty(txtHomogenizer2.Text) ? 0 : Convert.ToInt32(txtHomogenizer2.Text);
            mmachine.SeparatorPump = txtSeparatorPump.Text;
            mmachine.BDTill = txtBDTill.Text;
            mmachine.Report = txtReport.Text;
            mmachine.Service = txtService.Text;
            mmachine.Pending = txtPending.Text;
            mmachine.MachineConditionStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
            mmachine.flag = "Update";
            Result = bmachine.machinedata(mmachine);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Machine Starting Condition Data Add  Successfully";
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

        protected void RpMachineStartingCondition_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetMachineStartingConditionDetails(Id);


                        btnAdd.Visible = false;
                        btnUpdate.Visible = true;
                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMachineStartingConditionDetails()
        {
            bmachine = new BMachineStartingCondition();
            DataSet DS = new DataSet();
            DS = bmachine.GetMachineStartingConditionDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                RpMachineStartingCondition.DataSource = DS;
                RpMachineStartingCondition.DataBind();
            }
        }

         public void GetMachineStartingConditionDetails(int MachineStartingConditionId)
        {
            DataSet DS = new DataSet();
            bmachine = new BMachineStartingCondition();
            DS = bmachine.GetMachineStartingConditionDetailsById(MachineStartingConditionId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineStartingConditiondDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineStartingConditiondDate"].ToString();
            //    //sky
            //    if (DATE == "")
            //    {
            //        txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
            //    }
            //    else
            //    {
            //        DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
            //        txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
            //    }
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineStartingConditionShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineStartingConditionShiftId"]).ToString()).Selected = true;
                }
                txtMachineName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineName"].ToString();
                txtPasteurizer1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Pasteurizer1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Pasteurizer1"].ToString();
                txtPasteurizer2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Pasteurizer2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Pasteurizer2"].ToString();
                txtHomogenizer1.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Homogenizer1"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Homogenizer1"].ToString();
                txtHomogenizer2.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Homogenizer2"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Homogenizer2"].ToString();
                txtSeparatorPump.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SeparatorPump"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SeparatorPump"].ToString();
                txtBDTill.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BDTill"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BDTill"].ToString();
                txtReport.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Report"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Report"].ToString();
                txtService.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Service"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Service"].ToString();
                txtPending.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Pending"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Pending"].ToString();
                dpStatusDetails.ClearSelection();
                if (dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineConditionStatus"]).ToString()) != null)
                {
                    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineConditionStatus"]).ToString()).Selected = true;
                }
            }

        }
    }
