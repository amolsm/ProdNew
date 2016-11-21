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
    public partial class ChemicalReagentAndMediaPreparationsQC : System.Web.UI.Page
    {
        MChemicalReagentAndMediaPreparationsQC mcramrqc;
        BChemicalReagentAndMediaPreparationsQC bcramrqc;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtReagentMfgDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtReagentExpDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSolutionPrepDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                txtSolutionExpDate.Text = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                GetChemicalReagentAndMediaPreparationsQCDetails();
                btnUpdate.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mcramrqc=new MChemicalReagentAndMediaPreparationsQC();
            bcramrqc = new BChemicalReagentAndMediaPreparationsQC();
            int Result = 0;
            mcramrqc.ChemicalReagentAndMediaPreparationsQCId = 0;
            mcramrqc.ChemicalReagentAndMediaPreparationsQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mcramrqc.ReagentMfgDate = Convert.ToDateTime(txtReagentMfgDate.Text.ToString());
            mcramrqc.ReagentExpDate = Convert.ToDateTime(txtReagentExpDate.Text.ToString());
            mcramrqc.SolutionPreparationDate = Convert.ToDateTime(txtSolutionPrepDate.Text.ToString());
            mcramrqc.SolutionExpDate = Convert.ToDateTime(txtSolutionExpDate.Text.ToString());
            mcramrqc.Phosphatase = string.IsNullOrEmpty(txtPhosphatase.Text) ? 0 : Convert.ToDouble(txtPhosphatase.Text);
            mcramrqc.Media = string.IsNullOrEmpty(txtMedia.Text) ? string.Empty : txtMedia.Text;
            mcramrqc.MBRT = string.IsNullOrEmpty(txtMBRT.Text) ? 0 : Convert.ToDouble(txtMBRT.Text);
            mcramrqc.RosalicAcid = string.IsNullOrEmpty(txtRosalicAcid.Text) ? 0 : Convert.ToDouble(txtRosalicAcid.Text);
            mcramrqc.Neutrilizer = string.IsNullOrEmpty(txtNeutrilizer.Text) ? 0 : Convert.ToDouble(txtNeutrilizer.Text);
            mcramrqc.SodiumHydrogenCarbonate = string.IsNullOrEmpty(txtSodiumHydrogenCarbonate.Text) ? 0 : Convert.ToDouble(txtSodiumHydrogenCarbonate.Text);
            mcramrqc.SodiumCarbonateAnHydrous = string.IsNullOrEmpty(txtSodiumCarbonateAnHydrous.Text) ? 0 : Convert.ToDouble(txtSodiumCarbonateAnHydrous.Text);
            mcramrqc.ParanitrophenylPhosphataseDisodiumSalt = string.IsNullOrEmpty(txtParanitrophenylDisodiumSalt.Text) ? 0 : Convert.ToDouble(txtParanitrophenylDisodiumSalt.Text);
            mcramrqc.DistilledWater = string.IsNullOrEmpty(txtDistilledWater.Text) ? 0 : Convert.ToDouble(txtDistilledWater.Text);
            mcramrqc.ReagentQuantity = string.IsNullOrEmpty(txtReagentQuantity.Text) ? 0 : Convert.ToDouble(txtReagentQuantity.Text);
            mcramrqc.PreparationQuantity = string.IsNullOrEmpty(txtPreparationQuantity.Text) ? 0 : Convert.ToDouble(txtPreparationQuantity.Text);
            mcramrqc.ReagentLotNo = string.IsNullOrEmpty(txtReagentLotNo.Text) ? 0 : Convert.ToDouble(txtReagentLotNo.Text);
            mcramrqc.Others = string.IsNullOrEmpty(txtOthers.Text) ? string.Empty:txtOthers.Text;
            mcramrqc.PreparedBy = string.IsNullOrEmpty(txtPreparedBy.Text) ? string.Empty : txtPreparedBy.Text;
            mcramrqc.VarifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mcramrqc.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mcramrqc.flag="Insert";
            Result = bcramrqc.chemicalreagentqcdata(mcramrqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Chemical Reagent And Media Preparations QC Data Added  Successfully";
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
            mcramrqc = new MChemicalReagentAndMediaPreparationsQC();
            bcramrqc = new BChemicalReagentAndMediaPreparationsQC();
            int Result = 0;
            mcramrqc.ChemicalReagentAndMediaPreparationsQCId = string.IsNullOrEmpty(hId.Value) ? 0 : Convert.ToInt32(hId.Value);
            mcramrqc.ChemicalReagentAndMediaPreparationsQCDate = Convert.ToDateTime(txtDate.Text.ToString());
            mcramrqc.ReagentMfgDate = Convert.ToDateTime(txtReagentMfgDate.Text.ToString());
            mcramrqc.ReagentExpDate = Convert.ToDateTime(txtReagentExpDate.Text.ToString());
            mcramrqc.SolutionPreparationDate = Convert.ToDateTime(txtSolutionPrepDate.Text.ToString());
            mcramrqc.SolutionExpDate = Convert.ToDateTime(txtSolutionExpDate.Text.ToString());
            mcramrqc.Phosphatase = string.IsNullOrEmpty(txtPhosphatase.Text) ? 0 : Convert.ToDouble(txtPhosphatase.Text);
            mcramrqc.Media = string.IsNullOrEmpty(txtMedia.Text) ? string.Empty : txtMedia.Text;
            mcramrqc.MBRT = string.IsNullOrEmpty(txtMBRT.Text) ? 0 : Convert.ToDouble(txtMBRT.Text);
            mcramrqc.RosalicAcid = string.IsNullOrEmpty(txtRosalicAcid.Text) ? 0 : Convert.ToDouble(txtRosalicAcid.Text);
            mcramrqc.Neutrilizer = string.IsNullOrEmpty(txtNeutrilizer.Text) ? 0 : Convert.ToDouble(txtNeutrilizer.Text);
            mcramrqc.SodiumHydrogenCarbonate = string.IsNullOrEmpty(txtSodiumHydrogenCarbonate.Text) ? 0 : Convert.ToDouble(txtSodiumHydrogenCarbonate.Text);
            mcramrqc.SodiumCarbonateAnHydrous = string.IsNullOrEmpty(txtSodiumCarbonateAnHydrous.Text) ? 0 : Convert.ToDouble(txtSodiumCarbonateAnHydrous.Text);
            mcramrqc.ParanitrophenylPhosphataseDisodiumSalt = string.IsNullOrEmpty(txtParanitrophenylDisodiumSalt.Text) ? 0 : Convert.ToDouble(txtParanitrophenylDisodiumSalt.Text);
            mcramrqc.DistilledWater = string.IsNullOrEmpty(txtDistilledWater.Text) ? 0 : Convert.ToDouble(txtDistilledWater.Text);
            mcramrqc.ReagentQuantity = string.IsNullOrEmpty(txtReagentQuantity.Text) ? 0 : Convert.ToDouble(txtReagentQuantity.Text);
            mcramrqc.PreparationQuantity = string.IsNullOrEmpty(txtPreparationQuantity.Text) ? 0 : Convert.ToDouble(txtPreparationQuantity.Text);
            mcramrqc.ReagentLotNo = string.IsNullOrEmpty(txtReagentLotNo.Text) ? 0 : Convert.ToDouble(txtReagentLotNo.Text);
            mcramrqc.Others = string.IsNullOrEmpty(txtOthers.Text) ? string.Empty : txtOthers.Text;
            mcramrqc.PreparedBy = string.IsNullOrEmpty(txtPreparedBy.Text) ? string.Empty : txtPreparedBy.Text;
            mcramrqc.VarifiedBy = string.IsNullOrEmpty(txtVerifiedBy.Text) ? string.Empty : txtVerifiedBy.Text;
            mcramrqc.ApprovedBy = string.IsNullOrEmpty(txtApprovedBy.Text) ? string.Empty : txtApprovedBy.Text;
            mcramrqc.flag = "Update";
            Result = bcramrqc.chemicalreagentqcdata(mcramrqc);
            if (Result > 0)
            {
                divDanger.Visible = false;
                divwarning.Visible = false;

                divSusccess.Visible = true;
                lblSuccess.Text = "Chemical Reagent And Media Preparations QC Data Updated  Successfully";
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

        protected void rpChemicalReagentQC_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        lblHeaderTab.Text = "Edit Chemical Reagent And Media Preparations QC Details";
                        hId.Value = Id.ToString();
                        Id = Convert.ToInt32(hId.Value);
                        GetChemicalReagentAndMediaPreparationsQCDetails(Id);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "sel3", "$('#bx1').removeClass('collapsed-box');", true);

                        //if (txtPhosphatase == 0 && txtCreamQualityPhysical.Text == "")
                        //{
                        //    btnAdd.Visible = true;
                        //    btnUpdate.Visible = false;
                        //}
                        //else
                        //{
                        //    btnAdd.Visible = false;
                        //    btnUpdate.Visible = true;
                        //}
                        btnUpdate.Visible = true;
                        btnAdd.Visible = false;
                        btnRefresh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
            }
        }

        public void GetChemicalReagentAndMediaPreparationsQCDetails()
        {
            bcramrqc=new BChemicalReagentAndMediaPreparationsQC() ;
            DataSet DS = new DataSet();
            DS = bcramrqc.GetChemicalReagentAndMediaPreparationsQCDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpChemicalReagentQC.DataSource = DS;
                rpChemicalReagentQC.DataBind();
            }
        }

        public void GetChemicalReagentAndMediaPreparationsQCDetails(int ChemicalReagentAndMediaPreparationsQCId)
        {
            DataSet DS = new DataSet();
            bcramrqc = new BChemicalReagentAndMediaPreparationsQC();
            DS = bcramrqc.GetChemicalReagentAndMediaPreparationsQCDetailsById(ChemicalReagentAndMediaPreparationsQCId);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                string DATE = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ChemicalReagentAndMediaPreparationsQCDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ChemicalReagentAndMediaPreparationsQCDate"].ToString();
                DateTime date1 = Convert.ToDateTime(DATE, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtDate.Text = (Convert.ToDateTime(date1).ToString("yyyy-MM-dd"));

                string DATE2 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReagentMfgDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReagentMfgDate"].ToString();
                DateTime date2 = Convert.ToDateTime(DATE2, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtReagentMfgDate.Text = (Convert.ToDateTime(date2).ToString("yyyy-MM-dd"));

                string DATE3 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReagentExpDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReagentExpDate"].ToString();
                DateTime date3 = Convert.ToDateTime(DATE3, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtReagentExpDate.Text = (Convert.ToDateTime(date3).ToString("yyyy-MM-dd"));

                string DATE4 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SolutionPreparationDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SolutionPreparationDate"].ToString();
                DateTime date4 = Convert.ToDateTime(DATE4, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtSolutionPrepDate.Text = (Convert.ToDateTime(date4).ToString("yyyy-MM-dd"));

                string DATE5 = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SolutionExpDate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SolutionExpDate"].ToString();
                DateTime date5 = Convert.ToDateTime(DATE5, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
                txtSolutionExpDate.Text= (Convert.ToDateTime(date5).ToString("yyyy-MM-dd"));

                txtPhosphatase.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Phosphatase"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Phosphatase"].ToString();
                txtMedia.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Media"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Media"].ToString();
                txtMBRT.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MBRT"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MBRT"].ToString();
                txtRosalicAcid.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["RosalicAcid"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["RosalicAcid"].ToString();
                txtNeutrilizer.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Neutrilizer"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Neutrilizer"].ToString();
                txtSodiumHydrogenCarbonate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SodiumHydrogenCarbonate"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SodiumHydrogenCarbonate"].ToString();
                txtSodiumCarbonateAnHydrous.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SodiumCarbonateAnHydrous"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SodiumCarbonateAnHydrous"].ToString();
                txtParanitrophenylDisodiumSalt.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ParanitrophenylPhosphataseDisodiumSalt"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ParanitrophenylPhosphataseDisodiumSalt"].ToString();
                txtDistilledWater.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["DistilledWater"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["DistilledWater"].ToString();
                txtReagentQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReagentQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReagentQuantity"].ToString();
                txtPreparationQuantity.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PreparationQuantity"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PreparationQuantity"].ToString();
                txtReagentLotNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ReagentLotNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ReagentLotNo"].ToString();
                txtOthers.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Others"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Others"].ToString();
                txtPreparedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["PreparedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["PreparedBy"].ToString();
                txtApprovedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["ApprovedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["ApprovedBy"].ToString();
                txtVerifiedBy.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["VarifiedBy"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["VarifiedBy"].ToString();
            }
        }
    }
}