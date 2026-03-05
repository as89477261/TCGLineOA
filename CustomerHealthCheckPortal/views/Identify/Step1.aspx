<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Identify.Master" AutoEventWireup="true" CodeBehind="Step1.aspx.cs" Inherits="CustomerHealthCheck.views.Identify.Step1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hddImage1" Value="" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddImage2" Value="" runat="server" ClientIDMode="Static"/>
<asp:HiddenField ID="hddImage3" Value="" runat="server" ClientIDMode="Static"/>
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

    <div class="card card-style">
        <div class="content">
            <div class="d-flex">
                <div class="mt-1">
                    <p class="color-highlight font-600 mb-n1">ขั้นตอนที่ (1/3)</p>
                    <h1 class="mb-0">ถ่ายรูปหลักฐานเพื่อยืนยันตัวตนกับ บสย.</h1>
                </div>
                <div class="ms-auto">
                </div>
            </div>


            <div class="divider"></div>
            <div class="d-flex mb-4">
                <div class="row">
                    <div class="col-4">
                        <canvas id="canvas1" class="canvas" width="600" height="450"></canvas>
                        <div id="snapshot1">
                            <img src="../../images/pictures/Identify/หน้าบัตร.jpg" id="img1" width="100%"
                                 style="max-height: 100px; max-width: 200px;"/>
                        </div>
                    </div>

                    <div class="col-8">
                        <div class="row">
                            <div class="col-12">
                                <div class="ps-3 w-100">
                                    <h1 class="mb-0">รูปหน้าบัตรประชาชน </h1>
                                    <p class="mb-0 color-red-light font-11">**กรุณาถ่ายในที่สว่างและปรับภาพให้ชัดเจนก่อนถ่ายภาพ</p>
                                    <div class="button-group">
                                    </div>
                                </div>
                            </div>

                            <div class="col-6">
                                <a id="btnStream1" onclick="btnStream1Onclick(1)" data-bs-toggle="modal" data-bs-target="#checkRegisterModal"
                                   class="btn btn-full btn-s rounded-s font-800 gradient-highlight">
                                    ถ่ายรูป
                                </a>

                            </div>
                            <div class="col-6">
                                <label id="picture1" for="file"
                                       class="btn btn-full btn-s rounded-s font-800 gradient-highlight">
                                    เลือกรูป
                                </label>
                                <input id="file1" name="file1" type="file" accept="image/*">
                            </div>
                        </div>
                    </div>
                </div>

            </div>


            <div class="divider"></div>
            <div class="d-flex mb-4">
                <div class="row">
                    <div class="col-4">
                        <canvas id="canvas2" class="canvas" width="600" height="450"></canvas>
                        <div id="snapshot2">
                            <img src="../../images/pictures/Identify/หลังบัตร.jpg" id="img2" width="100%"
                                 style="max-height: 100px; max-width: 200px;"/>
                        </div>
                    </div>

                    <div class="col-8">
                        <div class="row">
                            <div class="col-12">
                                <div class="ps-3 w-100">
                                    <h1 class="mb-0">รูปหลังบัตรประชาชน </h1>
                                    <p class="mb-0 color-red-light font-11">**กรุณาถ่ายในที่สว่างและปรับภาพให้ชัดเจนก่อนถ่ายภาพ</p>
                                    <div class="button-group">
                                    </div>
                                </div>
                            </div>

                            <div class="col-6">
                                <a id="btnStream2" onclick="btnStream1Onclick(2)" data-bs-toggle="modal" data-bs-target="#checkRegisterModal"
                                   class="btn btn-full btn-s rounded-s font-800 gradient-highlight">
                                    ถ่ายรูป
                                </a>

                            </div>
                            <div class="col-6">
                                <label id="picture2" for="file"
                                       class="btn btn-full btn-s rounded-s font-800 gradient-highlight">
                                    เลือกรูป
                                </label>
                                <input id="file2" name="file1" type="file" accept="image/*">
                            </div>
                        </div>
                    </div>
                </div>

            </div>


            <div class="divider"></div>
            <div class="d-flex mb-4">
                <div class="row">
                    <div class="col-4">
                        <canvas id="canvas3" class="canvas" width="600" height="450"></canvas>
                        <div id="snapshot3">
                            <img src="../../images/pictures/Identify/selfie.PNG" id="img3" width="100%"
                                 style="max-height: 100px; max-width: 200px;"/>
                        </div>
                    </div>

                    <div class="col-8">
                        <div class="row">
                            <div class="col-12">
                                <div class="ps-3 w-100">
                                    <h1 class="mb-0">รูปตนเองคู่กับบัตรประชาชน </h1>
                                    <p class="mb-0 color-red-light font-11">**กรุณาถ่ายในที่สว่างและปรับภาพให้ชัดเจนก่อนถ่ายภาพ</p>
                                    <div class="button-group">
                                    </div>
                                </div>
                            </div>

                            <div class="col-6">
                                <a id="btnStream3" onclick="btnStream1Onclick(3)" data-bs-toggle="modal" data-bs-target="#checkRegisterModal"
                                   class="btn btn-full btn-s rounded-s font-800 gradient-highlight">
                                    ถ่ายรูป
                                </a>

                            </div>
                            <div class="col-6">
                                <label id="picture3" for="file"
                                       class="btn btn-full btn-s rounded-s font-800 gradient-highlight">
                                    เลือกรูป
                                </label>
                                <input id="file3" name="file1" type="file" accept="image/*">
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="divider mt-4"></div>
            <label id="lblValidateComment" style="color:red;"></label>
            <asp:Button ID="btnSubmitKYCStep1" OnClick="btnSubmitKYCStep1_Click" OnClientClick="return ValidateStep1();"
                        class="btn btn-full btn-l rounded-s w-100 font-800 text-uppercase gradient-green "
                        Text="ถัดไป" runat="server"/>
            <%--<a href="#" onclick="redirectToStep2()" class="btn btn-full btn-l rounded-s font-800 text-uppercase gradient-green "></a>--%>
        </div>
    </div>
