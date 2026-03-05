<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="Register_KM.aspx.cs" Inherits="CustomerHealthCheck.Register_KM" %>

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

        <!-- Footer Bar -->
        <div id="footer-bar" class="footer-bar-1 footer-bar-detached">
            <asp:HyperLink ID="btnToActivity" NavigateUrl="~/views/Activity/index.aspx" runat="server"><i class="bi bi-journal-text"></i><span>ประวัติทำรายการ</span></asp:HyperLink>
            <asp:HyperLink ID="btnToHome" NavigateUrl="~/index.aspx" runat="server" class="circle-nav-2"><i class="bi bi-house-fill"></i><span>หน้าหลัก</span></asp:HyperLink>
            <asp:HyperLink ID="btnToProfile" NavigateUrl="~/views/Profile/index.aspx" runat="server"><i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span></asp:HyperLink>

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

                            <div id="pnlHealthCheckMenu" runat="server" class="splide__slide splide__slide--clone" aria-hidden="true" tabindex="-1" style="width: 68px;" onclick="RedirectToPage('healthcheck')">
                                <div href="#" data-card-height="68" data-bs-toggle="offcanvas" data-bs-target="#menu-friends-transfer"
                                    class="has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-patch-question d-flex justify-content-center align-items-center "
                                    style="height: 68px; font-size: 30px;">
                                </div>
                                <div class="pt-2 font-10">Health Check</div>
                            </div>

                            <div id="pnlDebtDoctorMenu" runat="server" class="splide__slide splide__slide--clone" tabindex="-1" style="width: 68px; display: none" onclick="RedirectToPage('debtDoctor')">
                                <div href="#" data-card-height="68" data-bs-toggle="offcanvas" data-bs-target="#menu-friends-transfer"
                                    class="has-bg1 gradient-teal shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-workspace d-flex justify-content-center align-items-center"
                                    style="height: 68px; font-size: 30px;">
                                    <a class="badge bg-red-dark font-9 rounded-xl position-absolute top-0 start-90 translate-middle" style="background-size: contain;">New</a>
                                </div>
                                <div
                                    class="pt-2 font-10">
                                    นัดหมายหมอหนี้
                                </div>
                            </div>

                            <%--                            <div class="splide__slide splide__slide--clone" style="width: 68px;" onclick="RedirectToPage('set_thailand')">
                                <div href="#" data-card-height="68" data-bs-toggle="offcanvas" data-bs-target="#menu-friends-transfer"
                                    class="has-bg1 gradient-gold shadow-bg shadow-bg-xs color-white rounded-s bi bi-file-bar-graph d-flex justify-content-center align-items-center"
                                    style="height: 68px; font-size: 30px;">
                                </div>
                                <div class="pt-2 font-10">SET</div>
                            </div>--%>

                            <div id="pnlDebtRegisterMenu" runat="server" class="splide__slide splide__slide--clone" style="width: 68px;" onclick="RedirectToPage('debt')">
                                <div href="#" data-card-height="68" data-bs-toggle="offcanvas" data-bs-target="#menu-friends-transfer"
                                    class="has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill d-flex justify-content-center align-items-center"
                                    style="height: 68px; font-size: 30px;">
                                </div>
                                <div class="pt-2 font-10">แก้หนี้</div>
                            </div>

                            <div id="pnlEventMenu" runat="server" class="splide__slide splide__slide--clone" style="width: 68px;" onclick="RedirectToPage('event')">
                                <div href="#" data-card-height="68" data-bs-toggle="offcanvas" data-bs-target="#menu-friends-transfer"
                                    class="has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar3 d-flex justify-content-center align-items-center"
                                    style="height: 68px; font-size: 30px;">
                                </div>
                                <div class="pt-2 font-10">กิจกรรม บสย.</div>
                            </div>

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

            <div class="card card-style" style="margin-bottom: 30px;">
                <div class="content">

                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs overflow-visible">

                        <%--                         <div id="pnlCalculate" class="list-group-item" runat="server" visible="true">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('signUp')" runat="server" id="A3">
                                <i class="has-bg1 gradient-yellow shadow-bg shadow-bg-xs color-white rounded-s bi bi-calculator p-0  "
                                    style="margin-right: 10px; font-size: 24px;"></i>

                                <div><strong>เครื่องมือคำนวณ</strong><span style="padding-right: 30px;">คำนวณการชำระค่าธรรมเนียมเบื้องต้น</span></div>
                            </a>
                        </div>--%>

                        <div id="pnlCalculator" class="list-group-item" runat="server" visible="false">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('cal')" runat="server" id="btnCalMenu">
                                <i class="has-bg1 gradient-green shadow-bg shadow-bg-xs color-white rounded-s bi bi-calculator-fill p-0  "
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <%--                             <img src="images/logos/Menu3.jpg" class="has-bg1 color-white rounded-s p-0" 
                                style="margin-right: 10px; font-size: 20px;width:50px;" />--%>
                                <div><strong>โปรแกรมคำนวน</strong><span style="padding-right: 30px;">คำนวณค่างวดสินเชื่อและคํ้าประกัน</span></div>
                            </a>
                        </div>

                        <div id="pnlRegisterWithTCGDB" class="list-group-item" runat="server" visible="false" style="display:none;">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('signUp')" runat="server" id="btnRegisterMenu">
                                <i class="has-bg1 gradient-yellow shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-bounding-box p-0  "
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <%--                             <img src="images/logos/Menu3.jpg" class="has-bg1 color-white rounded-s p-0" 
                                style="margin-right: 10px; font-size: 20px;width:50px;" />--%>
                                <div><strong>ยืนยันตัวตนลูกค้า บสย. </strong><span style="padding-right: 30px;">เพื่อดูข้อมูลการคํ้าประกันสินเชื่อ (บุคคลธรรมดา)</span></div>
                            </a>
                        </div>

                        <div id="pnlCheckRequestStatusMenu" class="list-group-item" runat="server" visible="false" style="display:none;">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('myrequest')" runat="server" id="btnRequest">
                                <i class="has-bg1 gradient-brown shadow-bg shadow-bg-xs color-white rounded-s bi bi-file-earmark-text p-0"
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>คำขอคํ้าประกัน กับ บสย.</strong><span style="padding-right: 30px;">รายการคำขอเข้าร่วมผลิตภัณฑ์ บสย.</span></div>
                            </a>
                            <a class="badge bg-red-dark line-height-xs font-9 rounded-xl position-absolute translate-end">New</a>
                        </div>

                        <div id="pnlCheckMyLGStatusMenu" class="list-group-item" runat="server" visible="true" style="display:none;">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('mylg')" runat="server" id="btnMyLg">
                                <i class="has-bg1 gradient-pink shadow-bg shadow-bg-xs color-white rounded-s bi bi-file-text-fill p-0"
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>My LG</strong><span style="padding-right: 30px;">หนังสือสัญญาค้ำประกัน</span></div>
                            </a>
                        </div>

                        <div id="pnlCheckMyBillStatusMenu" class="list-group-item" runat="server" visible="true" style="display:none;">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('mybill')" runat="server" id="btnMyBill">
                                <i class="has-bg1 gradient-magenta shadow-bg shadow-bg-xs color-white rounded-s bi bi-receipt p-0"
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>My Bill</strong><span style="padding-right: 30px;">ประวัติการชำระ</span></div>
                            </a>
                        </div>


                        <div id="Div1" class="list-group-item" runat="server" visible="true">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('reward');" runat="server" id="A3">
                                <i class="has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-gift p-0"
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>My Privilege</strong><span style="padding-right: 30px;">สิทธิประโยชน์สำหรับเพื่อน บสย.</span>

                                </div>
                            </a>
                        </div>
                         <div id="pnlMyShop" class="list-group-item" runat="server" visible="true" style="border:1px white solid">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('rewardShop');" runat="server" id="A5">
                                <i class="has-bg1 gradient-green shadow-bg shadow-bg-xs color-white rounded-s bi bi-shop p-0"
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>My Shop</strong><span style="padding-right: 30px;">จัดการร้านค้า ลูกค้า บสย.</span>

                                </div>
                            </a>
                        </div>

                        <div id="pnlDirectGuarantee" class="list-group-item" runat="server" visible="true" style="display:none;">
                            <a href="#" class="d-flex" style="border: none; color: black;" data-trigger-switch="switch-5"
                                onclick="RedirectToPage('LOA');" runat="server" id="A4">
                                <i class="has-bg1 gradient-pink shadow-bg shadow-bg-xs color-white rounded-s bi bi-file-earmark-text p-0"
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>My LOA</strong><span style="padding-right: 30px;">Letter of Guarantee Advisor</span></div>
                            </a>
                        </div>

                        <%--<a href="#" class="list-group-item" data-trigger-switch="switch-5" onclick="redirectToContactDoctor()" runat="server" id="btnContactDoctor">
                            <i class="has-bg1 gradient-teal shadow-bg shadow-bg-xs color-white rounded-s bi bi-pie-chart-fill p-0"
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>นัดหมายหมอหนี้ </strong><span>จองคิวหมอที่ต้องการปรึกษา</span></div>
                        </a>

                        <a href="#" class="list-group-item" data-trigger-switch="switch-5" onclick="RedirectToPage('product')" runat="server" id="btnProductFeature">
                            <i class="has-bg1 gradient-green shadow-bg shadow-bg-xs color-white rounded-s bi bi-receipt-cutoff p-0 "
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>ตรวจสอบคุณสมบัติเบื้องต้นของการเข้าร่วมผลิตภัณฑ์</strong><span>(เข้าร่วมร่วมโครงการกับ บสย)</span></div>
                        </a>--%>

                        <a href="#" class="list-group-item" onclick="RedirectToPage('healthcheck')" runat="server" id="btnHealthCheckFeature" style="display: none;">
                            <i class="has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-patch-question p-0"
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>ตรวจสุขภาพทางการเงินกับ บสย.</strong><span>(ไม่มีผลต่อการพิจารณาคํ้าประกันสินเชื่อของ บสย)</span></div>
                        </a>

                        <a href="#" class="list-group-item" onclick="redirectToEventBanner2()" runat="server" style="border-bottom: none;display:none;">
                            <i class="has-bg1 gradient-teal shadow-bg shadow-bg-xs color-white rounded-s bi bi-virus p-0"
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>มาตรการพักชำระหนี้ตามนโยบายรัฐ Code 21</strong><span>(เข้าร่วมคำขอพักชำระหนี้ กับบสย.)</span></div>
                        </a>

                        <a href="#" class="list-group-item" data-trigger-switch="switch-5" onclick="RedirectToPage('debt')" runat="server" id="btnDebtFeature" style="display: none;">
                            <i class="has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 "
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>ลงทะเบียนแก้หนี้</strong><span style="padding-right: 30px;">(เข้าร่วมมาตรการแก้หนี้กับ บสย.)</span></div>
                            <div class="align-self-center ms-auto text-end">
                            </div>
                        </a>

                        <a href="#" class="list-group-item" data-trigger-switch="switch-5" onclick="RedirectToPage('event')" runat="server" id="btnEventFeature" style="display: none;">
                            <i class="has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar3 p-0 "
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>ลงทะเบียนเข้าร่วมกิจกรรม</strong><span style="padding-right: 30px;">(เข้าร่วมกิจกรรมกับ บสย.)</span></div>
                            <div class="align-self-center ms-auto text-end">
                            </div>
                        </a>

                        <a href="#" class="list-group-item" data-trigger-switch="switch-5" onclick="" runat="server" id="btnPersonalQR">
                            <i class="has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar3 p-0 "
                                style="margin-right: 10px; font-size: 24px;"></i>
                            <div><strong>My QR</strong><span style="padding-right: 30px;">แสดง QR เพื่อเข้าร่วมกิจกรรม</span></div>
                            <div class="align-self-center ms-auto text-end">
                            </div>
                        </a>



                        <%--    <div id="pnlNdidEFormMenu" runat="server" visible="true">
                            <a href="#" class="list-group-item" style="border: none;" data-trigger-switch="switch-5" onclick="RedirectToPage('eform_ndid')" runat="server" id="btnNDIDRedirect">
                                <i class="has-bg1 gradient-yellow shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-bounding-box p-0  "
                                    style="margin-right: 10px; font-size: 24px;"></i>
                                <div><strong>ยืนยันตัวตนกับ บสย.</strong><span>พิสูจน์ตัวตนก่อนทำธุรกรรมกับ บสย.</span></div>
                            </a>
                        </div>--%>
                    </div>

                </div>
            </div>

            <div class="content my-0 mt-n2 px-1">
                <div class="d-flex">
                    <div class="align-self-center">
                        <h3 class="font-16 mb-2 color-black">กิจกรรมโครงการ</h3>
                    </div>
                </div>
            </div>

            <%--event banner link google from use 21/02/2567
            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://forms.gle/gBTK3fzetVAuCHjr6" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="A3">
                            <img src="images/Banner/Banner_TCG33Years_01.jpg" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>
            --%>

            <%--event banner link google from use 21/02/2567
            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://forms.gle/gBTK3fzetVAuCHjr6" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="A3">
                            <img src="images/Banner/Banner_TCG33Years_01.jpg" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>
            --%>
            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="#" onclick="RedirectToPage('healthcheck_PGS11')" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="PGS11">
                            <img src="images/Banner/PGS11_new.jpg" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>

            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://forms.gle/qZfRB8Dedm3Vfy8Y6" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="bannerInundation">
                            <img src="images/Banner/inundation_2.png" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>


            <div class="card card-style" style="display: block; margin-bottom: 10px !important" id="TccProject">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="#" onclick="RedirectToPage('TCCProject')" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/BannerTCCProject_1.jpg" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>


            <div class="card card-style" style="display: block; margin-bottom: 10px !important" id="dipromFeature">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="#" onclick="RedirectToPage('diprom')" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/Banner_DIPROM_02.png" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>

            <div class="card card-style" style="display: none; margin-bottom: 10px !important" id="bannerEvent2">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="#" onclick="redirectToEventBanner2()" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/EventBannerDebt_1_2.png" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>


       
            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://www.gsb.or.th/gsb_govs/loan4idpc/" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/GSBBannerPWIN.png" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>


            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://www.tcg.or.th/news_inside.php?news_id=7031" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/TCGGSB_ReNano_01.jpg" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>

            <%--            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://docs.google.com/forms/d/e/1FAIpQLSeI85snYaTi7S_sqeWf6jReA9EQ43FpRCG214DhoEgY2Cy2FQ/viewform" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/bussinessSchoolbanner_3.png" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>--%>

            <div class="card card-style" style="display: none; margin-bottom: 10px !important" id="bannerEvent1">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="#" onclick="redirectToEventBanner()" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5">
                            <img src="images/Banner/BannerEvent1_4.jpg" style="max-height: 200px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>

            <div class="card card-style" style="margin-bottom: 10px !important">
                <div class="content" style="margin: 0px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs ">
                        <a href="https://forms.exim.go.th/S1?suggest=EEAE848C-06AF-4F3B-8E56-4DC6C711A172" style="padding: 0px; margin: 0px;" class="list-group-item" data-trigger-switch="switch-5" runat="server" id="A1">
                            <img src="images/S1Logo/s1.png" style="height: 120px; width: 100%;" />
                        </a>
                    </div>
                </div>
            </div>


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
