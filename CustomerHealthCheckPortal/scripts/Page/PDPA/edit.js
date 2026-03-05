let purposesLineOA = [];
let _genFromUpdate = [];
let _genFromUpdateStatus = [];
document.addEventListener("DOMContentLoaded", async function () {
    const purposesLoaded = await getPurposesAll();
    if (purposesLoaded) {
        console.log("Purposes loaded successfully");
    } else {
        console.log("Failed to load purposes");
    }
});

function checkChangeConsent() {
    var hddConsent1 = document.getElementById("hddConsent1")
    var hddConsent2 = document.getElementById("hddConsent2")
    var hddConsent3 = document.getElementById("hddConsent3")
    var hddConsentUpdate1 = document.getElementById("hddConsentUpdate1")
    var hddConsentUpdate2 = document.getElementById("hddConsentUpdate2")
    var hddConsentUpdate3 = document.getElementById("hddConsentUpdate3")
    var btnSubmitConsent = document.getElementById("btnSubmitConsent")

    btnSubmitConsent.classList.remove("gradient-gray")
    btnSubmitConsent.classList.remove("gradient-green")
    btnSubmitConsent.classList.add("disabledButton")

    if (hddConsent1.value == hddConsentUpdate1.value
        && hddConsent2.value == hddConsentUpdate2.value
        && hddConsent3.value == hddConsentUpdate3.value) {
        btnSubmitConsent.classList.add("gradient-gray");
    }
    else {
        btnSubmitConsent.classList.add("gradient-green");
        btnSubmitConsent.classList.remove("disabledButton");
    }
}

function Step1Consent() {
    var btnStep1 = document.getElementById("switch-1");
    var hddConsentUpdate1 = document.getElementById("hddConsentUpdate1");

    if (btnStep1.checked === true) {
        hddConsentUpdate1.value = "1";
    } else {
        hddConsentUpdate1.value = "0";
    }
    checkChangeConsent();
}

function Step2Consent() {
    var btnStep2 = document.getElementById("switch-2");
    var hddConsentUpdate2 = document.getElementById("hddConsentUpdate2");

    if (btnStep2.checked === true) {
        hddConsentUpdate2.value = "1";
    } else {
        hddConsentUpdate2.value = "0";
    }
    checkChangeConsent();
}

function Step3Consent() {
    var btnStep3 = document.getElementById("switch-3");
    var hddConsentUpdate3 = document.getElementById("hddConsentUpdate3");

    if (btnStep3.checked === true) {
        hddConsentUpdate3.value = "1";
    } else {
        hddConsentUpdate3.value = "0";
    }
    checkChangeConsent();

}

const container1 = document.getElementById("confirmUpdate");
const container2 = document.getElementById("notUpdate");
const modalConfirm = new bootstrap.Modal(container1);
const modalConfirm1 = new bootstrap.Modal(container2);

async function submitUpdateData() {

    try {
        //const result = await getPurposesAll();

        console.log("purposesLineOA", purposesLineOA);

        //console.log(result);

        if (purposesLineOA != null) {

            modalConfirm.show();
            console.log("ConfirmUpdate");
        }
        else {
            modalConfirm.show();
            console.log("GetPureposesFail");
        }

    } catch {

        modalConfirm.show();
        console.log("ConfirmUpdate false");

    }


}

function consentNotChange() {
    modalConfirm1.show();
    console.log("NotUpdate")
}

document.getElementById("switch-1").addEventListener("change", (event) => collape.call(event.target, "1"))
document.getElementById("switch-2").addEventListener("change", (event) => collape.call(event.target, "2"))
document.getElementById("switch-3").addEventListener("change", (event) => collape.call(event.target, "3"))

