//คนทำเบอร์ 9053 ติดต่อแอ๊น
// List Parameters
var currentBankCode = "";
var currentProductCode = "";
var periodType = ""; // short,long
var customerType = ""; // personal,commercial
var MOR = 0;
var MLR = 0;
var MRR = 0;

const containerBankApproved = document.getElementById("ChooseBankModal");
const modalBankApproved = new bootstrap.Modal(containerBankApproved);

const containerProductApproved = document.getElementById("ChooseProductModal");
const modalProductApproved = new bootstrap.Modal(containerProductApproved);

const containerProductDetail = document.getElementById("ShowProductDetailModal");
const modalProductDetail = new bootstrap.Modal(containerProductDetail);


function ShowModalListBank() {
    modalBankApproved.show();
}
function HideModalListBank() {
    modalBankApproved.hide();
}

function ShowModalListProduct() {
    var ddlBank = document.getElementById('ddlBank').value;
    if (ddlBank != "") {
        modalProductApproved.show();
    }
}
function HideModalListProduct() {
    modalProductApproved.hide();
}

function ShowModalDetailProduct(productCode) {

    BindingProductInfo(productCode);
    modalProductDetail.show();
}
function HideModalDetailProduct() {
    modalProductDetail.hide();
}

function RefreshDropDown(thisDDL) {
    if (thisDDL.value == "") {
        thisDDL.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        thisDDL.style.border = "";
    }
}

function GetBankDetail(bankCode, bankName) {
    var ddlBank = document.getElementById('ddlBank');
    var ddlProduct = document.getElementById('ddlProduct');
    var formLabelBank = document.getElementById('formLabelBank');

    ddlBank.value = bankName;
    currentBankCode = bankCode
    ddlProduct.value = "";
    currentProductCode = "";

    HideModalListBank();
    formLabelBank.classList.add('form-label-active')

}
function GetProductDetail(productCode, productName) {
    var ddlProduct = document.getElementById('ddlProduct');
    var formLabelProduct = document.getElementById('formLabelProduct');

    ddlProduct.value = productName;
    currentProductCode = productCode;

    ShowPanelDetail();
    HideModalListProduct();
    formLabelProduct.classList.add('form-label-active')
}
function ShowPanelDetail() {

    var pnlDesc = document.getElementById('pnlDesc');
    var pnlPackageEmpty = document.getElementById('pnlPackageEmpty');

    var pnlPackage3 = document.getElementById('pnlGSB003_s');
    var pnlPackage4 = document.getElementById('pnlGSB003_l');
    var pnlPackage5 = document.getElementById('pnlGSB004');

    if (currentProductCode != "" && currentProductCode != null) {
        pnlDesc.style.display = "block";
        pnlPackageEmpty.style.display = "none";

        switch (currentProductCode) {

            case "GSB003_s":
                pnlPackage3.style.display = "block";
                pnlPackage4.style.display = "none";
                pnlPackage5.style.display = "none";
                break;
            case "GSB003_l":
                pnlPackage3.style.display = "none";
                pnlPackage4.style.display = "block";
                pnlPackage5.style.display = "none";
                break;
            case "GSB004":
                pnlPackage3.style.display = "none";
                pnlPackage4.style.display = "none";
                pnlPackage5.style.display = "block";
                break;
            default:
                break;
        }


        pnlResult.style.display = "none";
    } else {

    }
}

