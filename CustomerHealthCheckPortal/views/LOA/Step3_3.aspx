<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Step3_3.aspx.cs"
    Inherits="CustomerHealthCheck.views.LOA.Step3_3" %>

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

        <div class="card card-style px-2 py-2" id="pnlSignUpForm">
            <div class="content">
                <h3 class="mb-0 mt-2 font-22">แบบฟอร์มสอบถามทางการเงิน
                </h3>
                <p>
                    กรุณากรอกข้อมูลของท่านให้ครบถ้วน
                </p>



                <div class="stepwizard">
                    <div class="stepwizard-row setup-panel">
                        <div class="stepwizard-step col-xs-3">
                            <a href="#step-1" type="button" class="btn btn-success btn-circle">1</a>
                            <p style="line-height: 16px;"><small>ยอมรับเงื่อนไข NDID</small></p>
                        </div>
                        <div class="stepwizard-step col-xs-3">
                            <a href="#step-2" type="button" class="btn btn-success btn-circle" >2</a>
                            <p style="line-height: 16px;"><small>เลือกธนาคาร</small></p>
                        </div>
                        <div class="stepwizard-step col-xs-3">
                            <a href="#step-3" type="button" class="btn btn-success btn-circle" >3</a>
                            <p style="line-height: 16px;"><small>เข้าสู่แอปธนาคาร</small></p>
                        </div>
                        <div class="stepwizard-step col-xs-3">
                            <a href="#step-4" type="button" class="btn btn-default btn-circle" disabled="disabled">4</a>
                            <p style="line-height: 16px;"><small>กลับสู่ระบบ Line TCG</small></p>
                        </div>
                    </div>
                </div>





                <div class="row" id="step1">

                    <div class="col-12">
                        <div class="content m-0">
                            <div class="row" style="padding: 10px; margin-top: 20px; overflow-x: scroll; margin-bottom: 20px;">

                                <h2 class="">ท่านกำลังให้ธนาคาร</h2>
                                <p>
                                    กรุณาไปยืนยันตัวตนที่โมบาย
                                </p>
                            </div>

                            <div class="row" style="text-align: center;margin-bottom:30px;">

                                <div class="countdown mt-4" id="countdown">
                                    <%--<span id="days">00</span> :--%>
                                    <%-- <span id="hours">00</span> :--%>
                                    <span id="minutes">00</span> :
                                <span id="seconds">00</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12 center">
                                    <a href="#"
                                        onclick="redirectToLOAStep3_1()"
                                        class="btn btn-full mx-1 gradient-red shadow-bg shadow-bg-xs ">ยกเลิก</a>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>








    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/LOA/Step3.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/jquery-ui-1.8.10.custom.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>">

    <style>
        .stepwizard-step p {
            margin-top: 0px;
            color: #666;
        }

        .stepwizard-row {
            display: table-row;
        }

        .stepwizard {
            display: table;
            width: 100%;
            position: relative;
        }

        .stepwizard-step button[disabled] {
            /*opacity: 1 !important;
    filter: alpha(opacity=100) !important;*/
            background: white;
        }

        .stepwizard .btn.disabled, .stepwizard .btn[disabled], .stepwizard fieldset[disabled] .btn {
            opacity: 1 !important;
            color: #bbb;
            background: white;
            z-index: 9;
        }

        .stepwizard-row:before {
            top: 14px;
            bottom: 0;
            position: absolute;
            content: " ";
            width: 80%;
            height: 1px;
            background-color: #ccc;
            z-index: 0;
            margin-left: 45px;
        }

        .stepwizard-step {
            display: table-cell;
            text-align: center;
            position: relative;
        }

        .btn-circle {
            width: 30px;
            height: 30px;
            text-align: center;
            padding: 6px 0;
            font-size: 12px;
            line-height: 1.428571429;
            border-radius: 15px;
        }

        .countdown {
            justify-content: center;
            align-items: center;
            font-size: 3rem;
        }

        .container {
            padding-top: 50px;
        }

        .timer-box {
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 20px;
        }
    </style>

    <script>// ------------step-wizard-------------
        $(document).ready(function () {

            var navListItems = $('div.setup-panel div a'),
                allWells = $('.setup-content'),
                allNextBtn = $('.nextBtn');

            startCountdown();

            allWells.hide();

            navListItems.click(function (e) {
                e.preventDefault();
                var $target = $($(this).attr('href')),
                    $item = $(this);

                if (!$item.hasClass('disabled')) {
                    //navListItems.removeClass('btn-success').addClass('btn-default');
                    $item.addClass('btn-success');
                    allWells.hide();
                    $target.show();
                    $target.find('input:eq(0)').focus();
                }
            });

            allNextBtn.click(function () {
                var curStep = $(this).closest(".setup-content"),
                    curStepBtn = curStep.attr("id"),
                    nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
                    curInputs = curStep.find("input[type='text'],input[type='url']"),
                    isValid = true;

                $(".form-group").removeClass("has-error");
                for (var i = 0; i < curInputs.length; i++) {
                    if (!curInputs[i].validity.valid) {
                        isValid = false;
                        $(curInputs[i]).closest(".form-group").addClass("has-error");
                    }
                }

                if (isValid) nextStepWizard.removeAttr('disabled').trigger('click');
            });

            $('div.setup-panel div a.btn-success').trigger('click');
        });


  let countdownDate;

    function startCountdown() {
      // Get the date and time set by the user
     
        const a = new Date();
 countdownDate = a.setMinutes(a.getMinutes() + 60);

      // Update the countdown every 1 second
      let x = setInterval(function() {
        // Get the current date and time
        let now = new Date().getTime();
        
        // Calculate the distance between now and the countdown date
        let distance = countdownDate-now;;


        // Calculate days, hours, minutes and seconds
        let days = Math.floor(distance / (1000 * 60 * 60 * 24));
        let hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        let seconds = Math.floor((distance % (1000 * 60)) / 1000);
        
        // Display the result
        //document.getElementById("days").innerHTML = days.
        //    toString().padStart(2, '0');
        //document.getElementById("hours").innerHTML = hours.
        //    toString().padStart(2, '0');
        document.getElementById("minutes").innerHTML = minutes.
            toString().padStart(2, '0');
        document.getElementById("seconds").innerHTML = seconds.
            toString().padStart(2, '0');
        
        // If the countdown is over, display a message
          if (seconds == 55) {
              redirectToLOAStep3_4();
          }

        if (distance < 0) {
          clearInterval(x);
          document.getElementById("countdown").innerHTML = "EXPIRED";
        }
      }, 1000);
    }
    </script>

</asp:Content>
