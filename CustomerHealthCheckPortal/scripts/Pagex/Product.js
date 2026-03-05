
const container = document.getElementById("confirmFinishStep");
const modal = new bootstrap.Modal(container);

document.getElementById("btnCFClose").addEventListener("click", function () {
    modal.hide();
});
document.getElementById("btnCFSave").addEventListener("click", function () {

    loaderStep4(true);
});

function GetMockDetail() {

    var pID = getCookie("pid");
    switch (pID) {
        case "P004":

            document.getElementById("lblStep3Header").innerHTML = "โครงการค้ำประกันสินเชื่อรายสถาบันการเงินระยะที่ 7 (BI7)";
            document.getElementById("lblStep3Detail").innerHTML = "ผู้ประกอบการ SMEs ทั่วไป เพื่อธุรกิจทุกประเภทยกเว้นสินเชื่อเช่าซื้อและสินเชื่อแบบลิสซิ่ง  ที่ต้องการสินเชื่อใหม่ และขาดหลักประกันเพื่อช่วยให้ SMEs สามารถกู้เงิน และได้รับเงินกู้ หรือสินเชื่อในระบบสถาบันการเงินที่เข้าร่วมโครงการตามเงื่อนไขที่กำหนด เพื่อใช้ในการดำเนินธุรกิจ และช่วยเสริมสภาพคล่อง";
            break;
        case "P006":
            document.getElementById("lblStep3Header").innerHTML = "โครงการคํ้าประกันสินเชื่อดอกเบี้ยถูก";
            document.getElementById("lblStep3Detail").innerHTML = "• 2 ปีแรก 3%  อัตราดอกเบี้ย 2% + ค่าธรรมเนียมค้ำประกัน 1% <br />• 5 ปีแรก อัตราดอกเบี้ยเฉลี่ย ไม่เกิน 5% ต่อปี<br />• ค้ำประกันสูงสุด 10 ปี";
            break;
        case "P005":
            document.getElementById("lblStep3Header").innerHTML = "โครงการต่ออายุคํ้าประกัน Renew";
            document.getElementById("lblStep3Detail").innerHTML = "• ช่วยเหลือผู้ประกอบการเดิมที่สิ้นสุดการค้ำประกันจาก บสย.<br />• ค้ำประกันขั้นต่ำ 7 ปี<br />• ค่าธรรมเนียมค้ำประกันเริ่มต้น 1.75%";
            break;
        default:
            break;
    }
}

function loaderStep4(isShow) {
    if (isShow) {
        var cfBodyWording = document.getElementById("confirmFinishStepPanel");
        var cfBodyLoader = document.getElementById("confirmFinishStepLoader");
        var cfBtnClose = document.getElementById("btnCFClose");
        var cfBtnSubmit = document.getElementById("btnCFSave");

        //cfBodyWording.style.display = "none";
        //cfBodyLoader.style.display = "block";
        cfBtnClose.classList.add("disableOnLoading");
        cfBtnSubmit.classList.add("disableOnLoading");
        cfBtnSubmit.innerText = "กำลังบันทึก . . .";
    }
}
function KeepHealthCheckCookie(itemID) {

    setCookie("hcid", itemID, 3650);
    console.log(getCookie("hcid"));
    redirectToStep3();

}
function KeepProductCookie(productID) {
    setCookie("pid", productID, 3650);
    let uid = getCookie("uid");

    console.log("Step2 Get UID : " + uid + " PID : " + productID);

    var result = GetApprochByUIDAndPCode(productID, uid);
    console.log("Step2 Get IsRegisterProdicut is : " + result);
    if (result === '"OK"') {
        const modalElement = document.getElementById("checkRegisterModal");
        const modalDiv = new bootstrap.Modal(modalElement);

        modalDiv.show();
    } else {
        redirectToStep2();
    }
}

function CheckSendBank() {
    var checkCount = 0;
    var inputs = document.querySelectorAll("input[type=checkbox]");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].checked === true) {
            checkCount++;
        }
    }

    if (checkCount > 0) {
        var confirmFinishModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmFinishStep'));
        confirmFinishModal.show();
    } else {
        var notFoundModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('NotFoundBank'));
        notFoundModal.show();
    }
}
function CheckRegisterSameProduct() {

}

function GenerateUIDObject() {

    var lstObj = [];
    var inputs = document.querySelectorAll("input[type=checkbox]");

    for (var i = 0; i < inputs.length; i++) {

        if (inputs[i].type.toLowerCase() === 'checkbox') {



            if (inputs[i].checked === true) {
                var bankEmail = inputs[i].value;
                var bankCode = inputs[i].id.replace('switch-', '');
                var obj = {
                    ApprochID: getCookie("approchid"),
                    BankCode: bankCode,
                    BankEmail: bankEmail,
                    CreatedBy: 'system'
                };
                lstObj.push(obj);
            }
        }
    }
    return lstObj;
}

function FinishStep() {



    var resultCallAPI = "";
    let promise = new Promise(function (resolve, reject) {
        setTimeout(() => resolve(1), 1000);
    });

    promise.then(function (result) {

        return result * 2;
    });

    promise.then(function (result) {
        var approchID = getCookie("approchid");
        var buffer = GenerateUIDObject();
        resultCallAPI = InsertApprochMapBank(buffer, approchID);
        return result * 2;
    });

    promise.then(function (result) {

        if (resultCallAPI != "undefined" && resultCallAPI === '"OK"') {
            modal.hide();

            var successFinishModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('successFinishStep'));
            successFinishModal.show();
        }
        return result * 2;
    });

    //loaderStep4(true);

    //var approchID = getCookie("approchid");

    //var buffer = GenerateUIDObject();
    //var result = InsertApprochMapBank(buffer, approchID);




    //if (result != "undefined" && result === '"OK"') {

    //    modal.hide();

    //    var successFinishModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('successFinishStep'));
    //    successFinishModal.show();
    //}


}




