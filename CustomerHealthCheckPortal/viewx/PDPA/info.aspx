<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PDPA.Master" AutoEventWireup="true"
CodeBehind="info.aspx.cs" Inherits="CustomerHealthCheck.viewx.PDPA.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:HiddenField ID="hddStep1Consent" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hddStep2Consent" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hddStep3Consent" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hddIsCheckPDPACookie" runat="server" ClientIDMode="Static"/>
    <div id="preloader">
        <div class="spinner-border color-highlight" role="status"></div>
    </div>

    <!-- Page Wrapper-->
    <div id="page" style="background-color: whitesmoke !important;">


        <!-- Page Content - Only Page Elements Here-->
        <div class="">

            <!-- Page Title-->
            <div class="pt-3">
                <div class="page-title d-flex">

                </div>
            </div>

            <div class="card card-style">
                <div class="content">
                    <h3 style="text-align: center; margin-bottom: 10px;">ความยินยอมและข้อตกลงให้บริการ</h3>
                    <p class="mb-0">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้าแสดงเจตนาให้ บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อย (บสย.) ในการเก็บรวมรวบ ใช้ และเปิดเผยข้อมูลส่วนบุคคล เพื่อวัตถุประสงค์ ดังนี้

                    </p>
                    <p class="mb-0">
                        <b>1. ความยินยอมเพื่อวิจัยและพัฒนาผลิตภัณฑ์หรือบริการของ บสย.</b> ท่านยินยอมให้ บสย. เก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคล หรือข้อมูลทางการเงินอื่นๆ ของท่านที่ได้ให้ไว้แก่ บสย. หรือที่ บสย. อาจเข้าถึงได้จากแหล่งอื่น เพื่อใช้สำหรับการวิเคราะห์ วิจัยและ/หรือพัฒนาผลิตภัณฑ์ของ บสย. ให้เหมาะสมกับความต้องการของท่าน รวมถึงการสำรวจความพึงพอใจด้านผลิตภัณฑ์และบริการของ บสย. ด้วย
                    </p>

                    <div class="content">
                        <div class="row">
                            <div class="col-6">
                                <a href="#" data-bs-toggle="offcanvas"
                                   id="btnStep1Yes" onclick="Step1Consent(1)"
                                   data-bs-target="#menu-exchange"
                                   class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s">
                                    ยินยอม
                                </a>
                            </div>
                            <div class="col-6">
                                <a href="#" data-bs-toggle="offcanvas"
                                   id="btnStep1No" onclick="Step1Consent(0)"
                                   data-bs-target="#menu-exchange"
                                   class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s">
                                    ไม่ยินยอม
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="divider mt-4"></div>


                    <p class="mb-0">
                        <b>2. ความยินยอมเพื่อนำเสนอผลิตภัณฑ์หรือบริการของ บสย.</b>
                        ท่านยินยอมให้ บสย. เก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคล หรือข้อมูลทางการเงินอื่นๆ ของท่านที่ได้ให้ไว้แก่ บสย. หรือที่ บสย. อาจเข้าถึงได้จากแหล่งอื่น เพื่อขยายสิทธิประโยชน์ให้ท่านมากขึ้นผ่านการนำเสนอผลิตภัณฑ์ บริการ การแจ้งข่าวสารต่างๆ เชิญชวนเข้าร่วมกิจกรรม ข้อมูลการตลาดที่ตรงตามความความต้องการของท่าน โดยติดต่อผ่านช่องทางที่ท่านได้แจ้งข้อมูลไว้
                    </p>
                    <div class="content">
                        <div class="row">
                            <div class="col-6">
                                <a href="#" data-bs-toggle="offcanvas"
                                   id="btnStep2Yes" onclick="Step2Consent(1)"
                                   data-bs-target="#menu-exchange"
                                   class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s">
                                    ยินยอม
                                </a>
                            </div>
                            <div class="col-6">
                                <a href="#" data-bs-toggle="offcanvas"
                                   id="btnStep2No" onclick="Step2Consent(0)"
                                   data-bs-target="#menu-exchange"
                                   class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s">
                                    ไม่ยินยอม
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="divider mt-4"></div>


                    <p class="mb-0">
                        <b>3. ความยินยอมเพื่อการประชาสัมพันธ์กิจกรรมต่างๆ ของ บสย. </b>
                        ท่านยินยอมให้ บสย. เก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคล รวมทั้งข้อมูลอ่อนไหว ที่ท่านได้ให้ไว้แก่ บสย. หรือที่ บสย. อาจเข้าถึงได้จากการเข้าร่วมกิจกรรมต่างๆ ของ บสย. ซึ่งอาจมีการบันทึกเสียง ภาพนิ่ง ภาพเคลื่อนไหว การสัมภาษณ์ และ/หรือวีดิทัศน์ เพื่อการประชาสัมพันธ์กิจกรรมต่างๆ ของ บสย. ผ่านสื่อออนไลน์ สื่อวีดีทัศน์ สื่อโทรทัศน์ สื่อสิ่งพิมพ์ และสื่ออิเล็กทรอนิกส์
                    </p>
                    <div class="content">
                        <div class="row">
                            <div class="col-6">
                                <a href="#" data-bs-toggle="offcanvas"
                                   id="btnStep3Yes" onclick="Step3Consent(1)"
                                   data-bs-target="#menu-exchange"
                                   class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s">
                                    ยินยอม
                                </a>
                            </div>
                            <div class="col-6">
                                <a href="#" data-bs-toggle="offcanvas"
                                   id="btnStep3No" onclick="Step3Consent(0)"
                                   data-bs-target="#menu-exchange"
                                   class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s">
                                    ไม่ยินยอม
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="divider mt-4"></div>


                    <p class="mb-0">
                        <u>
                            <b>หมายเหตุ</b>
                        </u>
                        <br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ข้าพเจ้าได้อ่านและเข้าใจรายละเอียดการขอความยินยอมข้างต้น และสามารถดูรายละเอียดในนโยบายคุ้มครองข้อมูลส่วนบุคคลเพิ่มเติมในเว็บไซต์ <a href="https://www.tcg.or.th/privacy_policy.php">https://www.tcg.or.th/privacy_policy.php </a>

                    </p>

                    <div class="content">
                        <div class="row">
                            <div class="col-12">
                                <asp:Button
                                    Text="ยืนยัน"
                                    id="btnSubmitConsent"
                                    runat="server"
                                    ClientIDMode="Static"
                                    OnClientClick="return CheckConsentIsActive()"
                                    class="btn btn-full gradient-gray rounded-s shadow-bg shadow-bg-s w-100 disabledButton"
                                    OnClick="btnSubmitConsent_Click"
                                    data-bs-toggle="offcanvas"
                                    data-bs-target="#menu-exchange"/>


                            </div>

                        </div>
                    </div>
                </div>
            </div>


        </div>


    </div>
    <!-- End of Page ID-->


    <script src="<%= ResolveClientUrl("~/scripts/Page/PDPA_Info.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>