<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true"
CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.viewx.Profile.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hddPCustomerProfileCode" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddJCustomerProfileCode" runat="server" ClientIDMode="Static"/>
<div id="preloader">
    <div class="spinner-border color-highlight" role="status"></div>
</div>

<!-- Page Wrapper-->
<div id="page">

    <!-- Footer Bar -->
    <div id="footer-bar" class="footer-bar-1 footer-bar-detached">
        <!--<a href="page-wallet.html"><i class="bi bi-wallet2"></i><span>Cards</span></a>-->
        <asp:HyperLink NavigateUrl="~/viewx/Activity/index.aspx" runat="server">
            <i class="bi bi-journal-text"></i><span>ประวัติทำรายการ</span>
        </asp:HyperLink>
        <asp:HyperLink NavigateUrl="~/index_inno.aspx" runat="server">
            <i class="bi bi-house-fill"></i><span>หน้าหลัก</span>
        </asp:HyperLink>
        <asp:HyperLink NavigateUrl="~/viewx/Profile/index.aspx" runat="server" class="circle-nav-2">
            <i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span>
        </asp:HyperLink>

        <%-- <a href="activity.aspx"><i class="bi bi-patch-question"></i><span>ประวัติการตรวจ</span></a>
            <a href="index.aspx" ><i class="bi bi-house-fill"></i><span>หน้าหลัก</span></a>
            <a href="profile.aspx" class="circle-nav-2"><i class="bi bi-person-circle"></i><span>ข้อมูลบุคคล</span></a>--%>
        <!--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-sidebar"><i class="bi bi-three-dots"></i><span>More</span></a>-->
    </div>

    <!-- Page Content - Only Page Elements Here-->
    <div class="page-content footer-clear">

        <!-- Page Title-->
        <div class="pt-3">
            <div class="page-title d-flex">
                <div class="align-self-center me-auto">
                    <h2 class="color-white" style="color: #092d74 !important;">ข้อมูลผู้ใช้</h2>
                </div>

            </div>
        </div>


        <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg">
            <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
            <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
            <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
            <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
        </svg>


        <div class="card card-style overflow-visible ">
            <div class="mt-n5"></div>
            <img id="ContentPlaceHolder1_imgLineImage" class="mx-auto rounded-circle mt-n5 shadow-l" src="../../images/personal/p1.png" style="width:180px;">


            <div class="content mt-3">
                <div class="tabs tabs-box" id="tab-group-1">
                    <div class="tab-controls rounded-s border-highlight">
                        <a href="#tab1" id="tabHeaderPersonal" class="font-13 color-highlight " data-bs-toggle="collapse" aria-expanded="true">บุคคลธรรมดา</a>
                        <a href="#tab2" id="tabHeaderJuristic" class="font-13 color-highlight " data-bs-toggle="collapse" aria-expanded="false">นิติบุคคล</a>
                    </div>

                    <div id="tab1" class="collapse show" data-bs-parent="#tab-group-1">
                        <div class="content mt-0 mb-2" style="margin: 5px;">
                            <div class="content mt-0" style="margin-left: 5px; margin-right: 5px;">
                                <h5 class="pb-3 pt-4">ข้อมูลบุคคลธรรมดา</h5>


                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtPTitle" type="text" id="txtPTitle" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="นาย">
                                    <label for="c1ab" class="form-label-always-active color-highlight">
                                        คำนำหน้าชื่อ
                                    </label>
                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtPName" type="text" id="txtPName" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="สมมุติ">
                                    <label for="c1abc" class="form-label-always-active color-highlight">ชื่อ</label>

                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtPLastName" type="text" id="txtPLastName" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="พร้อมบริการ">
                                    <label for="c1abcd" class="form-label-always-active color-highlight">นามสกุล</label>

                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtPIDCard" type="email" id="txtPIDCard" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="1100800XXXXXX">
                                    <label for="c1" class="color-highlight form-label-always-active">
                                        เลขบัตรประชาชน
                                    </label>
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtPPhone" type="email" id="txtPPhone" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="082999XXXX">
                                    <label for="c1" class="color-highlight form-label-always-active">
                                        เบอร์โทรศัพท์เคลื่อนที่
                                    </label>
                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtEmail" type="email" id="txtEmail" class="form-control rounded-xs" placeholder="-" disabled="disabled" value="ตัวอย่างอีเมล์@gmail.com">
                                    <label for="c1" class="color-highlight form-label-always-active">
                                        อีเมล์
                                    </label>
                                </div>


                                <a href="#" onclick="ShowModal('1')" class="btn btn-full mx-3 gradient-blue shadow-bg shadow-bg-s mb-4">แก้ไขข้อมูล</a>
                            </div>
                        </div>
                    </div>


                    <div id="tab2" class="collapse" data-bs-parent="#tab-group-1">
                        <div class="content mt-0 mb-2" style="margin: 5px;">
                            <div class="content mt-0" style="margin-left: 5px; margin-right: 5px;">
                                <h5 class="pb-3 pt-4">ข้อมูลนิติบุคคล</h5>


                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtJTitle" type="text" id="txtJTitle" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="บจก.">
                                    <label for="c1ab" class="form-label-always-active color-highlight">
                                        คำนำหน้ากิจการ
                                    </label>

                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtJName" type="text" id="txtJName" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="กิจการตัวอย่าง">
                                    <label for="c1abc" class="form-label-always-active color-highlight">
                                        ชื่อกิจการ
                                    </label>

                                </div>


                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtJVatID" type="email" id="txtJVatID" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="123456789XXXX">
                                    <label for="c1" class="color-highlight form-label-always-active">
                                        เลขทะเบียนนิติบุคคล
                                    </label>

                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtJPhone" type="email" id="txtJPhone" class="form-control rounded-xs" placeholder="ไม่ระบุ" disabled="disabled" value="082999XXXX">
                                    <label for="c1" class="color-highlight form-label-always-active">
                                        เบอร์โทรศัพท์เคลื่อนที่

                                    </label>
                                </div>
                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input name="ctl00$ContentPlaceHolder1$txtJEmail" type="email" id="txtJEmail" class="form-control rounded-xs" placeholder="-" disabled="disabled" value="ตัวอย่างอีเมล์@gmail.com">
                                    <label for="c1" class="color-highlight form-label-always-active">
                                        อีเมล์
                                    </label>
                                </div>


                                <a href="#" onclick="ShowModal('2')" class="btn btn-full mx-3 gradient-blue shadow-bg shadow-bg-s mb-4">แก้ไขข้อมูล</a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <!-- End of Page Content-->
    <!-- Off Canvas and Menu Elements-->
    <!-- Always outside the Page Content-->