function ChooseProduct(thisDDL) {

    var ddlBank = document.getElementById('ddlBank');
    var pnlDesc = document.getElementById('pnlDesc');
    var pnlPackageEmpty = document.getElementById('pnlPackageEmpty');
    var pnlPackage1 = document.getElementById('pnlPackage1');
    var pnlPackage2 = document.getElementById('pnlPackage2');
    var pnlPackage3 = document.getElementById('pnlPackage3');
    var pnlPackage4 = document.getElementById('pnlPackage4');
    var pnlPackage5 = document.getElementById('pnlPackage5');

    var ddlProduct = document.getElementById('ddlProduct');
    var pnlResult = document.getElementById('pnlResult');

    if (ddlBank.value != "") {
        document.getElementById("ddlProduct").disabled = false;

        if (ddlProduct.value != "" && ddlProduct.value != null) {
            pnlDesc.style.display = "block";
            pnlPackageEmpty.style.display = "none";

            switch (ddlProduct.value) {
                case "GSB001":
                    pnlPackage1.style.display = "block";
                    pnlPackage2.style.display = "none";
                    pnlPackage3.style.display = "none";
                    pnlPackage4.style.display = "none";
                    pnlPackage5.style.display = "none";
                    break;
                case "GSB002":
                    pnlPackage1.style.display = "none";
                    pnlPackage2.style.display = "block";
                    pnlPackage3.style.display = "none";
                    pnlPackage4.style.display = "none";
                    pnlPackage5.style.display = "none";
                    break;
                case "GSB003":
                    pnlPackage1.style.display = "none";
                    pnlPackage2.style.display = "none";
                    pnlPackage3.style.display = "block";
                    pnlPackage4.style.display = "none";
                    pnlPackage5.style.display = "none";
                    break;
                case "GSB004":
                    pnlPackage1.style.display = "none";
                    pnlPackage2.style.display = "none";
                    pnlPackage3.style.display = "none";
                    pnlPackage4.style.display = "block";
                    pnlPackage5.style.display = "none";
                    break;
                case "GSB005":
                    pnlPackage1.style.display = "none";
                    pnlPackage2.style.display = "none";
                    pnlPackage3.style.display = "none";
                    pnlPackage4.style.display = "none";
                    pnlPackage5.style.display = "block";
                    break;
                default:
                    break;
            }


            pnlResult.style.display = "none";
        } else {

        }

    } else {
        document.getElementById("ddlProduct").disabled = true;
        document.getElementById("ddlProduct").value = "";
        var pnlDesc = document.getElementById('pnlDesc');
        pnlDesc.style.display = "none";
    }

    RefreshDropDown(thisDDL);


}
function AddOption() {

    $("input[id$='c1']").change(function () {
        $("input[id$='c1']").val(accounting.formatNumber($("input[id$='c1']").val(), 0, ',', '.'));
    });

}
function AddComma(money) {
    var buffer = accounting.formatNumber(money, 0, ',', '.')
    return buffer;
}

function Reset() {
    var pnlDesc = document.getElementById('pnlDesc');
    var pnlResult = document.getElementById('pnlResult');
    var pnlInfo = document.getElementById('pnlInfo');

    pnlResult.style.display = "none";
    pnlDesc.style.display = "block";
    pnlInfo.style.display = "block";

    ClearForm();
}

