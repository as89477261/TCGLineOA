<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.Bill.index" %>

<%@ Register Src="~/UserControl/MyBill/UC_MyBill.ascx" TagPrefix="uc1" TagName="UC_MyBill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>TCG OneStopService - My Bill</title>
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
                        <h2 class="color-white" style="color: #092d74 !important;">My Bill</h2>
                    </div>

                </div>
            </div>

            <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
                <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
                <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
                <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
                <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
            </svg>


            <!-- New Bill Menu -->
            <div id="Bill-main">

                <asp:Repeater ID="RepeaterMyBill" runat="server" OnItemDataBound="RepeaterMyBill_ItemDataBound">
                    <ItemTemplate>
                        <uc1:UC_MyBill runat="server" ID="UC_MyBill1" Index="<%# Container.ItemIndex %>" />
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Panel runat="server" ID="pnlMockupBill">
                    <div id="Bill-main1">

                        <div class="card card-style">
                            <div class="content">
                                <div class="accordion-item">
                                    <button class="accordion-button px-0 ps-1 collapsed" type="button" style="box-shadow: none;" data-bs-toggle="collapse" aria-expanded="true" data-bs-target="#BillLGList1">
                                        <i class="bi bi-file-earmark-text color-blue-dark pe-3 font-16"></i>

                                        <span class="font-600 font-16">
                                            <storng>
                                                LG No 61027452
                                            </storng>
                                        </span>
                                        <i class="bi bi-arrow-down-short font-20"></i>
                                    </button>
                                    <div id="BillLGList1" class="accordion-collapse collapse show">
                                        <div class="collapse show" id="Bill-1-Tab-History" data-bs-parent="#LGBillgroup-1">
                                            <hr style="margin: 5px;">
                                            <div class="list-group list-custom list-group-m list-group-flush rounded-xs">

                                                <div class="list-group-item" href="#Bill-63068512-Tab-History-List" data-bs-toggle="offcanvas" data-bs-target="#Bill-63068512-Tab-History-List">
                                                    <a class="has-bg ms-2 me-2 bi bi-view-list font-16"></a>
                                                    <div class="ms-2">
                                                        <strong>ชำระเลขที่ :  63068512
                                                        </strong>
                                                        <span>การต่ออายุ(เต็มปี)
                                                        </span>
                                                    </div>
                                                    <div class="flex-fill text-end">
                                                        <strong>25/02/2020
                                                        </strong><span>วันที่ตรวจรับ</span>
                                                    </div>
                                                </div>

                                                <div class="list-group-item" href="#Bill-62040898-Tab-History-List" data-bs-toggle="offcanvas" data-bs-target="#Bill-62040898-Tab-History-List">
                                                    <a class="has-bg ms-2 me-2 bi bi-view-list font-16"></a>
                                                    <div class="ms-2">
                                                        <strong>ชำระเลขที่ :  62040898
                                                        </strong>
                                                        <span>การต่ออายุ(เต็มปี)
                                                        </span>
                                                    </div>
                                                    <div class="flex-fill text-end">
                                                        <strong>26/02/2019
                                                        </strong><span>วันที่ตรวจรับ</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div id="Bill-63068512-Tab-History-List" class="offcanvas offcanvas-bottom offcanvas-detached rounded-m" style="height: max-content; display: block;">
                            <div class="menu-size" style="height: max-content">
                                <div class="d-flex mx-3 mt-3 py-1">
                                    <div class="align-self-center">
                                        <h1 class="mb-0">ใบเสร็จรับเงิน</h1>
                                        <a>ค่าธรรมเนียมดำเนินการค้ำประกัน LG: 6102xxxx</a>
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
                                        <h5 class="col-5 text-start font-15">วันที่ชำระ</h5>
                                        <h5 class="col-7 text-end font-14 font-400">
                                            <span class="bg-green-dark px-2 rounded-s">ลงวันที่ 25 กุมภาพันธ์ 2563
                                            </span>
                                        </h5>
                                        <h5 class="col-5 text-start font-15">ชำระโดย</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">ธนาคารออมสิน   ชำระแทน
                                        </h5>
                                        <h5 class="col-5 text-start font-15">ได้รับเงินจาก</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">เงินโอน ธนาคารออมสิน สาขา สำนักงานใหญ่
                                        </h5>
                                        <h5 class="col-5 text-start font-15">เลขที่ทำรายการ</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">63068512
                                        </h5>

                                        <h5 class="col-5 text-start font-15">ประเภทใบเสร็จ</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">การต่ออายุ(เต็มปี)
                                        </h5>

                                        <h5 class="col-5 text-start font-15">จำนวนเงิน</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">฿1,000.00
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="Bill-62040898-Tab-History-List" class="offcanvas offcanvas-bottom offcanvas-detached rounded-m" style="height: max-content; display: block;">
                            <div class="menu-size" style="height: max-content">
                                <div class="d-flex mx-3 mt-3 py-1">
                                    <div class="align-self-center">
                                        <h1 class="mb-0">ใบเสร็จรับเงิน</h1>
                                        <a>ค่าธรรมเนียมดำเนินการค้ำประกัน LG: 6102xxxx</a>
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
                                        <h5 class="col-5 text-start font-15">วันที่ชำระ</h5>
                                        <h5 class="col-7 text-end font-14 font-400">
                                            <span class="bg-green-dark px-2 rounded-s">ลงวันที่ 25 กุมภาพันธ์ 2562
                                            </span>
                                        </h5>
                                        <h5 class="col-5 text-start font-15">ชำระโดย</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">ธนาคารออมสิน   ชำระแทน
                                        </h5>
                                        <h5 class="col-5 text-start font-15">ได้รับเงินจาก</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">เงินโอน ธนาคารออมสิน สาขา สำนักงานใหญ่
                                        </h5>
                                        <h5 class="col-5 text-start font-15">เลขที่ทำรายการ</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">62040898
                                        </h5>

                                        <h5 class="col-5 text-start font-15">ประเภทใบเสร็จ</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">การต่ออายุ(เต็มปี)
                                        </h5>

                                        <h5 class="col-5 text-start font-15">จำนวนเงิน</h5>
                                        <h5 class="col-7 text-end font-14 opacity-60 font-400">฿1,000.00
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/MyBill.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>
