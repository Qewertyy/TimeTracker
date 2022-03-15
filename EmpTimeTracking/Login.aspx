<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmpTimeTracking.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/popper.min.js"></script>
<script src="scripts/bootstrap.bundle.min.js"></script>
   
    <style>
        .card{
            padding-left:40px;
            padding-right:40px;
        }
    </style>
</head>
   
<body>
<form id="form1" runat="server">
<div id="login">
<h2 class="text-center text-black pt-5">Time Tracker</h2>&nbsp;
<div id="login-row" class="row justify-content-center align-items-center">
<div id="login-column" class="col-md-6">
<div id="login-box" class="col-md-12">
<h4 class="text-center text-black ">Login</h4>&nbsp;
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
<asp:CheckBox id="chkbox" OnCheckedChanged="chkbox_CheckedChanged" AutoPostBack="true" runat="server"/><br />
<asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" CssClass="btn btn-outline-dark btn-md" />
</div>
<div id="register-link" class="text-right">
<a href="ForgetPass.aspx" class="text-black">Forget Password?</a>
</div>
</div>
</div>
</div>
</div>
</form>
</body>
</html>

