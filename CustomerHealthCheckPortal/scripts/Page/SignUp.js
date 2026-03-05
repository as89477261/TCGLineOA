
// Startup page
document.addEventListener("DOMContentLoaded", () => {
    if (isDebugMode == "0") {
        CheckLoginMainLineWithRedirect("https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/SignUp/index");
    }
});

var onloadCallback = function () {
    grecaptcha.render('html_element', {
        'sitekey': '6LeW2owoAAAAAHx7cWk81dNFq3OW73tb62RynwQ6',
        'callback': ShowButtonConfirmStep
    });
};
function ShowButtonConfirmStep() {
    var btn = document.getElementById("btnSubmit");
    btn.classList.remove("btn-disable");
}
// Front end Function
function ShowModalConfirmStep() {
    function ShowModalConfirmStep() {
        const container = document.getElementById("ConfirmRegisterModal");
        const modal = new bootstrap.Modal(container);
        modal.show();
    }
    function ShowModalSubmitOTP() {
        const containerSubmitOTP = document.getElementById("FinishModal");
        const modalSubmitOTP = new bootstrap.Modal(containerSubmitOTP);
        modalSubmitOTP.show();
    }
    const container = document.getElementById("ConfirmRegisterModal");
    const modal = new bootstrap.Modal(container);
    modal.show();
}
function ShowModalSubmitOTP() {
    const containerSubmitOTP = document.getElementById("FinishModal");
    const modalSubmitOTP = new bootstrap.Modal(containerSubmitOTP);
    modalSubmitOTP.show();
}
function ShowModalDopaCheckInfo() {
    const containerSubmitOTP = document.getElementById("FinishModal");
    const modalSubmitOTP = new bootstrap.Modal(containerSubmitOTP);
    modalSubmitOTP.show();
}
// Page Utility Function

function SendOTP() {
    LoaderActive();
    ShowLoading().then(() => {
        SendOTP_CoreSendOTP();
    });

}
async function SendOTP_CoreSendOTP() {
    DisableAndCounting("disable");
    var enrollDummyID = getCookie("SIGNUP_DummyID");
    var ddlSMSPhoneNumber = document.getElementById("ddlSMSPhoneNumber");
    var phoneNumber = ddlSMSPhoneNumber.value;

    console.log("Phone Number is : " + phoneNumber);
    if (phoneNumber != "") {
        var resultSendOTP = await CallServiceSendOTP(enrollDummyID, phoneNumber);

        if (resultSendOTP != "" && resultSendOTP != "undefined") {
            sendOTPObj = JSON.parse(resultSendOTP);
            console.log("Send OTP Status is : " + sendOTPObj.RESULT_OBJ);
            document.getElementById("pnlKeyInOTP").style.display = "block";
            document.getElementById("ltlReferenceNumber").innerText = sendOTPObj.RESULT_OBJ;
            LoaderInActive();
        } else {
            LoaderInActive();
            swal('แจ้งเตือน', 'กรุณาลองอีกครั้ง', 'warning');
        }
    }
}

function ShowLoading() {
    return new Promise((resolve) => {
        setTimeout(() => {

            loader.classList.add("loader--show");
            resolve('true')
        }, 10)
    })
}
async function CallServiceSendOTP(dummyID, phoneNumber) {
    if (dummyID != "" && phoneNumber != "") {
        //var result = SendPersonalOTP(dummyID, phoneNumber);
        let result = await SendPersonalOTPAsync(dummyID, phoneNumber);

        return result;
    }

}
function KeepUIDMapEnrollment(uid, dummyid) {

}
function RedirectTo(step) {

    var pnlConsent = document.getElementById("pnlConsent");
    var pnlSignUpForm = document.getElementById("pnlSignUpForm");
    var pnlConfirmOTP = document.getElementById("pnlConfirmOTP");
    switch (step) {
        case "1":
            pnlConsent.style.display = "block";
            pnlSignUpForm.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            break;
        case "2":
            pnlConsent.style.display = "none";
            pnlSignUpForm.style.display = "block";
            pnlConfirmOTP.style.display = "none";
            break;
        case "3":
            pnlConsent.style.display = "none";
            pnlSignUpForm.style.display = "none";
            pnlConfirmOTP.style.display = "block";
            break;
        default:
            break;
    }
}
function DisableAndCounting(action) {

    console.log("Disable button and send OTP");

    var limitCounting = 3;
    var btnSendOTP = document.getElementById("btnSendOTP");

    if (action == "disable") {
        btnSendOTP.classList.add("btn-disable");
        btnSendOTP.classList.remove("gradient-blue");
        CountDownResend();
    } else {
        btnSendOTP.classList.remove("btn-disable");
        btnSendOTP.classList.add("gradient-blue");
        btnSendOTP.innerText = "ขอรหัส OTP";
    }
}
function CountDownResend() {

    var minute = 4;
    var sec = 60;
    var interval = setInterval(function () {
        document.getElementById("btnSendOTP").style.color = "black";
        document.getElementById("btnSendOTP").innerHTML = "ส่งได้อีกครั้งใน " + minute + ":" + sec + " นาที";
        sec--;

        if (sec == 00) {
            minute--;

            if (minute > 0) {
                sec = 60;

            } else {
                clearInterval(interval);
                DisableAndCounting("Enable");
                return;
            }
        }

    }, 1000);

}

