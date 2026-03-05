<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Step.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerHealthCheck.views.SignUp.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - TCGSignUp</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddAcceptCondition" runat="server" />
    <asp:HiddenField ID="hddDummyID" runat="server" />

    <asp:HiddenField ID="hddIsSubmitStep1" runat="server" />
    <asp:HiddenField ID="hddIsSubmitStep2" runat="server" />
    <asp:HiddenField ID="hddIsSubmitStep3" runat="server" />

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


        <div class="card card-style mx-3 px-2 py-2" id="pnlConsent" style="display: block;">
            <div class="content">
                <h3 class="font-22 font-800 mb-0">เงื่อนไขการใช้บริการ (1/3)</h3>
                <p style="margin-bottom: 5px;">
                    กรุณาอ่านเงื่อนไขการใช้บริการให้ครบถ้วนก่อนลงทะเบียน
                </p>
                <div style="border-radius: 10px; height: 500px; margin-bottom: 30px; overflow: scroll; border: 1px solid silver; padding: 10px;">

                    <div style="height: 500px;">
                        <p>1. ท่านรับรอง ว่าข้อมูลใดๆ ที่ท่านได้บันทึกเข้าสู่ระบบอันเกี่ยวเนื่องกับการให้บริการนี้ เป็นข้อมูลของตัวท่านเอง และไม่ได้นำข้อมูลบุคคลอื่นมาใช้ หรือเป็นการใช้ข้อมูลโดยละเมิดสิทธิของบุคคลอื่น กรณีที่ท่านนำข้อมูลของบุคคลอื่นมาใช้โดยไม่ได้รับความยินยอมจากเจ้าของข้อมูล ท่านต้องรับผิดชอบต่อความเสียหายที่เกิดขึ้นทั้งในทางแพ่งและทางอาญา</p>

                        <p>2. ท่านรับทราบว่า บสย. ทำหน้าที่เป็นตัวกลางระหว่างสถาบันการเงินและผู้ประกอบธุรกิจขนาดกลางและขนาดย่อม (ลูกค้า) ในการให้คำปรึกษาแก่ลูกค้าในการขอรับสินเชื่อจากสถาบันการเงิน โดยข้อมูลนี้เพื่อประโยชน์ในการวิเคราะห์ของ บสย. ซึ่งเป็นการวิเคราะห์ตามหลักเกณฑ์ของ บสย. เท่านั้น จึงไม่ได้มีผลต่อการอนุมัติหรือไม่อนุมัติสินเชื่อของสถาบันการเงิน โดยการอนุมัติสินเชื่อเป็นดุลยพินิจและการพิจารณาของสถาบันการเงินที่ท่านขอสินเชื่อเท่านั้น</p>

                        <p>3. ท่านรับทราบว่าการให้ข้อมูลนี้ เพื่อวัตถุประสงค์ของ บสย. ในการใช้ข้อมูลมาวิเคราะห์เพื่อจัดทำผลิตภัณฑ์เพื่อช่วยเหลือผู้ประกอบการ รวมทั้งรองรับนโยบายของรัฐบาลในการที่จะช่วยเหลือผู้ประกอบธุรกิจขนาดกลางและขนาดย่อม</p>

                        <p>4. ท่านรับทราบว่า ข้อมูลและกิจกรรมที่นำเสนอเฉพาะในช่วงระยะเวลาหนึ่งเท่านั้น โดยข้อมูลดังกล่าวอาจไม่ใช่ข้อมูลปัจจุบัน</p>

                        <p>5. บสย. ไม่รับผิดชอบต่อความผิดพลาด ความไม่สมบูรณ์ หยุดชะงัก หรือ[คอมพิวเตอร์ไวรัส] รวมไปถึงความไม่ครบถ้วนใดๆ ของข้อมูล หรือความเสียหายต่อท่านหรือบุคคลใดๆ ไม่ว่าจะเป็นความสูญเสียทางตรงหรือทางอ้อม หรือค่าใช้จ่ายใดๆ อันเกิดจากการให้บริการ เข้าใช้ระบบได้</p>

                        <h5>ความยินยอมในการเปิดเผยข้อมูลส่วนบุคคล</h5>
                        <p>1. บสย. จัดทำหนังสือให้ขอความยินยอมจากท่านในการเก็บรวบรวม ใช้เปิดเผยข้อมูลส่วนบุคคล หรือข้อมูลทางการเงินอื่นๆ ของที่ท่านที่ได้ให้ไว้แก่ บสย. หรือที่ บสย. อาจเข้าถึงได้จากแหล่งอื่น เพื่อใช้สำหรับการวิเคราะห์ วิจัยและ/หรือพัฒนาผลิตภัณฑ์ของ บสย. รวมถึงการสำรวจความพึงพอใจด้านผลิตภัณฑ์และบริการของ บสย. และขยายสิทธิประโยชน์ให้ท่านมากขึ้นผ่านการนำเสนอผลิตภัณฑ์ บริการ การแจ้งข่าวสารต่างๆ เชิญชวนเข้าร่วมกิจกรรม ข้อมูลการตลาดที่ตรงตามความต้องการของท่าน</p>

                        <p>2. บสย. จะจัดเก็บข้อมูลส่วนบุคคลของท่านตามข้อ 1 สำรองไว้ตามกฎหมาย และระเบียบ บสย. เรื่องการเก็บรักษาและทำลายเอกสาร เมื่อสิ้นสุดระยะเวลาในการจัดเก็บแล้ว บสย. จะทำลายข้อมูลส่วนบุคคลดังกล่าว</p>

                        <p>3. ท่านสามารถดูรายละเอียดเพิ่มเติมได้ที่ <a data-fr-linked="true" href="https://www.tcg.or.th/privacy_policy.php">https://www.tcg.or.th/privacy_policy.php</a> หากท่านประสงค์จะเพิกถอนความยินยอมนี้ หรือทำการยื่นข้อร้องเรียนใดๆ เกี่ยวกับการละเมิดสิทธิของท่าน สามารถดำเนินการผ่านช่องทางตามที่ระบุไว้ที่ <a data-fr-linked="true" href="https://www.tcg.or.th/privacy_policy.php">https://www.tcg.or.th/privacy_policy.php</a> ทั้งนี้ ท่านมีสิทธิเลือกให้ ความยินยอมหรือไม่ก็ได้ โดยไม่ส่งผลต่อการพิจารณาการใช้ผลิตภัณฑ์หรือบริการของ บสย.</p>

                        <p>สอบถามรายละเอียดเพิ่มเติมโครงการ &ldquo;ลงทะเบียน ยืนยันตัวตน บสย.&rdquo; ได้ที่ Email: <a data-fr-linked="true" href="mailto:callcenter.mb@tcg.or.th">callcenter.mb@tcg.or.th</a> โทรศัพท์:0-2890-9999</p>

                    </div>
                </div>

                <div class="row">
                    <div class="d-flex py-1 mb-3">
                        <div class="align-self-center ">
                            <div class="form-switch ios-switch switch-green switch-l">
                                <input autocomplete="off" type="checkbox" class="ios-input" id="switch-b2">
                                <label class="custom-control-label" for="switch-b2"></label>
                            </div>
                        </div>

                        <div class="align-self-center ps-1" style="width: 250px;">
                            <h5>ข้าพเจ้ารับทราบเงื่อนไขทั้งหมด
                        <br />
                                อย่างครบถ้วนแล้ว<br />
                            </h5>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <a href="#" onclick="redirectToMain()" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ยกเลิก</a>
                    </div>
                    <div class="col-6">
                        <a href="#" onclick="AcceptStep1()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ถัดไป</a>
                    </div>
                </div>
            </div>
        </div>


        <div class="card card-style px-2 py-2" id="pnlSignUpForm" style="display: none;">
            <div class="content">
                <h3 class="mb-0 mt-2 font-22">แบบฟอร์มลงทะเบียน (2/3)
                </h3>
                <p>
                    กรุณากรอกข้อมูลของท่านให้ครบถ้วน
                </p>

                <div class="row" id="step1">

                    <div class="col-12">
                        <div class="content m-0">
                            <%--  <h5 class="pb-3 pt-4"></h5>--%>
                            <div class="form-custom form-label form-border form-icon">
                                <i class="bi bi-calendar font-13"></i>
                                <label for="c6a" class="color-highlight form-label-always-active">คำนำหน้าชื่อ</label>
                                <select class="form-select rounded-xs" id="ddlTitlePersonal">
                                    <option value="" selected="">- กรุณาเลือก -</option>
                                    <option value="001">นาย</option>
                                    <option value="002">นาง</option>
                                    <option value="003">นางสาว</option>
                                </select>
                            </div>

                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtFirstName" placeholder="โปรดระบุชื่อ" value="">
                                <label for="txtFirstName" class="form-label-always-active color-highlight">ชื่อ</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtLastName" placeholder="โปรดระบุนามสกุล" value="">
                                <label for="txtLastName" class="form-label-always-active color-highlight">นามสกุล</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtIDCard" placeholder="โปรดระบุเลขบัตรประจำตัวประชาชน" value="">
                                <label for="txtIDCard" class="form-label-always-active color-highlight">เลขบัตรประจำตัวประชาชน</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtLaserID" placeholder="โปรดระบุรหัสหลังบัตรประจำตัวประชาชน" value="">
                                <label for="txtLaserID" class="form-label-always-active color-highlight">รหัสหลังบัตรประจำตัวประชาชน</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs datepicker-th" id="txtBirthDate" placeholder="วันเดือนปีเกิด" value="" maxlength="10" onkeypress="filterDigits(event)">
                                <label for="txtBirthDate" class="color-highlight form-label-always-active">วันเกิด</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="number" class="form-control rounded-xs" id="txtPhone" placeholder="โปรดระบุเบอร์มือถือ" maxlength="10" value="">
                                <label for="txtPhone" class="color-highlight form-label-always-active">เบอร์มือถือ</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="email" class="form-control rounded-xs" id="txtEmail" placeholder="โปรดระบุอีเมล์" value="">
                                <label for="txtEmail" class="color-highlight form-label-always-active">อีเมล์</label>
                                <span>(required)</span>
                            </div>
                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <div id="html_element"></div>
                            </div>


                            <%--                            <div class="d-flex py-1">
                                <div class="align-self-center">
                                    <p class=" bi bi-person-bounding-box p-0  " style="margin-right: 10px; font-size: 36px;"></p>
                                </div>

                                <div class="align-self-center ps-1">
                                    <div>ยืนยันตัวตนกับฐานข้อมูล บสย.<br />
                                        <span style="font-size:11px;">(เพื่อเข้าถึงบริการเต็มรูปแบบ เช่น ตรวจสอบสถานะคำขอ เป็นต้น)</span></div>
                                </div>

                                <div class="align-self-center ms-auto">

                                    <div class="form-switch ios-switch switch-green switch-l">
                                        <input type="checkbox" class="ios-input" id="switch-b2">
                                        <label class="custom-control-label" for="switch-b2"></label>
                                    </div>
                                </div>
                            </div>--%>

                            <div class="row">
                                <div class="col-6">
                                    <a href="#" onclick="RedirectTo('1')" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ย้อนกลับ</a>
                                </div>
                                <div class="col-6">
                                    <a href="#" id="btnSubmit" onclick="AcceptStep2()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs btn-disable">ถัดไป </a>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card card-style px-2 py-2" id="pnlConfirmOTP" style="display: none;">
            <div class="content">
                <h3 class="font-22 font-800 mb-0">ยืนยันรหัส OTP (3/3)</h3>

                <div class="form-custom mb-1">
                    <i class="bi bi-calendar font-13"></i>
                    <label for="c6a" class="color-highlight form-label-always-active">เบอร์ติดต่อจากฐานข้อมูล บสย.</label>
                    <select class="form-select rounded-xs" id="ddlSMSPhoneNumber">
                    </select>
                </div>

                <div class="mb-5" style="text-align: center;">
                    <a href="#" id="btnSendOTP" onclick="SendOTP();"
                        class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs ">ขอรหัส OTP
                    </a>
                </div>

                <div id="pnlKeyInOTP" style="display: none;">
                    <div class="form-custom form-label form-border form-icon mb-1 bg-transparent">
                        <i class="bi bi-chat-right-text-fill font-16"></i>
                        <input autocomplete="off" type="text" class="form-control rounded-xs font-18" id="txtOTP" placeholder="โปรดระบุรหัส OTP" maxlength="6">
                        <label for="c1" class="color-theme">โปรดระบุรหัส OTP ที่ได้รับ</label>
                        <span>(required)</span>
                    </div>

                    <div class="mb-4" style="text-align: left;">
                        Reference Number : <span id="ltlReferenceNumber"></span>

                    </div>
                    <a href="#" onclick="AcceptStep3()" class="btn btn-full gradient-highlight shadow-bg shadow-bg-s mt-4">ยืนยันรหัส OTP</a>

                    <%--                    <div class="row">
                        <div class="col-6">
                            <a href="#" onclick="RedirectTo('2')" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs " style="text-align: center;">ย้อนกลับ</a>
                        </div>
                        <div class="col-6">
                            <a href="#" onclick="AcceptStep3()" class="btn btn-full mx-1 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                        </div>
                    </div>--%>
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
                        class="btn btn-sm mx-1 gradient-blue shadow-bg shadow-bg-xs" onclick="redirectToMain();">กลับสู่หน้าหลัก
                    </a>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ConfirmRegisterModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalToggleLabel">ยืนยันการลงทะเบียน</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้ายินยอมให้ บสย. เก็บข้อมูลส่วนบุคคลเพื่อใช้ในการลงทะเบียน

                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-1 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>


                    <a href="#" onclick="ShowModalSubmitOTP()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-1 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ErrorDopaModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ErrorDopaModalToggleLabel">แจ้งเตือนข้อมูลไม่ถูกต้อง</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้อมูลส่วนบุคคลของท่านไม่ถูกต้อง กรุณาตรวจสอบ แล้วลองใหม่อีกครั้ง

                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#ErrorDopaModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-1 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>


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
                        class="btn btn-sm mx-1 gradient-blue shadow-bg shadow-bg-xs">ปิด
                    </a>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>
    <script src="<%= ResolveClientUrl("~/scripts/Page/SignUp.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/jquery-1.6.4.min.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

    <script src="<%= ResolveClientUrl("~/scripts/jquery-ui-1.8.10.offset.datepicker.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/jquery-ui-1.8.10.custom.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>">
    <script type="text/javascript">
        $(function () {
            var d = new Date();
            var toDay = d.getDate() + '/'
                + (d.getMonth() + 1) + '/'
                + (d.getFullYear() + 543);

            // Datepicker
            $(".datepicker-th").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: false,
                yearRange: "-100:+0",
                changeYear: true, isBuddhist: true, defaultDate: toDay, dayNames: ['อาทิตย์', 'จันทร์', 'อังคาร', 'พุธ', 'พฤหัสบดี', 'ศุกร์', 'เสาร์'],
                dayNamesMin: ['อา.', 'จ.', 'อ.', 'พ.', 'พฤ.', 'ศ.', 'ส.'],
                monthNames: ['มกราคม', 'กุมภาพันธ์', 'มีนาคม', 'เมษายน', 'พฤษภาคม', 'มิถุนายน', 'กรกฎาคม', 'สิงหาคม', 'กันยายน', 'ตุลาคม', 'พฤศจิกายน', 'ธันวาคม'],
                monthNamesShort: ['ม.ค.', 'ก.พ.', 'มี.ค.', 'เม.ย.', 'พ.ค.', 'มิ.ย.', 'ก.ค.', 'ส.ค.', 'ก.ย.', 'ต.ค.', 'พ.ย.', 'ธ.ค.']
            });

        });


    </script>

    <script src="<%= ResolveClientUrl("~/scripts/jquery.signalR-2.4.3.min.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/signalr/hubs") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script>
        $(function () {
            var SignalHub = $.connection.signalHub;
            SignalHub.client.send = function (type, result, uid) {
                AcceptStep2_LandingCallback(type, result, uid);
            };
            $.connection.hub.start();
        });

    </script>

    <style>
        .ui-datepicker-year {
            border-radius: 10px;
            text-align: center;
        }
    </style>

</asp:Content>
