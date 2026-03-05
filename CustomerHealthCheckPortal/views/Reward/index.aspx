<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs"
    Inherits="CustomerHealthCheck.views.Reward.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - Reward</title>
    <style>
        #qrcode img {
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page">

        <!-- Page Content - Only Page Elements Here-->
        <div class="page-content footer-clear">
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
                <div class="page-title d-flex" style="padding-bottom: 15px !important;">
                    <div class="align-self-center me-auto">
                        <h2 class="color-white" style="color: #092d74 !important;">รายการสิทธิประโยชน์ </h2>
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
                <div class="content">
                    <div class="tabs tabs-pill" id="tab-group-2">
                        <div class="tab-controls rounded-m p-1 overflow-visible">
                            <a class="font-13 rounded-m shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-4" aria-expanded="true">คูปองที่ร่วมรายการ</a>
                            <a class="font-13 rounded-m shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-5" aria-expanded="false">คูปองของฉัน</a>

                        </div>
                        <div class="mt-3"></div>
                        <!-- Tab Group 1 -->
                        <div class="collapse show" id="tab-4" data-bs-parent="#tab-group-2">
                            <asp:Panel runat="server" ID="pnlRewardHeaderItem" Visible="false">
                                <asp:Literal ID="ltlRewardHeaderItem" runat="server" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlRewardHeaderEmpty" Visible="false" Style="text-align: center;">
                                <h5 class="m-2">ไม่พบข้อมูลคู่ค้าร่วมรายการ </h5>

                                <div style="text-align: center; margin-top: 5px; margin-top: 5px;">
                                    <a href="#" data-bs-target="#checkRegisterModal"
                                        style="font-weight: 500;"
                                        class="btn btn-xs gradient-blue shadow-bg shadow-bg-xs mt-2 mb-2"
                                        onclick="redirectToHealthCheck();">ตรวจสุขภาพทางการเงิน เพื่อรับสิทธิ์</a>
                                </div>
                            </asp:Panel>

                            <%--   <a href='#' class='d-flex py-1' data-bs-toggle='offcanvas' data-bs-target='#menu-activity-1'>
                                <div class='align-self-center'>
                                    <span class='icon  me-2 shadow-bg shadow-bg-s rounded-s'>
                                        <img src='../../images/logos/hotel.jpg' width='45' class='rounded-s' alt='img'>
                                    </span>
                                </div>
                                <div class='align-self-center ps-1'>
                                    <h5 class='pt-1 mb-n1'>คูปองส่วนลดค่าที่พักโรงแรม</h5>
                                    <p class='mb-0 font-11 opacity-70'>หมดเขต <span class=''>31/12/2568</span></p>
                                </div>
                                <div class='align-self-center ms-auto text-end' onclick='ShowCondition();'>
                                    <span class='btn btn-xxs gradient-blue shadow-bg shadow-bg-xs'>เงื่อนไข</span>
                                </div>
                            </a>--%>
                        </div>


                        <!-- Tab Group 2 -->
                        <div class="collapse" id="tab-5" data-bs-parent="#tab-group-2">

                            <asp:Panel runat="server" ID="pnlRewardItem" Visible="false">
                                <asp:Literal ID="ltlRewardItem" runat="server" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlRewardEmpty" Visible="false" Style="text-align: center;">
                                <h5 class="m-2">ไม่พบข้อมูลสิทธิประโยชน์ </h5>

                                <div style="text-align: center; margin-top: 5px; margin-top: 5px;">
                                    <a href="#" data-bs-target="#checkRegisterModal"
                                        style="font-weight: 500;"
                                        class="btn btn-xs gradient-blue shadow-bg shadow-bg-xs mt-2 mb-2"
                                        onclick="redirectToHealthCheck();">ตรวจสุขภาพทางการเงิน เพื่อรับสิทธิ์</a>
                                </div>
                            </asp:Panel>




                            <%--                            <a href="#" class="d-flex py-1" data-bs-toggle="offcanvas" data-bs-target="#menu-activity-1">
                                <div class="align-self-center">
                                    <span class="icon me-2 shadow-bg shadow-bg-xs rounded-s">
                                        <img src="../../images/logos/pt.jpg" width="45" class="rounded-s" alt="img"></span>
                                </div>
                                <div class="align-self-center ps-1">
                                    <label class="pt-1 mb-n1" style="font-size: 14px; color: black; font-weight: 500;">ส่วนลดกาแฟพันธ์ไทย 50 บาท</label>
                                    <p class="mb-0 font-11 opacity-70"><span class="">หมดเขต 31/12/2567</span></p>
                                </div>
                                <div class="align-self-center ms-auto text-end">
                                    <span class="btn btn-xxs gradient-green shadow-bg shadow-bg-xs" style="font-size: 28px; padding: 0px 12px;" onclick="CalPrivilege('dc4da3bf-46b6-4094-86b1-3ae7e203d467');">
                                        <i class="bi bi-ticket-detailed"></i></span>
                                </div>
                            </a>--%>
                            <%--   <div class="divider my-2 opacity-50"></div>--%>
                        </div>
                    </div>
                </div>
            </div>






            <div class="card card-style" style="display: none;">
                <div class="content mb-0 p-1" style="margin: 0px 15px 10px 15px;">




                    <%--                   <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item" onclick="CalPrivilege()">
                            <img src="http://localhost:56955/images/logos/pt.jpg" width="40" class="me-3 rounded-xs" alt="img">
                            <div>
                                <h5 class="font-15 mb-0">สิทธิประโยชน์ ลดราคา 30 บาท</h5>
                                <span>กาแฟพันธ์ไทย</span>
                            </div>
                        </a>

                        <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item" onclick="CalPrivilege()">
                            <img src="http://localhost:56955/images/logos/pt.jpg" width="40" class="me-3 rounded-xs" alt="img">
                            <div>
                                <h5 class="font-15 mb-0">สิทธิประโยชน์ ลดราคา 50 บาท</h5>
                                <span>กาแฟพันธ์ไทย</span>
                            </div>
                        </a>--%>
                </div>
            </div>


        </div>

    </div>

    <!-- Transaction Action Sheet -->
    <div class="modal fade" id="modalCallPrivilege" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <i class="bi bi-ticket-detailed" style="color: blueviolet; font-size: 35px; margin-right: 10px;"></i>
                    <h5 class="modal-title" id="modalCallPrivilegeLabel">รายละเอียดคูปอง</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="padding: 15px !important;">
                    <div class="row">
                        <strong class="col-5 color-theme">ผู้ร่วมรายการ : </strong>
                        <label class="col-7 text-end">
                            <img src="../../images/logos/pt.jpg" style="width: 20px;" id="imgPartnerLogo" />&nbsp;
                            <label id="lblPartnerName"></label>
                        </label>
                        <div class="col-12 mt-2 mb-2">
                            <div class="divider my-0"></div>
                        </div>

                        <strong class="col-5 color-theme">คูปอง : </strong>
                        <label class="col-7 text-end">
                            <label id="lblCouponTitle"></label>
                        </label>
                        <div class="col-12 mt-2 mb-2">
                            <div class="divider my-0"></div>
                        </div>



                        <strong class="col-5 color-theme">รายละเอียด : </strong>
                        <label class="col-7 text-end">
                            <label id="lblCouponDetail"></label>
                        </label>
                        <div class="col-12 mt-2 mb-2">
                            <div class="divider my-0"></div>
                        </div>

                        <strong class="col-5 color-theme">วันหมดอายุคูปอง : </strong>
                        <label class="col-7 text-end">
                            <label id="lblPeriod"></label>
                        </label>
                        <div class="col-12 mt-2 mb-2">
                            <div class="divider my-0"></div>
                        </div>
                        <br />

                        <div class="col-12" style="text-align: center;">
                            <div id="qrcode"></div>
                        </div>
                        <div class="col-12" style="text-align: center; margin-top: 5px;">
                            <h4>Code :
                                <label id="lblCouponCode"></label>
                            </h4>
                        </div>

                        <br />
                        <br />
                        <div style="text-align: right;">
                            <label>
                                <asp:Label ID="txtCouponDetailRemark" Text="" runat="server" /></label>
                        </div>
                    </div>

                </div>

                <div class="modal-footer" style="justify-content: center;">


                    <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>

                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalConditionPrivilege" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <input type="hidden" id="hddOwnerCode" />
        <input type="hidden" id="hddProgramCode" />
        <input type="hidden" id="hddStartDate" />
        <input type="hidden" id="hddEndDate" />
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <i class="bi bi-ticket-detailed" style="color: blueviolet; font-size: 35px; margin-right: 10px;"></i>
                    <h5 class="modal-title" id="modalConditionPrivilegeLabel">รายละเอียดเงื่อนไขลุ้นรับคูปอง</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body" style="padding: 15px !important;" id="modal-body-step1">
                    <div class=" overflow-visible mt-0" style="margin: 0px; padding: 0px;">
                        <div class="mt-n5"></div>
                        <img id="imgConditionLogo" src="../../images/logos/pt.jpg" alt="img" style="width: 50%" class="mx-auto mt-n5 ">
                        <h2 class="color-theme text-center font-30 mb-0">ร้านค้าร่วมรายการ<br />
                            <label id="lblConditionTitle"></label>
                        </h2>
                        <p class="text-center font-11">
                            <i class="bi bi-check-circle-fill color-green-dark pe-2"></i>
                            <label id="lblConditionDesc"></label>
                        </p>

                        <div class="content mt-0 mb-2">
                            <div class="row">
                                <strong class="col-5 color-theme">เงื่อนไข : </strong>
                                <label class="col-7 ">
                                    <label id="lblConditionDetail">
                                        ร่วมกิจกรรมกับ บสย. ผ่าน Line OA ผ่านฟีเจอร์ ดังนี้
                                        <br />
                                        - ตรวจสุขภาพทางการเงิน
                                        <br />
                                        - ยืนยันตัวตนกับ บสย.
                                        <br />
                                        - ลงทะเบียน PGS 11
                                        <br />
                                        - ลงทะเบียนแก้หนี้ 3 สี
                                    </label>
                                </label>

                                <div class="col-12 mt-2 mb-2">
                                    <div class="divider my-0"></div>
                                </div>

                                <strong class="col-5 color-theme">วันสิ้นสุดโครงการ : </strong>
                                <label class="col-7 ">
                                    <label id="lblConditionEndDate">31/12/2567</label>
                                </label>
                                <div class="col-12 mt-2 mb-2">
                                    <div class="divider my-0"></div>
                                </div>
                                <strong class="col-5 color-theme">เงื่อนไขการใช้งาน : </strong>
                                <label class="col-7 ">
                                    <label id="lblConditionUseCase">
                                        - 1 สิทธิ์ต่อ 1 ท่าน
                                        <br />
                                        - บสย.ขอสงวนสิทธิ์ ยกเกิกโปรแกรมโดยไม่ต้องแจ้งล่วงหน้า
                                    </label>
                                </label>
                            </div>
                        </div>

                    </div>
                </div>


                <div class="modal-body" style="padding: 15px !important; display: none;" id="modal-body-step2">
                    <div class=" overflow-visible mt-0" style="margin: 0px; padding: 0px;">
                        <div class="mt-n5"></div>

                        <div class="row">
                            <div class="col-3" style="text-align: left">
                                <img id="imgConditionLogo2" src="../../images/logos/pt.jpg" alt="img" style="width: 100%" class="mx-auto mt-n5 ">
                            </div>
                            <div class="col">
                                <h3 class="color-theme font-20 mb-0">ร้านค้าร่วมรายการ<br />
                                    <label id="lblConditionTitle2"></label>
                                </h3>
                                <%-- <div class="text-center font-11">
                                    <label id="lblConditionDesc2"></label>
                                </div>--%>
                            </div>
                        </div>


                        <div class="content mt-4 mb-2">
                            <div class="row">
                                <div class="col">
                                    <div class="form-custom form-label form-border form-icon mb-1 bg-transparent">
                                        <i class="bi bi-phone font-16"></i>
                                        <style>
                                            input::placeholder {
                                                color: red;
                                            }

                                            .validateFail::-webkit-input-placeholder {
                                                color: red;
                                                
                                            }
                                        </style>
                                        <input autocomplete="off" type="number" class="form-control rounded-xs font-14" id="txtPhoneNumber"
                                            placeholder="โปรดระบุเบอร์โทรศัพทื์" pattern="/^-?\d+\.?\d*$/" onKeyPress="if(this.value.length==10) return false;" />
                                        
                                        <span>(required)</span>
                                    </div>
                                </div>
                                <div class="col-3" style="text-align: left;">
                                    <a name="btnSendOTP" class="btn btn-xs gradient-blue shadow-bg shadow-bg-xs" onclick="ShowVerifiesOTP('1')" id="btnSendOTP"
                                        style="padding: 9px 5px !important; width: 100%; font-size: 10px !important;">ส่ง OTP</a>
                                </div>
                            </div>
                            <div>
                                <label style="font-size: 12px; color: black;">** กรุณาตรวจสอบเบอร์โทรศัพท์ก่อนส่ง OTP</label>
                            </div>

                            <div class="row mt-4" id="modal-body-step3" style="display: none; margin-top: 15px;">
                                <div class="form-custom form-label form-border form-icon mb-1 bg-transparent">
                                    <i class="bi bi-chat-right-text-fill font-16"></i>
                                    <input autocomplete="off" type="text" class="form-control rounded-xs font-14" id="txtOTP" onclick="VerifyOTP()"
                                        placeholder="โปรดระบุรหัส OTP" maxlength="6" onkeypress="return onlyNumberKey(event)">
                                    <label for="c1" class="color-theme">โปรดระบุรหัส OTP ที่ได้รับ</label>
                                    <span>(required)</span>
                                </div>
                                <div class="mb-4" style="text-align: left;">
                                    Reference Number : <span id="ltlReferenceNumber"></span>
                                </div>
                                <div class="form-custom form-label form-border form-icon">
                                    <div id="html_element"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="modal-footer" style="justify-content: center;">
                    <div id="pnlBtnStep1">
                        <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                            class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ปิด</a>

                        <a href="#" onclick="GetUIDMapReward();" id="btnStep1"
                            class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยันรับสิทธิ์</a>
                    </div>

                    <div id="pnlBtnStep2" style="display: none;">
                        <a href="#" onclick="GetCoupon('1')"
                            class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ย้อนกลับ</a>

                        <a href="#" onclick="ConfirmVerifiesOTP()" id="btnStep3"
                            class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs btn-disable">ยืนยัน OTP</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalOTPPrivilege" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <i class="bi bi-phone" style="color: blueviolet; font-size: 35px; margin-right: 10px;"></i>
                    <h5 class="modal-title" id="modalOTPPrivilegeLabel">ยืนยัน OTP เพื่อรับสิทธิ์</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="padding: 15px !important;">
                </div>

                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" onclick="SendOTP();"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ส่ง OTP</a>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/qrcodejs/1.0.0/qrcode.min.js"></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>
    <script src="<%= ResolveClientUrl("~/scripts/Page/Reward.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</asp:Content>
