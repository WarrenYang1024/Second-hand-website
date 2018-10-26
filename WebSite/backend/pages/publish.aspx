<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="publish.aspx.cs" Inherits="backend_pages_publish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Publish new Item &nbsp;&nbsp;&nbsp;<asp:Label ID="lblvalidation" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr><td>Item name:</td><td><input type="text" maxlength="20" class="form-control" name="item_name"></td></tr>
                                    <tr><td>Description:</td><td><textarea class="form-control" rows="3" name="item_desc"></textarea></td></tr>   
                                    <tr><td>Price (RM):</td><td><input type="text" maxlength="10" class="form-control" name="item_price" onkeyup="value=value.replace(/[^\d{1,}\.\d{1,}|\d{1,}]/g,'')"></td></tr>  
                                    <tr><td>Category:</td><td><asp:RadioButtonList ID="rdbCategory" runat="server">
                                        <asp:ListItem Value="1" Selected="True">Electronic</asp:ListItem>
                                        <asp:ListItem Value="2">Sports</asp:ListItem>
                                        <asp:ListItem Value="3">Fashion</asp:ListItem>
                                        <asp:ListItem Value="4">Other</asp:ListItem>
                                        </asp:RadioButtonList></td></tr>  
                                    <tr><td>Image</td><td><asp:FileUpload ID="Item_upload" runat="server" /></td></tr> 
                                    <tr><td><asp:Label ID="lblwarning" runat="server" Font-Bold="True"></asp:Label></td><td><button type="button" runat="server" onserverclick="Confirm_PublishClick" class="btn btn-outline btn-primary btn-lg">Confirm Publish</button></td></tr>  
                                </table>
                        </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
               
     
</asp:Content>

