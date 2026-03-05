<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="merchant_KM.aspx.cs" Inherits="CustomerHealthCheck.merchant_KM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - Main Menu</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hddHomeUrl" ClientIDMode="Static" />
    <asp:HiddenField ID="hddIshaveProfile" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddBannerEvent1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddBannerEvent2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddContactDoctor" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddSetThailandURL" runat="server" ClientIDMode="Static" />

    <div id="preloader">
        <div class="spinner-border color-highlight" role="status"></div>
    </div>

    <!-- Page Wrapper-->
    <div id="page">



        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear">

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



            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto" style="color: black;">
                        <p class="color-black opacity-80 header-date"></p>
                        <h1 class="color-black">Welcome</h1>
                    </div>
                    <div class="align-self-center ms-auto">

                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-notifications" class="icon bg-white color-theme rounded-m shadow-xl">
                            <i class="bi bi-bell-fill color-black font-17"></i>
                            <em class="badge bg-red-light color-white scale-box">3</em>
                        </a>


                        <div class="dropdown-menu" style="margin: 0px;">
                            <div class="card card-style shadow-m mt-1 me-1">
                                <div class="list-group list-custom list-group-s list-group-flush rounded-xs px-3 py-1">
                                    <a href="page-wallet.html" class="list-group-item">
                                        <i class="has-bg gradient-green shadow-bg shadow-bg-xs color-white rounded-xs bi bi-building-gear"></i>
                                        <strong class="font-13">Wallet</strong>
                                    </a>
                                    <a href="page-activity.html" class="list-group-item">
                                        <i class="has-bg gradient-blue shadow-bg shadow-bg-xs color-white rounded-xs bi bi-graph-up"></i>
                                        <strong class="font-13">Activity</strong>
                                    </a>
                                    <a href="page-profile.html" class="list-group-item">
                                        <i class="has-bg gradient-yellow shadow-bg shadow-bg-xs color-white rounded-xs bi bi-person-circle"></i>
                                        <strong class="font-13">Account</strong>
                                    </a>
                                    <a href="page-signin-1.html" class="list-group-item">
                                        <i class="has-bg gradient-red shadow-bg shadow-bg-xs color-white rounded-xs bi bi-power"></i>
                                        <strong class="font-13">Log Out</strong>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="content py-2">
                <div class="d-flex text-center">
                    <div class="me-auto">
                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-transfer" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-green color-white"
                            onclick="redirectToMProfile_KM();">
                            <i class="font-28  bi bi-building-gear"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">จัดการ Profile</h6>
                    </div>
                    <div class="m-auto">
                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-blue color-white"
                            onclick="redirectToMCoupon_KM();">
                            <i class="font-28  bi bi-ticket-detailed"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">จัดการคูปอง</h6>
                    </div>
                    <div data-bs-toggle="offcanvas" data-bs-target="#menu-exchange" class="m-auto">
                        <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m gradient-yellow color-white" onclick="redirectToMScan_KM();">
                            <i class="font-28 bi bi-hr"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Scan QR</h6>
                    </div>
                    <div class="ms-auto">
                        <a  class="icon icon-xxl rounded-m bg-theme shadow-m gradient-orange color-white" onclick="redirectToMDashboard_KM();">
                            <i class="font-28  bi bi-graph-up"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Report</h6>
                    </div>
                </div>
            </div>



            <!-- Page Title-->
            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>



            <div class="pt-3">
                <div class="page-title d-flex" style="padding-bottom: 0px;">
                    <div class="align-self-center me-auto" style="color: black;">

                        <h5 class="color-black">ข่าวสาร บสย.</h5>
                    </div>
                </div>
            </div>





            <div class="card card-style mb-3">
                <div class="content">
                    <div class="d-flex">
                        <div class="pt-1 ms-auto">
                            <img src="../../images/logos/n1.jpg" class="img-fluid rounded-s" width="110">
                        </div>
                        <div class="ps-3 me-auto">
                            <strong class="opacity-30 color-theme font-11"></strong>
                            <h3 class="mt-n2 pb-2">บสย. เชิญชวนลูกหนี้ที่จ่ายเคลม “ลด ปลด หนี้” แก้หนี้ยั่งยืน</h3>
                            <p>
                                บสย. เชิญชวนลูกหนี้ที่จ่ายเคลม “ลด ปลด หนี้” แก้หนี้ยั่งยืน 
ร่วมมาตรการ “บสย. พร้อมช่วย” ช่วยธุรกิจเดินหน้าต่อได้ 
                            </p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card card-style mb-3">
                <div class="content">
                    <div class="d-flex">
                        <div class="pe-3 me-auto">
                            <strong class="opacity-30 color-theme font-11">Great for Images</strong>
                            <h3 class="mt-n2 pb-2">​บสย. ร่วมงาน Thailand Wellness & Healthcare Expo 2024</h3>
                            <p>
                                บสย. ร่วมงาน Thailand Wellness & Healthcare Expo 2024
ผนึกลูกค้ากลุ่มสุขภาพ ออกบูธโชว์นวัตกรรม ต่อยอดธุรกิจ 
                            </p>
                        </div>
                        <div class="pt-1 ms-auto">
                            <img src="../../images/logos/n2.jpg" class="img-fluid rounded-s" width="110">
                        </div>
                    </div>
                </div>
            </div>





        </div>


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
                            <img src="http://localhost:56955/images/Banner/ba.jpg" style="width: 100%" />
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
                        <div class="col-12" style="float: right; font-size: 14px;">
                            <div class="form-check" style="float: right;">
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

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/Menu_KM.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
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
