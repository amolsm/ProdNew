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
    public partial class CurdPacketData : System.Web.UI.Page
    {
        MCurdPackedData mcurd;
        BCurdPackedData bcurd;
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetCurdPackedDetails();
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
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mcurd = new MCurdPackedData();
                bcurd = new BCurdPackedData();
                int Result = 0;
                mcurd.CurdPackedDataId = 0;
                mcurd.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mcurd.CurdPackedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mcurd.CurdShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mcurd.PackingOperatorName = txtPackingOperatorName.Text;
                mcurd.ReceivedBy = txtReceivedBy.Text;
                mcurd.CurdCupQty = string.IsNullOrEmpty(txtCurdCupQty.Text) ? 0 : Convert.ToDouble(txtCurdCupQty.Text);
                mcurd.Curd500MLQty = string.IsNullOrEmpty(txtCurd500mlQty.Text) ? 0 : Convert.ToDouble(txtCurd500mlQty.Text);
                mcurd.Curd450MLQty = string.IsNullOrEmpty(txt450mlQty.Text) ? 0 : Convert.ToDouble(txt450mlQty.Text);
                mcurd.ButterMilk200ML = string.IsNullOrEmpty(txtButterMilk200ml.Text) ? 0 : Convert.ToDouble(txtButterMilk200ml.Text);
                mcurd.TotalQtyOfCurd = string.IsNullOrEmpty(txtTotalOfCurd.Text) ? 0 : Convert.ToDouble(txtTotalOfCurd.Text);
                mcurd.ColdRoomNo = txtColdRoomNo.Text;
                mcurd.flag = "Insert";
                Result = bcurd.curddata(mcurd);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Curd Packed Data Add  Successfully";
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mcurd = new MCurdPackedData();
                bcurd = new BCurdPackedData();
                int Result = 0;
                mcurd.CurdPackedDataId = 0;
                mcurd.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mcurd.CurdPackedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mcurd.CurdShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mcurd.PackingOperatorName = txtPackingOperatorName.Text;
                mcurd.ReceivedBy = txtReceivedBy.Text;
                mcurd.CurdCupQty = string.IsNullOrEmpty(txtCurdCupQty.Text) ? 0 : Convert.ToDouble(txtCurdCupQty.Text);
                mcurd.Curd500MLQty = string.IsNullOrEmpty(txtCurd500mlQty.Text) ? 0 : Convert.ToDouble(txtCurd500mlQty.Text);
                mcurd.Curd450MLQty = string.IsNullOrEmpty(txt450mlQty.Text) ? 0 : Convert.ToDouble(txt450mlQty.Text);
                mcurd.ButterMilk200ML = string.IsNullOrEmpty(txtButterMilk200ml.Text) ? 0 : Convert.ToDouble(txtButterMilk200ml.Text);
                mcurd.TotalQtyOfCurd = string.IsNullOrEmpty(txtTotalOfCurd.Text) ? 0 : Convert.ToDouble(txtTotalOfCurd.Text);
                mcurd.ColdRoomNo = txtColdRoomNo.Text;
                mcurd.flag = "Update";
                Result = bcurd.curddata(mcurd);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;
                    divSusccess.Visible = true;
                    lblSuccess.Text = "Curd Packed Data Update  Successfully";
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
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void rpCurdPackedDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit PackedData Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetCurdPackedDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);


                        if (dpShiftDetails.SelectedIndex == 0 && txtPackingOperatorName.Text == "")
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

        public void GetCurdPackedDetails()
        {
            bcurd = new BCurdPackedData();
            DataSet DS = new DataSet();
            DS = bcurd.GetCurdPackedDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpCurdPackedDataList.DataSource = DS;
                rpCurdPackedDataList.DataBind();
            }
        }

        public void GetCurdPackedDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bcurd = new BCurdPackedData();
            DS = bcurd.GetCurdPackedDetailsbyId(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdPackedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdPackedDate"].ToString();
                ////sky
                //DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                //dpShiftDetails.ClearSelection();
                //if (dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdShiftId"]).ToString()) != null)
                //{
                //    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdShiftId"]).ToString()).Selected = true;
                //}

                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdPackedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdPackedDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["CurdShiftId"]).ToString()).Selected = true;
                }
                txtPackingOperatorName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingOperatorName"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingOperatorName"].ToString();
                txtReceivedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceivedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceivedBy"].ToString();
                txtCurdCupQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdCupQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdCupQty"].ToString();
                txtCurd500mlQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Curd500MLQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Curd500MLQty"].ToString();
                txt450mlQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Curd450MLQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Curd450MLQty"].ToString();
                txtButterMilk200ml.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ButterMilk200ML"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ButterMilk200ML"].ToString();
                txtTotalOfCurd.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalQtyOfCurd"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalQtyOfCurd"].ToString();
                txtColdRoomNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ColdRoomNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ColdRoomNo"].ToString();

            }
        }
    }
}