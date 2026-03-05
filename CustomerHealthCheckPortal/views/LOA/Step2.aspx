<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Step2.aspx.cs"
    Inherits="CustomerHealthCheck.views.LOA.Step2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page" style="z-index: 1;">

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

            <div class="card card-style px-2 py-2" id="pnlSignUpForm">
                <div class="content">
                    <h3 class="mb-0 mt-2 font-22">แบบฟอร์มลงทะเบียน KYC
                    </h3>
                    <p>
                        กรุณากรอกข้อมูลของท่านให้ครบถ้วน
                    </p>

                    <div class="row" id="step1">

                        <div class="col-12">
                            <div class="content m-0">

                                <%--                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <input autocomplete="off" type="text" class="form-control rounded-xs" id="txtIDCard" placeholder="โปรดระบุเลขบัตรประจำตัวประชาชน" value="">
                                    <label for="txtIDCard" class="form-label-always-active color-highlight">เลขบัตรประจำตัวประชาชน</label>
                                    <span>(required)</span>
                                </div>--%>

                                <div class="form-custom form-label no-icon mb-3">
                                    <input autocomplete="off" type="number" pattern="/^-?\d+\.?\d*$/" onkeypress="if(this.value.length==13) return false;" class="form-control rounded-xs" id="txtIdentityId" placeholder="เลขบัตรประจำตัวประชาชน/เลขนิติบุคคล" maxlength="13" value="">
                                    <label for="txtIDCard" class="form-label-always-active color-highlight">กรอกข้อมูลเลขบัตร 13 หลัก</label>
                                    <span>(required)</span>
                                </div>

                                <div class="form-custom form-label form-border mb-3 bg-transparent">
                                    <div id="html_element"></div>
                                </div>

                                <div class="row">
                                    <div class="col-6">
                                        <a href="#" onclick="redirectToLOAStep1()" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ย้อนกลับ</a>
                                    </div>
                                    <div class="col-6">
                                        <a href="#" id="btnSubmit" onclick="ShowModalConfirmApproved()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ถัดไป </a>


                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="ChooseBankNDIDModal"
                aria-hidden="true"
                data-backdrop="false"
                aria-labelledby="exampleModalToggleLabel"
                tabindex="-1"
                data-bs-backdrop="false">

                <div class="modal-dialog modal-dialog-centered modal-l">
                    <div class="modal-content" id="modalContent2">
                        <div class="modal-header">
                            <h5 class="modal-title" id="ChooseBankConfirmModalLabel">เลือกธนาคารที่ท่านเคยยืนยันตัวตน KYC </h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">


                            <div id="pnlConfirmRequestStep2" style="display: block;">
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ยืนยันรายการคำขอคํ้าประกัน ด้วยกระบวนการยืนยันตัวตนผ่าน NDID ผ่าน Mobile Banking ของธนาคารที่ท่านเคยยืนยันตัวตน (KYC)</span>
                                <br />
                                <br />
                                <div style="text-align: left;">
                                    หมายเลขคำขอ :
                            <label id="lblChooseBankRequestNumber"></label>
                                </div>


                                <div class="card card-style" style="margin: 0px; height: 220px; overflow: auto;">
                                    <div class="content mb-0" style="margin: 5px;">

                                        <!-- Tab 2-->
                                        <div class="collapse show" id="tab-5" data-bs-parent="#tab-group-2" style="">

                                            <div class="list-group list-custom list-group-m list-group-flush rounded-xs"
                                                style="border: 1px solid whitesmoke">

                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-kbank" onclick="onlyOne(this)">
                                                    <i class="bank bank-kbank xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารกสิกรไทย</strong><span>KBANK</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="kbank" class="ios-input" name="check" id="switch-kbank">
                                                            <label class="custom-control-label" for="switch-kbank"></label>
                                                        </div>
                                                    </div>
                                                </a>

                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-scb" onclick="onlyOne(this)">
                                                    <i class="bank bank-scb xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารไทยพาณิชย์</strong><span>SCB</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="scb" class="ios-input" name="check" id="switch-scb">
                                                            <label class="custom-control-label" for="switch-scb"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-ktb" onclick="onlyOne(this)">
                                                    <i class="bank bank-ktb xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารกรุงไทย</strong><span>KTB</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="ktb" class="ios-input" name="check" id="switch-ktb">
                                                            <label class="custom-control-label" for="switch-ktb"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-ttb" onclick="onlyOne(this)">
                                                    <i class="bank bank-ttb xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารทหารไทยธนชาต</strong><span>TTB</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="ttb" class="ios-input" name="check" id="switch-ttb">
                                                            <label class="custom-control-label" for="switch-ttb"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-baac" onclick="onlyOne(this)">
                                                    <i class="bank bank-baac xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารเพื่อการเกษตรและสหกรณ์การเกษตร</strong><span>BAAC</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="baac" class="ios-input" name="check" id="switch-baac">
                                                            <label class="custom-control-label" for="switch-baac"></label>
                                                        </div>
                                                    </div>
                                                </a>

                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-gsb" onclick="onlyOne(this)">
                                                    <i class="bank bank-gsb xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารออมสิน</strong><span>GSB</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="gsb" class="ios-input" name="check" id="switch-gsb">
                                                            <label class="custom-control-label" for="switch-gsb"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-ghb" onclick="onlyOne(this)">
                                                    <i class="bank bank-ghb xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารอาคารสงเคราะห์</strong><span>GHB</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="ghb" class="ios-input" name="check" id="switch-ghb">
                                                            <label class="custom-control-label" for="switch-ghb"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-kkp" onclick="onlyOne(this)">
                                                    <i class="bank bank-kk xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารเกียรตินาคินภัทร</strong><span>KKP</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="kkp" class="ios-input" name="check" id="switch-kkp">
                                                            <label class="custom-control-label" for="switch-kkp"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-bay" onclick="onlyOne(this)">
                                                    <i class="bank bank-bay xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารกรุงศรีอยุธยา</strong><span>BAY</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="bay" class="ios-input" name="check" id="switch-bay">
                                                            <label class="custom-control-label" for="switch-bay"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-bbl" onclick="onlyOne(this)">
                                                    <i class="bank bank-bbl xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคารกรุงเทพ</strong><span>BBL</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="bbl" class="ios-input" name="check" id="switch-bbl">
                                                            <label class="custom-control-label" for="switch-bbl"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-ais" onclick="onlyOne(this)">
                                                    <i class="bank bank-ais xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>เอไอเอส</strong><span>AIS</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="ais" class="ios-input" name="check" id="switch-ais">
                                                            <label class="custom-control-label" for="switch-ais"></label>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a href="#" class="list-group-item" style="padding: 5px;" data-trigger-switch="switch-cimb" onclick="onlyOne(this)">
                                                    <i class="bank bank-cimb xxxl"></i>
                                                    <div style="margin-left: 15px;">
                                                        <strong>ธนาคาร ซีไอเอ็มบี</strong><span>CIMB</span>
                                                    </div>
                                                    <div class="align-self-center ms-auto">
                                                        <div class="form-switch ios-switch switch-green switch-l">
                                                            <input type="checkbox" value="cimb" class="ios-input" name="check" id="switch-cimb">
                                                            <label class="custom-control-label" for="switch-cimb"></label>
                                                        </div>
                                                    </div>
                                                </a>


                                            </div>
                                        </div>

                                        <!-- End of Tabs-->
                                    </div>

                                </div>

                                <br />
                                <label style="color: red; font-size: 12px;">
                                    ** ระบบจำเป็นต้องขอข้อมูล NCB ของท่านเพื่อใช้ในการพิจารณาคำขอคํ้าประกันสินเชื่อ
                                </label>
                            </div>

                        </div>
                        <div class="modal-footer" style="justify-content: center;">
                            <a href="#" data-bs-target="#ChooseBankNDIDModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                                class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                            </a>

                            <a href="#" onclick="redirectToLOAStep3_1()"
                                class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน
                            </a>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/LOA/Step2.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/jquery-1.6.4.min.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/jquery-ui-1.8.10.custom.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>">
</asp:Content>
