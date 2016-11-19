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
    public partial class MicrobiologicalCultureStockRegisterQC : System.Web.UI.Page
    {
        MMicrobiologicalCultureStockRegisterQC mmbcsrqc;
        BMicrobiologicalCultureStockRegisterQC bmbcsrqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStockDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtReceivedDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtPackingDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetMicrobiologicalCultureStockRegisterQCDetails();
                btnUpdate.Visible = false;
            }
        }

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
                mmbcsrqc = new MMicrobiologicalCultureStockRegisterQC();
                bmbcsrqc = new BMicrobiologicalCultureStockRegisterQC();
                int Result = 0;
                mmbcsrqc.MicrobiologicalCultureStockRegisterQCId = 0;
                mmbcsrqc.MicrobiologicalStockDate = Convert.ToDateTime(txtStockDate.Text.ToString());
                mmbcsrqc.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text.ToString());
                mmbcsrqc.PackingDate = Convert.ToDateTime(txtPackingDate.Text.ToString());
                mmbcsrqc.OpeningStock = string.IsNullOrEmpty(txtOpeningStock.Text) ? 0 : Convert.ToDouble(txtOpeningStock.Text);
                mmbcsrqc.Receipt = string.IsNullOrEmpty(txtReceipt.Text) ? string.Empty :txtReceipt.Text;  
                mmbcsrqc.Issue = string.IsNullOrEmpty(txtIssue.Text)?string.Empty:txtIssue.Text;
                mmbcsrqc.Damage = string.IsNullOrEmpty(txtDamage.Text) ? string.Empty:txtDamage.Text; 
                mmbcsrqc.Returned = string.IsNullOrEmpty(txtReturned.Text) ? string.Empty:txtReturned.Text; 
                mmbcsrqc.ClosingStock = string.IsNullOrEmpty(txtClosingStock.Text) ? 0 : Convert.ToDouble(txtClosingStock.Text);
                mmbcsrqc.CultureUsed = string.IsNullOrEmpty(txtCultureUsed.Text) ? string.Empty:txtCultureUsed.Text;
                mmbcsrqc.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
                mmbcsrqc.flag = "Insert";
                Result = bmbcsrqc.microbiologicaldata(mmbcsrqc);
                if (Result > 0)
                {
                    divDanger.Visible = false;
                    divwarning.Visible = false;

                    divSusccess.Visible = true;
                    lblSuccess.Text = "Micro biological Culture Stock Register QC Data Added  Successfully";
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

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {

            mmbcsrqc = new MMicrobiologicalCultureStockRegisterQC();
            bmbcsrqc = new BMicrobiologicalCultureStockRegisterQC();
            int Result = 0;
            mmbcsrqc.MicrobiologicalCultureStockRegisterQCId = Convert.ToInt32(hId.Value);
            mmbcsrqc.MicrobiologicalStockDate = Convert.ToDateTime(txtStockDate.Text.ToString());
            mmbcsrqc.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text.ToString());
            mmbcsrqc.PackingDate = Convert.ToDateTime(txtPackingDate.Text.ToString());
            mmbcsrqc.OpeningStock = string.IsNullOrEmpty(txtOpeningStock.Text) ? 0 : Convert.ToDouble(txtOpeningStock.Text);
            mmbcsrqc.Receipt = string.IsNullOrEmpty(txtReceipt.Text) ? string.Empty : txtReceipt.Text;
            mmbcsrqc.Issue = string.IsNullOrEmpty(txtIssue.Text) ? string.Empty : txtIssue.Text;
            mmbcsrqc.Damage = string.IsNullOrEmpty(txtDamage.Text) ? string.Empty : txtDamage.Text;
            mmbcsrqc.Returned = string.IsNullOrEmpty(txtReturned.Text) ? string.Empty : txtReturned.Text;
            mmbcsrqc.ClosingStock = string.IsNullOrEmpty(txtClosingStock.Text) ? 0 : Convert.ToDouble(txtClosingStock.Text);
            mmbcsrqc.CultureUsed = string.IsNullOrEmpty(txtCultureUsed.Text) ? string.Empty : txtCultureUsed.Text;
            mmbcsrqc.VerifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mmbcsrqc.flag = "Update";
            Result = bmbcsrqc.microbiologicaldata(mmbcsrqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Micro biological Culture Stock Register QC Data Updated  Successfully";
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


        protected void rpMicrobiologicalCultureStockRegisterQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        GetMicrobiologicalCultureStockRegisterQCDetails(Id);


                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        btnUpdate.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetMicrobiologicalCultureStockRegisterQCDetails()
        {
            bmbcsrqc = new BMicrobiologicalCultureStockRegisterQC();
            DataSet DS = new DataSet();
            DS = bmbcsrqc.GetMicrobiologicalCultureStockRegisterQCDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS)) ;
            {
                rpMicrobiologicalCultureStockRegisterQC.DataSource = DS;
                rpMicrobiologicalCultureStockRegisterQC.DataBind();
            }

        }

        public void GetMicrobiologicalCultureStockRegisterQCDetails(int MicrobiologicalCultureStockRegisterQCId)
        {
            DataSet DS = new DataSet();
            bmbcsrqc = new BMicrobiologicalCultureStockRegisterQC();
            DS = bmbcsrqc.GetMicrobiologicalCultureStockRegisterQCDetailsById(MicrobiologicalCultureStockRegisterQCId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                //string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MicrobiologicalStockDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MicrobiologicalStockDate"].ToString();
                //DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtStockDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));

                //string DATE2 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceivedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceivedDate"].ToString();
                //DateTime date2 = Convert.ToDateTime(DATE2, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtReceivedDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));

                //string DATE3 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingDate"].ToString();
                //DateTime date3 = Convert.ToDateTime(DATE3, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                //txtPackingDate.Text = (Convert.ToDateTime(date3).ToString("yyyy-MM-dd"));

                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MicrobiologicalStockDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MicrobiologicalStockDate"].ToString();
                if (DATE == "")
                {
                    txtStockDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtStockDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                string DATE2 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReceivedDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReceivedDate"].ToString();
                if (DATE2 == "")
                {
                    txtReceivedDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtReceivedDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                string DATE3 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PackingDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PackingDate"].ToString();
                if (DATE3 == "")
                {
                    txtPackingDate.Text = Convert.ToString(DateTime.Now.ToString("yyy-MM-dd"));
                }
                else
                {
                    DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                    txtPackingDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));
                }

                txtOpeningStock.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["OpeningStock"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["OpeningStock"].ToString();
                txtReceipt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Receipt"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Receipt"].ToString();
                txtIssue.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Issue"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Issue"].ToString();
                txtDamage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Damage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Damage"].ToString();
                txtReturned.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Returned"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Returned"].ToString();
                txtClosingStock.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ClosingStock"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ClosingStock"].ToString();
                txtCultureUsed.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CultureUsed"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CultureUsed"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VerifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VerifiedBy"].ToString();

            }
        }
    }
}