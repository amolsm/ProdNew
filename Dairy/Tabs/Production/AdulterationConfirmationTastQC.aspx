<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdulterationConfirmationTastQC.aspx.cs" Inherits="Dairy.Tabs.Production.AdulterationConfirmationTastQC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
        <h1>
            Adulteration Confirmation Test QC  
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">AdulterationConfirmationTestQC</li>
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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Adulteration Confirmation Test QC"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">

              <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>


                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label14" runat="server" Text="Batch No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNo" class="form-control"   placeholder="Batch No " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                 </div>

        
                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>                
                          
                       

              <div class="col-lg-3">
                  <div class="form-group">
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
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Sugar"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSugar" class="form-control"   placeholder="Enter Sugar" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Product" ControlToValidate="txtProduct" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
               </div>


                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Starch"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtStarch" class="form-control"   placeholder="Enter Starch " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Commodity" ControlToValidate="txtCommodityWise" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="Hydrogen Peroxide"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtHydrogenPeroxide" class="form-control"   placeholder="Enter Hydrogen Peroxide" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
            </div>


                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Neutralizer "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtNeutralizer" class="form-control"   placeholder="Enter Neutralizer " runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group --> 
                  </div><!-- /.form group -->
                 </div>
                  
                   
                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Remarks"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRemarks" class="form-control"   placeholder=" Enter Remarks" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">                    
                        <asp:Label ID="Label4" runat="server" Text="Status"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpStatusDetails" class="form-control" DataValueField="MachineConditionStatusId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>                        
                    </div><!-- /.input group -->
                     <%-- <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" 
                             ValidationGroup="Save" runat="server" ControlToValidate="dpStatusDetails" ForeColor="Red"
                             ErrorMessage="Pls Select Status Detail" >--%>
                        <%-- </asp:RequiredFieldValidator>--%>
                   </div><!-- /.form group -->
                  </div>


                <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click"/> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click"/> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                        
                     
                </div>
            </ContentTemplate> 
          </asp:UpdatePanel>
        </div><!-- /.box-body -->            
     </div><!-- /.box -->


            <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title">  Adulteration Confirmation Test QC List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">

                  <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
              <asp:Repeater ID="rpAdulterationConfirmationTestQC" runat="server" OnItemCommand="rpAdulterationConfirmationTestQC_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                       
                                       <th>Date</th>
                                       <th>Batch No</th>
                                       <th>Shift Name</th>                                                                                                             
                                       <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <%--<td><%# string.IsNullOrEmpty( Eval("RMRDate").ToString())?"":Convert.ToDateTime(Eval("AdulterationConfirmationTestQCDate")).ToString("dd-MM-yyyy")%></td> --%>

                                        <td><%# Eval("AdulterationConfirmationTestQCDate")%></td> 
                                        <td><%# Eval("BatchNo")%></td>    
                                        <td><%# Eval("ShiftName")%></td>
                                                                               
                                       
                                    
                                        
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RMRId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                       <th>Date</th>
                                       <th>Batch No</th>
                                       <th>Shift Name</th>                                                                                                             
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