function collape(target) {
    //console.log(this.value)
    const bsCollapse = getShowHide("#collapse-list-" + target)                          // `#collapse-list-${target}` µèÍ String áººäÁèµéÍ§ºÇ¡ 
    //let consentDefault = document.getElementById('hddConsent' + target);              //String

    //console.log(this.checked)
    if (this.checked) {
        bsCollapse.show();
        //console.log(consentChange)
    }
    else {
        //console.log(bsCollapse)
        bsCollapse.hide();
    }


    let allSwitch = document.querySelectorAll("[id^='switch-']")
    let consentChange = false
    //console.log(consentChange)
    //console.log(allSwitch)
    for (var i = 0; i < allSwitch.length; i++) {

        let consentDefault = document.getElementById('hddConsent' + (i + 1));
        if (parseInt(consentDefault.value) !== ~~allSwitch[i].checked) {
            consentChange = true;
            break;
        }

    }
    if (consentChange) {
        document.getElementById("btnSubmitConsent").classList.remove("disabledButton");
        document.getElementById("btnSubmitConsent").onclick = submitUpdateData
    }
    else {
        document.getElementById("btnSubmitConsent").onclick = consentNotChange;
    }

}

function getShowHide(target) {
    const bsCollapse = new bootstrap.Collapse(target, {
        toggle: false
    })
    return bsCollapse
}

function OnOffSwitch1() {
    let SwitchConsent1 = document.getElementById('hddConsent1').value;           //String
    let Switch1 = document.getElementById('switch-1');                           //Control

    if (SwitchConsent1 === "1") {
        Switch1.checked = true;
        getShowHide('#collapse-list-1').show();
        document.getElementById("hddConsentUpdate1").value = "1";
    }
    else {
        //console.log(SwitchConsent1);
        Switch1.checked = false;
        document.getElementById("hddConsentUpdate1").value = "0";
    }
}

function OnOffSwitch2() {
    let SwitchConsent2 = document.getElementById('hddConsent2').value;          //String
    let Switch2 = document.getElementById('switch-2')                           //Control
    //let SwitchShowHide = document.getElementById('collapse-list-2');


    if (SwitchConsent2 === "1") {
        Switch2.checked = true;
        getShowHide('#collapse-list-2').show();
        document.getElementById("hddConsentUpdate2").value = "1";
    }
    else {
        //console.log(SwitchConsent2)
        Switch2.checked = false;
        document.getElementById("hddConsentUpdate2").value = "0";
    }
}

function OnOffSwitch3() {
    let SwitchConsent3 = document.getElementById('hddConsent3').value;          //String
    let Switch3 = document.getElementById('switch-3')                           //Control

    if (SwitchConsent3 === "1") {
        Switch3.checked = true;
        getShowHide('#collapse-list-3').show();
        document.getElementById("hddConsentUpdate3").value = "1";
    }
    else {
        //console.log(SwitchConsent3)
        Switch3.checked = false;
        document.getElementById("hddConsentUpdate3").value = "0";
    }
}

document.addEventListener("DOMContentLoaded", (event) => { OnOffSwitch1(); });
document.addEventListener("DOMContentLoaded", (event) => { OnOffSwitch2(); });
document.addEventListener("DOMContentLoaded", (event) => { OnOffSwitch3(); });

async function genFromUpdateStatus() {

    let modelUpdateStatus = [];

    let _uid = getCookie("uid");
    let _consent1 = document.getElementById("hddConsentUpdate1").value ?? ''
    let _consent2 = document.getElementById("hddConsentUpdate2").value ?? ''
    let _consent3 = document.getElementById("hddConsentUpdate3").value ?? ''

    modelUpdateStatus = {
        Uid: _uid,
        Consent1: _consent1,
        Consent2: _consent2,
        Consent3: _consent3
    };
    console.log('modelUpdateStatus', modelUpdateStatus)

    return modelUpdateStatus;

}

//GET ON PAGE LOAD
async function getPurposesAll() {

    try {
        const stringPorposesAll = await GetPurposesAll();
        let resultPorposes = JSON.parse(stringPorposesAll);
        let _resultPorposes = JSON.parse(resultPorposes);

        console.log(_resultPorposes);

        if (resultPorposes.Message == 'ErrorMessage : Unable to connect to the remote server') {
            return false;
            console.log('resultPorposes', 'fail api GetPurposesAll' + resultPorposes)
        };

        //let resultPorposesfinal = JSON.parse(resultPorposes);

        if (_resultPorposes.result != null) {

            let findresultPurposes = _resultPorposes.result.items.filter(i => i.purposeCategoryName === 'Customer');
            for (let i = 0; i < findresultPurposes.length; i++) {

                purposesLineOA.push(findresultPurposes[i].purpose);

                sessionStorage.setItem("consentId" + i, purposesLineOA[i].id);

            }
            return true;
        }
    }
    catch {
        return false;
        console.log("purposesLineOA", purposesLineOA);
    }

}

