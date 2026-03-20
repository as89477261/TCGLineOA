<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - Main Menu</title>
    <style>
        /* =====================================================
           INDEX PAGE REDESIGN — blue/white theme
        ===================================================== */

        /* --- Page background --- */
        #page { background: linear-gradient(180deg,#dbeafe 0%,#eff6ff 28%,#f8faff 60%) !important; }

        /* --- Header blue gradient area --- */
        .idx-header {
            background: linear-gradient(145deg,#0a2463 0%,#1344a0 45%,#3b82f6 100%);
            padding: 12px 20px 0;
            position: relative;
        }
        /* subtle aurora shimmer */
        .idx-header::before {
            content: "";
            position: absolute; top: -40px; right: -60px;
            width: 220px; height: 220px; border-radius: 50%;
            background: radial-gradient(circle,rgba(147,197,253,0.35) 0%,transparent 70%);
            pointer-events: none;
        }
        /* SVG wave at bottom of header */
        .idx-header-wave { display:block; width:100%; height:40px; margin-top:12px; }

        /* --- Service icons card --- */
        .idx-services-card {
            background: #fff;
            border-radius: 20px;
            margin: 0 16px 16px;
            padding: 16px 8px 12px;
            box-shadow: 0 4px 18px rgba(0,0,0,0.08);
        }

        /* --- Section title --- */
        .idx-section-title {
            font-size: 18px; font-weight: 800;
            color: #0f172a; margin: 0 16px 10px;
            letter-spacing: -0.2px;
        }

        /* ---- Service icon grid (override splide) ---- */
        #double-slider-2 { visibility: visible !important; }
        #double-slider-2 .splide__track { overflow: visible !important; }
        #double-slider-2 .splide__list {
            display: grid !important;
            grid-template-columns: repeat(4,1fr) !important;
            transform: none !important;
            gap: 4px !important;
            flex-wrap: wrap !important;
        }
        #double-slider-2 .splide__slide {
            width: auto !important;
            margin: 0 !important;
        }
        /* hide splide JS-generated clones so real items appear only once */
        #double-slider-2 .splide__slide--clone { display: none !important; }
        #double-slider-2 .splide__pagination { display: none !important; }
        /* squircle icon tile */
        #double-slider-2 .splide__slide > div[data-card-height] {
            height: 60px !important;
            width: 60px !important;
            font-size: 26px !important;
            border-radius: 16px !important;
            margin: 0 auto;
            display: flex !important;
            align-items: center !important;
            justify-content: center !important;
        }
        #double-slider-2 .splide__slide .font-10 {
            font-size: 11px !important;
            color: #334155;
            font-weight: 600;
            margin-top: 6px;
        }

        /* ---- "บริการของฉัน" individual menu cards ---- */
        .idx-menu-card {
            background: #fff;
            border-radius: 18px;
            margin: 0 16px 12px;
            padding: 14px 16px;
            box-shadow: 0 2px 14px rgba(0,0,0,0.07);
            display: flex;
            align-items: center;
            gap: 14px;
            text-decoration: none;
            color: inherit;
            cursor: pointer;
        }
        .idx-menu-card:hover { text-decoration: none; color: inherit; }
        .idx-menu-card .menu-icon-wrap {
            width: 48px; height: 48px; border-radius: 14px;
            display: flex; align-items: center; justify-content: center;
            font-size: 22px; color: #fff; flex-shrink: 0;
        }
        .idx-menu-card .menu-text { flex: 1; min-width: 0; }
        .idx-menu-card .menu-title { font-size: 15px; font-weight: 700; color: #0f172a; }
        .idx-menu-card .menu-desc  { font-size: 12px; color: #64748b; margin-top: 1px; }
        .idx-menu-card .menu-arrow { color: #cbd5e1; font-size: 20px; flex-shrink: 0; }
        .idx-menu-card .badge-new  {
            background: #ef4444; color: #fff;
            font-size: 9px; font-weight: 700; padding: 2px 7px;
            border-radius: 20px; flex-shrink: 0;
        }

        /* hide old single-card list wrapper */
        .idx-hide { display: none !important; }

        /* ---- Banner cards ---- */
        .idx-banner-card {
            margin: 0 16px 12px;
            border-radius: 18px;
            overflow: hidden;
            box-shadow: 0 3px 16px rgba(0,0,0,0.10);
        }
        .idx-banner-card img { width:100%; display:block; height:130px; object-fit:cover; }

        /* ---- SME Floating Circle Button (unchanged) ---- */
        @keyframes fab-pulse {
            0%,100%{ box-shadow:0 0 0 0 rgba(251,191,36,0.5),0 4px 20px rgba(245,158,11,0.35); }
            50%    { box-shadow:0 0 0 8px rgba(251,191,36,0.12),0 4px 28px rgba(245,158,11,0.55); }
        }
        @keyframes fab-twinkle {
            0%,100%{ opacity:0.15; transform:scale(0.6) rotate(0deg); }
            50%    { opacity:1;    transform:scale(1.3)  rotate(20deg); }
        }
        @keyframes fab-float {
            0%,100%{ transform:translateY(-50%) translateY(0px); }
            50%    { transform:translateY(-50%) translateY(-5px); }
        }
        .sme-floating-btn {
            position:fixed; right:14px; top:50%; transform:translateY(-50%);
            z-index:9999; width:64px; height:64px; border-radius:50%;
            display:flex; flex-direction:column; align-items:center; justify-content:center;
            background:radial-gradient(circle at 38% 32%,#fffbeb 0%,#fef3c7 40%,#fde68a 100%);
            border:2.5px solid rgba(245,158,11,0.55); text-decoration:none; gap:1px;
            animation:fab-pulse 2.8s ease-in-out infinite, fab-float 3.5s ease-in-out infinite;
            transition:transform 0.2s;
        }
        .sme-floating-btn:hover,.sme-floating-btn:active{ text-decoration:none; transform:translateY(-50%) scale(1.1); }
        .sme-floating-btn .fab-star{
            position:absolute; font-size:9px; color:#f59e0b;
            animation:fab-twinkle var(--d,2s) ease-in-out infinite;
            animation-delay:var(--dl,0s); pointer-events:none;
        }
        .sme-floating-btn .fab-star.s1{top:-5px;left:14px;--d:2.0s;--dl:0.0s}
        .sme-floating-btn .fab-star.s2{top:8px;right:-6px;--d:1.7s;--dl:0.5s}
        .sme-floating-btn .fab-star.s3{bottom:-4px;left:20px;--d:2.3s;--dl:0.9s}
        .sme-floating-btn .fab-star.s4{bottom:10px;right:-5px;--d:1.9s;--dl:1.3s}
        .sme-floating-btn .fab-star.s5{top:-4px;right:14px;--d:2.1s;--dl:0.3s}
        .sme-floating-btn .fab-star.s6{bottom:-3px;left:8px;--d:2.5s;--dl:0.7s}
        .sme-floating-btn .hora-icon{ font-size:22px; color:#b45309; filter:drop-shadow(0 1px 3px rgba(180,83,9,0.3)); line-height:1; }
        .sme-floating-btn .sme-label{ font-size:9px; font-weight:800; color:#92400e; letter-spacing:0.5px; line-height:1; }
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

            <!-- Page Header -->
            <div class="idx-header">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <asp:Image ImageUrl="~/images/logos/Logo.png" runat="server" Style="height: 80px; float: left;" />
                        <asp:Image ImageUrl="~/images/logos/FF.png" runat="server" Style="height: 95px; padding: 10px; max-width: 300px; margin: 0 auto; position: absolute;" />
                    </div>
                </div>
                <asp:Label ID="lblUID1" Text="" runat="server" Visible="false" />
                <!-- Wave bottom of header -->
                <svg class="idx-header-wave" viewBox="0 0 375 40" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M0,40 C80,10 295,10 375,40 L375,40 L0,40 Z" fill="#dbeafe"/>
                </svg>
            </div>

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

            <div class="idx-services-card">
                <h3 class="idx-section-title" style="margin:0 8px 12px;">บริการ บสย.</h3>
                <div>
                <div class="splide quad-slider slider-no-dots slider-no-arrows slider-visible text-center  splide--ltr splide--draggable is-active mt-2 me-1"
                    id="double-slider-2" style="visibility: visible;">
                    <div class="splide__track" id="double-slider-2-track">
                        <div class="splide__list ms-2" id="double-slider-2-list">

                            <asp:Repeater ID="rptServiceMenu" runat="server">
                                <ItemTemplate>
                                    <div class="splide__slide cursor-pointer"
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
                </div><%-- close inner div --%>
            </div><%-- close idx-services-card --%>

            <h3 class="idx-section-title mt-2">บริการของฉัน</h3>
            <asp:Repeater ID="rptMainMenu" runat="server">
                <ItemTemplate>
                    <div class="idx-menu-card" onclick="<%# Eval("ClickAction") %>">
                        <i class='<%# Eval("IconCssClass") %>' style="font-size:22px; width:44px; height:44px; display:flex; align-items:center; justify-content:center; border-radius:14px; flex-shrink:0;"></i>
                        <div class="menu-text">
                            <div class="menu-title"><%# Eval("Title") %></div>
                            <div class="menu-desc"><%# Eval("Description") %></div>
                        </div>
                        <%# (bool)Eval("IsNew") ? "<span class='badge-new'>New</span>" : "" %>
                        <i class="bi bi-chevron-right menu-arrow"></i>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

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


            <div class="d-flex align-items-center mt-3 mb-1">
                <h3 class="idx-section-title mb-0">กิจกรรมโครงการ</h3>
                <div class="ms-auto me-3">
                    <asp:HyperLink ID="btnShowAllBanner" onclick="ShowAllBanner();" NavigateUrl="#" runat="server" class="font-12 text-primary">ดูทั้งหมด</asp:HyperLink>
                </div>
            </div>

            <!-- Banner Campaign Config-->
            <%--<div id="campaignConfigBannerContainer"></div>--%>


            <asp:Repeater ID="rptBanners" runat="server">
                <ItemTemplate>
                    <div class="idx-banner-card" id='Div2' runat="server" visible='<%# Eval("IsVisible") %>'>
                        <a href="<%#  Eval("RedirectUrl") %>" onclick="<%# Eval("TargetUrl") %>">
                            <img src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' />
                        </a>
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

    <!-- SME มีดวง Floating Circle Button -->
    <a href="<%= ResolveClientUrl("~/views/hora/index.aspx") %>" class="sme-floating-btn">
        <span class="fab-star s1">&#10022;</span>
        <span class="fab-star s2">&#9733;</span>
        <span class="fab-star s3">&#10022;</span>
        <span class="fab-star s4">&#9733;</span>
        <span class="fab-star s5">&#10022;</span>
        <span class="fab-star s6">&#9733;</span>
        <i class="bi bi-suit-diamond-fill hora-icon"></i>
        <span class="sme-label">พร้อม</span>
        <span class="sme-label">มู</span>
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
