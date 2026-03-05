<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndividualSearch.aspx.cs" Inherits="LineOABackend.views.IndividualSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="txtIDCard" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    <br />
    <asp:GridView ID="grdData" runat="server"   AutoGenerateColumns="false">
        <Columns>
           
            <asp:BoundField DataField="personTypeName"
                SortExpression="personTypeName" HeaderText="personTypeName" />

            <asp:BoundField DataField="Name"
                SortExpression="Name" HeaderText="Name" />
            
            <asp:BoundField DataField="Surname"
                SortExpression="Surname" HeaderText="Surname" />

            <asp:BoundField DataField="IdCard"
                SortExpression="IdCard" HeaderText="เลขบัตรประจำตัวประชาชน" />

            <asp:BoundField DataField="Phone"
                SortExpression="Phone" HeaderText="เบอร์โทร" />

            <asp:BoundField DataField="GroupShortDesc"
                SortExpression="GroupShortDesc" HeaderText="สุขภาพการเงิน" />

             <asp:BoundField DataField="StatusName"
                SortExpression="StatusName" HeaderText="StatusName" />

             <asp:BoundField DataField="StatusLevelID"
                SortExpression="StatusLevelID" HeaderText="StatusLevelID" />
            


        </Columns>

        <EmptyDataTemplate>
            There are currently no items in this table.
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FooterScript" runat="server">
</asp:Content>
