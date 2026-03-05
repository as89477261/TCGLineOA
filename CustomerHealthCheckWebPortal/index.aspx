<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="preloader">
        <div class="spinner-border color-highlight" role="status"></div>
    </div>

    <!-- Page Wrapper-->
    <div id="page">

        <!-- Footer Bar -->
        <div id="footer-bar" class="footer-bar-1 footer-bar-detached">
            <!--<a href="page-wallet.html"><i class="bi bi-wallet2"></i><span>Cards</span></a>-->
            <a href="activity.html"><i class="bi bi-patch-question"></i><span>ประวัติการตรวจ</span></a>
            <a href="index.html" class="circle-nav-2"><i class="bi bi-house-fill"></i><span>หน้าหลัก</span></a>
            <a href="profile.html"><i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span></a>
            <!--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-sidebar"><i class="bi bi-three-dots"></i><span>More</span></a>-->
        </div>

        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear">

            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <!--<p class="color-white opacity-80 header-date"></p>-->

                        <h1 class="color-white">บสย. ยินดีต้อนรับ</h1>
                        <asp:Label ID="lblUID" Text="" runat="server" />
                    </div>
                    <div class="align-self-center ms-auto">
                        <!--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-highlights" class="icon bg-white color-theme rounded-m shadow-xl">
                            <i class="bi bi-palette-fill color-black font-16"></i>
                        </a>-->
                        <!--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-notifications" class="icon bg-white color-theme rounded-m shadow-xl">
                            <i class="bi bi-bell-fill color-black font-17"></i>-->
                        <!--<em class="badge bg-red-light color-white scale-box">3</em>-->
                        <!--</a>-->

                    </div>
                </div>
            </div>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>


            <div class="card card-style bg-2" style="height: 150px">
                <div class="card-bottom p-3">
                    <!--<h1 class="color-white mb-0">โลโก้ บสย.</h1>
                    <p class="color-white mb-0 opacity-60">
                        รวดเร็ว ทันใจ ที่หนึ่งในใจ SME
                    </p>-->
                </div>
                <div class="card-overlay bg-gradient"></div>
            </div>










            <!--Account Activity Notification-->
            <div class="card card-style gradient-blue shadow-bg shadow-bg-s">
                <div class="content">
                    <a href="https://chatclinic.tcg.or.th/customerHealthTest/ui/default.aspx" class="d-flex">
                        <div class="align-self-center">
                            <h1 class="mb-0 font-40"><i class="bi bi-patch-question color-white pe-3"></i></h1>
                        </div>
                        <div class="align-self-center">
                            <h5 class="color-white font-700 mb-0 mt-0 pt-1">ทดสอบสถานะการเงินกับ
                                <br>
                                บสย. หมอหนี้.
                            </h5>
                        </div>
                        <div class="align-self-center ms-auto">
                            <i class="bi bi-arrow-right-short color-white d-block pt-1 font-20 opacity-50"></i>
                        </div>
                    </a>
                </div>
            </div>







            <!-- Quick Actions -->
            <!--<div class="content py-2">
                <div class="d-flex text-center">
                    <div class="me-auto">
                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-transfer" class="icon icon-xxl rounded-m bg-theme shadow-m"><i class="font-28 color-green-dark bi bi-arrow-up-circle"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Transfer</h6>
                    </div>
                    <div class="m-auto">
                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="icon icon-xxl rounded-m bg-theme shadow-m"><i class="font-28 color-red-dark bi bi-arrow-down-circle"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Request</h6>
                    </div>
                    <div data-bs-toggle="offcanvas" data-bs-target="#menu-exchange" class="m-auto">
                        <a href="#" class="icon icon-xxl rounded-m bg-theme shadow-m"><i class="font-28 color-blue-dark bi bi-arrow-repeat"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Exchange</h6>
                    </div>
                    <div class="ms-auto">
                        <a href="page-payment-bill.html" class="icon icon-xxl rounded-m bg-theme shadow-m"><i class="font-28 color-brown-dark bi bi-filter-circle"></i></a>
                        <h6 class="font-13 opacity-80 font-500 mb-0 pt-2">Bills</h6>
                    </div>
                </div>
            </div>-->
            <!-- Recent Activity Title-->
            <div class="content my-0 mt-n2 px-1">
                <div class="d-flex">
                    <div class="align-self-center">
                        <h3 class="font-16 mb-2 color-black">ประวัติตรวจสถานะหนี้</h3>
                    </div>
                    <div class="align-self-center ms-auto">
                        <a href="activity.html" class="font-12 pt-1">ดูทั้งหมด</a>
                    </div>
                </div>
            </div>

            <!-- Recent Activity Cards-->
            <div class="card card-style">
                <div class="content">

                    <a href="page-activity.html" class="d-flex py-1">
                        <div class="align-self-center">
                            <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-s"><i class="bi bi-caret-up-fill color-white"></i></span>
                        </div>
                        <div class="align-self-center ps-1">
                            <h5 class="pt-1 mb-n1">ตรวจสอบครั้งที่ 1</h5>
                            <p class="mb-0 font-11 opacity-50">14th March <span class="copyright-year"></span></p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1 color-blue-dark">ปกติ</h4>
                            <!--<p class="mb-0 font-11">Stock Update</p>-->
                        </div>
                    </a>
                    <div class="divider my-2 opacity-50"></div>
                    <a href="page-activity.html" class="d-flex py-1">
                        <div class="align-self-center">
                            <span class="icon rounded-s me-2 gradient-yellow shadow-bg shadow-bg-s"><i class="bi bi-pie-chart-fill color-white"></i></span>
                        </div>
                        <div class="align-self-center ps-1">
                            <h5 class="pt-1 mb-n1">ตรวจสอบครั้งที่ 2</h5>
                            <p class="mb-0 font-11 opacity-50">13th March <span class="copyright-year"></span></p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1 color-green-dark">เสี่ยง</h4>
                            <!--<p class="mb-0 font-11">Wire Transfer</p>-->
                        </div>
                    </a>

                </div>

            </div>



        </div>
        <!-- End of Page Content-->
        <!-- Off Canvas and Menu Elements-->
        <!-- Always outside the Page Content-->
        <!-- Main Sidebar Menu -->
        <div id="menu-sidebar" data-menu-active="nav-welcome" data-menu-load="menu-sidebar.html"
            class="offcanvas offcanvas-start offcanvas-detached rounded-m">
        </div>

        <!-- Card Menu More -->
        <div id="menu-card-more" data-menu-load="menu-card-settings.html"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m">
        </div>

        <!-- Transfer Button Menu -->
        <div id="menu-transfer" data-menu-load="menu-transfer.html"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m">
        </div>

        <!-- Transfer Friends Menu -->
        <div id="menu-friends-transfer" data-menu-load="menu-friends-transfer.html"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m">
        </div>

        <!-- Request Button Menu -->
        <div id="menu-request" data-menu-load="menu-request.html"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m">
        </div>

        <!-- Exchange Button Menu -->
        <div id="menu-exchange" data-menu-load="menu-exchange.html"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m">
        </div>

        <!-- Notifications Bell -->
        <div id="menu-notifications" data-menu-load="menu-notifications.html"
            class="offcanvas offcanvas-top offcanvas-detached rounded-m">
        </div>

        <!-- Highlights Menu -->
        <div id="menu-highlights"
            data-menu-load="menu-highlights.html"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m">
        </div>

        <div class="offcanvas offcanvas-bottom rounded-m offcanvas-detached" id="menu-install-pwa-ios">
            <div class="content">
                <img src="app/icons/icon-128x128.png" alt="img" width="80" class="rounded-m mx-auto my-4">
                <h1 class="text-center">Install PayApp</h1>
                <p class="boxed-text-xl">
                    Install PayApp on your home screen, and access it just like a regular app. Open your Safari menu and tap "Add to Home Screen".
               
                </p>
                <a href="#" class="pwa-dismiss close-menu color-theme text-uppercase font-900 opacity-50 font-11 text-center d-block mt-n2" data-bs-dismiss="offcanvas">Maybe Later</a>
            </div>
        </div>

        <div class="offcanvas offcanvas-bottom rounded-m offcanvas-detached" id="menu-install-pwa-android">
            <div class="content">
                <img src="app/icons/icon-128x128.png" alt="img" width="80" class="rounded-m mx-auto my-4">
                <h1 class="text-center">Install PayApp</h1>
                <p class="boxed-text-l">
                    Install PayApp to your Home Screen to enjoy a unique and native experience.
               
                </p>
                <a href="#" class="pwa-install btn btn-m rounded-s text-uppercase font-900 gradient-highlight shadow-bg shadow-bg-s btn-full">Add to Home Screen</a><br>
                <a href="#" data-bs-dismiss="offcanvas" class="pwa-dismiss close-menu color-theme text-uppercase font-900 opacity-60 font-11 text-center d-block mt-n1">Maybe later</a>
            </div>
        </div>



    </div>
    <!-- End of Page ID-->

    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/custom.js"></script>
</asp:Content>
