/** hidden filed */
let profileStatus = document.getElementById("ContentPlaceHolder1_hddProfileStatus").value
let profileInformation = document.getElementById("ContentPlaceHolder1_hddProfileInformation").value
let profileRegisterNo = document.getElementById("ContentPlaceHolder1_hddProfileRegisterNo").value
let memberStatusTh = '';
let jsonAddress = JSON.parse((document.getElementById("ContentPlaceHolder1_hddJsonAddress").value));
let acceptCondition = document.getElementById("ContentPlaceHolder1_hddacceptCondition").value;


console.log(profileStatus);
console.log(profileInformation);
console.log(profileRegisterNo);
//console.log(jsonAddress);


let objRegister = [];
let objInformation = [];
let objAddress = [];
let objAPIPayload = [];
let objDocumentFile = [];
let objResultUIDMapTCC = [];
let objResultStatusMemberTCC = [];
let objResultStatusMemberTCCGroupList = [];
let objResultInformation = [];
let objResultFileUploadPerson = [];
let objResultFileUploadJurustic = [];
let payloadA = [];
let payloadB = [];
let objRepeatProcess = [];


document.getElementById('ddlOccupation').addEventListener('change', function () {
    let option1Details = document.getElementById("option1Details");
    // ซ่อนทุกแท็กก่อน
    option1Details.style.display = "none"
    // เปิดแท็กตามค่าที่เลือก
    if (this.value === '2') {
        option1Details.style.display = "block"
    }
});
document.getElementById('ddlBussinessType').addEventListener('change', function () {
    const option2Details = document.getElementById("option2Details");
    // ซ่อนทุกแท็กก่อน
    option2Details.style.display = "none"
    // เปิดแท็กตามค่าที่เลือก
    if (this.value === 'EX') {
        option2Details.style.display = "block"
    }
})

document.getElementById('ddlProvinceTH').addEventListener('change', function () {

    // Get the dropdown element
    const dropdownProvince = document.getElementById('ddlProvinceTH');
    const dropdownAmphurs = document.getElementById('ddlAmphurTH');
    const dropdownTumbol = document.getElementById('ddlTambolTH');
    const dropdownZipcode = document.getElementById('ddlZipcode')

    dropdownAmphurs.innerHTML = ''
    dropdownTumbol.innerHTML = ''
    dropdownZipcode.innerHTML = ''

    //เปลี่ยน อำเภอ จาก จังหวัด
    let province = dropdownProvince.value
    let amphurs = jsonAddress.filter(t => t.ProvinceName == province).map(t => t.Aumpur).filter((value, index, self) => self.indexOf(value) === index);

    // Bind the array to the dropdown
    amphurs.forEach(option => {
        // Create a new option element
        let opt = document.createElement('option');
        opt.value = option;  // Set the value
        opt.text = option;   // Set the display text

        // Append the option to the dropdown
        dropdownAmphurs.appendChild(opt);
    });


    //เปลี่ยนค่า ตำบล จาก อำเภอ

    let amphur = dropdownAmphurs.value
    let tumbols = jsonAddress.filter(t => t.Aumpur == amphur && t.ProvinceName == province).map(t => t.Tumbol).filter((value, index, self) => self.indexOf(value) === index);

    tumbols.forEach(option => {
        // Create a new option element
        let opt = document.createElement('option');
        opt.value = option;  // Set the value
        opt.text = option;   // Set the display text

        // Append the option to the dropdown
        dropdownTumbol.appendChild(opt);
    });


    //เปลี่ยนค่า รหัสไปรษณีย์ จาก ตำบล
    let tumbol = dropdownTumbol.value
    let zipcodes = jsonAddress.filter(t => t.Tumbol == tumbol && t.ProvinceName == province && t.Aumpur == amphur).map(t => t.Postcode).filter((value, index, self) => self.indexOf(value) === index);

    zipcodes.forEach(option => {
        // Create a new option element
        let opt = document.createElement('option');
        opt.value = option;  // Set the value
        opt.text = option;   // Set the display text

        // Append the option to the dropdown
        dropdownZipcode.appendChild(opt);
    });

});

document.getElementById('ddlAmphurTH').addEventListener('change', function () {

    // Get the dropdown element

    const dropdownAmphurs = document.getElementById('ddlAmphurTH');
    const dropdownTumbol = document.getElementById('ddlTambolTH');
    const dropdownZipcode = document.getElementById('ddlZipcode')
    const dropdownProvince = document.getElementById('ddlProvinceTH');

    dropdownTumbol.innerHTML = ''
    dropdownZipcode.innerHTML = ''
    //dropdownProvice.innerHTML = ''


    //เปลี่ยนค่า ตำบล จาก อำเภอ
    let province = dropdownProvince.value
    let amphur = dropdownAmphurs.value
    let tumbols = jsonAddress.filter(t => t.Aumpur == amphur && t.ProvinceName == province).map(t => t.Tumbol).filter((value, index, self) => self.indexOf(value) === index);

    tumbols.forEach(option => {
        // Create a new option element
        let opt = document.createElement('option');
        opt.value = option;  // Set the value
        opt.text = option;   // Set the display text

        // Append the option to the dropdown
        dropdownTumbol.appendChild(opt);
    });


    //เปลี่ยนค่า รหัสไปรษณีย์ จาก ตำบล
    let tumbol = dropdownTumbol.value
    let zipcodes = jsonAddress.filter(t => t.Tumbol == tumbol && t.ProvinceName == province && t.Aumpur == amphur).map(t => t.Postcode).filter((value, index, self) => self.indexOf(value) === index);

    zipcodes.forEach(option => {
        // Create a new option element
        let opt = document.createElement('option');
        opt.value = option;  // Set the value
        opt.text = option;   // Set the display text

        // Append the option to the dropdown
        dropdownZipcode.appendChild(opt);
    });


});

document.getElementById('ddlTambolTH').addEventListener('change', function () {

    // Get the dropdown element
    const dropdownAmphurs = document.getElementById('ddlAmphurTH');
    const dropdownTumbol = document.getElementById('ddlTambolTH');
    const dropdownZipcode = document.getElementById('ddlZipcode')
    const dropdownProvince = document.getElementById('ddlProvinceTH');
    dropdownZipcode.innerHTML = '';


    //เปลี่ยนค่า รหัสไปรษณีย์ จาก ตำบล
    let province = dropdownProvince.value
    let amphur = dropdownAmphurs.value
    let tumbol = dropdownTumbol.value
    let zipcodes = jsonAddress.filter(t => t.Tumbol == tumbol && t.ProvinceName == province && t.Aumpur == amphur).map(t => t.Postcode).filter((value, index, self) => self.indexOf(value) === index);

    zipcodes.forEach(option => {
        // Create a new option element
        let opt = document.createElement('option');
        opt.value = option;  // Set the value
        opt.text = option;   // Set the display text

        // Append the option to the dropdown
        dropdownZipcode.appendChild(opt);
    });

});

//Tic Upload Person
document.getElementById('documentDCFile').addEventListener('change', function () {
    handleFileUpload('documentDCFile');
});
document.getElementById('documentDBFile').addEventListener('change', function () {

    handleFileUpload('documentDBFile')
});
document.getElementById('documentCHFile').addEventListener('change', function () {

    handleFileUpload('documentCHFile')
});
document.getElementById('documentPLFile').addEventListener('change', function () {

    handleFileUpload('documentPLFile')
});
//Tic Upload Jurustic
document.getElementById('documentIDCardFile').addEventListener('change', function () {

    handleFileUpload('documentIDCardFile')
});
document.getElementById('documentOJFile').addEventListener('change', function () {

    handleFileUpload('documentOJFile')
});
document.getElementById('documentPPFile').addEventListener('change', function () {

    handleFileUpload('documentPPFile')
});
document.getElementById('documentISFile').addEventListener('change', function () {

    handleFileUpload('documentISFile')
});

function handleFileUpload(fileInputId) {
    const fileInput = document.getElementById(fileInputId);
    const file = fileInput.files[0];

    if (file) {
        const fileSizeMB = file.size / (1024 * 1024); // Convert bytes to MB
        const fileName = file.name;
        const fileExtension = fileName.split('.').pop().toLowerCase(); // Get file extension and convert to lowercase
        const allowedExtensions = ['pdf', 'jpg'];

        if (fileSizeMB > 5) {
            Swal.fire("แจ้งเตือน", "ขนาดไฟล์มากกว่า 5 MB", "warning");
            fileInput.value = '';
        } else if (!allowedExtensions.includes(fileExtension)) {
            Swal.fire("แจ้งเตือน", "อนุญาตเฉพาะไฟล์ PDF และ JPG เท่านั้น", "warning");
            fileInput.value = ''; // Reset input
        }
        else {
            console.log(fileInput.value);
        }
    }
}

function validateAcceptConsent() {

    let radioAcceptTerm = document.querySelectorAll("input[type=checkbox]");

    if (radioAcceptTerm[0].checked === true) {
        return true;
    } else {
        return false;
    }
}

function submitConsent() {
    let isReadTAndC = validateAcceptConsent();
    if (isReadTAndC) {

        acceptCondition.value = "1";
        //LocalLog("Step 1 : Validate Is Read Term & Condition : " + isReadTAndC);
        RedirectTo("informationDetailPage");

    } else {
        Swal.fire('แจ้งเตือน', 'กรุณาอ่านเงื่อนไขบริการทั้งหมดก่อนยืนยันรับทราบเงื่อนไข', 'warning');
    }
}

function disableButton(action, elementID) {

    console.log("Disable button");

    let btnElement = document.getElementById(`${elementID}`);
    //let btnBackStep4 = document.getElementById("btnBackStep4");

    if (action == "disable") {
        btnElement.classList.add("btn-disable");
        btnElement.classList.remove("gradient-blue");
    } else {
        btnElement.classList.remove("btn-disable");
        btnElement.classList.add("gradient-blue");
    }
}

function enableButton(action, elementID) {

    console.log("Enable button");

    let btnElement = document.getElementById(`${elementID}`);

    if (action == "enable") {
        btnElement.classList.remove("btn-disable");
        btnElement.classList.add("gradient-blue");
    } else {
        btnElement.classList.add("btn-disable");
        btnElement.classList.remove("gradient-blue");
    }
}

let modalCheckConfirm;
let modalConfirmInformation;

document.addEventListener("DOMContentLoaded", () => {

    const container1 = document.getElementById("checkRegisterModalTCC");
    const container2 = document.getElementById("confirmInformation");

    // ตรวจสอบว่า Modal มีอยู่ในหน้า HTML จริงหรือไม่
    if (container1) {
        modalCheckConfirm = new bootstrap.Modal(container1);

        container1.addEventListener('hide.bs.modal', () => {
            document.activeElement.blur(); // บังคับให้ย้ายโฟกัสออกไปจากปุ่มที่คลิก
        });

        // เพิ่ม Event Listener ให้กับปุ่มที่ต้องการยืนยัน
        const btnSubmit = document.getElementById("btnSubmitIdCard");
        if (btnSubmit) {
            btnSubmit.addEventListener("click", (event) => {
                event.preventDefault(); // ป้องกันการ Redirect โดยค่าเริ่มต้น
                SubmitIdCard(); // เรียกใช้งานฟังก์ชันก่อนซ่อน Modal
            });
        };
    };
    if (container2) {
        modalConfirmInformation = new bootstrap.Modal(container2);
    }
});

/** Second Step*/
let tccContanier1 = document.getElementById("checkRegisterModalTCC");

tccContanier1.addEventListener('hide.bs.modal', () => {
    document.activeElement.blur();
});

function ShowModalTCC() {

    if (modalCheckConfirm) {
        modalCheckConfirm.show();
    } else {
        console.error("ไม่พบ Modal ที่มี ID: checkRegisterModalTCC");
    }

}

function ShowModalConfirmInformation() {

    if (modalConfirmInformation) {
        modalConfirmInformation.show();

    } else {
        console.error("ไม่พบ Modal ที่มี ID: confirmInformation");
    }
}

async function getRegisterDataAndGenFrom(Uid) {

    const uid = Uid
    const result = false
    if (uid == null || uid == undefined || uid == 'undefined') return SwalCaseTCC("1");

    const buffer = await GetUidDataTCCAsync(uid)
    //console.log(buffer)
    const bufferResult = JSON.parse(buffer);
    //console.log(bufferResult);

    if (bufferResult.RESULT_STATUS == 'OK' && bufferResult.RESULT_OBJ[0].InformationId != null) {

        objRepeatProcess = {
            TransID: bufferResult.RESULT_OBJ[0].TransID
        }

        const resultData = bufferResult.RESULT_OBJ[0];

        const resultGen = GenPreviewMemberStatus(resultData);

        return resultGen;
    }

    return result;

}

