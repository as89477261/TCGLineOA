<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - Main Menu</title>
    <style>
        .sme-floating-btn {
            position: fixed;
            right: 0;
            top: 50%;
            transform: translateY(-50%);
            z-index: 9999;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            background: linear-gradient(to bottom, #4e8cff, #2563eb);
            color: #fff;
            text-decoration: none;
            padding: 14px 10px;
            border-radius: 16px 0 0 16px;
            box-shadow: -3px 0 12px rgba(37,99,235,0.45);
            gap: 6px;
            min-width: 52px;
            transition: padding 0.2s;
        }
        .sme-floating-btn:hover,
        .sme-floating-btn:active {
            color: #fff;
            text-decoration: none;
            padding-right: 14px;
        }
        .sme-floating-btn i {
            font-size: 26px;
            display: block;
        }
        .sme-floating-btn .sme-label {
            writing-mode: vertical-rl;
            text-orientation: mixed;
            transform: rotate(180deg);
            font-size: 12px;
            font-weight: 700;
            line-height: 1.3;
            letter-spacing: 0.5px;
            white-space: nowrap;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hddHomeUrl" ClientIDMode="Static" />
    <asp:HiddenField ID="hddIshaveProfile" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddBannerEvent1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddBannerEvent2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddContactDoctor" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddSetThailandURL" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddPROMKHUMShow" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddLToken" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddSMEsPickUpShow" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddSMEsStimulateCampaignShow" runat="server" ClientIDMode="Static" />
    <div id="preloader">
        <div class="spinner-border color-highlight" role="status"></div>
    </div>

    <!-- Page Wrapper-->
    <div id="page">

        <!-- Footer Bar -->
        <div id="footer-bar" class="footer-bar-1 footer-bar-detached">
            <asp:HyperLink ID="btnToActivity" NavigateUrl="~/views/Activity/index.aspx" runat="server"><i class="bi bi-journal-text"></i><span>ประวัติทำรายการ</span></asp:HyperLink>
            <asp:HyperLink ID="btnToHome" NavigateUrl="~/index.aspx" runat="server" class="circle-nav-2"><i class="bi bi-house-fill"></i><span>หน้าหลัก</span></asp:HyperLink>
            <asp:HyperLink ID="btnToProfile" NavigateUrl="~/views/Profile/index.aspx" runat="server"><i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span></asp:HyperLink>
        </div>

        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear">

            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <!--<p class="color-white opacity-80 header-date"></p>-->
                        <asp:Image ImageUrl="~/images/logos/Logo.png" runat="server" Style="height: 80px; float: left;" />
                        <asp:Image ImageUrl="~/images/logos/FF.png" runat="server" Style="height: 95px; padding: 10px; max-width: 300px; margin: 0 auto; position: absolute;" />
                        <%-- <h1 class="color-white" style="position: absolute; top: 30px; left: 85px; color: #092d74 !important;">ยินดีต้อนรับ</h1>--%>
                    </div>

                </div>
                <asp:Label ID="lblUID1" Text="" runat="server" Visible="false" />
            </div>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>

            <div class="card card-style" style="text-align: center;" runat="server" id="pnlTestCommand" visible="false">
                <asp:Button Text="Reset" ID="btnReset" CssClass="btn btn-primary" OnClick="btnReset_Click" runat="server" Visible="true" />
            </div>

            <!--Account Activity Notification-->
            <div class="card card-style shadow-bg shadow-bg-s color-blue" style="display: none;">
                <div class="content">

                    <a href="#" onclick="redirectToHealthCheck()" class="d-flex ">
                        <div class="align-self-center">
                            <h1 class="mb-0 font-40"><i class="bi bi-patch-question pe-3" style="color: #092d74 !important;"></i></h1>
                        </div>
                        <div class="align-self-center">
                            <h5 class=" font-700 mb-0 mt-0 pt-1 " style="color: #092d74 !important;">ตรวจสุขภาพทางการเงินกับ บสย
                               
                            </h5>
                            <label style="font-size: 11px;">(ไม่มีผลต่อการพิจารณาคํ้าประกันสินเชื่อของ บสย)</label>
                        </div>
                        <div class="align-self-center ms-auto">
                            <i class="bi bi-arrow-right-short color-white d-block pt-1 font-20 opacity-50"></i>
                        </div>
                    </a>

                </div>
            </div>

            <div class="content my-0 mt-n2 px-1">
                <div class="d-flex">
                    <div class="align-self-center">
                        <h3 class="font-16 mb-2 color-black">บริการ บสย.</h3>
                    </div>
                </div>
            </div>


            <div class="card card-style" style="margin-bottom: 15px; display: block;">
                <div class="splide quad-slider slider-no-dots slider-no-arrows slider-visible text-center  splide--ltr splide--draggable is-active mt-2 me-1"
                    id="double-slider-2" style="visibility: visible;">
                    <div class="splide__track" id="double-slider-2-track">
                        <div class="splide__list ms-2" id="double-slider-2-list" style="transform: translateX(-670px);">

                            <asp:Repeater ID="rptServiceMenu" runat="server">
                                <ItemTemplate>
                                    <div class="splide__slide splide__slide--clone cursor-pointer"
                                        style="width: 68px;"
                                        onclick="<%# Eval("ClickAction") %>"
                                        visible="<%# Eval("IsVisible") %>">

                                        <div href="#" data-card-height="68" data-bs-toggle="offcanvas" data-bs-target="#menu-friends-transfer"
                                            class="<%# Eval("IconCssClass") %>"
                                            style="height: 68px; font-size: 30px;">
                                        </div>
                                        <div class="pt-2 font-10">
                                            <%# Eval("Title") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                    <ul class="splide__pagination">
                        <li>
                            <button class="splide__pagination__page is-active" type="button" aria-current="true"
                                aria-controls="pnlRegisterWithTCGDBIcon pnlCheckRequestStatusMenuIcon pnlCheckMyLGStatusMenuIcon"
                                aria-label="Go to page 1">
                            </button>
                        </li>
                    </ul>
                </div>
            </div>

            <!-- SME มีดวง floating button (moved to fixed position) -->





            <div class="card card-style" style="margin-bottom: 30px;">
                <div class="content">

                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs overflow-visible">

                        <asp:Repeater ID="rptMainMenu" runat="server">
                            <ItemTemplate>
                                <div class="list-group-item" visible='<%# Eval("IsVisible") %>'>
                                    <a href="#" class="d-flex" style="border: none; color: black;" onclick="<%# Eval("ClickAction") %>">

                                        <i class='<%# Eval("IconCssClass") %>'
                                            style="margin-right: 10px; font-size: 24px;"></i>

                                        <div>
                                            <strong><%# Eval("Title") %></strong>
                                            <span style="padding-right: 30px;"><%# Eval("Description") %></span>
                                        </div>

                                        <%-- This line will ONLY render the 'New' badge if the IsNew property is true --%>
                                        <%# (bool)Eval("IsNew") ? "<a class='badge bg-red-dark line-height-xs font-9 rounded-xl position-absolute translate-end'>New</a>" : "" %>

                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>
            </div>

            <asp:Panel runat="server" ID="pnlSmallIconMenu" Visible="false">

                <div class="content my-0 mt-n2 px-1">
                    <div class="d-flex">
                        <div class="align-self-center">
                            <h3 class="font-16 mb-2">กิจกรรมล่าสุด</h3>
                        </div>
                        <%-- <div class="align-self-center ms-auto">
                        <a href="page-payment-transfer.html" class="font-12 pt-1">View All</a>
                    </div>--%>
                    </div>
                </div>

                <div class="content py-2" style="margin-top: 0 !important; padding-top: 0px !important;">
                    <div class="d-flex text-center">
                        <div class="me-auto">
                            <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-transfer" class="icon icon-xxl rounded-m bg-theme shadow-m">
                                <img src="http://localhost:56955/images/logos/กอช.png" style="width: 50px;" />
                            </a>
                            <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">บสย.X กอช.</h6>
                        </div>
                        <div class="m-auto">
                            <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="icon icon-xxl rounded-m bg-theme shadow-m">
                                <i class="font-28 color-red-dark bi bi-arrow-down-circle"></i>
                            </a>
                            <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Request</h6>
                        </div>
                        <div data-bs-toggle="offcanvas" data-bs-target="#menu-exchange" class="m-auto">
                            <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m">
                                <i class="font-28 color-blue-dark bi bi-arrow-repeat"></i>
                            </a>
                            <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Exchange</h6>
                        </div>
                        <div class="ms-auto">
                            <a href="page-payment-bill.html" class="icon icon-xxl rounded-m bg-theme shadow-m">
                                <i class="font-28 color-brown-dark bi bi-filter-circle"></i>
                            </a>
                            <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Bills</h6>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <div class="content my-0 px-1 mt-3">
                <div class="d-flex">
                    <div class="align-self-center">
                        <h3 class="font-16 mb-2 color-black">กิจกรรมโครงการ</h3>
                    </div>
                    <div class="align-self-center ms-auto">
                        <div class="align-self-center ms-auto">
                            <asp:HyperLink ID="btnShowAllBanner" onclick="ShowAllBanner();" NavigateUrl="#" runat="server" class="font-12 pt-1">ดูทั้งหมด</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Banner Campaign Config-->
            <%--<div id="campaignConfigBannerContainer"></div>--%>


            <asp:Repeater ID="rptBanners" runat="server">
                <ItemTemplate>
                    <div class="card card-style" style="margin-bottom: 10px !important" id='Div2' runat="server" visible='<%# Eval("IsVisible") %>'>
                        <div class="content" style="margin: 0px;">
                            <a href="<%#  Eval("RedirectUrl") %>" onclick="<%# Eval("TargetUrl") %>" style="padding: 0px; margin: 0px;" class="list-group-item">
                                <img src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' style="height: 120px; width: 100%;" />
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <asp:Panel runat="server" ID="pnlEvents" Visible="false">
                <div class="content my-0 mt-n2 px-1">
                    <div class="d-flex">
                        <div class="align-self-center">
                            <h3 class="font-16 mb-2 color-black">กิจกรรมที่เข้าร่วม</h3>
                        </div>
                    </div>
                </div>

                <!-- Recent Activity Cards-->
                <div class="card card-style">
                    <div class="content">
                        <asp:Literal ID="ltlEventHistory" Text="" runat="server" />
                    </div>
                </div>
            </asp:Panel>

            <!-- Recent Activity Title-->
            <asp:Panel runat="server" ID="pnlHistoryItem" Visible="false">


                <div class="content my-0 mt-n2 px-1">
                    <div class="d-flex">
                        <div class="align-self-center">
                            <h3 class="font-16 mb-2 color-black">ประวัติทำรายการ 5 ครั้งล่าสุด</h3>
                        </div>
                        <div class="align-self-center ms-auto">
                            <asp:HyperLink NavigateUrl="~/views/Activity/index.aspx" runat="server" class="font-12 pt-1">ดูทั้งหมด</asp:HyperLink>

                        </div>
                    </div>
                </div>

                <!-- Recent Activity Cards-->
                <div class="card card-style">
                    <div class="content">
                        <asp:Literal ID="ltlHistoryItem" Text="" runat="server" />
                    </div>
                </div>
            </asp:Panel>


        </div>

        <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" onclick="ShowRegisterInfoDetail(1)"  data-bs-whatever="@getbootstrap">Open modal for @getbootstrap</button>--%>

        <div id="menu-activity" class="offcanvas offcanvas-start" style="display: block; visibility: hidden;"
            aria-hidden="true">

            <div class="menu-size" style="width: 100vw;">
                <div class="d-flex mx-3 mt-3 py-1">
                    <div class="align-self-center">
                        <span class="icon icon-l gradient-red shadow-bg shadow-bg-xs me-3"><i
                            class="bi bi-droplet color-white"></i></span>
                    </div>
                    <div class="align-self-center">
                        <h1 class="font-24 mb-0">Utilities</h1>
                        <h2 class="mt-n1 mb-0 font-13 opacity-50 font-500">$1530.41 - 24.53%</h2>
                    </div>
                    <div class="align-self-center ms-auto">
                        <a href="#" class="ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                            <i class="bi bi-x color-red-dark font-26 line-height-xl"></i>
                        </a>
                    </div>
                </div>
                <div class="divider divider-margins my-3"></div>
                <div class="content">
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-single" class="d-flex py-1 mb-2">
                        <div class="align-self-center">
                            <h5 class="pt-1 mb-n1">Water Bill</h5>
                            <p class="mb-0 font-11 opacity-70">15th June <span class="copyright-year">2023</span></p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1">$15.35</h4>
                            <p class="mb-0 font-11 color-blue-dark opacity-70">Download</p>
                        </div>
                    </a>

                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-single" class="d-flex py-1 mb-2">
                        <div class="align-self-center">
                            <h5 class="pt-1 mb-n1">Telephone Bill</h5>
                            <p class="mb-0 font-11 opacity-70">15th June <span class="copyright-year">2023</span></p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1">$31.41</h4>
                            <p class="mb-0 font-11 color-blue-dark opacity-70">Download</p>
                        </div>
                    </a>

                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-single" class="d-flex py-1 mb-2">
                        <div class="align-self-center">
                            <h5 class="pt-1 mb-n1">Cloud Storage</h5>
                            <p class="mb-0 font-11 opacity-70">15th June <span class="copyright-year">2023</span></p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1">$43.21</h4>
                            <p class="mb-0 font-11 color-blue-dark opacity-70">Download</p>
                        </div>
                    </a>

                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-single" class="d-flex py-1 mb-2">
                        <div class="align-self-center">
                            <h5 class="pt-1 mb-n1">Spotify Music</h5>
                            <p class="mb-0 font-11 opacity-70">15th June <span class="copyright-year">2023</span></p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1">$19.21</h4>
                            <p class="mb-0 font-11 color-blue-dark opacity-70">Download</p>
                        </div>
                    </a>
                </div>

                <a href="#" data-bs-dismiss="offcanvas" class="mx-3 btn btn-full gradient-highlight shadow-bg shadow-bg-s">Back to Activity View</a>

            </div>
        </div>
    </div>

    <div class="modal fade" id="notFoundModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <i class="bi bi-patch-exclamation-fill" style="color: red; font-size: 30px; margin-right: 10px;"></i>
                    <h5 class="modal-title" id="exampleModalToggleLabel">ไม่พบข้อมูลติดต่อกลับ</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;กรุณาทำรายการตรวจสุขภาพทางการเงิน พร้อมกรอกข้อมูลติดต่อกลับ ก่อนทำรายการ                       
               
                </div>

                <div class="modal-footer" style="justify-content: center;">
                    <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="modalFirstTimeInfo" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static" style="padding: 20px;">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-body" style="padding: 0px !important;">

                    <div class="row">
                        <div class="col-12" style="font-size: 14px;">
                            <img src="images/Banner/closeServer252601.png" runat="server" style="width: 100%; margin-bottom: 10px;" />
                        </div>
                    </div>

                    <%--<div class="row">
                        <div class="col-12" style="font-size: 14px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;โปรโมชั่นพิเศษ ใช้บริการ HealthCheck ยืนยันตัวตนกับ บสย. หรือ ลงทะเบียนแก้หนี้ ลุ้นรับคูปองส่วนลดกาแฟพันธ์ไทย ฟรี!!
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <div class="list-group list-custom list-group-m list-group-flush rounded-xs overflow-visible">

                                <div id="Div2" class="list-group-item" runat="server">
                                    <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5" id="A4">
                                        <i class="has-bg1 gradient-yellow shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-bounding-box p-0  "
                                            style="margin-right: 10px; font-size: 24px;"></i>
                                        <div><strong>ยืนยันตัวตนลูกค้า บสย. </strong><span style="padding-right: 30px;">เพื่อดูข้อมูลการคํ้าประกันสินเชื่อ (บุคคลธรรมดา)</span></div>
                                    </a>
                                </div>

                                <a href="#" class="list-group-item" runat="server" id="A5">
                                    <i class="has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-patch-question p-0"
                                        style="margin-right: 10px; font-size: 24px;"></i>
                                    <div><strong>ตรวจสุขภาพทางการเงินกับ บสย.</strong><span>(ไม่มีผลต่อการพิจารณาคํ้าประกันสินเชื่อของ บสย)</span></div>
                                </a>

                                <a href="#" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="A6">
                                    <i class="has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 "
                                        style="margin-right: 10px; font-size: 24px;"></i>
                                    <div><strong>ลงทะเบียนแก้หนี้</strong><span style="padding-right: 30px;">(เข้าร่วมมาตรการแก้หนี้กับ บสย.)</span></div>
                                    <div class="align-self-center ms-auto text-end">
                                    </div>
                                </a>

                            </div>
                        </div>
                    </div>--%>

                    <div class="row">
                        <div class="col-12" style="float: right; font-size: 16px;">
                            <div class="form-check" style="float: right; font-size: 16px; margin-bottom: 8px;">
                                <input class="form-check-input" type="checkbox" value="" id="chkNotShowFirstTimeModal" onclick="SetFirstTimeToken();">
                                <label class="form-check-label" for="flexCheckDefault">
                                    ไม่ต้องแสดงอีก
                               
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <div class="modal-footer" style="justify-content: center;">
                                <a href="#" data-bs-target="#checkRegisterModal" onclick="HideFirstTimeInfo();"
                                    class="btn btn-xs mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ConfirmRegisterModal1" aria-hidden="true" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalToggleLabel1">เลือก โครงการเข้าร่วม</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="align-content: center; padding-left: 36px">
                    <%--<span>พร้อมค้ำ - มีความต้องการวงเงินสินเชื่อ
                    </span>
                    <br />
                    <span>พร้อมช่วย - ปรับปรุงโครงสร้างหนี้กับ บสย.
                    </span>--%>
                    <asp:Repeater ID="rptPromptkhumOptions" runat="server">
                        <ItemTemplate>
                            <span>
                                <%# Eval("Title") %>
                            </span>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <%--<a href="#" data-bs-target="#checkRegisterModal" onclick="RedirectToPage('healthcheck_PromKhum')" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">พร้อมค้ำ
                    </a>

                    <a href="#" onclick="RedirectToPage('event')" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">พร้อมช่วย</a>--%>
                    <asp:Repeater ID="rptPromptkhumActions" runat="server">
                        <ItemTemplate>
                            <a href="#"
                                onclick="<%# Eval("ClickAction") %>"
                                data-bs-toggle="modal"
                                data-bs-dismiss="modal"
                                class='<%# Eval("IconCssClass") %>'>
                                <%# Eval("BtnTitle") %>
        </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="allBannerModal" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">

                <div class="modal-header">
                    <i class="bi bi-box2-heart-fill" style="color: forestgreen; font-size: 30px; margin-right: 10px;"></i>
                    <h5 class="modal-title" id="allBannerModalToggleLab">กิจกรรมทั้งหมด</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body" style="padding: 0px;">

                    <!-- Banner Campaign Config-->
                    <%--<div id="campaignConfigBannerContainerAll"></div>--%>


                    <asp:Repeater ID="rptModalBanner" runat="server">
                        <ItemTemplate>
                            <div class="card card-style" style="margin-bottom: 10px !important" id='Div2' runat="server" visible='<%# Eval("IsVisible") %>'>
                                <div class="content" style="margin: 0px;">
                                    <a href="<%#  Eval("RedirectUrl") %>" onclick="<%# Eval("TargetUrl") %>" style="padding: 0px; margin: 0px;" class="list-group-item">
                                        <img src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' style="height: 120px; width: 100%;" />
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div class="modal-footer" style="justify-content: center;">
                    <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                </div>
            </div>
        </div>
    </div>

    <!-- SME มีดวง Floating Button -->
    <a href="page-activity.html" class="sme-floating-btn">
        <i class="bi bi-check-circle"></i>
        <span class="sme-label">SME มีดวง</span>
    </a>

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/Menu.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <%--
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-7F6BG5Q4NP"></script>

    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-7F6BG5Q4NP');
    </script>--%>
</asp:Content>
