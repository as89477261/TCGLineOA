
let profileRegister = document.getElementById("ContentPlaceHolder1_hddprofileRegister").value
let profileConsultFA = document.getElementById("ContentPlaceHolder1_hddIsConsultFASuccess").value
let profileConsultClinic = document.getElementById("ContentPlaceHolder1_hddIsConsultClinicSuccess").value

//profileRegister = "0"; // Defualt 0  (ยังไม่เคยลงทะเบียน = 0 เคยลงทะเบียน =1)
console.log("profileRegister : " + profileRegister);

//profileConsultFA = "0"; // Defualt 0  (ยังไม่เคยลงทะเบียน = 0 เคยลงทะเบียน =1)
console.log("profileConsultFA : " + profileConsultFA);

//profileConsultClinic = "0"; // Defualt 0  (ยังไม่เคยลงทะเบียน = 0 เคยลงทะเบียน =1)
console.log("profileConsultClinic : " + profileConsultClinic);


let TransID = document.getElementById("ContentPlaceHolder1_hddtransDummyID").value;
console.log("TransID : " + TransID);

let acceptCondition = document.getElementById("ContentPlaceHolder1_hddacceptCondition").value;
console.log("tigger value consent : " + acceptCondition);

let iElement = document.querySelector('#statusbar8 i');

let timeCoolDownStart = new Date();
let timeCoolDownEnd = new Date();

/**
 * 
 * @param {"statusBar1"|"statusBar2"|"statusBar3"|"statusBar4"|"statusBar5"|"statusBar6"|"statusBar7"} statusbarID
 * @param {"PASS" | "REJECT" | "WAIT" | "PROCESS"} textStatus 
 * @param {"PASS" | "REJECT" | "WAIT" | "PROCESS"} colorStatus
 */
function AddStatus(
    statusbarID, textStatus
)
{
    let statusBar = document.getElementById(statusbarID);
    let spanElement = document.querySelector(`#${statusbarID} span`);

    while (spanElement.firstChild) {
        // ลบ child element ทุกตัว
        spanElement.removeChild(spanElement.firstChild);
    }

    //let textNode = document.getElementById(`${statusbarID}-span`)
    //if (!textNode) {
    let textNode = document.createTextNode(textStatus)
        //textNode.setAttribute("id", `${statusbarID}-span`)
    //}

    /** @type {"gray" | "green" | "red" | "yellow"} */
    let spanColor = "gray"


    statusBar.querySelector("span").appendChild(textNode);
    spanElement.classList.remove("gradient-gray");
    spanElement.classList.remove("gradient-red");
    spanElement.classList.remove("gradient-green");
    spanElement.classList.remove("gradient-yellow");

    switch (textStatus) {
        case "PASS":
            spanColor = "green"
            break;
        case "REJECT":
            spanColor = "red"
            break;
        case "WAIT":
            spanColor = "gray"
            break;
        case "PROCESS":
            spanColor = "yellow"
            break;
    }
    spanElement.classList.add(`gradient-${spanColor}`);
}

function AddStatusIcon(statusbarID, colorStatus)
{
    let statusBar = document.getElementById(statusbarID);

    /** 
     * @type {"gray" | "green" | "red" | "yellow"}
     */

    let spanColor = "gray"

    /** 
     * @type {"bi-check2-circle" | "bi-clipboard-x" | "bi-hourglass"}
     */
    let icon = "bi-check2-circle"

    statusBar.querySelector("span").classList.remove("color-gray-light");;
    statusBar.querySelector("span").classList.remove("color-red-light");
    statusBar.querySelector("span").classList.remove("color-green-light");
    statusBar.querySelector("span").classList.remove("color-yellow-light");
    statusBar.querySelector("span").classList.remove("bi-check2-circle");
    statusBar.querySelector("span").classList.remove("bi-clipboard-x");
    statusBar.querySelector("span").classList.remove("bi-hourglass");
    statusBar.querySelector("span").classList.remove("bi-x-circle");

    switch (colorStatus) {
        case "PASS":
            spanColor = "green"
            icon = "bi-check2-circle"
            break;
        case "REJECT":
            spanColor = "red"
            icon = "bi-x-circle"
            break;
        case "WAIT":
            spanColor = "gray"
            icon = "bi-check2-circle"
            break;
        case "PROCESS":
            spanColor = "gray"
            icon = "bi-hourglass"
            break;
        case "PROCESSREJECT" : 
            spanColor = "yellow"
            icon = "bi-x-circle"
            break;
    }
    statusBar.querySelector("span").classList.add(`color-${spanColor}-light`);
    statusBar.querySelector("span").classList.add(`${icon}`);
}

function AddStatusColor(
    statusbarID, colorStatus
) {
    let statusBar = document.getElementById(statusbarID);

    /** 
     * @type {"gray" | "green" | "red" | "yellow"}
     */
    let spanColor = "gray"

    statusBar.querySelector("span").classList.remove("color-gray-light");;
    statusBar.querySelector("span").classList.remove("color-red-light");
    statusBar.querySelector("span").classList.remove("color-green-light");
    statusBar.querySelector("span").classList.remove("color-yellow-light");
    statusBar.querySelector("span").classList.remove("bi-check2-circle");
    statusBar.querySelector("span").classList.remove("bi-clipboard-x");
    statusBar.querySelector("span").classList.remove("bi-hourglass");
    statusBar.querySelector("span").classList.remove("bi-x-circle");

    switch (colorStatus) {
        case "PASS":
            spanColor = "green"
            break;
        case "REJECT":
            spanColor = "red"
            break;
        case "WAIT":
            spanColor = "gray"
            break;
        case "PROCESS":
            spanColor = "yellow"
            break;
    }
    statusBar.querySelector("span").classList.add(`color-${spanColor}-light`);
    statusBar.querySelector("span").classList.add("bi-check2-circle");
}

let objUidProfile = [];
let objUidMapDIPROM = [];
let objtransDIPROM = [];
let ojbFromEnroll = [];
let objSendOTP = [];
let objSuccessTrans = [];
let objSuccessReigster = []; 
let objGetSuccessReigster = [];
let objConfirmOTPResult = [];
let objResultCheckSent = [];
let objCusProfileFA = [];
let objCusTransFA = [];
let objGetImport= [];

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

function ShowModalConsult() {

    const container3 = document.getElementById("confirmConsult");
    const modalConfirm3 = new bootstrap.Modal(container3);
    const profileConsultFA = document.getElementById("ContentPlaceHolder1_hddIsConsultFASuccess").value

    if (profileConsultFA == "1") {
        swalCaseDIPROM("12"); 
    }
    else {
        modalConfirm3.show(); 
    }
}

function ShowModalConsultClinic() {
    const container4 = document.getElementById("confirmConsultClinic");
    const modalConfirm4 = new bootstrap.Modal(container4);
    const profileConsultClinic = document.getElementById("ContentPlaceHolder1_hddIsConsultClinicSuccess").value

    if (profileConsultClinic == "1") {
        swalCaseDIPROM("12");
    }
    else {
        modalConfirm4.show();
    }
}