</div>
<!-- End of Page ID-->


<div class="modal fade cssSuccessFinish" id="updatePersonalModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="updatePersonalHeader">ฟอร์มแก้ไขข้อมูลบุคคล</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">


                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <asp:DropDownList runat="server" ID="ddlTitlePersonal" CssClass="form-control rounded-xs " ClientIDMode="Static">
                        <asp:ListItem Text="นาย" Value="001"/>
                        <asp:ListItem Text="นาง" Value="002"/>
                        <asp:ListItem Text="นางสาว" Value="003"/>
                    </asp:DropDownList>
                    <label for="c1ab" class="form-label-always-active color-highlight">
                        คำนำหน้าชื่อ
                    </label>
                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="text" class="form-control rounded-xs" id="txtUpdatePName" placeholder="ไม่ระบุ" runat="server" clientidmode="Static" value="สมมุติ"/>
                    <label for="c1abc" class="form-label-always-active color-highlight">ชื่อ</label>

                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="text" class="form-control rounded-xs" id="txtUpdatePLastName" placeholder="ไม่ระบุ" runat="server" clientidmode="Static" value="พร้อมบริการ"/>
                    <label for="c1abcd" class="form-label-always-active color-highlight">นามสกุล</label>

                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="tel" maxlength="13" class="form-control rounded-xs" id="txtUpdatePIDCard" placeholder="ไม่ระบุ" runat="server" clientidmode="Static" value="1100800XXXX"/>
                    <label for="c1" class="color-highlight form-label-always-active">
                        เลขบัตรประชาชน
                    </label>
                </div>

                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="tel" maxlength="10" class="form-control rounded-xs" id="txtUpdatePMobilePhone" placeholder="ไม่ระบุ" runat="server" clientidmode="Static" value="082999XXXX"/>
                    <label for="c1" class="color-highlight form-label-always-active">
                        เบอร์โทรศัพท์เคลื่อนที่
                    </label>
                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent" style="margin: 0px !important;">
                    <input type="email" class="form-control rounded-xs" id="txtUpdatePEmail" placeholder="-" runat="server" value="ตัวอย่างอื่น@gmail.com"
                           clientidmode="Static" style="border: none;"/>
                    <label for="c1" class="color-highlight form-label-always-active">
                        อีเมล์
                    </label>
                </div>


            </div>
            <div class="modal-footer" style="justify-content: center;">
                <button type="button" class="btn mx-3 gradient-blue shadow-bg shadow-bg-xs" data-bs-dismiss="modal">ปิด</button>
                <button type="button" onclick="UpdateProfile('1')" id="btnUpdatePersonalModal"
                        class="btn  mx-3 gradient-green shadow-bg shadow-bg-xs">
                    ยืนยัน
                </button>
            </div>
        </div>
    </div>
