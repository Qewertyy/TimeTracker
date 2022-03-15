<%@ Page Title="" Language="C#" MasterPageFile="~/TrackingMaster.Master" AutoEventWireup="true" CodeBehind="EmpMaster.aspx.cs" Inherits="EmpTimeTracking.EmpMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="scriptmanager" ScriptMode="Auto" runat="server"></ajaxToolkit:ToolkitScriptManager>
<div class="modal-body">
<div class="table table-bordered">
<div id="sa" runat="server" visible="true">
<p><asp:Button runat="server" OnClick="ADD_Click" ID="ADD" Text="Add Employee" cssclass="btn btn-outline-dark"/></p>
<asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false" Width="100%" RowStyle-HorizontalAlign="Center" OnRowCommand="gridview1_RowCommand" HeaderStyle-HorizontalAlign="Center">
<Columns>
<asp:BoundField DataField="EmpID" HeaderText="Employee ID" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="EmpName" HeaderText="Employee Name" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="Empsall" HeaderText="Employee Salary" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="EmpDOJ" HeaderText="Employee Date Of Join" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="EmpDOR" HeaderText="Employee Date Of Resigned" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="Email" HeaderText="Email Address" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="Role" HeaderText="Role" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" ControlStyle-BorderStyle="Dashed"/>
<asp:TemplateField  HeaderText="Action" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" >
<ItemTemplate>
<asp:Button runat="server" ID="BtnEdit" Text="Edit"  CommandName="RowEdit" CommandArgument='<%#Eval("EmpID")%>' CssClass="btn btn-outline-dark"/>
<asp:Button runat="server" ID="BtnDelete" Text="Delete" OnClientClick="return confirm('Are You Sure That You Want To Delete The Record!!')" CommandName="RowDelete" CommandArgument='<%#Eval("EmpID")%>' CssClass="btn btn-outline-dark"/>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</div>
</div>
<div id="sas" class="form-group" runat="server" visible="false">
<asp:HiddenField Id="hdd" runat="server" Value='<%#Eval("EmpID")%>'/>
    <div class="container">
        <div class="form-group">
<table>
<tr>
<td>
<p><label>Employee Name :</label></p>
<p><asp:TextBox ID="tb1" runat="server" CssClass="form-control" ></asp:TextBox></p>
</td>
</tr>
<tr>
<td>
<p><label>Employee Salary :</label></p>
    <ajaxToolkit:FilteredTextBoxExtender ID="filterextend" FilterType="Custom" ValidChars="0123456789." ValidateRequestMode="Enabled" runat="server" TargetControlID="tb2"></ajaxToolkit:FilteredTextBoxExtender>
<p><asp:TextBox ID="tb2" runat="server"  placeholder="000000.00" CssClass="form-control"></asp:TextBox></p>
</td>
</tr>
<tr>
<td>
<p><label>Employee Date Of Join :</label></p>
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Custom" ValidChars="1234567890/" ValidateRequestMode="Enabled" runat="server" TargetControlID="tb3"></ajaxToolkit:FilteredTextBoxExtender>
<p><asp:TextBox ID="tb3" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control" ></asp:TextBox></p>
</td>
</tr>

<tr>
<td>
<p> <label>Employee Date Of Resigned :</label></p>
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="Custom" ValidChars="0123456789/" ValidateRequestMode="Enabled" runat="server" TargetControlID="tb4"></ajaxToolkit:FilteredTextBoxExtender>
<p><asp:TextBox ID="tb4" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control"></asp:TextBox></p>
</td>
</tr>
<tr>
<td>
<p> <label>Email Address :</label></p>
<p><asp:TextBox ID="tb5" runat="server" TextMode="Email" placeholder="Someone@gmail.com" CssClass="form-control"></asp:TextBox></p>
</td>
</tr>
<tr>
<td>
<p> <label>Role :</label></p>
<p><asp:TextBox ID="tb6" runat="server" placeholder="User" CssClass="form-control"></asp:TextBox></p>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnsave"  OnClick="btnsave_Click" Text="Save" runat="server"  CssClass="btn btn-outline-dark"/>
</td>
<td>
<asp:Button ID="btnback" Text="Back" runat="server" OnClick="btnback_Click" CssClass="btn btn-outline-dark"/>
</td>
</tr>
</table>
            </div>
        </div>
</div>    
</div>
</asp:Content>

  