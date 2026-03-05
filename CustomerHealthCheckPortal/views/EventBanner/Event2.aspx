<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true"
CodeBehind="Event2.aspx.cs" Inherits="CustomerHealthCheck.views.EventBanner.Event2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>TCG OneStopService - Event DebtHolding Code 21 </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:HiddenField ID="hddAcceptCondition" runat="server"/>
<asp:HiddenField ID="hddDummyID" runat="server"/>

<asp:HiddenField ID="hddIsSubmitStep1" runat="server"/>
<asp:HiddenField ID="hddIsSubmitStep2" runat="server"/>
<asp:HiddenField ID="hddIsSubmitStep3" runat="server"/>

<asp:HiddenField ID="hddDataProfile" runat="server" />


    <div class="page-content footer-clear" style="padding: 0px !important;">

        <!-- Page Title-->
        <div class="pt-3">
            <div id="backStep" class="page-title" >
                <div class="align-self-center">
                    <a href="#"  onclick="redirectToMain()"
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

        <!-- Page Step 1-->
        <div class="card card-style mx-3 px-2 py-2" id="pnlConsent" style="display: none;">

            <div class="content">
                <h3 class="font-22 font-800 mb-0">เงื่อนไขการใช้บริการ (1)</h3>
                <p style="margin-bottom: 5px;">
                    กรุณาอ่านเงื่อนไขการใช้บริการให้ครบถ้วนก่อนลงทะเบียน
                </p>
                <div style="border-radius: 10px; height: 500px; margin-bottom: 30px; overflow: scroll; border: 1px solid silver; padding: 10px;">

                    <div style="height: 500px;">

                        <p>1. บสย. จะดำเนินการเก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคลตามที่เจ้าของข้อมูลส่วนบุคคลได้ให้ไว้แก่ บสย. หรือที่ บสย.อาจเข้าถึงได้จากแหล่งอื่น เพื่อการประมวลผล การบริหารจัดการ การดำเนินการเกี่ยวกับ วิเคราะห์ วิจัย สถิติสำรวจความคิดเห็น แนะนำ เสนอปรับปรุงบริการหรือพัฒนาผลิตภัณฑ์ต่างๆ ของ บสย. รวมทั้งการให้ความช่วยเหลือลูกหนี้ตามมาตรการจูงใจประนอมหนี้และการปรับปรุงโครงสร้างหนี้กับ บสย. นำเสนอสิทธิประโยชน์ที่เหมาะสมให้แก่เจ้าของข้อมูลส่วนบุคคลผ่านการนำเสนอบริการหรือผลิตภัณฑ์ และการแจ้งข่าวสารต่างๆ ของ บสย.</p>

                        <p>ข้อมูลส่วนบุคคลที่ บสย. ได้รับมาจากเจ้าของข้อมูลส่วนบุคคลจากการติดต่อผ่านช่องทาง “บสย. F.A.Center” หรือการเข้าร่วมกิจกรรมของ บสย.หรือพันธมิตรทางธุรกิจ และ/หรือนิติบุคคลอื่นจัดขึ้น ที่มีการบันทึกเสียง ภาพนิ่ง ภาพเคลื่อนไหว CCTVหากมีการนำไปใช้เพื่อการประชาสัมพันธ์กิจกรรมต่างๆ บสย. ผ่านสื่อออนไลน์ สื่อวีดีทัศน์ สื่อโทรทัศน์สื่อสิ่งพิมพ์ สื่ออิเล็กทรอนิกส์ บสย. จะคำนึงถึงสิทธิขั้นพื้นฐานของเจ้าของข้อมูลส่วนบุคคลเป็นหลัก รวมถึงบุคคลอื่น (ถ้ามี) และรักษาความปลอดภัยของข้อมูลเป็นสำคัญ</p>

                        <p>2. บสย. จะเก็บข้อมูลส่วนบุคคลไว้ตามระยะเวลาความจำเป็นตามวัตถุประสงค์ที่ได้การเก็บรวบรวมไว้ เท่านั้นเมื่อสิ้นสุดความสัมพันธ์ บสย.จะเก็บรักษาข้อมูลส่วนบุคคลไว้ต่อไปตามระยะเวลาที่จำเป็นตามอายุความหรือระยะเวลาที่กฎหมายกำหนดหรืออนุญาตไว้รวมถึงเป็นไปตามระเบียบของ บสย.เรื่องการเก็บรักษาและทำลายเอกสารภายในระยะเวลา 2 ปี หรือ 10 ปี (แล้วแต่กรณี)</p>

                        <p>3. หากเจ้าของข้อมูลส่วนบุคคลมีข้อสอบถามเพิ่มเติม หรือข้อร้องเรียนเกี่ยวกับข้อมูลส่วนบุคคล สามารถติดต่อ บสย.ได้ที่ช่องทาง Website : <a data-fr-linked="true" href="https://www.tcg.or.th/privacy_policy.php">https://www.tcg.or.th/privacy_policy.php </a>:หรือขอรายละเอียดได้ที่:ศูนย์ที่ปรึกษาทางการเงิน SMEs (บสย. F.A.Center) <a data-fr-linked="true" href="mailto:debt.doctor@tcg.or.th">debt.doctor@tcg.or.th</a> โทรศัพท์: 0-2890-9999 </p>

                        <h5>ความยินยอมในการเปิดเผยข้อมูลเพื่อการประชาสัมพันธ์  </h5>

                        <p>ข้าพเจ้าขอให้ความยินยอมต่อ บสย. ในการนำภาพถ่าย วีดีโอ เนื้อหา และข้อมูล ของข้าพเจ้าที่ให้ไว้แก่ บสย.เพื่อใช้เผยแพร่ในสื่อต่างๆ เช่น สื่อออนไลน์ สื่อวีดีทัศน์ สื่อโทรทัศน์ รวมทั้งสื่อสิ่งพิมพ์ เพื่อการประชาสัมพันธ์ ในกิจกรรมต่างๆ ของ บสย.</p>
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

        <!-- Page Step 2-->
        <div class="card card-style px-2 py-2" id="pnlFillIdCard" style="display: none;">
            <div class="content">
                <h3 class="font-22 font-800 mb-0">ตรวจสอบคุณสมบัติ (2)</h3>
                <div class="card card-img">
                    <img src="<%= ResolveClientUrl("~/images/Banner/Debt04.png") %>" />
                </div>
                <br />
                <div class="form-custom form-label no-icon mb-3">
                    <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==13) return false;" class="form-control rounded-xs" id="txtIdentityId" placeholder="เลขบัตรประจำตัวประชาชน/เลขนิติบุคคล" maxlength="13">
                    <label for="txtIdentityId" class="form-label-always-active color-highlight">กรอกข้อมูล 13 หลัก เพื่อตรวจสอบคุณสมบัติ </label>
                    <span>(required)</span>
                </div>
                <a href="#" id="btnSubmitCheck" onclick="ShowModal()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ตรวจสอบสิทธิ์</a>
            </div>
        </div>

        <!-- Page Step 3-->
        <div class="card card-style px-2 py-2" id="pnlSignUpForm" style="display: none;">
            <div class="content">
                <h3 class="font-22 font-800 mb-0"> ลงทะเบียนเข้าร่วมมาตรการ </h3>
                 <%--<a class="bg-green-dark line-height-xs font-15 rounded-3 "> </a>--%>
                <p>
                   กรุณากรอกข้อมูลของท่านให้ครบถ้วนเพื่อลงทะเบียน
                </p>

                <div class="row" id="step1">

                    <div class="col-12">
                        <div class="content m-0">
                            <div class="form-custom form-label form-border form-icon">
                                <i class="bi bi-calendar font-13"></i>
                                <label for="c6a" class="color-highlight form-label-always-active">คำนำหน้าชื่อ</label>
                                <select class="form-select rounded-xs" id="ddlTitlePersonal">
                                    <option value="" selected="">- กรุณาเลือก -</option>
                                    <option value="001">นาย</option>
                                    <option value="002">นาง</option>
                                    <option value="003">นางสาว</option>
                                    <option value="004">บจก.</option>
                                    <option value="005">หจก.</option>
                                    <option value="006">บมจ.</option>
                                    <option value="007">อื่นๆ</option>
                                </select>
                            </div>

                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtFirstName" placeholder="โปรดระบุชื่อ">
                                <label for="txtFirstName" class="form-label-always-active color-highlight">ชื่อ</label>
                                <span>(required)</span>
                            </div>

                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtLastName" placeholder="โปรดระบุนามสกุล">
                                <label for="txtLastName" class="form-label-always-active color-highlight">นามสกุล</label>
                                <span>(required)</span>
                            </div>

                            <div class="form-custom form-label form-border form-icon">
                                <i class="bi bi-calendar font-13"></i>
                                <label for="c6a" class="color-highlight form-label-always-active">ความเกี่ยวข้องในกิจการ</label>
                                <select class="form-select rounded-xs" id="ddlBusinessPosition">
                                    <option value="" selected="">- กรุณาเลือก -</option>
                                    <option value="1">เจ้าของกิจการ</option>
                                    <option value="2">ผู้ถือหุ้น/หุ้นส่วน</option>
                                    <option value="3">ครอบครัว/เพื่อน/ญาติ</option>
                                    <option value="4">ผู้บริหาร/พนักงาน</option>
                                    <option value="5">อื่น ๆ</option>
                                </select>
                            </div>

                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input type="text" class="form-control rounded-xs" id="txtBusinessName" placeholder="โปรดระบุชื่อกิจการ/บริษัท" autocomplete="off">
                                <label for="txtBusinessName" class="color-highlight form-label-always-active">ชื่อกิจการ/บริษัท</label>
                                <span>(required)</span>
                            </div>

                            <div class="form-custom form-label form-border form-icon">
                                <i class="bi bi-calendar font-13"></i>
                                <label for="c6a" class="color-highlight form-label-always-active">จังหวัดที่อยู่</label>
                                <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                    ID="ddlProvince" ClientIDMode="Static" AppendDataBoundItems="true">
                                    <asp:ListItem Value="" Text="- กรุณาเลือก -" />
                                </asp:DropDownList>
                            </div>


                            <div class="form-custom form-label form-border form-icon">
                                <i class="bi bi-calendar font-13"></i>
                                <label for="c6a" class="color-highlight form-label-always-active">รายได้โดยประมาณต่อเดือน (บาท)</label>
                                <select class="form-select rounded-xs" id="ddlIncome">
                                    <option value="" selected="">- กรุณาเลือก -</option>
                                    <option value="0-25,000">0-25,000</option>
                                    <option value="25,001-50,000">25,001-50,000</option>
                                    <option value="50,001-100,000">50,001-100,000</option>
                                    <option value="100,001-500,000">100,001-500,000</option>
                                    <option value="500,001-1,000,000">500,001-1,000,000</option>
                                    <option value="1,000,001-3,000,000">1,000,001-3,000,000</option>
                                    <option value="3,000,001-5,000,000">3,000,001-5,000,000</option>
                                    <option value="มากกว่า 5,000,000">มากกว่า 5,000,000</option>
                                </select>
                            </div>

                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==10) return false;" class="form-control rounded-xs" id="txtMobilePhone" placeholder="โปรดระบุเบอร์มือถือ ขึ้นต้นด้วย 0"/>
                                <label for="txtPhone" class="color-highlight form-label-always-active">เบอร์มือถือ</label>
                                <span>(required)</span>
                            </div>

                            <div class="form-custom form-label form-border mb-3 bg-transparent">
                                <div id="html_element"></div>
                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <a href="#" onclick="ShowModalCancel()" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ยกเลิก</a>
                                </div>
                                <div class="col-6">
                                    <a href="#" id="btnSubmit" onclick="AcceptStep3()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ถัดไป</a>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Page Step 4-->
        <div class="card card-style px-2 py-2" id="pnlConfirmOTP" style="display: none;">
            <div class="content">
                <h3 class="font-22 font-800 mb-0">ยืนยันรหัส OTP (4)</h3>

                <div class="form-custom mb-1">
                    <i class="bi bi-calendar font-13"></i>
                    <label for="c6a" class="color-highlight form-label-always-active">ต้องการ ส่ง OTP ไปที่ หมายเลข</label>
                    <input disabled="disabled" autocomplete="off" type="text" class="form-control rounded-xs" id="txtMobilePhoneSentOTP" placeholder="" maxlength="10">
                </div>
                        <a href="#" id="btnSendOTP" onclick="SendOTP();" class="btn btn-full gradient-highlight shadow-bg shadow-bg-s mt-4">ขอรหัส OTP</a>
                <br />

                <div id="pnlKeyInOTP" style="display: none;">
                    <div class="form-custom form-label form-border form-icon mb-1 bg-transparent">
                        <i class="bi bi-chat-right-text-fill font-16"></i>
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==6) return false;" class="form-control rounded-xs font-18" id="txtOTP" placeholder="โปรดระบุรหัส OTP หลัก" maxlength="6">
                        <label for="c1" class="color-theme">โปรดระบุรหัส OTP ที่ได้รับ</label>
                        <span>(required)</span>
                    </div>

                    <div class="mb-4" style="text-align: left; display: block;">
                        Reference Number : <span id="ltlReferenceNumber"></span>
                    </div>
                    <br >
                    <div id="confirmRegister" style="display : block";>
                        <input type="button"
                            value="ยืนยันรหัส OTP"
                            onclick="AcceptStep4()"
                            id="btnConfirmRegister"
                            class="btn btn-full rounded-s gradient-blue shadow-bg shadow-bg-s w-100"
                            data-bs-toggle="offcanvas"
                            data-bs-target="#menu-exchange">
                    </div>
                    <%--<a href="#" onclick="AcceptStep4()" class="btn btn-full gradient-highlight shadow-bg shadow-bg-s mt-4">ยืนยันรหัส OTP</a>--%>

                </div>

            </div>
        </div>

        <!-- Page Register Complete Step 1 -->
        <div class="card card-style px-2 py-2" id="pnlRegisterComplete" style="display: none;">
            <div class="content">
                <h3 class="font-22 font-800 mb-0">ท่านลงทะเบียนเข้าร่วมมาตรการสำเร็จ</h3>
                <div class="card card-img">
                    <img src="<%= ResolveClientUrl("~/images/Banner/Debt04.png") %>" />
                </div>
                <br />
                <a href="#" id="btnRegisterComplete" onclick="" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs disabledButton">ลงทะเบียนสำเร็จ</a>
            </div>
        </div>
    </div>
<!-- End of Page ID-->
    

        <div class="modal fade" id="checkRegisterModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalToggleLabel">ยืนยันตรวจสอบสิทธิ์ในการเข้าร่วมมาตรการ</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้ายินยอมให้ บสย. เก็บข้อมูลส่วนบุคคลเพื่อใช้ในตรวจสอบ
                    </div>
                    <div class="modal-footer" style="justify-content: center;">

                        <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                            class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                        </a>


                        <a href="#" onclick="AcceptStep2()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                    </div>
                </div>
            </div>
        </div>

    <div class="modal fade" id="cancelRegister" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="cancelRegisterLabel">ยกเลิก</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ต้องการ ยกเลิกการลงทะเบียนเข้าร่วมมาตรการ
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#cancelRegister" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>

                    <a href="#" onclick="redirectToMain()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
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
    <script src="<%= ResolveClientUrl("~/scripts/Page/EventBanner/EventBanner2.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>