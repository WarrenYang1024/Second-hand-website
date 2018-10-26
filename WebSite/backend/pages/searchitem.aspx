<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="searchitem.aspx.cs" Inherits="backend_pages_searchitem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Search item&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_result" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr><td>Item name:</td><td><input type="text" maxlength="15" class="form-control" name="item_name"></td><td><button type="button" class="btn btn-outline btn-primary" runat="server" onserverclick="Search_Click">Search Item!</button></td></tr>
                                </table>
                                <asp:Panel ID="Panel_display" runat="server">
                                    <table class="table table-striped table-bordered table-hover">
                                        <tr><td>Item name:</td><td><input type="text" name="new_item_name" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_item_name %>" ></td></tr>
                                        <tr><td>Item description:</td><td><input type="text" name="new_item_desc" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_desc %>" ></td></tr>
                                        <tr><td>Item price :</td><td><input type="text" name="new_item_price" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_price %>" ></td></tr>
                                        <tr><td>Item Category:</td><td><asp:RadioButtonList ID="rdb_category" runat="server">
                                            <asp:ListItem Value="1">Electronic</asp:ListItem>
                                            <asp:ListItem Value="2">Sports</asp:ListItem>
                                            <asp:ListItem Value="3">Fashion</asp:ListItem>
                                            <asp:ListItem Value="4">Other</asp:ListItem>
                                            </asp:RadioButtonList></td></tr>
                                        <tr><td>Item image:</td><td><asp:Image ID="Img_display" runat="server" Width="300px" Height="175px" /></td></tr>
                                        <tr><td></td><td><button type="button" id="btn_update" runat="server" onserverclick="Update_item_Click" class="btn btn-outline btn-success btn-lg btn-block">Update</button></td></tr>
                                        <tr><td></td><td><button type="button"  id="btn_delete" runat="server" onserverclick="Delete_item_Click" class="btn btn-outline btn-primary btn-lg btn-danger btn-block">Delete</button></td></tr>
                                    </table>
                                </asp:Panel>
                        </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
</asp:Content>

