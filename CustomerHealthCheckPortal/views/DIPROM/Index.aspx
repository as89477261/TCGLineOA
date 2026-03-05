<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerHealthCheck.views.DIPROM.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>TCG OneStopService - DIPROM</title>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddprofileRegister" runat="server" />
    <asp:HiddenField ID="hddtransDummyID" runat="server" />
    <asp:HiddenField ID="hddacceptCondition" runat="server" />
    <asp:HiddenField ID="hddCreditStatus" runat="server" />
    <asp:HiddenField ID="hddHealthCheckStatus" runat="server" />
    <asp:HiddenField ID="hddIsRegisterSuccess" runat="server" />
    <asp:HiddenField ID="hddSendEmailStatus" runat="server" />
    <asp:HiddenField ID="hddIsApprove" runat="server" />
    <asp:HiddenField ID="hddIsConsultFASuccess" runat="server" />
    <asp:HiddenField ID="hddIsConsultClinicSuccess" runat="server" />


    <!-- Page Title-->
    <div class="pt-3">
        <div id="backStep" class="page-title">
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
    <!-- Page Information -->
    <div class="card card-style" id="pnlInformation" style="display: none;">
        <%--        <div class="content">
            <h4 class="mb-0">DIPROM Guarantee
            </h4>
            <p>
                การันตี ให้ SMEs <b>มีหลักประกัน</b>
            </p>
        </div>--%>

        <div class="card card-style">
            <%--<img src="<%= ResolveClientUrl("~/images/Banner/Information_DIPROM_02.png") %>" />--%>
            <div class="content pb-0">
                <h3>รายละเอียดโครงการ</h3>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;โครงการ “ติดปีกเอสเอ็มอี หลักทรัพย์ไม่มี ดีพร้อมค้ำประกันให้” โดยโครงการนี้เป็นการบูรณาการระหว่างกรมส่งเสริมอุตสาหกรรมหรือดีพร้อม (DIPROM)จึงร่วมมือกับหน่วยงานพันธมิตรได้แก่ บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม ธนาคารกรุงไทย จำกัด (มหาชน)ธนาคารพัฒนาวิสาหกิจขนาดกลางและขนาดย่อมแห่งประเทศไทยธนาคารเพื่อการส่งออกและนำเข้าแห่งประเทศไทย และธนาคารออมสิน เพื่อเสริมศักยภาพการเงินให้กับผู้ประกอบการ SMEs เข้าถึงแหล่งเงินทุนควบคู่กับการค้ำประกัน ลดภาระต้นทุนทางการเงิน และเพิ่มโอกาสในการเข้าถึงแหล่งเงินทุน โดยใช้หนังสือค้ำประกันแทนหลักทรัพย์
                </p>
                <%--                <h4>หลักการและเหตุผล</h4>
                <div>
                    <a style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ปัจจุบันวิสาหกิจขนาดกลางและขนาดย่อม(SMEs)ต้องเผชิญกับปัญ หาและความท้าทายรอบด้านทั้งในเรื่องความก้าวหน้าทางเทคโนโลยีที่ทำให้พฤติกรรมของผู้บริโภคเริ่มเปลี่ยนแปลงไปภาวะเศรษฐกิจถดถ้อยที่ส่งผลต่ออัตราดอกเบี้ยและการชะลอตัวของระบบเศรษฐกิจทั่วโลกและความขัดแย้งทางภูมิรัฐศาสตร์จากสงครามต่างๆที่กระทบต่อการนำเข้าและส่งออกทำให้SMEsในปัจจุบันต้องปรับตัวเพื่อการอยู่รอดและสร้างการเติบโตอย่างยั่งยืนกรมส่งเสริมอุตสาหกรรมหรือดีพร้อม (DIPROM)จึงร่วมมือกับหน่วยงานพันธมิตรได้แก่ บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม ธนาคารกรุงไทย จำกัด (มหาชน)ธนาคารพัฒนาวิสาหกิจขนาดกลางและขนาดย่อมแห่งประเทศไทยธนาคารเพื่อการส่งออกและนำเข้าแห่งประเทศไทย และธนาคารออมสิน </a>
                </div>--%>
                <h5>วัตถุประสงค์</h5>
                <div>
                    <ol class="align-self-center me-auto">
                        <li>เพื่อบูรณาการความร่วมมือในการสนับสนุนและช่วยเหลือวิสาหกิจขนาดกลางและขนาดย่อมให้สามารถเข้าถึงแหล่งเงินทุนควบคู่กับการค้ำประกัน</li>
                        <li>เพื่อเพิ่มโอกาสในการเข้าถึงแหล่งเงินทุนให้กับวิสาหกิจขนาดกลางและขนาดย่อม</li>
                    </ol>
                </div>
                <%--<h4>ความคาดหวัง/ผลที่คาดว่าจะได้รับ</h4>
                <div>
                    <a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;วิสาหกิจขนาดกลางและขนาดย่อมสามารถเข้าถึงหลักประกันและแหล่งเงินทุน โดยสามารถต่อยอด การดำเนินธุรกิจและสร้างโอกาสเติบโตได้ คิดเป็นมูลค่าทางเศรษฐกิจ ไม่น้อยกว่า 8,000 ล้านบาท </a>
                </div>--%>
                <h5>สิทธิประโยชน์สำหรับผู้ประกอบการสำหรับความร่วมมือครั้งนี้</h5>
                <div>
                    <ol class="align-self-center me-auto">
                        <li>สามารถทราบผลการพิจารณาคุณสมบัติเบื้องต้น ภายใน 7 วันทำการ (สำหรับกรณีเอกสารครบถ้วน)</li>
                        <%--<li>ผู้ประกอบการที่สมัครภายใน 30 วันหลังจาก วันที่เปิดรับสมัคร (14/2/2567) และได้รับอนุมัติสินเชื่อพร้อมวงเงินค้ำประกัน 100 รายแรก จะได้รับสิทธิประโยชน์ ยกเว้นค่าดำเนินการค้ำประกัน (ค่าออกหนังสือค้ำประกัน)</li>--%>
                        <li>ผู้ประกอบการที่สมัครภายใน 30 วันหลังจาก วันที่เปิดรับสมัคร (14/2/2567) และได้รับอนุมัติสินเชื่อพร้อมวงเงินค้ำประกัน 100 รายแรก จะได้รับสิทธิประโยชน์ ยกเว้นค่าดำเนินการค้ำประกัน (ค่าออกหนังสือค้ำประกัน) *สงวนสิทธิสำหรับเฉพาะผลิตภัณฑ์ BI7 เท่านั้น</li>
                    </ol>
                </div>
                <%--<h4>หน่วยร่วมดำเนินการ  </h4>
                <div>
                    <ol class="align-self-center me-auto">
                        <li>กรมส่งเสริมอุตสาหกรรม กระทรวงอุตสาหกรรม </li>
                        <li>บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม</li>
                        <li>ธนาคารกรุงไทย จำกัด (มหาชน) </li>
                        <li>ธนาคารพัฒนาวิสาหกิจขนาดกลางและขนาดย่อมแห่งประเทศไทย </li>
                        <li>ธนาคารเพื่อการส่งออกและนำเข้าแห่งประเทศไทย </li>
                        <li>ธนาคารออมสิน </li>
                    </ol>
                </div>--%>
            </div>
            <div id="registerInformation" style="display: block">
                <%--<a href="#" onclick="" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-gray shadow-bg shadow-bg-xs">พบกับการลงทะเบียน เร็วๆ นี้</a>--%>
                <input type="button"
                    value="ลงทะเบียน"
                    onclick="AcceptStep1()"
                    id="btnRegisterInformation"
                    class="btn btn-full rounded-s gradient-blue shadow-bg shadow-bg-s w-100"
                    style="font-size: 18px !important;"
                    data-bs-toggle="offcanvas"
                    data-bs-target="#menu-exchange">
            </div>

        </div>
    </div>

    <!-- Page Consent-->
    <div class="card card-style mx-3 px-2 py-2" id="pnlConsent" style="display: none;">
        <div class="content">
            <h3 class="font-18 font-800 mb-0">เงื่อนไขการใช้บริการ</h3>

            <p style="margin-bottom: 5px;">
                กรุณาอ่านเงื่อนไขการใช้บริการให้ครบถ้วนก่อนลงทะเบียน
            </p>

            <div style="border-radius: 10px; height: 500px; margin-bottom: 30px; overflow: scroll; border: 1px solid silver; padding: 10px;">
                <div style="height: 500px;">

                    <p>1. บสย. จะดำเนินการเก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคลตามที่เจ้าของข้อมูลส่วนบุคคลได้ให้ไว้แก่ บสย. หรือที่ บสย.อาจเข้าถึงได้จากแหล่งอื่น เพื่อการประมวลผล การบริหารจัดการ การดำเนินการเกี่ยวกับ วิเคราะห์ วิจัย สถิติสำรวจความคิดเห็น แนะนำ เสนอปรับปรุงบริการหรือพัฒนาผลิตภัณฑ์ต่างๆ ของ บสย. รวมทั้งการให้ความช่วยเหลือลูกหนี้ตามมาตรการจูงใจประนอมหนี้และการปรับปรุงโครงสร้างหนี้กับ บสย. นำเสนอสิทธิประโยชน์ที่เหมาะสมให้แก่เจ้าของข้อมูลส่วนบุคคลผ่านการนำเสนอบริการหรือผลิตภัณฑ์ และการแจ้งข่าวสารต่างๆ ของ บสย.</p>

                    <p>ข้อมูลส่วนบุคคลที่ บสย. ได้รับมาจากเจ้าของข้อมูลส่วนบุคคลจากการติดต่อผ่านช่องทาง “กรมส่งเสริมอุตสาหกรรม” หรือการเข้าร่วมกิจกรรมของ บสย.หรือพันธมิตรทางธุรกิจ และ/หรือนิติบุคคลอื่นจัดขึ้น ที่มีการบันทึกเสียง ภาพนิ่ง ภาพเคลื่อนไหว CCTVหากมีการนำไปใช้เพื่อการประชาสัมพันธ์กิจกรรมต่างๆ บสย. ผ่านสื่อออนไลน์ สื่อวีดีทัศน์ สื่อโทรทัศน์สื่อสิ่งพิมพ์ สื่ออิเล็กทรอนิกส์ บสย. จะคำนึงถึงสิทธิขั้นพื้นฐานของเจ้าของข้อมูลส่วนบุคคลเป็นหลัก รวมถึงบุคคลอื่น (ถ้ามี) และรักษาความปลอดภัยของข้อมูลเป็นสำคัญ</p>

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
                    <a href="#" onclick="AcceptStep2()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ถัดไป</a>
                </div>
            </div>
        </div>

    </div>

    <!-- Page FillIdCard  Check การลงทะเบียนสำเร็จไปแล้ว จากเลขบัตรประชาชนที่กรอ -->
    <div class="card card-style px-2 py-2" id="pnlFillIdCard" style="display: none;">
        <div class="content">
            <h3 class="font-18 font-800 mb-0">ตรวจสอบข้อมูลการลงทะเบียน</h3>
            <div class="card card-img">
                <img src="<%= ResolveClientUrl("~/images/Banner/ValidIdentityCard_RIPROM_01.png") %>" />
            </div>
            <br />
            <div class="form-custom form-label no-icon mb-3">
                <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==13) return false;" class="form-control rounded-xs" id="txtIdentityId" placeholder="เลขบัตรประจำตัวประชาชน/เลขนิติบุคคล" maxlength="13" value="">
                <label for="txtIdentityId" class="form-label-always-active color-highlight">กรอกข้อมูล 13 หลัก เพื่อตรวจสอบคุณสมบัติ </label>
                <span>(required)</span>
            </div>
            <a href="#" id="btnSubmitCheck" onclick="ValidatefiledIdentityCard()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ยืนยัน</a>
        </div>
    </div>

    <!-- Page Detail Data From OTP -->
    <div class="card card-style px-2 py-2" id="pnlConfirmOTP" style="display: none;">
        <div class="content">
            <h3 class="font-18 font-800 mb-0">ยืนยันรหัส OTP</h3>

            <div class="form-custom mb-1">
                <i class="bi bi-calendar font-13"></i>
                <label for="c6a" class="color-highlight form-label-always-active">ต้องการ ส่ง OTP ไปที่ หมายเลข</label>
                <input disabled="disabled" autocomplete="off" type="text" class="form-control rounded-xs" id="txtMobilePhoneSentOTP" placeholder="" maxlength="10" value="xxx-xxx-xxxx">
            </div>
            <a href="#" id="btnSendOTP" onclick="SendOTP()" class="btn btn-full gradient-highlight shadow-bg shadow-bg-s mt-4">ขอรหัส OTP</a>
            <br />

            <div id="pnlKeyInOTP" style="display: none;">
                <div class="form-custom form-label form-border form-icon mb-1 bg-transparent">
                    <i class="bi bi-chat-right-text-fill font-16"></i>
                    <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==6) return false;" class="form-control rounded-xs font-18" id="txtOTP" placeholder="โปรดระบุรหัส OTP 6 หลัก" maxlength="6">
                    <label for="c1" class="color-theme">โปรดระบุรหัส OTP ที่ได้รับ 6 หลัก</label>
                    <span>(required)</span>
                </div>

                <div class="mb-4" style="text-align: left; display: block;">
                    Reference Number : <span id="ltlReferenceNumber"></span>
                </div>

                <a href="#" onclick="AcceptStep4()" class="btn btn-full gradient-highlight shadow-bg shadow-bg-s mt-4">ยืนยันรหัส OTP</a>

            </div>

        </div>
    </div>

    <!-- Page DIPROM Data ลงทะเบียนได้ เลขบัตรประชาชนเดียว  -->
    <div class="card card-style mx-3 px-2 py-2" id="pnlDataDIPROM" style="display: none;">

        <div class="content">
            <h3 class="font-18 font-800 mb-0">ข้อมูลการตรวจสอบคุณสมบัติเบื้องต้น </h3>
            <p>รายละเอียดสถานะ</p>

            <div class="card card-style gradient-green shadow-bg shadow-bg-s" id="btnStatusGreen" style="display: none;">
                <div class="content">
                    <a class="d-flex">
                        <div class="align-self-center">
                            <h1 class="mb-0 font-40"><i class="bi bi-check2-square color-white pe-3"></i></h1>
                        </div>
                        <div class="align-self-center">
                            <h5 class="color-white font-300 mb-0 mt-0 pt-1">คุณสมบัติผ่านเกณฑ์
                                <br>
                                สามารถพิจารณา Pre-Screen 
                            </h5>
                        </div>
                    </a>
                </div>
            </div>

            <div class="card card-style gradient-yellow shadow-bg shadow-bg-s" id="btnStatusYellow" style="display: none;">
                <div class="content">
                    <a class="d-flex">
                        <div class="align-self-center">
                            <h1 class="mb-0 font-40"><i class="bi bi-check2-square color-white pe-3"></i></h1>
                        </div>
                        <div class="align-self-center">
                            <h5 class="color-white font-300 mb-0 mt-0 pt-1">คุณสมบัติผ่านเกณฑ์
                            <br>
                                สามารถพิจารณา Pre-Screen
                            </h5>
                        </div>
                    </a>
                </div>
            </div>

            <div class="card card-style gradient-red shadow-bg shadow-bg-s" id="btnStatusRed" style="display: none;">
                <div class="content">
                    <a class="d-flex">
                        <div class="align-self-center">
                            <h1 class="mb-0 font-40"><i class="bi bi-x-square color-white pe-3"></i></h1>
                        </div>
                        <div class="align-self-center">
                            <h5 class="color-white font-300 mb-0 mt-0 pt-1">คุณสมบัติไม่เกณฑ์ผ่านเกณฑ์
                   <br>
                                ต้องเข้าอบรมกับทาง FA Center
                            </h5>
                        </div>
                    </a>
                </div>
            </div>

            <div class="card card-style gradient-gray shadow-bg shadow-bg-s" id="btnStatusGray" style="display: none;">
                <div class="content">
                    <%--<a class="d-flex">--%>
                    <div class="align-self-center">
                        <h1 class="mb-0 font-40"><i class="bi bi-exclamation-lg color-white pe-3"></i></h1>
                    </div>
                    <div class="align-self-center">
                        <h5 class="color-white font-300 mb-0 mt-0 pt-1">คุณสมบัติไม่ครบถ้วน
                    <br>
                            ติดต่อเจ้าหน้าที่
                    <br>
                            กรมส่งเสริมอุตสาหกรรม
                    <br>
                            เพื่อแก้ไขข้อมูลให้ครบถ้วน
                        </h5>
                    </div>
                    <%--</a>--%>
                </div>
            </div>

            <div class="gradient-blue shadow-bg shadow-bg-s rounded-m" id="btnStatusFix" style="display: block;">
                <div class="content">
                    <a class="d-flex">
                        <div class="align-self-center">
                            <%--<h1 class="mb-0 font-40"><i class=" color-white pe-3"></i></h1>--%>
                        </div>
                        <div class="align-self-center">
                            <h5 class="color-white font-300 mb-0 mt-0 pt-1">รายละเอียดข้อมูล
                            <br>
                                สำหรับลงทะเบียนเข้าร่วมโครงการ
                            </h5>
                        </div>
                    </a>
                </div>
            </div>



        </div>

        <div class="content">

            <p>
                กรุณาตรวจสอบข้อมูลของท่าน
            </p>

            <div style="border-radius: 10px; height: 500px; margin-bottom: 30px; overflow: scroll; border: 1px solid silver; padding: 10px;">
                <div style="height: 500px;">
                    <div class="row" id="txtPreviewInformation">
                        <div class="col-12">
                            <div class="content m-0">

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtCustomerName" class="color-highlight form-label-always-active">ชื่อนามสกุลผู้กู้</label>
                                    <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtCustomerName" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtCardID" class="form-label-always-active color-highlight">หมายเลขผู้กู้</label>
                                    <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtCardID" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtSpouseName" class="form-label-always-active color-highlight">ชื่อนามสกุลคู่สมรส</label>
                                    <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtSpouseName" placeholder="" value="">
                                </div>

                                <%--<div class="form-custom form-label form-border mb-3 bg-transparent">
                                     <label for="txtBusinessName" class="color-highlight form-label-always-active">ID-คู่สมรส</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtCardIDSpouse" placeholder=""  value="">                                   
                                </div>--%>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtMDName" class="color-highlight form-label-always-active">ชื่อนามสกุลกรรมการผู้มีอำนาจลงนาม</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtMDName" placeholder="" value="">
                                </div>

                                <%--<div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtProvince" class="color-highlight form-label-always-active">ID ผู้มีอำนาจลงนาม</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtCardIDMD" placeholder="" value="">
                                </div>--%>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtShareHolderName" class="color-highlight form-label-always-active">ชื่อนามสกุลผู้ถือหุ้นตั้งแต่ร้อยละ 20 ขึ้นไป</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtShareHolderName" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtProvince" class="color-highlight form-label-always-active">ลักษณะธุรกิจ</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtBusinessType" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtProvince" class="color-highlight form-label-always-active">กรรมสิทธิ์ของสถานที่ประกอบกิจการ</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtEstablishmentType" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtYearIncorporate" class="color-highlight form-label-always-active">อายุกิจการ (ปี)</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtYearIncorporate" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtIndustryCode" class="color-highlight form-label-always-active">ประเภทกิจการ</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtIndustryCode" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtProvinceCode" class="color-highlight form-label-always-active">จังหวัดที่ตั้งกิจการ</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtProvinceCode" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtOwnerAge" class="color-highlight form-label-always-active">อายุผู้บริหารหลัก (ปี)</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtOwnerAge" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtMaritalStatus" class="color-highlight form-label-always-active">สถานะภาพการสมรสของผู้บริหารหลัก</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtMaritalStatus" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtYearExperience" class="color-highlight form-label-always-active">ประสบการณ์โดยตรงในการทําธุรกิจนี้ (ปี)</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtYearExperience" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtIncome" class="color-highlight form-label-always-active">รายได้รวมของกิจการ (ต่อเดือน)</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtIncome" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtExpense" class="color-highlight form-label-always-active">กิจการคุณมีค่าใช้จ่าย (ต่อเดือน)</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtExpense" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtLoanAmount" class="color-highlight form-label-always-active">วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท)</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtLoanAmount" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtMobileNo" class="color-highlight form-label-always-active">เบอร์โทรศัพท์</label>
                                    <input type="text" class="form-control rounded-xs btn-disable" id="txtMobileNo" placeholder="" value="">
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <label for="txtBankSendEmail" class="color-highlight form-label-always-active">ธนาคารที่ต้องการขอสินเเชื่อ</label>
                                    <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtBankSendEmail" placeholder="" value="">
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-6">
                    <a href="#" onclick="ShowModalCancel()" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ยกเลิก</a>
                </div>
                <div class="col-6">
                    <a href="#" onclick="AcceptStep5()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>

        </div>

    </div>

    <!-- Page Register Complete -->
    <div class="card card-style px-2 py-2" id="pnlRegisterComplete" style="display: none;">
        <div class="content">
            <h3 class="font-18 font-800 mb-0">สถานะการดำเนินการ</h3>
        </div>

        <div class="content">
            <div class="card card-style">
                <div class="content">
                    <div class="tabs tabs-pill" id="tab-group-2">

                        <div class="collapse show" id="statusbarMain" data-bs-parent="#tab-group-2">

                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-1">

                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-1-square font-18 color-white"></i></span>
                                </div>

                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">ข้อมูลและเอกสารครบถ้วน</h5>
                                    <p class="mb-0 font-11 opacity-70">ตรวจสอบข้อมูลกรมอุตสาหกรรม</p>
                                </div>

                                <div class="align-self-center ms-auto text-end font-25 font-25" id="statusBar1">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>

                            </a>
                            <div class="divider my-2 opacity-75"></div>

                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-4">
                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-2-square font-18 color-white"></i></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">ยืนยันตัวตนและลงทะเบียนโครงการสำเร็จ</h5>
                                    <p class="mb-0 font-11 opacity-70">ยืนยันตัวตนและลงทะเบียนโครงการสำเร็จ</p>
                                </div>
                                <div class="align-self-center ms-auto text-end font-25" id="statusBar2">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>
                            </a>
                            <div class="divider my-2 opacity-50"></div>

                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-4">
                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-3-square font-18 color-white"></i></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">ผลตรวจสุขภาพทางการเงินเบื้องต้น</h5>
                                    <p class="mb-0 font-11 opacity-70">ผลตรวจสุขภาพทางการเงินเบื้องต้น</p>
                                </div>
                                <div class="align-self-center ms-auto text-end font-25" id="statusBar3">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>
                            </a>
                            <div class="divider my-2 opacity-50"></div>

                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-4">
                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-4-square font-18 color-white"></i></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">ผลการพิจารณาเบื้องต้น</h5>
                                    <p class="mb-0 font-11 opacity-70">ผลการพิจารณาเบื้องต้น</p>
                                </div>
                                <div class="align-self-center ms-auto text-end font-25" id="statusBar4">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>
                            </a>
                            <div class="divider my-2 opacity-50"></div>

                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-4">
                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-5-square font-18 color-white"></i></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">นำส่งธนาคารตามที่ท่านเลือก</h5>
                                    <p class="mb-0 font-11 opacity-70">นำส่งธนาคารตามที่ท่านเลือก</p>
                                </div>
                                <div class="align-self-center ms-auto text-end font-25" id="statusBar5">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>
                            </a>
                            <%--<div class="divider my-2 opacity-50"></div>--%>

                            <%--                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-4">
                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-6-square font-18 color-white"></i></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">ธนาคารอนุมัติสินเชื่อ</h5>
                                    <p class="mb-0 font-11 opacity-70">ธนาคารอนุมัติสินเชื่อ</p>
                                </div>
                                <div class="align-self-center ms-auto text-end font-25" id ="statusBar6">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>
                            </a>
                            <div class="divider my-2 opacity-50"></div>

                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-4">
                                <div class="align-self-center">
                                    <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs"><i class="bi bi-7-square font-18 color-white"></i></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <h5 class="pt-1 mb-n1">บสย. ออกหนังสือค้ำประกัน</h5>
                                    <p class="mb-0 font-11 opacity-70">บสย. ออกหนังสือค้ำประกัน</p>
                                </div>
                                <div class="align-self-center ms-auto text-end font-25" id ="statusBar7">
                                    <span class="bi bi-check2-circle color-gray-light"></span>
                                </div>
                            </a>
                            <div class="divider my-2 opacity-50"></div>--%>
                        </div>

                    </div>

                </div>
            </div>

            <div class="card card-style" id="pnlConsultFACenter" style="display: none;">
                <div class="content">
                    <p class="mb-2">
                        <i class="bi bi-x-diamond" style="color: crimson;">คุณสมบัติไม่ผ่านเงื่อนไขในการเข้าร่วมโครงการ สามารถลงทะเบียนรับคำปรึกษา กับศูนย์ที่ปรึกษาเพื่อรับ คำแนะนำ ในการเตรียมความพร้อมก่อนเข้าร่วมโครงการ </i>
                    </p>
                </div>
                <a href="#" id="btnConsultFACenter" onclick="redirectToConsultFACenter()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">รับคำปรึกษา</a>
                <%--<a href="#" id="btnConsultFACenter" onclick="ShowModalConsult()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">รับคำปรึกษา</a>--%>
            </div>

            <div class="card card-style" id="pnlConsultClinicOnline" style="display: none;">
                <div class="content">
                    <p class="mb-2">
                        <i class="bi bi-x-diamond" style="color: darkblue;">ไม่ผ่านการอนุมัติ คุณมีโอกาสในการขอสินเชื่อ สนใจรับคำแนะนำเพิ่มเติม คลิ๊ก ลงทะเบียนเพื่อติดต่อเจ้าหน้าที่ สาขาบสย. เพื่อเตรียมความพร้อมก่อนเข้าร่วมโครงการ </i>
                    </p>
                </div>
                <a href="#" id="btnConsultClinicOnline" onclick="redirectToConsultClinicOnline()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ลงทะเบียน</a>
                <%--<a href="#" id="btnConsultClinicOnline" onclick="ShowModalConsultClinic()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ลงทะเบียน</a>--%>
            </div>

        </div>

        <a href="#" id="btnRegisterComplete" onclick="BackToMain()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">กลับสู่หน้าหลัก</a>

    </div>



    <!-- 1. Component Modal Confirm-->
    <div class="modal fade" id="checkRegisterModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalToggleLabel">ยืนยันตรวจสอบสิทธิ์ในลงทะเบียน</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้ายินยอมให้ บสย. เก็บข้อมูลส่วนบุคคลเพื่อใช้ในตรวจสอบ
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>
                    <a href="btnAcceptModal" onclick="Accept3Modal()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>
        </div>
    </div>

    <!-- 2. Component Modal Confirm ConsultFA-->
    <div class="modal fade" id="confirmConsult" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="cancelRegisterLabelConsultFA">ยืนยันลงทะเบียนรับคำปรึกษา</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; โปรดยืนยันการลงทะเบียน รับคำปรึกษา 
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#cancelRegister" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>

                    <a href="#" onclick="AcceptConsultFA()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>
        </div>
    </div>

    <!-- 3. Component Modal Confirm ConsultClinic-->
    <div class="modal fade" id="confirmConsultClinic" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="cancelRegisterLabelConsultClinic">ยืนยันลงทะเบียนติดต่อสาขา</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; โปรดยืนยันการลงทะเบียน คิดต่อสาขา
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#cancelRegister" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>

                    <a href="#" onclick="AcceptConsultClinic()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <%--    <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>--%>
    <script src="<%= ResolveClientUrl("~/scripts/Page/DIPROM.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>
