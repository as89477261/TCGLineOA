<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.Cal.LG.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - Calculator</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Wrapper-->
    <div id="page">
        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content " style="padding: 0px !important; min-height: 100%;">
            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center">
                        <a href="#" onclick="redirectToCal()"
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
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <h3 class="color-white" style="color: #092d74 !important;">คำนวณค่างวดสินเชื่อและค้ำประกัน</h3>
                    </div>

                </div>
            </div>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>

            <div class="card-body overflow-visible card-style" id="pnlInfo" style="display: block;">
                <div class="content mb-0">
                    <h3>แบบประเมินการชำระค่างวดสินเชื่อเบื้องต้น
                    </h3>
                    <p>กรอกข้อมูลรายละเอียดพร้อมเลือกผลิตภัณฑ์ของ บสย. ที่ท่านต้องการใช้</p>

                    <div class="card form-custom form-label form-icon" style="border: none">
                        <i class="bi bi-cash-stack font-14"></i>
                        <input type="text" class="form-control " id="a1" placeholder="จำนวนเงินที่ขอสินเชื่อ (บาท)" 
                            required="">
                        <label for="a1" class="form-label-always-active color-highlight font-11">รายละเอียดธนาคาร</label>
                        <div class="valid-feedback">a11_valid-feedback</div>
                        <div class="invalid-feedback">a12_invalid-feedback</div>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="card form-custom form-label form-icon" style="border: none">
                        <i class="bi bi-percent font-14"></i>
                        <input type="number" class="form-control " id="a2" placeholder="ดอกเบื้ย"
                            pattern="[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="">
                        <label for="a2" class="form-label-always-active color-highlight font-11"></label>
                        <div class="valid-feedback">a21_valid-feedback</div>
                        <div class="invalid-feedback">a22_invalid-feedback</div>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="card form-custom form-label form-icon" style="border: none">
                        <i class="bi bi-credit-card-fill font-14"></i>
                        <input type="number" class="form-control " id="a3" placeholder="ระยะเวลาการชำระ (ปี)"
                            pattern="[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="">
                        <label for="a3" class="form-label-always-active color-highlight font-11"></label>
                        <div class="valid-feedback">a31_valid-feedback</div>
                        <div class="invalid-feedback">a32_invalid-feedback</div>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="card form-custom form-label form-icon" style="border: none">
                        <i class="bi bi-percent font-14"></i>
                        <select class="form-control" id="a4" required>
                            <option value="" disabled selected>อัตราค่าธรรมเนียม (ร้อยละ/ปี)</option>
                            <option value="1">1/ปี</option>
                            <option value="1.5">1.5/ปี</option>
                            <option value="2.5">2.5/ปี</option>
                        </select>
                        <label for="a4" class="form-label-always-active color-highlight font-11">ค่าธรรมเนียม บสย.</label>
                        <div class="valid-feedback">a41_valid-feedback</div>
                        <div class="invalid-feedback">a42_invalid-feedback</div>
                        <span class="font-10">(required)</span>
                    </div>

                    <label class="form-check-label" for="c2a1">
                        หมายเหตุ : การคำนวณข้างต้นเป็นเพียงการประมาณการ ทั้งนี้ การอนุมัติวงเงินและเงื่อนไขต่างๆ ขึ้นอยู่กับดุลยพินิจของ ธนาคาร และการค้ำประกันสินเชื่อ บสย.
                        <%--<a href="#">Terms of Service</a>--%>
                    </label>


                    <button class="btn btn-full bg-blue-dark rounded-xs text-uppercase font-700 w-100 btn-s mt-4 mb-4"
                        type="button" id="btnCal" onclick="calculateLG();">
                        เริ่มคำนวณ</button>

                </div>
            </div>
        </div>

        <div class="card card-style" id="pnlResult_LG" style="display: none;">
            <div class="content mt-3">
                <h4>ผลลัพธ์การคำนวณ</h4>
                <div class="tabs tabs-box mt-2" id="tab-group-1">
                    <div class="tab-controls rounded-s border-highlight">

                        <a class="font-13 color-highlight" data-bs-toggle="collapse" href="#tab-2" aria-expanded="false">การชำระคืนเงินกู้พร้อมดอกเบี้ย</a>

                    </div>
                    <div class="mt-3"></div>

                    <div class="collapse show" id="tab-1" data-bs-parent="#tab-group-1">

                        <div class="table-responsive" style="display: block;">
                          
                            <table class="table color-theme mb-2">
                                <%--                                <thead>
                                    <tr>
                                        <th class="border-fade-blue" scope="col">ชื่อข้อมูล</th>
                                        <th class="border-fade-blue" scope="col">ข้อมูล</th>
                                    </tr>
                                </thead>--%>
                                <tbody>
                                    <tr class="border-fade-blue">
                                        <td style="text-align:right;width:50%;">วงเงินกู้ที่ขอกู้</td>
                                        <td>
                                            <label id="lblParam1"></label> บาท
                                            <input type="hidden" id="hddParam1" value="0" />
                                        </td>

                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td style="text-align:right;width:50%;" class="">อัตราดอกเบี้ยธนาคาร </td>
                                        <td class="">
                                            <label id="lblParam2"></label> (ต่อปี)
                                        </td>

                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td style="text-align:right;width:50%;">ระยะเวลาที่ขอกู้ </td>
                                        <td>
                                            <label id="lblParam3"></label>
                                        </td>

                                    </tr>
                                   



                                    <tr class="border-fade-blue" style="background: rgb(80 255 84 / 15%) !important;">
                                        <td style="text-align:right;width:50%;" class="">เงินผ่อนชำระต่อเดือน </td>
                                        <td class="">
                                            <lable id="lblBankPayPerMonth"></lable>
                                            บาท </td>

                                    </tr>

                                     <tr class="border-fade-blue" style="background: rgb(80 255 84 / 35%) !important;">
                                        <td style="text-align:right;width:50%;" class="">เงินผ่อนชำระต่อปี </td>
                                        <td class="">
                                            <lable id="lblBankPayPerYear"></lable>
                                            บาท </td>

                                    </tr>

                                     <tr class="border-fade-blue">
                                        <td style="text-align:right;width:50%;">อัตราค่าธรรมเนียม บสย. </td>
                                        <td>
                                            <label id="lblParam4"></label> (ต่อปี)
                                        </td>

                                    </tr>

                                    <tr class="border-fade-blue" style="background: rgb(71 230 255 / 15%) !important;">
                                        <td style="text-align:right;width:50%;" class="">ค่าธรรมเนียมคํ้าประกันสินเชื่อ (รายปี) </td>
                                        <td class="">
                                            <lable id="lblTcgPayPerMonth"></lable>
                                            บาท</td>
                                    </tr>

                                    <tr class="border-fade-blue" style="background: rgb(71 230 255 / 35%) !important;">
                                        <td style="text-align:right;width:50%;" class="">จำนวนเงินรวมที่ต้องชำระมั้งหมด (ต่อปี)</td>
                                        <td class="">
                                            <lable id="lblTotalPayPerMonth"></lable>
                                            บาท</td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-6">

                        <button class="btn bg-blue-dark rounded-xs text-uppercase font-700 w-100 btn-s mt-4 mb-4"
                            type="button" id="btnReset" onclick="Reset();">
                            เริ่มคำนวณใหม่</button>
                    </div>
                    <div class="col-6">
                        <button class="btn bg-green-dark rounded-xs text-uppercase font-700 w-100 btn-s mt-4 mb-4"
                            type="button" id="btnRegister" onclick="redirectToHealthCheckPGS11();">
                            ลงทะเบียนใช้บริการ บสย.</button>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
      <script src="<%= ResolveClientUrl("~/scripts/accounting.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/jquery-1.6.4.min.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/Page/Cal/LG.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

</asp:Content>
