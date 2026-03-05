<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MyLgItem.ascx.cs" Inherits="CustomerHealthCheck.UserControl.MyLg.UC_MyLgItem" %>
<div id="Item" runat="server">
    <div class="card card-style m-0 bg-mylg-1 shadow-card shadow-card-m" style="height: 200px; padding: 20px;">
        <div class="card-top p-3">
            <a href="#" data-id="<%= LgNumber %>" data-bs-toggle="offcanvas" data-bs-target="#menu-card-more" 
                class="moremenu icon icon-xxs bg-white color-black float-end">
                <i class="bi bi-three-dots font-18"></i>
            </a>
        </div>
        <div class="card-center">
            <%--            <div class="bg-theme px-3 py-2 rounded-end d-inline-block">
                <h1 class="font-13 my-n1">
                    <a id="TabHeader" class="color-theme" data-bs-toggle="collapse" style="pointer-events: auto;" runat="server">วงเงินค้ำประกัน</a>
                </h1>
                <div class="collapse" id="Tab1">
                    <h2 class="color-theme font-20">
                        <asp:Literal ID="L_Outstanding1" runat="server"/>
                    </h2>
                </div>
            </div>--%>
        </div>
        <strong class="card-top no-click font-12 p-3 color-black font-monospace  ">
            <asp:Literal ID="L_LgNumber1" runat="server" />
        </strong>
        <strong class="card-bottom no-click p-3 font-12 text-star0t color-black font-monospace">
            <asp:Literal ID="L_ProjectTypeName1" runat="server" />
        </strong>
        <div class="card-overlay bg-black opacity-25" style="border: 1px solid silver"></div>
    </div>
    <div class="card" style="margin-top: 20px; border: none; margin-bottom: 20px;">
        <div class="card-body" style="background-color: WhiteSmoke;">
            <h5 style="text-align: left; margin-bottom: 20px !important" class="font-15 mb-0">หนังสือสัญญาค้ำประกัน เลขที่ :
                <asp:Literal ID="L_LgNumber2" runat="server" /></h5>
            <dl style="margin: 0px;">
                <dt>ชื่อผู้กู้ :
                    <asp:Literal ID="L_CustomerName" runat="server" /></dt>
                <dt>ธนาคารสินเชื่อ :
                    <asp:Literal ID="L_BankName" runat="server" /></dt>
                <dt>ผู้กู้ร่วม :
                    <asp:Literal ID="L_IsHaveCustomerJoin" runat="server" /></dt>
                <dt>โครงการ :
                    <asp:Literal ID="L_ProjectTypeName2" runat="server" /></dt>
                <dt>รายละเอียดโครงการ :
                    <asp:Literal ID="L_SubProjectTypeName" runat="server" /></dt>
                <dt>วงเงินคำประกัน :
                    <asp:Literal ID="L_Outstanding2" runat="server" /></dt>
                <dt>วันที่ครบ/สิ้นสุดการค้ำประกัน :
                    <asp:Literal ID="L_LgEndDate" runat="server" /></dt>
            </dl>
        </div>
    </div>

<%--    <button class="carousel-control-prev pe-auto" style="color:grey;z-index:10 !important;max-height:200px;font-size: xx-large;" type="button" data-bs-target="#carouselCardLGNew" data-bs-slide="prev">
        <i class="=bi bi-chevron-compact-left carousel-dark"></i> 
    </button>--%>


<%--    <button class="carousel-control-prev pe-auto" style="color:grey;z-index:10 !important;max-height:200px;font-size: xx-large;" type="button" data-bs-target="#carouselCardLGNew" data-bs-slide="prev">
        <i class="=bi bi-chevron-compact-left carousel-dark"></i> 
    </button>--%>

    <button class="carousel-control-prev pe-auto"
        style="pointer-events: auto !important;"
        type="button"
        data-bs-target="#carouselcardlgnew"
        data-bs-slide="prev">
        <i class="bi bi-chevron-compact-left"></i>
    </button>

    <button class="carousel-control-next pe-auto"
        style="pointer-events: auto !important;"
        type="button"
        data-bs-target="#carouselcardlgnew"
        data-bs-slide="next">
        <i class="bi bi-chevron-compact-right"></i>
    </button>

</div>
