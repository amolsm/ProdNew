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
    public partial class CreamProduction : System.Web.UI.Page
    {
        MCreamProduction mcream;
        BCreamProduction bcream;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSearchDate.Text= Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                //GetCreamDetails();
                txtBatchNo.ReadOnly = true;
                
            }
        }
        protected void BindDropDwon()
        {
            DS = new DataSet();
            DS = BindCommanData.BindCommanDropDwon("ShiftId", "ShiftName as Name", "ShiftDetails", "IsActive =1");
            dpShiftDetails.DataSource = DS;
            dpShiftDetails.DataBind();
            dpShiftDetails.Items.Insert(0, new ListItem("--Select Shift--", "0"));

            DS = BindCommanData.BindCommanDropDwon("StatusId", "StatusName as StatusName", "Prod_StatusDetails", "IsActive =1");
            dpCreamProductionDone.DataSource = DS;
            dpCreamProductionDone.DataBind();
            dpCreamProductionDone.Items.FindByText("Release").Enabled = false;
            dpCreamProductionDone.Items.FindByText("Hold").Enabled = false;
            dpCreamProductionDone.Items.FindByText("Yes").Enabled = false;
            dpCreamProductionDone.Items.FindByText("No").Enabled = false;
            dpCreamProductionDone.Items.Insert(0, new ListItem("--Status--", "0"));
        }

        

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mcream = new MCreamProduction();
                bcream = new BCreamProduction();
                int Result = 0;
                mcream.CreamProductionId = 0;
                mcream.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mcream.CreamProductionDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
                mcream.CreamProductionShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mcream.BatchCodeCream = string.IsNullOrEmpty(txtBatchCodeCream.Text) ? string.Empty : txtBatchCodeCream.Text;
                mcream.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mcream.CreamQty = string.IsNullOrEmpty(txtCreamQty.Text) ? 0 : Convert.ToDouble(txtCreamQty.Text);
                mcream.CreamStatusId = Convert.ToInt32(dpCreamProductionDone.SelectedItem.Value);
                mcream.flag = "Insert";
                Result = bcream.creamdata(mcream);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "PasteurizationProcess Data Add  Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    string dates;
                    dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    GetCreamDetails(dates);
                    uprouteList.Update();

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

                mcream = new MCreamProduction();
                bcream = new BCreamProduction();
                int Result = 0;
                mcream.CreamProductionId = 0;
                mcream.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mcream.CreamProductionDate = Convert.ToDateTime(txtDate.Text).ToString("dd-MM-yyyy");
                mcream.CreamProductionShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mcream.BatchCodeCream = string.IsNullOrEmpty(txtBatchCodeCream.Text) ? string.Empty : txtBatchCodeCream.Text;
                mcream.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mcream.CreamQty = string.IsNullOrEmpty(txtCreamQty.Text) ? 0 : Convert.ToDouble(txtCreamQty.Text);
                mcream.CreamStatusId = Convert.ToInt32(dpCreamProductionDone.SelectedItem.Value);
                mcream.flag = "Update";
                Result = bcream.creamdata(mcream);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "PasteurizationProcess Data Add  Successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').addClass('collapsed-box');", true);
                    pnlError.Update();
                    string dates;
                    dates = string.IsNullOrEmpty(txtSearchDate.Text) ? string.Empty : Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
                    GetCreamDetails(dates);
                    uprouteList.Update();
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

      
        protected void rpCreamProduction_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Cream Production Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        ClearAll();
                        GetCreamDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);
                        if (txtBatchCodeCream.Text==string.Empty && txtCreamQty.Text==string.Empty)
                        {
                            btnAdd.Visible = true;
                            btnUpdate.Visible = false;
                            btnRefresh.Visible = true;
                            dpCreamProductionDone.SelectedIndex = 2;
                        }
                        else
                        {
                            btnUpdate.Visible = true;
                            btnAdd.Visible = false;
                            btnRefresh.Visible = true;
                            dpCreamProductionDone.SelectedIndex = 1;
                        }
                        // btnAdd.Visible = true;
                        btnRefresh.Visible = true;
                        //btnUpdateProductindetail.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetCreamDetails(string dates)
        { 
          bcream =new BCreamProduction();
          DataSet DS=new DataSet();
          DS=bcream.GetCreamDetails(dates);
            if(!Comman.Comman.IsDataSetEmpty(DS))
            {
               rpCreamProduction.DataSource=DS;
               rpCreamProduction.DataBind(); 
            }
            else
            {
                DS.Clear();
                rpCreamProduction.DataSource = DS;
                rpCreamProduction.DataBind();
            }
        }

        public void GetCreamDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bcream = new BCreamProduction();
            DS = bcream.GetCreamDetailsbyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamProductionDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamProductionDate"].ToString();
                //sky
                if (DATE == "")
                {
                    txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                   
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                dpShiftDetails.ClearSelection();
                try
                {
                    if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CreamProductionShiftId"]).ToString()) != null)
                    {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CreamProductionShiftId"]).ToString()).Selected = true;
                    }
                   
                }
                catch(InvalidCastException)
                {
                        dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["PastQCShiftId"]).ToString()).Selected = true;
               
                    //dpShiftDetails.SelectedIndex = 0;
                }
                txtBatchCodeCream.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchCodeCream"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchCodeCream"].ToString();
                txtCreamQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CreamQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CreamQty"].ToString();
                txtFAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FAT"].ToString();
                
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        public void ClearAll()
        {
            txtBatchNo.Text = string.Empty;
            txtDate.Text = Convert.ToString(DateTime.Now.ToString("MM-dd-yyyy"));
            dpShiftDetails.ClearSelection();
            txtBatchCodeCream.Text = string.Empty;
            txtCreamQty.Text = string.Empty;
            txtFAT.Text = string.Empty;
            dpCreamProductionDone.ClearSelection();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string dates = Convert.ToDateTime(txtSearchDate.Text).ToString("dd-MM-yyyy");
            GetCreamDetails(dates);
        }
    }
}