<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true"
CodeBehind="Register001.aspx.cs" Inherits="CustomerHealthCheck.views.Register.Register001" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page-content footer-clear" style="padding: 0px !important;">

    <!-- Page Title-->
    <div class="pt-3">
        <div class="page-title d-flex">
            <div class="align-self-center">
                <a href="#" onclick="redirectToEvent()"
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

    <div class="card card-style">
        <a style="display:none"; href="../../../EmailTemplate/">../../../EmailTemplate/</a>
        <div class="content">
            <h4 class="mb-0">
                แบบฟอร์มลงทะเบียน
            </h4>
            <p>
                กรุณากรอกข้อมูลติดต่อกลับ
            </p>

            <div class="row" id="step1">
                <asp:Panel class="col-6" runat="server" ID="pnlPersonal" Visible="false">

                    <a href="#" class="btn-full btn-sm btn gradient-blue shadow-bg shadow-bg-m" onclick="BindingPersonal();">
                        ตั้งต้นด้วยข้อมูล
                        <br/>
                        บุคคลธรรมดา
                    </a>

                </asp:Panel>
                <asp:Panel class="col-6" runat="server" ID="pnlJuristic" Visible="false">

                    <a href="#" class="btn-full btn-sm btn gradient-green shadow-bg shadow-bg-m" onclick="BindingJuristic();">
                        ตั้งต้นด้วยข้อมูล
                        <br/>
                        นิติบุคคล
                    </a>

                </asp:Panel>
                <div class="col-12">
                    <div class="content mt-0">
                        <h5 class="pb-3 pt-4"></h5>
                        <div class="form-custom form-label form-border form-icon">
                            <i class="bi bi-calendar font-13"></i>
                            <label for="c6a" class="color-highlight form-label-always-active">ประเภทของธุรกิจ</label>
                            <select class="form-select rounded-xs" id="ddlBusinessType">
                                <option value="" selected="">- กรุณาเลือก -</option>
                                <option value="001">บุคคลธรรมดา</option>
                                <option value="002">นิติบุคคล</option>

                            </select>
                        </div>
                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtBusinessName" placeholder="โปรดระบุชื่อกิจการ" autocomplete="off">
                            <label for="txtBusinessName" class="color-highlight form-label-always-active">ชื่อกิจการ</label>
                            <span>(required)</span>
                        </div>
                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtFirstName" placeholder="โปรดระบุชื่อ" autocomplete="off">
                            <label for="txtFirstName" class="form-label-always-active color-highlight">ชื่อ</label>
                            <span>(required)</span>
                        </div>
                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtLastName" placeholder="โปรดระบุนามสกุล" autocomplete="off">
                            <label for="txtLastName" class="form-label-always-active color-highlight">นามสกุล</label>
                            <span>(required)</span>
                        </div>

                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="number" class="form-control rounded-xs" id="txtPhone" placeholder="โปรดระบุเบอร์มือถือ" maxlength="10" autocomplete="off">
                            <label for="txtPhone" class="color-highlight form-label-always-active">เบอร์มือถือ</label>
                            <span>(required)</span>
                        </div>
                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="email" class="form-control rounded-xs" id="txtEmail" placeholder="โปรดระบุอีเมล" autocomplete="off">
                            <label for="txtEmail" class="color-highlight form-label-always-active">อีเมล</label>
                            <span>(required)</span>
                        </div>
                        <div class="form-custom form-label form-border form-icon">
                            <i class="bi bi-calendar font-13"></i>
                            <label for="c6a" class="color-highlight form-label-always-active">จังหวัดที่ตั้งกิจการ</label>
                            <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                              ID="ddlProvince" ClientIDMode="Static" AppendDataBoundItems="true">
                                <asp:ListItem Value="" Text="- กรุณาเลือก -"/>
                            </asp:DropDownList>

                        </div>
                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtLoanMoney" placeholder="โปรดระบุวงเงินสินเชื่อที่ต้องการ (บาท)" onkeyup="return numberMobile(event)" autocomplete="off">
                            <label for="txtLoanMoney" class="form-label-always-active color-highlight">วงเงินสินเชื่อที่ต้องการ (บาท)</label>
                            <span>(required)</span>
                        </div>
                        <div class="form-custom form-label form-border form-icon">
                            <i class="bi bi-calendar font-13"></i>
                            <label for="c6a" class="color-highlight form-label-always-active">ธนาคารที่ใช้สินเชื่อหลัก</label>
                            <select class="form-select rounded-xs" id="ddlHaveMainBank" onchange="ToggleMainLoanBankValue();">
                                <option value="" selected="">- กรุณาเลือก -</option>
                                <option value="001">ไม่มี</option>
                                <option value="002">มี (โปรดระบุ) </option>
                            </select>
                        </div>

                        <div id="divHaveMainBankSelectBank" class="form-custom form-label form-border form-icon" style="display: none;">
                            <i class="bi bi-calendar font-13"></i>
                            <label for="c6a" class="color-highlight form-label-always-active">โปรดระบุธนาคารที่ใช้สินเชื่อหลัก</label>
                            <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                              ID="ddlHaveMainBankSelectBank" ClientIDMode="Static" AppendDataBoundItems="true">
                                <asp:ListItem Value="" Text="- กรุณาเลือก -"/>
                            </asp:DropDownList>
                        </div>

                        <div class="form-custom form-label form-border form-icon">
                            <div id="html_element"></div>
                        </div>

                        <a href="#" onclick="RegisterEventOneStep();" id="btnSubmit"
                           class="btn btn-full gradient-green shadow-bg shadow-bg-s mt-4 btn-disable">
                            บันทึก
                        </a>

                        <%-- <a href="#" onclick="GotoStep2();"
                                class="btn btn-full gradient-highlight shadow-bg shadow-bg-s mt-4">ถัดไป
                            </a>--%>
                    </div>
                </div>
            </div>
        </div>

    </div>

