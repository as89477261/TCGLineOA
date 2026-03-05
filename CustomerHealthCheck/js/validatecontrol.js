$(function () {

    /* มูลค่าสินทรัพย์รวมของกิจการ - สำหรับใส่คอมม่าและทศนิยม */
    $("input[id$='txtAssetValue']").change(function () {
        $("input[id$='txtAssetValue']").val(accounting.formatNumber($("input[id$='txtAssetValue']").val(), 2, ',', '.'));
    });

    /* หนี้สินรวมของกิจการ - สำหรับใส่คอมม่าและทศนิยม */
    $("input[id$='txtDebtValue']").change(function () {
        $("input[id$='txtDebtValue']").val(accounting.formatNumber($("input[id$='txtDebtValue']").val(), 2, ',', '.'));
    });

    /* รายได้รวมของกิจการ - สำหรับใส่คอมม่าและทศนิยม */
    $("input[id$='txtIncome']").change(function () {
        $("input[id$='txtIncome']").val(accounting.formatNumber($("input[id$='txtIncome']").val(), 2, ',', '.'));
    });

    /* กิจการคุณมีค่าใช้จ่าย - สำหรับใส่คอมม่าและทศนิยม */
    $("input[id$='txtExpense']").change(function () {
        $("input[id$='txtExpense']").val(accounting.formatNumber($("input[id$='txtExpense']").val(), 2, ',', '.'));
    });

    /* ภาระหนี้ที่ต้องผ่อนชําระ - สำหรับใส่คอมม่าและทศนิยม */
    $("input[id$='txtInstallmentAmount']").change(function () {
        $("input[id$='txtInstallmentAmount']").val(accounting.formatNumber($("input[id$='txtInstallmentAmount']").val(), 2, ',', '.'));
    });

    /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ - สำหรับใส่คอมม่าและทศนิยม */
    $("input[id$='txtLoanAmount']").change(function () {
        $("input[id$='txtLoanAmount']").val(accounting.formatNumber($("input[id$='txtLoanAmount']").val(), 2, ',', '.'));
    });

    /* อายุกิจการ - สำหรับรับ input เฉพาะตัวเลข */
    //$("input[id$='txtYearIncorporate']").change(function () {
    //    $("input[id$='txtYearIncorporate']").val(accounting.formatNumber($("input[id$='txtYearIncorporate']").val(), 0));

    //    if ($("input[id$='txtYearIncorporate']").val() == '' || $("input[id$='txtYearIncorporate']").val() <= 0) {

    //        $("label[id$='lblYearIncorporate']").css('color', 'red');
    //        $("input[id$='txtYearIncorporate']").css('border-color', 'red');
    //    }
    //});

    $("input[id$='txtYearIncorporate']").change(function () {
        $("input[id$='txtYearIncorporate']").val(accounting.formatNumber($("input[id$='txtYearIncorporate']").val(), 0, '', ''));
    });

    /* อายุผู้บริหารหลัก - สำหรับรับ input เฉพาะตัวเลข */
    $("input[id$='txtOwnerAge']").change(function () {
        $("input[id$='txtOwnerAge']").val(accounting.formatNumber($("input[id$='txtOwnerAge']").val(), 0, '', ''));
    });

    /* ประสบการณ์โดยตรงในการทําธุรกิจนี้ - สำหรับรับ input เฉพาะตัวเลข */
    $("input[id$='txtBizExperience']").change(function () {
        $("input[id$='txtBizExperience']").val(accounting.formatNumber($("input[id$='txtBizExperience']").val(), 0, '', ''));
    });

    /* ปรับโครงสร้างหนี้ จำนวน - สำหรับรับ input เฉพาะตัวเลข */
    $("input[id$='txtTdrAmount']").change(function () {
        $("input[id$='txtTdrAmount']").val(accounting.formatNumber($("input[id$='txtTdrAmount']").val(), 0, '', ''));
    });

    /* ปรับโครงสร้างหนี้ พศ - สำหรับรับ input เฉพาะตัวเลข */
    $("input[id$='txtTdrYear']").change(function () {
        $("input[id$='txtTdrYear']").val(accounting.formatNumber($("input[id$='txtTdrYear']").val(), 0, '', ''));
    });

    /* ระยะเวลาในการผ่อนชําระที่คุณต้องการ - สำหรับรับ input เฉพาะตัวเลข */
    $("input[id$='txtInstallmentYear']").change(function () {
        $("input[id$='txtInstallmentYear']").val(accounting.formatNumber($("input[id$='txtInstallmentYear']").val(), 0, '', ''));
    });

});

