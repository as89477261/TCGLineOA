<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs"
    Inherits="CustomerHealthCheck.views.RequestInfo.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - NDID Confirm Request</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hddJson" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddLstOnlineID" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddRegisterDummyID" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddENCBConsentAPI" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddENCBConsentToken" ClientIDMode="Static" />

    <asp:HiddenField runat="server" ID="hddIDCard" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddFirstName" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddLastName" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddDob" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddBirthDate" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddMobileNo" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddEmail" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hddProductCode" ClientIDMode="Static" />

    <!-- Page Wrapper-->
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
                <div class="page-title d-flex">
                    <div class="align-self-center me-auto">
                        <h2 class="color-white" style="color: #092d74 !important;">รายการคำขอ </h2>
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
                <div class="content mb-0">
                    <div class="tabs tabs-pill" id="tab-group-2">

                        <div class="tab-controls rounded-m p-1 overflow-visible" style="background: silver; text-align: center;">
                            <%--<a class="font-13 rounded-s py-1 shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-4" aria-expanded="true">หมอหนี้</a>--%>
                            <a class="font-13 rounded-s py-1 shadow-bg shadow-bg-s tabCustomBar" data-bs-toggle="collapse" onclick="ShowDownloadSlipPanel('0')"
                                href="#tab-5" aria-expanded="true">ยืนยันรายการคำขอ (<asp:Literal Text="" ID="lblCountWaitingItem" runat="server" />)
                            </a>
                            <a class="font-13 rounded-s py-1 shadow-bg shadow-bg-s tabCustomBar" data-bs-toggle="collapse" onclick="ShowDownloadSlipPanel('1')"
                                href="#tab-6" aria-expanded="false">ประวัติทำรายการ (<asp:Literal Text="" ID="lblCountFinishItem" runat="server" />)
                            </a>

                        </div>


                        <!-- Tab List request verified my identity none complete-->
                        <div class="collapse show" id="tab-5" data-bs-parent="#tab-group-2">

                            <div class="pt-3"></div>
                            <asp:Panel runat="server" ID="pnlRequestWaitingItem" class="list-group list-custom list-group-m list-group-flush rounded-xs" Visible="false">

                                <asp:Literal Text="" ID="ltlRequestiWaitingItem" runat="server" />

                                <%-- <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                                    <img src="../../images/RequestInfo/RequestInfo_Document.png" width="43" class="me-3 rounded-xs" alt="img" />
                                    <div>
                                        <div style="display:inline-block;">
                                            <h5 style="float:left;margin-right:10px;" class="font-15 mb-0">เลขที่คำขอ : O65000255 </h5> <span style="float:left;height:25px;margin:0px;padding-left:10px;padding-right:10px;" class="rounded-xl bg-red-dark">รอยืนยันตัวตน</span>
                                        </div>
                                       
                                        <div class="mt-2"></div>
                                        <span>โครงการ : สินเชื่อ TCG RBP</span>
                                        <span>วงเงินคำขอสินเชื่อ : 1,500,000 บาท</span>
                                        <span>วันที่เพิ่มคำขอ : 11/01/2023</span>
                                    </div>
                                   
                                </a>--%>
                                <%--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                                    <img src="../../images/personal/p1.png" width="43" class="me-3 rounded-xs" alt="img" />
                                    <div>
                                        <h5 class="font-15 mb-0">นัดหมาย วันที่ : 22/05/2563 </h5>
                                        <div class="mt-2"></div>
                                        <span>เรื่อง : ขอคำปรึกษาเรื่องการเงิน</span>
                                        <span>สถานที่ : สำนักงานใหญ่ตึกชาญอิสระ</span>
                                        <span>หมอหนี้ : ดร.ตัวอย่าง นามสมมุติ</span>
                                    </div>
                                    <span class="badge rounded-xl bg-green-dark">อีก 2 วันข้างหน้า</span>
                                </a>--%>
                                <a runat="server" id="btnConfirmRequest" href="#" onclick="ConfirmApprovedForm()" style="margin: 15px;" class="btn btn-full mx-3 gradient-blue shadow-bg shadow-bg-s">ยืนยันรายการคำขอ</a>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlEmptyWaitingItem" Style="text-align: center; margin: 10px;" Visible="true">
                                <label style="font-size: 20px;">ยังไม่พบรายการคำขอคํ้าประกัน</label>
                            </asp:Panel>
                        </div>

                        <!-- Tab List request verified my identity none complete-->
                        <div class="collapse" id="tab-6" data-bs-parent="#tab-group-2">
                            <div class="pt-3"></div>

                            <asp:Panel runat="server" ID="pnlRequestFinishedItem" class="list-group list-custom list-group-m list-group-flush rounded-xs">
                                <asp:Literal Text="" ID="ltlRequestFinishedItem" runat="server" />


                                <%--
                                <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                                    <img src="../../images/RequestInfo/RequestInfo_Document.png" width="43" class="me-3 rounded-xs" alt="img" />
                                    <div>
                                        <h5 class="font-15 mb-0">เลขที่คำขอ : O65000255 </h5>
                                        <div class="mt-2"></div>
                                        <span>โครงการ : สินเชื่อ TCG RBP</span>
                                        <span>วงเงินคำขอสินเชื่อ : 1,500,000 บาท</span>
                                        <span>วันที่เพิ่มคำขอ : 11/01/2023</span>
                                    </div>
                                    <span class="badge rounded-xl bg-red-dark">รอยืนยันตัวตน</span>
                                </a>--%>
                                <%--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                                    <img src="../../images/personal/p1.png" width="43" class="me-3 rounded-xs" alt="img" />
                                    <div>
                                        <h5 class="font-15 mb-0">นัดหมาย วันที่ : 22/05/2563 </h5>
                                        <div class="mt-2"></div>
                                        <span>เรื่อง : ขอคำปรึกษาเรื่องการเงิน</span>
                                        <span>สถานที่ : สำนักงานใหญ่ตึกชาญอิสระ</span>
                                        <span>หมอหนี้ : ดร.ตัวอย่าง นามสมมุติ</span>
                                    </div>
                                    <span class="badge rounded-xl bg-green-dark">อีก 2 วันข้างหน้า</span>
                                </a>--%>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlEmptyFinishedItem" Style="text-align: center; margin: 10px;" Visible="true">
                                <label style="font-size: 20px;">ไม่พบรายการคำขอคํ้าประกัน</label>
                            </asp:Panel>
                            <%-- <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                                    <img src="../../images/RequestInfo/RequestInfo_Document.png" width="43" class="me-3 rounded-xs" alt="img" />
                                    <div>
                                        <h5 class="font-15 mb-0">เลขที่คำขอ : O65000255 </h5>
                                        <div class="mt-2"></div>
                                        <span>โครงการ : สินเชื่อ TCG RBP</span>
                                        <span>วงเงินคำขอสินเชื่อ : 1,500,000 บาท</span>
                                        <span>วันที่เพิ่มคำขอ : 11/01/2023</span>
                                    </div>
                                    <span class="badge rounded-xl bg-green-dark">ยืนยันสำเร็จ</span>
                                </a>--%>
                            <%--<a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                                    <img src="../../images/personal/p1.png" width="33" class="me-3 rounded-xs" alt="img" />
                                    <div>
                                        <h5 class="font-15 mb-0">ขอคำปรึกษาเรื่องการชำระหนี้</h5>
                                        <span>ดร.ตัวอย่าง นามสมมุติ วันที่ : 12/02/2563</span>
                                    </div>
                                    <span class="badge rounded-xl bg-green-dark"></span>
                                </a>--%>
                        </div>


                    </div>
                </div>
            </div>




            <asp:Panel runat="server" ID="pnlNCBEConsentSlip" Visible="false" ClientIDMode="Static" Style="display: none;">
                <asp:HiddenField ID="hddTransID" runat="server" ClientIDMode="Static" />

                <%--                 <asp:Panel runat="server" ID="Panel1" Visible="false" ClientIDMode="Static" Style="display: none;">--%>
                <div class="card card-style" runat="server">
                    <div class="content mb-0">
                        <a style="border: none;" href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">

                            <div style="display: inline-block; width: 75%; padding: 5px; float: left;">
                                <h5 style="float: left; margin-right: 10px;" class="font-15 mb-0">หลักฐานการให้ความยินยอมเปิดเผยข้อมูล </h5>

                                <p style="float: left; margin-right: 10px;" class="font-11 mb-0">
                                    ปรับปรุงข้อมูลล่าสุด : 
                                    <asp:Literal Text="" ID="ltlSlipCreateDate" runat="server" />
                                </p>
                            </div>

                            <div class="m-2" style="float: right; display: inline-block;">
                                <%--<asp:LinkButton ID="btnDownloadSlip" runat="server"                                    
                                   CssClass="btn btn-sm gradient-green shadow-bg shadow-bg-xs"
                                  
                                   style="padding:10px 15px !important;">
                                   <i class="bi bi-save" style="font-size: 20px;"></i>
                               </asp:LinkButton>--%>

                                <span class="btn btn-sm gradient-green shadow-bg shadow-bg-xs"
                                    onclick="DownloadFile();return false;"
                                    style="padding: 10px 15px !important;"
                                    id="btnDownloadSlip">
                                    <i class="bi bi-save" style="font-size: 20px;"></i>
                                </span>
                            </div>
                        </a>
                    </div>
                </div>
            </asp:Panel>



        </div>


        <!-- Bill Button Menu -->
        <div id="menu-bill"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m" style="height: 670px !important;">
            <!-- menu-size will be the dimension of your menu. If you set it to smaller than your content it will scroll-->
            <div class="menu-size" style="height: 670px;">
                <div class="d-flex mx-3 mt-3 py-1">
                    <div class="align-self-center">
                        <h3 class="mb-0">ทำรายการนัดหมาย</h3>
                    </div>
                    <div class="align-self-center ms-auto">
                        <a href="#" class="ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                            <i class="bi bi-x color-red-dark font-26 line-height-xl"></i>
                        </a>
                    </div>
                </div>
                <div class="divider divider-margins mt-3 mb-2"></div>
                <div class="card card-style">
                    <div class="content">

                        <div class="row mb-3 mt-4">
                            <div class="col-2">
                                <img src="../../images/personal/p1.png" width="33" class="me-3 rounded-xs" alt="img" />
                            </div>
                            <div class="col-10">
                                <h4>หมอหนี้ : ดร.ตัวอย่าง นามสมมุติ</h4>
                            </div>
                        </div>
                        <div class="row">
                            <img src="../../images/calendar.png" style="margin: 0 auto; width: 350px;" />
                        </div>
                        <div class="row">
                            <div class="demo-animation needs-validation mt-3" novalidate="">
                                <div class="form-custom form-label form-icon mb-3">
                                    <i class="bi bi-calendar4-event font-14"></i>
                                    <input type="text" class="form-control rounded-xs" id="c1" placeholder="เวลาที่นัดหมาย" pattern="[A-Za-z ]{1,32}" required="">
                                    <label for="c1" class="color-theme">Your Name</label>
                                    <div class="valid-feedback">Excellent!</div>
                                    <div class="invalid-feedback">Name is Missing or Invalid</div>
                                    <span>(required)</span>
                                </div>
                                <div class="form-custom form-label form-icon mb-3">
                                    <i class="bi bi-building font-16"></i>
                                    <input type="email" class="form-control rounded-xs" id="c2" placeholder="สถานที่ที่นัดหมาย" pattern="[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="">
                                    <label for="c2" class="color-theme">Your Email</label>
                                    <div class="valid-feedback">Email address looks good!</div>
                                    <div class="invalid-feedback">Email is missing or is invalid.</div>
                                    <span>(required)</span>
                                </div>

                            </div>
                        </div>

                        <a href="#" data-bs-dismiss="offcanvas" class="mx-3 btn btn-full gradient-blue shadow-bg shadow-bg-s mb-3">ยืืนยันนัดหมาย</a>
                    </div>
                </div>
            </div>
        </div>

        <!-- Bill Button Menu -->
        <div id="menu-bill-paid"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m" style="height: 350px !important;">
            <!-- menu-size will be the dimension of your menu. If you set it to smaller than your content it will scroll-->
            <div class="menu-size" style="height: 350px;">
                <div class="d-flex mx-3 mt-3 py-1">
                    <div class="align-self-center">
                        <h1 class="mb-0">ใบเสร็จรับเงิน</h1>
                    </div>
                    <div class="align-self-center ms-auto">
                        <a href="#" class="ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                            <i class="bi bi-x color-red-dark font-26 line-height-xl"></i>
                        </a>
                    </div>
                </div>
                <div class="divider divider-margins mt-3 mb-2"></div>
                <div class="content mt-0">
                    <div class="row mb-3 mt-4">
                        <h5 class="col-5 text-start font-15">รหัสใบเสร็จ</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">#13241</h5>
                        <h5 class="col-5 text-start font-15">วันที่ออก</h5>
                        <h5 class="col-7 text-end font-14 font-400">
                            <span class="bg-green-dark px-2 rounded-s">12/01/2563</span>
                        </h5>
                        <h5 class="col-5 text-start font-15">รหัสหนังสือคํ้าประกัน</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">66-00001</h5>
                        <h5 class="col-5 text-start font-15">อัตราค่าธรรมเนี่ยม/ปี</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">1.75%</h5>
                        <h5 class="col-5 text-start font-15">ค่าธรรมเนียม</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">52,482.5 บาท</h5>
                    </div>
                    <div class="divider my-2"></div>
                </div>
                <a href="#" data-bs-dismiss="offcanvas" class="mx-3 btn btn-full gradient-blue shadow-bg shadow-bg-s mb-3">ดาวน์โหลดใบเสร็จรับเงิน (e-Receipt)</a>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ConfirmNDIDModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="confirmModalLabel">ยืนยันทำรายการ</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ยืนยันรายการคำขอคํ้าประกัน ด้วยกระบวนการยืนยันตัวตนผ่าน NDID</span>
                    <br />
                    <br />
                    <div style="text-align: left;">
                        หมายเลขคำขอ :
                    <label id="lblRequestNumber"></label>
                    </div>
                    <br />
                    <br />
                    <label style="color: red; font-size: 12px;">
                        ** ระบบจำเป็นต้องขอข้อมูล NCB ของท่านเพื่อใช้ในการพิจารณาคำขอคํ้าประกันสินเชื่อ
                    </label>
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#ConfirmNDIDModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>
                    <a href="#" onclick="ApprovedSubmitForm()"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยืนยัน
                    </a>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ConfirmUseOldNCBDataModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ConfirmUseOldNCBDataModalLabel">ยืนยันการใช้ข้อมูล NCB </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField runat="server" ID="hddNCBGrade" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddNCBScore" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddNCBTransID" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddNDIDReferenceID" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddStepName" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddStepNumber" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddIsSuccessNCB" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddT01OnlineIDStep" ClientIDMode="Static" />
                    <asp:HiddenField runat="server" ID="hddNCBTransactionID" ClientIDMode="Static" />
                      <asp:HiddenField runat="server" ID="hddNDIDRef" ClientIDMode="Static" />


                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ท่านต้องการใช้ข้อมูล NCB เดิมที่เคยให้ไว้กับ บสย. เพื่อเป็นข้อมูลการวิเคราะห์การคํ้าประกันสินเชื่อกับ บสย. ได้</span>
                    <br />
                    <br />

                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-target="#ConfirmUseOldNCBDataModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>
                    <a href="#" onclick="ConfirmApprovePreviousNCBScore()"
                        class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน
                    </a>
                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="ChooseBankNDIDModal" aria-hidden="true" data-backdrop="true"
        aria-labelledby="exampleModalToggleLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered modal-l">


            <div class="modal-content" id="modalContent1">
                <div class="modal-header">
                    <h5 class="modal-title" id="ChooseBankConfirmModalLabel1">ข้อตกลงขอรับเอกสารหลักฐานทางอีเมล</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">

                    <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ข้าพเจ้าตกลงขอรับเอกสารหลักฐานการให้ความยินยอมและหรือเอกสารใดๆภายใต้การทำสัญญาขอคํ้าประกันสินเชื่อนี้ ทางอีเมลที่ข้าพเจ้าได้ให้ไว้กับ บสย.  </span>
                    <br />
                    <br />


                    <div class="demo-animation needs-validation m-0" novalidate="">
                        <div class="form-custom form-label form-icon mb-3">
                            <i class="bi bi-at font-16"></i>
                            <asp:TextBox runat="server" type="email" ClientIDMode="Static"
                                class="form-control rounded-xs"
                                ID="textboxEmailEConsentSlip"
                                value=""
                                placeholder="ระบุอีเมล์"
                                pattern="[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="" />

                            <label for="c2" class="color-theme">Your Email</label>
                            <div class="valid-feedback">Email address looks good!</div>
                            <div class="invalid-feedback">Email is missing or is invalid.</div>
                            <span id="lblRequireEmail" style="display: none;">(required)</span>
                            <span id="lblOptionEmail">(Optional)</span>
                        </div>

                        <a href="#" data-trigger-switch="switch-3" class="d-flex pb-2" onclick="ShowLabelEmailRequire();">
                            <div class="align-self-center">
                                <h5 class="mb-0 font-700 font-15">ขอรับหลักฐานทางอีเมล์</h5>
                            </div>
                            <div class="align-self-center ms-auto">
                                <div class="form-switch ios-switch switch-green switch-L">
                                    <i class="color-white font-9">รับ</i>
                                    <input type="checkbox" class="ios-input" id="switch-3" value="0">
                                    <label class="custom-control-label" for="switch-3"></label>
                                    <i class="color-theme font-9">ไม่รับ</i>
                                </div>
                            </div>
                        </a>
                    </div>

                    <br />
                    <label style="color: red; font-size: 12px;">
                        ** กรณีขอรับหลักฐาน กรุณาตรวจสอบอีเมล์ของท่านให้ถูกต้องก่อนไปขั้นตอนถัดไป และหากไม่สะดวกรับทางอีเมล์ สามารถดาวน์โหลดได้จากเมนูยืนยันคำขอคํ้าประกัน
                    </label>
                </div>

                <div class="modal-footer" style="justify-content: center;">
                    <a href="#" data-bs-target="#ChooseBankNDIDModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ยกเลิก
                    </a>

                    <a href="#" onclick="ShowPanel('2')"
                        class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs">ถัดไป
                    </a>
                </div>
            </div>





            <div class="modal-content" id="modalContent2" style="display: none;">
                <div class="modal-header">
                    <h5 class="modal-title" id="ChooseBankConfirmModalLabel">เลือกธนาคารที่ท่านเคยยืนยันตัวตน KYC</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">

                    <div id="pnlConfirmRequestStep1" style="display: none;">
                    </div>

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
                    <a href="#" onclick="ShowPanel('1')"
                        class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">ย้อนกลับ
                    </a>

                    <a href="#" onclick="ApprovedSubmitForm()"
                        class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/Request_Info.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>
