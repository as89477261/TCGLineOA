public class TCG_HealthCheckTemplateManager
{
    public class HealthCheckHistory
    {
        public static string GenerateDividerLine()
        {
            return
                " <div class='divider my-2 opacity-50' style='background-color: rgba(0, 0, 0, 0.07) !important;'></div>";
        }

        public static string GenerateHealthCheckHistory(string level, string type, string date, string status)
        {
            status = status.ToReplaceWithEmpty("สุขภาพทางการเงิน", "");
            var template = "<a class='d-flex py-1 p-1' href='#'>" +
                           "<div class='align-self-center'>" +
                           GenerateHealthCheckHistoryImage(level) +
                           //"<span class='icon rounded-s me-2 " + GenerateHealthCheckHistoryColor(level) + " shadow-bg shadow-bg-s'>" +
                           //"<i style='font-size:20px;' class='bi " + GenerateHealthCheckHistoryIcon(level) + " color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1'>" + GenerateHealthCheckHistoryType(type) + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + date + "</p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " +
                           GenerateHealthCheckHistoryFontColor(level, type) + " '>" + status + "</h5>" +
                           "</div>" +
                           "</a>";

            return template;
        }

        public static string GenerateHealthCheckHistoryWithReduce(string level, string type, string date, string status,
            int reduceLevel = 0, string remark1 = "")
        {
            status = status.ToReplaceWithEmpty("สุขภาพทางการเงิน", "");
            var template = "<a class='d-flex py-1 p-1' href='#'>" +
                           "<div class='align-self-center'>" +
                           GenerateHealthCheckHistoryImage(level, reduceLevel, type) +
                           //"<span class='icon rounded-s me-2 " + GenerateHealthCheckHistoryColor(level) + " shadow-bg shadow-bg-s'>" +
                           //"<i style='font-size:20px;' class='bi " + GenerateHealthCheckHistoryIcon(level) + " color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1' style='font-size:14px;'>" +
                           GenerateHealthCheckHistoryType(type, remark1) + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + date + "</p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " +
                           GenerateHealthCheckHistoryFontColor(level, type) + " '>" + status + "</h5>" +
                           "</div>" +
                           "</a>";

            return template;
        }

        public static string GenerateHealthCheckHistoryWithJSFunction(string level, string type, string date,
            string status, string id)
        {
            status = status.ToReplaceWithEmpty("สุขภาพทางการเงิน", "");
            var template = "<a class='d-flex py-1' href='#' onclick='ShowRegisterInfoDetail(" + id + ")'>" +
                           "<div class='align-self-center'>" +
                           GenerateHealthCheckHistoryImage(level) +
                           //"<span class='icon rounded-s me-2 " + GenerateHealthCheckHistoryColor(level) + " shadow-bg shadow-bg-s'>" +
                           //"<i style='font-size:25px;' class='bi " + GenerateHealthCheckHistoryIcon(level) + " color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1'>" + GenerateHealthCheckHistoryType(type) + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + date + "</p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " +
                           GenerateHealthCheckHistoryFontColor(level, type) + " '>" + status + "</h5>" +
                           "</div>" +
                           "</a>";

            return template;
        }

        public static string GenerateHealthCheckHistoryWithJSFunctionKeepHCID(string level, string type, string date,
            string status, string id)
        {
            status = status.ToReplaceWithEmpty("สุขภาพทางการเงิน", "");
            var template = "<a class='d-flex py-1' href='#'  onclick='KeepHealthCheckCookie(\"" + id + "\")' >" +
                           "<div class='align-self-center'>" +
                           GenerateHealthCheckHistoryImage(level) +
                           //"<span class='icon rounded-s me-2 " + GenerateHealthCheckHistoryColor(level) + " shadow-bg shadow-bg-s'>" +
                           //"<i style='font-size:25px;' class='bi " + GenerateHealthCheckHistoryIcon(level) + " color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1'>" + GenerateHealthCheckHistoryType(type) + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + date + "</p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " +
                           GenerateHealthCheckHistoryFontColor(level, type) + " '>" + status + "</h5>" +
                           "</div>" +
                           "</a>";

            return template;
        }


        private static string GenerateHealthCheckHistoryIcon(string level)
        {
            switch (level)
            {
                case "3":
                    return "bi-caret-down-square";
                case "2":
                    return "bi-chevron-bar-contract";
                case "1":
                    return "bi-caret-up-square";
                default:
                    return "";
            }
        }

        private static string GenerateHealthCheckHistoryColor(string level)
        {
            switch (level)
            {
                case "3":
                    return "gradient-red";
                case "2":
                    return "gradient-yellow";
                case "1":
                    return "gradient-green";
                default:
                    return "";
            }
        }

        private static string GenerateHealthCheckHistoryImage(string level)
        {
            switch (level)
            {
                case "3":
                    return "<img src='../../images/statusHC/score-3.png' width='40' />";
                case "2":
                    return "<img src='../../images/statusHC/score-2.png' width='40' />";
                case "1":
                    return "<img src='../../images/statusHC/score-1.png' width='40' />";
                default:
                    return "";
            }
        }

        private static string GenerateHealthCheckHistoryImage(string level, int reduceLevel, string type)
        {
            var path = string.Empty;
            if (type == "1" || type == "2")
                switch (level)
                {
                    case "4":
                        path =
                            "<span class='icon rounded-s me-2 gradient-green shadow-bg shadow-bg-s' style='font-size:25px;'><i class='bi bi-patch-check color-white'></i></span>";
                        break;
                    case "3":
                        path = "<img src='../../images/statusHC/score-3.png' width='40' />";
                        break;
                    case "2":
                        path = "<img src='../../images/statusHC/score-2.png' width='40' />";
                        break;
                    case "1":
                        path = "<img src='../../images/statusHC/score-1.png' width='40' />";
                        break;
                    default:
                        path = "";
                        break;
                }
            else if (type == "3")
                switch (level)
                {
                    case "1":
                        return
                            "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                    case "2":
                        return
                            "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                    case "3":
                        return
                            "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";

                    //case "1":
                    //    return "<i class='bi bi-1-square-fill color-violet-dark pe-3 font-40' style='color: white;'></i><span class='font-600 font-18 color-violet-dark'></span>";
                    //case "2":
                    //    return "<i class='bi bi-2-square-fill color-yellow-dark pe-3 font-40' style='color: white;'></i><span class='font-600 font-18 color-violet-dark'></span>";
                    //case "3":
                    //    return "<i class='bi bi-3-square-fill color-green-dark pe-3 font-40' style='color: white;'></i><span class='font-600 font-18 color-violet-dark'></span>";
                    default:
                        return "";
                }
            else if (type == "4")
                return
                    "<i class='icon has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar-event p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
            else if (type == "5")
                return
                    "<i class='icon has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-clipboard-plus p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";

            for (var i = 0; i < reduceLevel; i++) path = path.Replace("../", "");

            return path;
        }

        private static string GenerateHealthCheckHistoryFontColor(string level, string type)
        {
            if (type == "1" || type == "2")
                switch (level)
                {
                    case "3":
                        return "color-red-dark";
                    case "2":
                        return "color-yellow-dark";
                    case "1":
                        return "color-green-dark";
                    default:
                        return "";
                }

            if (type == "3")
                switch (level)
                {
                    case "1":
                        return "color-violet-dark";
                    case "2":
                        return "color-yellow-dark";
                    case "3":
                        return "color-green-dark";
                    default:
                        return "";
                }

            if (type == "4")
                switch (level)
                {
                    case "1":
                        return "color-yellow-dark";
                    case "2":
                        return "color-green-dark";
                    case "3":
                        return "color-violet-dark";
                    default:
                        return "";
                }

            return "";
        }

        private static string GenerateHealthCheckHistoryStatus(string level)
        {
            switch (level)
            {
                case "3":
                    return "อ่อนแอ";
                case "2":
                    return "ปกติ";
                case "1":
                    return "มั่นคง";
                default:
                    return "";
            }
        }

        private static string GenerateHealthCheckHistoryType(string type, string remark1 = "")
        {
            switch (type)
            {
                case "5":
                    return remark1;
                case "4":
                    return remark1;
                case "3":
                    return remark1;
                case "2":
                    return remark1;
                case "1":
                    return "ตรวจสุขภาพหนี้";

                default:
                    return "";
            }
        }
    }

    public class HealthCheckMeasurementStatus
    {
        public static string GenerateHealthCheckHistory(int bandLevel, bool isPassProductCriteria)
        {
            var template = "<a class='d-flex py-1 p-1' href='#'>" +
                           "<div class='align-self-center'>" +
                           GenerateHealthCheckProdcutCriteriaStatusImage(isPassProductCriteria) +
                           //"<span class='icon rounded-s me-2 " + GenerateHealthCheckHistoryColor(level) + " shadow-bg shadow-bg-s'>" +
                           //"<i style='font-size:20px;' class='bi " + GenerateHealthCheckHistoryIcon(level) + " color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-2'>" +
                           "<h5 class='pt-1 mb-n1'>" +
                           GenerateHealthCheckProductCriteriaStatusWord(isPassProductCriteria) + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + "" + "</p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " +
                           GenerateHealthCheckProductCriteriaFontColor(isPassProductCriteria) + " '>" + "" + "</h5>" +
                           "</div>" +
                           "</a>";

            return template;
        }

        private static string GenerateHealthCheckProdcutCriteriaStatusImage(bool status)
        {
            var path = "";
            if (status)
                path = "<img src='../../images/statusTrueFalse/pass.png' width='40' />";
            else
                path = "<img src='../../images/statusTrueFalse/fail.png' width='40' />";
            return path;
        }

        private static string GenerateHealthCheckProductCriteriaStatusWord(bool status)
        {
            var word = "";
            if (status)
                word = "คุณผ่านคุณสมบัติเบื้องต้น สามารถเข้าร่วมโครงการ";
            else
                word =
                    "คุณไม่ผ่านคุณสมบัติเบื้องต้น ในการเข้าร่วมโครงการ ติดต่อสอบถามข้อมูลเพิ่มเติม ที่ Call Center 02-890-9999";
            return word;
        }

        private static string GenerateHealthCheckProductCriteriaFontColor(bool status)
        {
            var color = "";
            if (status)
                color = "color-green-dark";
            else
                color = "color-red-dark";
            return color;
        }
    }

    public class HealthCheckProductRegister
    {
        public static string GenerateHealthCheckApprochHistory(string productName, string createdDate, string id)
        {
            var template = "<div class='collapse show m-1'  data-bs-parent='#tab-group-2'>" +
                           "<a href = '#' class='d-flex py-1'>" +
                           "<div class='align-self-center'>" +
                           "<span class='icon rounded-s me-2 gradient-green shadow-bg shadow-bg-s' style='font-size:25px;'>" +
                           "<i class='bi bi-patch-check color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1'>" + productName + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + createdDate +
                           "<span class='copyright-year'></span></p>" +
                           "</div>" +
                           "</a>" +
                           "</div>";

            return template;
        }
    }

    public class HealthCheckApproch
    {
        public static string GenerateHealthCheckApprochHistory(string productName, string createdDate, string id)
        {
            var template = "<div class='collapse show m-1'  data-bs-parent='#tab-group-2'>" +
                           "<a href = '#' class='d-flex py-1'>" +
                           "<div class='align-self-center'>" +
                           "<span class='icon rounded-s me-2 gradient-green shadow-bg shadow-bg-s' style='font-size:25px;'>" +
                           "<i class='bi bi-patch-check color-white'></i></span>" +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1' style='font-size:14px;'>" + productName + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + createdDate + "<span class=''></span></p>" +
                           "</div>" +
                           "</a>" +
                           "</div>";

            return template;
        }
    }

    public class FACenterDebt
    {
        public static string GenerateFACenterDebtHistory(string productName, string createdDate,
            string DebtPackageID = "")
        {
            var template = "<div class='collapse show m-1'  data-bs-parent='#tab-group-2'>" +
                           "<a href = '#' class='d-flex py-1'>" +
                           "<div class='align-self-center'>" +
                           GenerateFAIcon(DebtPackageID) +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1' style='font-size:14px;'>" + productName + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + createdDate + "<span class=''></span></p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " +
                           GenerateFAHistoryFontColor(DebtPackageID, "3") + " '> มาตรการที่ " + DebtPackageID +
                           "</h5>" +
                           "</div>" +
                           "</a>" +
                           "</div>";

            return template;
        }

        private static string GenerateFAIcon(string level)
        {
            switch (level)
            {
                //case "1":
                //    return "<i class='bi bi-1-square-fill color-violet-dark pe-3 font-40' style='color: white;'></i><span class='font-600 font-18 color-violet-dark'></span>";
                //case "2":
                //    return "<i class='bi bi-2-square-fill color-yellow-dark pe-3 font-40' style='color: white;'></i><span class='font-600 font-18 color-violet-dark'></span>";
                //case "3":
                //    return "<i class='bi bi-3-square-fill color-green-dark pe-3 font-40' style='color: white;'></i><span class='font-600 font-18 color-violet-dark'></span>";


                case "1":
                    return
                        "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                case "2":
                    return
                        "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                case "3":
                    return
                        "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                default:
                    return "";
            }
        }

        private static string GenerateFAHistoryFontColor(string level, string type)
        {
            if (type == "1" || type == "2")
                switch (level)
                {
                    case "3":
                        return "color-red-dark";
                    case "2":
                        return "color-yellow-dark";
                    case "1":
                        return "color-green-dark";
                    default:
                        return "";
                }

            if (type == "3")
                switch (level)
                {
                    case "1":
                        return "color-violet-dark";
                    case "2":
                        return "color-yellow-dark";
                    case "3":
                        return "color-green-dark";
                    default:
                        return "";
                }

            return "";
        }
    }

    public class RegisterEvent
    {
        public static string GenerateRegisterEventHistory(string eventName, string createdDate, string type,
            string status)
        {
            var template = "<div class='collapse show m-1'  data-bs-parent='#tab-group-2'>" +
                           "<a href = '#' class='d-flex py-1'>" +
                           "<div class='align-self-center'>" +
                           GenerateFAIcon(type) +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1' style='font-size:14px;'>" + eventName + "</h5>" +
                           "<p class='mb-0 font-11 opacity-50'>" + createdDate + "<span class=''></span></p>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto text-end'>" +
                           "<h5 style='font-size: 14px;' class='pt-1 mb-n1 " + GenerateFAHistoryFontColor(status) +
                           " '>" + GenerateHealthCheckHistoryStatus(status) + "</h5>" +
                           "</div>" +
                           "</a>" +
                           "</div>";

            return template;
        }

        private static string GenerateFAIcon(string level)
        {
            switch (level)
            {
                case "1":
                    return
                        "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                case "2":
                    return
                        "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                case "3":
                    return
                        "<i class='icon has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                case "4":
                    return
                        "<i class='icon has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar-event p-0 ' style='margin-right: 10px; font-size: 25px;'></i>";
                default:
                    return "";
            }
        }

        private static string GenerateFAHistoryFontColor(string level)
        {
            switch (level)
            {
                case "0":
                    return "color-red-dark";
                case "2":
                    return "color-green-dark";
                case "1":
                    return "color-yellow-dark";
                default:
                    return "";
            }
        }

        private static string GenerateHealthCheckHistoryStatus(string level)
        {
            switch (level)
            {
                case "1":
                    return "รอติดตาม";
                case "2":
                    return "ติดตามแล้ว";

                default:
                    return "";
            }
        }
    }

    public class HealthCheckProduct
    {
        public static string GenerateProductList(string prodName, string prodDetail, string param, string productCode)
        {
            var template =
                "<div class='accordion-item  border-fade-highlight border-bottom-0 rounded-top rounded-m' style='margin-bottom:10px !important;' >" +
                "<button class='accordion-button collapsed' type='button' data-bs-toggle='collapse' data-bs-target='#accordion" +
                productCode + "'>" +
                "<i class='bi bi-handbag-fill color-green-dark pe-3 font-26'></i>" +
                "<span class='font-600 font-14'>" + prodName + "</span>" +
                "<i class='bi bi-plus font-20'></i>" +
                "</button>" +
                "<div id='accordion" + productCode +
                "' class='accordion-collapse collapse p-2' data-bs-parent='#accordion-group-7'>" +
                "<p class='px-3 mb-0 pb-3 pt-1'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                prodDetail +
                "</p>" +
                "<a href='#' onclick='KeepProductCookie(\"" + param +
                "\")' class='btn btn-full mx-3 gradient-blue shadow-bg shadow-bg-s'>ลงทะเบียนโครงการ</a>" +
                "</div>" +
                "</div>";

            return template;
        }
    }

    public class HealthCheckBank
    {
        public static string GenerateBankList(string bankName, string bankLogo, string bankCode, string bankEmail)
        {
            var template = "<a href='#' class='d-flex py-1'>" +
                           "<div class='align-self-center'>" +
                           bankLogo +
                           "</div>" +
                           "<div class='align-self-center ps-1'>" +
                           "<h5 class='pt-1 mb-n1' style='font-size:14px;'>" + bankName + "</h5>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto'>" +
                           "<div class='form-switch ios-switch switch-green switch-l'>" +
                           "<input type='checkbox' value='" + bankEmail + "' class='ios-input' id='switch-" + bankCode +
                           "'>" +
                           "<label class='custom-control-label' for='switch-" + bankCode + "'></label>" +
                           "</div>" +
                           "</div>" +
                           "</a>";

            return template;
        }
    }

    public class NDIDIDPPanel
    {
        public static string GenerateIDPList(string idpCode, string idpName, string nodeID)
        {
            var template = " <a href='#' data-trigger-switch='switch-" + idpCode + "' class='d-flex pb-2 mb-1'>" +
                           "<img src='../../images/logos/" + idpCode +
                           ".png' class='me-3 rounded-xs' alt='img' style='width: 30px; height: 30px;'>" +
                           "<div class='align-self-center'>" +
                           "<h5 class='mb-0 font-17'>" + idpName + "</h5>" +
                           "<span>Ndid Node</span>" +
                           "</div>" +
                           "<div class='align-self-center ms-auto'>" +
                           "<div class='form-switch ios-switch switch-blue switch-m'>" +
                           "<input type='checkbox' value='" + idpCode + "_" + nodeID +
                           "' class='ios-input' id='switch-" + idpCode + "'>" +
                           "<label class='custom-control-label' for='switch-" + idpCode + "'></label>" +
                           "</div>" +
                           "</div>" +
                           "</a>";

            return template;
        }
    }
}