// Validation
function ValidateEnrolmentForm() {

    var result = true;
    var txtFirstName = document.getElementById("txtFirstName");
    var txtLastName = document.getElementById("txtLastName");
    var txtPhone = document.getElementById("txtPhone");
    var txtEmail = document.getElementById("txtEmail");
    var txtIDCard = document.getElementById("txtIDCard");
    var txtLaserID = document.getElementById("txtLaserID");
    var ddlTitle = document.getElementById("ddlTitlePersonal");

    if (txtFirstName.value == "") {
        result = false;
    }
    if (txtLastName.value == "") {
        result = false;
    }
    if (txtPhone.value == "") {
        result = false;
    }
    if (txtEmail.value == "") {
        result = false;
    }
    if (txtIDCard.value == "") {
        result = false;
    }
    if (txtLaserID.value == "") {
        result = false;
    }
    if (ddlTitle.value == "") {
        result = false;
    }
    console.log("Step 2 : Validation Form is : " + result);
    return result;
}
function ValidateAcceptConsent() {

    var radioAcceptTerm = document.querySelectorAll("input[type=checkbox]");

    if (radioAcceptTerm[0].checked === true) {
        return true;
    } else {
        return false;
    }
}
async function ValidateOTP(dummyID, refNo, otpMsg) {

    //var resultConfirmOTP = ConfirmPersonalOTP(dummyID, refNo, otpMsg);
    let resultConfirmOTP = await ConfirmPersonalOtpAsync(dummyID, refNo, otpMsg);

    if (resultConfirmOTP != "" && resultConfirmOTP != "undefined") {
        console.log("confirm Status is : " + resultConfirmOTP);

        var bufferObj = JSON.parse(resultConfirmOTP);
        if (bufferObj.RESULT_OBJ.isSuccess === true) {

            console.log("IsSuccess is : " + bufferObj.RESULT_OBJ.isSuccess);
            return true;
        } else {
            return false;
        }
    } return false;

}

// Generate OBJ
function GenerateObject() {
    var ddlPersonal = document.getElementById("ddlTitlePersonal");

    var Obj = {
        BusinessType: '001',
        TitleName: ddlPersonal.value,
        FirstName: document.getElementById("txtFirstName").value,
        LastName: document.getElementById("txtLastName").value,
        MobilePhone: document.getElementById("txtPhone").value,
        Email: document.getElementById("txtEmail").value,
        IdentityID: document.getElementById("txtIDCard").value,
        LaserID: document.getElementById("txtLaserID").value,
        BirthDay: ToGlobalDate(document.getElementById("txtBirthDate").value),
        CreatedBy: "SYSTEM",
        IdentityType: 'IDCARD'

    };

    setCookie("rIDCard", document.getElementById("txtIDCard").value, 3650);

    console.log("Generate FormRegister Object");
    return Obj;
}
function GenerateObjectNDIDConnextDopa(dummyID, uid) {

    var obj = {
        data: {
            citizen_id: document.getElementById("txtIDCard").value,
            firstname: document.getElementById("txtFirstName").value,
            lastname: document.getElementById("txtLastName").value,
            birthday: ToNDIDConnextDate(document.getElementById("txtBirthDate").value),
            laser: document.getElementById("txtLaserID").value
        },
        service: 'DOPACheckCardByLaser',
        ref1: dummyID,
        ref2: uid

    };


    return obj;
}

