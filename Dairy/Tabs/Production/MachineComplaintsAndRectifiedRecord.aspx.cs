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
    public partial class MachineConditionRecord : System.Web.UI.Page
    {
        MMachineComplaintsAndRectifiedRecord mmcr;
        BMachineComplaintsAndRectifiedRecord bmcr;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtComplaintsDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtRectifiedDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMachineComplaintsAndRectifiedDetails();
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
            dpStatusDetails.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mmcr = new MMachineComplaintsAndRectifiedRecord();
                bmcr = new BMachineComplaintsAndRectifiedRecord();
                int Result = 0;
                mmcr.MachineComplaintsAndRectifiedRecordId = 0;
                mmcr.MachineComplaintsAndRectifiedRecordDate = Convert.ToDateTime(txtComplaintsDate.Text.ToString());
                mmcr.MachineComplaintsAndRectifiedRecordShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmcr.MachineName = txtMachineName.Text;
                mmcr.IdentifiedBy = txtIdentifiedBy.Text;
                mmcr.RectifiedBy = txtRectifiedBy.Text;
                mmcr.RectifiedDate = Convert.ToDateTime(txtRectifiedDate.Text.ToString());
                mmcr.MachineRectifiedStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mmcr.flag = "Insert";
                Result = bmcr.machinereportdata(mmcr);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Machine Complaints And Rectified  Data Add  Successfully";
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mmcr = new MMachineComplaintsAndRectifiedRecord();
                bmcr = new BMachineComplaintsAndRectifiedRecord();
                int Result = 0;
                mmcr.MachineComplaintsAndRectifiedRecordId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mmcr.MachineComplaintsAndRectifiedRecordDate = Convert.ToDateTime(txtComplaintsDate.Text.ToString());
                mmcr.MachineComplaintsAndRectifiedRecordShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmcr.MachineName = txtMachineName.Text;
                mmcr.IdentifiedBy = txtIdentifiedBy.Text;
                mmcr.RectifiedBy = txtRectifiedBy.Text;
                mmcr.RectifiedDate = Convert.ToDateTime(txtRectifiedDate.Text.ToString());
                mmcr.MachineRectifiedStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mmcr.flag = "Update";
                Result = bmcr.machinereportdata(mmcr);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Machine Complaints And Rectified  Data Update  Successfully";
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

        protected void rpMachineComplaintsReport_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetMachineComplaintsAndRectifiedDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMachineComplaintsAndRectifiedDetails()
        {
            bmcr = new BMachineComplaintsAndRectifiedRecord();
            DataSet DS = new DataSet();
            DS = bmcr.GetMachineComplaintsAndRectifiedDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMachineComplaintsReport.DataSource = DS;
                rpMachineComplaintsReport.DataBind();
            }
        }

        public void GetMachineComplaintsAndRectifiedDetails(int MachineComplaintsAndRectifiedRecordId)
        {
            DataSet DS = new DataSet();
            bmcr = new BMachineComplaintsAndRectifiedRecord();
            DS = bmcr.GetMachineComplaintsAndRectifiedDetailsById(MachineComplaintsAndRectifiedRecordId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineComplaintsAndRectifiedRecordDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineComplaintsAndRectifiedRecordDate"].ToString();
                if (DATE == "")
                {
                    txtComplaintsDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtComplaintsDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineComplaintsAndRectifiedRecordShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineComplaintsAndRectifiedRecordShiftId"]).ToString()).Selected = true;
                }
                txtMachineName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MachineName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MachineName"].ToString();
                txtIdentifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IdentifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IdentifiedBy"].ToString();
                txtRectifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RectifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RectifiedBy"].ToString();
                string DATE2 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RectifiedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RectifiedDate"].ToString();
                if (DATE2 == "")
                {
                    txtRectifiedDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtRectifiedDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                dpStatusDetails.ClearSelection();
                if (dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineRectifiedStatus"]).ToString()) != null)
                {
                    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MachineRectifiedStatus"]).ToString()).Selected = true;
                }

            }
        }
    }
}