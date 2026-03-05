<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true"
CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.Activity.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - History</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="preloader">
        <div class="spinner-border color-highlight" role="status"></div>
    </div>

    <!-- Page Wrapper-->
    <div id="page">

        <div id="footer-bar" class="footer-bar-1 footer-bar-detached">
            <asp:HyperLink ID="btnToActivity" NavigateUrl="~/views/Activity/index.aspx" runat="server" class="circle-nav-2">
                <i class="bi bi-journal-text"></i><span>ประวัติทำรายการ</span>
            </asp:HyperLink>
            <asp:HyperLink ID="btnToHome" NavigateUrl="~/index.aspx" runat="server">
                <i class="bi bi-house-fill"></i><span>หน้าหลัก</span>
            </asp:HyperLink>
            <asp:HyperLink ID="btnToProfile" NavigateUrl="~/views/Profile/index.aspx" runat="server">
                <i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span>
            </asp:HyperLink>


            <!--<a href="page-wallet.html"><i class="bi bi-wallet2"></i><span>Cards</span></a>-->
            <%--  <a href="activity.html" class="circle-nav-2"><i class="bi bi-patch-question"></i><span>ประวัติการตรวจ</span></a>
            <a href="index.html" ><i class="bi bi-house-fill"></i><span>หน้าหลัก</span></a>
            <a href="profile.html"><i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span></a>--%>
            <!--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-sidebar"><i class="bi bi-three-dots"></i><span>More</span></a>-->
        </div>

        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear">

            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto ">
                        <h2 class="color-white" style="color: #092d74 !important;">ประวัติทำรายการ </h2>
                    </div>

                </div>
            </div>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>

            <asp:Panel runat="server" Visible="true" ID="pnlHasRegisterProduct">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;overflow:auto;max-height:300px;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black">โครงการคํ้าประกัน บสย.</h3>
                        <div class="divider mb-0"></div>
                        <asp:Literal ID="ltlRegisterProductList" Text="" runat="server"/>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlEmptyRegisterProduct">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black" style="text-align:center;">โครงการคํ้าประกัน บสย.</h3>

                        <div class="divider mb-0"></div>
                        <div class="collapse show" ="data-bs-parent=""#tab-group-2" style="text-align:center;margin-top:10px;">
                            <h5 class="color-black opacity-50">ยังไม่มีประวัติโครงการคํ้าประกัน บสย.</h5>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:Panel runat="server" Visible="true" ID="pnlHasDebt">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;overflow:auto;max-height:300px;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black">โครงการประนอมหนี้ บสย.</h3>
                        <div class="divider mb-0"></div>
                        <asp:Literal ID="ltlDebtItem" Text="" runat="server"/>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlEmptyDept">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black" style="text-align:center;">โครงการประนอมหนี้ บสย.</h3>

                        <div class="divider mb-0"></div>
                        <div class="collapse show" ="data-bs-parent=""#tab-group-2" style="text-align:center;margin-top:10px;">
                            <h5 class="color-black opacity-50">ยังไม่มีประวัติโครงการประนอมหนี้ บสย.</h5>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:Panel runat="server" Visible="true" ID="pnlHasEvent">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;overflow:auto;max-height:300px;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black">เข้าร่วมกิจกรรมกับ บสย.</h3>
                        <div class="divider mb-0"></div>
                        <asp:Literal ID="ltlEventItem" Text="" runat="server"/>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlEmptyEvent">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black" style="text-align:center;">เข้าร่วมกิจกรรมกับ บสย.</h3>

                        <div class="divider mb-0"></div>
                        <div class="collapse show" ="data-bs-parent=""#tab-group-2" style="text-align:center;margin-top:10px;">
                            <h5 class="color-black opacity-50">ยังไม่มีประวัติเข้าร่วมโครงการกับ บสย.</h5>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:Panel runat="server" ID="pnlHasItem" Visible="false">
                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black">รายการตรวจสุขภาพทางการเงิน</h3>

                        <div class="divider mb-0"></div>

                        <div class="collapse show" id="tab-4" data-bs-parent="#tab-group-2" style="overflow:auto;max-height:300px;">
                            <asp:Literal ID="ltlHistoryItem" Text="" runat="server"/>

                            <%-- <a href="page-activity.html" class="d-flex py-1">
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
                        </a>--%>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlEmpty">

                <div class="card card-style">
                    <div class="content" style="margin-top: 5px !important;">
                        <h3 class="opacity-30 pt-1 pb-1 color-black" style="text-align:center;">รายการตรวจสุขภาพทางการเงิน</h3>

                        <div class="divider mb-0"></div>
                        <div class="collapse show" ="data-bs-parent=""#tab-group-2" style="text-align:center;margin-top:10px;">
                            <h5 class="color-black opacity-50">ยังไม่มีประวัติการตรวจสุขภาพทางการเงิน</h5>
                        </div>
                    </div>
                </div>


            </asp:Panel>


        </div>


    </div>
    <!-- End of Page ID-->
</asp:Content>