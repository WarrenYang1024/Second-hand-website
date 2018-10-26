<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="searchuser.aspx.cs" Inherits="backend_pages_searchuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           
    <div class="col-lg-4 col-md-offset-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            User operation
                        </div>
                        <div class="panel-body">
                            <label>Search</label><input class="form-control" name="s_content">
                            <br />
                             <button type="button" runat="server" onserverclick="Btn_search_Click" class="btn btn-outline btn-primary btn-lg btn-block">Search</button>
                            <br /><hr />
                            <asp:Panel ID="Panel1" runat="server">

                                <div class="form-group">
                                        <label>Username</label><input type="text" name="new_username" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_name %>" >
                                </div>
                                <div class="form-group">
                                         <label>Passowrd</label><input type="text" name="new_password" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_password %>">
                                 </div>
                                <div class="form-group">
                                         <label>Email Address</label><input type="email" name="new_email" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_email %>">
                                 </div>
                                <div class="form-group">
                                         <label>Type</label><input type="text" style="color:darkblue" class="form-control"  required="required" autofocus="autofocus" value="<%=display_type %>" disabled="disabled">
                                 </div>
                                 <button type="button" runat="server" onserverclick="Update_Click" class="btn btn-outline btn-primary btn-lg btn-success btn-block">Update</button>
                                <button type="button"  runat="server" onserverclick="Delete_Click" class="btn btn-outline btn-primary btn-lg btn-danger btn-block">Delete</button>

                            </asp:Panel>
                        </div>
                        <div class="panel-footer">
                            WAPP Resale
                        </div>
                    </div>
              </div>
        
</asp:Content>

