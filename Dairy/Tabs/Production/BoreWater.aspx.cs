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
    public partial class BoreWater : System.Web.UI.Page
    {
        MBoreWater mbw;
        BBoreWater bbw;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetBoreWaterDetails();
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
            mbw = new MBoreWater();
            bbw = new BBoreWater();
            int Result = 0;
            mbw.BoreWaterId = 0;
            mbw.BoreWaterDate = Convert.ToDateTime(txtDate.Text.ToString());
            mbw.BoreWaterShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mbw.OperatedBy=string.IsNullOrEmpty(txtOperatedBy.Text)?string.Empty :txtOperatedBy.Text;
            mbw.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mbw.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mbw.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
            mbw.flag="insert";
            Result = bbw.borewaterdata(mbw);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Bore Water Data Added  Successfully";
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
            mbw = new MBoreWater();
            bbw = new BBoreWater();
            int Result = 0;
            mbw.BoreWaterId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mbw.BoreWaterDate = Convert.ToDateTime(txtDate.Text.ToString());
            mbw.BoreWaterShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mbw.OperatedBy = string.IsNullOrEmpty(txtOperatedBy.Text) ? string.Empty : txtOperatedBy.Text;
            mbw.StartingTime = string.IsNullOrEmpty(txtStartingTime.Text) ? string.Empty : txtStartingTime.Text;
            mbw.EndTime = string.IsNullOrEmpty(txtEndTime.Text) ? string.Empty : txtEndTime.Text;
            mbw.TotalHours = string.IsNullOrEmpty(txtTotalHours.Text) ? string.Empty : txtTotalHours.Text;
            mbw.flag = "Update";
            Result = bbw.borewaterdata(mbw);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Bore Water Data Updated  Successfully";
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

        protected void rpborewater_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetBoreWaterDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetBoreWaterDetails()
        {
            bbw = new BBoreWater();
            DataSet DS = new DataSet();
            DS = bbw.GetBoreWaterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS)) 
            {
                rpborewater.DataSource = DS;
                rpborewater.DataBind();
            }
        }

        public void GetBoreWaterDetails(int BoreWaterId)
        {
            DataSet DS = new DataSet();
            bbw = new BBoreWater();
            DS=bbw.GetBoreWaterDetailsById(BoreWaterId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BoreWaterDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BoreWaterDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                dpShiftDetails.ClearSelection();
                if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["BoreWaterShiftId"]).ToString()) != null)
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["BoreWaterShiftId"]).ToString()).Selected = true;
                }
                txtOperatedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OperatedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OperatedBy"].ToString();
                txtStartingTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["StartingTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["StartingTime"].ToString();
                txtEndTime.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["EndTime"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["EndTime"].ToString();
                txtTotalHours.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalHours"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalHours"].ToString();
            }
        }
    }
}