//STEP 2 GenFrom 
async function genFromUpdateConsent() {

    let _uid = getCookie("uid");
    let _emailLine = getCookie("uemail");
    let _configConsentPoint = document.getElementById("hddPDPAConsentPoint").value;

    const _consent1 = sessionStorage.getItem('consentId0');
    const _consent2 = sessionStorage.getItem('consentId1');
    const _consent3 = sessionStorage.getItem('consentId2');

    //console.log(_uid, _emailLine, _configConsentPoint);

    let geDataConsentData = {
        Consent1: document.getElementById("hddConsentUpdate1").value ?? '',
        Consent2: document.getElementById("hddConsentUpdate2").value ?? '',
        Consent3: document.getElementById("hddConsentUpdate3").value ?? ''
    };

    let objGenFrom = [];

    //console.log('geDataConsentData', geDataConsentData);

    if (_uid != null) {
        objGenFrom = {
            identifier: _uid,
            email: _emailLine ?? '',
            mobileNo: "-",
            otpType: 0,
            consentPoint: _configConsentPoint, // pdpaConsentPoint
            purposeConsent: [
                {
                    "id": _consent1,
                    "consentStatus": geDataConsentData.Consent1 == '1' ? true : false
                },
                {
                    "id": _consent2,
                    "consentStatus": geDataConsentData.Consent2 == '1' ? true : false
                },
                {
                    "id": _consent3,
                    "consentStatus": geDataConsentData.Consent3 == '1' ? true : false
                }
            ]
        };
        //console.log('obj', objGenFrom);
        return objGenFrom;
    };

    return objGenFrom;
}


//STEP 
async function updateConsentStatus(obj) {

    const data = obj;

    if (data != null) {


        console.log('data', data);

        const buffer = await UpdateConsentStatusAsync(data);
        const result = JSON.parse(buffer);

        console.log(result);

        if (result.RESULT_STATUS == "OK") {
            return true;
        }
        else {
            return false;
        }
    }

}

//STEP 2
async function sumbitConsent(obj) {

    let _uid = getCookie("uid");
    let _genFromUpdateStatus = {
        Uid: _uid,
        Consent1: document.getElementById("hddConsentUpdate1").value,
        Consent2: document.getElementById("hddConsentUpdate2").value,
        Consent3: document.getElementById("hddConsentUpdate3").value
    };
    console.log(_genFromUpdateStatus);
    //STEP 2.1 
    let resultUpdate = await updateConsentStatus(_genFromUpdateStatus);
    //console.log('resultUpdateStatus', resultUpdateStatus ? "complete" : "fail");

    if (resultUpdate == true) try {
        let formSubmit = obj;

        //STEP 2.2
        let buffer = await SubmitConsent(formSubmit);
        let resultSubmit = JSON.parse(buffer);
        let _resultSubmit = JSON.parse(resultSubmit);

        console.log(_resultSubmit);

        if (_resultSubmit.success == true) {

            return true;

        } else {

            return false;
        }

    } catch {

        return false;
    }

}

//STEP 1 MAIN
async function updatePDPAFunction() {

    let _FromResult = await genFromUpdateConsent();

    try {

        const result = await sumbitConsent(_FromResult);

        console.log(result);

        if (result == true) {
            swal("บันทึก", "บันทึกข้อมูลสำเร็จ", "success",
                {
                    className: "boxstyle",
                    buttons:
                        { New: { text: "กลับหน้าหลัก", value: "index", visible: true, }, },
                }).then((value) => {
                    switch (value) {
                        case "index":
                            redirectToMain();
                            break;
                        default:
                            redirectToMain();
                    }
                });
        } else {
            redirectToMain();
        }

    }
    catch {
        return false;
        console.log("purposesLineOA", purposesLineOA);
    }

}