function validate() {
    var result = true;
    var amount = document.getElementById('c1');
    var interest = document.getElementById('c2');
    var year = document.getElementById('c2a');
    var bank = document.getElementById('ddlBank');
    var product = document.getElementById('ddlProduct');

    if (amount.value == "") {
        amount.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        amount.style.border = "";
    }

    if (interest.value == "") {
        interest.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        interest.style.border = "";
    }

    if (year.value == "") {
        year.style.border = "1px solid #CF0A0A";
        result = false;
    } else {
        year.style.border = "";
    }

    if (bank != null) {
        if (bank.value == "") {
            bank.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            bank.style.border = "";
        }
    } else {

    }

    if (product != null) {
        if (product.value == "") {
            product.style.border = "1px solid #CF0A0A";
            result = false;
        } else {
            product.style.border = "";
        }
    }

    return result;
}
function BusinessValidate() {
    var result = true;
    var message = "";
    var amount = document.getElementById('c1').value.replaceAll(',', '');
    var year = document.getElementById('c2a').value;
    var bank = document.getElementById('ddlBank').value;
    var product = currentProductCode;/* document.getElementById('ddlProduct').value*/;

    switch (product) {
        case "GSB001":
            if (amount <= 0 || amount > 1000000) {
                message += "จำนวนเงิน ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            if (year <= 0 || year > 10) {
                message += "ระยะเวลา ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            break;
        case "GSB002":
            if (amount <= 0 || amount > 500000) {
                message += "จำนวนเงิน ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            if (year <= 0 || year > 10) {
                message += "ระยะเวลา ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            break;
        ///////////////////
        case "GSB003_s":
            if (amount <= 0 || amount > 50000000) {
                message += "จำนวนเงิน ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            if (year <= 0 || year > 1) {
                message += "ระยะเวลา ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            break;
        case "GSB003_l":
            if (amount <= 0 || amount > 50000000) {
                message += "จำนวนเงิน ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            if (year <= 1 || year > 10) {
                message += "ระยะเวลา ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            break;
        case "GSB004":
            if (amount <= 0 || amount > 100000) {
                message += "จำนวนเงิน ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            if (year <= 0 || year > 8) {
                message += "ระยะเวลา ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            break;
        case "GSB005":
            if (amount <= 0 || amount > 500000) {
                message += "จำนวนเงิน ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            if (year <= 0 || year > 10) {
                message += "ระยะเวลา ไม่สอดคล้องกับเงื่อนไขโครงการ \r\n";
                result = false;
            }
            break;
        default:
            break;
    }

    return result;
}


    var loanAmount = document.getElementById('c1').value;
    var yearPaid = document.getElementById('c2a').value;

    let obj = {
        BankShortName: currentBankCode,
        BankProductCode: currentProductCode,
        LoanAmount: loanAmount,
        YearPaid: yearPaid,
        PeriodType: "",
        CustomerType: ""
    };

    return obj;
}
function GenerateProductPackageObj() {

    let obj = [{
        ProductImage: "https://chatclinic.tcg.or.th/tcghealthcheck_dev/images/Cal/ProductPoster/Picture1.png",
        ProductCode: "GSB003_s",
        ProductDetail: "- เป็นบุคคลธรรมดาอายุ  20  ปีขึ้นไป  สัญชาติไทย  หรือนิติบุคคลจดทะเบียนตามกฎหมายไทย  <br /> - เป็นผู้ประกอบธุรกิจ และธุรกิจที่เกี่ยวข้องกับอุตสาหกรรมยานยนต์ไฟฟ้า ได้แก่ ผู้ผลิต/ ผู้ประกอบยานยนต์ไฟฟ้า(OEM)  ผู้ผลิตชิ้นส่วนและส่วนประกอบยานยนต์ไฟฟ้า และ Supply Chain ของธุรกิจดังกล่าว",
        ProductObjective: "- เพื่อเป็นเงินทุนหมุนเวียนในการดำเนินกิจการ <br /> - เพื่อลงทุนในทรัพย์สินถาวร <br /> - เพื่อไถ่ถอนจำนองจากสถาบันการเงินอื่น <br />- ยกเว้น การซื้อขายที่ดินที่มีลักษณะเก็งกำไร",
        ProductLoanAmount: "- สูงสุดไม่เกิน 50 ล้านบาท",
        ProductTimeLine: "- เงินกู้ระยะยาว สูงสุดไม่เกิน 10 ปี <br /> - เงินกู้ระยะสั้น ได้แก่ เงินเบิกเกินบัญชี ตั๋วสัญญาใช้เงิน",
        ProductInterest: "หลักทรัพย์ค้ำประกันเต็มวงเงินกู้ <br />1. เงินกู้ระยะสั้น <br /> ปีที่ 1-2 : ร้อยละ MOR – 3.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MOR – 1.00 ต่อปี <br /> 2.เงินกู้ระยะยาว <br /> ปีที่ 1-2 : ร้อยละ MLR – 3.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MLR – 1.00 ต่อปี <br /> <br /> หลักทรัพย์ค้ำประกันไม่น้อยกว่าร้อยละ 30 และใช้ บสย.ค้ำประกันเพิ่มเติมในส่วนที่ขาด <br /> 1.เงินกู้ระยะสั้น<br />ปีที่ 1 - 2 : ร้อยละ MOR – 2.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MOR ต่อปี <br /> 2.เงินกู้ระยะยาว <br />   ปีที่ 1 - 2 : ร้อยละ MLR – 2.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MLR ต่อปี"
    },
    {
        ProductImage: "https://chatclinic.tcg.or.th/tcghealthcheck_dev/images/Cal/ProductPoster/Picture1.png",
        ProductCode: "GSB003_l",
        ProductDetail: "- เป็นบุคคลธรรมดาอายุ  20  ปีขึ้นไป  สัญชาติไทย  หรือนิติบุคคลจดทะเบียนตามกฎหมายไทย  <br /> - เป็นผู้ประกอบธุรกิจ และธุรกิจที่เกี่ยวข้องกับอุตสาหกรรมยานยนต์ไฟฟ้า ได้แก่ ผู้ผลิต/ ผู้ประกอบยานยนต์ไฟฟ้า(OEM)  ผู้ผลิตชิ้นส่วนและส่วนประกอบยานยนต์ไฟฟ้า และ Supply Chain ของธุรกิจดังกล่าว",
        ProductObjective: "- เพื่อเป็นเงินทุนหมุนเวียนในการดำเนินกิจการ <br /> - เพื่อลงทุนในทรัพย์สินถาวร <br /> - เพื่อไถ่ถอนจำนองจากสถาบันการเงินอื่น <br />- ยกเว้น การซื้อขายที่ดินที่มีลักษณะเก็งกำไร",
        ProductLoanAmount: "- สูงสุดไม่เกิน 50 ล้านบาท",
        ProductTimeLine: "- เงินกู้ระยะยาว สูงสุดไม่เกิน 10 ปี <br /> - เงินกู้ระยะสั้น ได้แก่ เงินเบิกเกินบัญชี ตั๋วสัญญาใช้เงิน",
        ProductInterest: "หลักทรัพย์ค้ำประกันเต็มวงเงินกู้ <br />1. เงินกู้ระยะสั้น <br /> ปีที่ 1-2 : ร้อยละ MOR – 3.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MOR – 1.00 ต่อปี <br /> 2.เงินกู้ระยะยาว <br /> ปีที่ 1-2 : ร้อยละ MLR – 3.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MLR – 1.00 ต่อปี <br /> <br /> หลักทรัพย์ค้ำประกันไม่น้อยกว่าร้อยละ 30 และใช้ บสย.ค้ำประกันเพิ่มเติมในส่วนที่ขาด <br /> 1.เงินกู้ระยะสั้น<br />ปีที่ 1 - 2 : ร้อยละ MOR – 2.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MOR ต่อปี <br /> 2.เงินกู้ระยะยาว <br />   ปีที่ 1 - 2 : ร้อยละ MLR – 2.00 ต่อปี <br /> หลังจากนั้น : ร้อยละ MLR ต่อปี"
    },
    {
        ProductImage: "https://chatclinic.tcg.or.th/tcghealthcheck_dev/images/Cal/ProductPoster/Picture2.jpg",
        ProductCode: "GSB004",
        ProductDetail: "สินเชื่อธุรกิจรายย่อย เพื่อใช้ในการประกอบธุรกิจอุตสาหกรรม ธุรกิจพาณิชยกรรม ธุรกิจบริการ เกษตรเพื่อการค้าและอุตสาหกรรม",
        ProductObjective: "เป็นเงินทุนหมุนเวียนในการดำเนินกิจการ<br /> ลงทุนในทรัพย์สินถาวร <br /> ไถ่ถอนจำนองจากสถาบันการเงินอื่น",
        ProductLoanAmount: "เกินกว่ารายละ 200,000 บาทขึ้นไป แต่ไม่เกิน 1,000,000 บาท",
        ProductTimeLine: "เงินกู้ระยะสั้น ระยะเวลาชำระเงินกู้ไม่เกิน 1 ปี ทั้งนี้ ให้มีการทบทวนวงเงินทุกปี  <br /> เงินกู้ระยะยาว ระยะเวลาชำระเงินกู้ไม่เกิน 10 ปี",
        ProductInterest: "<table style='width: 100 %'>  <tr>    <th>หลักทรัพย์ค้ำประกัน</th>    <th>อัตราดอกเบี้ย</th></tr><tr><td>1.) บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม (บสย.)</td><td>MRR + 3</td></tr><tr><td>2.) หลักประกันทางธุรกิจ</td><td>MRR + 3</td></tr><tr><td>3.) ที่ดินพร้อมสิ่งปลูกสร้าง ห้องชุด ที่ดินว่างเปล่า และที่ดินที่เป็นที่สวน ที่ไร่ ที่นา</td><td>MRR + 1.50</td></tr><tr><td>4. กรณีใช้หลักประกันมากกว่า 1 ประเภท</td><td>เท่ากับอัตราดอกเบี้ยสูงสุดของอัตราดอกเบี้ยตามประเภทหลักประกัน</td></tr></table>"
    }
    ];

    return obj;
}
function BindingResult(obj) {

    var bufferBankProductCode = currentProductCode;
    var bufferYearPaid = document.getElementById('c2a').value;

    if (ddlProduct.value != null && ddlProduct.value != null) {
        pnlDesc.style.display = "block";
        pnlPackageEmpty.style.display = "none";


    document.getElementById('lblMonthBankName').innerHTML = obj.BankFullName;
    document.getElementById('lblMonthProductName').innerHTML = obj.BankProductName;
    document.getElementById('lblBankInterest').innerHTML = BindingInterest(bufferBankProductCode, bufferYearPaid);
    document.getElementById('lblMonthLoanAmount').innerHTML = AddComma(obj.LoanAmount);
    document.getElementById('lblMonthYearPaid').innerHTML = (obj.YearPaid * 12) + " เดือน " + "(" + obj.YearPaid + " ปี)";


    document.getElementById('lblMonthPayPerMonth').innerHTML = AddComma(monthPaid);
    document.getElementById('lblTCGPayPerYear').innerHTML = AddComma(tcgPayPerYear);
    document.getElementById('lblSummaryAmountPerYear').innerHTML = AddComma(summaryAmountPerYear);
    //document.getElementById('lblSummaryAmount').innerHTML = AddComma(Math.ceil(summaryAmount / 100) * 100);


}
function BindingInterest(productID, year) {

    var result = "";
    LocalLog(productID);
    LocalLog(year);

    switch (productID) {
        case "GSB001":
            if (year == 1) {
                result = "- ปีที่ 1-2 : ร้อยละ MOR ต่อปี  <br/> - ปีที่ 3 เป็นต้นไป: MOR + 2 % ต่อปี";
            } else {
                result = "- ปีที่ 1-2 : ร้อยละ MLR ต่อปี  <br/> - ปีที่ 3 เป็นต้นไป: MLR + 2 % ต่อปี";
            }
            break;
        case "GSB002":
            result = "- เดือนที่ 1-6 : MRR-2.255% ต่อปี <br/>- เดือนที่ 7 เป็นต้นไป MRR ต่อปี";
            break;
        case "GSB003_s":
            result = "- ปีที่ 1-2 : ร้อยละ MOR - 2.00 ต่อปี  <br/> - ปีที่ 3 เป็นต้นไป: MOR ต่อปี";
            break;
        case "GSB003_l":
            result = "- ปีที่ 1-2 : ร้อยละ MLR - 2.00 ต่อปี  <br/> - ปีที่ 3 เป็นต้นไป: MLR ต่อปี";
            break;
        case "GSB004":
            result = "- ร้อยละ 1.00 ต่อเดือน (Flat Rate)";
            break;
        default:
            break;
    }
    return result;

}


function Reset() {
    var pnlDesc = document.getElementById('pnlDesc');
    var pnlResult = document.getElementById('pnlResult');
    var pnlInfo = document.getElementById('pnlInfo');

    pnlResult.style.display = "none";
    pnlDesc.style.display = "block";
    pnlInfo.style.display = "block";



}

function Calculate() {
    var isValid = validate();
    if (isValid) {

        var pnlDesc = document.getElementById('pnlDesc');
        var pnlResult = document.getElementById('pnlResult');
        var pnlInfo = document.getElementById('pnlInfo');

    pnlResult.style.display = "none";
    pnlDesc.style.display = "none";

    //document.getElementById("ddlProduct").disabled = true;
    document.getElementById("ddlProduct").value = "";


}

function BindingProductInfo(productCode) {
    var buffer = GenerateProductPackageObj();
    var obj;
    for (i = 0; i < buffer.length; i++) {
        console.log(buffer[i].ProductCode);
        if (buffer[i].ProductCode == productCode) {
            obj = buffer[i];
        }
    }

    document.getElementById('imgProductDetail').src = obj.ProductImage;
    document.getElementById('lblProductDetail').innerHTML = obj.ProductDetail;
    document.getElementById('lblProductObjective').innerHTML = obj.ProductObjective;
    document.getElementById('lblProductLoanAmount').innerHTML = obj.ProductLoanAmount;
    document.getElementById('lblProductTimeLine').innerHTML = obj.ProductTimeLine;
    document.getElementById('lblProductInterest').innerHTML = obj.ProductInterest;






}