// Main Action
function AcceptStep1() {

    var isReadTAndC = ValidateAcceptConsent();
    if (isReadTAndC) {
        LocalLog("Step 1 : Validate Is Read Term & Condition : " + isReadTAndC);

        RedirectTo("2");
    } else {
        //swal('แจ้งเตือน', 'ข้อมูลส่วนบุคคลของท่านไม่สอดคล้องกับฐานข้อมูลกรมการปกครอง <br /> กรุณาตรวจสอบ แล้วรองใหม่อีกครั้ง', 'warning');
        swal('แจ้งเตือน', 'กรุณาอ่านเงื่อนไขบริการทั้งหมดก่อนยืนยันรับทราบเงื่อนไข', 'warning');
    }
}

function AcceptStep2() {
    LoaderActive();
    AcceptStep2_ShowLoading().then(() => {
        AcceptStep2_CoreAcceptStep2();
    });

}
function AcceptStep2_ShowLoading() {
    return new Promise((resolve) => {
        setTimeout(() => {

            loader.classList.add("loader--show");
            resolve('true')
        }, 10)
    })
}
async function AcceptStep2_CoreAcceptStep2() {
    // 003 = Error Check Existing
    var isKeyIn = ValidateEnrolmentForm();
    LocalLog("Step 2 : Validate input form : " + isKeyIn);
    //alert('Step 2');
    if (isKeyIn == true) {

        var obj = GenerateObject();
        LocalLog("Step 3 : Generate Enrollment Object : " + JSON.stringify(obj));

        //setTimeout(function () {
        //    console.log("Executed after 1 second");
        //}, 2000);
        //LoaderInActive();
        //swal('แจ้งเตือน', 'ข้อมูลส่วนบุคคลของท่านไม่สอดคล้องกับฐานข้อมูลกรมการปกครอง  กรุณาตรวจสอบข้อมูลของท่าน แล้วลองใหม่อีกครั้ง', 'warning');
        //return false;


        if (obj != null) {
            var objTCGResult = await AcceptStep2_EnrolmentAndVerifyToLG(obj);

            LocalLog("Step 4.10 : Enrollment&Verify Result is : " + objTCGResult);
            if (typeof objTCGResult != 'undefined' && objTCGResult != null) {


                switch (objTCGResult) {

                    case "BYPASS":
                        AcceptStep2_CallBackDopa();
                        break;
                    case "SUCCESS":   // Waiting for dopa callback
                        LocalLog("Step 4.11 : Waiting for NDID Connext Callback ");
                        break;
                    case "001": // Enrollment Error
                        LoaderInActive();
                        swal('แจ้งเตือน', 'ระบบลงทะเบียนขัดข้องกรุณาลองใหม่อีกครั้ง', 'warning').then(function () {
                        });
                        break;
                    case "002": // Verify Error
                        LoaderInActive();
                        swal('แจ้งเตือน', 'ไม่พบข้อมูลของท่าน ในฐานข้อมูล บสย. กรุณาตรวจสอบข้อมูลของท่าน หรือติดต่อ Call Center ', 'warning').then(function () {
                            // redirectToMain();
                        });
                        break;
                    case "003": // NDID connext dopa error
                        LoaderInActive();
                        swal('แจ้งเตือน', 'ข้อมูลบัตรประจำตัวประชาชนไม่ถูกต้อง', 'warning').then(function () {
                            //redirectToMain();
                        });
                        break;
                    /** แก้ไข Case ไม่พบเบอร์โทรศัพท์ มือถือเป็นค่าว่าง  22/10/2567 */
                    case "004" : // No Return Mobile Phone Form API 
                        LoaderInActive();
                        swal("แจ้งเตือน", "ติดต่อ CallCenter เพื่ออัพเดทเบอร์โทรศัพท์", "warning",
                            {
                                className: "boxstyle",
                                buttons:
                                    { New: { text: "กลับสู่หน้าเมนูหลัก", value: "index", visible: true, }, },
                            }).then((value) => {
                                switch (value) {
                                    case "index":
                                        redirectToMain();
                                        break;
                                    default:
                                        redirectToMain();
                                }
                            });
                        break;
                    /** End แก้ไข Case ไม่พบเบอร์โทรศัพท์ มือถือเป็นค่าว่าง  22/10/2567 */
                    default:
                        break;
                }
            } else {
                /* redirectToEnrollmentNotFound();*/
                LoaderInActive();
                swal('แจ้งเตือน', 'ไม่พบข้อมูลของท่าน ในฐานข้อมูล บสย.', 'warning').then(function () {
                    // redirectToMain();
                });
            }
        }
    } else {
        LoaderInActive();
        swal('แจ้งเตือน', 'กรุณากรอกข้อมูลให้ครบถ้วน', 'warning');
    }
}
async function AcceptStep2_EnrolmentAndVerifyToLG(obj) {
    var uid = getCookie("uid");
    var IsCheckDopa = document.getElementById("hddIsCheckDopa").value;
    LocalLog("Step 4.1 Config : uid : " + uid + " | Is Check Dopa : " + IsCheckDopa);

    var bufferResult = EnrollPersonal(obj);
    LocalLog("Step 4.2 Call API enrollment result is : " + bufferResult);

    // alert(bufferResult);

    if (typeof bufferResult != 'undefined' && bufferResult != null && bufferResult != "") {

        var bufferProfile = JSON.parse(bufferResult);
        LocalLog("Step 4.3 Casting EnrollmentObj To Object.");

        if (bufferProfile.RESULT_STATUS == "OK") {
            //var objBuffer = VerifyPersonal(bufferProfile.RESULT_OBJ);
            let objBuffer = await VerifyPersonalAsync(bufferProfile.RESULT_OBJ);

            LocalLog("Step 4.4 Call API Validate To TCG Existing Database. result is : " + objBuffer);

            if (typeof objBuffer != 'undefined' && objBuffer != null) {

                var bufferVerifyProfile = JSON.parse(objBuffer);
                LocalLog("Step 4.5 Casting VerifyObj To Object.");

                if (bufferVerifyProfile.RESULT_STATUS == "OK") {
                   

                    if (IsCheckDopa == '1') {

                        var objDopaDipChip = GenerateObjectNDIDConnextDopa(bufferProfile.RESULT_OBJ, uid);
                        LocalLog("Step 4.6 Generate NDID Connext Dopa service Object is : " + JSON.stringify(objDopaDipChip));

                        var objResultDopaBuffer = VerifyDopaDipchip(objDopaDipChip);
                        LocalLog("Step 4.7 Call API NDID Connext Dopa service. Result is : " + objResultDopaBuffer);

                        if (typeof objResultDopaBuffer != 'undefined' && objResultDopaBuffer != null) {
                            var result = JSON.parse(objResultDopaBuffer);
                            LocalLog("Step 4.8 Casting NDID Connext Dopa service Result To Object.");

                            if (typeof result != 'undefined') {
                                LocalLog("Step 4.9 Initial Personal Phonenumber to next step.");

                                setCookie("SIGNUP_Phonenumber", bufferVerifyProfile.RESULT_OBJ.mobileNumber, 3650);
                                setCookie("SIGNUP_DummyID", result.ref1, 3650);

                                return "SUCCESS";
                            } else {
                                LocalLog("Step 4.8 Casting NDID Connext Dopa service Result To Object. : Error");
                                return "003";
                            }
                        } else {
                            LocalLog("Step 4.7 Call API NDID Connext Dopa service Result To Object. : Error");
                            return "003";
                        }

                    } else {
                        LocalLog("** NDID Connext Dopa Service is disable");
                        LocalLog("Step 4.6 Initial Personal Phonenumber to next step.");

                        setCookie("SIGNUP_Phonenumber", bufferVerifyProfile.RESULT_OBJ.mobileNumber, 3650);
                        setCookie("SIGNUP_DummyID", bufferProfile.RESULT_OBJ, 3650);
                        return "BYPASS";
                    }

                } else {
                    LocalLog("Step 4.5 Casting VerifyObj To Object. : Error");
                    return "002";
                }
            } else {
                LocalLog("Step 4.4  Call API Validate To TCG Existing Database : Error");
                return "002";
            }
            // --//////////////////////////////////////////////////////////////////
        } else {
            LocalLog("Step 4.3 Casting EnrollmentObj To Object. : Error");
            return "001";
        }
    } else {
        LocalLog("Step 4.2 Call API enrollment result is : Error");
        return "001";
    }
}

