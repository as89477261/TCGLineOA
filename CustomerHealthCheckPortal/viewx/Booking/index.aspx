<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs"
Inherits="CustomerHealthCheck.viewx.Booking.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
            <h2 class="color-white" style="color: #092d74 !important;">ปรึกษาหมอหนี้ </h2>
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
            <div class="tab-controls rounded-m p-1 overflow-visible">
                <a class="font-13 rounded-s py-1 shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-4" aria-expanded="true">หมอหนี้</a>
                <a class="font-13 rounded-s py-1 shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-5" aria-expanded="false">คิวการนัดหมาย</a>
                <a class="font-13 rounded-s py-1 shadow-bg shadow-bg-s" data-bs-toggle="collapse" href="#tab-6" aria-expanded="false">ประวัติการปรึกษา</a>
            </div>
            <div class="mt-3"></div>
            <!-- Tab Bills List -->
            <div class="collapse show" id="tab-4" data-bs-parent="#tab-group-2">
                <div class="pt-3"></div>
                <div class="list-group list-custom list-group-m list-group-flush rounded-xs">
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-bill" class="list-group-item">
                        <img src="../../images/personal/p1.png" width="43" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">ดร.ตัวอย่าง นามสมมุติ</h5>
                            <span>ความถนัด: อุตสาหกรรมอาหาร และการธนาคาร</span>
                        </div>
                        <span class="badge rounded-xl bg-green-dark">ให้บริการ</span>
                    </a>
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-bill" class="list-group-item">
                        <img src="../../images/personal/p2.png" width="43" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">ดร.ดีเด่น เป็นกันเอง</h5>
                            <span>ความถนัด: ด้านการเงิน และ Startup</span>
                        </div>
                        <span class="badge rounded-xl bg-green-dark">ให้บริการ</span>
                    </a>
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-bill" class="list-group-item">
                        <img src="../../images/personal/p3.png" width="43" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">ดร.เก่ง นามสกุลดี</h5>
                            <span>ความถนัด: ด้านการเงิน</span>
                        </div>
                        <span class="badge bg-green-dark rounded-xl">ให้บริการ</span>
                    </a>

                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-bill" class="list-group-item">
                        <img src="../../images/personal/p5.png" width="43" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">ดร.สมมุติ หยุดเสาร์อาทิตย์</h5>
                            <span>ความถนัด: ด้านการเงิน และ Startup</span>
                        </div>
                        <span class="badge rounded-xl">พักให้บริการ</span>
                    </a>

                </div>
            </div>

            <!-- Tab Custom Payments-->
            <div class="collapse" id="tab-5" data-bs-parent="#tab-group-2">
                <div class="pt-3"></div>
                <div class="list-group list-custom list-group-m list-group-flush rounded-xs">
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                        <img src="../../images/personal/p1.png" width="43" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">นัดหมาย วันที่ : 22/05/2563 </h5>
                            <div class="mt-2"></div>
                            <span>เรื่อง : ขอคำปรึกษาเรื่องการเงิน</span>
                            <span>สถานที่ : สำนักงานใหญ่ตึกชาญอิสระ</span>
                            <span>หมอหนี้ : ดร.ตัวอย่าง นามสมมุติ</span>
                        </div>
                        <span class="badge rounded-xl bg-green-dark">อีก 2 วันข้างหน้า</span>
                    </a>
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                        <img src="../../images/personal/p1.png" width="43" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">นัดหมาย วันที่ : 22/05/2563 </h5>
                            <div class="mt-2"></div>
                            <span>เรื่อง : ขอคำปรึกษาเรื่องการเงิน</span>
                            <span>สถานที่ : สำนักงานใหญ่ตึกชาญอิสระ</span>
                            <span>หมอหนี้ : ดร.ตัวอย่าง นามสมมุติ</span>
                        </div>
                        <span class="badge rounded-xl bg-green-dark">อีก 2 วันข้างหน้า</span>
                    </a>

                </div>
            </div>

            <div class="collapse" id="tab-6" data-bs-parent="#tab-group-2">
                <div class="pt-3"></div>
                <div class="list-group list-custom list-group-m list-group-flush rounded-xs">
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                        <img src="../../images/personal/p1.png" width="33" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">ขอคำปรึกษาเรื่องการเงิน</h5>
                            <span>ดร.ตัวอย่าง นามสมมุติ วันที่ : 22/05/2563</span>
                        </div>
                        <span class="badge rounded-xl bg-green-dark"></span>
                    </a>
                    <a href="#" data-bs-toggle="offcanvas" data-bs-target="#menu-request" class="list-group-item">
                        <img src="../../images/personal/p1.png" width="33" class="me-3 rounded-xs" alt="img"/>
                        <div>
                            <h5 class="font-15 mb-0">ขอคำปรึกษาเรื่องการชำระหนี้</h5>
                            <span>ดร.ตัวอย่าง นามสมมุติ วันที่ : 12/02/2563</span>
                        </div>
                        <span class="badge rounded-xl bg-green-dark"></span>
                    </a>

                </div>
            </div>
        </div>
    </div>
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
                        <img src="../../images/personal/p1.png" width="33" class="me-3 rounded-xs" alt="img"/>
                    </div>
                    <div class="col-10">
                        <h4>หมอหนี้ : ดร.ตัวอย่าง นามสมมุติ</h4>
                    </div>
                </div>
                <div class="row">
                    <img src="../../images/calendar.png" style="margin: 0 auto; width: 350px;"/>
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
</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>