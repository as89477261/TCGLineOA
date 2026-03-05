<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Site.Master" CodeBehind="Step7_1.aspx.cs"
    Inherits="CustomerHealthCheck.views.LOA.Step7_1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


        <div class="card card-style mx-3 px-2 py-2" id="pnlDataDIPROM" style="display: block;">
            <div class="accordion accordion-m border-0" id="accordion-group-1">
                <div class="accordion-item card card-style ms-n3 ps-3" style="background-image: linear-gradient(rgb(93,156,236),rgb(74,137,220)) !important; border-radius:20px; padding: 5px !important; margin: 0px!important;">
                    <button class="accordion-button px-0 ps-1 rounded-xs" type="button" data-bs-toggle="collapse" data-bs-target="#accordion1-1" aria-expanded="true">
                        <div>
                            <%--<h4 class="mb-n1 opacity-50" style="color: azure">สถานะปัจจุบัน (5/9)</h4>--%>
                            <h3 class="pt-1 mb-n1 opacity-80" style="color: azure">ยืนยันข้อมูล (5/9)</h3>
                        </div>
                        <div class="">
                            <i class="bi bi-arrow-down-short font-25" style="color:white"></i>
                        </div>
                    </button>
                </div>
            </div>
            <div class="accordion-collapse collapse collapse show" data-bs-parent="#accordion-group-1" id="accordion1-1">

                <div class="content">
                    <%--<h3 class="font-18 font-800 mb-0">ตรวจสอบข้อมูลลงทะเบียน </h3>--%>
                    <div class="gradient-blue shadow-bg shadow-bg-s rounded-m" id="btnStatusFix" style="display: none;">
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
                        รายละเอียดข้อมูลการลงทะเบียนของท่าน
                    </p>

                    <div style="border-radius: 10px; height: 500px; margin-bottom: 30px; overflow: scroll; border: 1px solid silver; padding: 10px;">
                        <div style="height: 500px;">
                            <div class="row" id="txtPreviewInformation">
                                <div class="col-12">
                                    <div class="content m-0">

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtCustomerName" class="color-highlight form-label-always-active">ชื่อ</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtCustomerName" placeholder="" value="ทดสอบ">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtCardID" class="form-label-always-active color-highlight">นามสกุล</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtCardID" placeholder="" value="ระบบ" />
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtSpouseName" class="form-label-always-active color-highlight">เลขบัตรประจำตัวประชาชน</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="txtSpouseName" placeholder="" value="8985522654123">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtMDName" class="color-highlight form-label-always-active">รหัสหลังบัตรประจำตัวประชาชน</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtMDName" placeholder="" value="TCG1525854">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtProvince" class="color-highlight form-label-always-active">เบอร์มือถือ</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtBusinessType" placeholder="" value="0885552545">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtProvince" class="color-highlight form-label-always-active">กรรมสิทธิ์ของสถานที่ประกอบกิจการ</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtEstablishmentType" placeholder="" value="เจ้าของ">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtYearIncorporate" class="color-highlight form-label-always-active">อายุกิจการ (ปี)</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtYearIncorporate" placeholder="" value="45">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtIndustryCode" class="color-highlight form-label-always-active">ประเภทกิจการ</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtIndustryCode" placeholder="" value="ขายส่ง">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtProvinceCode" class="color-highlight form-label-always-active">จังหวัดที่ตั้งกิจการ</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtProvinceCode" placeholder="" value="กรุงเทพ">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtOwnerAge" class="color-highlight form-label-always-active">อายุผู้บริหารหลัก (ปี)</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtOwnerAge" placeholder="" value="45">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtMaritalStatus" class="color-highlight form-label-always-active">สถานะภาพการสมรสของผู้บริหารหลัก</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtMaritalStatus" placeholder="" value="โสด">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtYearExperience" class="color-highlight form-label-always-active">ประสบการณ์โดยตรงในการทําธุรกิจนี้ (ปี)</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtYearExperience" placeholder="" value="50">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtIncome" class="color-highlight form-label-always-active">รายได้รวมของกิจการ (ต่อเดือน)</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtIncome" placeholder="" value="2000009.00">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtExpense" class="color-highlight form-label-always-active">กิจการคุณมีค่าใช้จ่าย (ต่อเดือน)</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtExpense" placeholder="" value="1000009.00">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtLoanAmount" class="color-highlight form-label-always-active">วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท)</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="txtLoanAmount" placeholder="" value="2850000.00">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="txtMobileNo" class="color-highlight form-label-always-active">วันที่ขอสินเชื่อ</label>
                                            <input type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="23/10/2530">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="" class="color-highlight form-label-always-active">ประเภทกิจการ(ISIC CODE)</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="G464140 : การขายส่งเสื้อผ้า">
                                        </div>

                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="" class="color-highlight form-label-always-active">วันที่เริ่มกิจการ</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="23/10/2530">
                                        </div>
                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="" class="color-highlight form-label-always-active">ประเภทกิจการ(ISIC CODE)</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="G464140 : การขายส่งเสื้อผ้า">
                                        </div>
                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="" class="color-highlight form-label-always-active">ประเภทกิจการ (ISIC CODE)</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="สิ่งทอและเครื่องนุ่งห่ม">
                                        </div>
                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="" class="color-highlight form-label-always-active">ชื่อกิจการ</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="ประดิษฐ์ทอผ้า">
                                        </div>
                                        <div class="form-custom form-label form-border mb-3 bg-transparent">
                                            <label for="" class="color-highlight form-label-always-active">วัตถุประสงค์การขอสินเชื่อครั้งนี้</label>
                                            <input autocomplete="off" type="text" class="form-control rounded-xs btn-disable" id="" placeholder="" value="หมุนเวียนธุรกิจ">
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-6">
                            <a href="#" onclick="redirectToLOAStep7()" class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ยกเลิก</a>
                        </div>
                        <div class="col-6">
                            <a href="#" id="btnSubmit" onclick="redirectToLOAStep7_2()" class="btn btn-full mx-1 gradient-blue shadow-bg shadow-bg-xs">ยืนยันข้อมูล</a>
                        </div>
                    </div>
                </div>
            </div>

        </div>




    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>

