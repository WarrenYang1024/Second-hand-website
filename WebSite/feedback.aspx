<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Feedback</h1>
    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Leehanming</h4>
                <p class="card-text">hello good weisite</p>
        </div>
        <div class="card-footer">
              2010/01/01
        </div>
    </div>
 <%=fetchData() %>

    <hr />
     <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <div class="card-body">
              <h4 class="card-title">Leave your message here:</h4>
              <p class="card-text">
                  <textarea id="txt_message" runat="server" cols="40" rows="2"></textarea><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_message" ErrorMessage="Please enter message!" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
            </div>
            <div class="card-footer">
              <a href="#" runat="server" onserverclick="Submit_message_Click" class="btn btn-primary">Submit!</a>
            </div>
          </div>
        </div>


        
</asp:Content>