function valStep1() {

    var valid = true;

    if (document.querySelector('input[name="personType"]:checked') == null) {
        $("label[id$='lblPersonType']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblPersonType']").css('color', '');

    if (document.querySelector('input[name="officeType"]:checked') == null) {
        $("label[id$='lblOfficeType']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblOfficeType']").css('color', '');

    if ($("#txtYearIncorporate").val() == "" || $("#txtYearIncorporate").val() <= 0 || $("#txtYearIncorporate").val() > 150)  {
        $("label[id$='lblYearIncorporate']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblYearIncorporate']").css('color', '');

    if ($("#ddIndustry").val() == 0) {
        $("label[id$='lblIndustry']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblIndustry']").css('color', '');

    if ($("#ddProvince").val() == 0) {
        $("label[id$='lblProvince']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblProvince']").css('color', '');

    return valid;
}

function valStep2() {

    var valid = true;

    if ($("#txtOwnerAge").val() == "" || $("#txtOwnerAge").val() <= 0 || $("#txtOwnerAge").val() > 80) {
        $("label[id$='lblOwnerAge']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblOwnerAge']").css('color', '');

    if ($("#ddMaritalStatus").val() == 0) {
        $("label[id$='lblMaritalStatus']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblMaritalStatus']").css('color', '');

    if ($("#txtYearExperience").val() == "" || $("#txtYearExperience").val() <= 0 || $("#txtYearExperience").val() > 150) {
        $("label[id$='lblYearExperience']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblYearExperience']").css('color', '');

    return valid;
}

function valStep3() {

    var valid = true;
    var year = ((new Date().getFullYear()) + 543);


    if ($("#ddDebtStatus").val() == 3) {
        if ($("#txtTdrAmount").val() == "" || $("#txtTdrAmount").val() <= 0 || $("#txtTdrAmount").val() > 10) {
            $("label[id$='lblTdrAmount']").css('color', 'red');
            valid = false;
        }
        else
            $("label[id$='lblTdrAmount']").css('color', '');
        /*if ($("#txtTdrYear").val() == "" || $("#txtTdrYear").val() < 2500 || $("#txtTdrYear").val() > 2565) {*/
        if ($("#txtTdrYear").val() == "" || $("#txtTdrYear").val() < 2500 || $("#txtTdrYear").val() > year) {
            $("label[id$='lblTdrYear']").css('color', 'red');
            valid = false;
        }
        else
            $("label[id$='lblTdrYear']").css('color', '');
    }
    else {
        $("label[id$='lblTdrAmount']").css('color', '');
    }
    var assetValue = $("#txtAssetValue").val().replace(/[$,]+/g, "").replace(".00", "");
    /*if ($("#txtAssetValue").val() == "" || $("#txtAssetValue").val() < 0 || $("#txtAssetValue").val() > 1000000000) {*/
    if ($("#txtAssetValue").val() == "" || assetValue <= 0 || assetValue > 1000000000) {
        $("label[id$='lblAssetValue']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblAssetValue']").css('color', '');

    var debtValue = $("#txtDebtValue").val().replace(/[$,]+/g, "").replace(".00", "");
    /*  if ($("#txtDebtValue").val() == "" || $("#txtDebtValue").val() < 0 || $("#txtDebtValue").val() > 1000000000) {*/
    if ($("#txtDebtValue").val() == "" || debtValue < 0 || debtValue > 1000000000) {
        $("label[id$='lblDebtValue']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblDebtValue']").css('color', '');

    return valid;
}

function valStep4() {

    var valid = true;

    var IncomeValue = $("#txtIncome").val().replace(/[$,]+/g, "").replace(".00", "");;
    /* if ($("#txtIncome").val() == "" || $("#txtIncome").val() < 0 || $("#txtIncome").val() > 1000000000) {*/
    if ($("#txtIncome").val() == "" || IncomeValue <= 0 || IncomeValue > 1000000000) {
        $("label[id$='lblIncome']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblIncome']").css('color', '');

    var ExpenseValue = $("#txtExpense").val().replace(/[$,]+/g, "").replace(".00", "");;
   /* if ($("#txtExpense").val() == "" || $("#txtExpense").val() < 0 || $("#txtExpense").val() > 1000000000) {*/
    if ($("#txtExpense").val() == "" || ExpenseValue <= 0 || ExpenseValue > 1000000000) {
        $("label[id$='lblExpense']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblExpense']").css('color', '');

    var InstallmentAmountValue = $("#txtInstallmentAmount").val().replace(/[$,]+/g, "").replace(".00", "");;
    //if ($("#txtInstallmentAmount").val() == "" || $("#txtInstallmentAmount").val() < 0 || $("#txtInstallmentAmount").val() > 1000000000) {
    if ($("#txtInstallmentAmount").val() == "" || InstallmentAmountValue < 0 || InstallmentAmountValue > 1000000000) {
        $("label[id$='lblInstallmentAmount']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblInstallmentAmount']").css('color', '');

    return valid;
}

function valStep5() {

    var valid = true;

    if (document.querySelector('input[name="radioIsGetProfit"]:checked') == null) {
        $("label[id$='lblGetProfitYes']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblGetProfitYes']").css('color', '');

    var LoanAmountValue = $("#txtLoanAmount").val().replace(/[$,]+/g, "").replace(".00", "");;
    if ($("#txtLoanAmount").val() == "" || LoanAmountValue <= 0 || LoanAmountValue > 1000000000) {
/*    if ($("#txtLoanAmount").val() == "" || $("#txtLoanAmount").val() < 0 || $("#txtLoanAmount").val() > 1000000000) {*/
        $("label[id$='lblLoanAmount']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblLoanAmount']").css('color', '');

    if ($("#txtInstallmentYear").val() == "" || $("#txtInstallmentYear").val() <= 0 || $("#txtInstallmentYear").val() > 30) {
        $("label[id$='lblInstallmentYear']").css('color', 'red');
        valid = false;
    }
    else
        $("label[id$='lblInstallmentYear']").css('color', '');

    return valid;
}

function valResult() {

    var valid = true;

    if (isNaN($("#txtPhone").val()) || $("#txtPhone").val() == "" || $("#txtPhone").val().length != 10) {
        $("label[id$='lblPhone']").css('color', 'red');
        valid = false;
    }
    else {
        $("label[id$='lblPhone']").css('color', '');
    }

    if (Script_checkID($("#txtIDCard").val()) || ($("#hdIDCard").val() == "1" && $("#txtIDCard").val().length == 13)) {
        $("span[id$='lblIDCard']").css('color', '');
    }
    else {
        $("span[id$='lblIDCard']").css('color', 'red');
        valid = false;
    }

    return valid;
}

function Script_checkID(id) {
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