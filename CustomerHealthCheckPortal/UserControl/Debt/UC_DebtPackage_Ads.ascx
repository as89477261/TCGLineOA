<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DebtPackage_Ads.ascx.cs" Inherits="CustomerHealthCheck.UserControl.Debt.UC_DebtPackage_Ads" %>

<asp:HiddenField ID="hddEventCode" runat="server"/>
<asp:Literal Text="" ID="ltlDivPadding" runat="server"/>

<%-- <div class='divider my-2 opacity-50' style='background-color: rgba(0, 0, 0, 0.07) !important;'></div>
    <h4 class="mb-0">มาตรการลูกหนี้ บสย. ผ่อนน้อย เบาแรง</h4>
    <asp:Image ImageUrl="~/images/Events/PIC02.jpg" runat="server" Style="width: 100%; border-radius: 20px; padding: 5px;" />
    <span style="font-size: 12px;">** กรุณาลงทะเบียนโครงการประนอมหนี้กับ บสย. ก่อนเข้าร่วมมาตรการ</span>
    <a href='#' id='btnChoosePkgRegisterTopUp' style="margin-bottom: 15px;" class='btn btn-full mx-3 gradient-gray shadow-bg shadow-bg-s disableOnLoading'>กิจกรรมยังไม่เปิดลงทะเบียน</a>--%>


<div class="divider my-2 opacity-50" style="background-color: rgba(0, 0, 0, 0.07) !important;"></div>
<h4 class="mb-0">
    <asp:Literal Text="" ID="ltlEventHeader" runat="server"/>
</h4>

<asp:Panel runat="server" ID="pnlIsBodyIsText" Visible="false">
    <asp:Literal ID="ltlBody" Text="" runat="server"/>
</asp:Panel>

<asp:Panel runat="server" ID="pnlIsBodyIsPicture" Visible="false">
    <asp:Image Style="width: 100%; margin-bottom: 15px; border-radius: 15px;" runat="server" ID="imgImageBody"/>
</asp:Panel>


<asp:Literal Text="" ID="ltlEventCondition" runat="server"/>
<asp:Literal Text="" ID="ltlEventButton" runat="server"/>
