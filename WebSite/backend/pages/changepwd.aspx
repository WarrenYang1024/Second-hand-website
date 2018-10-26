<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="backend_pages_changepwd" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row">
            <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Change Password</h3>
                    </div>
                    <div class="panel-body">
                        
                            
                                <div class="form-group">
                                    <input type="password" name="newpwd1" class="form-control" placeholder="New password" required="required" autofocus="autofocus">
                                </div>
                                <div class="form-group">
                                    <input type="password" name="newpwd2" class="form-control" placeholder="Retype password" required="required" autofocus="autofocus" >
                                </div>
                               
                                <!-- Change this to a button or input when using this as a form -->
                                <a href="index.html" class="btn btn-lg btn-success btn-block" runat="server" onserverclick="Change_Click">Login</a>
                            
                       </div>
                    </div>
                </div>
            </div>
        </div>
  
</asp:Content>

