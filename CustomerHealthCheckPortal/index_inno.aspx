<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
AutoEventWireup="true" CodeBehind="index_inno.aspx.cs" Inherits="CustomerHealthCheck.index_inno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField runat="server" ID="hddHomeUrl" ClientIDMode="Static"/>
<asp:HiddenField ID="hddIshaveProfile" runat="server" ClientIDMode="Static"/>

<div id="preloader">
    <div class="spinner-border color-highlight" role="status"></div>
</div>

<!-- Page Wrapper-->
<div id="page">

<!-- Footer Bar -->
<div id="footer-bar" class="footer-bar-1 footer-bar-detached">
    <asp:HyperLink ID="btnToActivity" NavigateUrl="~/viewx/Activity/index.aspx" runat="server">
        <i class="bi bi-journal-text"></i><span>ประวัติทำรายการ</span>
    </asp:HyperLink>
    <asp:HyperLink ID="btnToHome" NavigateUrl="~/index_inno.aspx" runat="server" class="circle-nav-2">
        <i class="bi bi-house-fill"></i><span>หน้าหลัก</span>
    </asp:HyperLink>
    <asp:HyperLink ID="btnToProfile" NavigateUrl="~/viewx/Profile/index.aspx" runat="server">
        <i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span>
    </asp:HyperLink>

    <!--<a href="page-wallet.html"><i class="bi bi-wallet2"></i><span>Cards</span></a>-->
    <%--  <a href="activity.aspx"><i class="bi bi-patch-question"></i><span>ประวัติการตรวจ</span></a>
                <a href="index.aspx" class="circle-nav-2"><i class="bi bi-house-fill"></i><span>หน้าหลัก</span></a>
                <a href="views/profile/profile.aspx"><i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span></a>--%>
    <!--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-sidebar"><i class="bi bi-three-dots"></i><span>More</span></a>-->
</div>

<!-- Page Content - Only Page Elements Here-->
<div class="page-content footer-clear">

<!-- Page Title-->
<div class="pt-3">
    <div class="page-title d-flex">
        <div class="align-self-center me-auto">
            <!--<p class="color-white opacity-80 header-date"></p>-->
            <asp:Image ImageUrl="~/images/logos/Logo.png" runat="server" Style="height: 60px; float: left;"/>

            <h1 class="color-white" style="position: absolute; top: 30px; left: 85px; color: #092d74 !important;">ยินดีต้อนรับ</h1>
        </div>

    </div>
    <asp:Label ID="lblUID1" Text="" runat="server" Visible="false"/>
</div>

<svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
    <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
    <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
    <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
    <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
</svg>


<div class="card card-style" style="text-align: center;">
    <a href="https://www.tcg.or.th/index.php">
        <asp:Image ImageUrl="~/images/logos/FF.png" runat="server" Style="height: 130px; padding: 20px; max-width: 300px; margin: 0 auto;"/>
        <div class="card-bottom p-3">
            <!--<h1 class="color-white mb-0">โลโก้ บสย.</h1>
            <p class="color-white mb-0 opacity-60">
                รวดเร็ว ทันใจ ที่หนึ่งในใจ SME
            </p>-->
        </div>
        <div class="card-overlay bg-gradient-fade2"></div>
    </a>
</div>


<!--Account Activity Notification-->
<div class="card card-style shadow-bg shadow-bg-s color-blue" style="display: none;">
    <div class="content">

        <a href="#" onclick="redirectToHealthCheck()" class="d-flex ">
            <div class="align-self-center">
                <h1 class="mb-0 font-40">
                    <i class="bi bi-patch-question pe-3" style="color: #092d74 !important;"></i>
                </h1>
            </div>
            <div class="align-self-center">
                <h5 class=" font-700 mb-0 mt-0 pt-1 " style="color: #092d74 !important;">
                    ตรวจสุขภาพทางการเงินกับ บสย

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

