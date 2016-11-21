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
    public partial class MachineAirCompressors : System.Web.UI.Page
    {
        MMachineAirCompressors mmac;
        BMachineAirCompressors bmac;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMachineAirCompressorsDetails();
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
            mmac = new MMachineAirCompressors();
            bmac = new BMachineAirCompressors();
            int Result = 0;
            mmac.MachineAirCompressorsId = 0;
            mmac.MachineAirCompressorsDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmac.MachineAirCompressorsShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmac.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mmac.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mmac.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
            mmac.flag = "insert";
            Result = bmac.machineairdata(mmac);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Machine Air Compressors Data Added  Successfully";
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
            mmac = new MMachineAirCompressors();
            bmac = new BMachineAirCompressors();
            int Result = 0;
            mmac.MachineAirCompressorsId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mmac.MachineAirCompressorsDate = Convert.ToDateTime(txtDate.Text.ToString());
            mmac.MachineAirCompressorsShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mmac.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mmac.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mmac.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
            mmac.flag = "Update";
            Result = bmac.machineairdata(mmac);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Machine Air Compressors Data Updated  Successfully";
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

        protected void rpMachineAirCompressors_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetMachineAirCompressorsDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMachineAirCompressorsDetails()
        {
            bmac = new BMachineAirCompressors();
            DataSet DS = new DataSet();
            DS = bmac.GetMachineAirCompressorsDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMachineAirCompressors.DataSource = DS;
                rpMachineAirCompressors.DataBind();
            }
        }

        public void GetMachineAirCompressorsDetails(int MachineAirCompressorsId)
        {
            DataSet DS = new DataSet();
            bmac = new BMachineAirCompressors();
            DS = bmac.GetMachineAirCompressorsDetailsById(MachineAirCompressorsId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineAirCompressorsDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineAirCompressorsDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineAirCompressorsShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineAirCompressorsShiftId"]).ToString()).Selected = true;
                }
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartingTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalHours"].ToString();
            }
        }
    }
}