function AcceptStep2_LandingCallback(type, result, uid) {
    LocalLog("Step 5.1 : NDID Callback Is Landing");
    LocalLog("Step 5.2 : Param > type : " + type + " | result : " + result + " | uid : " + uid);

    if (type == "SIGNUP_01") {
        var curUID = getCookie("uid");

        if (curUID == uid) {
            LocalLog("Step 5.3 : UID matching is success.");
            if (result == "false") {

                AcceptStep2_CallBackDopa();
                LoaderInActive();
            } else {

                LoaderInActive();
                LocalLog("Step 5.4 : NDID Connext Dopa Service result is : false");
                swal("แจ้งเตือน", "ข้อมูลส่วนบุคคลของท่านไม่ถูกต้อง กรุณาต้องสอบ ก่อนลองใหม่อีกครั้ง", "error")
                    .then((value) => {

                    });
            }

        } else {
            LoaderInActive();
            LocalLog("Step 5.3 : UID matching is error.");
            swal("แจ้งเตือน", "การลงทะเบียนเกิดเหตุขัดข้อง กรุณาลองใหม่อีกครั้ง", "error")
                .then((value) => {
                    window.location = host + "/index";
                });
        }
    } else {
        LoaderInActive();
        LocalLog("Step 5.2 : Compare type is error");
        swal("แจ้งเตือน", "การลงทะเบียนเกิดเหตุขัดข้อง กรุณาลองใหม่อีกครั้ง", "error")
            .then((value) => {
                window.location = host + "/index";
            });
    }
}
function AcceptStep2_CallBackDopa() {
    var Phonenumber = getCookie("SIGNUP_Phonenumber");
    var DummyID = getCookie("SIGNUP_DummyID");

    LocalLog("Step 5.5 : Prepare for step 3");
    LocalLog("Step 6 : DummyID is : " + DummyID + " | Phone number is : " + Phonenumber);


    // verify data
    LoaderInActive();
    AcceptStep2_BindingPhoneList(Phonenumber);
    RedirectTo("3");

}
function AcceptStep2_BindingPhoneList(phoneData) {
    var select = document.getElementById("ddlSMSPhoneNumber");
    var phoneList = phoneData.replace(' ', '').replace(/-/g, '').split('และ');

    for (const val of phoneList) {
        var option = document.createElement("option");
        option.value = val;
        option.text = val.charAt(0).toUpperCase() + val.slice(1);
        select.appendChild(option);

        LocalLog("Step 7 : Binding Phone number : " + val);

    }
}

