<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EffluentTreatmentPlant.aspx.cs" Inherits="Dairy.Tabs.Production.EffluentTreatmentPlant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
         <link href="../../Theme/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
        <script src="../../Theme/plugins/jQuery/jquery-1.10.2.min.js"></script>
        <script src="../../Theme/plugins/jQueryUI/jquery-ui.min.js"></script>
        <style type="text/css">.cntrlbtm {    margin-bottom: 1px;} </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
          <h1>
          Effluent Treatment Plant   
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">EffluentTreatmentPlant</li>
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
                   <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Effluent Treatment Plant Details"></asp:Label> </h3>
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
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>                
                          
             

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label1" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
                       <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpShiftDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Shift Detail" >
                         </asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>
                 
                     <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label2" runat="server" Text="Operated By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtOperatedBy" class="form-control"   placeholder="Enter Operated By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Operated By" ControlToValidate="txtOperatedBy" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
              </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label4" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control"   placeholder="Enter Remarks" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Operated By" ControlToValidate="txtRemarks" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label5" runat="server" Text="Collection pump A"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label9" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtAStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
               </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label3" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtAEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label6" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtATotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtATotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>



                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label7" runat="server" Text="Collection pump B"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label8" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label10" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label11" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBTotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             



                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label12" runat="server" Text="AERATOR"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                  </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label13" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAERATORStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtAERATORStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label14" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAERATOREndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtAERATOREndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label15" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtAERATORTotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtAERATORTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label16" runat="server" Text="BLOWER A"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label17" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBLOWERAStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBLOWERAStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label18" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBLOWERAEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBLOWERAEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label19" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBLOWERATotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBLOWERATotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label20" runat="server" Text="BLOWER B"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label21" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBLOWERBStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBLOWERBStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label22" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBLOWERBEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBLOWERBEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group ">
                      <div class="input-group-addon">
                          <asp:Label ID="Label23" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBLOWERBTotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtBLOWERBTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label24" runat="server" Text="Clarifier Mechanism "></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label25" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtClarifierMechanismStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtClarifierMechanismStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label26" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtClarifierMechanismEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtClarifierMechanismEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label27" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtClarifierMechanismTotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtClarifierMechanismTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label28" runat="server" Text="Sludge Re-Circulation pump A"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label29" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSludgeReCirculationpumpAStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtSludgeReCirculationpumpAStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label30" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSludgeReCirculationpumpAEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtSludgeReCirculationpumpAEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label31" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSludgeReCirculationpumpATotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtSludgeReCirculationpumpATotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             

                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                  <div class="input-group-addon">
                  <asp:Label ID="Label32" runat="server" Text="Sludge Re-Circulation pump B"></asp:Label>
                   </div>
                  </div><!-- /.form group -->
                 </div>


                    <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label33" runat="server" Text=" Starting Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSludgeReCirculationpumpBStartingTime" class="form-control" type="time"        placeholder="Starting Time" ToolTip="Enter Starting Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtSludgeReCirculationpumpBStartingTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label34" runat="server" Text="End Time "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSludgeReCirculationpumpBEndTime" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtSludgeReCirculationpumpBEndTime" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
                         
                        
                   <div class="col-lg-3">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label35" runat="server" Text="Total Running Hours"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSludgeReCirculationpumpBTotalHours" class="form-control" type="time"        placeholder="End Time" ToolTip="End Time" runat="server" ></asp:TextBox>        
                    </div><!-- /.input group -->
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="Please Enter Time" ControlToValidate="txtSludgeReCirculationpumpBTotalHours" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                  </div><!-- /.form group -->
                 </div>
             


                <div class="col-lg-3 pull-right">
                  <div class="form-group cntrlbtm">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click" /> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click"/> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                        
                    
                </div>
            </ContentTemplate> 
          </asp:UpdatePanel>
        </div><!-- /.box-body -->            
     </div><!-- /.box -->


          <div id="bx2" class ="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"> Effluent Treatment Plant List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">

                                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpEffluentTreatmentPlant" runat="server" OnItemCommand="rpEffluentTreatmentPlant_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <th>Date</th>
                                        <th>Shift Name</th>
                                        <th>Operated By</th>
                                        <th>Remarks</th>
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <td><%# Eval("EffluentTreatmentPlantDate")%></td>   
                                        <td><%# Eval("ShiftName")%></td>
                                        <td><%# Eval("OperatedBy")%></td>
                                        <td><%# Eval("Remarks")%></td>   
                                         
                                       
                                    
                                        
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("EffluentTreatmentPlantId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>


                                       <th>Date</th>
                                        <th>Shift Name</th>
                                        <th>Operated By</th>
                                        <th>Remarks</th>
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
