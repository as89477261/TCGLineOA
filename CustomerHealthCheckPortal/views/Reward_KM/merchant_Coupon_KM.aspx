<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="merchant_Coupon_KM.aspx.cs" Inherits="CustomerHealthCheck.merchant_Coupon_KM" %>

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





            <!-- Page Title-->
            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>


             <div class="content">
                <div class="row">
                    <div class="col-12">
                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-exchange" 
                            class="btn btn-full btn-xs gradient-green rounded-s shadow-bg shadow-bg-s">สร้าง</a>
                    </div>
                  
                </div>
            </div>


            <div class="card card-style">
                <div class="content">
                    <div class="tabs tabs-pill" id="tab-group-2">
                        <div class="tab-controls rounded-m p-1 overflow-visible">
                            <a class="font-13 rounded-m shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-3" aria-expanded="true">กิจกรรม</a>
                            <a class="font-13 rounded-m shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-4" aria-expanded="false">คูปองร่วมรายการ</a>
                           
                        </div>
                        <div class="mt-3"></div>

                        <!-- Tab Group 1 -->
                        <div class="collapse show" id="tab-3" data-bs-parent="#tab-group-2">
                            <asp:Panel runat="server" ID="Panel1" Visible="false">
                                <asp:Literal ID="Literal1" runat="server" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="Panel2" Visible="false" Style="text-align: center;">
                                <h5 class="m-2">ไม่พบข้อมูลคู่ค้าร่วมรายการ </h5>

                                <div style="text-align: center; margin-top: 5px; margin-top: 5px;">
                                    <a href="#" data-bs-target="#checkRegisterModal"
                                        style="font-weight: 500;"
                                        class="btn btn-xs gradient-blue shadow-bg shadow-bg-xs mt-2 mb-2"
                                        onclick="redirectToHealthCheck();">ตรวจสุขภาพทางการเงิน เพื่อรับสิทธิ์</a>
                                </div>
                            </asp:Panel>



                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/e1.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>งาน TCG Money Expro</h5>
                                    <p class='mb-0 font-11 opacity-100'>อิมแพคเมืองทอง </p>
                                    <p class='mb-0 font-11 opacity-100'>เริ่ม <span class=''>31/11/2567 - 7/12/2567</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowFixModal1();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>คูปอง</span>
                                </div>
                            </a>

                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/e2.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>งาน TCG SME Festival ภูเก็ต</h5>
                                    <p class='mb-0 font-11 opacity-100'>ลานอเนกประสงค์ภูเก็ต </p>
                                    <p class='mb-0 font-11 opacity-100'>เริ่ม <span class=''>31/11/2567 - 7/12/2567</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowFixModal1();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>คูปอง</span>
                                </div>
                            </a>

                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/e3.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>งาน TCG Tech Day 2024</h5>
                                    <p class='mb-0 font-11 opacity-100'>เกษรทาวเวอร์ </p>
                                    <p class='mb-0 font-11 opacity-100'>เริ่ม <span class=''>11/11/2567 - 12/11/2567</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowFixModal1();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>คูปอง</span>
                                </div>
                            </a>





                        </div>

                        <!-- Tab Group 1 -->
                        <div class="collapse" id="tab-4" data-bs-parent="#tab-group-2">
                            <asp:Panel runat="server" ID="pnlRewardHeaderItem" Visible="false">
                                <asp:Literal ID="ltlRewardHeaderItem" runat="server" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlRewardHeaderEmpty" Visible="false" Style="text-align: center;">
                                <h5 class="m-2">ไม่พบข้อมูลคู่ค้าร่วมรายการ </h5>

                                <div style="text-align: center; margin-top: 5px; margin-top: 5px;">
                                    <a href="#" data-bs-target="#checkRegisterModal"
                                        style="font-weight: 500;"
                                        class="btn btn-xs gradient-blue shadow-bg shadow-bg-xs mt-2 mb-2"
                                        onclick="redirectToHealthCheck();">ตรวจสุขภาพทางการเงิน เพื่อรับสิทธิ์</a>
                                </div>
                            </asp:Panel>

                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/pt.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>คูปองกาแฟพันธ์ไทย 50 บาท</h5>
                                    <p class='mb-0 font-11 opacity-100'>ร้านกาแฟพันธ์ไทยทุกสาขา </p>
                                    <p class='mb-0 font-11 opacity-100'>หมดเขต <span class=''>31/12/2568</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowCondition();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>
                                </div>
                            </a>

                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/c2.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>คูปองส่วนลดค่าที่พัก 300 บาท</h5>
                                    <p class='mb-0 font-11 opacity-100'>โรงแรมพัทยาวิวดี ,หาดพัทยา ชลบุรี </p>
                                    <p class='mb-0 font-11 opacity-100'>หมดเขต <span class=''>31/12/2568</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowCondition();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>
                                </div>
                            </a>



                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/c3.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>คูปองส่วนลดไก่ย่าง 5 ดาว</h5>
                                    <p class='mb-0 font-11 opacity-100'>ไก่ย่าง 5 ดาวทุกสาขา </p>
                                    <p class='mb-0 font-11 opacity-100'>หมดเขต <span class=''>31/12/2568</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowCondition();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>
                                </div>
                            </a>



                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/c4.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>คูปองแลกรับปุ๋ยการเกษตร</h5>
                                    <p class='mb-0 font-11 opacity-100'>ร้ายเกษตรดีทั่วประเทศ</p>
                                    <p class='mb-0 font-11 opacity-100'>หมดเขต <span class=''>31/12/2568</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowCondition();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>
                                </div>
                            </a>



                            <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/c5.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>คูปองฟรีค่าดำเนินการ บสย.</h5>
                                    <p class='mb-0 font-11 opacity-100'>ใช้แนบกับช่องทางออนไลน์เท่านั้น </p>
                                    <p class='mb-0 font-11 opacity-100'>หมดเขต <span class=''>31/12/2568</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowCondition();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>
                                </div>
                            </a>





                        </div>

                    
                    </div>
                </div>
            </div>




            <div id="menu-exchange" class="offcanvas offcanvas-bottom offcanvas-detached rounded-m "
                style="display: block; visibility: visible;" aria-modal="true" role="dialog">
                <!-- menu-size will be the dimension of your menu. If you set it to smaller than your content it will scroll-->
                <div class="menu-size" style="height: 260px;">
                    <div class="d-flex mx-3 mt-3 py-1">
                        <div class="align-self-center">
                            <h1 class="mb-0">Exchange</h1>
                        </div>
                        <div class="align-self-center ms-auto">
                            <a href="#" class="ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                                <i class="bi bi-x color-red-dark font-26 line-height-xl"></i>
                            </a>
                        </div>
                    </div>
                    <div class="divider divider-margins mt-3"></div>
                    <div class="content mt-0">
                        <div class="row mt-n3">
                            <div class="col-5">
                                <div class="form-custom form-label form-border">
                                    <select class="form-select color-blue-dark exchange-select rounded-xs border-0" id="cura">
                                        <option value="0" selected="">USD</option>
                                        <option value="1">EUR</option>
                                        <option value="2">BTC</option>
                                        <option value="3">ETH</option>
                                    </select>
                                </div>
                                <div class="form-custom form-label form-border">
                                    <div class="form-custom form-label">
                                        <input type="number" class="form-control exchange-value border-0 rounded-xs" id="val1a" placeholder="50.00">
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <h5 class="exchange-arrow"><i class="bi bi-arrow-left-right"></i></h5>
                            </div>
                            <div class="col-5">
                                <div class="form-custom form-label form-border">
                                    <select class="form-select color-blue-dark exchange-select rounded-xs border-0" id="curb">
                                        <option value="0" selected="">EUR</option>
                                        <option value="1">USD</option>
                                        <option value="2">BTC</option>
                                        <option value="3">ETH</option>
                                    </select>
                                </div>
                                <div class="form-custom form-label form-border">
                                    <div class="form-custom form-label">
                                        <input type="number" class="form-control exchange-value border-0 rounded-xs" id="val2a" placeholder="43.35">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <a href="#" data-bs-dismiss="offcanvas" class="mx-3 btn btn-full gradient-red shadow-bg shadow-bg-s">Convert and Add to Account</a>
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
