document.addEventListener('DOMContentLoaded', () => {
    CheckIsRegisterProduct();
});

function CheckIsRegisterProduct() {
    var cid = "653817"; //document.getElementById("hddCustomerID");
    var result = GetIsRegister(cid);
    if (result != "" && parseInt(result) > 0) {
        var btnRegisProduct = document.getElementById("btnShowProduct");
        btnRegisProduct.style.display = "block";
    } else {
        btnRegisProduct.style.display = "none";
    }
}
function ShowProductRegisterPage() {
    var cid = "653817";
    var externalURL = "https://chatclinic.tcg.or.th/tcghealthcheck_dev/views/extend/productregister?cid=" + cid;
    window.open(externalURL);
}

