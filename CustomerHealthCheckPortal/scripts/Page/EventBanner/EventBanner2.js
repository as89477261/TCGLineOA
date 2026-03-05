//event2

//let now2 = new Date();
//let register2 = new Date("2023-05-29T00:00:00");
//let btnRegister2 = document.getElementById("btnRegisterEventBanner2");


//btnRegister2.classList.remove("gradient-gray")
//btnRegister2.classList.remove("gradient-green")
//btnRegister2.classList.add("disabledButton")
//btnRegister2.removeAttribute("value")

//if (now2 < register2) {
//    //alert("can not regiseter")
//    btnRegister2.classList.add("gradient-gray");
//    btnRegister2.classList.add("disabledButton");
//    btnRegister2.setAttribute("value", "รอดิดตามการลงทะเบียน เร็วๆนี้");

//} else {
//    //alert("Registger Open")
//    btnRegister2.classList.add("gradient-blue");
//    btnRegister2.classList.remove("disabledButton");
//    btnRegister2.setAttribute("value", "ลงทะเบียนเข้าร่วมงานสัมมนา...Click");

//};


//// Startup eventDebt
let ObjIdCard = [];
let ObjCustomerProfile = []; 
let ObjEnrollSentOTP = [];
let ObjInsertUidDebt = [];
let ObjFormRegister = [];


//let dummyID = document.getElementById("ContentPlaceHolder1_hddDummyID").value;
//console.log(dummyID);

document.addEventListener("DOMContentLoaded", () => {
    if (document.getElementById("ContentPlaceHolder1_hddDataProfile")) {
        let hddValue = document.getElementById("ContentPlaceHolder1_hddDataProfile").value;
        console.log(hddValue);
        if (hddValue == '1') {
            console.log(document.getElementById("pnlRegisterComplete").style.display);
            document.getElementById("pnlConsent").style.display = "none";
            document.getElementById("pnlRegisterComplete").style.display = "block";
        }
        else {
            document.getElementById("pnlConsent").style.display = "block";
        }
    }
});

function ShowModalCancel() {
    const container1 = document.getElementById("cancelRegister");
    const modalCancel = new bootstrap.Modal(container1);

    modalCancel.show(); 

}

function ShowModal() {
    const container2 = document.getElementById("checkRegisterModal");
    const modalConfirmC2 = new bootstrap.Modal(container2);

    modalConfirmC2.show();
}

