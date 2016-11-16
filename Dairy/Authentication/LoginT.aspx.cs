﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using Bussiness;
using System.Data;
namespace Dairy.Authentication
{
    public partial class LoginT : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Visible = false;
            DataSet DS = new DataSet();
            if (!IsPostBack)
            {
                DS = BindCommanData.BindCommanDropDwon("AgentID", "AgentCode+' '+AgentName as Name", "AgentMaster", "IsArchive=0 and Agensytype='Booth'");
                if (!Comman.Comman.IsDataSetEmpty(DS))
                {
                    dpAgent.DataSource = DS;
                    dpAgent.DataBind();
                    dpAgent.Items.Insert(0, new ListItem("--Select Booth--", "0"));
                }

            }
        }
        protected void btnLogin_clcik(object sender, EventArgs e)
        {

            ViewState["txtpassword"] = txtpassword.Text;
            UserData userData = new UserData();
            user.UserName = txtUsername.Text;
            user.PassWord = txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
            if (userData.Isauthenticat(user) && checkLoggedIn())
            {
                 if (user.RoleID.ToString() == "Sales")
                {

                    PNLLOGIN.Visible = false;
                    PNLSELECTBOTH.Visible = true;
                   // CreateAutinticationTikit(user, string.Empty);
                }
                else
                {
                    PNLLOGIN.Visible = true;
                    PNLSELECTBOTH.Visible = false;
                    CreateAutinticationTikit(user, string.Empty);


                }
               

            }
            else
            {
                txtUsername.Text = "";
                txtpassword.Text = "";
                lblmsg.Visible = true;
            }
        }

       public bool checkLoggedIn()
        {
            List<string> d = Application["UsersLoggedIn"] as List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(user.UserName))
                    {
                        // User is already logged in!!!
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User already logged in')", true);
                        return false;
                    }
                    d.Add(user.UserName);
                }
            }
            Session["UserLoggedIn"] = user.UserName;
            return true;
        }
          public void CreateAutinticationTikit(User user,string bothID)
        {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsername.Text,
                DateTime.Now, DateTime.Now.AddMinutes(60),
                true, user.UserID.ToString() + ";" + user.RoleID.ToString() + ";" + user.UserName.ToString() + ";" + user.privilege.ToString() + ";" + user.LastLogin+ ";" + bothID,
                FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName, // Name of auth cookie (it's the name specified in web.config)
                hash); // Hashed ticket                        
                Response.Cookies.Add(cookie);
                switch (user.RoleID.ToString())
                {
                      case "Administration":
                        {
                            Response.Redirect("/Tabs/Administration/CreateUser.aspx");
                            break;
                        }
                        case "Reception":
                        {
                            Response.Redirect("/Tabs/Reception/PlaceOrder.aspx");
                            break;
                        }
                        case "Sales":
                        {
                            Response.Redirect("/Tabs/Sales/BoothStockLanding.aspx");
                            break;
                        }
                        case "Despatch":
                        {
                            Response.Redirect("/Tabs/Despatch/ViewDispatchOrders.aspx");
                            break;
                        }   
                        case "Cashier":
                            {
                                Response.Redirect("/Tabs/Administration/CashierSettlement.aspx");
                                break;
                            }
                case "Transport":
                    {
                        Response.Redirect("/Tabs/TransportModule/TransportBrandMaster.aspx");
                        break;
                    }
            }               

            }
              protected void dpAgentpre_SelectedIndexChanged(object sender, EventArgs e)
           {
            if(dpAgent.SelectedItem.Value != "0")
            { 
            UserData userData = new UserData();
            user.UserName = txtUsername.Text;
            user.PassWord = ViewState["txtpassword"].ToString();//txtpassword.Text;// FormsAuthentication.HashPasswordForStoringInConfigFile(txtpassword.Text, "MD5");
            if (userData.Isauthenticat(user) && boothLoggedIn())
            {
                CreateAutinticationTikit(user, dpAgent.SelectedItem.Value);
            }
            }
        }

        public bool boothLoggedIn()
        {
            List<string> d = Application["BoothLoggedIn"] as List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(dpAgent.SelectedItem.Text))
                    {
                        // User is already logged in!!!
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booth already logged in')", true);
                        return false;
                    }
                    d.Add(dpAgent.SelectedItem.Text);
                }
            }
            Session["BoothLoggedIn"] = dpAgent.SelectedItem.Text;
            return true;
        }
    }
    }
