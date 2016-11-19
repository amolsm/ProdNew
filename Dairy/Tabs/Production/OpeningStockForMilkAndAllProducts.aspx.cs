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
    public partial class OpeningStockForMilkAndAllProducts : System.Web.UI.Page
    {
        MOpeningStockForMilkAndAllProducts mosfmaap;
        BOpeningStockForMilkAndAllProducts bosfmaap;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetOpeningStockForMilkAndAllProductsDetails();
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

            DS = BindCommanData.BindCommanDropDwon("MachineConditionStatusId", "Status as Name", "Prod_MachineConditionStatus", "IsActive =1");
            dpStatusDetails.DataSource = DS;
            dpStatusDetails.DataBind();
            dpStatusDetails.Items.FindByText("OK").Enabled = false;
            dpStatusDetails.Items.FindByText("NOT").Enabled = false;
            dpStatusDetails.Items.Insert(0, new ListItem("--QC Status--", "0"));
        }

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                mosfmaap = new MOpeningStockForMilkAndAllProducts();
                bosfmaap = new BOpeningStockForMilkAndAllProducts();
                int Result = 0;
                mosfmaap.OpeningStockForMilkAndAllProductsId = 0;
                mosfmaap.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mosfmaap.OpeningStockForMilkAndAllProductsDate = Convert.ToDateTime(txtDate.Text.ToString());
                mosfmaap.OpeningStockForMilkAndAllProductsShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mosfmaap.SiloNoForMilk = string.IsNullOrEmpty(txtSiloNoForMilk.Text) ? 0 : Convert.ToInt32(txtSiloNoForMilk.Text);
                mosfmaap.MilkType = txtMilkType.Text;
                mosfmaap.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mosfmaap.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mosfmaap.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                mosfmaap.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                mosfmaap.Temperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
                mosfmaap.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
                mosfmaap.MBRT = string.IsNullOrEmpty(txtMBRT.Text) ? 0 : Convert.ToDouble(txtMBRT.Text);
                mosfmaap.HomoEfficiency = string.IsNullOrEmpty(txtHomoEfficiency.Text) ? 0 : Convert.ToDouble(txtHomoEfficiency.Text);
                mosfmaap.Remarks = txtRemarks.Text;
                mosfmaap.OpeningStockForMilkAndAllProductsStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mosfmaap.flag = "Insert";
                Result = bosfmaap.openingstockdata(mosfmaap);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Opening Stock For Milk And All Products Data Add  Successfully";
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

                //return Result;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mosfmaap = new MOpeningStockForMilkAndAllProducts();
                bosfmaap = new BOpeningStockForMilkAndAllProducts();
                int Result = 0;
                mosfmaap.OpeningStockForMilkAndAllProductsId = 0;
                mosfmaap.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mosfmaap.OpeningStockForMilkAndAllProductsDate = Convert.ToDateTime(txtDate.Text.ToString());
                mosfmaap.OpeningStockForMilkAndAllProductsShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mosfmaap.SiloNoForMilk = string.IsNullOrEmpty(txtSiloNoForMilk.Text) ? 0 : Convert.ToInt32(txtSiloNoForMilk.Text);
                mosfmaap.MilkType = txtMilkType.Text;
                mosfmaap.Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToDouble(txtQuantity.Text);
                mosfmaap.FAT = string.IsNullOrEmpty(txtFAT.Text) ? 0 : Convert.ToDouble(txtFAT.Text);
                mosfmaap.SNF = string.IsNullOrEmpty(txtSNF.Text) ? 0 : Convert.ToDouble(txtSNF.Text);
                mosfmaap.CLR = string.IsNullOrEmpty(txtCLR.Text) ? 0 : Convert.ToDouble(txtCLR.Text);
                mosfmaap.Temperature = string.IsNullOrEmpty(txtTemperature.Text) ? 0 : Convert.ToDouble(txtTemperature.Text);
                mosfmaap.Acidity = string.IsNullOrEmpty(txtAcidity.Text) ? 0 : Convert.ToDouble(txtAcidity.Text);
                mosfmaap.MBRT = string.IsNullOrEmpty(txtMBRT.Text) ? 0 : Convert.ToDouble(txtMBRT.Text);
                mosfmaap.HomoEfficiency = string.IsNullOrEmpty(txtHomoEfficiency.Text) ? 0 : Convert.ToDouble(txtHomoEfficiency.Text);
                mosfmaap.Remarks = txtRemarks.Text;
                mosfmaap.OpeningStockForMilkAndAllProductsStatus = Convert.ToInt32(dpStatusDetails.SelectedItem.Value);
                mosfmaap.flag = "Update";
                Result = bosfmaap.openingstockdata(mosfmaap);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Opening Stock For Milk And All Products Data Update  Successfully";
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


        protected void rpOpeningStockForMilkAndAll_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetOpeningStockForMilkAndAllProductsDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);

                        if (dpShiftDetails.SelectedIndex == 0 && txtSiloNoForMilk.Text == "")
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


        public void GetOpeningStockForMilkAndAllProductsDetails()
        {
            bosfmaap = new BOpeningStockForMilkAndAllProducts();
            DataSet DS = new DataSet();
            DS = bosfmaap.GetOpeningStockForMilkAndAllProductsDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpOpeningStockForMilkAndAll.DataSource = DS;
                rpOpeningStockForMilkAndAll.DataBind();
            }
        }

        public void GetOpeningStockForMilkAndAllProductsDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bosfmaap = new BOpeningStockForMilkAndAllProducts();
            DS = bosfmaap.GetOpeningStockForMilkAndAllProductsDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
             {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {

                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsShiftId"]).ToString()).Selected = true;
                }

                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtSiloNoForMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SiloNoForMilk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SiloNoForMilk"].ToString();
                txtMilkType.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkType"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkType"].ToString();
                txtQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Quantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Quantity"].ToString();
                txtFAT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FAT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FAT"].ToString();
                txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtCLR.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLR"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLR"].ToString();
                txtTemperature.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Temperature"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Temperature"].ToString();
                txtAcidity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Acidity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Acidity"].ToString();
                txtMBRT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRT"].ToString();
                txtHomoEfficiency.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["HomoEfficiency"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["HomoEfficiency"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();
                dpStatusDetails.ClearSelection();
                string Status = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsStatus"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsStatus"].ToString();
                if (Status == "")
                {
                    dpStatusDetails.SelectedIndex = 0;
                }
                else
                {

                    dpStatusDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["OpeningStockForMilkAndAllProductsStatus"]).ToString()).Selected = true;
                }

              
            }
        }
    }
}