<!-- Main Card Slider-->
<div class="splide single-slider slider-no-dots slider-no-arrows slider-visible" id="single-slider-1">
    <div class="splide__track">
        <div class="splide__list">
            <div class="splide__slide">
                <div class="card card-style m-0  shadow-card shadow-card-m" style="height: 200px">
                    <div class="card-top p-3">
                    </div>
                    <div class="card-center">
                        <div class="content py-2">
                            <div class="d-flex text-center">
                                <div class="me-auto">
                                    <a href="#" onclick="redirectToMyLG();"
                                       class="icon icon-xxl rounded-m bg-theme shadow-m gradient-brown">
                                        <i class="font-28 color-white bi bi-file-earmark-text"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">My LG</h6>
                                </div>
                                <div class="m-auto">
                                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-orange" onclick="RedirectToPage('debt')">
                                        <i class="font-28 color-white bi bi-capsule-pill"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">แก้หนี้</h6>
                                </div>
                                <div data-bs-toggle="offcanvas" data-bs-target="#menu-exchange" class="m-auto" onclick="RedirectToPage('event')">
                                    <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-mint">
                                        <i class="font-28 color-white bi bi-calendar-event"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">กิจกรรม</h6>
                                </div>
                                <div class="ms-auto">
                                    <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-green" onclick="redirectToProduct()">
                                        <i class="font-28 color-white  bi bi-receipt-cutoff"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">ผลิตภัณฑ์</h6>
                                </div>
                            </div>
                            <div class="d-flex text-center">
                                <div class="me-auto">
                                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-transfer" onclick="redirectToNDID();"
                                       class="icon icon-xxl rounded-m bg-theme shadow-m gradient-yellow">
                                        <i class="font-28 color-white bi bi-person-bounding-box"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">ยืนยันตัวตน</h6>
                                </div>
                                <div class="m-auto">
                                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" onclick="redirectToQueue();"
                                       class="icon icon-xxl rounded-m bg-theme shadow-m gradient-magenta">
                                        <i class="font-28 color-white bi bi-calendar2-check"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">จองคิวหมอ</h6>
                                </div>
                                <div data-bs-toggle="offcanvas" data-bs-target="#menu-exchange" onclick="redirectToPayment();"
                                     class="m-auto">
                                    <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-teal">
                                        <i class="font-28 color-white bi bi-pass"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">บิล</h6>
                                </div>
                                <div class="ms-auto">
                                    <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-pink" onclick="redirectToCal();">
                                        <i class="font-28 color-white bi bi-calculator"></i>
                                    </a>
                                    <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">คำนวน</h6>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>


        </div>
    </div>
</div>


<div class="content my-0 mt-n2 px-1">
    <div class="d-flex">
        <div class="align-self-center">
            <h3 class="font-16 mb-2 color-black">บริการยอดนิยม</h3>
        </div>
    </div>
</div>

<div class="card card-style" style="display: flex;">
    <div class="content" style="margin: 10px 15px 10px 15px !important;">
        <div class="list-group list-custom list-group-m list-group-flush rounded-xs overflow-visible">

            <a href="#" class="list-group-item" onclick="RedirectToPage('healthcheck')" runat="server" id="btnHealthCheckFeature">
                <i class="has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-patch-question p-0"
                   style="margin-right: 10px; font-size: 24px;">
                </i>
                <div>
                    <strong>ตรวจสุขภาพทางการเงินกับ บสย.</strong><span>(ไม่มีผลต่อการพิจารณาคํ้าประกันสินเชื่อของ บสย)</span>
                </div>
                <div class="align-self-center ms-auto text-end">
                    <img src="images/logos/hothit.png" style="width: 50px; margin-bottom: 4px;"/>
                    <span>Hot!&nbsp;&nbsp;&nbsp;</span>
                    <%-- <i class="has-bg1 shadow-bg shadow-bg-xs color-white rounded-s bi bi-gift-fill p-0  " style="margin-right: 0px; font-size: 22px; color: red !important;"></i>--%>
                </div>
            </a>


            <%-- <a href="#" class="list-group-item" data-trigger-switch="switch-5" onclick="redirectToIdentify()">
                                <i class="has-bg1 gradient-yellow shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-bounding-box p-0 " 
                                    style="margin-right: 10px;font-size:24px;"></i>
                                <div><strong>ยืนยันตัวตนกับ บสย.</strong><span>พิสูจณ์ตัวตนก่อนทำธุรกรรมกับ บสย.</span></div>
                            </a>--%>
        </div>
    </div>
</div>


<div class="card card-style" style="margin-bottom: 10px;">
    <div class="content" style="margin: 0px;">
        <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">


            <a href="https://fti.or.th/sme_gift_2023" id="ContentPlaceHolder1_A3" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                <img src="images/S1Logo/s2.jpg" style="height: 120px; width: 100%;">
            </a>


        </div>
    </div>
</div>


<div class="card card-style">
    <div class="content" style="margin: 0px;">
        <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
            <a href="https://forms.exim.go.th/S1?suggest=EEAE848C-06AF-4F3B-8E56-4DC6C711A172" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="A2">
                <img src="images/S1Logo/s1.png" style="height: 120px; width: 100%;"/>
            </a>
        </div>
    </div>
</div>


