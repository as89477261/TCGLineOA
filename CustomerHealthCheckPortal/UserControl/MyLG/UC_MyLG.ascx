<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MyLG.ascx.cs" Inherits="CustomerHealthCheck.UserControl.MyLG.UC_MyLG" %>


<div class="splide__slide">
    <div class="card card-style m-0 bg-5 shadow-card shadow-card-m" style="height: 200px">
        <div class="card-top p-3">
        </div>
        <div class="card-center">
            <div class="bg-theme px-3 py-2 rounded-end d-inline-block">
                <h1 class="font-13 my-n1">
                    <a class="color-theme" data-bs-toggle="collapse" href="#balance3" aria-controls="balance2">ดูยอดการคํ้า</a>
                </h1>
                <div class="collapse" id="balance3">
                    <h2 class="color-theme font-26">
                        <asp:Literal Text="" ID="ltlLGGuaranteePrice" runat="server" />
                </div>
            </div>
        </div>
        <strong class="card-top no-click font-12 p-3 color-white font-monospace">
            <asp:Literal Text="" ID="ltlLGNumber" runat="server" /></strong>
        <strong class="card-bottom no-click p-3 text-start color-white font-monospace">วันเริ่มต้น :
            <asp:Literal Text="" ID="ltlLGStartDate" runat="server" /></strong>
        <strong class="card-bottom no-click p-3 text-end color-white font-monospace">วันที่สิ้นสุด :
            <asp:Literal Text="" ID="ltlLGEndDate" runat="server" /></strong>
        <div class="card-overlay bg-black opacity-50"></div>
    </div>
</div>
