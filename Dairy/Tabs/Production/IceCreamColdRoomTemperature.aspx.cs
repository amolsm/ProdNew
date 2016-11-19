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
    public partial class IceCreamColdRoomTemperature : System.Web.UI.Page
    {
        MIceCreamColdRoomTemperature mict;
        BIceCreamColdRoomTemperature bict;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                BindDropDwonStatus();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetIceCreamColdRoomTemperatureDetails();
                txtBatchNo.ReadOnly = true;
                btnUpdate.Visible = false;

            }
        }

        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName As Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));
        }

        protected void BindDropDwonStatus()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as Name", "Prod_StatusDetails", "IsActive =1");
            dpStatusDetails.DataSource = DS;
            dpStatusDetails.DataBind();
            dpStatusDetails.Items.Insert(0, new ListItem("--Select Status--", "0"));
            dpStatusDetails.Items.FindByText("Rejected").Enabled = false;
        }

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mict = new MIceCreamColdRoomTemperature();
            bict = new BIceCreamColdRoomTemperature();
            int Result = 0;
            mict.IceCreamColdRoomTemperatureId = 0;
            mict.RMRId=string.IsNullOrEmpty(hId.Value)?0:Convert.ToInt32(hId.Value);
            mict.IceCreamColdRoomTemperatureDate=Convert.ToDateTime(txtDate.Text.ToString());
            mict.IceCreamColdRoomTemperatureShiftId=Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mict.HardeningRoom=string.IsNullOrEmpty(txtHardeningRoom.Text) ? string.Empty : txtHardeningRoom.Text;
            mict.AgingTank=string.IsNullOrEmpty(txtAgingTank.Text)?string.Empty:txtAgingTank.Text;
            mict.CandyTank=string.IsNullOrEmpty(txtCandyTank.Text)?string.Empty:txtCandyTank.Text;
            mict.ColdStorageRoom=string.IsNullOrEmpty(txtColdStorageRoom.Text)?string.Empty:txtColdStorageRoom.Text;
            mict.IBTTemperature=string.IsNullOrEmpty(txtIBTTemperature.Text)?0:Convert.ToDouble(txtIBTTemperature.Text);
            mict.CheckedBy=string.IsNullOrEmpty(txtCheckedBy.Text)?string.Empty:txtCheckedBy.Text;
            mict.verifierBy=string.IsNullOrEmpty(txtverifierBy.Text)?string.Empty:txtverifierBy.Text;
            mict.BreakAndDownServices=string.IsNullOrEmpty(txtBreakAndDownServices.Text)?string.Empty:txtBreakAndDownServices.Text;
            mict.flag = "Insert";
            Result=bict.icecreamdata(mict);
            if (Result>0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "IceCream ColdRoom Temperature Data Add  Successfully";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             mict = new MIceCreamColdRoomTemperature();
            bict = new BIceCreamColdRoomTemperature();
            int Result = 0;
            mict.IceCreamColdRoomTemperatureId = 0;
            mict.RMRId=string.IsNullOrEmpty(hId.Value)?0:Convert.ToInt32(hId.Value);
            mict.IceCreamColdRoomTemperatureDate=Convert.ToDateTime(txtDate.Text.ToString());
            mict.IceCreamColdRoomTemperatureShiftId=Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
            mict.HardeningRoom=string.IsNullOrEmpty(txtHardeningRoom.Text) ? string.Empty : txtHardeningRoom.Text;
            mict.AgingTank=string.IsNullOrEmpty(txtAgingTank.Text)?string.Empty:txtAgingTank.Text;
            mict.CandyTank=string.IsNullOrEmpty(txtCandyTank.Text)?string.Empty:txtCandyTank.Text;
            mict.ColdStorageRoom=string.IsNullOrEmpty(txtColdStorageRoom.Text)?string.Empty:txtColdStorageRoom.Text;
            mict.IBTTemperature=string.IsNullOrEmpty(txtIBTTemperature.Text)?0:Convert.ToDouble(txtIBTTemperature.Text);
            mict.CheckedBy=string.IsNullOrEmpty(txtCheckedBy.Text)?string.Empty:txtCheckedBy.Text;
            mict.verifierBy=string.IsNullOrEmpty(txtverifierBy.Text)?string.Empty:txtverifierBy.Text;
            mict.BreakAndDownServices=string.IsNullOrEmpty(txtBreakAndDownServices.Text)?string.Empty:txtBreakAndDownServices.Text;
            mict.flag="Update";
            Result=bict.icecreamdata(mict);
            if (Result>0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "IceCream ColdRoom Temperature Data Update  Successfully";
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

        protected void rpIceCreamColdRoomTemperature_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetIceCreamColdRoomTemperatureDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);

                        if (dpShiftDetails.SelectedIndex == 0 && txtHardeningRoom.Text == "")
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


        public void GetIceCreamColdRoomTemperatureDetails()
        {
            bict = new BIceCreamColdRoomTemperature();
            DataSet DS = new DataSet();
            DS = bict.GetIceCreamColdRoomTemperatureDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpIceCreamColdRoomTemperature.DataSource = DS;
                rpIceCreamColdRoomTemperature.DataBind();
            }
        }

        public void GetIceCreamColdRoomTemperatureDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bict = new BIceCreamColdRoomTemperature();
            DS = bict.GetIceCreamColdRoomTemperatureDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureDate"].ToString();
            //    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
            //    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
            //    dpShiftDetails.ClearSelection();
            //    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureShiftId"]).ToString()) != null)
            //    {
            //        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureShiftId"]).ToString()).Selected = true;
            //    }
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["IceCreamColdRoomTemperatureShiftId"]).ToString()).Selected = true;
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtHardeningRoom.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HardeningRoom"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HardeningRoom"].ToString();
                txtAgingTank.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["AgingTank"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["AgingTank"].ToString();
                txtCandyTank.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CandyTank"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CandyTank"].ToString();
                txtColdStorageRoom.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdStorageRoom"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdStorageRoom"].ToString();
                txtIBTTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["IBTTemperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["IBTTemperature"].ToString();
                txtCheckedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CheckedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CheckedBy"].ToString();
                txtverifierBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["verifierBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["verifierBy"].ToString();
                txtBreakAndDownServices.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BreakAndDownServices"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BreakAndDownServices"].ToString();
            }
        }
    }
}