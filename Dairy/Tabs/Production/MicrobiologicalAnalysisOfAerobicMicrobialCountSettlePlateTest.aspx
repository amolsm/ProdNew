<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest.aspx.cs" Inherits="Dairy.Tabs.Production.MicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <section class="content-header">
          <h1>
           Microbiological Analysis of Aerobic Microbial Count Settle Plate Test   
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTest</li>
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

</asp:Content>
