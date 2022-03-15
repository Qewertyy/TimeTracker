<%@ Page Language="C#" MasterPageFile="~/TrackingMaster.Master" AutoEventWireup="true" CodeBehind="TimeTracker.aspx.cs" Inherits="EmpTimeTracking.TimeTracker" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="modal-body">
<div id="as" runat="server" visible="true">
<div class="modal-body">
<div class="form-group row">
<div class="col-xl-2">
<label>Employee Name :</label>
<asp:DropDownList ID="dll1" runat="server" Enabled="false" CssClass="form-control,  btn btn-outline-dark" Width="83px"></asp:DropDownList>
</div>&nbsp;&nbsp;
<div class="col-xl-2">
<label>Work :</label>
<asp:TextBox id="tt1" runat="server" CssClass="form-control, btn btn-outline-dark" Width="160px"></asp:TextBox>
</div>&nbsp;&nbsp;
<div class="col-xl-2">
<label>Date :</label>
<asp:TextBox ID="tt2" runat="server" CssClass="form-control, btn btn-outline-dark" Width="160px"></asp:TextBox>
</div>&nbsp;&nbsp;
<div class="col-xl-2">
<label>Status :</label>
<asp:TextBox ID="tt3" runat="server" CssClass="form-control, btn btn-outline-dark" Width="160px"></asp:TextBox>
</div>&nbsp;&nbsp;
<div class="col-xl-2">
<label>Action :</label>
<asp:Button ID="bttn" runat="server" Text="Start" OnClick="bttn_Click" Width="160px" CssClass="form-control, btn btn-outline-dark" />
</div>
</div>
</div>
<div class="table table-active">
<asp:GridView ID="gridview2" runat="server" AutoGenerateColumns="false" Width="100%" RowStyle-HorizontalAlign="Center" OnRowCommand="gridview2_RowCommand" BorderStyle="Ridge" HeaderStyle-HorizontalAlign="Center">
<Columns>
<asp:BoundField DataField="TrackerID" HeaderText="Tracker ID" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="EmpID" HeaderText="User ID" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="Work" HeaderText="Work" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="TimeStart" HeaderText="Time Start" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="TimeStop" HeaderText="Time Stop" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
<asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White"/>
</Columns>
</asp:GridView>
</div>
</div>
<div id="sus" runat="server" visible="false">
<asp:HiddenField Id="ddh" runat="server" Value='<%#Eval("TrackerID")%>'/>
</div>
</div>
</div>
</asp:Content>