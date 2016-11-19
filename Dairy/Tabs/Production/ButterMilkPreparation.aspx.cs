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
    public partial class ButterMilkPreparation : System.Web.UI.Page
    {
        MButterMilkPreparation mbmp;
        BButterMilkPreparation bbmp;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetButterMilkDetails();
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

                mbmp = new MButterMilkPreparation();
                bbmp = new BButterMilkPreparation();
                int Result = 0;
                mbmp.ButterMilkPreparationId = 0;
                mbmp.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mbmp.ButterMilkPreparationDate = Convert.ToDateTime(txtDate.Text.ToString());
                mbmp.ButterMilkPreparationShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mbmp.CurdQuantity = string.IsNullOrEmpty(txtCurdQuantity.Text) ? 0 : Convert.ToDouble(txtCurdQuantity.Text);
                mbmp.GingerQuantity = string.IsNullOrEmpty(txtGingerQuantity.Text) ? 0 : Convert.ToDouble(txtGingerQuantity.Text);
                mbmp.ChillyQuantity = string.IsNullOrEmpty(txtChillyQuantity.Text) ? 0 : Convert.ToDouble(txtChillyQuantity.Text);
                mbmp.Salt = string.IsNullOrEmpty(txtSalt.Text) ? 0 : Convert.ToDouble(txtSalt.Text);
                mbmp.CurryLeaves = string.IsNullOrEmpty(txtCurryLeaves.Text) ? 0 : Convert.ToDouble(txtCurryLeaves.Text);
                mbmp.CorianderLeaves = string.IsNullOrEmpty(txtCorianderLeaves.Text) ? 0 : Convert.ToDouble(txtCorianderLeaves.Text);
                mbmp.Lemon = string.IsNullOrEmpty(txtLemon.Text) ? 0 : Convert.ToDouble(txtLemon.Text);
                mbmp.TotalPouchProduction = string.IsNullOrEmpty(txtTotalPouchProduction.Text) ? 0 : Convert.ToDouble(txtTotalPouchProduction.Text);
                mbmp.Damage = string.IsNullOrEmpty(txtDamage.Text) ? 0 : Convert.ToDouble(txtDamage.Text);
                mbmp.MixedAndTastedBy = string.IsNullOrEmpty(txtMixedAndTastedBy.Text) ? string.Empty : txtMixedAndTastedBy.Text;
                mbmp.TastedAndMonitoredBy = string.IsNullOrEmpty(txtTastedAndMonitoredBy.Text) ? string.Empty : txtTastedAndMonitoredBy.Text;
                mbmp.flag = "Insert";
                Result = bbmp.buttermilkdata(mbmp);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Butter Milk Preparation Data Add  Successfully";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            {

                mbmp = new MButterMilkPreparation();
                bbmp = new BButterMilkPreparation();
                int Result = 0;
                mbmp.ButterMilkPreparationId = 0;
                mbmp.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mbmp.ButterMilkPreparationDate = Convert.ToDateTime(txtDate.Text.ToString());
                mbmp.ButterMilkPreparationShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mbmp.CurdQuantity = string.IsNullOrEmpty(txtCurdQuantity.Text) ? 0 : Convert.ToDouble(txtCurdQuantity.Text);
                mbmp.GingerQuantity = string.IsNullOrEmpty(txtGingerQuantity.Text) ? 0 : Convert.ToDouble(txtGingerQuantity.Text);
                mbmp.ChillyQuantity = string.IsNullOrEmpty(txtChillyQuantity.Text) ? 0 : Convert.ToDouble(txtChillyQuantity.Text);
                mbmp.Salt = string.IsNullOrEmpty(txtSalt.Text) ? 0 : Convert.ToDouble(txtSalt.Text);
                mbmp.CurryLeaves = string.IsNullOrEmpty(txtCurryLeaves.Text) ? 0 : Convert.ToDouble(txtCurryLeaves.Text);
                mbmp.CorianderLeaves = string.IsNullOrEmpty(txtCorianderLeaves.Text) ? 0 : Convert.ToDouble(txtCorianderLeaves.Text);
                mbmp.Lemon = string.IsNullOrEmpty(txtLemon.Text) ? 0 : Convert.ToDouble(txtLemon.Text);
                mbmp.TotalPouchProduction = string.IsNullOrEmpty(txtTotalPouchProduction.Text) ? 0 : Convert.ToDouble(txtTotalPouchProduction.Text);
                mbmp.Damage = string.IsNullOrEmpty(txtDamage.Text) ? 0 : Convert.ToDouble(txtDamage.Text);
                mbmp.MixedAndTastedBy = string.IsNullOrEmpty(txtMixedAndTastedBy.Text) ? string.Empty : txtMixedAndTastedBy.Text;
                mbmp.TastedAndMonitoredBy = string.IsNullOrEmpty(txtTastedAndMonitoredBy.Text) ? string.Empty : txtTastedAndMonitoredBy.Text;
                mbmp.flag = "Update";
                Result = bbmp.buttermilkdata(mbmp);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Butter Milk Preparation Data Update  Successfully";
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

        protected void rpButterMilkPreparation_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Butter Milk Preparation Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetButterMilkDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);


                        if (dpShiftDetails.SelectedIndex == 0 && txtCurdQuantity.Text == "")
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

        public void GetButterMilkDetails()
        {
            bbmp = new BButterMilkPreparation();
            DataSet DS = new DataSet();
            DS = bbmp.GetButterMilkDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS)) ;
            {
                rpButterMilkPreparation.DataSource = DS;
                rpButterMilkPreparation.DataBind();
            }

        }

        public void GetButterMilkDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bbmp = new BButterMilkPreparation();
            DS =bbmp.GetButterMilkDetailsById (RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ButterMilkPreparationDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ButterMilkPreparationDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ButterMilkPreparationShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ButterMilkPreparationShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {
                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["ButterMilkPreparationShiftId"]).ToString()).Selected = true;
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtCurdQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurdQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurdQuantity"].ToString();
                txtGingerQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["GingerQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["GingerQuantity"].ToString();
                txtChillyQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ChillyQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ChillyQuantity"].ToString();
                txtSalt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Salt"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Salt"].ToString();
                txtCurryLeaves.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CurryLeaves"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CurryLeaves"].ToString();
                txtCorianderLeaves.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CorianderLeaves"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CorianderLeaves"].ToString();
                txtLemon.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Lemon"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Lemon"].ToString();
                txtTotalPouchProduction.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalPouchProduction"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalPouchProduction"].ToString();
                txtDamage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Damage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Damage"].ToString();
                txtMixedAndTastedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MixedAndTastedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MixedAndTastedBy"].ToString();
                txtTastedAndMonitoredBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TastedAndMonitoredBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TastedAndMonitoredBy"].ToString();

            }
        }
    }
}