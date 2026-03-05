<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.Cal.index" %>

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
            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <h3 class="color-white" style="color: #092d74 !important;">แบบประเมิณความสามารถการผ่อนชำระหนี้</h3>
                    </div>

                </div>
            </div>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>

            <div class="card overflow-visible card-style" id="pnlInfo" style="display: none;">
                <div class="content mb-0">
                    <%--  <h4>แบบประเมินความสามารถในการชำระหนี้คืน</h4>
                    <p>
                        **** กรอกข้อมูลเป็นค่าเฉลี่ยต่อเดือน
                    </p>--%>


                    <p>
                        กรอกข้อมูลรายละเอียดตามแบบฟอร์มเพื่อคำนวน
                    </p>

                    <%--   <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-bank font-16" style="color: mediumblue;"></i>
                        <input type="text" class="form-control rounded-xs" id="ddlBank" placeholder="เลือกธนาคาร"
                            required="" autocomplete="off" onclick="ShowModalListBank();" readonly>
                        <label id="formLabelBank" for="ddlBank" class="color-theme">เลือกธนาคาร</label>
                        <div class="valid-feedback">กรุณาเลือกธนาคาร</div>
                        <div class="invalid-feedback">กรุณาเลือกธนาคาร</div>
                        <span>(required)</span>
                    </div>

                    <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-card-list font-16" style="color: mediumblue;"></i>
                        <input type="text" class="form-control rounded-xs" id="ddlProduct" placeholder="เลือกผลิตภัณฑ์"
                            required="" autocomplete="off" onclick="ShowModalListProduct();" readonly>
                        <label id="formLabelProduct" for="ddlProduct" class="color-theme">เลือกผลิตภัณฑ์</label>
                        <div class="valid-feedback">กรุณาเลือกผลิตภัณฑ์</div>
                        <div class="invalid-feedback">กรุณาเลือกผลิตภัณฑ์</div>
                        <span>(required)</span>
                    </div>--%>

                    <%--  <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-bank font-18" style="color: mediumblue;"></i>
                        <select class="form-select rounded-xs" id="ddlBank" aria-label="Floating label select example"
                            onchange="ChooseProduct(this);">
                            <option selected="" value="">เลือกธนาคาร</option>
                            <option value="GSB">ธนาคารออมสิน</option>

                        </select>
                        <label for="ddlBank" class="color-theme">ธนาคารที่ร่วมโครงการ</label>
                        <div class="valid-feedback">ธนาคารที่ร่วมโครงการ</div>
                    </div>--%>

                    <%--                    <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-card-list font-18" style="color: mediumblue;"></i>
                        <select class="form-select rounded-xs" id="ddlProduct" aria-label="Floating label select example"
                            onchange="ChooseProduct(this);">
                            <option selected="" value="">เลือกผลิตภัณฑ์</option>
                            <%--   <option value="GSB001">GSB D-Vers </option>
                            <option value="GSB002">สินเชื่อธุรกิจห้องแถว </option>
                            <option value="GSB003">สินเชื่อ GSB EV Supply Chain</option>
                            <option value="GSB004">สินเชื่อเพื่อผู้ประกอบอาชีพอิสระรายย่อย</option>
                        </select>
                        <label for="ddlProduct" class="color-theme">ผลิตภัณฑ์</label>
                        <div class="valid-feedback">ผลิตภัณฑ์</div>
                    </div>--%>

                    <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-cash-stack font-16" style="color: green;"></i>
                        <input type="text" class="form-control rounded-xs" id="c1" placeholder="จำนวนผ่อนชำระต่อเดือน (บาท)"
                            required="" autocomplete="off" onkeypress="AddOption(this)">
                        <label for="c1" class="color-theme">จำนวนผ่อนชำระต่อเดือน (บาท)</label>
                        <div class="valid-feedback">กรุณากรอกข้อมูลผ่อนชำระต่อเดือน</div>
                        <div class="invalid-feedback">กรุณากรอกข้อมูลผ่อนชำระต่อเดือน</div>
                        <span>(required)</span>
                    </div>
                    <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-percent font-16"></i>
                        <input type="number" class="form-control rounded-xs" id="c2" placeholder="จำนวนปีที่ผ่อนชำระ"
                            pattern="[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="">
                        <label for="c2" class="color-theme">จำนวนปีที่ผ่อนชำระ</label>
                        <div class="valid-feedback">กรุณากรอกข้อมูลจำนวนปีที่ผ่อนชำระ</div>
                        <div class="invalid-feedback">กรุณากรอกข้อมูลจำนวนปีที่ผ่อนชำระ</div>
                        <span>(required)</span>
                    </div>
                    <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-calendar-week-fill font-14" style="color: darkgoldenrod;"></i>
                        <input type="number" class="form-control rounded-xs" id="c2a" placeholder="จำนวนภาระหนี้คงเหลือ"
                            pattern="(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])\S{8,}" required="" autocomplete="off">
                        <label for="c2a" class="color-theme ">จำนวนภาระหนี้คงเหลือ</label>
                        <div class="valid-feedback">กรุณากรอกข้อมูลจำนวนภาระหนี้คงเหลือ</div>
                        <div class="invalid-feedback">กรุณากรอกข้อมูลจำนวนภาระหนี้คงเหลือ</div>
                        <span>(required)</span>
                    </div>

                    <%--  <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-boxes font-18"></i>
                        <select class="form-select rounded-xs" id="ddlBank" aria-label="Floating label select example"
                            onchange="RefreshDropDown(this);">
                            <option selected="" value="">เลือกธนาคาร</option>
                            <option value="1">ธนาคารออมสิน</option>

                        </select>
                        <label for="ddlBank" class="color-theme">ธนาคารที่ร่วมโครงการ</label>
                        <div class="valid-feedback">ธนาคารที่ร่วมโครงการ</div>
                    </div>

                    <div class="form-custom form-label form-icon mb-3">
                        <i class="bi bi-boxes font-18"></i>
                        <select class="form-select rounded-xs" id="ddlProduct" aria-label="Floating label select example"
                            onchange="ChooseProduct(this);">
                            <option selected="" value="">เลือกผลิตภัณฑ์</option>
                            <option value="1">บสย. SMEs BI7-GSB </option>
                            <option value="2">บสย. SMEs BI7-2% ต่อปี </option>
                        </select>
                        <label for="ddlProduct" class="color-theme">ผลิตภัณฑ์</label>
                        <div class="valid-feedback">ผลิตภัณฑ์</div>
                    </div>--%>



                    <button class="btn btn-full bg-blue-dark rounded-xs text-uppercase font-700 w-100 btn-s mt-4 mb-4"
                        type="button" id="btnCal" onclick="Calculate();">
                        คำนวณรายการ</button>

                </div>
            </div>
        </div>




        <div class="card overflow-visible card-style" id="pnlDesc" style="display: none;">
            <div class="content mb-0 pt-3">
                <h4>คำอธิบายรายการ</h4>
                <div style="margin: 10px; text-align: center;" id="pnlPackageEmpty">
                    <p>กรุณาเลือกธนาคารและผลิตภัณฑ์ที่ท่านสนใจ</p>
                </div>

                <div class="table-responsive" id="pnlGSB003_s" style="display: none">
                    <table class="table color-theme mb-2">
                        <tbody>
                            <tr class="border-fade-blue">
                                <td style="vertical-align: middle;">ธนาคาร</td>
                                <td><i class="bank bank-gsb xxxl"></i>ออมสิน</td>
                            </tr>
                            <tr class="border-fade-blue">
                                <td>ผลิตภัณฑ์สินเชื่อ</td>
                                <td>สินเชื่อ GSB EV Supply Chain</td>
                            </tr>
                            <tr class="" style="border-bottom: white;">
                                <td>รายละเอียดผลิตภัณฑ์</td>
                                <td><a href="#" onclick="ShowModalDetailProduct('GSB003')">สินเชื่อ GSB EV Supply Chain</a></td>
                                <%-- <td><a href="https://www.gsb.or.th/gsb_smes/gsbev-supplychain/">สินเชื่อ GSB EV Supply Chain</a></td>--%>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="table-responsive" id="pnlGSB003_l" style="display: none">
                    <table class="table color-theme mb-2">
                        <tbody>
                            <tr class="border-fade-blue">
                                <td style="vertical-align: middle;">ธนาคาร</td>
                                <td><i class="bank bank-gsb xxxl"></i>ออมสิน</td>
                            </tr>
                            <tr class="border-fade-blue">
                                <td>ผลิตภัณฑ์สินเชื่อ</td>
                                <td>สินเชื่อ GSB EV Supply Chain</td>
                            </tr>
                            <tr class="" style="border-bottom: white;">
                                <td>รายละเอียดผลิตภัณฑ์</td>
                                <td><a href="#" onclick="ShowModalDetailProduct('GSB003')">สินเชื่อ GSB EV Supply Chain</a></td>
                                <td><%--<a href="https://www.gsb.or.th/gsb_smes/gsbev-supplychain/">สินเชื่อ GSB EV Supply Chain</a>--%></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="table-responsive" id="pnlGSB004" style="display: none">
                    <table class="table color-theme mb-2">
                        <tbody>
                            <tr class="border-fade-blue">
                                <td style="vertical-align: middle;">ธนาคาร</td>
                                <td><i class="bank bank-gsb xxxl"></i>ออมสิน</td>
                            </tr>
                            <tr class="border-fade-blue">
                                <td>ผลิตภัณฑ์สินเชื่อ</td>
                                <td>สินเชื่อเพื่อผู้ประกอบอาชีพอิสระรายย่อย</td>
                            </tr>
                            <tr class="" style="border-bottom: white;">
                                <td>รายละเอียดผลิตภัณฑ์</td>
                                <td><a href="#" onclick="ShowModalDetailProduct('GSB004')">สินเชื่อเพื่อผู้ประกอบอาชีพอิสระรายย่อย</a></td>
                                <%--<td><a href="https://www.gsb.or.th/gsb_govs/loan4idpc/">สินเชื่อเพื่อผู้ประกอบอาชีพอิสระรายย่อย</a></td>--%>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>


        <div class="card card-style" id="pnlResult" style="display: none;">
            <div class="content mt-3">
                <h4>ผลลัพธ์การคำนวณ</h4>
                <div class="tabs tabs-box mt-2" id="tab-group-1">
                    <div class="tab-controls rounded-s border-highlight">

                        <a class="font-13 color-highlight" data-bs-toggle="collapse" href="#tab-2" aria-expanded="false">การชำระแบบรายปี</a>

                    </div>
                    <div class="mt-3"></div>

                    <div class="collapse show" id="tab-1" data-bs-parent="#tab-group-1">

                        <div class="table-responsive" style="display: none;">
                            <h5>1) กรณีเป็นวงเงินกู้ระยะยาวผ่อนชำระ</h5>
                            <table class="table color-theme mb-2">
                                <thead>
                                    <tr>
                                        <th class="border-fade-blue" scope="col">ชื่อข้อมูล</th>
                                        <th class="border-fade-blue" scope="col">ข้อมูล</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="border-fade-blue">
                                        <td>วงเงินกู้ที่ขอ</td>
                                        <td>1,000,000 บาท</td>

                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td>ระยะเวลาที่ขอกู้</td>
                                        <td>84 เดือน</td>

                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td class="">อัตราดอกเบี้ยธนาคาร(ต่อปี)</td>
                                        <td class="">10%</td>

                                    </tr>


                                    <tr class="border-fade-blue" style="background: rgb(71 230 255 / 30%) !important;">
                                        <td class="">ค่าธรรมเนียมคํ้าประกันสินเชื่อ (รายปี)</td>
                                        <td class="">
                                            <lable id="lblTCGPayPerYear1"></lable>
                                            บาท (1.75 %)</td>

                                    </tr>


                                    <tr class="border-fade-blue" style="background: rgb(71 230 255 / 45%) !important;">
                                        <td class="">จำนวนเงินรวมที่ต้องชำระทั้งหมด (ต่อปี)</td>
                                        <td class="">
                                            <lable id="lblSummaryAmountPerYear2"></lable>
                                            บาท</td>

                                    </tr>

                                </tbody>
                            </table>
                        </div>
                        <div class="table-responsive">
                            <h5>1) กรณีเป็นวงเงินกู้ระยะยาวผ่อนชำระ</h5>
                            <table class="table color-theme mb-2">
                                <thead>
                                    <tr>
                                        <th class="border-fade-blue" scope="col">ชื่อข้อมูล</th>
                                        <th class="border-fade-blue" scope="col">ข้อมูล</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="border-fade-blue">
                                        <td>วงเงินกู้ที่ขอ</td>
                                        <td>1,000,000 บาท</td>

                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td>ระยะเวลาที่ขอกู้</td>
                                        <td>1 ปี</td>

                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td class="">อัตราดอกเบี้ยธนาคาร(ต่อปี)</td>
                                        <td class="">10%</td>

                                    </tr>


                                    <tr class="border-fade-blue" style="background: rgb(71 230 255 / 30%) !important;">
                                        <td class="">ค่าธรรมเนียมคํ้าประกันสินเชื่อ (ต่อปี)</td>
                                        <td class="">
                                            <lable id="lblTCGPayPerYear"></lable>
                                            17,500 บาท (1.75 %)</td>

                                    </tr>


                                    <tr class="border-fade-blue" style="background: rgb(71 230 255 / 45%) !important;">
                                        <td class="">จำนวนเงินรวมที่ต้องชำระทั้งหมด (ต่อปี)</td>
                                        <td class="">
                                            <lable id="lblSummaryAmountPerYear"></lable>
                                            117,500 บาท</td>

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
                            type="button" id="btnRegister" onclick="redirectToMain();">
                            ลงทะเบียนใช้บริการ บสย.</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="card card-style" id="pnlResult1" style="display: block;">
            <div class="content mt-3">
                <h4>ผลลัพธ์การคำนวณ</h4>
                <div class="tabs tabs-box mt-2" id="tab-group-11">
                    <div class="mt-3"></div>
                    <div class="collapse show" id="tab-11" data-bs-parent="#tab-group-1">
                        <div class="table-responsive">

                            <table class="table color-theme mb-2">
                                <thead>
                                    <tr>
                                        <th class="border-fade-blue" style="text-align: center; width: 70%;" scope="col">ชื่อข้อมูล</th>
                                        <th class="border-fade-blue" style="text-align: center; width: 30%;" scope="col">ข้อมูล</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="border-fade-blue">
                                        <td class="" style="text-align: center;">
                                            <img src="http://localhost:56955/images/Debt/11.png" style="width: 65%;" />
                                        </td>
                                        <td style="text-align: center;">
                                            <label>แนะนำ</label>
                                        </td>
                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td class="" style="text-align: center; width: 65%; height: 45%">
                                            <img src="http://localhost:56955/images/Debt/22.png" style="width: 65%;" />
                                        </td>
                                        <td style="text-align: center;">
                                            <label>แนะนำ</label>
                                        </td>
                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td class="" style="text-align: center;">
                                            <img src="http://localhost:56955/images/Debt/33.png" style="width: 65%;" />
                                        </td>
                                        <td style="text-align: center;">
                                            <label>แนะนำ</label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                        <div style="text-align: center;">
                            <button class="btn btn-sm btn-success">ลงทะเบียน 3 สี</button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="ChooseBankModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-l">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ChooseBankConfirmModalLabel">แสดงรายการธนาคาร</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="padding-bottom: 0px;">
                    <span>&nbsp;&nbsp; เลือกธนาคารที่ท่านสนใจ </span>
                    <br />
                    <div class="card card-style" style="margin: 0px; max-height: 220px; overflow: auto; box-shadow: none; border-radius: 0px;">
                        <div class="content mb-0" style="margin: 5px;">

                            <!-- Tab 2-->
                            <div class="collapse show" id="tab-5" data-bs-parent="#tab-group-2" style="">

                                <div class="list-group list-custom list-group-m list-group-flush rounded-xs"
                                    style="border: 1px solid whitesmoke">
                                    <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-gsb"
                                        onclick="GetBankDetail('GSB','ธนาคารออมสิน')">
                                        <i class="bank bank-gsb xxxl"></i>
                                        <div style="margin-left: 15px;">
                                            <p>ธนาคารออมสิน</p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <!-- End of Tabs-->
                        </div>
                    </div>
                    <br />
                </div>
                <div class="modal-footer" style="justify-content: center;">
                    <a href="#" data-bs-target="#ChooseBankNDIDModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ChooseProductModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-l">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ChooseProductConfirmModalLabel">แสดงรายการผลิตภัณฑ์</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="padding-bottom: 0px;">
                    <span>&nbsp;&nbsp; เลือกผลิตภัณฑ์ที่ท่านสนใจ </span>
                    <br />


                    <div class="card card-style" style="margin: 0px; max-height: 220px; overflow: auto; box-shadow: none; border-radius: 0px;">
                        <div class="content mb-0" style="margin: 5px;">

                            <!-- Tab 2-->
                            <div class="collapse show" id="tab-6" data-bs-parent="#tab-group-2" style="">

                                <div class="list-group list-custom list-group-m list-group-flush rounded-xs"
                                    style="border: 1px solid whitesmoke">
                                    <a href="#" class="list-group-item" style="padding: 10px;" data-trigger-switch="switch-gsb"
                                        onclick="GetProductDetail('GSB003_s','สินเชื่อระยะสั้น GSB EV Supply Chain')">
                                        <i class="bi bi-bag " style="font-size: 20px; color: green;"></i>
                                        <div style="margin-left: 5px;">
                                            <p>สินเชื่อระยะสั้น GSB EV Supply Chain</p>
                                        </div>
                                    </a>
                                    <a href="#" class="list-group-item" style="padding: 10px;" data-trigger-switch="switch-gsb"
                                        onclick="GetProductDetail('GSB003_l','สินเชื่อระยะยาว GSB EV Supply Chain')">
                                        <i class="bi bi-bag " style="font-size: 20px; color: green;"></i>
                                        <div style="margin-left: 5px;">
                                            <p>สินเชื่อระยะยาว GSB EV Supply Chain</p>
                                        </div>
                                    </a>
                                    <a href="#" class="list-group-item" style="padding: 10px;" data-trigger-switch="switch-gsb"
                                        onclick="GetProductDetail('GSB004','สินเชื่อเพื่อผู้ประกอบอาชีพอิสระรายย่อย')">
                                        <i class="bi bi-bag " style="font-size: 20px; color: green;"></i>
                                        <div style="margin-left: 5px;">
                                            <p>สินเชื่อเพื่อผู้ประกอบอาชีพอิสระรายย่อย</p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <!-- End of Tabs-->
                        </div>
                    </div>
                    <br />
                </div>
                <div class="modal-footer" style="justify-content: center;">
                    <a href="#" data-bs-target="#ChooseProductModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ShowProductDetailModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-l">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ShowProductDetailModalLabel">แสดงรายละเอียดโครงการ</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="padding-bottom: 0px;">
                    <div class="card card-style" style="margin: 0px; max-height: 1520px; overflow: auto; box-shadow: none; border-radius: 0px;">
                        <div class="content mb-0" style="margin: 5px;">
                            <div>
                                <img id="imgProductDetail" src="" style="max-width: 100%;" />
                            </div>
                            <table class="table color-theme mb-2">
                                <tbody>
                                    <tr class="border-fade-blue">
                                        <td>
                                            <label style="font-size: 18px;"><strong>คุณสมบัติของ SMEs</strong></label><br />
                                            <label id="lblProductDetail"></label>
                                        </td>
                                    </tr>

                                    <tr class="border-fade-blue">
                                        <td>
                                            <label style="font-size: 18px;"><strong>วัตถุประสงค์การกู้</strong></label><br />
                                            <label id="lblProductObjective"></label>
                                        </td>
                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td>
                                            <label style="font-size: 18px;"><strong>โครงการสินเชื่อ</strong></label><br />
                                            <label id="lblProductLoanAmount"></label>
                                        </td>
                                    </tr>
                                    <tr class="border-fade-blue">
                                        <td>
                                            <label style="font-size: 18px;"><strong>ดอกเบี้ยตามโครงการธนาคาร</strong></label><br />
                                            <label id="lblProductTimeLine"></label>
                                        </td>
                                    </tr>
                                    <tr class="">
                                        <td style="border: none;">
                                            <label style="font-size: 18px;"><strong>วงเงินกู้ที่ขอ</strong></label><br />
                                            <label id="lblProductInterest"></label>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>

                        </div>
                    </div>
                    <br />
                </div>
                <div class="modal-footer" style="justify-content: center;">
                    <a href="#" data-bs-target="#ChooseBankNDIDModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/jquery-1.6.4.min.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/accounting.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

    <script src="<%= ResolveClientUrl("~/scripts/Page/Cal.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

</asp:Content>
