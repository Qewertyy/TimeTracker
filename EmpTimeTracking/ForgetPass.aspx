<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="EmpTimeTracking.ForgetPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="align-self:center">
    <div class="form-gap"></div>
            <div class="container"><br /><br /><br /><br />
       <div id="login-row" class="row justify-content-center align-items-center">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                            <h3><i class="fa fa-lock fa-4x"></i></h3>
                            <h2 class="text-center">Forget Password ?</h2>
                            <p>You Can Reset Your Password Here.</p>
                            <div class="panel-body">
                       <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtemail" name="email" placeholder="Email Address" class="form-control"  TextMode="Email"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                            <asp:Button runat="server" ID="btnreset" name="recover-submit" OnClick="btnreset_Click" class="btn btn-lg btn-outline-dark btn-block"  Text="Reset Password" value="Reset Password" type="submit"/>
                      </div>
                      <div class="form-group">
                            <asp:Button runat="server" Text="Back" class="btn btn-lg btn-outline-dark btn-block" PostBackUrl="~/Login.aspx" />
                      </div>
                      <asp:TextBox runat="server" type="hidden" class="hide" name="token" ID="token" value=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            </div>
    </form>
</body>
</html>
