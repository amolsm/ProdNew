<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChemicalReagentAndMediaPreparationsQC.aspx.cs" Inherits="Dairy.Tabs.Production.ChemicalReagentAndMediaPreparationsQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>
           Chemical Reagent And Media Preparations QC     
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">ChemicalReagentAndMediaPreparationsQC</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Chemical Reagent And Media Preparations QC Details"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

           <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>

                   <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>                
                          

                   <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label1" runat="server" Text="Regnt Mfg Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtReagentMfgDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>                 



                  <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label2" runat="server" Text="Regnt Exp Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtReagentExpDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>    



                   <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label3" runat="server" Text="Solu Prep Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSolutionPrepDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div> 


                   <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label4" runat="server" Text="Solu Exp Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSolutionExpDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>   


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label8" runat="server" Text="Phosphatase"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPhosphatase" class="form-control"   placeholder="Enter Phosphatase" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Phosphatase" ControlToValidate="txtPhosphatase" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label9" runat="server" Text="Media"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMedia" class="form-control"   placeholder="Enter Media" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Media" ControlToValidate="txtMedia" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label10" runat="server" Text="MBRT"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMBRT" class="form-control"   placeholder="Enter MBRT " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter MBRT " ControlToValidate="txtMBRT" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label11" runat="server" Text="Rosalic Acid"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRosalicAcid" class="form-control"   placeholder="Enter Rosalic Acid" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Rosalic Acid" ControlToValidate="txtRosalicAcid" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label12" runat="server" Text="Neutrilizer"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtNeutrilizer" class="form-control"   placeholder="Enter Neutrilizer" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Neutrilizer" ControlToValidate="txtNeutrilizer" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label13" runat="server" Text="Sodium Hydrogen Carbonate"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSodiumHydrogenCarbonate" class="form-control"   placeholder="Enter " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Sodium Hydrogen Carbonate" ControlToValidate="txtSodiumHydrogenCarbonate" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label14" runat="server" Text="Sodium Carbonate An Hydrous"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSodiumCarbonateAnHydrous" class="form-control"   placeholder="Enter " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Sodium Carbonate An Hydrous" ControlToValidate="txtSodiumCarbonateAnHydrous" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label15" runat="server" Text="Paranitrophenyl Disodium Salt"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtParanitrophenylDisodiumSalt" class="form-control"   placeholder="Enter" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter Paranitrophenyl Disodium Salt" ControlToValidate="txtParanitrophenylDisodiumSalt" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label16" runat="server" Text="Distilled Water"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDistilledWater" class="form-control"   placeholder="Enter Distilled Water" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter Distilled Water" ControlToValidate="txtDistilledWater" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label17" runat="server" Text="Reagent Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtReagentQuantity" class="form-control"   placeholder="Enter Reagent Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Enter Reagent Quantity" ControlToValidate="txtReagentQuantity" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label18" runat="server" Text="Preparation  Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPreparationQuantity" class="form-control"   placeholder="Enter Preparation  Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Enter Preparation  Quantity" ControlToValidate="txtPreparationQuantity" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label19" runat="server" Text="Reagent Lot No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtReagentLotNo" class="form-control"   placeholder="Enter Reagent Lot No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please Enter Reagent Lot No" ControlToValidate="txtReagentLotNo" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label20" runat="server" Text="Others"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOthers" class="form-control"   placeholder="Enter Others" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Please Enter Others" ControlToValidate="txtOthers" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>



                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label5" runat="server" Text="Prepared By "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtPreparedBy" class="form-control"   placeholder="Enter Inspected By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Prepared By" ControlToValidate="txtPreparedBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label6" runat="server" Text="Verified By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtVerifiedBy" class="form-control"   placeholder="Enter Verified By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Verified By" ControlToValidate="txtVerifiedBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>


                  <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label7" runat="server" Text="Approved By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtApprovedBy" class="form-control"   placeholder="Enter Approved By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Approved By" ControlToValidate="txtApprovedBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                   </div><!-- /.form group -->
                  </div>

                   <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click"/> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click"/> &nbsp;                         
                    </div><!-- /.input group -->
                   </div><!-- /.form group -->                        
                  </div>
                </ContentTemplate> 
               </asp:UpdatePanel>
              </div><!-- /.box-body -->            
             </div><!-- /.box -->

          <div id="bx2" class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"> Chemical Reagent And Media Preparations QC List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">

              <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
              <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   
                      <asp:Repeater ID="rpChemicalReagentQC" runat="server" OnItemCommand="rpChemicalReagentQC_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <th>DateTime</th>
                                        <th>PreparedBy</th>
                                        <th>VarifiedBy</th> 
                                        <th>ApprovedBy</th>                                                                       
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <td><%# Eval("ChemicalReagentAndMediaPreparationsQCDate")%></td>
                                        <td><%# Eval("PreparedBy")%></td> 
                                        <td><%# Eval("VarifiedBy")%></td>
                                        <td><%# Eval("ApprovedBy")%></td>
                                                                                
                                       
                                    
                                        
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ChemicalReagentAndMediaPreparationsQCId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>


                                        <th>DateTime</th>
                                        <th>PreparedBy</th>
                                        <th>VarifiedBy</th> 
                                        <th>ApprovedBy</th>                                                                       
                                        <th>Edit</th>

                                      
                                        
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                </asp:Repeater>    
          
                    <asp:HiddenField Id="hId" runat="server" />
                   
                  
                     
                   
                  </table>
             </section>
                
                        </ContentTemplate>
                                              </asp:UpdatePanel>
 </div>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
   </section>
</asp:Content>
