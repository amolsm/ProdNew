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
           Personal Hygiene CheckList QC   
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
                   <h3 class="box-title"><asp:Label ID="lblHeaderTab" runat="server" Text="Personal Hygiene CheckList QC Details"></asp:Label> </h3>
                   <div class="box-tools pull-right">
                   <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
                   </div>
                   </div>
                 <div class="box-body">

                               <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
              <ContentTemplate>
        
              

              <div class="col-lg-4">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                      </div>
                       <asp:TextBox ID="txtDate" class="form-control" type="date" runat="server" ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                </div>                
                          

                     <div class="col-lg-4">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label2" runat="server" Text="Employee Name"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpEmployee"  class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                     <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Employee Name" ControlToValidate="txtEmployeeName" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
            </div>



                   <div class="col-lg-4">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:Label ID="Label1" runat="server" Text="Designation Name"></asp:Label>
                      </div>
                      <asp:DropDownList ID="dpDesignation"  class="form-control" DataTextField="Name" DataValueField="employeeID" runat="server"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->
                     <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Employee Name" ControlToValidate="txtEmployeeName" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
                   </div>

                         
             
              <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:CheckBox ID="chkUniform" runat="server" />
                      </div>
                       <asp:TextBox ID="txtUniformCleaning" class="form-control"   placeholder="Uniform Clean" runat="server" disabled></asp:TextBox>                        
                    </div><!-- /.input group -->
                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Uniform Cleaning" ControlToValidate="txtUniformCleaning" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
               </div>
                  

               <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:CheckBox ID="chkNail" runat="server" />
                      </div>
                       <asp:TextBox ID="txtNail" class="form-control"   placeholder="Enter Nail" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group --> 
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Pls Enter Nail"  ControlToValidate="txtNail" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
                 </div>

                  
                <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:CheckBox ID="chkCap" runat="server" />
                      </div>
                       <asp:TextBox ID="txtCap" class="form-control"   placeholder=" Enter Cap" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pls Enter Cap"  ControlToValidate="txtCap" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
                  </div>


                   <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                           <asp:CheckBox ID="chkApronLab" runat="server" />
                      </div>
                       <asp:TextBox ID="txtApronLab" class="form-control"   placeholder="Enter Apron Lab" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Apron Lab" ControlToValidate="txtApronLab" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
              </div>

                  
                <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                           <asp:CheckBox ID="chkBeardCrimp" runat="server" />
                      </div>
                       <asp:TextBox ID="txtBeardCrimp" class="form-control"   placeholder="Enter Beard Crimp" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Beard Crimp" ControlToValidate="txtBeardCrimp" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
            </div>


                    <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                          <asp:CheckBox ID="chkHandGloves" runat="server" />
                      </div>
                       <asp:TextBox ID="txtHandGloves" class="form-control"   placeholder="Enter Hand Gloves" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Hand Gloves" ControlToValidate="txtHandGloves" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
                </div>

             
                <div class="col-lg-3">
                  <div class="form-group ">
                    <div class="input-group">
                      <div class="input-group-addon">
                           <asp:CheckBox ID="chkMask" runat="server" />
                      </div>
                       <asp:TextBox ID="txtMask" class="form-control"   placeholder="Enter Mask" runat="server" disabled ></asp:TextBox>                        
                    </div><!-- /.input group -->
<%--                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Mask" ControlToValidate="txtMask" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                  </div><!-- /.form group -->
                </div>



                <div class="col-lg-3 pull-right">
                  <div class="form-group ">
                    <div class="input-group">
                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAdd_Click1"/> &nbsp;    
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnUpdate_Click1" /> &nbsp;    
                        <asp:Button ID="btnRefresh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Refresh" ValidationGroup="Refresh" OnClick="btnRefresh_Click1"/> &nbsp;                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                        
                     

                </div>
            </ContentTemplate> 
          </asp:UpdatePanel>
       </div><!-- /.box-body -->            
     </div><!-- /.box -->


         <div id="bx2" class="box collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title"> Personal Hygiene CheckList QC Details </h3>
              <div class="box-tools pull-right" style="right: 4px; top: 4px">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">

             <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
              <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 
                      <asp:Repeater ID="rpPersonalHygieneCheckListQC" runat="server" OnItemCommand="rpPersonalHygieneCheckListQC_ItemCommand">
                
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                                        <th>DateTime</th>
                                        <th>Employee Name</th>
                                        <th>Designation Of Emp</th>                        
                                        <th>Uniform Cleaning</th>
                                        <th>Nail</th>
                                        <th>Cap</th>
                                        <th>Apron Lab</th>
                                        <th>Beard Crimp</th>
                                        <th>Hand Gloves</th>
                                        <th> Mask </th>
                                        <th>Edit</th>


                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                            
                                        <td><%# Eval("PersonalHygieneCheckListQCDate")%></td>
                                        <td><%# Eval("EmployeeName")%></td>   
                                        <td><%# Eval("Designation")%></td>   
                                        <td><%# Eval("UniformCleaning")%></td>
                                        <td><%# Eval("Nail")%></td>  
                                        <td><%# Eval("Cap")%></td>   
                                        <td><%# Eval("ApronLab")%></td>   
                                        <td><%# Eval("BeardCrimp")%></td>
                                        <td><%# Eval("HandGloves")%></td>
                                        <td><%# Eval("Mask")%></td>
                                       
                                    
                                        
                                          
                         <td>
                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" onItemCommand="lblEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("PersonalHygieneCheckListQCId") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         



                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>

                                        <th>DateTime</th>
                                        <th>Employee Name</th>
                                        <th>Designation Of Emp</th>                        
                                        <th>Uniform Cleaning</th>
                                        <th>Nail</th>
                                        <th>Cap</th>
                                        <th>Apron Lab</th>
                                        <th>Beard Crimp</th>
                                        <th>Hand Gloves</th>
                                        <th> Mask </th>
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
