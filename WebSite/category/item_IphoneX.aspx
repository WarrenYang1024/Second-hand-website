<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="item_IphoneX.aspx.cs" Inherits="category_item_IphoneX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 298px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container">

      <div class="row">

        <div class="col-lg-3">

          <h1 class="my-4">Category</h1>
          <div class="list-group">
            <a href="category_e.aspx" class="list-group-item">Electronic</a>
            <a href="category_s.aspx" class="list-group-item">Sports</a>
            <a href="category_f.aspx" class="list-group-item">Fashion</a>
            <a href="category_o.aspx" class="list-group-item">Other</a>
          </div>

        </div>
        <!-- /.col-lg-3 -->

        <!-- Blog Entries Column -->
        <div class="col-md-8">

          <h1 class="my-4">IphoneX
            <small>9.9 New</small>
          </h1>
            <table border="1" class="w-100">
                <tr>
                    <td colspan="2">
                        <asp:Image ID="Image1" runat="server" Height="175px" ImageUrl="~/imgs/iphone.png" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Name</td>
                    <td>IphoneX</td>
                </tr>
                <tr>
                    <td class="auto-style1">Description</td>
                    <td>IphoneX</td>
                </tr>
                <tr>
                    <td class="auto-style1">Price</td>
                    <td>3699.99</td>
                </tr>
                <tr>
                    <td class="auto-style1">Seller</td>
                    <td>joanna</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <button runat="server" onserverclick="Purchase_Click"    class="btn btn-outline btn-primary" type="button">
                            Purchase
                        </button>
                    </td>
                </tr>
            </table>
   </div>
          </div>
    </div>

    
</asp:Content>