function ProfileRegisterStatus() {

    let uid = getCookie("uid")
    let eventCode = '001'

    let buffer = GetRegisterUIDMapDIPROM(uid, eventCode);

    let bufferResult = JSON.parse(buffer);
    console.log(bufferResult);

    // Check ลงทะเบียนใหม่ได้หรือไม่ 
    let identityid = bufferResult.RESULT_OBJ[0].IdentityCard;
    let partnerKey = bufferResult.RESULT_OBJ[0].IsPartnerKey;
    console.log(identityid);
    console.log(partnerKey);

    let bufferimport = GetImportRequest(uid, identityid);
    let bufferImportResult = JSON.parse(bufferimport);

    console.log(bufferImportResult);
/*    let checkID = bufferImportResult.RESULT_OBJ[0].ID;*/

    if (bufferResult.RESULT_STATUS = "OK" && bufferImportResult.RESULT_STATUS == "OK") {

        objGetSuccessReigster = {
            Uid: bufferResult.RESULT_OBJ[0].Uid,
            IsRegisterSuccess: bufferResult.RESULT_OBJ[0].IsRegisterSuccess,
            Req_CreditStatus: bufferResult.RESULT_OBJ[0].Req_CreditStatus,
            Req_CreditStatus_Des: bufferResult.RESULT_OBJ[0].Req_CreditStatus_Des,
            Req_HealthCheckStatus: bufferResult.RESULT_OBJ[0].Req_HealthCheckStatus,
            Req_HealthCheckStatus_Des: bufferResult.RESULT_OBJ[0].Req_HealthCheckStatus_Des,
            Req_AMLStatus: bufferResult.RESULT_OBJ[0].Req_AMLStatus,
            Req_AMLStatus_Des: bufferResult.RESULT_OBJ[0].Req_AMLStatus_Des,
            Req_IsRegisterSuccess: bufferResult.RESULT_OBJ[0].Req_IsRegisterSuccessJoin,
            Req_IsRegisterSuccess_Desc: bufferResult.RESULT_OBJ[0].Req_IsRegisterSuccess_Desc,
            Req_SendEmailStatus: bufferResult.RESULT_OBJ[0].Req_SendEmailStatus,
            Req_SendEmailStatus_Des: bufferResult.RESULT_OBJ[0].Req_SendEmailStatus_Des,
            Req_IsApprove: bufferResult.RESULT_OBJ[0].Req_IsApprove,
            Req_IsApprove_Desc: bufferResult.RESULT_OBJ[0].Req_IsApprove_Desc
        }
        console.log(objGetSuccessReigster);

        objGetImport = {
            ID: bufferImportResult.RESULT_OBJ[0].ID,
            ID_Check: bufferImportResult.RESULT_OBJ[0].ID_Check
        }
        console.log(objGetImport); 

        return true;
    }
    return false;

}

function ValidateDataCheck() {

    console.log(objGetSuccessReigster.Uid); 

    if (objGetSuccessReigster.Uid != null, objGetSuccessReigster.Uid != undefined) {
        return true;
    }
    else return false; 
}
    
async function GetRegisterUIDMapDipromAsync(uid, eventCode) {
    try {
        if (uid != "" && uid != null) {
            let result = await InterfaceGetRegisterUIDMapDipromAsync(uid, eventCode);
            console.log(result);
            return (result);
        }
    } catch (error) {
        throw error; 
    }

}

document.addEventListener("DOMContentLoaded", () => {
    if (profileRegister == '1') {
        /*เพิ่ม API 1 เส้น*/
        // GET DATA DIPROM TO PREIVEW

        var result = ProfileRegisterStatus();

        //var result = ProfileRegisterStatus();

        if (result == true) {

            GenPreviewStatusRegisterSuccess();

            if (objGetImport.ID_Check == "OpenNewRegister") {
                return redirectTO("1");
            }

            if (objGetImport.ID_Check == "AutoNewRegister") {
                let result = ProfileRegisterStatus();
                if (result == true) {
                    GenPreviewStatusRegisterSuccess();
                    if (objGetSuccessReigster.Req_CreditStatus == 3) {
                        return redirectTO("7");
                    }
                    if (objGetSuccessReigster.Req_IsApprove == 2) {
                        return redirectTO("8");
                    }
                }
                else return redirectTO("6");
            }

            if (objGetSuccessReigster.Req_CreditStatus == 3 )
            {
                return redirectTO("7");
            }
            if (objGetSuccessReigster.Req_IsApprove == 2) {
                return redirectTO("8");
            }
            else  return redirectTO("6");
        }
        else  return redirectToMain();
    }
    else
        redirectTO("1");
})

