<%--<%@ Page Title="" Language="C#" MasterPageFile="~/TrackingMaster.Master" AutoEventWireup="true" CodeBehind="Loginn.aspx.cs" Inherits="EmpTimeTracking.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css"/>
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="login">
<h3 class="text-center text-white pt-5">Login form</h3>
<div class="container">
<div id="login-row" class="row justify-content-center align-items-center">
<div id="login-column" class="col-md-6">
<div id="login-box" class="col-md-12">
<h3 class="text-center text-black ">Login</h3>&nbsp;<h5 class="text-center text-black">Login From Here To Access The Time Tracker</h5>&nbsp;
<div class="form-group">
<label for="username" class="text-black">E-Mail Address</label><br/>
<asp:TextBox runat="server"  type="text" name="username" id="txtEmail" TextMode="Email" class="form-control" />
</div>
<div class="form-group">
<label for="password" class="text-black">Password</label><br/>
<asp:TextBox runat="server" type="text" name="Password" TextMode="Password" id="txtPwd" class="form-control" />
</div>
<div class="form-group">
<label>Show Password</label>
<asp:CheckBox id="chkbox" Checked="false" OnCheckedChanged="chkbox_CheckedChanged" runat="server"/><br />
<asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" CssClass="btn btn-outline-dark btn-md" />
</div>
<div id="register-link" class="text-right">
<a href="#" class="text-black">Forget Password?</a>
</div>
</div>
</div>
</div>
</div>
</div>
</asp:Content>--%>