
function InitialCountDown() {

    //var fiveMinutes = 60 * 5,
    //    display = $('#time');
    //startTimer(fiveMinutes, display);

    var minute = 59;
    var sec = 59;
    setInterval(function () {
        document.getElementById("timer").innerHTML = minute + ":" + sec;
        sec--;

        if (sec == 00) {
            minute--;
            sec = 60;

            if (minute == 0) {
                minute = 5;
            }
        }

        

    }, 1000);

}
function startTimer(duration, display) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.text(minutes + ":" + seconds);

        if (--timer < 0) {
            timer = duration;
        }
    }, 1000);
}

function SubmitConditionStep1() {
    redirectToNDIDStep2();
}
function SubmitConditionStep2() {
    redirectToNDIDStep3();
}
function SubmitConditionStep3() {   
    var bufferObj = GenerateUIDObject();
    var result = InsertCustomerChooseIDP(bufferObj);
    if (result != "undefined" && result === '"OK"') {
        redirectToNDIDStep4();
    }
   
}

function ShowModalConfirmStep3() {
    const container = document.getElementById("confirmChooseIDPModal");
    const modal = new bootstrap.Modal(container);
    modal.show();
}
function SubmitConditionStep4() {
    redirectToNDIDStep5();
}

function GenerateUIDObject() {

    var lstObj = [];
    var inputs = document.querySelectorAll("input[type=checkbox]");
    var transID = getCookie("ndidtransid");
    for (var i = 0; i < inputs.length; i++) {

        if (inputs[i].type.toLowerCase() === 'checkbox') {

            if (inputs[i].checked === true) {
                var bufferValue = inputs[i].value.split('_');
                var idpCode = bufferValue[0];
                var nodeID = bufferValue[1];
                var obj = {
                    UID: getCookie("uid"),
                    IDPVerifyStatus: "001",
                    IDPVerifyRemark: "เลือก IDP แล้ว",
                    IDPCode: idpCode,
                    IDPName: "",
                    Status: true,
                    TransactionID: transID,
                    CreatedBy: 'system',
                    UpdatedBy: 'system'
                };
                lstObj.push(obj);
            }
        }
    }
    return lstObj;
}



