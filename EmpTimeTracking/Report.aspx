<%@ Page Title="" Language="C#" MasterPageFile="~/TrackingMaster.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="EmpTimeTracking.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="modal-body">
            <ajaxToolkit:ToolkitScriptManager ID="atm" runat="server" EnablePageMethods="true"></ajaxToolkit:ToolkitScriptManager>
            <div id="rp" runat="server" visible="true">
                <div class="modal-body">
                    <div class="form-group row">
                        <asp:Label runat="server" ID="namelbl" >Employee Name :</asp:Label>&nbsp;&nbsp;
                        <asp:DropDownList ID="dll2" runat="server" CssClass="form-control,  btn btn-outline-dark" Width="150px"></asp:DropDownList>
                    </div>
                    &nbsp;&nbsp;&nbsp;
                        <div>
                            <label>Select Date :</label>&nbsp;&nbsp;
                        <asp:TextBox ID="tt1" runat="server" CssClass="form-control" Width="170px" OnTextChanged="tt1_TextChanged" AutoPostBack="true" TextMode="Date" autoComplete="off"></asp:TextBox>
                        </div>
                </div>
            </div>
            <div>
                <div class="table table-bordered">
                    <asp:GridView ID="gv22" runat="server" EmptyDataText="No Records Found !" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" AutoGenerateColumns="false" Width="100%" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="TrackerID" HeaderText="Tracker ID" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="EmpID" HeaderText="User ID" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="Work" HeaderText="Work" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="TimeStart" HeaderText="Time Start" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="TimeStop" HeaderText="Time Stop" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-BackColor="#343A40" HeaderStyle-ForeColor="White" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button runat="server" ID="btnpdf" CssClass="btn btn-outline-dark" OnClick="btnpdf_Click" Text="Export In PDF" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnxslx" CssClass="btn btn-outline-dark" OnClick="btnxslx_Click" Text="Export In Excel" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btndocx" CssClass="btn btn-outline-dark" OnClick="btndocx_Click" Text="Export In Word" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
