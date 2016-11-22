<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Re-ChilledMilkQc.aspx.cs" Inherits="Dairy.Tabs.Production.Re_ChilledMilkQc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
          <h1>
           Re-chilled Milk QC    
          </h1> 
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Administration</a></li>
            <li class="active">Re-chilledMilkQC</li>
          </ol>
        </section>

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
              <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Re-chilling Details"></asp:Label> </h3>
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
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label1" runat="server" Text="Batch No "></asp:Label>
                      </div>
                       <asp:TextBox ID="txtBatchNO" class="form-control"   placeholder="Batch No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
 

                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                       <i class="fa fa-road"></i><span style="color:red">&nbsp;*</span>--%>
                        <asp:Label ID="lblShift" runat="server" Text="Shift"></asp:Label>

                      </div>
                      <asp:DropDownList ID="dpShiftDetails" class="form-control" DataValueField="ShiftId" DataTextField="Name"   runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->
                         </div>
               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                                        
                          
                      </div> 



                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label12" runat="server" Text="Silo No"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtSiloNo" class="form-control"   placeholder="Silo No" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label2" runat="server" Text="Type Of Milk"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtTypeOfMilk" class="form-control"   placeholder="RCM" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control"   placeholder="Quantity" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label4" runat="server" Text="IBT In Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIBTInTemperature" class="form-control"   placeholder="Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label5" runat="server" Text="IBT Out Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtIBTOutTemperature" class="form-control"   placeholder="Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label6" runat="server" Text="Milk In Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkInTemperature" class="form-control"   placeholder="Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label7" runat="server" Text="Milk Out Temperature"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtMilkOutTemperature" class="form-control"   placeholder="Temperature" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
            </div>
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
<%--                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>--%>
                          <asp:Label ID="Label8" runat="server" Text="Rechilled By"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtRechilledBy" class="form-control"   placeholder="Rechilled By" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->


            </div>
                <div class="col-lg-3 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" onclick="btnAdd_Click"/> &nbsp;      
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click"/> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Save" OnClick="btnRefresh_Click"/> &nbsp;    

                        </div><!-- /.input group -->
                  </div><!-- /.form group -->
               </div> 
           </ContentTemplate> 
        </asp:UpdatePanel>
      </div><!-- /.box-body -->            
    </div><!-- /.box -->


                               <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> Rechilling Data Information List </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpRechilledMilkQC" runat="server" OnItemCommand="rpRechilledMilkQC_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                       <th>Id</th>
                                        <th>Batch No</th>
                                        <th>Shift Name</th>
                                        <th>Date</th>
                                        
                                        <th>Type Of Milk</th>
                                        <th>Quantity</th>
                                        <th>Silo No</th>
                                        <th>IBT In Temperature</th>
                                        <th>IBT Out Temperature</th>
                                        <th>Milk In Temperature </th>
                                        <th>Milk Out Temperature </th>
                                        <th>Rechilled By</th>
                                        <th>Edit</th>

                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                                        <td><%# Eval("Id")%></td>   
                                        <td><%# Eval("BatchNo")%></td>   
                                        <td><%# Eval("ShiftName")%></td>
                                        <td><%# Eval("Date")%></td>     
                                       
                                        <td><%# Eval("TypeOfMilk")%></td>
                                        <td><%# Eval("Qty")%></td>
                                        <td><%# Eval("SiloNo")%></td> 
                                        <td><%# Eval("IBTInTemperature")%></td>
                                        <td><%# Eval("IBTOutTemperature")%></td>                                       
                                        <td><%# Eval("MilkInTemperature")%></td>
                                        <td><%# Eval("MilkOutTemperature")%></td>
                                        <td><%# Eval("RechilledBy")%></td>
                                        
                                      
                                       
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                                        <th>Id</th>
                                        <th>Batch No</th>
                                        <th>Shift Name</th>
                                        <th>Date</th>
                                        
                                        <th>Type Of Milk</th>
                                        <th>Quantity</th>
                                        <th>Silo No</th>
                                        <th>IBT In Temperature</th>
                                        <th>IBT Out Temperature</th>
                                        <th>Milk In Temperature </th>
                                        <th>Milk Out Temperature </th>
                                        <th>Rechilled By</th>
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
   
</asp:Content>