function swalCase(show) {
    switch (show) {
        case "1":
            swal('แจ้งเตือน', 'กรอกข้อมูล 13 หลักครับ', 'warning');
            break;
        case "2":
            swal("แจ้งเตือน", "ไม่สามารถตรวจสอบข้อมูลได้", "warning",
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
        case "3":
            swal("ไม่พบสิทธิ์", "ตรวจสอบไม่พบสิทธิ์ในการเข้ารวมมาตรการ หากต้องการอบรมหรือปรึกษา บสย. FA Center คลิ๊ก รับคำปรึกษา", "success",
                {
                    className: "boxstyle",
                    buttons:
                    {
                        New: { text: "รับคำปรึกษา", value: "contactFA", visible: true, },
                        New2: { text: "เสร็จสิ้น", value: "index", visible: true, },
                    },
                }).then((value) => {
                    switch (value) {
                        case "contactFA":
                            redirectToDebt()
                            break;
                        case "index":
                            redirectToMain();
                            break;
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "4":
            swal('แจ้งเตือน', 'กรอกข้อมูลไม่ถูกต้อง', 'warning');
            break;
        case "5":
            swal('แจ้งเตือน', 'เบอร์โทรศัพทไม่สามารถส่ง OTP ได้', 'warning');
            break;
        case "6":
            swal('แจ้งเตือน', 'ท่านกรอกรหัส OTP ไม่ถูกต้อง', 'warning');
            break;
        case "7":
            swal('แจ้งเตือน', 'ไม่สามารถตรวจสอบสิทธิ์ได้ใน ขณะนี้', 'warning')
            break;
        case "8":
            swal('ระบบผิดพลาด', 'ไม่สามารถไปต่อได้', 'warning')
            break
        case "9":
            swal('ระบบผิดพลาด', 'ไม่สามารถลงทะเบียนได้', 'erorr')
            break;
        case "10":
            swal("แจ้งเตือน", "ระบบไม่สามารถส่ง OTP ได้ในขณะนี้ รบกวนทำรายการในภายหลัง", "warning",
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
        default:
            break;
    }
}

function RedirectTo(step) {

    let pnlConsent = document.getElementById("pnlConsent");
    let pnlFillIdCard = document.getElementById("pnlFillIdCard");
    let pnlSignUpForm = document.getElementById("pnlSignUpForm");
    let pnlConfirmOTP = document.getElementById("pnlConfirmOTP")
    let pnlbackStep = document.getElementById("backStep")
    let pnlRegisterComplete = document.getElementById("pnlRegisterComplete")

    switch (step) {
        case "1":
            pnlConsent.style.display = "block";
            pnlFillIdCard.style.display = "none";
            pnlSignUpForm.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlRegisterComplete.display = "none";
            break;
        case "2":
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "block";
            pnlSignUpForm.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlRegisterComplete.display = "none";
            break;
        case "3":
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlSignUpForm.style.display = "block";
            pnlConfirmOTP.style.display = "none";
            pnlbackStep.style.display = "none";
            pnlRegisterComplete.display = "none";
            break;
        case "4":
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlSignUpForm.style.display = "none";
            pnlConfirmOTP.style.display = "block";
            pnlbackStep.style.display = "none";
            pnlRegisterComplete.display = "none";
            break;
        case "5":
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlSignUpForm.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlbackStep.style.display = "none";
            pnlRegisterComplete.display = "block";
            break; 
        default:
            break;
    }
}

//step 1

function AcceptStep1() {
    let isReadTAndC = ValidateAcceptConsent();
    if (isReadTAndC) {
        LocalLog("Step 1 : Validate Is Read Term & Condition : " + isReadTAndC);
        RedirectTo("2");
    } else {
        swal('แจ้งเตือน', 'กรุณาอ่านเงื่อนไขบริการทั้งหมดก่อนยืนยันรับทราบเงื่อนไข', 'warning');
    }
}

function ValidateAcceptConsent() {
    let radioAcceptTerm = document.querySelectorAll("input[type=checkbox]");

    if (radioAcceptTerm[0].checked === true) {
        return true;
    } else {
        return false;
    }
}

//step 2
function ValidateIdentityField() {

    let result = true;
    let txtIdentityId = document.getElementById("txtIdentityId");

    if (txtIdentityId.value.length < 13 || txtIdentityId.value.length > 13) {
        result = false;
        return swalCase("1");
    }
    if (txtIdentityId.value.length == 13) {
        result = true;
    }
    console.log("Step 2.1 Validation Field is : " + result);

    return (result);
}

function GenerateIdentityFieldValue() {

    let uid = getCookie("uid");
    let eventCode = '001';
    let eventName = 'มาตรการพักชำระหนี้ ปี 66';
    let txtIdentityId = document.getElementById("txtIdentityId");
    let idCardAccept = "";
    let status = true;
    let isAcceptConsent = true;
    let isDebtDCSEvent = null;
    let isDebtDCS_Id = null;
    let dummyID = null;
    let isRegisterSuccess = false;

    if (txtIdentityId != null && txtIdentityId != 'undefined' && txtIdentityId != '') {
        idCardAccept = txtIdentityId.value;
    }
    ObjIdCard = {
        Uid: uid,
        EventCode: eventCode,
        EventName: eventName,
        IdentityCard: idCardAccept,
        Status: status,
        IsAcceptConsent: isAcceptConsent,
        IsDebtDCSEvent: isDebtDCSEvent,
        IsDebtDCS_Id: isDebtDCS_Id,
        DummyID: dummyID,
        IsRegisterSuccess : isRegisterSuccess        
    };
    console.log("Step 2.2 Generate Identity Filed Object = " + ObjIdCard.IdentityCard);
    return ObjIdCard;
}

function ValidateIndentityFieldValue() {

    let result = false
    let identityCard = ObjIdCard.IdentityCard;

    if (identityCard != '')
    {
        result = true;
    }
    console.log("Step 2.3 ValidateIndentityFieldValue : " + result);
    return result; 
}

function ValidateConditionDebt() {

    let result = false;
    console.log(ObjInsertUidDebt);
    console.log(ObjInsertUidDebt.RESULT_OBJ.Table[0].IdentityCard);

    let idCard = ObjInsertUidDebt.RESULT_OBJ.Table[0].IdentityCard;
    //let idCardDebt = ObjInsertUidDebt.RESULT_OBJ.Table[0].IsDebtDCS_Id; <<< Use This Fix
    let idCardDebt = ObjInsertUidDebt.RESULT_OBJ.Table[0].IdCard; //function > CheckID Table.....from stored
    let isDebtDCSEvent = ObjInsertUidDebt.RESULT_OBJ.Table[0].IsDebtDCSEvent
    console.log(isDebtDCSEvent)

    if (isDebtDCSEvent != null && isDebtDCSEvent != '' && isDebtDCSEvent == '1')
    {
        if (idCard != null && idCard != 'undefined')
        {
            if (idCardDebt != null && idCardDebt != 'undefined')
            {
                if (idCard == idCardDebt) {
                    result = true;
                }
                else {
                    result = false;
                }
            }
        }
    }
    console.log("Step 2.5 isDebtCondition : " + result);
    return result;
}

function AcceptStep2() {

    let isKeyIn = ValidateIdentityField();
    let ObjField = GenerateIdentityFieldValue();
    let isHaveIdentityValues = ValidateIndentityFieldValue();
    let resultInsertUIDMapDebtEvent = InsertUIDMapDebtEvent(ObjField);
    //alert(resultInsertUIDMapDebtEvent);
    console.log("Step 2.4 InsertLog : Complete");
    ObjInsertUidDebt = JSON.parse(resultInsertUIDMapDebtEvent)


    let isConditionDebt = ValidateConditionDebt();

    if (isKeyIn == true)
    {
        if (isHaveIdentityValues == true)
        {

            if (ObjInsertUidDebt != null && ObjInsertUidDebt != undefined && ObjInsertUidDebt.RESULT_STATUS == 'OK')
            {
                
                if (isConditionDebt == true)
                {
                    RedirectTo("3");
                }
                else { swalCase("3"); }

            } else { swalCase("7"); }
        }
        else { swalCase("2"); }
    }
    else { swalCase("1"); }
}

//step 3
function ValidateDebtForm() {

    let result = true;
    let ddlTitlePersonal = document.getElementById("ddlTitlePersonal");
    let txtFirstName = document.getElementById("txtFirstName");
    let txtLastName = document.getElementById("txtLastName");
    let ddlBusinessPosition = document.getElementById("ddlBusinessPosition");
    let txtBusinessName = document.getElementById("txtBusinessName");
    let ddlProvince = document.getElementById("ddlProvince");
    let txtMobilePhone = document.getElementById("txtMobilePhone");
    let ddlIncome = document.getElementById("ddlIncome");

    if (ddlTitlePersonal.value === "") {
        ddlTitle.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlTitlePersonal.style.border = "";
    }

    if (txtFirstName.value === "") {
        txtFirstName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtFirstName.style.border = "";
    }

    if (txtLastName.value === "") {
        txtLastName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtLastName.style.border = "";
    }

    if (txtBusinessName.value === "") {
        txtBusinessName.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        txtBusinessName.style.border = "";
    }
    if (ddlBusinessPosition.value === "") {
        ddlBusinessPosition.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlBusinessPosition.style.border = "";
    }
    if (ddlProvince.value === "") {
        ddlProvince.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlProvince.style.border = "";
    }
    if (txtMobilePhone.value === "") {
        txtMobilePhone.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        if (txtMobilePhone.value.length === 10) {
            txtMobilePhone.style.border = "";
        } else {
            txtMobilePhone.style.border = "1px solid #CF0A0A";
            result = false;
        }
    }
    if (ddlIncome.value === "") {
        ddlIncome.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        ddlIncome.style.border = "";
    }

    LocalLog("3.1 isValidateDataKey : " + result);
    GenerateDebtFromProfileObject();
    GenerateFormRegisterObject();
    return result;
}

function GenerateFormRegisterObject() {

    //let cusIDNumber = parseInt(resultInsertCustomerProfile.replace('"', ''));
    //let packageID = getCookie("debtPID");
    let incomeData = document.getElementById('ddlIncome').value;
    let uid = ObjIdCard.Uid;

    ObjFormRegister = {
        UID: uid,
        ApplicationId: '2',
//        CustomerProfileId: cusIDNumber,
        ChannelId: '2',
        CurrentStatusId: '80',
        CreateBy: '9991',
        FA_Ref: ObjIdCard.IdentityCard,
        Dept_Recon_ObjectId: 3,
        Dept_Recon_Money: incomeData
    };
    console.log("Generate FormRegister Object");
    return ObjFormRegister;

}

function GenFormatServiceObject() {
    let TitleName = document.getElementById("ddlTitlePersonal").value;
    switch (TitleName) {
        case "001":
            return 1;
        case "002":
            return 1;
        case "003":
            return 1;
        case "004":
            return 2;
        case "005":
            return 2;
        case "006":
            return 2;
        default:
            return 1;
    }
}

function GenerateDebtFromProfileObject() {



    ObjCustomerProfile = {
        TitleName: document.getElementById("ddlTitlePersonal").value,
        UserFirstName: document.getElementById("txtFirstName").value,
        UserLastName: document.getElementById("txtLastName").value,
        CompanyName: document.getElementById("txtBusinessName").value,
        PositionInCompany: document.getElementById("ddlBusinessPosition").value,
        IdCard: ObjIdCard.IdentityCard,
        Province:document.getElementById("ddlProvince").value,
        Mobile: document.getElementById("txtMobilePhone").value,
        TypeCompany: 4,
        FormatService: GenFormatServiceObject(),
        TypeProductOrService: '-',
        CreateBy: '9991',
        Line_UserId: ObjIdCard.Uid,
    };

    console.log("3.2 Generate CustomerProfile Object");
    console.log(ObjCustomerProfile);

    return ObjCustomerProfile;
}

function ValidateMobilePhone() {
    let result = false;
    let txtPhoneOTP = ObjCustomerProfile.Mobile
    let substring = txtPhoneOTP.substring(0, 1);
    let txtMobilePhoneSentOTP = document.getElementById("txtMobilePhoneSentOTP").value; 

    if (txtPhoneOTP != '' && txtPhoneOTP != "undefined" && txtPhoneOTP != null && substring == "0") {
        txtPhoneOTP = txtMobilePhoneSentOTP; 
        result = true;
    }
    else {
        result = false; 
    }

    console.log("3.3 isValidateMobilePhone : " + result);

    return result;
}

function GenerateDebtFromEnrollment() {
    let ddlPersonal = document.getElementById("ddlTitlePersonal");

    let Obj = {
        BusinessType: '001',
        TitleName: ddlPersonal.value,
        FirstName: document.getElementById("txtFirstName").value,
        LastName: document.getElementById("txtLastName").value,
        MobilePhone: document.getElementById("txtMobilePhone").value,
        Email: null,
        IdentityID: ObjIdCard.IdentityCard,
        LaserID: 'TCG1234567',
        BirthDay: null,
        CreatedBy: "SYSTEM",
        IdentityType: 'IDCARD'

    };

    setCookie("debtIDCard", ObjIdCard.identityCard, 3650);

    LocalLog("Step 3.4 : Generate Enrollment Object : " + JSON.stringify(obj));
    return Obj;
}

function MapMobilePhone() {
    let txtMobilePhoneOTP = ObjCustomerProfile.Mobile;
    let txtMobilePhoneSentOTP = document.getElementById("txtMobilePhoneSentOTP");

    if (txtMobilePhoneSentOTP.value = txtMobilePhoneOTP) {
        txtMobilePhoneSentOTP = txtMobilePhoneOTP
        console.log("3.xx MapMobilePhoneNumber : " + txtMobilePhoneSentOTP)
        return true;
    }
    return false;
}

function EnrollmentData(obj)
{
    let bufferResult = EnrollPersonal(obj);
    //alert(bufferResult);
    console.log(bufferResult);

    if (typeof bufferResult != 'undefined' && bufferResult != null && bufferResult != "" && bufferResult != undefined) {
        return bufferResult; 
        LocalLog("Step 1EnrollmentData Casting EnrollmentObj To Object.");
    } else {
        LocalLog("Step 4.3 Casting EnrollmentObj To Object. : Error");
        return "001";
    }
}

function SendEmailToConSult(obj)
{
    let bufferResult = SendEmailToConsult(obj)

    console.log(bufferResult); 

    if (typeof bufferResult != 'undefined' && bufferResult != null && bufferResult != "" && bufferResult != undefined) {
        return bufferResult;
        LocalLog("Step 1EnrollmentData Casting EnrollmentObj To Object.");
    }
    return bufferResult; 
        
}

function AcceptStep3() {
    LoaderActive();
    ShowLoading().then(() => {
        ConfirmStep3();
    });
}

function ConfirmStep3() {

    let isValidateDataKey = ValidateDebtForm();
    let isValidateMobilePhone = ValidateMobilePhone();
   
    //console.log("3.1 ValidateField");
    //console.log(isValidateDataKey);
    //console.log("3.2 Generate CustomerProfile Object");
    //console.log(resultObjProfile);
    //console.log("3.3 ValidateMobilePhone");
    //console.log(isValidateMobilePhone);

    if (isValidateDataKey == true) {
        

        if (isValidateMobilePhone == true) {

            let obj = GenerateDebtFromEnrollment();
            console.log("AcceptStep3 : GenerateDebtFromEnrollment Success")
            if (obj != null)
            {
                let objResult = EnrollmentData(obj);

                console.log("CALL API" + objResult); 

                ObjEnrollSentOTP = JSON.parse(objResult);
                MapMobilePhone();
                console.log(ObjEnrollSentOTP.RESULT_OBJ); 
                if (ObjEnrollSentOTP != 'undefined' && ObjEnrollSentOTP != null)
                {
                    LocalLog("AcceptStep3 : Enrollment&Verify Result is : " + ObjEnrollSentOTP);
                    RedirectTo("4");
                    LoaderInActive(); 

                } else { LoaderInActive(); swalCase("8"); }
            } else { LoaderInActive(); swalCase("7"); }           
        } else {
            LoaderInActive(); swalCase("5");
        }
    } else {
        LoaderInActive(); swalCase("4")
    }
}

//step 4
function AcceptStep4() {
    LoaderActive();
    ShowLoading().then(() => {

        let validateOTP = ValidateRefferenOTP();
        console.log("Validate OTP is :" + validateOTP);
        if (validateOTP == true) {
            KeepDataAndGoFinish();
            LoaderInActive();
            LocalLog("Finish Progess Register");
            swal("เสร็จสิ้น", "ลงทะเบียน มาตรการพักชำระหนี้ สำเร็จ รอเจ้าหน้าที่ติดต่อกลับ", "success").then(function () {
                redirectToMain();
            });
        }
        else {
            LocalLog("end Progess ValidateOTPRef");
            LoaderInActive();
            swalCase("6");
        }

    });

    
}

function SendOTP() {
    LoaderActive();

    ShowLoading().then(() => {
        SendOTP_CoreSendOTP();
    });
    //document.getElementById("pnlKeyInOTP").style.display = "block";   // TEST Close send OTP
}

function ShowLoading() {
    return new Promise((resolve) => {
        setTimeout(() => {
            loader.classList.add("loader--show");
            resolve('true')
        }, 10)
    })
}           

async function SendOTP_CoreSendOTP() {

    DisableAndCounting("disable");
    let btnSendOTP = document.getElementById("btnSendOTP");
    let txtMobilePhoneSentOTP = document.getElementById("txtMobilePhoneSentOTP").value;
    let enrollDummyID = ObjEnrollSentOTP.RESULT_OBJ;
    let phoneNumber = txtMobilePhoneSentOTP;

    console.log(enrollDummyID)
    console.log("Phone Number is : " + phoneNumber); 

    if (phoneNumber != "" && phoneNumber != 'undefined')
    {
        let resultSentOTP = await CallServiceSendOTP(enrollDummyID, phoneNumber);

        if (resultSentOTP != "" && resultSentOTP != 'undefined' && resultSentOTP != null && resultSentOTP != undefined)
        {

            //let resultCheckSent = await GenResultCheckSentOTP(enrollDummyID);

            //console.log("resultCheckSent : " + resultCheckSent)

            btnSendOTP.classList.add("btn-disable");
            sendOTPObj = JSON.parse(resultSentOTP);
            document.getElementById("pnlKeyInOTP").style.display = "block";
            document.getElementById("ltlReferenceNumber").innerText = sendOTPObj.RESULT_OBJ;
            LoaderInActive();
        }
        else {         
            swalCase("10"); 
            LoaderInActive();
        }
    } else {
        btnSendOTP.classList.remove("btn-disable");
        btnSendOTP.innerText = "ขอรหัส OTP";
        LoaderInActive();
        swal('แจ้งเตือน', 'กรุณาลองอีกครั้ง', 'warning');
    }

    console.log("4.2 Get OTP  :"); 
}

async function CallServiceSendOTP(enrollDummyID, phoneNumber) {

    if (enrollDummyID != "" && phoneNumber != "") {

        let result = await SendPersonalOTP(enrollDummyID, phoneNumber);
        console.log(result);
        return result;
    }

}
function DisableAndCounting(action) {

    console.log("Disable button and send OTP");

    let limitCounting = 3;
    let btnSendOTP = document.getElementById("btnSendOTP");
    //let btnBackStep4 = document.getElementById("btnBackStep4");


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

    //TIME_SETTING
    let minute = 4;
    let sec = 59;
    let itemStartCoolDown = new Date();
    timeCoolDownStart = itemStartCoolDown;
    console.log("StartCoolDown");
    console.log(timeCoolDownStart);

    let interval = setInterval(function () {
        document.getElementById("btnSendOTP").style.color = "white";
        document.getElementById("btnSendOTP").innerHTML = "ส่งได้อีกครั้งใน " + minute + ":" + sec + " นาที";

        sec--;

        if (sec == 0) {
            minute--;

            if (minute >= 0) {
                sec = 59;

            } else {
                let itemEndCoolDown = new Date();

                clearInterval(interval);
                timeCoolDownEnd = itemEndCoolDown;
                console.log("EndCoolDown");
                console.log(timeCoolDownEnd);
                DisableAndCounting("enable");
                return;
            }
        }
    }, 1000);
}

function ValidateRefferenOTP() {

    let enrollDummyID = ObjEnrollSentOTP.RESULT_OBJ;
    let otpMsg = document.getElementById("txtOTP").value;
    console.log(otpMsg)
    if (otpMsg == '')
    {
        return false;
    }
    let refMsg = document.getElementById("ltlReferenceNumber").innerText;
    let isValidateOTP = ValidateOTP(enrollDummyID, refMsg, otpMsg);

    if (isValidateOTP == true) {
        return true;
    }
    else {
        return false;
    }

    //return true; //  // TEST Close send OTP

}

function ValidateOTP(enrollDummyID, refNo, otpMsg) {
    let resultConfirmOTP = ConfirmPersonalOTP(enrollDummyID, refNo, otpMsg);

    if (resultConfirmOTP != "" && resultConfirmOTP != "undefined") {
        console.log("confirm Status is : " + resultConfirmOTP);

        let bufferObj = JSON.parse(resultConfirmOTP);
        if (bufferObj.RESULT_OBJ.isSuccess === true) {

            console.log("IsSuccess is : " + bufferObj.RESULT_OBJ.isSuccess);
            return true;
        } else {
            return false;
        }
    } return false;

}

function DisableConfirmRegister(action) {

    console.log("Disable button and Create Transaction");

    let btnConfirmRegister = document.getElementById("btnConfirmRegister");
    //let btnBackStep4 = document.getElementById("btnBackStep4");


    if (action == "disable") {
        btnConfirmRegister.classList.add("btn-disable");
        btnConfirmRegister.classList.remove("gradient-blue");
    } else {
        btnConfirmRegister.classList.remove("btn-disable");
        btnConfirmRegister.classList.add("gradient-blue");
    }
}

function KeepDataAndGoFinish() {

        DisableConfirmRegister("disable");

        let resultGenProfileObject = GenerateDebtFromProfileObject();
        LocalLog("KeepDataAndGoFinish Generate DebtFromProfile Object");
        console.log(resultGenProfileObject);
        let resultInsertCustomerProfile = InsertCustomerProfile(resultGenProfileObject);
        console.log(resultInsertCustomerProfile);

        if (resultInsertCustomerProfile !== "" && resultInsertCustomerProfile != null) {

            LocalLog("ID FA Customer Profile is : " + resultInsertCustomerProfile);


            let resultGenFromObject = GenerateFromDebtCompromise(resultInsertCustomerProfile);
            console.log(resultGenFromObject);
            LocalLog("KeepDataAndGoFinish Gen DebtFormRegister Object");
            console.log(ObjFormRegister);

            let obj = GenerateFromDebtTrans();

            if (obj != null && obj.Uid == ObjFormRegister.UID) {
                let resultFromDebtCompromise = InsertFormFARegisterCompromise(ObjFormRegister, obj.Id, obj.DummyID);
                console.log(resultFromDebtCompromise);

                let bufferObj = JSON.parse(resultFromDebtCompromise);
                if (bufferObj.RESULT_OBJ != null && bufferObj != undefined) {

                    let objSend = GenerateFromSendEmail(bufferObj.RESULT_OBJ, ObjIdCard.IdentityCard);

                    let resultSendEmail = SendEmailToConSult(objSend)
                    console.log(resultSendEmail);
                }
            }
            DisableConfirmRegister("enable");

        }
        else {
            DisableConfirmRegister("enable");
            LoaderInActive();
            swalCase("9");
        }
}

function GenerateFromDebtCompromise(resultInsertCustomerProfile) {
    console.log(resultInsertCustomerProfile);
    let cusIDNumber = parseInt(resultInsertCustomerProfile.replace('"', '')); 
    let packageID = 1;
    let incomeData = document.getElementById('ddlIncome').value;
    let resultFromDebtTrans = GenerateFromDebtTrans();
    let uid = ObjInsertUidDebt.RESULT_OBJ.Table[0].Uid;
    console.log(resultFromDebtTrans);

    ObjFormRegister = {

        ApplicationId : '2',
        CustomerProfileId: cusIDNumber,
        ChannelId: '2',
        CurrentStatusId: '80',
        CreateBy: '9991',
        FA_Ref: ObjIdCard.IdentityCard,
        Dept_Recon_ObjectId: packageID,
        Dept_Recon_Money: incomeData,
        UID: uid
    }
    console.log("GenerateFromDebtCompromise Object");
    return ObjFormRegister;

}

function GenerateFromDebtTrans() {

    let obj = ObjInsertUidDebt.RESULT_OBJ.Table[0];
    obj.DummyID = ObjEnrollSentOTP.RESULT_OBJ;

    let objFrom = {
        Id: obj.Id,
        DummyID: obj.DummyID,
        Uid: obj.Uid
    };

    console.log(objFrom);
    return objFrom;
}

function GenerateFromSendEmail(tranid, cardID) {
    //let tranid = '6083'
    //let cardID =  ObjIdCard.IdentityCard

    let objSend = {
        Id: tranid,
        Ref1: cardID,
        Ref2: ''
    };
    console.log(objSend)
    return objSend;
}





