<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CustomerHealthCheck.views.PDPA.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hddConsent1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddConsent2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddConsent3" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddConsentUpdate1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddConsentUpdate2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddConsentUpdate3" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hddPDPAConsentPoint" runat="server" ClientIDMode="Static" />

    <div class="page-content footer-clear">

        <div class="pt-3">
            <div class="page-title d-flex">
                <div class="align-self-center">
                    <a href="#" onclick="redirectToProfile()" class="me-3 ms-0 icon icon-xxs bg-theme rounded-s shadow-m">
                        <i class="bi bi-chevron-left color-theme font-14"></i>
                    </a>
                </div>
                <div class="align-self-center me-auto">
                    <h1 class="color-theme mb-0 font-18">ย้อนกลับ</h1>
                </div>

            </div>
        </div>
        <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
            <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
            <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
            <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
            <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
        </svg>

        <%--<div class="card card-style">--%>
        <div class="card card-style">
            <div class="content">
                <h4>ตั้งค่าความเป็นส่วนตัว</h4>
                <p class="mb-0">
                    ทาง บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม (บสย.) ให้ความสำคัญกับความเป็นส่วนตัวของคุณอยู่เสมอ
                </p>
                <div class="collapse" id="collapse-list-more">
                    <p class="mb-0">
                        โปรดอ่านเพิ่มเติมเกี่ยวกับนโยบายความเป็นส่วนตัวของเราอย่างละเอียด เพื่อเข้าใจถึงวิธีการที่เราเก็บรวมรวม ใช้ และเปิดเผยข้อมูลส่วนบุคคลของคุณ
                        <a href="https://www.tcg.or.th/privacy_policy.php">นโยบายควบคุมข้อมูลส่วนบุคคล</a>
                    </p>
                </div>
                <a data-bs-toggle="collapse" href="#collapse-list-more" aria-controls="collapse-list-more" class="d-block pt-3 collapsed" aria-expanded="false">
                    <i class="bi bi-chevron-down" style="color: #092d74 !important;"></i>
                </a>
            </div>
            <%--<TESTBOX>--%>
            <div class="card card-style">
                <div class="content">
                    <h5>ความยินยอมและข้อตกลงให้บริการ</h5>
                    <p>
                        ข้าพเจ้าได้รับทราบข้อตกลงในการให้บริการเรียบร้อยทั้งแต่เริ่มการใช้ LINE:Official TCG FIRST ตั้งแต่ครั้งแรกที่ใช้งาน
                        <br />
                        และท่านยินยอมให้ บสย. เก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคล หรือข้อมูลทางการเงินอื่นๆ รวมทั้งข้อมูลอ่อนไหว ของท่านที่ได้ให้ไว้แก่ บสย. หรือที่ บสย. อาจเข้าถึงได้จากแหล่งอื่น รวมถึง บสย. อาจเข้าถึงได้จากการเข้าร่วมกิจกรรมต่างๆ ของ บสย. ตามหัวข้อดังต่อไปนี้
                    </p>
                </div>
                <div class="list-group list-custom list-group-m mx-3 mb-4">
                    <a class="list-group-item collapsed" href="#collapse-list-1">
                        <div>
                            <strong>1. ความยินยอมเพื่อวิจัยและพัฒนาผลิตภัณฑ์หรือบริการของ บสย.</strong>
                        </div>
                        <div class="form-switch ios-switch switch-green switch-m">
                            <input type="checkbox" class="ios-input" id="switch-1" onclick="Step1Consent()">
                            <label class="custom-control-label" for="switch-1"></label>
                        </div>
                    </a>
                    <div id="collapse-list-1" class="collapse" style="">
                        <a href="#" class="list-group-item">
                            <div class="mb-0">
                                เพื่อใช้สำหรับการวิเคราะห์ วิจัยและ/หรือพัฒนาผลิตภัณฑ์ของ บสย. ให้เหมาะสมกับความต้องการของท่าน รวมถึงการสำรวจความพึงพอใจด้านผลิตภัณฑ์และบริการของ บสย. ด้วย
                            </div>
                        </a>
                    </div>
                    <a class="list-group-item collapsed" href="#collapse-list-2">
                        <div>
                            <strong>2. ความยินยอมเพื่อนำเสนอผลิตภัณฑ์หรือบริการของ บสย. </strong>
                        </div>
                        <div class="form-switch ios-switch switch-green switch-m">
                            <input type="checkbox" class="ios-input" id="switch-2" onclick="Step2Consent()">
                            <label class="custom-control-label" for="switch-2"></label>
                        </div>
                    </a>
                    <div id="collapse-list-2" class="collapse" style="">
                        <a href="#" class="list-group-item">
                            <div class="mb-0">
                                เพื่อขยายสิทธิประโยชน์ให้ท่านมากขึ้นผ่านการนำเสนอผลิตภัณฑ์ บริการ การแจ้งข่าวสารต่างๆ เชิญชวนเข้าร่วมกิจกรรม ข้อมูลการตลาดที่ตรงตามความความต้องการของท่าน โดยติดต่อผ่านช่องทางที่ท่านได้แจ้งข้อมูลไว้
                            </div>
                        </a>
                    </div>
                    <a class="list-group-item collapsed" href="#collapse-list-3">
                        <div>
                            <strong>3. ความยินยอมเพื่อการประชาสัมพันธ์กิจกรรมต่างๆ ของ บสย. </strong>
                        </div>
                        <div class="form-switch ios-switch switch-green switch-m">
                            <input type="checkbox" class="ios-input" id="switch-3" onclick="Step3Consent()">
                            <label class="custom-control-label" for="switch-3"></label>
                        </div>
                    </a>
                    <div id="collapse-list-3" class="collapse" style="">
                        <a href="#" class="list-group-item">
                            <div class="mb-0">
                                เพื่อเข้าถึงได้จากการเข้าร่วมกิจกรรมต่างๆ ของ บสย. ซึ่งอาจมีการบันทึกเสียง ภาพนิ่ง ภาพเคลื่อนไหว การสัมภาษณ์ และ/หรือวีดิทัศน์ เพื่อการประชาสัมพันธ์กิจกรรมต่างๆ ของ บสย. ผ่านสื่อออนไลน์ สื่อวีดีทัศน์ สื่อโทรทัศน์ สื่อสิ่งพิมพ์ และสื่ออิเล็กทรอนิกส์
                            </div>
                        </a>
                    </div>
                </div>
                <div class="content">
                    <div class="row">
                        <div class="col-12">
                            <input type="button"
                                value="บันทึก"
                                onclick="consentNotChange()"
                                id="btnSubmitConsent"
                                class="btn btn-full rounded-s gradient-gray shadow-bg shadow-bg-s w-100 disabledButton"
                                data-bs-toggle="offcanvas"
                                data-bs-target="#menu-exchange">
                        </div>
                    </div>
                </div>

            </div>
        </div>


    </div>
    <%--<END TESTBOX>--%>

    <%--</div>--%>

    <div class="modal fade" id="confirmUpdate" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalToggleLabel">ตั้งค่าความเป็นส่วนตัว</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="text-indent: 50px">ยืนยันการแก้ไขข้อมูล การตั้งค่าความเป็นส่วนตัว</div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#checkConsentModalUpdate" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก</a>

                    <asp:Button Text="ยืนยัน" ID="UpdateConsent_Click" OnClientClick="updatePDPAFunction(this); return false"  runat="server" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs" />
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="notUpdate" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalToggleLabel2">แจ้งเตือน</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="text-indent: 50px">ท่านไม่ได้เปลี่ยนแปลงข้อมูลในการบันทึก</div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#checkConsentModalNotChange" data-bs-toggle="modal" data-bs-dismiss="modal" class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ตกลง</a>

                </div>
            </div>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/PDPA/edit.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script>
        function testScriptC() {
            alert('JavaScript testScriptC called! HTML');
        }
    </script>
</asp:Content>