</div>

<div class="modal fade cssSuccessFinish" id="updateCompanyModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="updateCompanyHeader">ฟอร์มแก้ไขข้อมูลนิติบุคคล</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">

                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <asp:DropDownList runat="server" ID="ddlTitleCompany" CssClass="form-control rounded-xs " ClientIDMode="Static">
                        <asp:ListItem Text="บจก." Value="004"/>
                        <asp:ListItem Text="บมจ." Value="005"/>
                        <asp:ListItem Text="หจก." Value="006"/>
                    </asp:DropDownList>
                    <label for="c1ab" class="form-label-always-active color-highlight">
                        คำนำหน้ากิจการ
                    </label>

                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="text" class="form-control rounded-xs" id="txtUpdateJName" placeholder="ไม่ระบุ" runat="server" clientidmode="Static" value="กิจการตัวอย่าง"/>
                    <label for="c1abc" class="form-label-always-active color-highlight">
                        ชื่อกิจการ
                    </label>

                </div>


                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="text" class="form-control rounded-xs" id="txtUpdateJID" placeholder="ไม่ระบุ" value="123456789XXXX"
                           runat="server" clientidmode="Static"/>
                    <label for="c1" class="color-highlight form-label-always-active">
                        เลขทะเบียนนิติบุคคล
                    </label>

                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent">
                    <input type="tel" maxlength="10" class="form-control rounded-xs" id="txtUpdateJMobilePhone" value="082999XXXX"
                           placeholder="ไม่ระบุ" runat="server" clientidmode="Static"/>
                    <label for="c1" class="color-highlight form-label-always-active">
                        เบอร์โทรศัพท์เคลื่อนที่

                    </label>
                </div>
                <div class="form-custom form-label form-border mb-3 bg-transparent" style="margin: 0px !important;">
                    <input type="email" class="form-control rounded-xs" id="txtUpdateJEmail" placeholder="-" runat="server" value="ตัวอย่างอีเมล์@gmail.com"
                           clientidmode="Static" style="border: none;"/>
                    <label for="c1" class="color-highlight form-label-always-active">
                        อีเมล์
                    </label>
                </div>


            </div>
            <div class="modal-footer" style="justify-content: center;">
                <button type="button" class="btn  mx-3 gradient-blue shadow-bg shadow-bg-xs" data-bs-dismiss="modal">ปิด</button>
                <button type="button" onclick="UpdateProfile('2')"
                        class="btn  mx-3 gradient-green shadow-bg shadow-bg-xs">
                    ยืนยัน
                </button>
            </div>
        </div>
    </div>
</div>


<div class="modal fade cssSuccessFinish" id="confirmUpdateDataModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <i class="bi bi-check-circle-fill-header"></i>
                <h5 class="modal-title" id="confirmUpdateDataHeader">แก้ไขข้อมูลเสร็จสิ้น</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                ระบบแก้ไขข้อมูลของท่านเป็นข้อมูลล่าสุด และบันทึกประวัติการแก้ไขข้อมูลของท่านเรียบร้อย
            </div>
            <div class="modal-footer" style="justify-content: center;">
                <button type="button" class="btn  mx-3 gradient-blue shadow-bg shadow-bg-xs" data-bs-dismiss="modal">ปิด</button>

            </div>
        </div>
    </div>
</div>

<div class="modal fade cssSuccessFinish" id="alertUpdateDataModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <i class="bi bi-x-circle-fill-header" style="color:green;font-size:30px;margin-right:10px;"></i>
                <h5 class="modal-title" id="alertUpdateDataHeader">แก้ไขข้อมูลขัดข้อง</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                ระบบเกิดเหตุขัดข้องในการแก้ไขข้อมูล กระณาติดต่อเจ้าหน้าที่ บสย.เพื่อแก้ไข
            </div>
            <div class="modal-footer" style="justify-content: center;">
                <button type="button" class="btn  mx-3 gradient-blue shadow-bg shadow-bg-xs" data-bs-dismiss="modal">ปิด</button>

            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/Profile.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>