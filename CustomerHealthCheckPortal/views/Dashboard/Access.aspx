<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="CustomerHealthCheck.views.Dashboard.Access" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="preloader">
    <div class="spinner-border color-highlight" role="status"></div>
</div>

<!-- Page Wrapper-->
<div id="page">

<asp:HiddenField ID="hddSummaryPersonalType" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddSummaryRegisterType" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddSummaryEvent" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddSummaryRegisterPGS10" runat="server" ClientIDMode="Static"/>

<asp:HiddenField ID="hddUIDMonthly" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddUIDLabel" runat="server" ClientIDMode="Static"/>

<asp:HiddenField ID="hddMonthlyHCRegisterCount" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddMonthlyHCRegisterLabel" runat="server" ClientIDMode="Static"/>

<asp:HiddenField ID="hddMonthlyFARegisterCount" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddMonthlyFARegisterLabel" runat="server" ClientIDMode="Static"/>

<asp:HiddenField ID="hddEventCount" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddEventLabel" runat="server" ClientIDMode="Static"/>

<asp:HiddenField ID="hddRegisterPGS10Count" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddRegisterPGS10Label" runat="server" ClientIDMode="Static"/>

<!-- Page Content - Only Page Elements Here-->
<div class="page-content footer-clear" style="min-height: 0px !important; padding: 0px !important;">

<!-- Page Title-->
<div class="pt-3">
    <div class="page-title d-flex">

        <div class="align-self-center me-auto">
            <h1 class="color-theme mb-0 font-18">TCG Line OA Dashboard</h1>
        </div>

    </div>
</div>


<div class="card card-style">
<div class="content mt-3">
<div class="tabs tabs-box" id="tab-group-1">
<div class="tab-controls rounded-s border-highlight">
    <a class="font-13 color-highlight" data-bs-toggle="collapse" href="#tab-1" aria-expanded="true">ลงทะเบียน Line</a>
    <a class="font-13 color-highlight collapsed" data-bs-toggle="collapse" href="#tab-2" aria-expanded="false">ตรวจสุขภาพ</a>
    <a class="font-13 color-highlight collapsed" data-bs-toggle="collapse" href="#tab-3" aria-expanded="false">ประนอมหนี้</a>
    <a class="font-13 color-highlight collapsed" data-bs-toggle="collapse" href="#tab-4" aria-expanded="false">ลงทะเบียน กิจกรรม</a>
    <a class="font-13 color-highlight collapsed" data-bs-toggle="collapse" href="#tab-5" aria-expanded="false">ลงทะเบียน PGS10</a>
</div>
<div class="mt-3"></div>
<div class="collapse show" id="tab-1" data-bs-parent="#tab-group-1" style="">
    <div class="content">
        <h4 class="font-800">จำนวนผู้เข้าใช้งาน</h4>
    </div>

    <div id="charts-demo-UID" class="chart"></div>

    <div class="divider"></div>

    <div class="position-relative">
        <div class="position-absolute w-100" style="height: 320px">
            <!-- same height as chart in plugins/apex/apex-call.js-->
            <div class="card-center">
                <h1 class="pb-5 mb-5 text-center color-theme">
                    <span class="font-25 d-block pt-4 mt-1">
                        <asp:Literal ID="ltlRegisterCount" Text="" runat="server"/>
                    </span>
                    <span class="font-12 font-400 opacity-50 d-block mt-n2">จำนวนรวมทั้งหมด</span>
                </h1>
            </div>
        </div>
        <div class="mx-auto" style="width: 320px">
            <!-- same height as chart in plugins/apex/apex-call.js-->
            <div class="chart mx-auto no-click" id="chart-register"></div>
        </div>
    </div>

    <div class="content">
        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-red shadow-bg shadow-bg-xs">
                    <i class="bi bi-file-person font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">บุคคลธรรมดา</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนบุคคลลงทะเบียน</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-red-dark">
                    <asp:Literal ID="ltlPersonalCount" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">24.53%</p>--%>
            </div>
        </a>
        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-xs">
                    <i class="bi bi-building font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">นิติบุคคล</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนนิติบุคคลที่ลงทะเบียน</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-green-dark">
                    <asp:Literal ID="ltlCompanyCount" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>

        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs">
                    <i class="bi bi-patch-minus font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">ไม่ให้ข้อมูล Profile</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนผู้ใช้งานที่ไม่ได้ลงทะเบียน</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-blue-dark">
                    <asp:Literal ID="ltlTotalNotRegisterCount" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>

    </div>


