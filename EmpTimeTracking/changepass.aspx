<%@ Page Title="" Language="C#" MasterPageFile="~/TrackingMaster.Master" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="EmpTimeTracking.changepass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="align-self:center">
    <div class="form-gap"></div>
            <div class="container"><br /><br /><br /><br />
       <div id="login-row" class="row justify-content-center align-items-center">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                            <h3><i class="fa fa-edit fa-4x"></i></h3>
                            <h2 class="text-center">Change Password ?</h2>
                            <p>You Can Change Your Password Here.</p>
                            <div class="panel-body">
                       <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtemail" name="email" placeholder="Email Address" class="form-control"  TextMode="Email"></asp:TextBox>
                            </div>&nbsp;&nbsp;&nbsp;
                           <div class="input-group">
                            <asp:TextBox runat="server" ID="txtpwd" name="password" placeholder="Password" class="form-control"  TextMode="Password"></asp:TextBox>
</div>&nbsp;&nbsp;&nbsp;
                           <div class="input-group">
                               <asp:TextBox runat="server"  ID="txtconfirmpwd1" name="password" placeholder=" Confirm Password" class="form-control"  TextMode="Password"></asp:TextBox>
                               </div>
                           <div>
<asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Requirements Doesn't Match"    
    ControlToValidate="txtpwd" ValidationGroup="cp" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ValidationGroup="cp" ID="RegularExpressionValidator1" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Atleast 6 Character length"  
        ValidationExpression="^.*(?=.{6}).*$"  
        ControlToValidate="txtpwd"></asp:RegularExpressionValidator>
                               <asp:RegularExpressionValidator ValidationGroup="cp" ID="RegularExpressionValidator2" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="<br />Atleast One Upper Case"  
        ValidationExpression="^.*(?=.*[A-Z]).*$"  
        ControlToValidate="txtpwd"></asp:RegularExpressionValidator>  
<asp:RegularExpressionValidator ValidationGroup="cp" ID="RegularExpressionValidator3" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="<br />Atleast One Lower Case"  
        ValidationExpression="^.*(?=.*[a-z])*$"  
        ControlToValidate="txtpwd"></asp:RegularExpressionValidator>  
<asp:RegularExpressionValidator ValidationGroup="cp" ID="RegularExpressionValidator4" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="<br />Atleast One Numeric Value"  
        ValidationExpression="^.*(?=.*[1-9]).*$"  
        ControlToValidate="txtpwd"></asp:RegularExpressionValidator>  
<asp:RegularExpressionValidator ValidationGroup="cp" ID="RegularExpressionValidator5" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="<br />Atleast One Special Character"  
        ValidationExpression="^.*(?=.*[!@#$%^&*]).*$"  
        ControlToValidate="txtpwd"></asp:RegularExpressionValidator>

                               </div>
                        </div>
                                <asp:CompareValidator ValidationGroup="cp" runat="server" ForeColor="SlateGray" ID="CompareValidator1" ControlToCompare="txtpwd" ControlToValidate="txtconfirmpwd1" ErrorMessage="Password Doesn't Match!"></asp:CompareValidator>
                      </div>
                                <div class="form-group">
                                   <label>Show Password</label>
                                  <asp:CheckBox id="chkboxchange" OnCheckedChanged="chkboxchange_CheckedChanged"  AutoPostBack="true" runat="server"/><br />
                      <div class="form-group">
                            <asp:Button runat="server" ID="btnchange" name="change-submit" OnClick="btnchange_Click" ValidationGroup="cp" class="btn btn-lg btn-outline-dark btn-block" Text="Save" value="Change Password" type="submit"/>
                      </div>
                      <div class="form-group">
                            <asp:Button runat="server" Text="Back" class="btn btn-lg btn-outline-dark btn-block" PostBackUrl="~/TimeTracker.aspx" />
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
</asp:Content>
