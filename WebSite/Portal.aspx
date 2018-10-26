<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Portal.aspx.cs" Inherits="Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Page Content -->
    <div class="container">

      <!-- Jumbotron Header -->
      <header class="jumbotron my-4">
        <h1 class="display-3">Welcome to WAPP Resale Store!</h1>
        <p class="lead">
WAPP RESALE STORE offers the most valuable items, each of which has been rigorously verified by our organization.</p>
        <a href="#" class="btn btn-primary btn-lg">Call to action!</a>
      </header>

      <!-- Page Features -->
      <div class="row text-center">

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="imgs/iphone.png" alt="">
            <div class="card-body">
              <h4 class="card-title">Electronic</h4>
              <p class="card-text">Here are the most beautiful new or used mobile phones, tablets or related electronic devices, all of which are certified by professional bodies..</p>
            </div>
            <div class="card-footer">
              <a href="./category/category_e.aspx" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="imgs/sport.png" alt="">
            <div class="card-body">
              <h4 class="card-title">Sports</h4>
              <p class="card-text">Sports shoes, sports equipment, professional sports clothes make you more able to show off during sports.</p>
            </div>
            <div class="card-footer">
              <a href="./category/category_s.aspx" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="imgs/fashion.png" alt="">
            <div class="card-body">
              <h4 class="card-title">Fashion</h4>
              <p class="card-text">Brand-name clothes and bags can't afford it? It doesn't matter, try someone else who wants to resell it, it's much cheaper than the new one.</p>
            </div>
            <div class="card-footer">
              <a href="./category/category_f.aspx" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="imgs/other.png" alt="">
            <div class="card-body">
              <h4 class="card-title">Other</h4>
              <p class="card-text">If you still can't find what you want, come here and give it a try. The mess is here.</p>
            </div>
            <div class="card-footer">
              <a href="./category/category_o.aspx" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

      </div>
      <!-- /.row -->

    </div>
    <!-- /.container -->
</asp:Content>

