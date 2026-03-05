var post = "POST";
var get = "GET";
// Profile
function InsertCustomerProfileHistory(lstObj) {
    var url = host + "/api/customerprofile";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(lstObj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

function GetUidData(uid) {
    var url = host + "/api/uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

function GetUIDLineProfile(uid) {
    var url = host + "/api/uidlineprofile/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

//Product
function GetApprochByUIDAndPCode(pcode, uid) {
    var url = host + "/api/approch/" + pcode + "/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function InsertApprochMapBank(lstObj, approchID) {
    var url = host + "/api/approch/" + approchID;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(lstObj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

//Menu
function InsertUID(obj) {
    var url = host + "/api/UID";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;

}

//Landing
function SelectUserConsent() {
    var uid = getCookie("uid");
    var url = host + "/api/consent/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);
    console.log("Service interface : " + uid);

    if (uid !== null) {
        let buffer = HttpRequest(url, "GET")
        if (buffer !== null && typeof buffer != "undefined") {
            return buffer = JSON.parse(buffer);
        }
        return null;
    }
    LocalLogHttp("HTTP Res :" + result);
}

//External
function GetIsRegister(cid) {
    //let result = HttpRequest(host + "/api/customerprofile/" + cid + "/approch/count", "GET")
    var url = host + "/api/customerprofile/" + cid + "/approch/count";
    var data = "";
    var xhr = new XMLHttpRequest();

    LocalLogHttp("HTTP Req : " + get + " : " + url);

    xhr.open('GET', url, false);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('Authorization', 'Bearer 123456789');
    xhr.send();

    data = xhr.responseText;
    LocalLogHttp("HTTP Res :" + data);

    return data;

}

//debt Service
function GetUIDMapFAEvent(uid, eventcode) {
    var url = host + "/api/debt/event/" + eventcode + "/uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function InsertCustomerProfile(obj) {
    var url = host + "/api/customerprofile/fa";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

function InsertFormFARegister(obj) {
    var url = host + "/api/registerinfo/fa";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function InsertUIDMapTransaction(obj) {
    var url = host + "/api/registerinfo/fa/uid";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function InsertUIDMapFAEvent(obj) {
    var url = host + "/api/debt/event/register";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;

}

//DebtCompromiseEvent
function InsertUIDMapDebtEvent(obj) {
    var url = host + "/api/debt/event/checkIdentity";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function InsertFormFARegisterCompromise(obj, Id, DummyID) {
    var url = host + "/api/registerinfo/fa/debtcompromise?Id=" + Id + "&DummyID=" + DummyID;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function SendEmailToConsult(obj) {
    var url = host + "/api/v1/FACenter/send-email-to-consult";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

//function GetUIDMapDebtEvent(obj) {
//    var url = host + "/api/debt/event/get-uid-map-debt-event";
//    LocalLogHttp("HTTP Req : " + post + " : " + url);
//    let result = HttpRequest(url, post, JSON.stringify(obj))
//    LocalLogHttp("HTTP Res :" + result);
//    return result;
//}

//Events
function GetFormRegisterWithEventCodeAndUID(eventCode, uid) {
    var url = host + "/api/event/" + eventCode + "/uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;

}
function InsertFormEventRegister(obj) {
    var url = host + "/api/event/register";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;

}
function InsertFormEventRegisterDynamic(obj) {
    var url = host + "/api/event/register/dynamic";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;

}
function InsertFormEventRegisterDynamicNoSendMail(obj) {
    var url = host + "/api/event/register/dynamic/nosendmail";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;

}

//PreNDID
function InsertUIDMapNDIDPreRequest(obj) {
    var url = host + "/api/requestinfo/prendid/";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

//NDID
function InsertCustomerChooseIDP(obj) {
    var url = host + "/api/ndid/register/idp";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

// Register SignUp
function EnrollPersonal(obj) {
    var url = host + "/api/enrollment/personal/";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function UpdateEnrollPersonalEmail(registerID, email) {
    var url = host + "/api/enrollment/email/" + registerID;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(email))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function VerifyPersonal(dummyID) {
    var url = host + "/api/verify/personal/" + dummyID + "/obj";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, get, "")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function VerifyPersonalAsync(dummyID) {

    var url = host + "/api/verify/personal/" + dummyID + "/obj";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET", undefined)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}


function VerifyDopaDipchip(obj) {
    var url = host + "/api/verify/dopa/directly";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

function SendPersonalOTP(dummyID, phoneNumber) {
    var url = host + "/api/verify/otp/" + dummyID + "/" + phoneNumber;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, "")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function SendPersonalOTPAsync(dummyID, phoneNumber) {
    var url = host + "/api/verify/otp/" + dummyID + "/" + phoneNumber;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function GetVerifyOTPLastStatusAsync(dummyid) {
    var url = host + "/api/verify/dummy/" + dummyid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

function ConfirmPersonalOTP(dummyID, ref, otp) {
    var url = host + "/api/verify/otp/" + dummyID + "/ref/" + ref + "/" + otp;
    LocalLogHttp("HTTP Req : " + post + " : " + url);


    let result = HttpRequest(url, post, "")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function ConfirmPersonalOtpAsync(dummyID, ref, otp) {
    var url = host + "/api/verify/otp/" + dummyID + "/ref/" + ref + "/" + otp;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}


//function MappingUidWithDummayID(uid, dummyID) {
//    var url = host + "/api/mapping/uid/" + uid + "/dummyid/" + dummyID;
//    LocalLogHttp("HTTP Req : " + post + " : " + url);

//    let result = HttpRequest(url, post, "")
//    LocalLogHttp("HTTP Res :" + result);
//    return result;
//}

function CallNDIDEForm(obj) {
    var url = host + "/api/ndid/eform";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}


//Call NODE SETThailandTCG 
function CallNodeSetThailandTcg(obj) {
    var url = host + "/api/setthailand/authenticate";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function logSetThainland(obj) {
    var url = host + "/api/setthailand/log";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

//DIPROM
function InsertUIDMapDIPROM(obj) {
    var url = host + "/api/diprom/checkIdentity";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function UpdateUIDMapDIPROM(obj) {
    var url = host + "/api/diprom/update-transaction-diprom";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function UpdateDataSetUIDMapDIPROM(obj) {
    var url = host + "/api/diprom/update-transaction-diprom-dataset";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function GetCheckUIDMapDIPROM(identityId) {
    var url = host + "/api/diprom/get-transaction-indentityid/" + identityId;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function UpdateLineRequestDIPROM(ID) {
    var url = host + "/api/diprom/update-importrequest-registersuccess/" + ID;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, "")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function MappingUidWithDummayID(uid, dummyID) {
    var url = host + "/api/mapping/uid/" + uid + "/dummyid/" + dummyID;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, "")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
async function MappingUidWithDummyIDAsync(uid, dummyID) {

    var url = host + "/api/mapping/uid/" + uid + "/dummyid/" + dummyID;
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST")
    LocalLogHttp("HTTP Res :" + result);
    return result;

}

function GetUidMapEnrollment(uid) {
    var url = host + "/api/getenrollment/uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
async function GetUidMapEnrollmentAsync(uid) {
    var url = host + "/api/getenrollment/uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}



function GetRegisterUIDMapDIPROM(uid, eventCode) {
    var url = host + "/api/diprom/get-transaction-uid/" + uid + "/eventCode/" + eventCode;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function InsertCustomerProfileAsync(obj) {
    var url = host + "/api/customerprofile/fa";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function InsertCustomerTransConsultAsync(obj) {
    var url = host + "/api/registerinfo/consult/fa";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function UpdateReturnDataSetUidMapDipromConsultFA(obj) {
    var url = host + "/api/diprom/update-transaction-diprom-consult-dataset";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

/* async function*/
async function InterfaceGetRegisterUIDMapDipromAsync(uid, eventCode) {

    var url = host + "/api/diprom/get-transaction-uid/" + uid + "/eventCode/" + eventCode;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET", undefined)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function GetProfileDiprom(uid) {
    var url = host + "/api/diprom/get-transaction-profile-uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function GetImportRequest(uid, identityid) {
    var url = host + "/api/diprom/get-importrequest/uid/" + uid + "/identityId/" + identityid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

// Utility
function CreateLogActivity(obj) {
    var url = host + "/api/logactivity";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

//TCCProject
async function InsertUIDMapTCC(obj) {
    var url = host + "/api/tcc/insertUidMapTcc";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function GetMemberStatusBYSAsync(identityId) {
    var url = host + "/api/tcc/getMemberStatusBYS/" + identityId
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function InsertInformationTCC(obj) {
    var url = host + "/api/tcc/insertInformationTCC";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function UpdateInformationTCCPerson(obj) {
    var url = host + "/api/tcc/updateInformationTCCPerson";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function UpdateInformationTCCJurustic(obj) {
    var url = host + "/api/tcc/updateInformationTCCJurustic";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function ServiceAddMemberPeronalBYS(obj) {
    var url = host + "/api/tcc/addMemberPeronalBYS";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function ServiceAddMemberJurusticlBYS(obj) {
    var url = host + "/api/tcc/addMemberCorperateBYS";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}


async function GetUidDataTCCAsync(uid) {

    var url = host + "/api/tcc/getUidDataTCC/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET", undefined)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function UpdateUIDMapTCC(obj) {
    var url = host + "/api/tcc/updateUIDMapTCC";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function FileUpload(formData, uid) {

    var url = `${host}/api/tcc/fileUpload?uid=${uid}`;
    //var url = 'http://localhost:56955/api/tcc/fileUpload?uid=' + uid;
    //let result = await HttpRequestFetch(url, "POST", formData, "multipart/form-data");
    //LocalLogHttp("HTTP Res :" + result);

    try {
        let response = await fetch(url, {
            method: "POST",
            body: formData,
            headers: {
                //"Content-Type" : "multipart/form-data"
                // Content-Type is automatically set to multipart/form-data when FormData is used
            }
        });
        if (response.ok) {
            let result = await response.json();
            return result;
        } else {
            throw new Error("File upload failed");
        }
    } catch (error) {

        return error;
    }
}


//reward 15/08/2567
function GetRewardByID(rewardID) {
    var url = host + "/api/reward/" + rewardID;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function GetRewardDetailByRewardHeaderCode(ownerCode, programCode) {
    var url = host + "/api/reward/owner/" + ownerCode + "/" + programCode;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function GetRewardByOwnerCodeAndProgramCode(ownerCode, programCode) {
    var url = host + "/api/reward/program/" + ownerCode + "/" + programCode;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

function GetUIDMapRewardProgram(uid, ownerCode, programCode) {
    var url = host + "/api/reward/uid/" + uid + "/" + ownerCode + "/" + programCode + "/exist";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function SendRewardOTPAsync(obj) {
    var url = host + "/api/reward/otp/verify/step1";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function SendRewardConfirmOTP(obj) {
    var url = host + "/api/reward/otp/verify/step2";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, "POST", JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function CheckRewardCondition(uid, ownerCode, programCode) {
    var url = host + "/api/reward/condition/" + ownerCode + "/" + programCode + "/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

// NCB E-Consent Slip
function InsertENCBConsentSlipInfo(obj) {
    var url = host + "/api/encbconsentslip/step1";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function GetNCBHistory(idcard) {
    var url = host + "/api/ncb/history/" + idcard + "/score";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = HttpRequest(url, get)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
function InsertNCBPreRequest(obj) {
    var url = host + "/api/requestinfo/prendid/score/previous";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = HttpRequest(url, post, JSON.stringify(obj))
    LocalLogHttp("HTTP Res :" + result);
    return result;

}

//PDPA 23/11/2567 
async function GetActivePurposesAsync(uid) {
    var url = host + "/service/GetActivePurposes/" + uid + "/identifier";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function GetApprovedPurposeByIdentifier(uid) {
    var url = host + "/service/GetApprovedPurposeByIdentifier/" + uid + "/identifier";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function GetPurposesAll() {
    var url = host + "/service/PurposesGetAll"; 
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function SubmitConsent(obj) {
    var url = host + "/service/SubmitConsent";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj);
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function UpdateConsentPdpa(obj) {
    var url = host + "/api/UpdateConSentPdpa";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function UpdateConsentStatusAsync(obj) {
    // api / UpdateConsentStatus
    var url = host + "/api/UpdateConsentStatus";
    LocalLogHttp("HTTP Req : " + post + " : " + url);

    let result = await HttpRequestFetch(url, "POST", obj)
    LocalLogHttp("HTTP Res :" + result);
    return result;
}

async function GetUidTransFA(uid) {

    var url = host + "/api/debt/transaction/" + "uid/" + uid;
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;

}

//CAMPAIGNCONFIG
async function AsyncGetCampaignConfigBanner() {
    var url = host + "/campaignConfig/getCampaignConfigActive";
    LocalLogHttp("HTTP Req : " + get + " : " + url);

    let result = await HttpRequestFetch(url, "GET")
    LocalLogHttp("HTTP Res :" + result);
    return result;
}
