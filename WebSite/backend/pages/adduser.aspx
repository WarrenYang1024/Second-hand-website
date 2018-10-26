<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="adduser.aspx.cs" Inherits="backend_pages_adduser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Add user / admin account
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                        <tr><td>Username (Max 15)</td><td><input type="text" maxlength="15" class="form-control" name="add_username" id="inputSuccess1"></td></tr>
                                        <tr><td>Password (Max 20)</td><td><input type="text" maxlength="20" class="form-control" name="add_password" id="inputSuccess2"></td></tr>   
                                        <tr><td>Email (Max 25)</td><td><input type="text" maxlength="25" class="form-control" name="add_email" id="inputSuccess3"></td></tr>  
                                        <tr><td>Type</td><td>
                                            <asp:RadioButtonList ID="rdbType" runat="server">
                                                <asp:ListItem Selected="True">user</asp:ListItem>
                                                <asp:ListItem Value="admin"></asp:ListItem>
                                                <asp:ListItem Enabled="False">Author-Warren</asp:ListItem>
                                            </asp:RadioButtonList></td></tr> 
                                        <tr><td></td><td><button type="button" runat="server" onserverclick="Confirm_AddClick" class="btn btn-outline btn-primary btn-lg">Confirm add</button></td></tr>  
                                           
                                 
                                </table>
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-6 -->
</asp:Content>