</div>


<div class="modal fade" id="ConfirmRegisterModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalToggleLabel">ยืนยันเข้าร่วมมาตรการ</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้ายินยอมให้ บสย. เก็บข้อมูลส่วนบุคคลเพื่อใช้ในการลงทะเบียนเข้าร่วมมาตรการ และติดต่อกลับในภายหลัง

                <%--<table class=" color-theme mb-2" style="margin-left: 20px;">

                        <tbody>
                            <tr class="border-fade-blue">
                                <td class="text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                                <td>ปลอดเงินชำระครั้งแรก</td>
                            </tr>
                            <tr class="border-fade-blue">
                                <td class="text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                                <td>ระยะเวลาผ่อน 5 ปี</td>
                            </tr>
                            <tr class="border-fade-blue">
                                <td class="border-0 text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                                <td>ตัดเงินต้น 20% ดอกเบี้ย 80%</td>
                            </tr>
                            <tr class="border-fade-blue">
                                <td class="border-0 text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                                <td>อัตราดอกเบี้ยตามประกาศ บสย. (3%)</td>
                            </tr>
                        </tbody>
                    </table>--%>
            </div>
            <div class="modal-footer" style="justify-content: center;">

                <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                   class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">
                    ยกเลิก
                </a>


                <a href="#" onclick="KeepDataAndFinish()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="FinishModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="FinishModalLabel">เสร็จสิ้น</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ระบบบันทึกการลงทะเบียนของท่านเป็นที่เรียบร้อย
            </div>
            <div class="modal-footer" style="justify-content: center;">

                <a href="#" data-bs-target="#FinishModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                   class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs" onclick="redirectToMain();">
                    กลับสู่หน้าหลัก
                </a>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="ErrorModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="ErrorModalLabel">แจ้งเตือน</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; เกิดข้อผิดพลาดในการลงทะเบียน กรุณาลองใหม่อีกครั้ง หรือติดต่อเจ้าหน้าที่ บสย.
            </div>
            <div class="modal-footer" style="justify-content: center;">

                <a href="#" data-bs-target="#ErrorModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                   class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">
                    ปิด
                </a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>
    <script src="<%= ResolveClientUrl("~/scripts/Lib/accounting.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/Page/Event/Register001.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>