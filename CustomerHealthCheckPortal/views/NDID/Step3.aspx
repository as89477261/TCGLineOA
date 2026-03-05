<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Step.Master" AutoEventWireup="true" CodeBehind="Step3.aspx.cs"
Inherits="CustomerHealthCheck.views.NDID.Step3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="page-content footer-clear">

        <div class="pt-3">
            <div class="page-title d-flex">
                <div class="align-self-center">
                    <a href="#" class="me-3 ms-0 icon icon-xxs bg-theme rounded-s shadow-m">
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

        <div class="card card-style">
            <div class="content" style="overflow: scroll;">
                <h4 class="">เลือกผู้ให้บริการยืนยันตัวตน</h4>
                <p>
                    กรุณาเลือกผู้ให้บริการยืนยันตัวตน ที่ท่านมีแอปพลิเคชันพร้อมใช้งานแล้ว ศึกษาขั้นตอนการยืนยันตัวตนโดยคลิกเลือกผู้ให้บริการที่ต้องการ
                </p>

                <div class="content my-1">
                    <div class="collapse show" id="tab-16" data-bs-parent="#tab-group-6">
                        <div class="list-group list-custom list-group-m list-group-flush rounded-xs">
                            <asp:Literal ID="ltlIdpList" Text="" runat="server"/>


                            <%--   <a href="#" data-trigger-switch="switch-3l" class="d-flex pb-2 mb-1">
                                <img src="../../images/logos/Ndid.png" class="me-3 rounded-xs" alt="img" style="width: 30px; height: 30px;">
                                <div class="align-self-center">
                                    <h5 class="mb-0 font-17">Idp1</h5>
                                    <span>Ndid Node</span>
                                </div>
                                <div class="align-self-center ms-auto">
                                    <div class="form-switch ios-switch switch-blue switch-m">
                                        <input type="checkbox" class="ios-input" id="switch-3l">
                                        <label class="custom-control-label" for="switch-3l"></label>
                                    </div>
                                </div>
                            </a>--%>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <a class="btn btn-full mx-3 gradient-blue shadow-bg shadow-bg-s" onclick="ShowModalConfirmStep3()">ดำเนินการต่อ</a>
        <br/>
        <a class="btn btn-full mx-3 gradient-red shadow-bg shadow-bg-s" onclick="redirectToNDIDStep2()">ย้อนกลับ</a>
    </div>

    <div class="modal fade" id="confirmChooseIDPModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
        <div class="modal-dialog modal-dialog-centered modal-m">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="RegisteredLabel">ยืนยัน</h5>
                </div>
                <div class="modal-body">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ยืนยันการเลือกผู้ยืนยันตัวตน
                </div>
                <div class="modal-footer" style="justify-content: center;">

                    <a href="#" data-bs-dismiss="modal"
                       class="btn btn-sm mx-3 gradient-red shadow-bg shadow-bg-xs">
                        ยกเลิก
                    </a>
                    <a href="#" data-bs-dismiss="modal" onclick="SubmitConditionStep3();"
                       class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">
                        ดำเนินการต่อ
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/NDID.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>