document.addEventListener("DOMContentLoaded", async () => {

    const pagelist = document.getElementById("myElement")?.classList.add("myClass");
    const uid = getCookie("uid");
    //registerRepeatAPI : registerComplete : neverRegister
    //profileInformation

    console.log(jsonAddress);

    console.log("profileStatus :", profileStatus);

    if (profileStatus == 'neverRegister') {

        RedirectTo("consentPage");
    }
    if (profileStatus == 'registerRepeatAPI') {

        const dataRepeatAPI = await getRegisterDataAndGenFrom(uid);
        if (dataRepeatAPI === true) {
            SwalCaseTCC("5");
        }
    }
    if (profileStatus == 'registerComplete') {

        const resultMemberApi = await CheckMemberStatusTCC(profileRegisterNo);
        if (resultMemberApi == true) {
            genPreviewDataFormAPI(objResultStatusMemberTCC);
            RedirectTo("TCCMemberStatusPage")
        }
        else {
            const resultGet = getRegisterDataAndGenFrom(uid)
            if (resultGet === true) {
                RedirectTo("TCCMemberStatusPage")
            }
        }
    }
})
async function getMemberStatus(registerNo) {

    const buffer = await GetMemberStatusBYSAsync(registerNo)

    console.log('resultgetMemberStatus', buffer);

    if (buffer != null) {
        return buffer
    }
    else {
        SwalCaseTCC("6");
    }
}
function SwalCaseTCC(show) {
    switch (show) {
        case "1":
            Swal.fire("แจ้งเตือน", "การเชื่อมต่อขัดข้อง", "warning",
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
            Swal.fire("แจ้งเตือน", "การบันทึกข้อมูลขัดข้อง", "warning",
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
            Swal.fire("ลงทะเบียน", "บันทึกข้อมูลสำเร็จ", "success",
                {
                    className: "boxstyle",
                    buttons:
                        { New: { text: "ดูข้อมูลสมาชิก", value: "index", visible: true, }, },
                }).then((value) => {
                    switch (value) {
                        case "index":
                            RedirectTo("TCCMemberStatusPage")
                            break;
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "4":
            Swal.fire("แจ้งเตือน", "ข้อมูลที่บันทึกไม่สามารถส่งใบสมัครได้", "warning",
                {
                    className: "boxstyle",
                    buttons:
                    {
                        btn1: { text: "ลงทะเบียนข้อมูลใหม่", value: "repeat", visible: true, }
                        //,btn2: { text: "ดูข้อมูลสมาชิก", value: "index", visible: true, }
                    },
                }).then((value) => {
                    switch (value) {
                        case "index":
                            RedirectTo("TCCMemberStatusPage")
                            break;
                        case "repeat":
                            RedirectTo("informationDetailPage")
                            break;
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "5":
            Swal.fire("พบประวัติการลงทะเบียน", "โหลดข้อมูลสำเร็จ", "success",
                {
                    className: "boxstyle",
                    buttons:
                        { New: { text: "สถานะข้อมูลสมาชิก", value: "index", visible: true, }, },
                }).then((value) => {
                    switch (value) {
                        case "index":
                            RedirectTo("TCCMemberStatusPage")
                            break;
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "6":
            Swal.fire("ไม่สามารถเชื่อมต่อ", "โหลดข้อมูลสมาชิกไม่สำเร็จ", "warning",
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
        case "7":
            Swal.fire("เกิดข้อผิดพลาด", "อัพโหลดไฟล์ไม่สำเร็จ", "warning",
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
        case "8":
            Swal.fire({
                title: "ผลการทดสอบ",
                html: `คุณยังไม่ได้ เข้าร่วม <br> "โครงการสนั่นสิทธิ์ <br> (ต้องเป็นสมาชิก บสย.<br> และสมาชิกหอการค้าไทย)`,
                icon: "info",
                showCancelButton: true,
                confirmButtonText: "สมัครสภาหอการค้า",
                cancelButtonText: "กลับสู่หน้าหลัก",
                customClass: {
                    confirmButton: "btn btn-primary",
                    cancelButton: "btn btn-info"
                },
                buttonsStyling: false,
                reverseButtons: false
            }).then((result) => {
                if (result.isConfirmed) {
                    redirectToRegisterTCC();
                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    redirectToMain();
                }
            });
            break;
        case "8":
            Swal.fire({
                title: "ผลการทดสอบ",
                html: `คุณยังไม่ได้ เข้าร่วม <br> "โครงการสนั่นสิทธิ์ <br> (ต้องเป็นสมาชิก บสย.<br> และสมาชิกหอการค้าไทย)`,
                icon: "info",
                showCancelButton: true,
                confirmButtonText: "สมัครสภาหอการค้า",
                cancelButtonText: "กลับสู่หน้าหลัก",
                customClass: {
                    confirmButton: "btn btn-primary",
                    cancelButton: "btn btn-info"
                },
                buttonsStyling: false,
                reverseButtons: false
            }).then((result) => {
                if (result.isConfirmed) {
                    redirectToRegisterTCC();
                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    redirectToMain();
                }
            });
            break;

        case "9":
            Swal.fire("ผลการตรวจสอบ", "ไม่มีข้อมุูลรายการบัตร", "success",
                {
                    className: "boxstyle",
                    buttons:
                    {
                        btn1: { text: "กลับสู่หน้าหลัก", value: "", visible: true, }
                    },
                }).then((value) => {
                    switch (value) {
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "10":
            Swal.fire("ผลการทดสอบ", `คุณยังไม่ได้ เข้าร่วม "โครงการสนั่นสิทธิ์"(ต้องเป็นสมาชิก บสย.และสมาชิกหอการค้าไทย)`, "warning",
                {
                    className: "boxstyle",
                    buttons:
                    {
                        btn1: { text: "กลับสู่หน้าหลัก", value: "", visible: true, }
                    },
                }).then((value) => {
                    switch (value) {
                        default:
                            redirectToMain();
                    }
                });
            break;
        case "11":
            Swal.fire({
                title: "ผลการทดสอบ",
                html: `คุณยังไม่ได้ เข้าร่วม <br> "โครงการสนั่นสิทธิ์ <br> (ต้องเป็นสมาชิก บสย.<br> และสมาชิกหอการค้าไทย)`,
                icon: "info",
                confirmButtonColor: '#5D9CEC',
                confirmButtonText: "กลับหน้าหลัก",
                denyButton: { New: { text: "กลับสู่หน้าเมนูหลัก", value: "index", visible: true, }, },
            }).then((value) => {
                switch (value) {
                    default:
                        redirectToMain();
                }
            });
            break;
        case "12":
            Swal.fire({
                title: "ผลการตรวจสอบ",
                html: `กรุณาเข้าสู่ระบบ <br> ด้วยหมายเลขบัตร <br> ประชาชนของท่าน`,
                icon: "info",
                confirmButtonColor: '#5D9CEC',
                confirmButtonText: "ลองใหม่อีกครั้ง",
                denyButton: { New: { text: "ลองใหม่อีกครั้ง", value: "index", visible: true, }, },
            }).then((value) => {
                switch (value) {
                    default:
                        let txtIdentityId = document.getElementById("txtIdentityId")
                        txtIdentityId.value = '';

                        enableButton('enable', 'btnSubmitIDcard');
                }
            });
            break;
        default:
            break;
    }
}
function RedirectTo(step) {

    let pnlbackStep = document.getElementById("backStep");
    let pnlInformaiton = document.getElementById("pnlInformation")
    let pnlFillIdCard = document.getElementById("pnlFillIdCard")
    let pnlRegisterMemberTCCPerson = document.getElementById("pnlRegisterMemberTCCPerson")
    let pnlRegisterMemberTCCJuristic = document.getElementById("pnlRegisterMemberTCCJuristic")
    let pnlRegisterMemberAddress = document.getElementById("pnlRegisterMemberAddress")
    let pnlRegisterMemberFileUpload = document.getElementById("pnlRegisterMemberFileUpload")
    let pnlTCCMemberStatusPage = document.getElementById("pnlTCCMemberStatusPage")
    let pnlConsent = document.getElementById("pnlConsent")

    switch (step) {

        case "consentPage":
            pnlConsent.style.display = "block"
            pnlbackStep.style.display = "block"
            pnlInformaiton.style.display = "none" // test
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "none" // test
            break;


        case "informationDetailPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "none"
            pnlInformaiton.style.display = "block" // test
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "none" // test
            break;

        case "FillIdPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "block";
            pnlInformaiton.style.display = "none";
            pnlFillIdCard.style.display = "block";
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "none"
            break;

        case "RegisterMemberTCCPersonPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "none"
            pnlInformaiton.style.display = "none"
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "block"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "none"
            break;
        case "RegisterMemberAddressPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "none"
            pnlInformaiton.style.display = "none"
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "block"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "none"
            break;
        case "RegisterMemberTCCJuristicPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "none"
            pnlInformaiton.style.display = "none"
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "block"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "none"
            break;
        case "RegisterMemberFileUploadPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "none"
            pnlInformaiton.style.display = "none"
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "block"
            pnlTCCMemberStatusPage.style.display = "none"
            break;
        case "TCCMemberStatusPage":
            pnlConsent.style.display = "none"
            pnlbackStep.style.display = "none"
            pnlInformaiton.style.display = "none"
            pnlFillIdCard.style.display = "none"
            pnlRegisterMemberTCCPerson.style.display = "none"
            pnlRegisterMemberTCCJuristic.style.display = "none"
            pnlRegisterMemberAddress.style.display = "none"
            pnlRegisterMemberFileUpload.style.display = "none"
            pnlTCCMemberStatusPage.style.display = "block"
            break;
        default:
            SwalCaseTCC("1")
            break;
    }
}
function SubmitInformation(_type) {

    const typeRegister = _type
    //console.log(typeRegister);

    objRegister = {
        RegisterForm: typeRegister
    }

    console.log('objRegister', objRegister);

    RedirectTo("FillIdPage");

}
function Script_checkID(id) {
    //console.log(typeof(id))
    if (!IsNumeric(id)) return false;
    if (id.substring(0, 1) == 0) return false;
    if (id.length != 13) return false;
    for (i = 0, sum = 0; i < 12; i++)
        sum += parseFloat(id.charAt(i)) * (13 - i);
    if ((11 - sum % 11) % 10 != parseFloat(id.charAt(12))) return false;
    return true;
}
function IsNumeric(input) {
    var RE = /^-?(0|INF|(0[1-7][0-7]*)|(0x[0-9a-fA-F]+)|((0|[1-9][0-9]*|(?=[\.,]))([\.,][0-9]+)?([eE]-?\d+)?))$/;
    return (RE.test(input));
}

/** New Flow Step 1 */
function ConditionValidateIdentityFieldTCC() {

    //LocalLog("Start : ConditionValidateIdentityField")

    let txtIdentityId = document.getElementById("txtIdentityId").value;

    parseInt(txtIdentityId);
    //console.log(txtIdentityId)
    let result = false

    if (objRegister.RegisterForm == "1") {

        const resultCheck = Script_checkID(txtIdentityId);
        if (resultCheck == true) {
            result = true;
        }
        return (result);
    }
    if (objRegister.RegisterForm == "2") {
        if (txtIdentityId == '') {
            result = false;
        }
        //if (txtIdentityId.value.substring(0, 1) != 0) {
        //    result = false;
        //}
        if (txtIdentityId.length < 13 || txtIdentityId.length > 13) {
            result = false;
        }
        if (txtIdentityId.length == 13) {
            result = true;
            return (result);
        }
        return (result);
    }
    return (result);
}
function ValidateIdentityCard() {


    //ต้องการ Valid
    //let validatefiledIdentityCard = ConditionValidateIdentityFieldTCC();
    ////console.log("validatefiledIdentityCard :" + validatefiledIdentityCard);

    //if (validatefiledIdentityCard == true) {
    //    ShowModal();
    //}
    //else {
    //    return Swal.fire("แจ้งเตือน", "กรอกหมายเลขไม่สมบูรณ์", "warning",);
    //}

    // ไม่ต้องการ Valid
    let txtIdentityId = document.getElementById("txtIdentityId").value;

    const checkIdentity = Script_checkID(txtIdentityId); 

    if (checkIdentity === true) {
        ShowModalTCC();

    } else {
        return Swal.fire({
            title: "",
            html: `กรุณาเข้าสู่ระบบ <br> ด้วยหมายเลขบัตร <br> ประชาชนของท่าน`,
            icon: "warning",
            showCancelButton: false,
            confirmButtonText: "ลองใหม่อีกครั้ง"
        });
    }
}
function GenInsertUidMapTCC(fillCardId) {

    const uid = getCookie("uid");
    const identityId = fillCardId;
    const status = true;
    const isAcceptConsent = null;
    const informationId = null;
    const otpDummyId = null;
    const isRegisterSuccess = false;

    const obj = {
        Uid: uid,
        IdentityId: identityId,
        Status: status,
        IsAcceptConsent: isAcceptConsent,
        InformationId: informationId,
        OtpDummyId: otpDummyId,
        IsRegisterSuccess: isRegisterSuccess
    }

    return obj;

}
async function CheckMemberStatusTCC(IdentityId) {

    const getStatusMember = await GetMemberStatusBYSAsync(IdentityId)

    const resultStatusMember = JSON.parse(getStatusMember);

    if (resultStatusMember == null || resultStatusMember == undefined) return SwalCaseTCC("1");

    // ไม่เป้น สมาชิก บสย. คส 2,3,5 (ไม่เป็นสมช.บสย.) แสดงว่า id ลูกค้าเหล่านั้น จะต้องถูกดักและได้รับ error message จากทางบสย. ซึ่งบสย.ต้องว่า journey เพิ่มว่าจะแจ้งลูกค้าอย่างไร และนั่นหมายถึง MR เราไม่ต้อง process อะไรกับกรณี 2,3,5 นี้
    if (resultStatusMember.Items.isTCG === false) {
        return '11';
    }

    //เป็น สมาชิก แต่ไม่มีข้อมุูลรายการบัตร
    if (!resultStatusMember.Items.MemberRegisno) {
        return '9';
    };
    //
    if (resultStatusMember.Items.MemberRegisno.startsWith("0")) {
        return '12';
    };

    //console.log(resultStatusMember)
    //console.log(resultStatusMember.Items)
    //console.log(resultStatusMember.Items.MemberGroupList.length)

    if (resultStatusMember.Items.MemberGroupList != null) {
        if (resultStatusMember.Items.MemberGroupList.length > 0) {

            //API SENT MORE 1 IN LIST. CHECK THIS FOR RESULTAPI IN PERSON AND JURUSTIC WHAT? IS UPDATE STATUS LAST 
            /**สอบถามไปที่ไลน์ วันที่ 14/08/2567 เวลา 16.25 นำคำตอบกลับมาเพื่อเอาค่าอัพเดท ล่าสุด */
            const lastMemberGroupList = resultStatusMember.Items.MemberGroupList.length - 1 //ปัจจุบันเลือก 0 เป็นข้อมูล หลัก

            objResultStatusMemberTCCGroupList.push(resultStatusMember.Items.MemberGroupList[lastMemberGroupList]);
        }
    }
    //console.log('objResultStatusMemberTCCGroupList', objResultStatusMemberTCCGroupList);

    objResultStatusMemberTCC = {
        MemberRegisno: resultStatusMember.Items.MemberRegisno,
        MemberType: resultStatusMember.Items.MemberType,
        MemberTaxId: resultStatusMember.Items.MemberTaxId,
        MemberCompanyType: resultStatusMember.Items.MemberCompanyType,
        MemberTName: resultStatusMember.Items.MemberTName,
        MemberEName: resultStatusMember.Items.MemberEName,
        MemberFirstName: resultStatusMember.Items.MemberFirstName,
        MemberLastName: resultStatusMember.Items.MemberLastName,
        MemberLineID: resultStatusMember.Items.MemberLineID,
        MemberCard: resultStatusMember.Items.MemberCard,
        MemberImage: resultStatusMember.Items.MemberImage,
        // MemberGroupList เป็น [] หาวิธีนำ ค่าจาก API มาใส่ ใน obj นี้
        MemberGroupList: objResultStatusMemberTCCGroupList,
        TransactionId: resultStatusMember.TransactionId
    }
    console.log('objResultStatusMemberTCC', objResultStatusMemberTCC)

    if (resultStatusMember.Code == '200') {

        const obj = {
            Id: objResultUIDMapTCC.ID,
            IsMemberTCC: true,
            MemberTCCStatus: objResultStatusMemberTCC.MemberGroupList[0].MemberStatus ?? '',
            TransactionId: objResultStatusMemberTCC.TransactionId
        };

        try {
            const bufferUpdate = await UpdateUIDMapTCC(obj);
            if (bufferUpdate != null) {
                const resultbufferUpdate = JSON.parse(bufferUpdate);
                console.log('bufferUpdate', resultbufferUpdate);
                return true;
            }
        } catch (error) {
            console.error("UpdateUIDMapTCC Error", error);
            return false;
        }
    }
    if (resultStatusMember.Code == '350') {

        const obj = {
            Id: objResultUIDMapTCC.ID,
            IsMemberTCC: false,
            //MemberTCCStatus: objResultStatusMemberTCC.MemberGroupList[0].MemberStatus,
            TransactionId: objResultStatusMemberTCC.TransactionId
        };

        try {
            const bufferUpdate = await UpdateUIDMapTCC(obj);
            if (bufferUpdate != null) {
                const resultbufferUpdate = JSON.parse(bufferUpdate);
                console.log('bufferUpdate', resultbufferUpdate);
                return false;
            }
        } catch (error) {
            console.error("UpdateUIDMapTCC Error", error);
            return false;
        }
    }

    return false
}
function changeTCCMemberStatus(status) {

    //สถานะของสมาชิก
    //FR = ติดตามต่ออายุ
    //WS = รอสิ้นสภาพ
    //ES = ยกเว้นสิ้นสภาพ
    //SO = สิ้นสภาพ
    //MB = เป็นสมาชิก
    //WR = แจ้งต่ออายุ
    //RS = ลาออก
    //C  = อยุ่ระหว่างการตรวจสอบ

    switch (status) {
        case "FR":
            memberStatusTh = "ติดตามต่ออายุ"
            break;
        case "WS":
            memberStatusTh = "รอสิ้นสภาพ"
            break;
        case "ES":
            memberStatusTh = "ยกเว้นสิ้นสภาพ"
            break;
        case "SO":
            memberStatusTh = "สิ้นสภาพ"
            break;
        case "MB":
            memberStatusTh = "เป็นสมาชิก"
            break;
        case "WR":
            memberStatusTh = "แจ้งต่ออายุ"
            break;
        case "RS":
            memberStatusTh = "ลาออก"
            break;
        case "C":
            memberStatusTh = "อยู่ระหว่างการตรวจสอบ"
            break;
        case "IP":
            memberStatusTh = "อยู่ระหว่างสมัครสมาชิกหอฯ"
            break;
        case "EP":
            memberStatusTh = "สมาชิกคุณ หมดอายุ ติดต่อหอฯ"
            break;
        default:
            memberStatusTh = "ไม่สามารถแสดงสถานะปัจจุบันได้"
    }
}
async function genPreviewDataFormAPI(obj) {
    const uid = getCookie("uid");
    const buffer = await GetUidDataTCCAsync(uid)
    //console.log(buffer)
    const bufferResult = JSON.parse(buffer);
    console.log('genPreviewDataFormAPI', bufferResult);

    //const txtMemberName = document.getElementById("txtMemberName")
    //const txtRegisterNo = document.getElementById("txtRegisterNo")
    //const txtMemberMobileContact = document.getElementById("txtMemberMobileContact")
    const txtTypeFrom = document.getElementById("txtTypeFrom");
    const txtMemberStatusLast = document.getElementById("txtMemberStatusLast");
    let txtImageCardId = document.getElementById("txtImageCardId");
    let txtImageCardName = document.getElementById("txtImageCardName");
    let pnlbackStep = document.getElementById("backStep");
    let txtImageCardLicen = document.getElementById("txtImageCardLicen");
    let txtImageTName = document.getElementById("txtImageTName");
    let txtImageTittleRisno = document.getElementById("txtImageTittleRisno");
    let txtImageRisno = document.getElementById("txtImageRisno");
    let txtImageExpDateTittle = document.getElementById("txtImageExpDateTittle");
    let txtImageExpDate = document.getElementById("txtImageExpDate");
    let txtImagePerson = document.getElementById("txtImagePerson");

    let _tccCardImage = document.getElementById("tcccardimage");
    let _tccOverlay1 = document.getElementById("tccOverlay1");
    let _tccOverlay2 = document.getElementById("tccOverlay2");
    let _tccOverlay3 = document.getElementById("tccOverlay3");
    let _tccOverlay4 = document.getElementById("tccOverlay4");
    let _tccOverlay5 = document.getElementById("tccOverlay5");
    let _tccOverlay6 = document.getElementById("tccOverlay6");
    let _tccOverlay7 = document.getElementById("tccOverlay7");
    let _tccProfileImage = document.getElementById("tccprofileImage");


    const data = obj

    const APIMemberstatus = document.getElementById("APIMemberstatus")
    let _memberStatusTh = ''

    if (data.MemberGroupList[0].MemberStatus != null && data.MemberGroupList[0].MemberStatus != undefined) {
        changeTCCMemberStatus(data.MemberGroupList[0].MemberStatus)
        _memberStatusTh = memberStatusTh
    }

    let _memberstatusDate = formatDate(data.MemberGroupList[0].MemberGroupExpireDate)
    if (_memberstatusDate == '1970-01-01') {
        _memberstatusDate = '-';
    }

    //txtMemberName.textContent = data.MemberTName

    //txtRegisterNo.textContent = data.MemberRegisno

    //txtMemberMobileContact.textContent = bufferResult.RESULT_OBJ[0].mobile ?? "-", bufferResult.RESULT_OBJ[0].mobile;

    txtTypeFrom.textContent = (!data.MemberType || data.MemberType === "null") ? "-" : data.MemberType;
    ;
    //txtMemberStatusLast.textContent = data.MemberGroupList[0].MemberStatusDesc;

    if (data.MemberRegisno != null) {
        txtMemberStatusLast.textContent = _memberStatusTh;

        APIMemberstatus.innerHTML += `<a style=""><i class="bi bi-list color-green-drak"></i>&nbsp;ชื่อของกลุ่มสมาชิก</a><br /><a style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong  style="color: dodgerblue">${data.MemberGroupList[0].MemberGroupName}</strong></a><br />`;
        //APIMemberstatus.innerHTML += `<a style=""><i class="bi bi-list color-green-drak"></i>&nbsp;=วันที่หมดอายุของกลุ่มสมาชิก</a><br /><a style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong  style="color: dodgerblue">${_memberstatusDate}</strong></a><br />`;
        //APIMemberstatus.innerHTML += `<a style=""><i class="bi bi-list color-green-drak"></i>&nbsp;=สถานะของสมาชิก</a><br /><a style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong  style="color: dodgerblue">${_memberStatusTh}</strong></a><br />`;

        APIMemberstatus.style.display = 'block'

        btnMemberStatus("registerComplete");
    }

    if (data.MemberCard == null) {
        pnlbackStep.style.display = "block";
        btnMemberStatus("waitRegister");
        const linkElement = document.querySelector('a[href="btnBackPageMemberStatusPage"]');

        // ตรวจสอบว่าพบ element หรือไม่ แล้วทำการลบออก
        if (linkElement) {
            linkElement.remove();
        }
    } else {

        let _MemberFirstName = (!data.MemberFirstName || data.MemberFirstName == "" || data.MemberFirstName == "null") ? "" : data.MemberFirstName;
        let _MemberLastName = (!data.MemberLastName || data.MemberLastName == "" || data.MemberLastName == "null") ? "" : data.MemberLastName;
        let _MemberTName = (!data.MemberTName || data.MemberTName == "" || data.MemberTName == "null") ? "หอการค้าไทย" : data.MemberTName;

        document.documentElement.style.setProperty('--main-bg-image', `url(${data.MemberCard})`);

        txtImageCardId.src = data.MemberCard;
        updateAspectRatio(data.MemberCard);

        _tccCardImage.src = data.MemberCard;

        const parentElement = document.querySelector('.parent');
        parentElement.style.backgroundImage = data.MemberCard;
        updateAspectRatio(data.MemberCard);


        txtImageCardLicen.textContent = "บัตรสิทธิประโยชน์สมาชิก";
        _tccOverlay1.textContent = "บัตรสิทธิประโยชน์สมาชิก";


        txtImageCardName.textContent = _MemberFirstName + ' ' + _MemberLastName
        _tccOverlay2.textContent = _MemberFirstName + ' ' + _MemberLastName


        txtImageTName.textContent = _MemberTName;
        _tccOverlay3.textContent = "หอการค้าไทย";

        txtImageTittleRisno.textContent = "เลขที่สมาชิก";
        _tccOverlay4.textContent = "เลขที่สมาชิก"; 

        txtImageRisno.textContent = data.MemberRegisno;
        _tccOverlay5.textContent = data.MemberRegisno;

        txtImageExpDateTittle.textContent = "วันหมดอายุบัตร";
        _tccOverlay6.textContent = "วันหมดอายุบัตร";

        txtImageExpDate.textContent = _memberstatusDate;
        _tccOverlay7.textContent = _memberstatusDate;

        txtImagePerson.style.display = "block";
        pnlbackStep.style.display = "block";

        if (data.MemberImage != null) {
            txtImagePerson.style.display = "block";
            txtImagePerson.src = data.MemberImage;
            _tccProfileImage.src = data.MemberImage;
        }

        btnMemberStatus("none");

        const linkElement = document.querySelector('a[href="btnBackPageMemberStatusPage"]');

        // ตรวจสอบว่าพบ element หรือไม่ แล้วทำการลบออก
        if (linkElement) {
            linkElement.remove();
        }

    }
}

/** New Flow Step 3 */
async function SubmitIdCard() {

    if (modalCheckConfirm) {
        modalCheckConfirm.hide(); // ปิด Modal หลังจากที่ข้อมูลถูกส่งเสร็จ
    }

    disableButton('disable', 'btnSubmitIDcard')

    const fillCardId = document.getElementById("txtIdentityId").value

    if (objRegister.RegisterForm == "1") {
        document.getElementById('txtregisterNo').value = fillCardId
        console.log("SubmitIdCard-personID :" + fillCardId);
    }
    if (objRegister.RegisterForm == "2") {
        document.getElementById("txtregisterNoJuristic").value = fillCardId
        console.log("SubmitIdCard-juristicID :" + fillCardId);
    }

    const objInsertUIDMapTCC = GenInsertUidMapTCC(fillCardId);

    const resultInsert = await InsertUIDMapTCC(objInsertUIDMapTCC);

    if (resultInsert == null || resultInsert == undefined) return SwalCaseTCC("2");

    const objResultInsert = JSON.parse(resultInsert);

    if (objResultInsert.RESULT_STATUS == "OK") {
        objResultUIDMapTCC = {
            ID: objResultInsert.RESULT_OBJ.Table[0].ID,
            Uid: objResultInsert.RESULT_OBJ.Table[0].Uid,
            IdentityId: objResultInsert.RESULT_OBJ.Table[0].IdentityId,
            Status: objResultInsert.RESULT_OBJ.Table[0].Status
        }
        console.log("SubmitIdCard-objResultUIDMapTCC :", objResultUIDMapTCC);
    }

    //API GET MEMBER TCC 

    const resultMemberApi = await CheckMemberStatusTCC(objResultUIDMapTCC.IdentityId);

    console.log(resultMemberApi);

    if (!resultMemberApi) {
        if (resultMemberApi == '9') {
            return SwalCaseTCC("9");
        }

    };

    if (resultMemberApi == '12') {
        return SwalCaseTCC("12");
    }

    const typeForm = objRegister.RegisterForm

    //RESULT API FLOW REIGSTER 

    //if (resultMemberApi === false && typeForm === "1") {

    //    objRegister = {
    //        typeForm: typeForm,
    //        registerNo: fillCardId
    //    };

    //    /**New Function Call*/
    //    const objInsertInformation = {
    //        TransID: objResultUIDMapTCC.ID,
    //        TypeFrom: objRegister.typeForm
    //    }

    //    const bufferResultInformation = await InsertInformationTCC(objInsertInformation)

    //    const reusultInsertInformation = JSON.parse(bufferResultInformation)

    //    console.log('reusultInsertInformation', reusultInsertInformation);

    //    objResultInformation = {
    //        IDInformation: reusultInsertInformation.RESULT_OBJ.Table[0].IDInformation,
    //        IDTransUid: reusultInsertInformation.RESULT_OBJ.Table[0].IDTransUid
    //    };
    //    console.log('objResultInformation', objResultInformation);
    //    /**New Function End*/

    //    RedirectTo("RegisterMemberTCCPersonPage");
    //}
    //if (resultMemberApi === false && typeForm === "2") {

    //    objRegister = {
    //        typeForm: typeForm,
    //        registerNo: fillCardId
    //    };


    //    /**New Function Call*/
    //    const objInsertInformation = {
    //        TransID: objResultUIDMapTCC.ID,
    //        TypeFrom: objRegister.typeForm
    //    }

    //    const bufferResultInformation = await InsertInformationTCC(objInsertInformation)

    //    const reusultInsertInformation = JSON.parse(bufferResultInformation)

    //    console.log('reusultInsertInformation', reusultInsertInformation);

    //    objResultInformation = {
    //        IDInformation: reusultInsertInformation.RESULT_OBJ.Table[0].IDInformation,
    //        IDTransUid: reusultInsertInformation.RESULT_OBJ.Table[0].IDTransUid
    //    };
    //    console.log('objResultInformation', objResultInformation);
    //    /**New Function End*/

    //    RedirectTo("RegisterMemberTCCJuristicPage");
    //}
    /** */

    //DO IT MORE : IT RESULT API == TRUE ADD PAHT : PERSON AND JUSTIC TO PREVIEW ;
    if (resultMemberApi === true) {
        objRegister = {
            typeForm: typeForm,
            registerNo: fillCardId
        };

        console.log('SubmitIdCard-objRegister', objRegister);

        genPreviewDataFormAPI(objResultStatusMemberTCC);

        RedirectTo("TCCMemberStatusPage");
    } else {
        objRegister = {
            typeForm: typeForm,
            registerNo: fillCardId
        };

        if (resultMemberApi == '10' || resultMemberApi == '9') {
            SwalCaseTCC(resultMemberApi);
        } else {
            SwalCaseTCC("8");
        }

        //console.log('SubmitIdCard-objRegister', objRegister);

        //genPreviewDataFormAPI(objResultStatusMemberTCC);

        //RedirectTo("TCCMemberStatusPage");
    }

}
function isValidEmail(email) {
    // Regular Expression สำหรับตรวจสอบรูปแบบอีเมล
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}
function containsThai(text) {
    // Regular expression for Thai characters including vowels and tone marks
    const thaiPattern = /[ก-๙ะ-๯เ-๎๏-๛]/;
    return thaiPattern.test(text);
}
function ValidDataPersonPage() {

    const txtregisterNo = document.getElementById("txtregisterNo").value
    const txtfirstName = document.getElementById("txtfirstName").value
    const txtlastName = document.getElementById("txtlastName").value
    const txtemail = document.getElementById("txtemail").value
    const txtMobilePhone = document.getElementById("txtMobilePhone").value
    const txtproductExportCountry = document.getElementById("txtproductExportCountry").value
    const txtproductNameExport = document.getElementById("txtproductNameExport").value
    const ddlOccupation = document.getElementById("ddlOccupation").value
    const txtproductName = document.getElementById("txtproductName").value
    const ddlbussinessType = document.getElementById("ddlbussinessType").value

    //CONDITION INPUT FILED TO FAILD CASE : PERSON 

    if (txtregisterNo == null && txtregisterNo.length <= 12 && txtregisterNo != objRegister.registerNo) {
        Swal.fire("แจ้งเตือน", "เลขที่สมัครไม่ถูกต้อง", "warning",);
        return false;
    }
    if (txtfirstName.length == 0 || txtemail.length == 0 || txtlastName.length == 0 || txtMobilePhone.length != 10 || txtproductExportCountry.length == 0 || txtproductNameExport.length == 0) {
        Swal.fire("แจ้งเตือน", "กรอกข้อมูลไม่ครบถ้วน", "warning",);
        return false;
    }
    if (txtemail != null) {
        const resultFormat = isValidEmail(txtemail)
        if (resultFormat == false) {
            Swal.fire("แจ้งเตือน", "กรอกรูปแบบอีเมลล์ไม่ถูกต้อง", "warning",);
            return false;
        };
        const resultIsThai = containsThai(txtemail)
        if (resultIsThai == true) {
            Swal.fire("แจ้งเตือน", "ช่องกรอก อีเมลล์ มีอักขระภาษาไทย", "warning",);
            return false;
        };
    }
    if (txtMobilePhone.substring(0, 1) != '0') {
        Swal.fire("แจ้งเตือน", "เบอร์มือถือไม่ถูกต้อง", "warning",);
        return false;
    }
    if (ddlOccupation == '') {
        Swal.fire("แจ้งเตือน", "กรุณาเลือกอาชีพ", "warning",);
        return false;
    }
    if (ddlOccupation == '2') {
        if (txtproductName.length == 0 || ddlbussinessType.length == 0) {
            Swal.fire("แจ้งเตือน", "เนื่องจากท่านเลือก อาชีพธุรกิจส่วนตัว กรอกข้อมูลให้ครบถ้วน", "warning",);
            return false;
        }
    }
    //console.log(ddlOccupation); 
    return true

}
function formatDate(dateString) {
    let date = new Date(dateString);
    let year = date.getFullYear();
    let month = String(date.getMonth() + 1).padStart(2, '0'); // เพิ่ม 1 เนื่องจาก getMonth() เริ่มจาก 0
    let day = String(date.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
}
function GenDataPersonPage() {

    const resultValid = ValidDataPersonPage();

    if (resultValid === true) {

        const txtregisterNo = document.getElementById("txtregisterNo").value
        const txtfirstName = document.getElementById("txtfirstName").value
        const txtlastName = document.getElementById("txtlastName").value
        const registerDate = formatDate(new Date())
        const txtemail = document.getElementById("txtemail").value
        const txtMobilePhone = document.getElementById("txtMobilePhone").value
        const ddlOccupation = document.getElementById("ddlOccupation").value
        const txtproductName = document.getElementById("txtproductName").value
        const txtproductExportCountry = document.getElementById("txtproductExportCountry").value
        const ddlbussinessType = document.getElementById("ddlbussinessType").value
        const txtproductNameExport = document.getElementById("txtproductNameExport").value

        //ต้นทางชุดข้อมูล พื้นฐาน สำหรับยิง APIddMemberPeronalBYS
        obj = {
            firstName: txtfirstName,
            lastName: txtlastName,
            registerNo: txtregisterNo,
            issueDate: registerDate,
            email: txtemail,
            mobile: txtMobilePhone,
            occupation: ddlOccupation,
            productName: txtproductName,
            productExportcountry: txtproductExportCountry,
            bussinessType: ddlbussinessType,
            productNameExport: txtproductNameExport
        };

        objInformation.push(obj);

        console.log("GenDataPersonPage-objInformationPerson :", objInformation);
        console.log("GenDataPersonPage-lastobjInformationPerson :", objInformation[objInformation.length - 1]);

        if (objInformation != null) {
            RedirectTo("RegisterMemberAddressPage");
        }
    }
}
function ValidDataJurusticPage() {

    const txtregisterNoJuristic = document.getElementById("txtregisterNoJuristic").value
    const txtcompanyNameJuristic = document.getElementById("txtcompanyNameJuristic").value
    const txtissueDateJuristic = document.getElementById("txtissueDateJuristic").value
    const txtemailJuristic = document.getElementById("txtemailJuristic").value
    const txtMobilePhoneJuristic = document.getElementById("txtMobilePhoneJuristic").value
    const ddlCompanyType = document.getElementById("ddlCompanyType").value
    const txtproductNameJuristic = document.getElementById("txtproductNameJuristic").value
    const ddlBussinessType = document.getElementById("ddlBussinessType").value
    const txtnumberEmployeeJuristic = document.getElementById("txtnumberEmployeeJuristic").value
    const txtproductExportCountryJuristic = document.getElementById("txtproductExportCountryJuristic").value
    const txtproductNameExportJuristic = document.getElementById("txtproductNameExportJuristic").value
    const txtcontactFirstNameJuristic = document.getElementById("txtcontactFirstNameJuristic").value
    const txtcontactLastNameJuristic = document.getElementById("txtcontactLastNameJuristic").value
    const txtcontactIDCardJuristic = document.getElementById("txtcontactIDCardJuristic").value
    const txtcontactPositionJuristic = document.getElementById("txtcontactPositionJuristic").value
    const txtcontactMobileJuristic = document.getElementById("txtcontactMobileJuristic").value
    const txtcontactEmailJuristic = document.getElementById("txtcontactEmailJuristic").value
    const txtdirectorFirstNameJuristic = document.getElementById("txtdirectorFirstNameJuristic").value
    const txtdirectorLastNameJuristic = document.getElementById("txtdirectorLastNameJuristic").value
    const txtdirectorIDCardJuristic = document.getElementById("txtdirectorIDCardJuristic").value
    const txtdirectorMobileJuristic = document.getElementById("txtdirectorMobileJuristic").value
    const txtdirectorEmailJuristic = document.getElementById("txtdirectorEmailJuristic").value
    const txtTotalAssetJuristic = document.getElementById("txtTotalAssetJuristic").value

    //CONDITION INPUT FILED TO FAILD CASE : JURUSTIC

    if (txtregisterNoJuristic == null && txtregisterNoJuristic.length <= 12 && txtregisterNoJuristic != objRegister.registerNo) {
        Swal.fire("แจ้งเตือน", "เลขที่สมัครไม่ถูกต้อง", "warning",);
        return false;
    }
    if (txtcompanyNameJuristic.length == 0 || txtproductNameJuristic.length == '0' || txtnumberEmployeeJuristic.length == '0' || txtcontactFirstNameJuristic.length == '0' || txtcontactLastNameJuristic.length == '0' || txtcontactIDCardJuristic.length == '0' || txtcontactPositionJuristic.length == '0' || txtdirectorFirstNameJuristic.length == '0' || txtdirectorLastNameJuristic.length == '0' || txtTotalAssetJuristic.length == '0') {
        Swal.fire("แจ้งเตือน", "กรอกข้อมูลไม่ครบถ้วน", "warning",);
        return false;
    }
    if (txtissueDateJuristic.length == 0) {
        Swal.fire("แจ้งเตือน", "เลือกวันที่จดทะเบียน", "warning",);
        return false;
    }
    if (txtemailJuristic.length == 0 || txtemailJuristic != null) {

        const result = isValidEmail(txtemailJuristic)
        if (result == false) {
            Swal.fire("แจ้งเตือน", "กรอกรูปแบบอีเมลล์บริษัทไม่ถูกต้อง", "warning",);
            return false;
        };
        const resultIsThai = containsThai(txtemailJuristic)
        if (resultIsThai == true) {
            Swal.fire("แจ้งเตือน", "มีอักขระภาษาไทย", "warning",);
            return false;
        };
    }
    if (txtMobilePhoneJuristic.length == 0 || txtMobilePhoneJuristic.substring(0, 1) != '0') {
        Swal.fire("แจ้งเตือน", "กรอกเบอร์โทรบริษัทไม่ถูกต้อง", "warning",);
        return false;
    }
    if (ddlCompanyType == '') {
        Swal.fire("แจ้งเตือน", "กรุณาเลือก รูปแบบกิจการ", "warning",);
        return false;
    }
    if (ddlBussinessType == '') {
        Swal.fire("แจ้งเตือน", "กรุณาเลือก ประเภทธุรกิจ", "warning",);
        return false;
    }
    if (ddlBussinessType == 'EX') {
        if (txtproductExportCountryJuristic.length == 0 || txtproductNameExportJuristic.length == 0) {
            Swal.fire("แจ้งเตือน", "หากท่านเลือก ประเภทธุรกิจส่งออก ให้ระบุ ประเทศและผลิตภัณฑ์ที่ส่งออก", "warning",);
            return false;
        }
    }
    if (txtcontactIDCardJuristic.length != '0') {
        const resultCheck = Script_checkID(txtcontactIDCardJuristic);
        if (resultCheck == false) {
            Swal.fire("แจ้งเตือน", "รูปแบบบัตรประชาชนผู้ติดต่อไม่ถูกต้อง", "warning",);
            return false;
        }
    }
    if (txtcontactMobileJuristic.length == 0 && txtcontactMobileJuristic.substring(0, 1) != '0') {
        Swal.fire("แจ้งเตือน", "กรอกเบอร์โทรผู้ติดต่อไม่ถูกต้อง", "warning",);
        return false;
    }
    if (txtcontactEmailJuristic.length == 0 || txtcontactEmailJuristic != null) {

        const result = isValidEmail(txtcontactEmailJuristic)
        if (result == false) {
            Swal.fire("แจ้งเตือน", "กรอกรูปแบบอีเมลล์ผู้ติดต่อไม่ถูกต้อง", "warning",);
            return false;
        };
        const resultIsThai = containsThai(txtcontactEmailJuristic)
        if (resultIsThai == true) {
            Swal.fire("แจ้งเตือน", "มีอักขระภาษาไทย", "warning",);
            return false;
        };
    }
    if (txtdirectorIDCardJuristic.length != '0') {
        const resultCheck = Script_checkID(txtdirectorIDCardJuristic);
        if (resultCheck == false) {
            Swal.fire("แจ้งเตือน", "รูปแบบบัตรประชาชนผู้มีอำนาจไม่ถูกต้อง", "warning",);
            return false;
        }
    }
    if (txtdirectorMobileJuristic.length == 0 || txtdirectorMobileJuristic.substring(0, 1) != '0') {
        Swal.fire("แจ้งเตือน", "กรอกเบอร์โทรผู้มีอำนาจไม่ถูกต้อง", "warning",);
        return false;
    }
    if (txtdirectorEmailJuristic.length == 0 || txtdirectorEmailJuristic != null) {

        const result = isValidEmail(txtdirectorEmailJuristic)
        if (result == false) {
            Swal.fire("แจ้งเตือน", "กรอกรูปแบบอีเมลล์ผู้มีอำนาจไม่ถูกต้อง", "warning",);
            return false;
        };
        const resultIsThai = containsThai(txtdirectorEmailJuristic)
        if (resultIsThai == true) {
            Swal.fire("แจ้งเตือน", "มีอักขระภาษาไทย", "warning",);
            return false;
        };
    }
    return true;
}
function convertThaiDateToISO(thaiDate) {
    // แยกวันที่ไทยออกมา
    let [day, month, thaiYear] = thaiDate.split('/').map(Number);

    // แปลงปีพุทธศักราช (พ.ศ.) เป็นคริสต์ศักราช (ค.ศ.)
    let year = thaiYear - 543;

    // สร้างวันที่ในรูปแบบ ISO
    let isoDate = new Date(year, month - 1, day).toISOString().split('T')[0];

    return isoDate;
}
function GenDataJuristicPage() {

    const resultValid = ValidDataJurusticPage();

    const txtregisterNoJuristic = document.getElementById("txtregisterNoJuristic").value
    const txtcompanyNameJuristic = document.getElementById("txtcompanyNameJuristic").value
    const txtissueDateJuristic = document.getElementById("txtissueDateJuristic").value
    const txtemailJuristic = document.getElementById("txtemailJuristic").value
    const txtMobilePhoneJuristic = document.getElementById("txtMobilePhoneJuristic").value
    const ddlCompanyType = document.getElementById("ddlCompanyType").value
    const txtproductNameJuristic = document.getElementById("txtproductNameJuristic").value
    const ddlBussinessType = document.getElementById("ddlBussinessType").value
    const txtnumberEmployeeJuristic = document.getElementById("txtnumberEmployeeJuristic").value
    const txtproductExportCountryJuristic = document.getElementById("txtproductExportCountryJuristic").value
    const txtproductNameExportJuristic = document.getElementById("txtproductNameExportJuristic").value
    const txtcontactFirstNameJuristic = document.getElementById("txtcontactFirstNameJuristic").value
    const txtcontactLastNameJuristic = document.getElementById("txtcontactLastNameJuristic").value
    const txtcontactIDCardJuristic = document.getElementById("txtcontactIDCardJuristic").value
    const txtcontactPositionJuristic = document.getElementById("txtcontactPositionJuristic").value
    const txtcontactMobileJuristic = document.getElementById("txtcontactMobileJuristic").value
    const txtcontactEmailJuristic = document.getElementById("txtcontactEmailJuristic").value
    const txtdirectorFirstNameJuristic = document.getElementById("txtdirectorFirstNameJuristic").value
    const txtdirectorLastNameJuristic = document.getElementById("txtdirectorLastNameJuristic").value
    const txtdirectorIDCardJuristic = document.getElementById("txtdirectorIDCardJuristic").value
    const txtdirectorMobileJuristic = document.getElementById("txtdirectorMobileJuristic").value
    const txtdirectorEmailJuristic = document.getElementById("txtdirectorEmailJuristic").value
    const txtTotalAssetJuristic = document.getElementById("txtTotalAssetJuristic").value

    console.log('ValidDataJurusticPage : ', resultValid);

    if (resultValid == true) {
        //ต้นทางชุดข้อมูล พื้นฐาน สำหรับยิง APIddMemberPeronalBYS
        obj = {
            companyName: txtcompanyNameJuristic,
            registerNo: txtregisterNoJuristic,
            issueDate: convertThaiDateToISO(txtissueDateJuristic),
            email: txtemailJuristic,
            mobile: txtMobilePhoneJuristic,
            companyType: ddlCompanyType,
            productName: txtproductNameJuristic,
            bussinessType: ddlBussinessType,
            numberEmployee: txtnumberEmployeeJuristic,
            productExportcountry: txtproductExportCountryJuristic,
            productNameExport: txtproductNameExportJuristic,
            contactFirstName: txtcontactFirstNameJuristic,
            contactLastName: txtcontactLastNameJuristic,
            contactIDCard: txtcontactIDCardJuristic,
            contactPosition: txtcontactPositionJuristic,
            contactMobile: txtcontactMobileJuristic,
            contactEmail: txtcontactEmailJuristic,
            directorFirstName: txtdirectorFirstNameJuristic,
            directorLastName: txtdirectorLastNameJuristic,
            directorIDCard: txtdirectorIDCardJuristic,
            directorMobile: txtdirectorMobileJuristic,
            directorEmail: txtdirectorEmailJuristic,
            totalAsset: txtTotalAssetJuristic
        };

        objInformation.push(obj);

        console.log("GenDataJuristicPage-objInformationJurustic :", objInformation);
        console.log("GenDataJuristicPage-lastobjInformationJurustic :", objInformation[objInformation.length - 1]);

        if (objInformation != null) {
            RedirectTo("RegisterMemberAddressPage");
        }
    }
}
function BackStepAddress() {

    const _typeForm = objRegister.typeForm

    if (_typeForm == '1') {
        RedirectTo("RegisterMemberTCCPersonPage")
    }
    if (_typeForm == '2') {
        RedirectTo("RegisterMemberTCCJuristicPage")
    }

}
function ValidDataAddressPage() {

    const txtaddressNoTH = document.getElementById("txtaddressNoTH").value
    const txtmooTH = document.getElementById("txtmooTH").value
    const txtbuildingTH = document.getElementById("txtbuildingTH").value
    const txtvillageTH = document.getElementById("txtvillageTH").value
    const txtfloorTH = document.getElementById("txtfloorTH").value
    const txtroomTH = document.getElementById("txtroomTH").value
    const txtsoiTH = document.getElementById("txtsoiTH").value
    const txtlaneTH = document.getElementById("txtlaneTH").value
    const txtroadTH = document.getElementById("txtroadTH").value
    const ddltambolTH = document.getElementById("ddlTambolTH").value
    const ddlamphurTH = document.getElementById("ddlAmphurTH").value
    const ddlprovinceTH = document.getElementById("ddlProvinceTH").value
    const txtcountryTH = document.getElementById("txtcountryTH").value
    const ddlzipcode = document.getElementById("ddlZipcode").value
    //const txtfullAddressThai = ['เลขที่ ' + txtaddressNoTH, 'หมู่ ' + txtmooTH, 'อาคาร ' + txtbuildingTH, 'หมู่บ้าน ' + txtvillageTH, 'ชั้น ' + txtfloorTH, 'ห้อง ' + txtroomTH, 'ซอย ' + txtsoiTH, 'ตรอก ' + txtlaneTH, 'ถนน ' + txtroadTH, 'แขวง ' + ddltambolTH, 'เขต ' + ddlamphurTH, 'จังหวัด ' + ddlprovinceTH + 'ประเทศ ' + txtcountryTH, ddlzipcode].join(", ")
    //console.log(txtfullAddressThai);

    //ต้นทางชุดข้อมูลที่อยู่ สำหรับยิง API ddMemberPeronalBYS และ addMemberCorperateBYS

    if (txtaddressNoTH.length == 0 || txtroadTH.length == 0 || ddltambolTH.length == 0 || ddlamphurTH.length == 0 || ddlprovinceTH.length == 0 || ddlzipcode.length == 0) {
        Swal.fire("แจ้งเตือน", "กรอกข้อมูลไม่ครบถ้วน", "warning",);
        return false;
    }

    return true
}
function disableFileUpload() {

    const _typeForm = objRegister.typeForm
    const tabDCfile = document.getElementById("tabDCfile");
    const tabDBfile = document.getElementById("tabDBfile");
    const tabCHfile = document.getElementById("tabCHfile");
    const tabPLfile = document.getElementById("tabPLfile");

    const tabIDCardfile = document.getElementById("tabIDCardfile");
    const tabOJfile = document.getElementById("tabOJfile");
    const tabPPfile = document.getElementById("tabPPfile");
    const tabISfile = document.getElementById("tabISfile");


    if (_typeForm == '1') {
        tabDCfile.style.display = 'block';
        tabDBfile.style.display = 'block';
        tabCHfile.style.display = 'block';
        tabPLfile.style.display = 'block';
        tabIDCardfile.style.display = 'none';
        tabOJfile.style.display = 'none';
        tabPPfile.style.display = 'none';
        tabISfile.style.display = 'none';
    }
    if (_typeForm == '2') {
        tabDCfile.style.display = 'none';
        tabDBfile.style.display = 'none';
        tabCHfile.style.display = 'none';
        tabPLfile.style.display = 'none';
        tabIDCardfile.style.display = 'block';
        tabOJfile.style.display = 'block';
        tabPPfile.style.display = 'block';
        tabISfile.style.display = 'block';
    }
}
function GenDataPageAddress() {

    const resultValid = ValidDataAddressPage();

    if (resultValid === true) {

        const txtaddressNoTH = document.getElementById("txtaddressNoTH").value
        const txtmooTH = document.getElementById("txtmooTH").value
        const txtbuildingTH = document.getElementById("txtbuildingTH").value
        const txtvillageTH = document.getElementById("txtvillageTH").value
        const txtfloorTH = document.getElementById("txtfloorTH").value
        const txtroomTH = document.getElementById("txtroomTH").value
        const txtsoiTH = document.getElementById("txtsoiTH").value
        const txtlaneTH = document.getElementById("txtlaneTH").value
        const txtroadTH = document.getElementById("txtroadTH").value
        const ddltambolTH = document.getElementById("ddlTambolTH").value
        const ddlamphurTH = document.getElementById("ddlAmphurTH").value
        const ddlprovinceTH = document.getElementById("ddlProvinceTH").value
        const txtcountryTH = document.getElementById("txtcountryTH").value
        const ddlzipcode = document.getElementById("ddlZipcode").value
        const txtfullAddressThai = ['เลขที่' + txtaddressNoTH + ' หมู่' + txtmooTH + ' อาคาร' + txtbuildingTH + ' หมู่บ้าน' + txtvillageTH + ' ชั้น' + txtfloorTH + ' ห้อง' + txtroomTH + ' ซอย' + txtsoiTH + ' ตรอก' + txtlaneTH + ' ถนน' + txtroadTH + ' แขวง' + ddltambolTH + ' เขต' + ddlamphurTH + ' จังหวัด' + ddlprovinceTH + ' ' + ddlzipcode].join(", ")

        obj = {
            addressNoTH: txtaddressNoTH,
            mooTH: txtmooTH,
            buildingTH: txtbuildingTH,
            villageTH: txtvillageTH,
            floorTH: txtfloorTH,
            roomTH: txtroomTH,
            soiTH: txtsoiTH,
            laneTH: txtlaneTH,
            roadTH: txtroadTH,
            tambolTH: ddltambolTH,
            amphurTH: ddlamphurTH,
            provinceTH: ddlprovinceTH,
            countryTH: txtcountryTH,
            zipcode: ddlzipcode,
            fullAddressTH: txtfullAddressThai,
            addressNoEN: txtaddressNoTH,
            mooEN: txtmooTH,
            buildingEN: "",
            villageEN: "",
            floorEN: "",
            roomEN: "",
            soiEN: "",
            laneEN: "",
            roadEN: "",
            countryEN: "",
            fullAddressEN: ""
        }

        objAddress.push(obj);
        console.log("objAddress :", objAddress);

        console.log("lastobjAddress", objAddress[objAddress.length - 1])

        if (objAddress != null) {

            disableFileUpload();

            RedirectTo("RegisterMemberFileUploadPage")
        }
    }
}
function BackStepFileUploadPerson() {

    const _typeForm = objRegister.typeForm

    if (_typeForm == '1') {
        RedirectTo("RegisterMemberAddressPage")
    }
    if (_typeForm == '2') {
        RedirectTo("RegisterMemberAddressPage")
    }

}
/** START FOR TEST API AddMemberPerson  */
function getFile(filePath) {
    return filePath.substr(filePath.lastIndexOf('\\') + 1);
}
/** FOR TEST API AddMemberPerson  */
function getoutput(filePath) {

    const outputfile = getFile(filePath);
    //const extension = outputfile.split('.')[1];

    const uid = objResultUIDMapTCC.Uid;

    const httpDownLoad = `https://demo.tcg.or.th/LineOAFront_uat/TCCProject/67/${uid}/`


    if (filePath != '') {

        const linkOutputFile = httpDownLoad + outputfile
        return linkOutputFile
    }

    return outputfile

}
/** END FOR TEST API AddMemberPerson  */

//function ValidDataFileUploadPagePerson() {

//    const documentDCFile = document.getElementById("documentDCFile").value
//    const documentDBFile = document.getElementById("documentDBFile").value
//    const documentCHFile = document.getElementById("documentCHFile").value
//    const documentPLFile = document.getElementById("documentPLFile").value

//    if (documentDCFile.length == 0 || documentDBFile.length == 0 || documentCHFile.length == 0 || documentPLFile.length == 0) {
//        Swal.fire("แจ้งเตือน", "รบกวนแนบไฟล์ตามเงื่อนไขให้ครบถ้วน", "warning",);
//        return false;
//    } else {

//        console.log('objResultFileUploadPerson', objResultFileUploadPerson);

//        objResultFileUploadPerson = {
//            pathDC: getoutput(documentDCFile) ?? "",
//            pathDB: getoutput(documentDBFile) ?? "",
//            pathCH: getoutput(documentCHFile) ?? "",
//            pathPL: getoutput(documentPLFile) ?? ""
//        };
//        console.log('objResultFileUploadPerson', objResultFileUploadPerson);

//        return true;
//    }
//    return false;

//}

function validDataFilePerson() {

    const documentDCFile = document.getElementById("documentDCFile").value
    const documentDBFile = document.getElementById("documentDBFile").value
    const documentCHFile = document.getElementById("documentCHFile").value
    const documentPLFile = document.getElementById("documentPLFile").value

    if (documentDCFile.length == 0 || documentDBFile.length == 0 || documentCHFile.length == 0 || documentPLFile.length == 0) {
        Swal.fire("แจ้งเตือน", "รบกวนแนบไฟล์ตามเงื่อนไขให้ครบถ้วน", "warning",)
        return false;
    } else {
        return true;
    }
    return false;

}
async function UploadFilePerson() {

    const documentDCFile = document.getElementById("documentDCFile").files[0]
    const documentDBFile = document.getElementById("documentDBFile").files[0]
    const documentCHFile = document.getElementById("documentCHFile").files[0]
    const documentPLFile = document.getElementById("documentPLFile").files[0]

    // เขียนเชื่อมต่อ API กับ SERVICE 
    // Prepare FormData for file upload
    let formData = new FormData();
    formData.append("uid", objResultUIDMapTCC.Uid);
    formData.append("files", documentDCFile, "DC_" + documentDCFile.name);
    formData.append("files", documentDBFile, "DB_" + documentDBFile.name);
    formData.append("files", documentCHFile, "CH_" + documentCHFile.name);
    formData.append("files", documentPLFile, "PL_" + documentPLFile.name);
    // Call the file upload API

    try {
        let bufferFileUpload = await FileUpload(formData, objResultUIDMapTCC.Uid);
        for (var i = 0; i < bufferFileUpload.RESULT_OBJ.length; i++) {

            let type = bufferFileUpload.RESULT_OBJ[i].FileType

            switch (type) {
                case "DC":
                    objResultFileUploadPerson.pathDC = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                case "DB":
                    objResultFileUploadPerson.pathDB = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                case "CH":
                    objResultFileUploadPerson.pathCH = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                case "PL":
                    objResultFileUploadPerson.pathPL = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                default:
                    break;
            }
        }
    } catch (error) {
        console.error("Error uploading files:", error);
        return false;
    }

    console.log('objResultFileUploadPerson', objResultFileUploadPerson);

    if (objResultFileUploadPerson.pathDC != null && objResultFileUploadPerson.pathDC && objResultFileUploadPerson.pathDB != null && objResultFileUploadPerson.pathDB && objResultFileUploadPerson.pathCH != null && objResultFileUploadPerson.pathCH && objResultFileUploadPerson.pathPL != null && objResultFileUploadPerson.pathPL) {
        console.log('UploadFilePath Success')
        return true;
    }
    else {
        console.log('UploadFilePath Fail')
        return false;
    }
}

async function GenDataPageFileUploadPerson() {

    const resultValid = validDataFilePerson();

    //const resultValid = true /**TETS NO VALID*/

    if (resultValid === true) {

        const resultUpload = await UploadFilePerson(); /**/

        if (resultUpload == true) {
            console.log("FileUploadPerson ValidComplete");
            ShowModalConfirmInformation();
        }
        else {
            console.log("UploadFilePath Fail");
            SwalCaseTCC("7");
        }

    } else {
        console.log("NoHaveFileUpload");
        Swal.fire("แจ้งเตือน", "รบกวนแนบไฟล์ตามเงื่อนไขให้ครบถ้วน", "warning",);
    }

}

function validDataFileJurustic() {

    const documentIDCardFile = document.getElementById("documentIDCardFile").value
    const documentOJFile = document.getElementById("documentOJFile").value
    const documentPPFile = document.getElementById("documentPPFile").value
    const documentISFile = document.getElementById("documentISFile").value

    if (documentIDCardFile.length == 0 || documentOJFile.length == 0 || documentPPFile.length == 0 || documentISFile.length == 0) {
        Swal.fire("แจ้งเตือน", "รบกวนแนบไฟล์ตามเงื่อนไขให้ครบถ้วน", "warning",)
        return false;
    } else {
        return true;
    }
    return false;

}
async function UploadFileJurustic() {

    const documentIDCardFile = document.getElementById("documentIDCardFile").files[0]
    const documentOJFile = document.getElementById("documentOJFile").files[0]
    const documentPPFile = document.getElementById("documentPPFile").files[0]
    const documentISFile = document.getElementById("documentISFile").files[0]

    // เขียนเชื่อมต่อ API กับ SERVICE 
    // Prepare FormData for file upload
    let formData = new FormData();
    formData.append("uid", objResultUIDMapTCC.Uid);
    formData.append("files", documentIDCardFile, "IDCard_" + documentIDCardFile.name);
    formData.append("files", documentOJFile, "OJ_" + documentOJFile.name);
    formData.append("files", documentPPFile, "PP_" + documentPPFile.name);
    formData.append("files", documentISFile, "IS_" + documentISFile.name);
    // Call the file upload API

    try {
        let bufferFileUpload = await FileUpload(formData, objResultUIDMapTCC.Uid);
        for (var i = 0; i < bufferFileUpload.RESULT_OBJ.length; i++) {

            let type = bufferFileUpload.RESULT_OBJ[i].FileType

            switch (type) {
                case "IDCard":
                    objResultFileUploadJurustic.pathIDCardCopy = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                case "OJ":
                    objResultFileUploadJurustic.pathOJ = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                case "PP":
                    objResultFileUploadJurustic.pathPP = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                case "IS":
                    objResultFileUploadJurustic.pathIS = bufferFileUpload.RESULT_OBJ[i].Url
                    break;
                default:
                    break;
            }
        }
    } catch (error) {
        console.error("Error uploading files:", error);
        return false;
    }

    console.log('objResultFileUploadJurustic', objResultFileUploadJurustic);

    if (objResultFileUploadJurustic.pathIDCardCopy != null && objResultFileUploadJurustic.pathIDCardCopy && objResultFileUploadJurustic.pathOJ != null && objResultFileUploadJurustic.pathOJ && objResultFileUploadJurustic.pathPP != null && objResultFileUploadJurustic.pathPP && objResultFileUploadJurustic.pathIS != null && objResultFileUploadJurustic.pathIS) {
        console.log('UploadFilePath Success')
        return true;
    }
    else {
        console.log('UploadFilePath Fail')
        return false;
    }

}
async function GenDataPageFileUploadJurustic() {

    const resultValid = validDataFileJurustic();

    //const resultValid = true /**TETS NO VALID*/

    if (resultValid === true) {

        const resultUpload = await UploadFileJurustic(); /**/

        if (resultUpload == true) {
            console.log("FileUploadJurustic ValidComplete");
            ShowModalConfirmInformation();
        }
        else {
            console.log("UploadFilePath Fail");
            SwalCaseTCC("7");
        }

    } else {
        console.log("NoHaveFileUpload");
        Swal.fire("แจ้งเตือน", "รบกวนแนบไฟล์ตามเงื่อนไขให้ครบถ้วน", "warning",);
    }

}
function uploadFileData() {

    const _typeForm = objRegister.typeForm

    if (_typeForm == '1') {
        GenDataPageFileUploadPerson();
    }
    if (_typeForm == '2') {
        GenDataPageFileUploadJurustic();
    }
}
async function UpdateInfoPerson() {
    const objMain = objResultInformation
    const objInformationlast = objInformation[objInformation.length - 1]
    const objAddresslast = objAddress[objAddress.length - 1]
    const objUpload = objResultFileUploadPerson

    const objUpdateInformation = {
        TransID: objMain.IDTransUid,
        ID: objMain.IDInformation,
        firstName: objInformationlast.firstName,
        lastName: objInformationlast.lastName,
        registerNo: objInformationlast.registerNo,
        email: objInformationlast.email,
        mobile: objInformationlast.mobile,
        occupation: objInformationlast.occupation,
        productName: objInformationlast.productName,
        productExportcountry: objInformationlast.productExportcountry,
        bussinessType: objInformationlast.bussinessType,
        productNameExport: objInformationlast.productNameExport,
        addressNoTH: objAddresslast.addressNoTH,
        mooTH: objAddresslast.mooTH,
        buildingTH: objAddresslast.buildingTH,
        villageTH: objAddresslast.villageTH,
        floorTH: objAddresslast.floorTH,
        roomTH: objAddresslast.roomTH,
        soiTH: objAddresslast.soiTH,
        laneTH: objAddresslast.laneTH,
        roadTH: objAddresslast.roadTH,
        tambolTH: objAddresslast.tambolTH,
        ampherTH: objAddresslast.amphurTH,
        provinceTH: objAddresslast.provinceTH,
        countryTH: objAddresslast.countryTH,
        zipcode: objAddresslast.zipcode,
        fullAddressTH: objAddresslast.fullAddressTH,
        filePath_DC: objUpload.pathDC,
        filePath_DB: objUpload.pathDB,
        filePath_CH: objUpload.pathCH,
        filePath_PL: objUpload.pathPL
    };
    console.log('objUpdateInformationPerson', objUpdateInformation)

    const buffer = await UpdateInformationTCCPerson(objUpdateInformation)
    //console.log(buffer)
    const bufferResult = JSON.parse(buffer)
    console.log(bufferResult);

    return bufferResult;
}
async function UpdateInfoJurustic() {

    const objMain = objResultInformation
    const objInformationlast = objInformation[objInformation.length - 1]
    const objAddresslast = objAddress[objAddress.length - 1]
    const objUpload = objResultFileUploadJurustic

    const objUpdateInformation = {
        TransID: objMain.IDTransUid,
        ID: objMain.IDInformation,
        companyName: objInformationlast.companyName,
        registerNo: objInformationlast.registerNo,
        issueDate: objInformationlast.issueDate,
        email: objInformationlast.email,
        mobile: objInformationlast.mobile,
        companyType: objInformationlast.companyType,
        productName: objInformationlast.productName,
        bussinessType: objInformationlast.bussinessType,
        numberEmployee: objInformationlast.numberEmployee,
        productExportcountry: objInformationlast.productExportcountry,
        productNameExport: objInformationlast.productNameExport,
        contactFirstName: objInformationlast.contactFirstName,
        contactLastName: objInformationlast.contactLastName,
        contactIDCard: objInformationlast.contactIDCard,
        contactPosition: objInformationlast.contactPosition,
        contactMobile: objInformationlast.contactMobile,
        contactEmail: objInformationlast.contactEmail,
        directorFirstName: objInformationlast.directorFirstName,
        directorLastName: objInformationlast.directorLastName,
        directorIDCard: objInformationlast.directorIDCard,
        directorMobile: objInformationlast.directorMobile,
        directorEmail: objInformationlast.directorEmail,
        filePath_directorIDCopyDoc: objUpload.pathIDCardCopy,
        totalAsset: objInformationlast.totalAsset,
        addressNoTH: objAddresslast.addressNoTH,
        mooTH: objAddresslast.mooTH,
        buildingTH: objAddresslast.buildingTH,
        villageTH: objAddresslast.villageTH,
        floorTH: objAddresslast.floorTH,
        roomTH: objAddresslast.roomTH,
        soiTH: objAddresslast.soiTH,
        laneTH: objAddresslast.laneTH,
        roadTH: objAddresslast.roadTH,
        tambolTH: objAddresslast.tambolTH,
        ampherTH: objAddresslast.amphurTH,
        provinceTH: objAddresslast.provinceTH,
        countryTH: objAddresslast.countryTH,
        zipcode: objAddresslast.zipcode,
        fullAddressTH: objAddresslast.fullAddressTH,
        filePath_OJ: objUpload.pathOJ,
        filePath_PP: objUpload.pathPP,
        filePath_IS: objUpload.pathIS,
        filePath_directorIDCopyDoc: objUpload.pathIDCardCopy,
    }
    console.log('objUpdateInformationJurustic', objUpdateInformation)

    const buffer = await UpdateInformationTCCJurustic(objUpdateInformation)
    //console.log(buffer)
    const bufferResult = JSON.parse(buffer)
    console.log(bufferResult);

    return bufferResult;
}
function GenFormAddMemberJurusticBYS(data) {
    const payload =
    {
        //Json body for api {{URL}}addMemberCorperateBYS?file
        companyName: data.companyName,
        registerNo: data.registerNo,
        issueDate: data.issueDate,
        email: data.email,
        mobile: data.mobile,
        companyType: data.companyType,
        productName: data.productName,
        bussinessType: data.bussinessType,
        numberEmployee: data.numberEmployee,
        productExportcountry: data.productExportcountry,
        productNameExport: data.productNameExport,
        contactFirstName: data.contactFirstName,
        contactLastName: data.contactLastName,
        contactIDCard: data.contactIDCard,
        contactPosition: data.contactPosition,
        contactMobile: data.contactMobile,
        contactEmail: data.contactEmail,
        directorFirstName: data.directorFirstName,
        directorLastName: data.directorLastName,
        directorIDCard: data.directorIDCard,
        directorMobile: data.directorMobile,
        directorEmail: data.directorEmail,
        directorIDCopyDoc: data.filePath_directorIDCopyDoc,
        totalAsset: data.totalAsset,
        address: {
            addressNoTH: data.addressNoTH,
            mooTH: data.mooTH,
            buildingTH: data.buildingTH,
            villageTH: data.villageTH,
            floorTH: data.floorTH,
            roomTH: data.roomTH,
            soiTH: data.soiTH,
            laneTH: data.laneTH,
            roadTH: data.roadTH,
            tambolTH: data.tambolTH,
            amphurTH: data.ampherTH,
            provinceTH: data.provinceTH,
            countryTH: data.countryTH,
            fullAddressTH: data.fullAddressTH,
            addressNoEN: "-",
            mooEN: "-",
            buildingEN: "-",
            villageEN: "-",
            floorEN: "-",
            roomEN: "-",
            soiEN: "-",
            laneEN: "-",
            roadEN: "-",
            countryEN: "-",
            fullAddressEN: "-",
            zipcode: data.zipcode
        },
        document: [
            {
                /**DO IT รอสอบถาม เรื่องการส่งไฟล์ แล้วปรับกลับก่อนนำมาบันทึก*/
                documentType: "OJ",
                file: data.filePath_OJ
                //file: "https://demo.tcg.or.th/LineOAFront_uat/TCCProject/67/U32652a9f099999beb06bafa55afe6e3c/OJ.pdf"
            },
            {
                documentType: "PP",
                file: data.filePath_PP
                //file: "https://demo.tcg.or.th/LineOAFront_uat/TCCProject/67/U32652a9f099999beb06bafa55afe6e3c/PP.pdf"
            },
            {
                documentType: "IS",
                file: data.filePath_IS
                //file: "https://demo.tcg.or.th/LineOAFront_uat/TCCProject/67/U32652a9f099999beb06bafa55afe6e3c/IS.pdf"

            }
        ]
    }

    payloadB.push(payload)

    if (payloadB.length > 0) {

        let payloadLast = [];

        payloadLast.push(payloadB[payloadB.length - 1])

        const RootAddJurustic = {
            listData: payloadLast
        }
        console.log('ifpayload', RootAddJurustic)
        return RootAddJurustic;
    }

    const RootAddJurustic = {
        listData: payloadB
    }

    console.log('payload', RootAddJurustic);

    return RootAddJurustic;

}
function GenFormAddMemberPeronalBYS(data) {

    const payload =
    {
        firstName: data.firstName,
        lastName: data.lastName,
        registerNo: data.registerNo,
        issueDate: data.issueDate,
        email: data.email,
        mobile: data.mobile,
        occupation: data.occupation,
        productName: data.productName,
        productExportcountry: data.productExportcountry,
        bussinessType: data.bussinessType,
        productNameExport: data.productNameExport,
        address: {
            addressNoTH: data.addressNoTH,
            mooTH: data.mooTH,
            buildingTH: data.buildingTH,
            villageTH: data.villageTH,
            floorTH: data.floorTH,
            roomTH: data.roomTH,
            soiTH: data.soiTH,
            laneTH: data.laneTH,
            roadTH: data.roadTH,
            tambolTH: data.tambolTH,
            amphurTH: data.ampherTH,
            provinceTH: data.provinceTH,
            countryTH: data.countryTH,
            fullAddressTH: data.fullAddressTH,
            addressNoEN: "-",
            mooEN: "-",
            buildingEN: "-",
            villageEN: "-",
            floorEN: "-",
            roomEN: "-",
            soiEN: "-",
            laneEN: "-",
            roadEN: "-",
            countryEN: "-",
            fullAddressEN: "-",
            zipcode: data.zipcode
        },
        document: [
            {
                //DO IT จาก API ต้องใช้งาน PATH อะไร ในการส่งข้อมูล เนื่องจาก แนบ ลิ้งค์ อื่นไม่สามารถ SAVE ได้
                documentType: "DC",
                file: data.filePath_DC
                //file: "https://starrtccprod02.blob.core.windows.net/image/File/VerifySign/353.jpg"
            },
            {
                documentType: "DB",
                file: data.filePath_DB
                //file: "https://starrtccprod02.blob.core.windows.net/image/File/VerifySign/353.jpg"
            },
            {
                documentType: "CH",
                file: data.filePath_CH
                //file: "https://starrtccprod02.blob.core.windows.net/image/File/VerifySign/353.jpg"
            },
            {
                documentType: "PL",
                file: data.filePath_PL
                //file: "https://starrtccprod02.blob.core.windows.net/image/File/VerifySign/353.jpg"
            }
        ]

    }


    payloadA.push(payload)

    if (payloadA.length > 0) {

        let payloadLast = [];

        payloadLast.push(payloadA[payloadA.length - 1])

        const RootAddPerson = {
            listData: payloadLast
        }
        console.log('ifpayload', RootAddPerson)
        return RootAddPerson;
    }

    const RootAddPerson = {
        listData: payloadA
    }

    //console.log('GEN DATA API : ', payload.listData[0])
    console.log('payload', RootAddPerson);

    return RootAddPerson;

}
function convertBuddhistToGregorianDate(jsonStr) {
    return jsonStr.replace(/(\d{1,2}\/\d{1,2}\/)(\d{4})/g, (match, dayMonth, buddhistYear) => {
        const gregorianYear = parseInt(buddhistYear) - 543;
        return `${dayMonth}${gregorianYear}`;
    });
}

async function CallServiceAddMemberAPI(data) {

    //บุคคลธรรมดา
    if (data.TypeFrom == '1') {

        const payloadAddMemberPeronalBYS = GenFormAddMemberPeronalBYS(data);

        const resultAPI = await ServiceAddMemberPeronalBYS(payloadAddMemberPeronalBYS);
        console.log(resultAPI);
        const resultAddMemberPersonBYS = JSON.parse(resultAPI)

        const objResultAPIUpdateTrans = {
            Id: objResultUIDMapTCC.ID ?? objRepeatProcess.TransID,
            IsMemberTCC: resultAddMemberPersonBYS.Items[0].MemberStatus,
            MemberTCCStatus: resultAddMemberPersonBYS.Items[0].Status,
            TransactionId: resultAddMemberPersonBYS.TransactionId,
            IsRegisterSuccess: resultAddMemberPersonBYS.Items[0].IsSave
        };

        const bufferUpdate = await UpdateUIDMapTCC(objResultAPIUpdateTrans)

        const resultUpdate = JSON.parse(bufferUpdate);

        console.log('CallServiceAddMemberAPI-resultUpdatePerson', resultUpdate);

        const isSaveData = resultAddMemberPersonBYS.Items[0].IsSave

        return isSaveData;
    }
    //นิติบุคคล
    if (data.TypeFrom == '2') {

        const payloadAddMemberJurusticBYS = GenFormAddMemberJurusticBYS(data);

        const resultAPI = await ServiceAddMemberJurusticlBYS(payloadAddMemberJurusticBYS);
        console.log(resultAPI);
        const updatedString = convertBuddhistToGregorianDate(resultAPI)

        //const parsedData = JSON.parse(updatedString);
        //console.log(parsedData);

        const resultAddMemberJurusticBYS = JSON.parse(updatedString)
        console.log(resultAddMemberJurusticBYS);



        const objResultAPIUpdateTrans = {
            Id: objResultUIDMapTCC.ID ?? objRepeatProcess.TransID,
            IsMemberTCC: resultAddMemberJurusticBYS.Items[0].MemberStatus,
            MemberTCCStatus: resultAddMemberJurusticBYS.Items[0].Status,
            TransactionId: resultAddMemberJurusticBYS.TransactionId,
            IsRegisterSuccess: resultAddMemberJurusticBYS.Items[0].IsSave
        };

        const bufferUpdate = await UpdateUIDMapTCC(objResultAPIUpdateTrans)

        const resultUpdate = JSON.parse(bufferUpdate);

        console.log('CallServiceAddMemberAPI-resultUpdateJurustic', resultUpdate);

        const isSaveData = resultAddMemberJurusticBYS.Items[0].IsSave

        return isSaveData;
    }

}
function maskString(str, start, end, change) {
    return str.substring(0, start) + change + str.substring(end);
}
function btnMemberStatus(status) {

    let btnConnectTCC = document.getElementById("btnConnectTCC");
    let btnRepeatAPITCC = document.getElementById("btnRepeatAPITCC")

    switch (status) {
        case "registerRepeatAPI":
            btnConnectTCC.style.display = "none"
            btnRepeatAPITCC.style.display = "block"
            break;
        case "registerComplete":
            btnConnectTCC.style.display = "block"
            btnRepeatAPITCC.style.display = "none"
            break;
        case "waitRegister":
            btnConnectTCC.style.display = "none"
            btnRepeatAPITCC.style.display = "none"
            break;
        default:
            btnConnectTCC.style.display = "none"
            btnRepeatAPITCC.style.display = "none"
            break;
    }

}

function GenPreviewMemberStatus(obj) {

    const data = obj

    if (data.TypeFrom == '1') {
        document.getElementById("txtMemberName").textContent = 'คุณ ' + data.firstName;
        /*        document.getElementById("txtRegisterNo").textContent = maskString(data.registerNo, 4, 9, '*****');*/
        //document.getElementById("txtMemberMobileContact").textContent = maskString(data.mobile, 3, 7, '****');

        if (data.TypeFrom === '1') {
            document.getElementById("txtTypeFrom").textContent = 'บุคคลธรรมดา';
        }
        else {
            document.getElementById("txtTypeFrom").textContent = 'ไม่สามารถระบุได้';
        }

        if (data.InformationId != null && data.IsRegisterSuccess == null) {
            document.getElementById("txtMemberStatusLast").textContent = 'ไม่พบประวัติการส่งใบสมัคร';
            btnMemberStatus("registerRepeatAPI");
        }

        if (data.InformationId != null && data.IsRegisterSuccess == false) {
            document.getElementById("txtMemberStatusLast").textContent = 'ส่งข้อมูลไม่สำเร็จ';
            btnMemberStatus("registerRepeatAPI");
        }

        if (data.InformationId != null && data.IsRegisterSuccess == true) {
            document.getElementById("txtMemberStatusLast").textContent = 'สมัครสภาชิกสภาหอการค้าเรียบร้อย';
            btnMemberStatus("registerComplete");
        }

        return true;
    }

    if (data.TypeFrom === '2') {

        document.getElementById("txtMemberName").textContent = 'ชื่อกิจการ ' + data.companyName;
        //document.getElementById("txtRegisterNo").textContent = maskString(data.registerNo, 4, 9, '*****');
        //document.getElementById("txtMemberMobileContact").textContent = maskString(data.contactMobile, 3, 7, '****');


        if (data.TypeFrom === '2') {
            document.getElementById("txtTypeFrom").textContent = 'นิติบุคคล';
        }
        else {
            document.getElementById("txtTypeFrom").textContent = 'ไม่สามารถระบุได้';
        }

        if (data.InformationId != null && data.IsRegisterSuccess == false) {
            document.getElementById("txtMemberStatusLast").textContent = 'ส่งข้อมูลไม่สำเร็จ';
            btnMemberStatus("registerRepeatAPI");
        }

        if (data.InformationId != null && data.IsRegisterSuccess == true) {
            document.getElementById("txtMemberStatusLast").textContent = 'สมัครสภาชิกสภาหอการค้าเรียบร้อย';
            btnMemberStatus("registerComplete");
        }

        return true;
    }


    return false;
}
async function GenPreviewData() {

    const uid = objResultUIDMapTCC.Uid
    const result = false
    if (uid == null || uid == undefined || uid == 'undefined') return SwalCaseTCC("1");

    const buffer = await GetUidDataTCCAsync(uid)
    //console.log(buffer)
    const bufferResult = JSON.parse(buffer);
    //console.log('GenPreviewData-bufferResult',bufferResult);

    if (bufferResult.RESULT_STATUS == 'OK' && bufferResult.RESULT_OBJ[0].InformationId != null) {

        const resultData = bufferResult.RESULT_OBJ[0];

        const resultGen = GenPreviewMemberStatus(resultData);

        return resultGen;

    }
    return result

}
async function SubmitTransaction() {

    const _typeForm = objRegister.typeForm

    if (_typeForm == '1') {

        const resultUpdate = await UpdateInfoPerson();

        if (resultUpdate != null && resultUpdate.RESULT_STATUS == "OK") {

            const data = resultUpdate.RESULT_OBJ.Table[0];
            const resultsaveData = await CallServiceAddMemberAPI(data);

            console.log('SubmitTransactionPerson-resultsaveData', resultsaveData)

            if (resultsaveData != null && resultsaveData == true) {

                const resultStepGen = await GenPreviewData();

                if (resultStepGen === true) {

                    RedirectTo("TCCMemberStatusPage");

                }
            }

            const resultStepGen = await GenPreviewData();

            if (resultStepGen === true) {
                SwalCaseTCC("3")
            }

        }
        else SwalCaseTCC("1")
    }
    if (_typeForm == '2') {

        const resultUpdateJurustic = await UpdateInfoJurustic();

        if (resultUpdateJurustic != null && resultUpdateJurustic.RESULT_STATUS == "OK") {

            const data = resultUpdateJurustic.RESULT_OBJ.Table[0];
            const resultsaveData = await CallServiceAddMemberAPI(data);

            console.log('SubmitTransactionJurustic-resultsaveData', resultsaveData)

            if (resultsaveData != null && resultsaveData == true) {

                const resultStepGen = await GenPreviewData();

                if (resultStepGen === true) {

                    RedirectTo("TCCMemberStatusPage");

                }
            }
            const resultStepGen = await GenPreviewData();

            if (resultStepGen === true) {
                SwalCaseTCC("3")
            }

        }
        else SwalCaseTCC("1")
    }
}
async function RepeatAPITCC() {

    disableButton('disable', 'btnRepeatAPITCCA')

    let uid = objResultUIDMapTCC.Uid
    const uidLine = getCookie("uid");
    if (uid == undefined) {
        uid = uidLine;
    }

    if (uid == null || uid == undefined || uid == 'undefined') return SwalCaseTCC("1");

    const buffer = await GetUidDataTCCAsync(uid)
    //console.log(buffer)
    const bufferResult = JSON.parse(buffer);

    if (bufferResult.RESULT_STATUS == 'OK' && bufferResult.RESULT_OBJ[0].InformationId != null) {

        const resultData = bufferResult.RESULT_OBJ[0];

        if (resultData.TypeFrom == '1') {
            const saveData = await CallServiceAddMemberAPI(resultData);
            console.log('saveDataTCCPerson :', saveData);
            if (saveData != null && saveData == true) {
                SwalCaseTCC("3")
            }
            else SwalCaseTCC("4")
        }

        if (resultData.TypeFrom == '2') {
            const saveData = await CallServiceAddMemberAPI(resultData);
            console.log('saveDataTCCJurustic :', saveData);
            if (saveData != null && saveData == true) {
                SwalCaseTCC("3")
            }
            else SwalCaseTCC("4")
        }
    }
}
function BackToMain() {
    redirectToMain();
}
function ConnectTCC() {
    redirectToMain();
}


/** SETTING CARD*/

/**
 * 
 * @param {"textOverlay1"|"textOverlay2"|"textOverlay3"|"textOverlay4"|"textOverlay5"|"textOverlay6"|"textOverlay7"} _textOverlayId 
 * @param {"tccOverlay1"|"tccOverlay2"|"tccOverlay3"|"tccOverlay4"|"tccOverlay5"|"tccOverlay6"|"tccOverlay7"} _tccOverlayId
 *
 * 
*/
function setTextPosition(_textOverlayId, x, y) {
    const image = document.getElementById('image');
    const textOverlay = document.getElementById(_textOverlayId);
    //console.log(textOverlay.id);

    // คำนวณตำแหน่งของข้อความตามเปอร์เซ็นต์ของรูปภาพ
    const imageWidth = image.clientWidth;
    const imageHeight = image.clientHeight;

    // กำหนดตำแหน่ง (x, y) เป็นเปอร์เซ็นต์ของรูปภาพ
    const posX = (x / 100) * imageWidth;
    const posY = (y / 100) * imageHeight;

    // ตั้งค่าตำแหน่งของข้อความ
    textOverlay.style.left = `${posX}px`;
    textOverlay.style.top = `${posY}px`;

    // ปรับขนาดข้อความตามขนาดของรูปภาพ
    const fontSize = imageWidth * 0.05; // 5% ของความกว้างรูปภาพ
    textOverlay.style.fontSize = `${fontSize}px`;


    if (textOverlay.id == 'textOverlay1') {
        const fontSize = imageWidth * 0.06;
        textOverlay.style.fontSize = `${fontSize}px`;
    }
    if (textOverlay.id == 'textOverlay2' || textOverlay.id == 'textOverlay5') {
        const fontSize = imageWidth * 0.05; // 
        textOverlay.style.fontSize = `${fontSize}px`;
    }
    if (textOverlay.id == 'textOverlay3' || textOverlay.id == 'textOverlay7') {
        const fontSize = imageWidth * 0.04; // 
        textOverlay.style.fontSize = `${fontSize}px`;
    }
    if (textOverlay.id == 'textOverlay4' || textOverlay.id == "textOverlay6") {
        const fontSize = imageWidth * 0.03;
        textOverlay.style.fontSize = `${fontSize}px`;
    }

    // กำหนดขนาดของรูปโปรไฟล์ (5% ของความกว้างรูปภาพหลัก)
    const profileSize = imageWidth * 0.30;
    profileImage.style.width = `${profileSize}px`;
    profileImage.style.height = `${profileSize}px`;

    // กำหนดตำแหน่งของรูปโปรไฟล์ (ตัวอย่าง: 10% จากซ้าย, 10% จากบน)
    const profileX = imageWidth * 0.60;
    const profileY = imageHeight * 0.40;
    profileImage.style.left = `${profileX}px`;
    profileImage.style.top = `${profileY}px`;
}

function tccSetTextPosition(_tccOverlayId, x, y) {

    const tccimage = document.getElementById('tcccardimage')
    const tccOverlay = document.getElementById(_tccOverlayId)

    // คำนวณตำแหน่งของข้อความตามเปอร์เซ็นต์ของรูปภาพ
    const imageWidth = tccimage.clientWidth;
    const imageHeight = tccimage.clientHeight;

    // กำหนดตำแหน่ง (x, y) เป็นเปอร์เซ็นต์ของรูปภาพ
    const tccPosX = (x / 100) * imageWidth;
    const tccPosY = (y / 100) * imageHeight

    // ตั้งค่าตำแหน่งของข้อความ
    tccOverlay.style.left = `${tccPosX}px`;
    tccOverlay.style.top = `${tccPosY}px`;

    // ปรับขนาดข้อความตามขนาดของรูปภาพ
    const tccfontSize = imageWidth * 0.05
    tccOverlay.style.fontSize = `${tccfontSize}px`;

    if (tccOverlay.id == 'tccOverlay1') {
        const fontSize = imageWidth * 0.06;
        tccOverlay.style.fontSize = `${fontSize}px`;
    }
    if (tccOverlay.id == 'tccOverlay2' || tccOverlay.id == 'tccOverlay5') {
        const fontSize = imageWidth * 0.05; // 
        tccOverlay.style.fontSize = `${fontSize}px`;
    }
    if (tccOverlay.id == 'tccOverlay3' || tccOverlay.id == 'tccOverlay7') {
        const fontSize = imageWidth * 0.04; // 
        tccOverlay.style.fontSize = `${fontSize}px`;
    }
    if (tccOverlay.id == 'tccOverlay4' || tccOverlay.id == "tccOverlay6") {
        const fontSize = imageWidth * 0.03;
        tccOverlay.style.fontSize = `${fontSize}px`;
    }

    // กำหนดขนาดของรูปโปรไฟล์ (5% ของความกว้างรูปภาพหลัก)
    const tccProfileSize = imageWidth * 0.30;
    tccprofileImage.style.width = `${tccProfileSize}px`;
    tccprofileImage.style.height = `${tccProfileSize}px`;

    // กำหนดตำแหน่งของรูปโปรไฟล์ (ตัวอย่าง: 10% จากซ้าย, 10% จากบน)
    const tccProfileX = imageWidth * 0.60;
    const tccProfileY = imageHeight * 0.40;
    tccprofileImage.style.left = `${tccProfileX}px`;
    tccprofileImage.style.top = `${tccProfileY}px`;

}

window.addEventListener('load', () => {
    setTextPosition('textOverlay1', 35, 18); // Text Overlay 1
    setTextPosition('textOverlay2', 5, 35); // Text Overlay 2 
    setTextPosition('textOverlay3', 5, 42); // Text Overlay 3'
    setTextPosition('textOverlay4', 5, 60);
    setTextPosition('textOverlay5', 5, 67);
    setTextPosition('textOverlay6', 5, 85);
    setTextPosition('textOverlay7', 5, 92);

    tccSetTextPosition('tccOverlay1', 35, 18); // Text Overlay 1
    tccSetTextPosition('tccOverlay2', 5, 35); // Text Overlay 2 
    tccSetTextPosition('tccOverlay3', 5, 42); // Text Overlay 3'
    tccSetTextPosition('tccOverlay4', 5, 60);
    tccSetTextPosition('tccOverlay5', 5, 67);
    tccSetTextPosition('tccOverlay6', 5, 85);
    tccSetTextPosition('tccOverlay7', 5, 92);
}
);
// ปรับตำแหน่งและขนาดเมื่อหน้าจอถูกปรับขนาด
window.addEventListener('resize', () => {
    setTextPosition('textOverlay1', 35, 18); // Text Overlay 1
    setTextPosition('textOverlay2', 5, 35); // Text Overlay 2 
    setTextPosition('textOverlay3', 5, 42); // Text Overlay 3'
    setTextPosition('textOverlay4', 5, 60);
    setTextPosition('textOverlay5', 5, 67);
    setTextPosition('textOverlay6', 5, 85);
    setTextPosition('textOverlay7', 5, 92);

    tccSetTextPosition('tccOverlay1', 35, 18); // Text Overlay 1
    tccSetTextPosition('tccOverlay2', 5, 35); // Text Overlay 2 
    tccSetTextPosition('tccOverlay3', 5, 42); // Text Overlay 3'
    tccSetTextPosition('tccOverlay4', 5, 60);
    tccSetTextPosition('tccOverlay5', 5, 67);
    tccSetTextPosition('tccOverlay6', 5, 85);
    tccSetTextPosition('tccOverlay7', 5, 92);
});


let tccelement = document.getElementById('pnlTCCMemberStatusPage');

tccelement.addEventListener('transitionend', function () {
    if (tccelement.style.display === 'block') {
        setText();
    }
});

function setText() {
    console.log('Display เปลี่ยนเป็น block!');
    tccSetTextPosition('tccOverlay1', 35, 18); // Text Overlay 1
    tccSetTextPosition('tccOverlay2', 5, 35); // Text Overlay 2 
    tccSetTextPosition('tccOverlay3', 5, 42); // Text Overlay 3'
    tccSetTextPosition('tccOverlay4', 5, 60);
    tccSetTextPosition('tccOverlay5', 5, 67);
    tccSetTextPosition('tccOverlay6', 5, 85);
    tccSetTextPosition('tccOverlay7', 5, 92);
}

// เลือก element ที่คุณต้องการตรวจสอบ
const element = document.getElementById('pnlTCCMemberStatusPage');

// สร้าง instance ของ MutationObserver
const observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        // ตรวจสอบว่า attribute ที่เปลี่ยนแปลงคือ style หรือไม่
        if (mutation.attributeName === 'style') {
            // ตรวจสอบว่า display ถูกตั้งค่าเป็น block หรือไม่
            if (element.style.display === 'block') {
                // เรียกใช้ฟังก์ชัน a()
                a();
            }
        }
    });
});

// กำหนดค่า configuration ของ Observer:
const config = {
    attributes: true, // สังเกต attribute ที่มีการเปลี่ยนแปลง
    attributeFilter: ['style'] // กรองเฉพาะ attribute style
};

// เริ่มสังเกต element ที่กำหนด
observer.observe(element, config);

// ฟังก์ชัน a() ที่คุณต้องการเรียกใช้
function a() {
    console.log('Display เปลี่ยนเป็น block!');
    // โค้ดที่คุณต้องการให้ทำงาน
    tccSetTextPosition('tccOverlay1', 35, 18); // Text Overlay 1
    tccSetTextPosition('tccOverlay2', 5, 35); // Text Overlay 2 
    tccSetTextPosition('tccOverlay3', 5, 42); // Text Overlay 3'
    tccSetTextPosition('tccOverlay4', 5, 60);
    tccSetTextPosition('tccOverlay5', 5, 67);
    tccSetTextPosition('tccOverlay6', 5, 85);
    tccSetTextPosition('tccOverlay7', 5, 92);

}