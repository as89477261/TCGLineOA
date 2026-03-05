//IndexEvent

let btnRegister = document.getElementById("btnRegisterEventBanner")
let hddRegisterbutton = document.getElementById("hddRegisterbutton")
let registerEventBanner = document.getElementById("registerEventBanner")


if (hddRegisterbutton.value == "0") {
    registerEventBanner.style.display = "block";
    btnRegister.classList.add("gradient-gray");
    btnRegister.classList.add("disabledButton");
    btnRegister.setAttribute("value", "รอดิดตามการลงทะเบียน เร็วๆนี้");
}
if (hddRegisterbutton.value == "1") {
    btnRegister.classList.remove("gradient-gray");
    btnRegister.classList.remove("gradient-green");
    btnRegister.classList.add("disabledButton");
    btnRegister.removeAttribute("value");
};