</div>
<div class="collapse" id="tab-2" data-bs-parent="#tab-group-1" style="">

    <div class="content">
        <h4 class="font-800">ภาพรวมการตรวจสุขภาพ</h4>
    </div>

    <div id="charts-demo-1" class="chart"></div>


    <div class="divider"></div>


    <div class="position-relative">
        <div class="position-absolute w-100" style="height: 320px">
            <!-- same height as chart in plugins/apex/apex-call.js-->
            <div class="card-center">
                <h1 class="pb-5 mb-5 text-center color-theme">
                    <span class="font-25 d-block pt-4 mt-1">
                        <asp:Literal ID="ltlSummaryCount" Text="" runat="server"/>
                    </span>
                    <span class="font-12 font-400 opacity-50 d-block mt-n2">จำนวนรวมทั้งหมด</span>
                </h1>
            </div>
        </div>
        <div class="mx-auto" style="width: 320px">
            <!-- same height as chart in plugins/apex/apex-call.js-->
            <div class="chart mx-auto no-click" id="chart-activity"></div>
        </div>
    </div>
    <div class="content">
        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-red shadow-bg shadow-bg-xs">
                    <i class="bi bi-file-person font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">บุคคลธรรมดา</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนรายการในนามบุคคลธรรมดา</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-red-dark">
                    <asp:Literal ID="ltlPersonalValue" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">24.53%</p>--%>
            </div>
        </a>


        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-xs">
                    <i class="bi bi-building font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">นิติบุคคล</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนรายการในนามนิติบุคคล</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-green-dark">
                    <asp:Literal ID="ltlJuristicValue" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>

        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-blue shadow-bg shadow-bg-xs">
                    <i class="bi bi-patch-minus font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">ตรวจสุขภาพแต่ไม่ให้ Profile</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนรายการใช้งานแต่ไม่ลงทะเบียน</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-blue-dark">
                    <asp:Literal ID="ltlNotRegister" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>
    </div>


</div>
<div class="collapse" id="tab-3" data-bs-parent="#tab-group-1" style="">

    <div id="charts-demo-2" class="chart" style="max-width: 800px;"></div>

    <div class="divider"></div>
    <div class="content">
        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-xs">
                    <i class="bi bi-building font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">FA Register</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนคนลงทะเบียนประนอมหนี้ทั้งหมด</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-green-dark">
                    <asp:Literal ID="lblFARegister" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>
    </div>

</div>
<div class="collapse" id="tab-4" data-bs-parent="#tab-group-1" style="">

    <div id="charts-demo-3" class="chart" style="max-width: 800px;"></div>

    <div class="divider"></div>
    <div class="content">
        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-xs">
                    <i class="bi bi-building font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">กิจกรรม จับคู่กู้คํ้า</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนคนลงทะเบียนกิจกรรม</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-green-dark">
                    <asp:Literal ID="lblEventRegister" Text="" runat="server"/>
                </h4>
                <%--  <p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>
    </div>

</div>

<div class="collapse" id="tab-5" data-bs-parent="#tab-group-1" style="">

    <div id="charts-demo-5" class="chart" style="max-width: 800px;"></div>

    <div class="divider"></div>
    <div class="content">
        <a href="#" class="d-flex pb-3">
            <div class="align-self-center">
                <span class="icon rounded-s me-2 gradient-green shadow-bg shadow-bg-xs">
                    <i class="bi bi-building font-18 color-white"></i>
                </span>
            </div>
            <div class="align-self-center ps-1">
                <h5 class="pt-1 mb-n1">ลงทะเบียน PGS10</h5>
                <p class="mb-0 font-11 opacity-50">จำนวนคนลงทะเบียนทั้งหมด</p>
            </div>
            <div class="align-self-center ms-auto text-end">
                <h4 class="pt-1 mb-n1 color-green-dark">
                    <asp:Literal ID="lblEventRegisterPGS10" Text="" runat="server"/>
                </h4>
                <%--<p class="mb-0 font-12 opacity-50">41.27%</p>--%>
            </div>
        </a>

        <asp:Literal Text="" ID="ltlGroupStatus" runat="server"/>


    </div>

</div>
</div>
</div>
</div>


</div>
<!-- End of Page ID-->
</div>
</asp:Content>