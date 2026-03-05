<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Step8.aspx.cs"
    Inherits="CustomerHealthCheck.views.LOA.Step8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content footer-clear" style="padding: 0px !important;">

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

        <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
            <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
            <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
            <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
            <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
        </svg>

        <div class="card card-style px-2 py-2">

            <div class="accordion accordion-m border-0" id="accordion-group-1">

                <div class="accordion-item" style="background-image: linear-gradient(rgb(93,156,236),rgb(74,137,220)) !important; border-radius:20px; padding: 5px !important; margin: 0px!important;">
                    <button class="accordion-button px-0 ps-1 rounded-xs" type="button" data-bs-toggle="collapse" data-bs-target="#accordion1-1" aria-expanded="true">

                        <div>
                            <%--<h4 class="mb-n1 opacity-50" style="color: azure">สถานะปัจจุบัน (9/9)</h4>--%>
                            <h3 class="pt-1 mb-n1 opacity-80" style="color: azure">อนุมัติ และออกเอกสาร (9/9)</h3>
                        </div>
                        <div class="">
                            <i class="bi bi-arrow-down-short font-25" style="color:white"></i>
                        </div>

                    </button>
                </div>

                <div class="accordion-collapse collapse collapse show" data-bs-parent="#accordion-group-1" id="accordion1-1">

                    <div class="content">
                        <h3>สรุปผลการพิจารณาเบื้องต้น</h3>
                        <div class="d-flex">
                            <div class="pt-1 ms-auto">
                                <img src="~/images/pictures/scoreStep8.png" runat="server" class="img-fluid rounded-s" width="150">
                            </div>
                            <div class="ps-3 me-auto">
                                <strong class="opacity-30 color-theme font-11">ผลการประเมิน</strong>
                                <h3 class="mt-n2 pb-2">TCG Score</h3>
                                <h3 style="color: green;">AA (410) แข็งแรง</h3>
                                <p>
                                    ผลการพิจารณาของท่านดีเยี่ยม สถานะทางการเงินของท่านพร้อมที่จะขอสินเชื่อกับธนาคาร
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="card card-style px-2 py-2" id="pnlStep3_1">
                        <div class="content">
                            <h3>ข้อมูลเอกสาร</h3>
                            <table class="table">
                                <tr>
                                    <th>หัวข้อ</th>
                                    <th>รายละเอียด</th>
                                </tr>
                                <tr>
                                    <td>วันที่ออกเอกสาร</td>
                                    <td>22 พ.ย. 2567</td>
                                </tr>
                                <tr>
                                    <td>เลขที่</td>
                                    <td>xx515xxx55xx</td>
                                </tr>
                                <tr>
                                    <td>ชื่อผู้ขอให้คำประกัน</td>
                                    <td>สมหมาย น้องสมปอง</td>
                                </tr>
                                <tr>
                                    <td>สถานะการพิจารณาเบื้องต้น</td>
                                    <td>ผ่าน</td>
                                </tr>
                            </table>
                            <h3>ข้อมูลเพิ่มเติม</h3>
                            <table class="table">
                                <tr>
                                    <th>หัวข้อ</th>
                                    <th>รายละเอียด</th>
                                </tr>
                                <tr>
                                    <td>วงเงินคำประกันเบื้องต้น</td>
                                    <td>850000 บาท</td>
                                </tr>
                                <tr>
                                    <td>วงเงินคงเหลือ</td>
                                    <td>350000 บาท</td>
                                </tr>
                                <tr>
                                    <td>ผลิตภัณฑ์ที่แนะนำ</td>
                                    <td>PGS11 Smart Biz</td>
                                </tr>
                                <tr>
                                    <td>เงื่อนไขการออกหนังสือค้ำประกัน</td>
                                    <td>-</td>
                                </tr>
                                <tr>
                                    <td>วันหมดอายุ</td>
                                    <td>20 ม.ค. 2568</td>
                                </tr>
                            </table>
                            <h5 style="text-underline-offset: inherit">คำชี้แจงที่สำคัญ</h5>
                            <ol class="mb-0 ps-3">
                                <li>การแจ้งผลพิจารณาครั้งนี้เป็นเพียงการตรวจสอบคุณสมบัติของผู้ประกอบการ SMEs ในเบื้องต้นเท่านั้น การอนุมัติวงเงินสินเชื่อขึ้นอยู่กับเงื่อนไขและนโยบายของสถาบันการเงิน</li>
                                <li>ผลการพิจารณาเบื้องต้น มีอายุ 60 วัน นับแต่วันที่อนุมัติ หากพ้นระยะเวลาดังกล่าวแล้วท่านยังไม่ได้ใช้สิทธิในการขอใช้บริการกับสถาบันการเงินรายใด ให้ถือว่าการพิจารณานี้เป็นอันสิ้นผล ทั้งนี้ บสย. ขอสงวนสิทธิ์ในการยกเลิก หรือเปลี่ยนแปลงเงื่อนไข ในการออกหนังสือค้ำประกัน หากตรวจสอบพบว่าข้อมูลที่ท่านให้ไว้ต่อ บสย. ไม่ถูกต้องตามความเป็นจริงหรือ ท่านไม่ได้ปฏิบัติตามเงื่อนไข หรือมีการเปลี่ยนแปลงสถานะไปจากเดิมอย่างมีนัยสำคัญ</li>
                            </ol>
                        </div>

                        <div class="content">
                            <div class="d-flex">
                                <div class="pt-1 ms-auto">
                                    <img src="~/images/QR/QR.jpg" runat="server" class="img-fluid rounded-s" width="150">
                                </div>
                                <div class="ps-3 me-auto">
                                    <strong class="opacity-30 color-theme font-11">สำหรับธนาคารใช้งานเท่านั้น</strong>
                                    <h3 class="mt-n2 pb-2">For Bank Use Only</h3>
                                    <p>
                                        คิวอาร์โค้ดสำหรับสร้างคำขอ TCG สำหรับธนาคารที่ท่านเลือก เท่านั้น 
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="row" id="">
                            <div class="col-12">
                                <div class="content m-0">
                                    <div class="row">
                                        <div class="col-12">
                                            <a href="#" id="btnSubmit" onclick="redirectToMain()"
                                                class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/LOA/Step5.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/jquery-1.6.4.min.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/jquery-ui-1.8.10.offset.datepicker.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/jquery-ui-1.8.10.custom.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>">
</asp:Content>
