<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestModel.aspx.cs" Inherits="CustomerHealthController.TestModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <br/>################## Corporate ###################<br/>
    </div>
    <div>
        <asp:RadioButton ID="radioLoanAmount" runat="server" Text="LoanAmount" GroupName="corp"/>
        <asp:TextBox ID="txtLoanAmount" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:RadioButton ID="radioYearIncorporate" runat="server" Text="YearIncorporate" GroupName="corp"/>
        <asp:TextBox ID="txtYearIncorporate" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:RadioButton ID="radioBizProvince" runat="server" Text="BizProvince" GroupName="corp"/>
        <asp:DropDownList ID="ddBizProvince" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:RadioButton ID="radioEstablishmentStatus" runat="server" Text="EstablishmentStatus" GroupName="corp"/>
        <asp:DropDownList ID="ddEstablishmentStatus" runat="server">
            <asp:ListItem Text="เป็นเจ้าของ" Value="0"></asp:ListItem>
            <asp:ListItem Text="เป็นผู้เช่า" Value="1"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:RadioButton ID="radioDebtToIncome" runat="server" Text="DebtToIncome" GroupName="corp"/>
        <asp:TextBox ID="txtDebt" runat="server" placeholder="Debt"></asp:TextBox>
        <asp:TextBox ID="txtIncome" runat="server" placeholder="Income"></asp:TextBox>
    </div>
    <div>
        <asp:RadioButton ID="radioManagementAge" runat="server" Text="ManagementAge" GroupName="corp"/>
        <asp:TextBox ID="txtManagementAge" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnCalCorporate" runat="server" Text="Cal Corporate" OnClick="btnCalCorporate_Click"/>
    </div>
    <div>
        <asp:TextBox ID="txtResult" runat="server" placeholder="score corporate"></asp:TextBox>
    </div>
    <div>
        <br/>################## Personal ###################<br/>
    </div>
    <div>
        <asp:RadioButton ID="radioProvince" runat="server" Text="Province" GroupName="per"/>
        <asp:DropDownList ID="ddProvince" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:RadioButton ID="radioBizType" runat="server" Text="BizType" GroupName="per"/>
        <asp:DropDownList ID="ddBizType" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:RadioButton ID="radioMaritalStatus" runat="server" Text="MaritalStatus" GroupName="per"/>
        <asp:DropDownList ID="ddMaritalStatus" runat="server">
            <asp:ListItem Value="0" Text="กรุณาเลือกสถานะ"></asp:ListItem>
            <asp:ListItem Value="1" Text="โสด"></asp:ListItem>
            <asp:ListItem Value="2" Text="สมรส"></asp:ListItem>
            <asp:ListItem Value="3" Text="หย่าร้าง"></asp:ListItem>
            <asp:ListItem Value="4" Text="หม้าย"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:RadioButton ID="radioLoanAmountPersonal" runat="server" Text="LoanAmountPersonal" GroupName="per"/>
        <asp:TextBox ID="txtLoanAmountPersonal" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:RadioButton ID="radioYearExperience" runat="server" Text="YearExperience" GroupName="per"/>
        <asp:TextBox ID="txtYearExperience" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:RadioButton ID="radioManagementAgePersonal" runat="server" Text="ManagementAgePersonal" GroupName="per"/>
        <asp:TextBox ID="txtManagementAgePersonal" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnCalPersonal" runat="server" Text="Cal Personal" OnClick="btnCalPersonal_Click"/>
    </div>
    <div>
        <asp:TextBox ID="txtResultPersonal" runat="server" placeholder="score personal"></asp:TextBox>
    </div>
</form>
</body>
</html>