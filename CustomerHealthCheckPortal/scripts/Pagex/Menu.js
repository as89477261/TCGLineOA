
const container = document.getElementById("notFoundModal");
const modal = new bootstrap.Modal(container);

document.addEventListener('DOMContentLoaded', () => {   
    var obj = GenerateUIDObject();
    InsertUID(obj);
});

function RedirectToPage(page) {
    let IshaveProfile = document.getElementById('hddIshaveProfile').value

    switch (page) {
        case "healthcheck":
            redirectToHealthCheck();
            break;
        case "debt":
            redirectToDebt();
            break;
        case "event":
            redirectToEvent();
            break;
        case "product":
            if (IshaveProfile === "true") {
                redirectToProduct();
            } else {
                modal.show();
            }
            break;
        default:
            break;
    }


}

//Next Phase
function ShowRegisterInfoDetail(id) {
    if (id !== null) {
        let bufferDetail = GetRegisterInfoByID(id);
    }
}
function GetRegisterInfoByID(id) {

    let myOffcanvas = document.getElementById('registerInfoDetailModal')
    let bsOffcanvas = new bootstrap.Offcanvas(myOffcanvas)
    bsOffcanvas.show();
}

function GenerateUIDObject() {
    let obj = {
        sub: getCookie("uid"),
        name: getCookie("uname"),
        picture: getCookie("pic"),
        email: getCookie("uemail")
    };

    return obj;
}