async function AcceptStep3() {

    var uid = getCookie("uid");
    var enrollDummyID = getCookie("SIGNUP_DummyID");
    var otpMsg = document.getElementById("txtOTP").value;
    var refMsg = document.getElementById("ltlReferenceNumber").innerText;
    LocalLog("Step 8 : Config : uid : " + uid + " | dummy id : " + enrollDummyID + " | ref Message : " + refMsg + " | OTP : " + otpMsg);

    //var isValidateOTP = ValidateOTP(enrollDummyID, refMsg, otpMsg);

    let isValidateOTP = await ValidateOTP(enrollDummyID, refMsg, otpMsg);

    LocalLog("Step 9 : Validate OTP result is : " + isValidateOTP);

    if (isValidateOTP) {

        //Check map uid with customerProfile
        //var rawResultVerify = MappingUidWithDummayID(uid, enrollDummyID);
        let rawResultVerify = await MappingUidWithDummyIDAsync(uid, enrollDummyID);
        //let resultUidEnroll = GetUidMapEnrollment(uid);
        let rawResultAsyncUidEnroll = await GetUidMapEnrollmentAsync(uid);
        let resultAsyncUidmEnroll = JSON.parse(rawResultAsyncUidEnroll); 

        //alert(resultAsyncUidmEnroll);

        LocalLog("Step 10 : Map UID with DummyID result is : " + rawResultVerify);

        if (rawResultVerify != "" && typeof rawResultVerify != "undefined" ) {
                    var ResultVerify = JSON.parse(rawResultVerify);

            if (ResultVerify.RESULT_STATUS == "OK" || resultAsyncUidmEnroll.RESULT_STATUS == "OK") {
                        LocalLog("Step 11 : Convert Verify result to JSON is Success");
                        swal("เสร็จสิ้น", "ลงทะเบียนยืนยันตัวตนกับฐานข้อมูล บสย. เสร็จสิ้น", "success").then(function () {
                            redirectToMain();
                        });
                    } else {
                        LocalLog("Step 11 : Convert Verify result to JSON is Error");
                        swal("แจ้งเตือน", "การลงทะเบียนผิดพลาดกรุณาลองใหม่อีกครั้ง", "warning");
                    }
                } else {
                    LocalLog("Step 10 : Map UID with DummyID result is error");
                    swal("แจ้งเตือน", "การลงทะเบียนผิดพลาดกรุณาลองใหม่อีกครั้ง", "warning");
                }
    } else {
        LocalLog("Step 9 : Validate OTP result is error");
        swal("แจ้งเตือน", "รหัส OTP ไม่ถูกต้อง กระณาลองใหม่อีกครั้ง", "warning");
    }
}

//05/05/2515