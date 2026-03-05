<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerHealthCheck.views.Request.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Wrapper-->
    <div id="page">


        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear" style="padding-bottom: 0px !important;">
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
            <%--            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <h2 class="color-white" style="color: #092d74 !important;">My LG </h2>
                    </div>

                </div>
            </div>--%>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>


            <asp:Panel runat="server" ID="pnlEmptyLG" Visible="false">
                <div>
                    ไม่พบ LG ที่เกี่ยวข้อง
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlLG">

                <!-- Main Card Slider-->
                <div class="splide single-slider slider-no-dots slider-no-arrows slider-visible" id="single-slider-1">
                    <div class="splide__track">

                        <%--<asp:Panel CssClass="splide__list" runat="server" ID="pnlLGItems"></asp:Panel>--%>

                        <div class="splide__list">


                            <div class="splide__slide">
                                <div class="card card-style m-0 bg-5 shadow-card shadow-card-m" style="height: 200px">
                                    <div class="card-top p-3">
                                    </div>
                                    <div class="card-center">
                                        <div class="bg-theme px-3 py-2 rounded-end d-inline-block">
                                            <h1 class="font-13 my-n1">
                                                <a class="color-theme" data-bs-toggle="collapse" href="#balance3" aria-controls="balance2">ดูยอดการคํ้า</a>
                                            </h1>
                                            <div class="collapse" id="balance2">
                                                <h2 class="color-theme font-26">26,315 บาท</h2>
                                            </div>
                                        </div>
                                    </div>
                                    <strong class="card-top no-click font-14 p-3 color-white font-monospace">Request No. 66-00001</strong>

                                    <div class="card-overlay bg-black opacity-50"></div>
                                </div>
                            </div>
                            <div class="splide__slide">
                                <div class="card card-style m-0 bg-5 shadow-card shadow-card-m" style="height: 200px">
                                    <div class="card-top p-3">
                                    </div>
                                    <div class="card-center">
                                        <div class="bg-theme px-3 py-2 rounded-end d-inline-block">
                                            <h1 class="font-13 my-n1">
                                                <a class="color-theme" data-bs-toggle="collapse" href="#balance3" aria-controls="balance2">ดูยอดการคํ้า</a>
                                            </h1>
                                            <div class="collapse" id="balance3">
                                                <h2 class="color-theme font-26">26,315 บาท</h2>
                                            </div>
                                        </div>
                                    </div>
                                    <strong class="card-top no-click font-14 p-3 color-white font-monospace">Request No. 66-00002</strong>

                                    <div class="card-overlay bg-black opacity-50"></div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>

                <!-- Tabs-->
                <div class="card card-style">
                    <div class="content mb-0">

                        <!-- Tab Wrapper-->
                        <div class="tabs tabs-pill" id="tab-group-2">
                            <!-- Tab Controls -->
                            <div class="tab-controls rounded-m p-1">
                                <a class="font-13 rounded-m" data-bs-toggle="collapse" href="#tab-4" aria-expanded="true">รายละเอียด</a>
                                <%--   <a class="font-13 rounded-m" data-bs-toggle="collapse" href="#tab-5" aria-expanded="false">ประวัติชำระเงิน</a>                          --%>
                            </div>

                            <!-- Tab 1 -->
                            <div class="mt-3"></div>
                            <div class="collapse show" id="tab-4" data-bs-parent="#tab-group-2" style="padding: 5px; text-align: center;">
                                <h4>ใบคำขอให้คํ้าประกันสินเชื่อ</h4>
                                <div class="row mb-3 mt-4">
                                    <h5 class="col-4 text-start font-15">โครงการ</h5>
                                    <h5 class="col-8 text-end font-14 opacity-60 font-400">

                                        <asp:Label Text="PGS 10" ID="ltlProjectName" runat="server" ClientIDMode="Static" /></h5>
                                    <h5 class="col-4 text-start font-15">เลขคำขอ</h5>
                                    <%--  <h5 class="col-8 text-end font-14 font-400"><span class="bg-green-dark px-2 rounded-s">Paid</span></h5>--%>
                                    <h5 class="col-8 text-end font-14 font-400">
                                        <asp:Label Text="66-00001" ID="ltlBankName" runat="server" ClientIDMode="Static" /></h5>
                                    <h5 class="col-4 text-start font-15">วันที่ยื่น</h5>
                                    <h5 class="col-8 text-end font-14 opacity-60 font-400">
                                        <asp:Label Text="08/03/2566" ID="ltlCreateDate" runat="server" ClientIDMode="Static" /></h5>
                                    <h5 class="col-4 text-start font-15">สถานะ</h5>
                                    <h5 class="col-8 text-end font-14 opacity-60 font-400">
                                        <asp:Label Text="อยู่ระหว่างดำเนินการ" ID="ltlRequestName" runat="server" ClientIDMode="Static" ForeColor="#cc9900" Font-Bold="true" /></h5>

                                    
                                </div>
                                <%--  <a href="#" class="btn btn-full btn-l rounded-s font-800 text-uppercase gradient-green shadow-bg shadow-bg-m mb-3">ดาวน์โหลดหนังสือคํ้าประกัน (PDF)</a>--%>
                            </div>

                            <!-- Tab 2-->
                            <div class="collapse" id="tab-5" data-bs-parent="#tab-group-2">
                                <div class="form-custom form-label form-border form-icon mt-0 mb-0">
                                    <i class="bi bi-check-circle font-13"></i>
                                    <select class="form-select rounded-xs" id="c6" aria-label="Floating label select example">
                                        <option selected>ย้อนหลังล่าสุด</option>
                                        <option value="1">ย้อน 3 เดือน</option>
                                        <option value="2">ย้อน 9 เดือน</option>
                                        <option value="3">ย้อน 1 ปี</option>
                                    </select>
                                </div>
                                <div class="list-group list-custom list-group-m list-group-flush rounded-xs">
                                    <a href="#" class="list-group-item">
                                        <i class="has-bg gradient-green color-white rounded-xs bi bi-cash-coin"></i>
                                        <div style="margin-left: 10px;"><strong>ชำระเงินงวดที่ 3</strong><span>13 ม.ค. 2565</span></div>
                                        <span class="badge bg-transparent color-theme text-end font-15">52,482.5 บาท<br>
                                            <em class="fst-normal font-12 opacity-30">1.75%</em>
                                        </span>
                                    </a>
                                    <a href="#" class="list-group-item">
                                        <i class="has-bg gradient-green color-white rounded-xs bi bi-droplet"></i>
                                        <div style="margin-left: 10px;"><strong>ชำระเงินงวดที่ 2</strong><span>13 ม.ค. 2565</span></div>
                                        <span class="badge bg-transparent color-theme text-end font-15">52,482.5 บาท<br>
                                            <em class="fst-normal font-12 opacity-30">1.75%</em>
                                        </span>
                                    </a>
                                    <a href="#" class="list-group-item">
                                        <i class="has-bg gradient-green color-white rounded-xs bi bi-bag"></i>
                                        <div style="margin-left: 10px;"><strong>ชำระเงินงวดที่ 1</strong><span>13 ม.ค. 2565</span></div>
                                        <span class="badge bg-transparent color-theme text-end font-15">52,482.5 บาท<br>
                                            <em class="fst-normal font-12 opacity-30">1.75%</em>
                                        </span>
                                    </a>

                                </div>
                            </div>


                        </div>

                        <!-- End of Tab Wrapper-->
                    </div>
                </div>

            </asp:Panel>
        </div>
    </div>

    <!-- End of Page Content-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/MyLG.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>
