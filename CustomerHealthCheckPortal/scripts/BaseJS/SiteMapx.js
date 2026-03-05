
// Main
function redirectToMain() {

    window.location.href = host + "/index_inno.aspx";
}
function redirectToOriginalTcgWebsite() {
    url = "https://www.tcg.or.th/index.php";
    window.location.href = url;
}


//----------------------Detail-----------------------
//HealthCheck
function redirectToHealthCheck() {

    let customerHealthCheckURL = document.getElementById('hddCustomerHealthCheckURL').value
    window.location.href = "https://chatclinic.tcg.or.th/customerHealth_dev/ui/default.aspx";
}

//Product
function redirectToProduct() {
    let productURL = document.getElementById('hddProductURL').value
    window.location.href = host + "/viewx/PreApproch/Step1.aspx";
}
function redirectToStep1() {

    window.location.href = host + "/viewx/PreApproch/step1.aspx";
}
function redirectToStep2() {

    window.location.href = host + "/viewx/PreApproch/step2.aspx";
}
function redirectToStep3() {


    window.location.href = host + "/viewx/PreApproch/step3.aspx";
}
function redirectToStep4() {

    window.location.href = host + "/viewx/PreApproch/step4.aspx";
}

//NDID
function redirectToNDID() {

    let NDIDUrl = document.getElementById('hddNDIDURL').value
    window.location.href = host + NDIDUrl;
}
function redirectToNDIDStep1() {

    window.location.href = host + "/viewx/NDID/step1.aspx";
}
function redirectToNDIDStep2() {

    window.location.href = host + "/viewx/NDID/step2.aspx";
}
function redirectToNDIDStep3() {

    window.location.href = host + "/viewx/NDID/step3.aspx";
}
function redirectToNDIDStep4() {

    window.location.href = host + "/viewx/NDID/step4.aspx";
}
function redirectToNDIDStep5() {

    window.location.href = host + "/viewx/NDID/step5.aspx";
}

//Debt
function redirectToDebt() {

    let debtURL = document.getElementById('hddDebtURL').value
    window.location.href = host + "/viewx/Debt/package.aspx";
}
function redirectToDebtStep1() {
    let url = document.getElementById('hddDebtURL').value
    window.location.href = host + "/viewx/Debt/package.aspx";
}
function redirectToDebtStep2() {
    window.location.href = host + "/viewx/Debt/register.aspx";
}

//Dopa
function redirectToIdentify() {

    let IdentifyURL = document.getElementById('hddIdentifyURL').value
    window.location.href = host + "/viewx/Identify/Step1.aspx";
}

//Events
function redirectToEvent() {
    let IdentifyURL = document.getElementById('hddEventURL').value
    window.location.href = host + "/viewx/Event/index.aspx";
}

//Register
function redirectToRegister() {
    let EventRegisterURL = document.getElementById('hddRegisterURL').value
    window.location.href = host + "/viewx/Register/index.aspx";
}

function redirectToQuestionaire() {
    let RegisterURL = document.getElementById('hddRegisterURL').value
    window.location.href = host + "/viewx/Register/index.aspx";
}

function redirectToMyLG() {
    window.location.href = host + "/viewx/LG/index.aspx";
}
function redirectToQueue() {
    window.location.href = host + "/viewx/Booking/index.aspx";
}
function redirectToPayment() {
    window.location.href = host + "/viewx/bill/index.aspx";
}
function redirectToCal() {
    window.location.href = host + "/viewx/Cal/index.aspx";
}