function swalCaseDIPROM(show) {
    switch (show) {
        case "1":
            swal("แจ้งเตือน", "ไม่สามารถลงทะเบียนได้ในขณะนี้", "warning",
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
        case "2":
            swal("แจ้งเตือน", "ระบบมีปัญหาในขั้นตอน 1", "warning",)
            break;
        case "3":
            swal("แจ้งเตือน", "กรอกเลขบัตรประชาชนไม่ถูกต้อง", "warning",)
            break;
        case "4":
            swal("ตรวจสอบ", "ไม่พบประวัติการลงทะเบียนกับกรมส่งเสริมอุตสาหกรรม", "success",
                {
                    className: "boxstyle",
                    buttons:
                    {
                        //consultPage: { text: "รับคำปรึกษา", value: "contactFA", visible: true, },
                        default: { text: "เสร็จสิ้น", value: "index", visible: true, },
                    },
                }).then((value) => {
                    switch (value) {
                        case "contactFA":
                            redirectToConsultFACenter();
                            break;
                        case "index":
                            redirectToMain();
                            break;
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "5":
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
        case "6":
            swal('แจ้งเตือน', 'ตรวจสอบหมายเลข OTP ก่อนส่งรหัสอีกครั้ง', 'warning');
            break;
        case "7":
            swal('แจ้งเตือน', 'หมายเลขนี้มีผู้ใช้งานในการลงทะเบียนแล้ว', 'warning')
            break;
        case "8":
            swal('แจ้งเตือน', 'ลงทะเบียนยืนยันตัวตนไม่พร้อมใช้งาน', 'warning')
            break;
        case "9":
            swal('แจ้งเตือน', 'OTP หมดอายุ กรุณากดขอรหัส OTP อีกครั้ง', 'warning')
            break;
        case "10":
            swal('แจ้งเตือน', 'หมายเลข OTP ไม่ถูกต้องรบกวนกรอกรหัสครั้งล่าสุด', 'warning')
            break;
        case "11":
            swal("ลงทะเบียน", "รับคำปรึกษากับ FA Center สำเร็จ", "success",
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
        case "12":
            swal("ท่านลงทะเบียนเรียบร้อย", "รอเจ้าหน้าที่ติดต่อกลับ", "warning",
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
            break
        case "13":
            swal('แจ้งเตือน', 'ลงทะเบียนไม่สำเร็จ รบกวนลองใหม่อีกครั้ง', 'warning')
            break;
        case "14":
            swal("ลงทะเบียน", "ติดต่อเจ้าหน้าที่สาขาสำเร็จ", "success",
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
function redirectTO(step) {
    let pnlInformation = document.getElementById("pnlInformation");
    let pnlConsent = document.getElementById("pnlConsent");
    let pnlFillIdCard = document.getElementById("pnlFillIdCard");
    let pnlConfirmOTP = document.getElementById("pnlConfirmOTP");
    let pnlDataDIPROM = document.getElementById("pnlDataDIPROM");
    let pnlRegisterComplete = document.getElementById("pnlRegisterComplete");
    let pnlbackStep = document.getElementById("backStep");
    let pnlConsultFACenter = document.getElementById("pnlConsultFACenter");
    let pnlConsultClinicOnline = document.getElementById("pnlConsultClinicOnline");

    switch (step) {
        case "1":
            pnlInformation.style.display = "block";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "none";
            pnlRegisterComplete.style.display = "none";
            pnlConsultFACenter.style.display = "none";
            pnlConsultClinicOnline.style.display = "none";

            break;

        case "2":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "block";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "none";
            pnlRegisterComplete.style.display = "none";
            pnlbackStep.style.display = "none";
            pnlConsultFACenter.style.display = "none";
            pnlConsultClinicOnline.style.display = "none";

            break;

        case "3":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "block";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "none";
            pnlRegisterComplete.style.display = "none";
            pnlConsultFACenter.style.display = "none";
            pnlConsultClinicOnline.style.display = "none";

            break;

        case "4":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "block";
            pnlDataDIPROM.style.display = "none";
            pnlRegisterComplete.style.display = "none";
            pnlConsultFACenter.style.display = "none";
            pnlConsultClinicOnline.style.display = "none";

            break;

        case "5":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "block";
            pnlRegisterComplete.style.display = "none";
            pnlConsultFACenter.style.display = "none";

            break;

        case "6":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "none";
            pnlbackStep.style.display = "block";
            pnlRegisterComplete.style.display = "block";
            pnlConsultFACenter.style.display = "none";
            btnConsultFACenter.style.display = "none";

            break;

        case "7":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "none";
            pnlbackStep.style.display = "block";
            pnlRegisterComplete.style.display = "block";
            pnlConsultFACenter.style.display = "block";
            pnlConsultClinicOnline.style.display = "none";

            break;

        case "8":
            pnlInformation.style.display = "none";
            pnlConsent.style.display = "none";
            pnlFillIdCard.style.display = "none";
            pnlConfirmOTP.style.display = "none";
            pnlDataDIPROM.style.display = "none";
            pnlbackStep.style.display = "block";
            pnlRegisterComplete.style.display = "block";
            pnlConsultFACenter.style.display = "none";
            pnlConsultClinicOnline.style.display = "block";

            break; 

        default:
            swalCaseDIPROM("1")
            break;
    }
}
// start
function ValidateAcceptConsent() {
    let radioAcceptTerm = document.querySelectorAll("input[type=checkbox]");

    if (radioAcceptTerm[0].checked === true) {
        return true;
    } else {
        return false;
    }
}

function AcceptStep1() {

    let uid = getCookie("uid");

    //GET PROFILE UID LINE
    let objUid = GetUIDLineProfile(uid);
    let datalineprofile = JSON.parse(objUid);

    objUidProfile = {
        Uid: datalineprofile.RESULT_OBJ[0].Uid,
        Email: datalineprofile.RESULT_OBJ[0].Email,
        Uid_Channel: datalineprofile.RESULT_OBJ[0].Uid_Channel
    };

    console.log("datalineprofile : " + datalineprofile.RESULT_OBJ[0].Uid);

    if (datalineprofile.RESULT_OBJ[0].Uid != '' && datalineprofile.RESULT_OBJ[0].Uid != null && datalineprofile.RESULT_OBJ[0].Uid != undefined)
    {
        redirectTO("2");
    }
    else {
        redirectToLanding();
    }
}

function AcceptStep2() {
    let isReadTAndC = ValidateAcceptConsent();
    if (isReadTAndC) {

        acceptCondition.value = "1";
        //LocalLog("Step 1 : Validate Is Read Term & Condition : " + isReadTAndC);
        redirectTO("3");

    } else {
        swal('แจ้งเตือน', 'กรุณาอ่านเงื่อนไขบริการทั้งหมดก่อนยืนยันรับทราบเงื่อนไข', 'warning');
    }
}

function ConditionValidateIdentityField() {

    LocalLog("Start : ConditionValidateIdentityField")
    let result = true;
    let txtIdentityId = document.getElementById("txtIdentityId");
    //console.log(txtIdentityId.value);

    if (txtIdentityId.value == '') {
        result = false;
    }
    if (txtIdentityId.value.length < 13 || txtIdentityId.value.length > 13) {
        result = false;
    }
    if (txtIdentityId.value.length == 13) {
        result = true;
    }
    return (result);
}

function ValidatefiledIdentityCard() {
    LocalLog("Start : ValidatefiledIdentityCard")
    let validatefiledIdentityCard = ConditionValidateIdentityField();
    console.log("validatefiledIdentityCard :" + validatefiledIdentityCard);

    if (validatefiledIdentityCard == true) {
        ShowModal();
    }
    else {
        return swal("แจ้งเตือน", "กรอกเลข ไม่ถูกต้อง/ไม่ครบ", "warning",);
    }
}

function GenerateInsertUidMapDIPROMValue() {
    LocalLog("Start : GenerateInsertUidMapDIPROMValue")
    let uid = getCookie("uid");
    let eventCode = '001';
    let eventName = 'กรมส่งเสริมอุตสหากรรม';
    let txtIdentityId = document.getElementById("txtIdentityId");
    let idCardAccept = "";
    let status = true;
    let isAcceptConsent = true;
    let isPartnerData = null;
    let isPartnerKey = null;
    let OtpDummyId = null;
    let isRegisterSuccess = false;

    if (txtIdentityId != null && txtIdentityId != 'undefined' && txtIdentityId != '') {
        idCardAccept = txtIdentityId.value;
    }
    objUidMapDIPROM = {
        Uid: uid,
        EventCode: eventCode,
        EventName: eventName,
        IdentityCard: idCardAccept,
        Status: status,
        IsAcceptConsent: isAcceptConsent,
        isPartnerData: isPartnerData,
        IsPartnerKey: isPartnerKey,
        OtpDummyId: OtpDummyId,
        IsRegisterSuccess: isRegisterSuccess
    };
    //console.log("Step 2.2 Generate Identity Filed Object = " + ObjIdCard.IdentityCard);
    return objUidMapDIPROM;
}

function GenerateInsertFromEnrollment() {
    LocalLog("Start : GenerateInsertFromEnrollment")
    /* ต้องดึงข้อมูลจาก Data */

    //let firstName = objtransDIPROM.Req_CustomerName.replace(/ /g, '');
    let firstName = objtransDIPROM.ContactName != '' ? objtransDIPROM.ContactName : objtransDIPROM.Req_CustomerName.replace(/ /g, '')

    let businessType = '001'

    //let titleName = objtransDIPROM.Req_PersonType
    let titleName = objtransDIPROM.ContactTitleName != '' ? objtransDIPROM.ContactTitleName : objtransDIPROM.Req_PersonType

    //let lastName = firstName
    let lastName = objtransDIPROM.ContactSurname != '' ? objtransDIPROM.ContactSurname : firstName

    let mobilePhone = objtransDIPROM.Req_MobileNo
    let email = objUidProfile.Email
    let identityID = objtransDIPROM.IdentityID

    let Obj =
    {
        BusinessType: businessType,
        TitleName: titleName,
        FirstName: firstName,
        LastName: lastName,
        MobilePhone: mobilePhone,
        Email: email,
        IdentityID: identityID,
        LaserID: 'TCGDIPROM',
        BirthDay: null,
        CreatedBy: 'SYSTEM',
        IdentityType: 'IDCARD'
    };
    LocalLog("ProfileInsertEnrollment : " + JSON.stringify(obj));
    return Obj;
}

function EnrollmentData(obj) {

    let bufferResult = EnrollPersonal(obj);

    if (typeof bufferResult != 'undefined' && bufferResult != null && bufferResult != "" && bufferResult != undefined) {
        return bufferResult;
        //LocalLog("EnrollmentData Casting EnrollmentObj To Object.");
    } else {
        //LocalLog("Step 4.3 Casting EnrollmentObj To Object. : Error");
        return "001";
    }
}

function CallServiceCheckRegisterByIdentityId() {
    LocalLog("start CallServiceCheckRegisterByIdentityId")
    let identityId = objUidMapDIPROM.IdentityCard
    console.log(identityId);
    if (identityId != "" && identityId != "") {
        let buffer = GetCheckUIDMapDIPROM(identityId)
        //console.log(buffer);
        let bufferResult = JSON.parse(buffer);

        let result = bufferResult.RESULT_OBJ[0]
        console.log(result)

        let idString = String(objGetImport.ID);

        if (result != null || result != undefined) {
            if (result.IsRegisterSuccess === true && result.IsPartnerKey == idString )  {
                return true;
            } else
                return false;
        } else
            return false
    } else
        return false;
}

function Accept3Modal() {

    //DisableButtonModal3("disable"); 
   
    // INSERT UID MAP RIPROM and IDCARD TO CHECK DATA RIPROM RETURN DATA FROM THIS
    let obj = GenerateInsertUidMapDIPROMValue();
    
    console.log(obj);

    let resultCheckRegister = CallServiceCheckRegisterByIdentityId();
    //console.log(resultCheckRegister);

    if (resultCheckRegister == true) return swalCaseDIPROM("7");

    if (obj != null) {
        // INSERT UID MAP RIPROM
        LocalLog("start API INTSERT UIDMapDIPROM");
        let objInsert = InsertUIDMapDIPROM(obj);
        //console.log(objInsert);
        let objResultInsert = JSON.parse(objInsert);

        if (objResultInsert.RESULT_STATUS == "OK")
        { 
            objtransDIPROM = {
                TransID: objResultInsert.RESULT_OBJ.Table[0].Id,
                Uid: objResultInsert.RESULT_OBJ.Table[0].Uid,
                PersonType: objResultInsert.RESULT_OBJ.Table[0].PersonType,
                ContactTitleName: objResultInsert.RESULT_OBJ.Table[0].ContactTitleName,
                ContactName: objResultInsert.RESULT_OBJ.Table[0].ContactName,
                ContactSurname: objResultInsert.RESULT_OBJ.Table[0].ContactSurname,
                ContactCompanyName: objResultInsert.RESULT_OBJ.Table[0].ContactCompanyName,
                IdentityID: objResultInsert.RESULT_OBJ.Table[0].IdentityCard,
                Status: objResultInsert.RESULT_OBJ.Table[0].Status,
                IsPartnerData: objResultInsert.RESULT_OBJ.Table[0].IsPartnerData, /*ทดสอบกรณีไม่ได้ลงทะเบียน*/
                IsPartnerKey: objResultInsert.RESULT_OBJ.Table[0].IsPartnerKey,
                Req_Id: objResultInsert.RESULT_OBJ.Table[0].Req_Id,
                Req_PersonType: objResultInsert.RESULT_OBJ.Table[0].Req_PersonType,
                Req_EstablishmentType: objResultInsert.RESULT_OBJ.Table[0].Req_EstablishmentType, 
                Req_YearIncorporate: objResultInsert.RESULT_OBJ.Table[0].Req_YearIncorporate, 
                Req_IndustryCode: objResultInsert.RESULT_OBJ.Table[0].Req_IndustryCode, 
                Req_ProvinceCode: objResultInsert.RESULT_OBJ.Table[0].Req_ProvinceCode,
                Req_OwnerAge: objResultInsert.RESULT_OBJ.Table[0].Req_OwnerAge,
                Req_MaritalStatus: objResultInsert.RESULT_OBJ.Table[0].Req_MaritalStatus,
                Req_YearExperience: objResultInsert.RESULT_OBJ.Table[0].Req_YearExperience,
                Req_Income: objResultInsert.RESULT_OBJ.Table[0].Req_Income,
                Req_Expense: objResultInsert.RESULT_OBJ.Table[0].Req_Expense,
                Req_LoanAmount: objResultInsert.RESULT_OBJ.Table[0].Req_LoanAmount, 
                Req_CustomerName: objResultInsert.RESULT_OBJ.Table[0].Req_CustomerName, 
                Req_Card_ID: objResultInsert.RESULT_OBJ.Table[0].Req_Card_ID,
                Req_SpouseName: objResultInsert.RESULT_OBJ.Table[0].Req_SpouseName,
                Req_Card_ID_Spouse: objResultInsert.RESULT_OBJ.Table[0].Req_Card_ID_Spouse,               
                Req_MDName: objResultInsert.RESULT_OBJ.Table[0].Req_MDName,
                Req_Card_ID_MD: objResultInsert.RESULT_OBJ.Table[0].Req_Card_ID_MD,
                Req_ShareHolderName: objResultInsert.RESULT_OBJ.Table[0].Req_ShareHolderName,
                Req_Card_ID_ShareHolder: objResultInsert.RESULT_OBJ.Table[0].Req_Card_ID_ShareHolder,
                Req_BusinessType: objResultInsert.RESULT_OBJ.Table[0].Req_BusinessType,
                Req_CreditStatus: objResultInsert.RESULT_OBJ.Table[0].Req_CreditStatus,
                Req_CreditStatus_Des: objResultInsert.RESULT_OBJ.Table[0].Req_CreditStatus_Des,
                Req_HealthCheckStatus: objResultInsert.RESULT_OBJ.Table[0].Req_HealthCheckStatus,
                Req_HealthCheckStatus_Des: objResultInsert.RESULT_OBJ.Table[0].Req_HealthCheckStatus_Des,
                Req_AMLStatus: objResultInsert.RESULT_OBJ.Table[0].Req_AMLStatus,
                Req_AMLStatus_Des: objResultInsert.RESULT_OBJ.Table[0].Req_AMLStatus_Des,
                Req_GradeClaimStatus: objResultInsert.RESULT_OBJ.Table[0].Req_GradeClaimStatus,
                Req_IsRegisterSuccess: objResultInsert.RESULT_OBJ.Table[0].Req_IsRegisterSuccess,
                Req_IsRegisterSuccess_Desc: objResultInsert.RESULT_OBJ.Table[0].Req_IsRegisterSuccess_Desc,
                Req_SendEmailStatus: objResultInsert.RESULT_OBJ.Table[0].Req_SendEmailStatus,
                Req_SendEmailStatus_Des: objResultInsert.RESULT_OBJ.Table[0].Req_SendEmailStatus_Des,
                Req_IsApprove: objResultInsert.RESULT_OBJ.Table[0].Req_IsApprove,
                Req_IsApprove_Desc: objResultInsert.RESULT_OBJ.Table[0].Req_IsApprove_Desc,
                Req_MobileNo: objResultInsert.RESULT_OBJ.Table[0].Req_MobileNo,
                Req_Bank_1_Send_Email: objResultInsert.RESULT_OBJ.Table[0].Req_Bank_1_Send_Email
            };
        };

        console.log(objtransDIPROM);

        if (objtransDIPROM.IsPartnerData === "1")
        {
            /*get ข้อมูลจาก Table กลาง แล้ว ไป insert ที่ Enroll เพื่อยืนยันตัวตน
            GenerateFromEnrollment ได้ obj.parse
            */
            let genFromEnrollment = GenerateInsertFromEnrollment();

            console.log(genFromEnrollment);
            // INSERT ENROLLMENT
            if (genFromEnrollment != null) {
                let objResultEnroll = EnrollmentData(genFromEnrollment);

                if (objResultEnroll === "001") return swalCaseDIPROM("8");

                objResultEnroll = JSON.parse(objResultEnroll);
                console.log(objResultEnroll);

                if (objResultEnroll.RESULT_OBJ != null && objResultEnroll.RESULT_OBJ != undefined && objResultEnroll.RESULT_OBJ != 'undefined' && objResultEnroll.RESULT_OBJ != '')
                {
                    let mobileSentOTP = genFromEnrollment.MobilePhone;
                    // OTP FIX PHONE NUMBER
                    document.getElementById("txtMobilePhoneSentOTP").value = mobileSentOTP;

                    console.log(document.getElementById("txtMobilePhoneSentOTP").value);

                    objSendOTP = {
                        MobileSentOTP: mobileSentOTP,
                        OtpDummyID: objResultEnroll.RESULT_OBJ,
                        Uid: objUidMapDIPROM.Uid,
                        Id: objtransDIPROM.TransID
                    }
                    redirectTO("4");
                }
                else {
                    console.log("no data dummy enroll");
                    swalCaseDIPROM("1");
                }

            } else swal("แจ้งเตือน", "เกิดข้อผิดพลาดในการสร้างข้อมูล", "warning",);
           
        } else swalCaseDIPROM("4"); 
    }

    else swal("แจ้งเตือน", "เกิดข้อผิดพลาดในการสร้างข้อมูล", "warning",);
}
/* Strat ส่ง OTP */
function SendOTP() {
    LoaderActive();
    ShowLoading()
    .then(() => {
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

function CountDownResend() 
{
    //TIME_SETTING
    let minute = 4;
    let sec = 59;
    let itemStartCoolDown = new Date();
    timeCoolDownStart = itemStartCoolDown;
    console.log("StartCoolDown");
    console.log(timeCoolDownStart);

    let interval = setInterval(function () {
        document.getElementById("btnSendOTP").style.color = "white";
        document.getElementById("btnSendOTP").innerHTML = "ส่งได้อีกครั้งใน " + minute + ":" + sec +  " นาที";
        
        sec--;

        if (sec == 0) 
        {
            minute--;

            if (minute >= 0)
            {
                sec = 59;

            } else 
            {
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

async function CallServiceSendOTP(enrollDummyID, phoneNumber) {
    if (enrollDummyID != "" && phoneNumber != "") {

        //let result = SendPersonalOTP(enrollDummyID, phoneNumber);

        let result = await SendPersonalOTPAsync(enrollDummyID, phoneNumber);

        console.log(result);
        return result;
    }
}

async function CallServiceCheckSendOTP(dummyId) {

    if (dummyId != '') {

        let result = await GetVerifyOTPLastStatusAsync(dummyId);
        console.log(result);
        return result;
    }
}

async function GenResultCheckSentOTP(dummyid) {

    let buffer = await CallServiceCheckSendOTP(dummyid);
    let bufferResult = JSON.parse(buffer);

    objResultCheckSent = {
        Id: bufferResult.RESULT_OBJ.id,
        DummyId: bufferResult.RESULT_OBJ.dummyId,
        VerifyValue: bufferResult.RESULT_OBJ.verifyValue,
        RefNumber: bufferResult.RESULT_OBJ.refNumber
    }
    console.log(objResultCheckSent); 

    return objResultCheckSent.RefNumber;
}

async function SendOTP_CoreSendOTP() {

    DisableAndCounting("disable");
    let btnSendOTP = document.getElementById("btnSendOTP");
    //let txtMobilePhoneSentOTP = document.getElementById("txtMobilePhoneSentOTP").value;
    let enrollDummyID = objSendOTP.OtpDummyID;
    let phoneNumber = objSendOTP.MobileSentOTP;

    console.log(enrollDummyID)
    console.log("Phone Number is : " + phoneNumber);

    if (phoneNumber != "" && phoneNumber != 'undefined') {

        let resultSentOTP = await CallServiceSendOTP(enrollDummyID, phoneNumber);
        console.log("call service sentOTP" + resultSentOTP);

        if (resultSentOTP != "" && resultSentOTP != 'undefined' && resultSentOTP != null && resultSentOTP != undefined) {

            let resultCheckSent = await GenResultCheckSentOTP(enrollDummyID);

            console.log("resultCheckSent : " + resultCheckSent)

            btnSendOTP.classList.add("btn-disable");
            sendOTPObj = JSON.parse(resultSentOTP);
            document.getElementById("pnlKeyInOTP").style.display = "block";
            document.getElementById("ltlReferenceNumber").innerText = objResultCheckSent.RefNumber;
            LoaderInActive();
        }
        else {
            swalCaseDIPROM("5");
            LoaderInActive();
        }
    } else {
        btnSendOTP.classList.remove("btn-disable");
        btnSendOTP.innerText = "ขอรหัส OTP";
        LoaderInActive();
        swal('แจ้งเตือน', 'กรุณาลองอีกครั้ง', 'warning');
    }

    console.log("Get OTP :");
}
/* End ส่ง OTP */

/* Check รหัส OTP */
function ValidateRefferenOTP() {

    let enrollDummyID = objSendOTP.OtpDummyID;
    let otpMsg = document.getElementById("txtOTP").value;
    console.log(otpMsg)
    if (otpMsg == '') {
        return false;
    }
    let refMsg = document.getElementById("ltlReferenceNumber").innerText;
    //let refMsg = "9999";
    let isValidateOTP = ValidateOTP(enrollDummyID, refMsg, otpMsg);
    
    if (isValidateOTP == true) {
        return true;
    }
    else {
        return false;
    }
   //return true; //  // TEST Close send OTP*/

}

function GenConfirmResult(obj) {

    let sendRef = new Date(obj.RESULT_OBJ.sendRefDate);
    let keyInRef = new Date(obj.RESULT_OBJ.keyInDate);

    objConfirmOTPResult = {
        OtpDummyId: obj.RESULT_OBJ.dummyId,
        OtpID: obj.RESULT_OBJ.id,
        SendRef: sendRef,
        KeyInRef: keyInRef,
        RefId: obj.RESULT_OBJ.refNumber ,
        VerifyValue : obj.RESULT_OBJ.verifyValue 
    }
    console.log("objConfirmOTPResult" + objConfirmOTPResult);
}

function CheckOTPExpried() {

    let diffMs = (timeCoolDownEnd - timeCoolDownStart);
    let diffSecs = Math.floor(diffMs / 1000);
    console.log(diffSecs)

    console.log("DIFF OTP IN BeforeIF : " + diffSecs);

    //TIME_SETTING
    if (diffSecs <= 290) {
        console.log("DIFF OTP IN : " + diffSecs)
        return true;
    }
    else
        console.log("DIFF OTP IN : " + diffSecs)
    return false;

}

function CheckOTPRefNumber() {

    let RefOtp = objResultCheckSent.RefNumber

    let RefOtpValid = objConfirmOTPResult.RefId

    console.log("RefOTP is : " + RefOtp + " RefOTPValid is : " + RefOtpValid);

    if (RefOtp == RefOtpValid) {
        return true;
    }
    else {
        return false; 
    }
}

function ValidateOTP(enrollDummyID, refNo, otpMsg) {

    let resultConfirmOTP = ConfirmPersonalOTP(enrollDummyID, refNo, otpMsg);

    //console.log(resultConfirmOTP);

    if (resultConfirmOTP === undefined || !resultConfirmOTP) {
        let resultConfirmOTP = ConfirmPersonalOTP(enrollDummyID, refNo, otpMsg)
        console.log("ReplyLoop Confirm Status is : " + resultConfirmOTP);

        let bufferObj = JSON.parse(resultConfirmOTP);

        let genResult = GenConfirmResult(bufferObj);

        //console.log(genResult);

        if (bufferObj.RESULT_OBJ.isSuccess === true) {

            console.log("ReplyLoop IsSuccess is  : " + bufferObj.RESULT_OBJ.isSuccess);
            return true;
        } else {

            return false;
        }
    } 

    if (resultConfirmOTP && resultConfirmOTP != "undefined") {
        console.log("Confirm Status is : " + resultConfirmOTP);

        let bufferObj = JSON.parse(resultConfirmOTP);

        let genResult = GenConfirmResult(bufferObj);

        console.log(genResult);

        if (bufferObj.RESULT_OBJ.isSuccess === true) {

            console.log("IsSuccess is : " + bufferObj.RESULT_OBJ.isSuccess);
            return true;
        } else {
            return false;
        }
    } return false;

}
/* END Check รหัส OTP */
function UpdatetransUidMapDIPROM() {

    // let resultUpdate = UpdateUIDMapDIPROM(objSendOTP);
    let resultUpdate = UpdateDataSetUIDMapDIPROM(objSendOTP);
    //console.log(resultUpdate);

    if (resultUpdate != "" && resultUpdate != "undefined") {

        let bufferObj = JSON.parse(resultUpdate);
        let bufferObjOtpDummyId = bufferObj.RESULT_OBJ.Table[0].OtpDummyId;

        if (bufferObjOtpDummyId != null && bufferObjOtpDummyId != '') {
            console.log('Update UIDMapDIPROM Complete OtpDummyId is : ' + bufferObjOtpDummyId);
            return true;
        } else {
            return false;
        }
    } return false;
}

function GenPreviewInformation() {

    document.getElementById("txtCustomerName").value = objtransDIPROM.Req_CustomerName
    document.getElementById("txtCardID").value = objtransDIPROM.Req_Card_ID
    document.getElementById("txtSpouseName").value = objtransDIPROM.Req_SpouseName
    document.getElementById("txtMDName").value = objtransDIPROM.Req_MDName
    document.getElementById("txtShareHolderName").value = objtransDIPROM.Req_ShareHolderName
    document.getElementById("txtBusinessType").value = objtransDIPROM.Req_BusinessType
    document.getElementById("txtEstablishmentType").value = objtransDIPROM.Req_EstablishmentType
    document.getElementById("txtYearIncorporate").value = objtransDIPROM.Req_YearIncorporate
    document.getElementById("txtIndustryCode").value = objtransDIPROM.Req_IndustryCode
    document.getElementById("txtProvinceCode").value = objtransDIPROM.Req_ProvinceCode
    document.getElementById("txtOwnerAge").value = objtransDIPROM.Req_OwnerAge
    document.getElementById("txtMaritalStatus").value = objtransDIPROM.Req_MaritalStatus
    document.getElementById("txtYearExperience").value = objtransDIPROM.Req_YearExperience
    document.getElementById("txtIncome").value = objtransDIPROM.Req_Income
    document.getElementById("txtExpense").value = objtransDIPROM.Req_Expense
    document.getElementById("txtLoanAmount").value = objtransDIPROM.Req_LoanAmount
    document.getElementById("txtMobileNo").value = objtransDIPROM.Req_MobileNo
    document.getElementById("txtBankSendEmail").value = objtransDIPROM.Req_Bank_1_Send_Email

    console.log("GenPreviewIsSuccess");
}

function WaitUpdate() {
    LoaderActive();
    ShowLoading().then(() => {

        /* GET DATA BEFOR DIRECT*/
        GenPreviewInformation();

        let resultUpdate = UpdatetransUidMapDIPROM();
        if (resultUpdate === true) {

            LoaderInActive();
            redirectTO("5");
        } else {
            LoaderInActive();
            swalCaseDIPROM("1");
        }
    });
    //document.getElementById("pnlKeyInOTP").style.display = "block";   // TEST Close send WaitUpdate
}

function AcceptStep4() {

    let checkOTPExpried = CheckOTPExpried();

    if (checkOTPExpried == false) {
        LocalLog("end Progess ValidateOTPRef OTP Expired");
        return swalCaseDIPROM("9");
    }

    console.log()

    let validateOTP = ValidateRefferenOTP();

    console.log("Validate OTP is :" + validateOTP);

    if (validateOTP == true) {

        let checkOTPRef = CheckOTPRefNumber();

        if (checkOTPRef == false) {
            LocalLog("end Progess ValidateOTPRef OTP Not Correct");
            return swalCaseDIPROM("10");
            console.log("otp exp is : " + checkOTPExpried);

        } else {
            LocalLog("Finish OTP Register");
            WaitUpdate();
        }
    }
    else {
        LocalLog("end Progess ValidateOTPRef");
        swalCaseDIPROM("6");
    }
}

function UpdateSuccessUIDMapDIPROM() {

    objSuccessTrans = {
        Id: objtransDIPROM.TransID,
        Uid: objUidMapDIPROM.Uid,
        IsRegisterSuccess: true,
        OtpDummyID: objSendOTP.OtpDummyID
    }

    let resultUpdate = UpdateDataSetUIDMapDIPROM(objSuccessTrans);
    if (resultUpdate != "" && resultUpdate != "undefined") {

        let bufferObj = JSON.parse(resultUpdate);
        let bufferObjIsSuccess = bufferObj.RESULT_OBJ.Table[0].IsRegisterSuccess;

        if (bufferObjIsSuccess != null && bufferObjIsSuccess != '') {
            console.log('Update Complete Trans is : ' + bufferObjIsSuccess);
            return true;
        } else {
            return false;
        }
    } return false;
}

function UpdateSuccessImportRequest() {

    let ID = parseInt(objtransDIPROM.Req_Id)

    let resultUpdate = UpdateLineRequestDIPROM(ID);
    //console.log(resultUpdate);
    if (resultUpdate != "" && resultUpdate != "undefined" && resultUpdate != undefined) {

        let bufferObj = JSON.parse(resultUpdate);
        console.log(bufferObj.RESULT_OBJ.Id);

        if (bufferObj.RESULT_STATUS == "OK") {

            objSuccessReigster = {
                TransID: bufferObj.RESULT_OBJ[0].Id,
                IsRegisterSuccess: bufferObj.RESULT_OBJ[0].IsRegisterSuccess,
                Req_Id: bufferObj.RESULT_OBJ[0].Req_Id,
                Req_CreditStatus: bufferObj.RESULT_OBJ[0].Req_CreditStatus,
                Req_CreditStatus_Des: bufferObj.RESULT_OBJ[0].Req_CreditStatus_Des,
                Req_HealthCheckStatus: bufferObj.RESULT_OBJ[0].Req_HealthCheckStatus,
                Req_HealthCheckStatus_Des: bufferObj.RESULT_OBJ[0].Req_HealthCheckStatus_Des,
                Req_AMLStatus: bufferObj.RESULT_OBJ[0].Req_AMLStatus,
                Req_AMLStatus_Des: bufferObj.RESULT_OBJ[0].Req_AMLStatus_Des,
                Req_IsRegisterSuccess: bufferObj.RESULT_OBJ[0].Req_IsRegisterSuccess,
                Req_IsRegisterSuccess_Desc: bufferObj.RESULT_OBJ[0].Req_IsRegisterSuccess_Desc,
                Req_SendEmailStatus: bufferObj.RESULT_OBJ[0].Req_SendEmailStatus,
                Req_SendEmailStatus_Des: bufferObj.RESULT_OBJ[0].Req_SendEmailStatus_Des,
                Req_IsApprove: bufferObj.RESULT_OBJ[0].Req_IsApprove,
                Req_IsApprove_Desc: bufferObj.RESULT_OBJ[0].Req_IsApprove_Desc
            }
            console.log(objSuccessReigster);

        } else return false; 

        let bufferObjIsSuccess = bufferObj.RESULT_OBJ[0].Req_IsRegisterSuccess;
        if (bufferObjIsSuccess === 1) {
            return true;
        } else
            return false;
    } return false;
}

function GenPreviewStatusRegisterSuccess() {

    // let Req_CreditStatus = (objSuccessReigster.Req_CreditStatus ? undefined : objGetSuccessReigster.Req_CreditStatus)
    let Req_CreditStatus;
    if (objSuccessReigster.Req_CreditStatus === undefined) {
        Req_CreditStatus = objGetSuccessReigster.Req_CreditStatus;
    } else {
        Req_CreditStatus = objSuccessReigster.Req_CreditStatus;
    }
    console.log(objSuccessReigster.Req_CreditStatus_Des)
    console.log(objGetSuccessReigster.Req_CreditStatus_Des)
    if (Req_CreditStatus === 1) {
        AddStatusColor("statusBar1", "PASS");
    }
    if (Req_CreditStatus === 2) {
        AddStatusColor("statusBar1", "PASS");
    }
    if (Req_CreditStatus === 3) {
        AddStatusIcon("statusBar1", "REJECT");
    }

    let Req_IsRegisterSuccess;
    if (objSuccessReigster.Req_IsRegisterSuccess === undefined) {
        Req_IsRegisterSuccess = objGetSuccessReigster.Req_IsRegisterSuccess;
    } else {
        Req_IsRegisterSuccess = objSuccessReigster.Req_IsRegisterSuccess;
    }
    console.log(objSuccessReigster.Req_IsRegisterSuccess_Desc)
    console.log(objGetSuccessReigster.Req_IsRegisterSuccess_Desc)
    if (Req_IsRegisterSuccess == 1) {
        AddStatusColor("statusBar2", "PASS");
    }

    let Req_HealthCheckStatus;
    if (objSuccessReigster.Req_HealthCheckStatus === undefined) {
        Req_HealthCheckStatus = objGetSuccessReigster.Req_HealthCheckStatus;
    } else {
        Req_HealthCheckStatus = objSuccessReigster.Req_HealthCheckStatus;
    }
    console.log(objSuccessReigster.Req_HealthCheckStatus_Des);
    console.log(objGetSuccessReigster.Req_HealthCheckStatus_Des)
    if (Req_IsRegisterSuccess == 1 && Req_HealthCheckStatus == 0) {
        AddStatusIcon("statusBar3", "PROCESS");
    }
    if (Req_IsRegisterSuccess == 1 && Req_HealthCheckStatus == 0 && Req_CreditStatus === 3 ) {
        AddStatusColor("statusBar3", "WAIT");
    }
    if (Req_IsRegisterSuccess == 1 && Req_HealthCheckStatus == 1 || Req_HealthCheckStatus == 2) {
        AddStatusColor("statusBar3", "PASS");
    }
    if (Req_IsRegisterSuccess == 1 && Req_HealthCheckStatus == 3) {
        AddStatusIcon("statusBar3", "REJECT");
    }

    let Req_AMLStatus;
    if (objSuccessReigster.Req_AMLStatus === undefined) {
        Req_AMLStatus = objGetSuccessReigster.Req_AMLStatus;
    } else {
        Req_AMLStatus = objSuccessReigster.Req_AMLStatus;
    }
    let Req_IsApprove;
    if (objSuccessReigster.Req_IsApprove === undefined) {
        Req_IsApprove = objGetSuccessReigster.Req_IsApprove;
    } else {
        Req_IsApprove = objSuccessReigster.Req_IsApprove;
    }
    console.log(objSuccessReigster.Req_AMLStatus_Des + objGetSuccessReigster.Req_AMLStatus_Des);
    console.log(objSuccessReigster.Req_IsApprove_Desc + objGetSuccessReigster.Req_IsApprove_Desc);
    if (Req_HealthCheckStatus != 0 && Req_IsApprove == 0) {
        AddStatusIcon("statusBar4", "PROCESS");
    }
    if (Req_HealthCheckStatus == 0 && Req_IsApprove == 0) {
        AddStatusColor("statusBar4", "WAIT");
    }
    if (Req_HealthCheckStatus == 1 || Req_HealthCheckStatus == 2 && Req_IsApprove == 1) {
        AddStatusColor("statusBar4", "PASS");
    }
    if (Req_HealthCheckStatus == 3 && Req_IsApprove == 1) {
        AddStatusIcon("statusBar4", "REJECT");
    }
    if (Req_HealthCheckStatus == 3 && Req_IsApprove == 2) {
        AddStatusIcon("statusBar4", "REJECT");
    }
    if (Req_HealthCheckStatus == 1 || Req_HealthCheckStatus == 2 && Req_IsApprove == 2) {
        AddStatusIcon("statusBar4", "REJECT");
    }

    let Req_SendEmailStatus;
    if (objSuccessReigster.Req_SendEmailStatus === undefined) {
        Req_SendEmailStatus = objGetSuccessReigster.Req_SendEmailStatus;
    } else {
        Req_SendEmailStatus = objSuccessReigster.Req_SendEmailStatus;
    }
    console.log(objSuccessReigster.Req_SendEmailStatus_Des)
    console.log(objGetSuccessReigster.Req_SendEmailStatus_Des)
    if (Req_HealthCheckStatus == 1 && Req_IsApprove == 1 && Req_SendEmailStatus == 0) {
        AddStatusIcon("statusBar5", "PROCESS");
    }
    if (Req_IsApprove == 0 && Req_SendEmailStatus == 0) {
        AddStatusColor("statusBar5", "WAIT");
    }
    if (Req_IsApprove == 1 && Req_SendEmailStatus == 1) {
        AddStatusColor("statusBar5", "PASS");
    }
}

function AcceptStep5() {

    let resultUIDMapDIPROMUpdate = UpdateSuccessUIDMapDIPROM();
    let reusltImportRequestUpdate = UpdateSuccessImportRequest();

    console.log("resultDIPROMUpdate : " + resultUIDMapDIPROMUpdate + " resultImportUpdate : " + reusltImportRequestUpdate); 

    if (resultUIDMapDIPROMUpdate === true && reusltImportRequestUpdate === true) {

        GenPreviewStatusRegisterSuccess();

        if (objSuccessReigster.Req_CreditStatus == 3)
        {
            return redirectTO("7");
        }
        if (objSuccessReigster.Req_IsApprove == 2)
        {
            return redirectTO("8");
        }
        else {
            return redirectTO("6");
        }
    } else {
        return swalCaseDIPROM("1");
    }
}

function GenFormatServiceObjectDiprom(personType) {
    var personTypeCase = personType;
    switch (personTypeCase) {
        case 1 :
            return 1;
        case 3 :
            return 2;
        default:
            return 1;
    }
}

function GenerateDipromProfileObject() {

    let uid = getCookie("uid");

    if (uid != null || uid != "") {

        let bufferProfile = GetProfileDiprom(uid);
        let bufferProfileResult = JSON.parse(bufferProfile);
        console.log(bufferProfileResult);

        let id = bufferProfileResult.RESULT_OBJ[0].Diprom_Id != null ? bufferProfileResult.RESULT_OBJ[0].Diprom_Id : ""; 
        let titleName = bufferProfileResult.RESULT_OBJ[0].ContactTitleName != null ? bufferProfileResult.RESULT_OBJ[0].ContactTitleName : "";
        let name = bufferProfileResult.RESULT_OBJ[0].ContactName != null ? bufferProfileResult.RESULT_OBJ[0].ContactName : "";
        let lastName = bufferProfileResult.RESULT_OBJ[0].ContactSurname != null ? bufferProfileResult.RESULT_OBJ[0].ContactSurname : "";
        let companyName = bufferProfileResult.RESULT_OBJ[0].ContactCompanyName != null ? bufferProfileResult.RESULT_OBJ[0].ContactCompanyName : "-";
        let positionInCompany = bufferProfileResult.RESULT_OBJ[0].EstablishmentType != null ? bufferProfileResult.RESULT_OBJ[0].EstablishmentType : 1;
        let idCard = bufferProfileResult.RESULT_OBJ[0].Card_ID != null ? bufferProfileResult.RESULT_OBJ[0].Card_ID : "";
        let province = bufferProfileResult.RESULT_OBJ[0].ProvinceCode != null ? bufferProfileResult.RESULT_OBJ[0].ProvinceCode : "";
        let mobile = bufferProfileResult.RESULT_OBJ[0].MobileNo != null ? bufferProfileResult.RESULT_OBJ[0].MobileNo : "";
        let personType = bufferProfileResult.RESULT_OBJ[0].PersonType != null ? bufferProfileResult.RESULT_OBJ[0].PersonType : 1;
        let typeProductService = bufferProfileResult.RESULT_OBJ[0].BusinessType != null ? bufferProfileResult.RESULT_OBJ[0].BusinessType : "-";
        let line_UserId = uid;

        objCusProfileFA = {
            Diprom_Id : id,
            TitleName: titleName,
            UserFirstName: name,
            UserLastName: lastName,
            CompanyName: companyName,
            PositionInCompany: positionInCompany,
            IdCard: idCard,
            Province: province,
            Mobile: mobile,
            TypeCompany : 4,
            FormatService: GenFormatServiceObjectDiprom(personType),
            TypeProductOrService: typeProductService,
            CreateBy: '9991', 
            Line_UserId: line_UserId
        };
        console.log("Generate DipromProfile Object");
        return objCusProfileFA;

    } else
    {
    let error = Obj = { Uid  : UidNotFound};
        return error;
    }
}

function GenDipromTransactionObject(_customerID) {

    let uid = getCookie("uid");

    if (uid != null || uid != "") {

        let bufferProfile = GetProfileDiprom(uid);
        let bufferProfileResult = JSON.parse(bufferProfile);
        console.log(bufferProfileResult);
        let customerID = parseInt(_customerID.replace('"', ''));
        let interestLoanOfBank = bufferProfileResult.RESULT_OBJ[0].BankID1;
        let loanAmount = bufferProfileResult.RESULT_OBJ[0].LoanAmount

        objCusTransFA = {
            Uid: objCusProfileFA.Line_UserId,
            ApplicationId: '1',
            ChannelId: '2',
            CustomerProfileId: customerID,
            CurrentStatusId: '1',
            CreateBy: '9991',
            FA_Ref: objCusProfileFA.IdCard,
            LoanMoney: loanAmount,
            InterestLoanOfBank: interestLoanOfBank
        };

        return objCusTransFA; 
    }
}

async function AcceptConsultFA() {
    //redirectToMain();

    let objCustomerProfileFA = GenerateDipromProfileObject();
    console.log(objCustomerProfileFA);

    //Async Function 
    let customerID = await InsertCustomerProfileAsync(objCustomerProfileFA);

    console.log(customerID); 
        
    if (customerID !== "") {
        console.log("insert objCustomerProfileFA Success");

        let objCustomerTranConsultFA = GenDipromTransactionObject(customerID);
        console.log(objCustomerTranConsultFA);

        let bufferresultInsertTrans = await InsertCustomerTransConsultAsync(objCustomerTranConsultFA);

        let resultInsertTrans = JSON.parse(bufferresultInsertTrans);

        console.log(resultInsertTrans);

        if (resultInsertTrans.RESULT_OBJ != '') {
            console.log("insert objTans Success");

            let tranID = resultInsertTrans.RESULT_OBJ;
            console.log(tranID);

            let obj = {
                Id: objCusProfileFA.Diprom_Id,
                Uid: objCusProfileFA.Line_UserId,
                //IsContactClinic: null,
                //TransContactClinic: null,
                IsContactFA: true,
                TransContactFA: tranID
            };

            let bufferResult = await UpdateReturnDataSetUidMapDipromConsultFA(obj);

            let result = JSON.parse(bufferResult);

            console.log(result);

            if (result.RESULT_OBJ.Table[0].IsContactFA == true) {
                swalCaseDIPROM("11");
            }
            else {
                swalCaseDIPROM("13");
            }
            
        } else {
            console.log("insert objTans Fail"); 
        }

    }
    else
    {
        console.log("insert objCustomerProfileFA Fail");
    }
}

function GenObjectConsultClinic() { 

    let uid = getCookie("uid");

    if (uid != null || uid != "") {

        let bufferProfile = GetProfileDiprom(uid);
        let bufferProfileResult = JSON.parse(bufferProfile);

        console.log(bufferProfileResult);

        let id = bufferProfileResult.RESULT_OBJ[0].Diprom_Id != null ? bufferProfileResult.RESULT_OBJ[0].Diprom_Id : ""; 
        let line_UserId = uid;

        let obj = {
            Id: id,
            Uid: line_UserId,
            IsContactClinic: true
            //TransContactClinic: null,
            //IsContactFA: true,
            //TransContactFA: tranID
        };

        return obj 
    }
    else {
        let error = Obj = { Uid: UidNotFound };
        return error;
    }
}

async function AcceptConsultClinic() {

    let obj = GenObjectConsultClinic();

    let bufferResult = await UpdateReturnDataSetUidMapDipromConsultFA(obj);

    let result = JSON.parse(bufferResult)

    console.log(result); 

    if (result.RESULT_OBJ.Table[0].IsContactClinic == true) {
        swalCaseDIPROM("14");
    } else {
        swalCaseDIPROM("13");
    }

}

function BackToMain() {
    redirectToMain();
}