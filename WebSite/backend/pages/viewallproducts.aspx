<%@ Page Title="" Language="C#" MasterPageFile="~/backend/pages/backendMasterPage.master" AutoEventWireup="true" CodeFile="viewallproducts.aspx.cs" Inherits="backend_pages_user_viewproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- User and Admin share one page-->
    <!-- two panels, each panel based on each role-->

    <!-- User panel -->
    <asp:Panel ID="Panel_User" runat="server">
     <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>My products on sale</strong>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                        <tr><!-- row 1 head -->
                                            <th>Product_ID</th>
                                            <th>Product_Name</th>
                                            <th>Description</th>
                                            <th>Price</th>
                                            <th>Category</th>
                                            <th>Buyer</th>
                                        </tr>
                                <%=fetch_Data_onsale() %>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

         <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>My order </strong>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                        <tr><!-- row 1 head -->
                                            <th>Product_ID</th>
                                            <th>Product_Name</th>
                                            <th>Description</th>
                                            <th>Price</th>
                                            <th>Category</th>
                                            <th>Seller</th>
                                        </tr>
                                <%=fetch_Data_purchase() %>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
        </asp:Panel>



    
    <!-- Admin panel-->
    <asp:Panel ID="Panel_Admin" runat="server">
     <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>All products on sale</strong>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                        <tr><!-- row 1 head -->
                                            <th>Product_ID</th>
                                            <th>Product_Name</th>
                                            <th>Description</th>
                                            <th>Price</th>
                                            <th>Seller(Publisher)</th>
                                            <th>Category</th>
                                            <th>Buyer</th>
                                        </tr>
                                <%=Admin_fetch_Data() %>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
        </asp:Panel>

</asp:Content>

