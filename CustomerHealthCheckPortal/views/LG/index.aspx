<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.LG.index" %>

<%@ Register Src="~/UserControl/MyLg/UC_MyLgItem.ascx" TagPrefix="uc1" TagName="UC_MyLgItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - My LG</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Wrapper-->
    <div id="page">

        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear">
            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center">
                        <a href="#" onclick="redirectToMain()"
                            class="me-3 ms-0 icon icon-xxs bg-theme rounded-s shadow-m">
                            <i class="bi bi-chevron-left color-theme font-14"></i>
                        </a>
                    </div>
                    <div class="align-self-center me-auto">
                        <h1 class="color-theme mb-0 font-18">ย้อนกลับ </h1>
                    </div>
                </div>

            </div>
            <!-- Page Background ! -->
            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>

            <div class="pt-3">
                <!-- Page Title Header -->
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <h2 class="color-white" style="color: #092d74 !important;">รายการ LG</h2>
                    </div>
                </div>

                <!-- Detail Short LG  -->
                <div class="card card-style">
                    <div class="content mb-0">
                        <div class="tabs tabs-pill" id="tab-group-2">
                            <div id="carouselCardLGNew" class="carousel slide pointer-event" data-bs-ride="carousel" runat="server">

                                <asp:Panel runat="server" ID="pnlMyLGWaitingItemA" class="carousel-inner">

                                    <asp:Repeater ID="RepeaterMyLg" runat="server" OnItemDataBound="RepeaterMyLg_ItemDataBound">
                                        <ItemTemplate>
                                            <uc1:UC_MyLgItem runat="server" ID="UC_MyLgItem1" Index="<%# Container.ItemIndex %>" />
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </asp:Panel>

                                <div id="menu-card-more" class="offcanvas offcanvas-bottom offcanvas-detached rounded-m" style="display: block; visibility: hidden; height: auto">
                                    <div class="menu-size">
                                        <div class="d-flex mx-3 mt-3 py-1">
                                            <div class="align-self-center">
                                                <h1 class="mb-0">รายละเอียดเพิ่มเติม</h1>
                                            </div>
                                            <div class="align-self-center ms-auto">
                                                <a href="#" class="py-3 ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                                                    <i class="bi bi-x color-red-dark font-26"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="p-3 pt-2 list-group list-custom list-group-m list-group-flush">

                                            <div id="payment" data-bs-toggle="offcanvas" data-bs-target="#menu-transfer" class="list-group-item">
                                                <i class="has-bg gradient-blue color-white shadow-bg shadow-bg-xs rounded-xs bi bi-pass"></i>
                                                <div style="padding-left: 15px;">
                                                    <strong class="font-600 font-14">รายการชำระเงิน</strong>
                                                </div>
                                                <i class="bi bi-chevron-right"></i>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="carousel-inner">
                                    <asp:Panel runat="server" ID="pnlMyLGTabItemA" class="carousel-indicators" Style="margin-top: 20px; position: relative; filter: brightness(0);">

                                        <asp:Repeater ID="RepeaterBtnLgCard" runat="server" OnItemDataBound="RepeaterBtnLgCard_ItemDataBound">
                                            <ItemTemplate>
                                                <button id="btnLgCard" runat="server" type="button" clientidmode="Static"
                                                    data-bs-target="#carouselCardLGNew" data-bs-slide-to="<%# Container.ItemIndex %>"
                                                    aria-current="true" aria-label="<%# Container.ItemIndex %>">
                                                </button>
                                            </ItemTemplate>
                                        </asp:Repeater>


                                    </asp:Panel>
                                
                                <asp:Panel runat="server" ID="pnlEmptyWaitingItemA" Style="text-align: center; margin: 10px;" Visible="true">

                                    <label style="font-size: 20px;">ไม่พบรายการ หนังสือค้ำประกัน</label>

                                </asp:Panel>

                                    </div>
                                <%--</div>--%>
                            </div>

                            <div id="pnlMockupLG" runat="server">
                                <div id="carouselCardLGNew1" class="carousel slide pointer-event">

                                    <div id="MockColusal" class="carousel-inner ">

                                        <div id="MockMyLgItem1_0_Item_0" class="carousel-item active">
                                            <div class="card card-style m-0 bg-mylg-1 shadow-card shadow-card-m" style="height: 200px; padding: 20px;">
                                                <div class="card-top p-3">
                                                    <a href="#" data-id="61027452" data-bs-toggle="offcanvas" data-bs-target="#menu-card-more" class="moremenu icon icon-xxs bg-white color-black float-end">
                                                        <i class="bi bi-three-dots font-18"></i>
                                                    </a>
                                                </div>
                                                <div class="card-center">
                                                </div>
                                                <strong class="card-top no-click font-12 p-3 color-black font-monospace  ">61027452
                                                </strong>
                                                <strong class="card-bottom no-click p-3 font-12 text-star0t color-black font-monospace">Micro Entrepreneurs ระยะที่ 2
                                                </strong>
                                                <div class="card-overlay bg-black opacity-25" style="border: 1px solid silver"></div>
                                            </div>
                                            <div class="card " style="margin-top: 20px; border: none; margin-bottom: 20px;">
                                                <div class="card-body" style="background-color: WhiteSmoke;">
                                                    <h5 style="text-align: left; margin-bottom: 20px !important" class="font-15 mb-0">หนังสือสัญญาค้ำประกัน เลขที่: 6102xxxx</h5>
                                                    <dl style="margin: 0px;">
                                                        <dt>ชื่อผู้กู้ :
                    นางสาวบี้หร้า กองข้าวเรียบ</dt>
                                                        <dt>ธนาคารสินเชื่อ :
                    ธนาคารออมสิน</dt>
                                                        <dt>ผู้กู้ร่วม :
                    -</dt>
                                                        <dt>โครงการ :
                    Micro Entrepreneurs ระยะที่ 2</dt>
                                                        <dt>รายละเอียดโครงการ :
                    รอบ 3 Micro Entrepreneurs</dt>
                                                        <dt>วงเงินคำประกัน :
                    50000.00 บาท</dt>
                                                        <dt>วันที่ครบ/สิ้นสุดการค้ำประกัน :
                    21/03/2021</dt>
                                                    </dl>
                                                </div>
                                            </div>
                                            <button class="carousel-control-prev" style="color: grey; z-index: 0; max-height: 200px; font-size: xx-large;"
                                                type="button" data-bs-target="#carouselCardLGNew" data-bs-slide="prev">
                                                <i class="bi bi-chevron-compact-left"></i>

                                            </button>
                                            <button class="carousel-control-next" style="color: grey; z-index: 0; max-height: 200px; font-size: xx-large; text-align: start;"
                                                type="button" data-bs-target="#carouselCardLGNew" data-bs-slide="next">
                                                <i class="bi bi-chevron-compact-right"></i>

                                            </button>
                                        </div>

                                    </div>

                                    <div id="menu-card-more1" class="offcanvas offcanvas-bottom offcanvas-detached rounded-m"
                                        style="display: block; visibility: hidden; height: auto">
                                        <div class="menu-size">
                                            <div class="d-flex mx-3 mt-3 py-1">
                                                <div class="align-self-center">
                                                    <h1 class="mb-0">รายละเอียดเพิ่มเติม</h1>
                                                </div>
                                                <div class="align-self-center ms-auto">
                                                    <a href="#" class="py-3 ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                                                        <i class="bi bi-x color-red-dark font-26"></i>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="p-3 pt-2 list-group list-custom list-group-m list-group-flush">

                                                <div id="payment1" data-bs-toggle="offcanvas" data-bs-target="#menu-transfer" class="list-group-item">
                                                    <i class="has-bg gradient-blue color-white shadow-bg shadow-bg-xs rounded-xs bi bi-pass"></i>
                                                    <div style="padding-left: 15px;">
                                                        <strong class="font-600 font-14">รายการชำระเงิน</strong>
                                                    </div>
                                                    <i class="bi bi-chevron-right"></i>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <div id="MockpnlMyLGTabItemA" class="carousel-indicators" style="margin-top: 20px; position: relative; filter: brightness(0);">

                                        <button id="MockRepeaterBtnLgCard_btnLgCard_0" type="button" data-bs-target="#carouselCardLGNew" aria-current="true"
                                            aria-label="Slide" data-bs-slide-to="0" class="active">
                                        </button>

                                    </div>
                                </div>
                            </div>

                            <div class="" style="background-color: lightslategray"></div>

                        </div>
                    </div>

                </div>
            </div>

        </div>

    </div>
    <!-- End of Page Content-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">

    <script src="<%= ResolveClientUrl("~/scripts/Page/MyLG.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

</asp:Content>