</div>


<div class="modal fade" id="confirmSendIdenImage" aria-hidden="true" aria-labelledby="exampleModalToggleLabel" tabindex="-1" data-bs-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="confirmSendIdenImageHeader">ยืนยันความถูกต้องข้อมูล</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:HiddenField ID="hddSelectPicNumber" Value="" runat="server" ClientIDMode="Static"/>
                ข้าพเจ้าขอยืนยันว่าข้อมูลการตรวจสุขภาพทางการเงินของข้าพเจ้า เป็นข้อมูลที่ถูกต้อง และข้าพเจ้ายินยอมให้ทาง บสย. นำไปใช้เพื่อประมวณผลตามกระบวนการภายใน

            </div>
            <div class="modal-footer" style="justify-content: center;">

                <a href="#" data-bs-target="#confirmSendIdenImage" data-bs-toggle="modal" data-bs-dismiss="modal"
                   class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">
                    ยกเลิก
                </a>

                <asp:Button ID="btnConfirmIdenImage" OnClientClick="btnCaptureOnclick()"
                            class="btn btn-sm mx-3 gradient-green shadow-bg shadow-bg-xs " Text="ยืนยัน" runat="server"/>
                <%--<a href="#" onclick="redirectToStep4()" class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">ยืนยัน</a>--%>
            </div>
        </div>
    </div>
</div>


<div class="modal fade" id="checkRegisterModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel"
     tabindex="-1" data-bs-backdrop="static">
    <div class="modal-dialog modal-dialog-centered modal-md">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalToggleLabel">ถ่ายภาพ</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div id="camera" class="camera">
                    <video id="stream" class="stream" width="100%" height="650"></video>
                    <%-- <div>
                            <span></span>
                            <span></span>
                            <span></span>
                        </div>--%>
                </div>

            </div>
            <div class="modal-footer" style="justify-content: center;">


                <a href="#" data-bs-target="#checkRegisterModal" data-bs-toggle="modal" data-bs-dismiss="modal"
                   class="btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs">
                    ยกเลิก
                </a>


                <a href="#" onclick="btnCaptureOnclick()" data-bs-dismiss="modal"
                   class="btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs">
                    ยืนยัน
                </a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/plugins/WebRTC/sdk.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/Page/Identify.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <style>
        .canvas, .camera, input[type=file] {
            display: none
        }

        .disable {
            background-color: #efefef;
            color: #777;
        }

        .stream, .snapshot img, #canvas {
            width: 100%;
            height: 360px;
        }

        .custom-file-upload {
            width: 49.4%;
            border-radius: 4px;
            background-color: #06c755;
            padding: 20px 0;
            cursor: pointer;
            margin: 8px 0;
            color: white;
            font-weight: bold;
            font-size: 16px;
            text-align: center
        }

        .camera {
            position: relative;
        }

            .camera div {
                cursor: pointer;
            }

            .camera span {
                position: absolute;
                border-radius: 50%;
                bottom: 20px;
                left: 0;
                right: 0;
                margin-left: auto;
                margin-right: auto;
                display: flex;
                align-items: center;
                justify-content: center;
            }

                .camera span:first-of-type {
                    background: white;
                    width: 80px;
                    height: 80px;
                }

                .camera span:nth-of-type(2) {
                    background: black;
                    bottom: 24px;
                    width: 72px;
                    height: 72px;
                }

                .camera span:last-of-type {
                    background: white;
                    bottom: 28px;
                    width: 64px;
                    height: 64px;
                }
    </style>
</asp:Content>