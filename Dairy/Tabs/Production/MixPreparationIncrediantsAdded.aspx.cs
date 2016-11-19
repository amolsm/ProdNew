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
    public partial class MixPreparationIncrediantsAdded : System.Web.UI.Page
    {
        MMixPreparationIncrediantsAdded mmpia;
        BMixPreparationIncrediantsAdded bmpia;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDwon();
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMixPreparationIncrediantsAddedDetails();
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

                mmpia = new MMixPreparationIncrediantsAdded();
                bmpia = new BMixPreparationIncrediantsAdded();
                int Result = 0;
                mmpia.MixPreparationIncrediantsAddedId = 0;
                mmpia.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mmpia.MixPreparationIncrediantsAddedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mmpia.MixPreparationIncrediantsAddedShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmpia.SMP = string.IsNullOrEmpty(txtSMP.Text) ? 0 : Convert.ToDouble(txtSMP.Text);
                mmpia.Cream = string.IsNullOrEmpty(txtCream.Text) ? 0 : Convert.ToDouble(txtCream.Text);
                mmpia.Milk = txtMilk.Text;
                mmpia.Sugar = string.IsNullOrEmpty(txtSugar.Text) ? 0 : Convert.ToDouble(txtSugar.Text);
                mmpia.Stabilizer = string.IsNullOrEmpty(txtStabilizer.Text) ? 0 : Convert.ToDouble(txtStabilizer.Text);
                mmpia.Emulsifier = string.IsNullOrEmpty(txtEmulsifier.Text) ? 0 : Convert.ToDouble(txtEmulsifier.Text);
                mmpia.TotalMixQty = string.IsNullOrEmpty(txtTotalMixQty.Text) ? 0 : Convert.ToDouble(txtTotalMixQty.Text);
                mmpia.Remarks = txtRemarks.Text;
                mmpia.flag = "Insert";
                Result = bmpia.mixpreparationdata(mmpia);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Mix Preparation Incrediants Added Data Add  Successfully";
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

                mmpia = new MMixPreparationIncrediantsAdded();
                bmpia = new BMixPreparationIncrediantsAdded();
                int Result = 0;
                mmpia.MixPreparationIncrediantsAddedId = 0;
                mmpia.RMRId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
                mmpia.MixPreparationIncrediantsAddedDate = Convert.ToDateTime(txtDate.Text.ToString());
                mmpia.MixPreparationIncrediantsAddedShiftId = Convert.ToInt32(dpShiftDetails.SelectedItem.Value);
                mmpia.SMP = string.IsNullOrEmpty(txtSMP.Text) ? 0 : Convert.ToDouble(txtSMP.Text);
                mmpia.Cream = string.IsNullOrEmpty(txtCream.Text) ? 0 : Convert.ToDouble(txtCream.Text);
                mmpia.Milk = txtMilk.Text;
                mmpia.Sugar = string.IsNullOrEmpty(txtSugar.Text) ? 0 : Convert.ToDouble(txtSugar.Text);
                mmpia.Stabilizer = string.IsNullOrEmpty(txtStabilizer.Text) ? 0 : Convert.ToDouble(txtStabilizer.Text);
                mmpia.Emulsifier = string.IsNullOrEmpty(txtEmulsifier.Text) ? 0 : Convert.ToDouble(txtEmulsifier.Text);
                mmpia.TotalMixQty = string.IsNullOrEmpty(txtTotalMixQty.Text) ? 0 : Convert.ToDouble(txtTotalMixQty.Text);
                mmpia.Remarks = txtRemarks.Text;
                mmpia.flag = "Update";
                Result = bmpia.mixpreparationdata(mmpia);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Mix Preparation Incrediants Added Data Update  Successfully";
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

        protected void rpMixPreparationIncrediantsAdded_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Mix Preparation Incrediants Added Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetMixPreparationIncrediantsAddedDetails(Id);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);


                        if (dpShiftDetails.SelectedIndex == 0 && txtSMP.Text == "")
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


        public void GetMixPreparationIncrediantsAddedDetails()
        {
            bmpia = new BMixPreparationIncrediantsAdded();
            DataSet DS = new DataSet();
            DS = bmpia.GetMixPreparationIncrediantsAddedDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMixPreparationIncrediantsAdded.DataSource = DS;
                rpMixPreparationIncrediantsAdded.DataBind();
            }
        }

        public void GetMixPreparationIncrediantsAddedDetails(int RMRId)
        {
            DataSet DS = new DataSet();
            bmpia = new BMixPreparationIncrediantsAdded();
            DS = bmpia.GetMixPreparationIncrediantsAddedDetailsById(RMRId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MixPreparationIncrediantsAddedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MixPreparationIncrediantsAddedDate"].ToString();
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
                string Shift = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MixPreparationIncrediantsAddedShiftId"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MixPreparationIncrediantsAddedShiftId"].ToString();
                if (Shift == "")
                {
                    dpShiftDetails.SelectedIndex = 0;
                }
                else
                {

                    dpShiftDetails.Items.FindByValue(Convert.ToInt32(DS.Tables[0].Rows[0]["MixPreparationIncrediantsAddedShiftId"]).ToString()).Selected = true;
                }
                txtBatchNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["BatchNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["BatchNo"].ToString();
                txtSMP.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SMP"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SMP"].ToString();
                txtCream.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Cream"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Cream"].ToString();
                txtMilk.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Milk"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Milk"].ToString();
                txtSugar.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Sugar"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Sugar"].ToString();
                txtStabilizer.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Stabilizer"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Stabilizer"].ToString();
                txtEmulsifier.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Emulsifier"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Emulsifier"].ToString();
                txtTotalMixQty.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TotalMixQty"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TotalMixQty"].ToString();
                txtRemarks.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Remarks"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Remarks"].ToString();

            }
        }
    }
}