<div id="ContentPlaceHolder1_pnlHistoryItem">


    <div class="content my-0 mt-n2 px-1">
        <div class="d-flex">
            <div class="align-self-center">
                <h3 class="font-16 mb-2 color-black">ประวัติทำรายการ 5 ครั้งล่าสุด</h3>
            </div>
            <div class="align-self-center ms-auto">
                <a class="font-12 pt-1" href="views/Activity/index.aspx">ดูทั้งหมด</a>

            </div>
        </div>
    </div>

    <!-- Recent Activity Cards-->
    <div class="card card-style">
        <div class="content">
            <a class="d-flex py-1 p-1" href="#">
                <div class="align-self-center">
                    <img src="images/statusHC/score-3.png" width="40">
                </div>
                <div class="align-self-center ps-1">
                    <h5 class="pt-1 mb-n1" style="font-size: 14px;">ตรวจสุขภาพหนี้</h5>
                    <p class="mb-0 font-11 opacity-50">วันที่ 23/11/2565</p>
                </div>
                <div class="align-self-center ms-auto text-end">
                    <h5 style="font-size: 14px;" class="pt-1 mb-n1 color-red-dark ">อ่อนแอ</h5>
                </div>
            </a>
            <div class="divider my-2 opacity-50" style="background-color: rgba(0, 0, 0, 0.07) !important;"></div>
            <a class="d-flex py-1 p-1" href="#">
                <div class="align-self-center">
                    <i class="icon has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar-event p-0 " style="margin-right: 10px; font-size: 25px;"></i>
                </div>
                <div class="align-self-center ps-1">
                    <h5 class="pt-1 mb-n1" style="font-size: 14px;">ลงทะเบียนกิจกรรม จับคู่กู้คํ้า</h5>
                    <p class="mb-0 font-11 opacity-50">วันที่ 23/11/2565</p>
                </div>
                <div class="align-self-center ms-auto text-end">
                    <h5 style="font-size: 14px;" class="pt-1 mb-n1  "></h5>
                </div>
            </a>
            <div class="divider my-2 opacity-50" style="background-color: rgba(0, 0, 0, 0.07) !important;"></div>
            <a class="d-flex py-1 p-1" href="#">
                <div class="align-self-center">
                    <i class="icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 " style="margin-right: 10px; font-size: 25px;"></i>
                </div>
                <div class="align-self-center ps-1">
                    <h5 class="pt-1 mb-n1" style="font-size: 14px;">ลงทะเบียนประนอมหนี้</h5>
                    <p class="mb-0 font-11 opacity-50">วันที่ 20/11/2565</p>
                </div>
                <div class="align-self-center ms-auto text-end">
                    <h5 style="font-size: 14px;" class="pt-1 mb-n1 color-green-dark ">มาตรการที่ 3</h5>
                </div>
            </a>
            <div class="divider my-2 opacity-50" style="background-color: rgba(0, 0, 0, 0.07) !important;"></div>
            <a class="d-flex py-1 p-1" href="#">
                <div class="align-self-center">
                    <img src="images/statusHC/score-2.png" width="40">
                </div>
                <div class="align-self-center ps-1">
                    <h5 class="pt-1 mb-n1" style="font-size: 14px;">ตรวจสุขภาพหนี้</h5>
                    <p class="mb-0 font-11 opacity-50">วันที่ 20/11/2565</p>
                </div>
                <div class="align-self-center ms-auto text-end">
                    <h5 style="font-size: 14px;" class="pt-1 mb-n1 color-yellow-dark ">ปานกลาง</h5>
                </div>
            </a>
            <div class="divider my-2 opacity-50" style="background-color: rgba(0, 0, 0, 0.07) !important;"></div>
            <a class="d-flex py-1 p-1" href="#">
                <div class="align-self-center">
                    <img src="images/statusHC/score-3.png" width="40">
                </div>
                <div class="align-self-center ps-1">
                    <h5 class="pt-1 mb-n1" style="font-size: 14px;">ตรวจสุขภาพหนี้</h5>
                    <p class="mb-0 font-11 opacity-50">วันที่ 28/10/2565</p>
                </div>
                <div class="align-self-center ms-auto text-end">
                    <h5 style="font-size: 14px;" class="pt-1 mb-n1 color-red-dark ">อ่อนแอ</h5>
                </div>
            </a>

        </div>

    </div>

</div>


</div>


<%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" onclick="ShowRegisterInfoDetail(1)"  data-bs-whatever="@getbootstrap">Open modal for @getbootstrap</button>--%>
</div>

<!-- Modal Full-->


<!-- End of Page ID-->


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
                   class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">
                    ปิด
                </a>


            </div>
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/Menu.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-7F6BG5Q4NP"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-7F6BG5Q4NP');
    </script>
</asp:Content>