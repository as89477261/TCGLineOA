<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerHealthCheck.views.TCCProject.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - TCC Connect</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddProfileStatus" runat="server" />
    <asp:HiddenField ID="hddProfileInformation" runat="server" />
    <asp:HiddenField ID="hddProfileRegisterNo" runat="server" />
    <asp:HiddenField ID="hddJsonAddress" runat="server" />
    <asp:HiddenField ID="hddacceptCondition" runat="server" />

    <!-- Page Wrapper-->
    <div id="page">
        <div class="page-content footer-clear" style="padding: 0px !important;">

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
                            <a href="#" onclick="submitConsent()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ถัดไป</a>
                        </div>
                    </div>

                </div>

                <%--fortest image-container  --%>
                <div class="content" style="display:none;">

                    <div class="tcc-image-container">

                        <img src="<%= ResolveClientUrl("~/images/Banner/Card_TCC_blue_1.png") %>" alt="รูปภาพตัวอย่าง" class="tcc-responsive-image" id="image">
                        <!-- Text Overlay 1 -->
                        <div class="tcc-text-overlay" id="textOverlay1">บัตรสิทธิประโยชน์สมาชิก</div>
                        <!-- Text Overlay 2 -->
                        <div class="tcc-text-overlay" id="textOverlay2">สมัคร วันดี</div>
                        <!-- Text Overlay 3 -->
                        <div class="tcc-text-overlay" id="textOverlay3">หอการค้าไทย</div>
                        <!-- Text Overlay 4 -->
                        <div class="tcc-text-overlay" id="textOverlay4">เลขที่สมาชิก</div>
                        <!-- Text Overlay 5 -->
                        <div class="tcc-text-overlay" id="textOverlay5">1671234567890</div>
                        <!-- Text Overlay 6 -->
                        <div class="tcc-text-overlay" id="textOverlay6">วันหมดอายุบัตร</div>
                        <!-- Text Overlay 7 -->
                        <div class="tcc-text-overlay" id="textOverlay7">16/05/2567</div>
                        <!-- Imp Overlay 8-->
                        <img src="<%= ResolveClientUrl("~/images/pictures/31t.jpg") %>" alt="รูปภาพตัวอย่าง" class="tcc-profile-image" id="profileImage">
                    </div>
                </div>
            </div>

            <!-- Page Information -->

            <div class="card card-style" id="pnlInformation" style="display: none;">

                <div class="content">
                    <h4 class="mb-0">สิทธิพิเศษสำหรับลูกค้า บสย.
                    </h4>
                    <p>
                        (เมื่อสมัครเป็นสมาชิกหอการค้าและสภาหอการค้าไทย)
                    </p>
                </div>
                <div class="card card-style">
                    <img src="<%= ResolveClientUrl("~/images/Banner/TCCBannerInformation_1.png") %>" />
                </div>

                <div class="content pb-0">
                    <h3>รายละเอียดโครงการ</h3>
                    <p>โครงการความร่วมมือระหว่างบรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม (บสย.) กับหอการค้าและสภาหอการค้าไทย เพื่อยกระดับศักยภาพผู้ประกอบการที่เป็นลูกค้าของ บสย. ทั้งที่เป็นนิติบุคคลและบุคคลธรรมดา โดยลูกค้าของ บสย. สามารถสมัครเป็นสมาชิกสมทบ หอการค้าและสภาหอการค้าไทย ได้ในอัตราค่าบำรุงสมาชิกสมทบราคาพิเศษ เพียง 500 บาท (ไม่รวม vat) พร้อมรับสิทธิประโยชน์มากมาย </p>
                    <h4>รับสิทธิพิเศษมากมาย</h4>
                    <div>
                        <a style=""><i class="bi bi-check-circle-fill color-green-light"></i>&nbsp;อัตราค่าบำรุงสมาชิกสมทบเพียง <strong style="color: orangered">500</strong> บาท (ไม่รวม vat)</a><br />
                        <a style=""><i class="bi bi-check-circle-fill color-green-dark"></i>&nbsp;ฟรี! Online Training หลักสูตรออนไลน์ต่างๆ ของหอการค้าไทย</a><br />
                        <a style=""><i class="bi bi-check-circle-fill color-green-dark"></i>&nbsp;ฟรี! ข้อมูลข่าวสารด้านเศรษฐกิจ</a><br />
                        <a style=""><i class="bi bi-check-circle-fill color-green-dark"></i>&nbsp;ส่วนลด/ฟรี! โครงการ/หลักสูตรเพื่อสนับสนุนและพัฒนาผู้ประกอบการ</a><br />
                        <a style=""><i class="bi bi-check-circle-fill color-green-dark"></i>&nbsp;ส่วนลด! มากมายสบายกระเป๋า อาทิ</a><br />
                        <ul class="align-self-center me-auto">
                            <li>สิทธิพิเศษจาก LAZADA</li>
                            <li>สิทธิพิเศษจาก Flash Express และไปรษณีย์ไทย</li>
                            <li>สิทธิพิเศษจาก สายการบินต่างๆ</li>
                            <li>สิทธิพิเศษ ร้านค้า โรงแรม/ที่พัก ของฝาก คลินิกทันตกรรม และบริการ กว่า 2,000 รายการ</li>
                        </ul>
                    </div>

                    <%--            <div class="row mt-4">
                <div class="col-">
                    <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-blue shadow-bg shadow-bg-xs" onclick="SubmitInformation('1')">บุคคลธรมมดา</a>
                </div>
                <div class="col-6">
                    <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-green shadow-bg shadow-bg-xs" onclick="SubmitInformation('2')">นิติบุคคล</a>
                </div>

            </div>--%>


                    <a href="#" onclick="SubmitInformation('1')" id=""
                        class="btn btn-full gradient-blue shadow-bg shadow-bg-s mt-4">ถัดไป
                    </a>
                </div>

            </div>
            <!-- Page Input Id Card-->

            <div class="card card-style px-2 py-2" id="pnlFillIdCard" style="display: none;">
                <div class="content">
                    <h4 class="pb-3 pt-4">ตรวจสอบข้อมูลการลงทะเบียน</h4>
                    <div class="card card-img">
                        <img src="<%= ResolveClientUrl("~/images/Banner/TCCBannerInformation_1.png") %>" />
                    </div>
                    <br />
                    <div class="form-custom form-label no-icon mb-3">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==13) return false;" class="form-control rounded-xs" id="txtIdentityId" placeholder="เลขบัตรประจำตัวประชาชน" maxlength="13" value="">
                        <label for="txtIdentityId" class="form-label-always-active color-highlight">กรุณากรอกเลขบัตรประชาชน 13 หลัก</label>
                        <span>(required)</span>
                    </div>
                    <a href="#" id="btnSubmitIDcard" onclick="ValidateIdentityCard()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ลงทะเบียน</a>
                </div>
            </div>

            <!-- Page Input Register Person Form1-->
            <div class="card card-style px-2 py-2" id="pnlRegisterMemberTCCPerson" style="display: none;">
                <div class="content mt-0">
                    <h4 class="pb-3 pt-4">แบบฟอร์มสมัคร บุคคลธรรมดา</h4>

                    <div class="form-custom form-label form-border form-icon mb-3 bg-transparent btn-disable-2">
                        <i class="bi bi-file-earmark-break font-13"></i>
                        <input type="text" class="form-control rounded-xs" id="txtregisterNo" placeholder="" autocomplete="off" value="" />
                        <label for="txtregisterNo" class="color-highlight form-label-always-active">เลขประจำตัวบัตรประชาชน</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border form-icon" style="display: none;">
                        <i class="bi bi-calendar font-13"></i>
                        <label for="c6a" class="color-highlight form-label-always-active">ประเภทการสมัคร</label>
                        <select class="form-select rounded-xs" id="ddlBusinessType">
                            <option value="001">บุคคลธรรมดา</option>
                        </select>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtfirstName" placeholder="โปรดระบุชื่อ" autocomplete="off" value="ใจฟู" />
                        <label for="txtfirstName" class="color-highlight form-label-always-active">ชื่อ</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtlastName" placeholder="โปรดระบุนามสกุล" autocomplete="off" value="รักษา" />
                        <label for="txtlastName" class="color-highlight form-label-always-active">นามสกุล</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtemail" placeholder="โปรดระบุ อีเมลล์" autocomplete="off" value="Nut@gmail.com" />
                        <label for="txtemail" class="color-highlight form-label-always-active">อีเมลล์ที่ใช้งานปัจจุบัน</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==10) return false;" class="form-control rounded-xs" id="txtMobilePhone" placeholder="โปรดระบุเบอร์มือถือ ขึ้นต้นด้วย 0" value="0886441138" />
                        <label for="txtMobilePhone" class="color-highlight form-label-always-active">เบอร์มือถือติดต่อได้</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border form-icon">
                        <i class="bi bi-calendar font-13"></i>
                        <label for="c6a" class="color-highlight form-label-always-active">อาชีพ</label>
                        <select class="form-select rounded-xs" id="ddlOccupation">
                            <option value="" selected="">- กรุณาเลือก -</option>
                            <option value="1">พนักงานบริษัท</option>
                            <option value="2">ธุรกิจส่วนตัว</option>
                            <option value="3">พนักงานราชการ / รัฐวิสาหกิจ</option>
                        </select>
                    </div>

                    <div id="option1Details" style="display: none;">

                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtproductName" placeholder="ระบุผลิตภัณฑ์ (เฉพาะ ธุรกิจส่วนตัว)" autocomplete="off" />
                            <label for="txtproductName" class="color-highlight form-label-always-active">ผลิตภัณฑ์</label>
                        </div>

                        <div class="form-custom form-label form-border form-icon">
                            <i class="bi bi-calendar font-13"></i>
                            <label for="ddlbussinessType" class="color-highlight form-label-always-active">ลักษณะกิจการ</label>
                            <select class="form-select rounded-xs" id="ddlbussinessType">
                                <option value="" selected="">- กรุณาเลือก -</option>
                                <option value="MF">ผู้ผลิต</option>
                                <option value="EX">ผู้ส่งออก</option>
                                <option value="IM">ผู้นำเข้า</option>
                                <option value="DT">ผู้จำหน่าย</option>
                                <option value="WS">ผู้ค้าส่ง</option>
                                <option value="RT">ผู้ค้าปลีก</option>
                                <option value="SV">บริการ</option>
                                <option value="SP">ตัวแทนออกของ</option>
                                <option value="DA">ผู้แทนจำหน่าย</option>
                                <option value="SR">ผู้ตรวจสอบ</option>
                            </select>
                        </div>


                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtproductExportCountry" placeholder="ระบุ ชื่อประเทศ (หากมีการส่งออก)" autocomplete="off" />
                        <label for="txtproductExportCountry" class="color-highlight form-label-always-active">ส่งออก ไปยังประเทศ</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtproductNameExport" placeholder="ระบุ ผลิตภัณฑ์ (หากมีการส่งออก)" autocomplete="off" />
                        <label for="txtproductNameExport" class="color-highlight form-label-always-active">ผลิตภัณฑ์ ที่ส่งออก</label>
                        <span class="font-10">(required)</span>
                    </div>

                </div>

                <a href="#" onclick="GenDataPersonPage();" id="btnSubmitRegisterTCCPerson"
                    class="btn btn-full gradient-blue shadow-bg shadow-bg-s mt-4">ถัดไป
                </a>

            </div>

            <!-- Page Input Register Juristic-->
            <div class="card card-style px-2 py-2" id="pnlRegisterMemberTCCJuristic" style="display: none;">
                <div class="content mt-0">
                    <h4 class="pb-3 pt-4">แบบฟอร์มสมัคร นิติบุคคล</h4>
                    <div class="form-custom form-label form-border form-icon">
                        <i class="bi bi-calendar font-13"></i>
                        <label for="c6a" class="color-highlight form-label-always-active">ประเภทของธุรกิจ</label>
                        <select class="form-select rounded-xs" id="ddlBusinessTypeJuristic">
                            <option value="002">นิติบุคคล</option>
                        </select>
                    </div>

                    <div class="form-custom form-label form-border form-icon mb-3 bg-transparent btn-disable-2">
                        <i class="bi bi-file-earmark-break font-13"></i>
                        <input type="text" class="form-control rounded-xs" id="txtregisterNoJuristic" placeholder="" autocomplete="off" value="" />
                        <label for="txtregisterNoJuristic" class="color-highlight form-label-always-active">เลขทะเบียนนิติบุคคล</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtcompanyNameJuristic" placeholder="โปรดระบุชื่อกิจการ" autocomplete="off" value="ทดสอบสย">
                        <label for="txtcompanyNameJuristic" class="color-highlight form-label-always-active">ชื่อกิจการ</label>
                        <span>(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="text" class="form-control rounded-xs datepicker-th" id="txtissueDateJuristic" placeholder="จัดทะเบียน ณ วันที่" value="" maxlength="10" onkeypress="filterDigits(event)">
                        <label for="txtissueDateJuristic" class="color-highlight form-label-always-active">จดทะเบียนวันที่</label>
                        <span>(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtemailJuristic" placeholder="โปรดระบุ อีเมลล์" autocomplete="off" value="corp@gmail.com" />
                        <label for="txtemailJuristic" class="color-highlight form-label-always-active">อีเมลล์บริษัท</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==10) return false;" class="form-control rounded-xs" id="txtMobilePhoneJuristic" placeholder="โปรดระบุเบอร์มือถือ ขึ้นต้นด้วย 0" value="0889998888" />
                        <label for="txtMobilePhoneJuristic" class="color-highlight form-label-always-active">เบอร์โทรบริษัท</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border form-icon">
                        <i class="bi bi-calendar font-13"></i>
                        <label for="c6a" class="color-highlight form-label-always-active">รูปแบบกิจการ</label>
                        <select class="form-select rounded-xs" id="ddlCompanyType">
                            <option value="" selected="">- กรุณาเลือก -</option>
                            <option value="17">-</option>
                            <option value="1">ธนาคาร</option>
                            <option value="2">บรรษัท</option>
                            <option value="3">บริษัท</option>
                            <option value="4">บริษัทจำกัดมหาชน</option>
                            <option value="5">รัฐวิสาหกิจ</option>
                            <option value="6">ร้าน</option>
                            <option value="7">โรงแรม</option>
                            <option value="8">สมาคม</option>
                            <option value="9">สหกรณ์</option>
                            <option value="10">สำนักงาน</option>
                            <option value="11">หอการค้าต่างประเทศ</option>
                            <option value="12">หอการค้าต่างจังหวัด</option>
                            <option value="13">ห้าง</option>
                            <option value="14">ห้างหุ้นส่วนจำกัด</option>
                            <option value="15">ห้างหุ้นส่วนสามัญ</option>
                            <option value="16">สหกรณ์</option>
                            <option value="20">หอการค้าไทย</option>
                        </select>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtproductNameJuristic" placeholder="โปรดระบุ ผลิตภัณฑ์" autocomplete="off" value="ขวดนม" />
                        <label for="txtproductNameJuristic" class="color-highlight form-label-always-active">ผลิตภัณฑ์</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border form-icon">
                        <i class="bi bi-calendar font-13"></i>
                        <label for="c6a" class="color-highlight form-label-always-active">ประเภทธุรกิจ</label>
                        <select class="form-select rounded-xs" id="ddlBussinessType">
                            <option value="" selected="">- กรุณาเลือก -</option>
                            <option value="MF">ผู้ผลิต</option>
                            <option value="EX">ผู้ส่งออก</option>
                            <option value="IM">ผู้นำเข้า</option>
                            <option value="DT">ผู้จำหน่าย</option>
                            <option value="WS">ผู้ค้าส่ง</option>
                            <option value="RT">ผู้ค้าปลีก</option>
                            <option value="SV">บริการ</option>
                            <option value="SP">ตัวแทนออกของ</option>
                            <option value="DA">ผู้แทนจำหน่าย</option>
                            <option value="SR">ผู้ตรวจสอบ</option>
                        </select>
                    </div>


                    <div id="option2Details" class="form-custom form-label form-border mb-3 bg-transparent" style="display: none;">
                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtproductExportCountryJuristic" placeholder="ระบุ ชื่อประเทศ (หากมีการส่งออก)" autocomplete="off" value="ไทย" />
                            <label for="txtproductExportCountryJuristic" class="color-highlight form-label-always-active">ส่งออก ไปยังประเทศ</label>
                            <span class="font-10">(required)</span>
                        </div>

                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                            <input type="text" class="form-control rounded-xs" id="txtproductNameExportJuristic" placeholder="ระบุ ผลิตภัณฑ์ (หากมีการส่งออก)" autocomplete="off" value="ขวดนำส่งออก" />
                            <label for="txtproductNameExportJuristic" class="color-highlight form-label-always-active">ผลิตภัณฑ์ ที่ส่งออก</label>
                            <span class="font-10">(required)</span>
                        </div>
                    </div>


                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==4) return false;" class="form-control rounded-xs" id="txtnumberEmployeeJuristic" placeholder="จำนวนพนักงาน (ประมาณ)" value="20" />
                        <label for="txtnumberEmployeeJuristic" class="color-highlight form-label-always-active">จำนวนพนักงาน</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtcontactFirstNameJuristic" placeholder="ชื่อ ผู้ติดต่อหลัก (ประสานงาน)" autocomplete="off" value="อาทิตย์" />
                        <label for="txtcontactFirstNameJuristic" class="color-highlight form-label-always-active">ชื่อ ผู้ติดต่อหลัก</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtcontactLastNameJuristic" placeholder="นามสกุล ผู้ติดต่อหลัก (ประสานงาน)" autocomplete="off" value="ส่องแสง" />
                        <label for="txtcontactLastNameJuristic" class="color-highlight form-label-always-active">นามสกุล ผู้ติดต่อหลัก</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==13) return false;" class="form-control rounded-xs" id="txtcontactIDCardJuristic" placeholder="เลขบัตรประจำตัวประชาชน  ผู้ติดต่อหลัก (ประสานงาน)" maxlength="13" value="9181725979643">
                        <label for="txtcontactIDCardJuristic" class="form-label-always-active color-highlight">เลขบัตรประจำตัวประชาชน  ผู้ติดต่อหลัก (ประสานงาน)</label>
                        <span>(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtcontactPositionJuristic" placeholder="ตำแหน่ง ปัจจุบัน" autocomplete="off" value="กรรมการ" />
                        <label for="txtcontactPositionJuristic" class="color-highlight form-label-always-active">ตำแหน่ง</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==10) return false;" class="form-control rounded-xs" id="txtcontactMobileJuristic" placeholder="โปรดระบุเบอร์มือถือ ขึ้นต้นด้วย 0" value="0828889999" />
                        <label for="txtcontactMobileJuristic" class="color-highlight form-label-always-active">เบอร์โทร (ข้อมูลผู้ติดต่อหลัก)</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtcontactEmailJuristic" placeholder="โปรดระบุ อีเมลล์" autocomplete="off" value="contact@gmail.com" />
                        <label for="txtcontactEmailJuristic" class="color-highlight form-label-always-active">อีเมลล์ (ข้อมูลผู้ติดต่อหลัก)</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtdirectorFirstNameJuristic" placeholder="ชื่อ ผู้แทนที่มีอำนาจ" autocomplete="off" value="อำนาจ" />
                        <label for="txtdirectorFirstNameJuristic" class="color-highlight form-label-always-active">ชื่อ ผู้แทนที่มีอำนาจ</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtdirectorLastNameJuristic" placeholder="นามสกุล ผู้แทนที่มีอำนาจ" autocomplete="off" value="แทนที่" />
                        <label for="txtdirectorLastNameJuristic" class="color-highlight form-label-always-active">นามสกุล ผู้แทนที่มีอำนาจ</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==13) return false;" class="form-control rounded-xs" id="txtdirectorIDCardJuristic" placeholder="เลขบัตรประจำตัวประชาชน ผู้แทนที่มีอำนาจ" maxlength="13" value="1479287440985">
                        <label for="txtdirectorIDCardJuristic" class="form-label-always-active color-highlight">เลขบัตรประจำตัวประชาชน ผู้แทนที่มีอำนาจ</label>
                        <span>(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==10) return false;" class="form-control rounded-xs" id="txtdirectorMobileJuristic" placeholder="โปรดระบุเบอร์มือถือ ขึ้นต้นด้วย 0" value="0839998888" />
                        <label for="txtdirectorMobileJuristic" class="color-highlight form-label-always-active">เบอร์โทร (ผู้แทนที่มีอำนาจเต็มใช้สิทธิหอการค้าไทย)</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input type="text" class="form-control rounded-xs" id="txtdirectorEmailJuristic" placeholder="โปรดระบุ อีเมลล์" autocomplete="off" value="bigboss@gmail.com" />
                        <label for="txtdirectorEmailJuristic" class="color-highlight form-label-always-active">อีเมลล์(ผู้แทนที่มีอำนาจเต็มใช้สิทธิหอการค้าไทย)</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <div class="form-custom form-label form-border mb-3 bg-transparent">
                        <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==20) return false;" class="form-control rounded-xs" id="txtTotalAssetJuristic" placeholder="มูลค่าสินทรัพย์รวมของกิจการ (บาท)" value="2000000" />
                        <label for="txtTotalAssetJuristic" class="color-highlight form-label-always-active">มูลค่าสินทรัพย์รวมของกิจการ (บาท)</label>
                        <span class="font-10">(required)</span>
                    </div>

                    <a href="#" onclick="GenDataJuristicPage();" id="btnSubmitRegisterTCCJuristic"
                        class="btn btn-full gradient-blue shadow-bg shadow-bg-s mt-4">ถัดไป
                    </a>
                </div>
            </div>

            <!-- Page Input Register Address-->
            <div class="card card-style px-2 py-2" id="pnlRegisterMemberAddress" style="display: none;">
                <div class="content">
                    <h4 class="pb-3 pt-4">รายละเอียดที่อยู่ปัจุจบัน</h4>
                    <div class="row mt-4">
                        <div class="col-6 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtaddressNoTH" placeholder="โปรดระบุ">
                            <label for="txtaddressNoTH" class="color-highlight form-label-always-active font-11">บ้านเลขที่</label>
                        </div>
                        <div class="col-6 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtmooTH" placeholder="">
                            <label for="txtmooTH" class="color-highlight form-label-always-active font-11">หมู่</label>

                        </div>
                        <div class="col-12 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtbuildingTH" placeholder="">
                            <label for="txtbuildingTH" class="color-highlight form-label-always-active font-11">อาคาร/ตีก</label>
                        </div>
                        <div class="col-6 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtvillageTH" placeholder="">
                            <label for="txtvillageTH" class="color-highlight form-label-always-active font-11">หมู่บ้าน</label>
                        </div>
                        <div class="col-3 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtfloorTH" placeholder="">
                            <label for="txtfloorTH" class="color-highlight form-label-always-active font-11">ชั้น</label>
                        </div>
                        0
                    <div class="col-3 form-custom form-label mt-3">
                        <input type="text" class="form-control rounded-xs" id="txtroomTH" placeholder="">
                        <label for="txtroomTH" class="color-highlight form-label-always-active font-11">ห้อง</label>
                    </div>
                        <div class="col-6 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtsoiTH" placeholder="">
                            <label for="txtsoiTH" class="color-highlight form-label-always-active font-11">ซอย</label>
                        </div>
                        <div class="col-6 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtlaneTH" placeholder="">
                            <label for="txtlaneTH" class="color-highlight form-label-always-active font-11">ตรอก</label>
                        </div>
                        <div class="col-6 form-custom form-label mt-3">
                            <input type="text" class="form-control rounded-xs" id="txtroadTH" placeholder="โปรดระบุ">
                            <label for="txtroadTH" class="color-highlight form-label-always-active font-11">ถนน</label>
                        </div>

                        <div class="col-6 form-custom form-label mt-3">
                            <%--<input type="text" class="form-control rounded-xs" id="txtprovinceTH" placeholder="โปรดระบุ">--%>
                            <label for="txtprovinceTH" class="color-highlight form-label-always-active font-11">จังหวัด</label>
                            <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                ID="ddlProvinceTH" ClientIDMode="Static" AppendDataBoundItems="true">
                                <asp:ListItem Value="" Text="- กรุณาเลือก -" />
                            </asp:DropDownList>
                        </div>

                        <div class="col-6 form-custom form-label mt-3">
                            <%--<input type="text" class="form-control rounded-xs" id="txtamphurTH" placeholder="โปรดระบุ">--%>
                            <label for="ddlAmphurTH" class="color-highlight form-label-always-active font-11">เขต/อำเภอ</label>
                            <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                ID="ddlAmphurTH" ClientIDMode="Static" AppendDataBoundItems="true">
                                <asp:ListItem Value="" Text="- กรุณาเลือก -" />
                            </asp:DropDownList>

                        </div>
                        <div class="col-6 form-custom form-label mt-3">
                            <%--<input type="text" class="form-control rounded-xs" id="txttambolTH" placeholder="โปรดระบุ">--%>
                            <label for="ddlTambolTH" class="color-highlight form-label-always-active font-11">แขวง/ตำบล</label>
                            <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                ID="ddlTambolTH" ClientIDMode="Static" AppendDataBoundItems="true">
                                <asp:ListItem Value="" Text="- กรุณาเลือก -" />
                            </asp:DropDownList>

                        </div>


                        <div class="col-6 form-custom form-label mt-3 btn-disable-2">
                            <input type="text" class="form-control rounded-xs" id="txtcountryTH" placeholder="โปรดระบุ" value="ไทย">
                            <label for="txtcountryTH" class="color-highlight form-label-always-active font-11">ประเทศ</label>

                        </div>
                        <div class="col-6 form-custom form-label mt-3 ">
                            <%--<input type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==5) return false;" class="form-control rounded-xs" id="txtzipcode" placeholder="โปรดระบุ">--%>
                            <label for="txtzipcode" class="color-highlight form-label-always-active font-11">รหัสไปรษณีย์</label>
                            <asp:DropDownList CssClass="form-select rounded-xs" runat="server"
                                ID="ddlZipcode" ClientIDMode="Static" AppendDataBoundItems="true">
                                <asp:ListItem Value="" Text="- กรุณาเลือก -" />
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div class="row mt-4">
                    <div class="col-6">
                        <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-green shadow-bg shadow-bg-xs" onclick="BackStepAddress();">ย้อนกลับ</a>
                    </div>
                    <div class="col-6">
                        <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-blue shadow-bg shadow-bg-xs" onclick="GenDataPageAddress();">ถัดไป</a>
                    </div>
                </div>
            </div>

            <!-- Page Input File Upload -->
            <div class="card card-style px-2 py-2" id="pnlRegisterMemberFileUpload" style="display: none;">
                <div class="content">
                    <h4 class="pb-3 pt-4">แนบไฟล์เพิ่มเติม</h4>

                    <div class="mt-3" id="tabDCfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">สำเนาบัตรประชาชนผู้แทนที่มีอำนาจเต็มใช้สิทธิ์หอการค้าไทย (เซ็นต์รับรองสำเนา ไฟล์ PDF)</label>
                        <input class="form-control" type="file" id="documentDCFile">
                    </div>
                    <div class="mt-3" id="tabDBfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">ทะเบียนพาณิชย์ หรือเลขประจำตัวผู้เสียภาษี ( ภงด. 94 มาตรา 40(5) - 40(8) )  ( เซ็นต์รับรองสำเนา ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentDBFile">
                    </div>
                    <div class="mt-3" id="tabCHfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">สำเนาทะเบียนบ้าน  ( เซ็นต์รับรองสำเนา ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentCHFile">
                    </div>
                    <div class="mt-3" id="tabPLfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">ใบประกอบวิชาชีพ *หากมี ( เซ็นต์รับรองสำเนา ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentPLFile">
                    </div>
                    <div class="mt-3" id="tabIDCardfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">สำเนาบัตรประชาชนผู้แทนที่มีอำนาจเต็มใช้สิทธิ์หอการค้าไทย ( เซ็นต์รับรองสำเนา ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentIDCardFile">
                    </div>
                    <div class="mt-3" id="tabOJfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">หนังสือรับรอง พร้อมวัตถุประสงค์ของบริษัท อายุไม่เกิน 6 เดือน ( เซ็นต์และประทับตราบริษัท ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentOJFile">
                    </div>
                    <div class="mt-3" id="tabPPfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">สำเนาทะเบียนภาษีมูลค่าเพิ่ม (ภ.พ.20) หรือสำเนาใบเสร็จ ภงด.50/ภงด.51 (สำหรับบริษัทที่ไม่ได้จดทะเบียนภาษีมูลค่าเพิ่ม เซ็ตน์และประทับตราบริษัท ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentPPFile">
                    </div>
                    <div class="mt-3" id="tabISfile" style="display: none">
                        <label for="formFile" class="color-highlight form-label-always-active font-11 ">สำเนา งบกำไรขาดทุน ( แสดงหน้ารายได้รวมก่อนหักค่าใช้จ่าย ที่ยื่นกับกระทรวงพาณิชย์ปีปัจจุบัน หน้าเดียว ไฟล์ PDF )</label>
                        <input class="form-control" type="file" id="documentISFile">
                    </div>

                </div>

                <div class="row mt-4">
                    <div class="col-6">
                        <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-green shadow-bg shadow-bg-xs" onclick="BackStepFileUploadPerson();">ย้อนกลับ</a>
                    </div>
                    <div class="col-6">
                        <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-blue shadow-bg shadow-bg-xs" onclick="uploadFileData();">อัพโหลดไฟล์</a>
                    </div>
                </div>
            </div>

            <!-- Page TCC Member Status Page <Result API> -->
            <div class="card card-style" id="pnlTCCMemberStatusPage" style="display: none;">


                <%--Start for Card Solution --%>
                <div class="content" style="display:none;">

                    <div class="page-title " style="padding: inherit !important">
                        <div class="align-self-center me-auto">
                            <p class="color-blue opacity-80" style="font-size: 17px !important;">โครงการสนั่นสิทธิ์</p>
                            <h3 class="color-blue" id="txtMemberName"></h3>
                        </div>

                        <div id="txtImageCardId" onload="updateAspectRatio('https://starrtccprod02.blob.core.windows.net/image/Attachments/2024-08-06/tcc-connect-card-lightblue-2024_20240806102147682056_1.png')" style="justify-items: center;">
                            <div onload="updateFontSize()">
                                <div id="parentImages" class="parent">
                                    <div class="div1"></div>
                                    <div id="txtImageCardName" class="div2"></div>
                                    <div id="txtImageTName" class="div3"></div>
                                    <div id="txtImageTittleRisno" class="div4"></div>
                                    <div id="txtImageRisno" class="div5"></div>
                                    <div id="txtImageExpDateTittle" class="div6"></div>
                                    <div id="txtImageExpDate" class="div7">
                                        <%--<div id="txtImageExpDate" class="textdiv7"></div>--%>
                                    </div>
                                    <div id="txtImageCardLicen" class="div8"></div>
                                    <div class="div9">
                                        <img src="<%= ResolveClientUrl("~/images/personal/p1.png") %>" alt="Responsive Image" id="txtImagePerson" style="display: none">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <%--End for Card Solution --%>

                <div class="content">

                    <h4>โครงการสนั่นสิทธิ์</h4>

                    <div class="tcc-image-container">

                        <img src="<%= ResolveClientUrl("~/images/Banner/Card_TCC_blue_1.png") %>" alt="รูปภาพตัวอย่าง" class="tcc-responsive-image" id="tcccardimage">
                        <!-- Text Overlay 1 -->
                        <div class="tcc-text-overlay" id="tccOverlay1"></div>
                        <!-- Text Overlay 2 -->
                        <div class="tcc-text-overlay" id="tccOverlay2"></div>
                        <!-- Text Overlay 3 -->
                        <div class="tcc-text-overlay" id="tccOverlay3"></div>
                        <!-- Text Overlay 4 -->
                        <div class="tcc-text-overlay" id="tccOverlay4"></div>
                        <!-- Text Overlay 5 -->
                        <div class="tcc-text-overlay" id="tccOverlay5"></div>
                        <!-- Text Overlay 6 -->
                        <div class="tcc-text-overlay" id="tccOverlay6"></div>
                        <!-- Text Overlay 7 -->
                        <div class="tcc-text-overlay" id="tccOverlay7"></div>
                        <!-- Imp Overlay 8-->
                        <img src="<%= ResolveClientUrl("~/images/pictures/31t.jpg") %>" alt="รูปภาพตัวอย่าง" class="tcc-profile-image" id="tccprofileImage">

                    </div>


                    <div class="content pb-0">

                        <h4>รายละเอียดข้อมูล</h4>

                        <div>

                            <a style=""><i class="bi bi-list color-green-drak"></i>&nbsp;สมัครรูปแบบ</a><br />
                            <a style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong id="txtTypeFrom" style="color: dodgerblue"></strong></a><br />

                            <div>
                                <a style=""><i class="bi bi-list color-green-drak"></i>&nbsp;สถานะของสมาชิก</a><br />
                                <a style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong id="txtMemberStatusLast" style="color: dodgerblue"></strong></a><br />
                            </div>
                        </div>

                        <div id="APIMemberstatus" style="display: none">
                        </div>

                        <div class="row mt-4">
                            <div class="col-6">
                                <a href="btnBackPageMemberStatusPage" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-blue shadow-bg shadow-bg-xs" onclick="BackToMain();">กลับสู่หน้าหลัก</a>
                            </div>
                            <div id="btnConnectTCC" style="display: none" class="col-6">
                                <a href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-green shadow-bg shadow-bg-xs" onclick="ConnectTCC();">ใช้งานสิทธิ์พิเศษ</a>
                            </div>
                            <div id="btnRepeatAPITCC" style="display: none" class="col-6">
                                <a id="btnRepeatAPITCCA" href="#" data-bs-dismiss="offcanvas" class="btn btn-s btn-full gradient-green shadow-bg shadow-bg-xs" onclick="RepeatAPITCC();">ส่งใบสมัคร</a>
                            </div>

                        </div>
                    </div>

                </div>

            </div>


        </div>

    </div>

    <!-- 1. Component Modal Confirm-->
    <div class="modal fade" id="checkRegisterModalTCC" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
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
                    <a href="#" data-bs-target="#checkRegisterModalTCC" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>
                    <a id="btnSubmitIdCard" href="#" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>
        </div>
    </div>
    <!-- 2. Component Modal Confirm Information-->
    <div class="modal fade" id="confirmInformation" aria-hidden="true" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">ยืนยันข้อมูลการสมัคร</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้ายินยอมให้ บสย. เก็บข้อมูลส่วนบุคคลเพื่อใช้ในตรวจสอบ
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#confirmInformation" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>
                    <a href="btnAcceptModal" onclick="SubmitTransaction()" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <%--<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.17.2/dist/sweetalert2.all.min.js"></script>--%>
    <%-- Image Grid --%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script>

        function updateAspectRatio(imageUrl) {
            let img = new Image();
            img.src = imageUrl;
            img.onload = function () {
                document.documentElement.style.setProperty('--aspect-ratio', img.width / img.height);
            };

        }

        //let bannerResult = ResolveClientUrl("~/images/Banner/Card_TCC_lightblue_.png")
        let bannerResult = "/images/Banner/Card_TCC_blue_1.png"; // พาธไฟล์ที่สัมพันธ์กับ root project

        updateAspectRatio(bannerResult); // เปลี่ยนเป็น URL ของภาพจริง

    </script>
    <script>
        //function updateFontSize() {
        //    let screenWidth = window.innerWidth;
        //    let newFontSize = Math.max(12, screenWidth * 0.02); // คำนวณขนาดตามหน้าจอ
        //    document.documentElement.style.setProperty('--font-size', `${newFontSize}px`);
        //}

        //window.addEventListener('resize', updateFontSize);
        //updateFontSize(); // เรียกใช้ตอนโหลดหน้าเว็บ

        function updateFontSize() {
            let screenWidth = window.innerWidth;

            let largerFontSize = Math.max(14, screenWidth * 0.03); // 
            let largeFontSize = Math.max(10, screenWidth * 0.03); // ขนาดใหญ่กว่าปกติ
            let mediumFontSize = Math.max(8, screenWidth * 0.02);   // ขนาดปกติ
            let smallFontSize = Math.max(6, screenWidth * 0.015); // ขนาดเล็กกว่าปกติ

            document.documentElement.style.setProperty('--font-size-ll', `${largerFontSize}px`);
            document.documentElement.style.setProperty('--font-size-l', `${largeFontSize}px`);
            document.documentElement.style.setProperty('--font-size-m', `${mediumFontSize}px`);
            document.documentElement.style.setProperty('--font-size-s', `${smallFontSize}px`);
        }

        window.addEventListener('resize', updateFontSize);
        updateFontSize();
    </script>

    <script src="<%= ResolveClientUrl("~/scripts/Page/TCCProject.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/Lib/sweetalert2.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <%--Datapicker ALL --%>
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

    <style>
        .ui-datepicker-year {
            border-radius: 10px;
            text-align: center;
        }

        /*new CSS*/
        .parent {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            grid-template-rows: repeat(2, 1fr) repeat(5,0.5fr);
            width: 80vw;
            aspect-ratio: var(--aspect-ratio, 4 / 3);
            background-image: var(--main-bg-image);
            /* เปลี่ยนเป็น URL ของภาพจริง */
            background-size: contain;
            background-position: center;
            background-repeat: no-repeat;
            color: #143f90;
            font-family: 'KANIT' !important;
        }

        .div1 {
            grid-area: 1 / 7 / -1 / -1;
        }

        .div2 {
            grid-area: 3 / 1 / 7 / 2;
            padding-left: 1rem;
            display: flex;
            align-items: center;
            justify-content: start;
            font-weight: bold;
            font-size: var(--font-size-l);
        }

        .div3 {
            grid-area: 4 / 1 / 7 / 2;
            padding-left: 1rem;
            display: flex;
            align-items: center;
            justify-content: start;
            font-size: var(--font-size-m);
        }

        .div4 {
            grid-area: 5 / 1 / 7 / 2;
            padding-left: 1rem;
            display: flex;
            align-items: center;
            justify-content: start;
            font-size: var(--font-size-s);
        }

        .div5 {
            grid-area: 6 / 1 / 7 / 2;
            padding-left: 1rem;
            display: flex;
            align-items: center;
            justify-content: start;
            font-weight: bold;
            font-size: var(--font-size-l);
        }

        .div6 {
            grid-area: 7 / 1 / 7 / 2;
            padding-left: 1rem;
            display: flex;
            align-items: center;
            justify-content: start;
            font-size: var(--font-size-s);
        }

        .div7 {
            grid-area: 7 / 1 / 7 / 2;
            padding-left: 1rem;
            display: flex;
            align-items: center;
            justify-content: start;
            font-size: var(--font-size-m);
        }

        .div8 {
            grid-area: 2 / 2 / 1 / 3;
            display: flex;
            justify-content: center;
            align-items: center;
            min-width: max-content;
            flex-wrap: nowrap;
            letter-spacing: 0.5px;
            padding-right: 1rem;
            font-weight: bold;
            font-size: var(--font-size-ll);
        }

        .div9 {
            grid-area: 4 / 2 / 7 / 3;
            display: flex;
            justify-content: center;
            align-items: center;
            overflow: hidden;
        }

            .div9 img {
                max-width: 100%;
                max-height: 100%;
                object-fit: contain;
            }

    </style>

</asp:Content>
