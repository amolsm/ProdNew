<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalHygieneCheckListQC.aspx.cs" Inherits="Dairy.Tabs.Production.PersonalHygieneCheckListQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
           Personal Hygiene CheckListQC   
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">PersonalHygieneCheckListQC</li>
          </ol>
        </section>

     <section class="content">
                     <div class="row">
                    <asp:UpdatePanel runat="server" ID="pnlError" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="alert alert-danger alert-dismissable" runat="server" id="divDanger" visible="false">


                                <h4>
                                    <i class="icon fa fa-ban"></i>Alert!</h4>
                                <asp:Label runat="server" ID="lbldanger" Text="Something went worng please try Again"></asp:Label>
                            </div>
                            <div class="alert alert-warning alert-dismissable" runat="server" id="divwarning"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-warning"></i>Warning!</h4>
                                <asp:Label runat="server" ID="lblwarning" Text="Something Went wrong Please Try Again"></asp:Label>
                            </div>
                            <div class="alert alert-success alert-dismissable" runat="server" id="divSusccess"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-check"></i>Success!</h4>
                                <asp:Label runat="server" ID="lblSuccess" Text="Order Received Succesfully"></asp:Label>
                            </div>
                        </div>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div> 

               <div class="box">
                   <div class="box-header with-border">
                   <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Personal Hygiene CheckListQC Details"></asp:Label> </h3>
                   <div class="box-tools pull-right">
                   <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
                   </div>
                   </div>
               <div class="box-body">

                             <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>
        
              

            

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label2" runat="server" Text="Employee Name"></asp:Label>
                      </div>
                      <asp:CheckBox ID="CheckBox3" runat="server"></asp:CheckBox> 
                        </div>                                      
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
            </div>


                   <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                   <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>               

<asp:Panel ID="Panel1" runat="server"></asp:Panel>
<asp:Image ID="Image1" runat="server"></asp:Image>

<asp:ImageButton ID="ImageButton1" runat="server"></asp:ImageButton>

<asp:Table ID="Table1" runat="server"></asp:Table>

<asp:UpdatePanel ID="UpdatePanel2" runat="server"></asp:UpdatePanel>
<asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>

<asp:HiddenField ID="HiddenField1" runat="server" OnPreRender="HiddenField1_PreRender"></asp:HiddenField>

<asp:AdRotator ID="AdRotator1" runat="server"></asp:AdRotator>
<asp:ImageMap ID="ImageMap1" runat="server"></asp:ImageMap>
  
<asp:Timer ID="Timer1" runat="server" ></asp:Timer>


<asp:PasswordRecovery ID="PasswordRecovery1" runat="server"></asp:PasswordRecovery>


<asp:PasswordRecovery ID="PasswordRecovery2" runat="server" OnUnload="PasswordRecovery2_Unload"></asp:PasswordRecovery>




<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"></asp:Button>















                </div>
            </ContentTemplate> 
          </asp:UpdatePanel>
        </div><!-- /.box-body -->            
     </div><!-- /.box -->

   
</asp:Content>
