<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="merchant_Dashboard_KM.aspx.cs" Inherits="CustomerHealthCheck.merchant_Dashboard_KM" %>

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
                        <a href="#" onclick="redirectToMerchant_KM()"
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
                                        <i class="has-bg gradient-green shadow-bg shadow-bg-xs color-white rounded-xs bi bi-credit-card"></i>
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




            <!-- Page Title-->
            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>



            <div class="card card-style px-0">
                <div class="form-custom form-label form-border form-icon px-3 pt-1">
                    <i class="bi bi-calendar font-13"></i>
                    <select class="form-select rounded-xs" id="c6a">
                        <option value="0" selected="">ภาพรวมทั้งหมด</option>
                        <option value="01">January</option>
                        <option value="02">February</option>
                        <option value="03">March</option>
                        <option value="04">April</option>
                        <option value="05">May</option>
                        <option value="06">June</option>
                        <option value="07">July</option>
                        <option value="08">August</option>
                        <option value="09">September</option>
                        <option value="10">Octomber</option>
                        <option value="11">November</option>
                        <option value="12">December</option>
                    </select>
                </div>
                <div class="position-relative">
                    <div class="position-absolute w-100" style="height: 320px">
                        <div class="card-center">
                            <h1 class="pb-5 mb-5 text-center">
                                <span class="font-25 d-block pt-4 mt-1">ใช้ไป 10</span>
                                <span class="font-12 font-400 opacity-50 d-block mt-n2">จากคูปองทั้งหมด 25 </span>
                            </h1>
                        </div>
                    </div>
                    <div class="mx-auto" style="width: 320px; position: relative;">
                        <div class="chart mx-auto no-click" id="chart-activity" style="min-height: 249.467px;">
                            <div id="apexchartsl4pb4c4g" class="apexcharts-canvas apexchartsl4pb4c4g apexcharts-theme-light" style="width: 320px; height: 249.467px;">
                                <svg id="SvgjsSvg1023" width="320" height="249.46666666666667" xmlns="http://www.w3.org/2000/svg" version="1.1" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:svgjs="http://svgjs.com/svgjs" class="apexcharts-svg" xmlns:data="ApexChartsNS" transform="translate(0, 0)" style="background: transparent;">
                                    <g id="SvgjsG1025" class="apexcharts-inner apexcharts-graphical" transform="translate(39.66666666666666, 0)">
                                        <defs id="SvgjsDefs1024">
                                            <clipPath id="gridRectMaskl4pb4c4g">
                                                <rect id="SvgjsRect1027" width="246.66666666666669" height="264.6666666666667" x="-2" y="0" rx="0" ry="0" opacity="1" stroke-width="0" stroke="none" stroke-dasharray="0" fill="#fff"></rect>
                                            </clipPath>
                                            <clipPath id="gridRectMarkerMaskl4pb4c4g">
                                                <rect id="SvgjsRect1028" width="246.66666666666669" height="268.6666666666667" x="-2" y="-2" rx="0" ry="0" opacity="1" stroke-width="0" stroke="none" stroke-dasharray="0" fill="#fff"></rect>
                                            </clipPath>
                                        </defs>
                                        <g id="SvgjsG1029" class="apexcharts-pie">
                                            <g id="SvgjsG1030" transform="translate(0, 0) scale(1)">
                                                <circle id="SvgjsCircle1031" r="74.34308943089431" cx="121.33333333333334" cy="121.33333333333334" fill="transparent"></circle>
                                                <g id="SvgjsG1032" class="apexcharts-slices">
                                                    <g id="SvgjsG1033" class="apexcharts-series apexcharts-pie-series" seriesName="seriesx1" rel="1" data:realIndex="0">
                                                        <path id="SvgjsPath1034" d="M 121.33333333333334 6.959349593495929 A 114.37398373983741 114.37398373983741 0 0 1 184.626929388255 26.06881289179121 L 162.4741707690324 59.411395046330966 A 74.34308943089431 74.34308943089431 0 0 0 121.33333333333334 46.99024390243903 L 121.33333333333334 6.959349593495929 z" fill="rgba(218, 68, 83,1)" fill-opacity="1" stroke-opacity="1" stroke-linecap="butt" stroke-width="0" stroke-dasharray="0" class="apexcharts-pie-area apexcharts-donut-slice-0" index="0" j="0" data:angle="33.6" data:startAngle="0" data:strokeWidth="0" data:value="14" data:pathOrig="M 121.33333333333334 6.959349593495929 A 114.37398373983741 114.37398373983741 0 0 1 184.626929388255 26.06881289179121 L 162.4741707690324 59.411395046330966 A 74.34308943089431 74.34308943089431 0 0 0 121.33333333333334 46.99024390243903 L 121.33333333333334 6.959349593495929 z"></path>
                                                    </g>
                                                    <g id="SvgjsG1035" class="apexcharts-series apexcharts-pie-series" seriesName="seriesx2" rel="2" data:realIndex="1">
                                                        <path id="SvgjsPath1036" d="M 184.626929388255 26.06881289179121 A 114.37398373983741 114.37398373983741 0 0 1 66.23324644501685 221.56001930778112 L 85.51827685592764 186.48067921672438 A 74.34308943089431 74.34308943089431 0 0 0 162.4741707690324 59.411395046330966 L 184.626929388255 26.06881289179121 z" fill="rgba(140, 193, 82,1)" fill-opacity="1" stroke-opacity="1" stroke-linecap="butt" stroke-width="0" stroke-dasharray="0" class="apexcharts-pie-area apexcharts-donut-slice-1" index="0" j="1" data:angle="175.2" data:startAngle="33.6" data:strokeWidth="0" data:value="73" data:pathOrig="M 184.626929388255 26.06881289179121 A 114.37398373983741 114.37398373983741 0 0 1 66.23324644501685 221.56001930778112 L 85.51827685592764 186.48067921672438 A 74.34308943089431 74.34308943089431 0 0 0 162.4741707690324 59.411395046330966 L 184.626929388255 26.06881289179121 z"></path>
                                                    </g>
                                                    <g id="SvgjsG1037" class="apexcharts-series apexcharts-pie-series" seriesName="seriesx3" rel="3" data:realIndex="2">
                                                        <path id="SvgjsPath1038" d="M 66.23324644501685 221.56001930778112 A 114.37398373983741 114.37398373983741 0 0 1 9.981235726669766 95.2159346283195 L 48.95446988900203 104.35702417507434 A 74.34308943089431 74.34308943089431 0 0 0 85.51827685592764 186.48067921672438 L 66.23324644501685 221.56001930778112 z" fill="rgba(74, 137, 220,1)" fill-opacity="1" stroke-opacity="1" stroke-linecap="butt" stroke-width="0" stroke-dasharray="0" class="apexcharts-pie-area apexcharts-donut-slice-2" index="0" j="2" data:angle="74.4" data:startAngle="208.79999999999998" data:strokeWidth="0" data:value="31" data:pathOrig="M 66.23324644501685 221.56001930778112 A 114.37398373983741 114.37398373983741 0 0 1 9.981235726669766 95.2159346283195 L 48.95446988900203 104.35702417507434 A 74.34308943089431 74.34308943089431 0 0 0 85.51827685592764 186.48067921672438 L 66.23324644501685 221.56001930778112 z"></path>
                                                    </g>
                                                    <g id="SvgjsG1039" class="apexcharts-series apexcharts-pie-series" seriesName="seriesx4" rel="4" data:realIndex="3">
                                                        <path id="SvgjsPath1040" d="M 9.981235726669766 95.2159346283195 A 114.37398373983741 114.37398373983741 0 0 1 54.10599244511778 28.802836773440973 L 77.63556175599322 61.18851056940331 A 74.34308943089431 74.34308943089431 0 0 0 48.95446988900203 104.35702417507434 L 9.981235726669766 95.2159346283195 z" fill="rgba(55, 188, 155,1)" fill-opacity="1" stroke-opacity="1" stroke-linecap="butt" stroke-width="0" stroke-dasharray="0" class="apexcharts-pie-area apexcharts-donut-slice-3" index="0" j="3" data:angle="40.80000000000001" data:startAngle="283.2" data:strokeWidth="0" data:value="17" data:pathOrig="M 9.981235726669766 95.2159346283195 A 114.37398373983741 114.37398373983741 0 0 1 54.10599244511778 28.802836773440973 L 77.63556175599322 61.18851056940331 A 74.34308943089431 74.34308943089431 0 0 0 48.95446988900203 104.35702417507434 L 9.981235726669766 95.2159346283195 z"></path>
                                                    </g>
                                                    <g id="SvgjsG1041" class="apexcharts-series apexcharts-pie-series" seriesName="seriesx5" rel="5" data:realIndex="4">
                                                        <path id="SvgjsPath1042" d="M 54.10599244511778 28.802836773440973 A 114.37398373983741 114.37398373983741 0 0 1 121.31337130748584 6.959351335511315 L 121.32035801653247 46.99024503474904 A 74.34308943089431 74.34308943089431 0 0 0 77.63556175599322 61.18851056940331 L 54.10599244511778 28.802836773440973 z" fill="rgba(150, 122, 220,1)" fill-opacity="1" stroke-opacity="1" stroke-linecap="butt" stroke-width="0" stroke-dasharray="0" class="apexcharts-pie-area apexcharts-donut-slice-4" index="0" j="4" data:angle="36" data:startAngle="324" data:strokeWidth="0" data:value="15" data:pathOrig="M 54.10599244511778 28.802836773440973 A 114.37398373983741 114.37398373983741 0 0 1 121.31337130748584 6.959351335511315 L 121.32035801653247 46.99024503474904 A 74.34308943089431 74.34308943089431 0 0 0 77.63556175599322 61.18851056940331 L 54.10599244511778 28.802836773440973 z"></path>
                                                    </g>
                                                </g>
                                            </g>
                                        </g>
                                        <line id="SvgjsLine1043" x1="0" y1="0" x2="242.66666666666669" y2="0" stroke="#b6b6b6" stroke-dasharray="0" stroke-width="1" class="apexcharts-ycrosshairs"></line>
                                        <line id="SvgjsLine1044" x1="0" y1="0" x2="242.66666666666669" y2="0" stroke-dasharray="0" stroke-width="0" class="apexcharts-ycrosshairs-hidden"></line>
                                    </g><g id="SvgjsG1026" class="apexcharts-annotations"></g></svg><div class="apexcharts-legend" style="max-height: 133.333px;"></div>
                            </div>
                        </div>
                        <div class="resize-triggers">
                            <div class="expand-trigger">
                                <div style="width: 321px; height: 250px;"></div>
                            </div>
                            <div class="contract-trigger"></div>
                        </div>
                    </div>
                </div>
                <h6 class="text-center opacity-30 pb-3">Tap an Item below for More Details</h6>
                <div class="content mt-0 mb-0">
                    <a data-bs-toggle="offcanvas" data-bs-target="#menu-activity" href="#" class="d-flex pb-3">
                        <div class="align-self-center">
                            <span class="icon rounded-s me-2 gradient-red shadow-bg shadow-bg-xs"><i class="bi bi-droplet font-18 color-white"></i></span>
                        </div>
                        <div class="align-self-center ps-1">
                            <h5 class="pt-1 mb-n1">จำนวนการใช้คูปองทั้งหมด</h5>
                            <p class="mb-0 font-11 opacity-50">12 Transactions</p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1 color-red-dark">10</h4>
                            <p class="mb-0 font-12 opacity-50">45.53%</p>
                        </div>
                    </a>
                    <a data-bs-toggle="offcanvas" data-bs-target="#menu-activity" href="#" class="d-flex pb-3">
                        <div class="align-self-center">
                            <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-xs"><i class="bi bi-wallet font-18 color-white"></i></span>
                        </div>
                        <div class="align-self-center ps-1">
                            <h5 class="pt-1 mb-n1">รายได้ประมาณการจากการใช้คูปอง</h5>
                            <p class="mb-0 font-11 opacity-50">15 Transactions</p>
                        </div>
                        <div class="align-self-center ms-auto text-end">
                            <h4 class="pt-1 mb-n1 color-green-dark">$4530.55</h4>
                            <p class="mb-0 font-12 opacity-50">41.27%</p>
                        </div>
                    </a>
                   
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
