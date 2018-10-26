<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="backend_pages_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row">
            <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Profile</h3>
                    </div>
                    <div class="panel-body">
                        
                            
                                <div class="form-group">
                                    <label>Username</label><input maxlength="15" type="text" name="new_username" class="form-control"  required="required" autofocus="autofocus" value="<%=profile_name %>" >
                                </div>
                                <div class="form-group">
                                    <label>Email Address</label><input maxlength="25" type="text" name="new_email" class="form-control"  required="required" autofocus="autofocus" value="<%=profile_email %>" >
                                </div>
                                <div class="form-group">
                                    <label>Type</label><input type="text"  class="form-control"  required="required" autofocus="autofocus" value="<%=profile_type %>" disabled="disabled">
                                </div>
                                <button type="button" runat="server" onserverclick="Update_profile_Click" class="btn btn-outline btn-success btn-lg btn-block">Confirm</button>
                                
                                
                            
                       </div>
                    </div>
                </div>
            </div>
        </div>
        
</asp:Content>

