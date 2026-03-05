using System.Collections.Generic;

namespace OIC_UTILITY.Template
{
    public class Oreo_TemplateManager
    {
        public static string GenSpanStatus(string status, string wording)
        {
            var result = "";
            switch (status)
            {
                case "default":
                    result = "<span class='badge badge-default'>" + wording + "</span>";
                    break;
                case "primary":
                    result = "<span class='badge badge-primary'>" + wording + "</span>";
                    break;
                case "success":
                    result = "<span class='badge badge-success'>" + wording + "</span>";
                    break;
                case "info":
                    result = "<span class='badge badge-info'>" + wording + "</span>";
                    break;
                case "warning":
                    result = "<span class='badge badge-warning'>" + wording + "</span>";
                    break;
                case "danger":
                    result = "<span class='badge badge-danger'>" + wording + "</span>";
                    break;
            }

            return result;
        }

        public static string GenTable<T>(string[] header, string[] propName, List<T> obj, string[] headerClass = null)
        {
            var tableHeaderBeginTag =
                "<table class='table table-hover table-bordered' style='table-layout: fixed; width: 100 %;'><thead><tr>";
            var tableHeaderContent = "";
            var tableHeaderEndTab = "</tr></thead>";
            var tableBodyBegin = "<tbody>";
            var tableBodyContent = "";
            var tableBodyEnding = " </tbody> </table> ";

            for (var i = 0; i < header.Length; i++)
                if (headerClass != null)
                    tableHeaderContent += "<td " + headerClass[i] + ">" + header[i] + "</td>";
            for (var i = 0; i < obj.Count; i++)
            {
                tableBodyContent += "<tr>";
                var prop = typeof(T).GetProperties();
                for (var j = 0; j < prop.Length; j++)
                for (var k = 0; k < propName.Length; k++)
                    if (prop[j].Name == propName[k])
                        tableBodyContent += "<td>" + obj[i].GetPropValueToString(prop[j].Name) + "</td>";
                tableBodyContent += "</tr>";
            }

            var result = tableHeaderBeginTag + tableHeaderContent + tableHeaderEndTab + tableBodyBegin +
                         tableBodyContent + tableBodyEnding;
            return result;
        }

        public static string GenTableWithDropDown<T>(string[] header, string[] propName, List<T> obj,
            string[] headerClass = null)
        {
            var tableHeaderBeginTag =
                "<table class='table table-hover table-bordered' style='table-layout: fixed; width: 100 %;'><thead><tr>";
            var tableHeaderContent = "";
            var tableHeaderEndTab = "</tr></thead>";
            var tableBodyBegin = "<tbody>";
            var tableBodyContent = "";
            var tableBodyEnding = " </tbody> </table> ";

            for (var i = 0; i < header.Length; i++)
                if (headerClass != null)
                    tableHeaderContent += "<td " + headerClass[i] + ">" + header[i] + "</td>";
            for (var i = 0; i < obj.Count; i++)
            {
                tableBodyContent += "<tr>";
                var prop = typeof(T).GetProperties();
                for (var j = 0; j < prop.Length; j++)
                for (var k = 0; k < propName.Length; k++)
                    if (prop[j].Name == propName[k])
                    {
                        if (prop[j].Name == "P_POINT")
                        {
                            if (prop[j].Name == "IS_OPEN")
                            {
                                var isOpen = obj[i].GetPropValueToString(prop[j].Name);
                                if (isOpen == "1")
                                    tableBodyContent +=
                                        @"<td><select id='ddlMMPoint' class='form-control show-tick ms select2' data-placeholder='Select'>
                                                                    <option> -- เลือกระดับตัวชี้วัด -- </option>
                                                                    <option> ระดับ 1 </option>
                                                                    <option> ระดับ 2 </option>
                                                                    <option> ระดับ 3 </option>
                                                                    <option> ระดับ 4 </option>
                                                                    <option> ระดับ 5 </option>
                                                                </select>
                                                         </td><td><label id='lblPoint'></label></td><td><label id='lblWeight'></label></td> ";
                                else
                                    tableBodyContent += "<td>" + obj[i].GetPropValueToString(prop[j].Name) + "</td>";
                            }
                            else
                            {
                                tableBodyContent += "<td>" + obj[i].GetPropValueToString(prop[j].Name) + "</td>";
                            }
                        }
                        else
                        {
                            tableBodyContent += "<td>" + obj[i].GetPropValueToString(prop[j].Name) + "</td>";
                        }
                    }

                tableBodyContent += "</tr>";
            }

            var result = tableHeaderBeginTag + tableHeaderContent + tableHeaderEndTab + tableBodyBegin +
                         tableBodyContent + tableBodyEnding;
            return result;
        }

        public static string GenTotalLineChart01(string header = "", string zone = "col-lg-3 col-md-6",
            string totalData = "47,055", string midWord = "23% Average", string lineData = "1,2,3,1,4,3,6,4,4,1")
        {
            var env01 = "<div class='" + zone +
                        "'>  <div class='card'>  <div class='header'>  <h2><strong>Total</strong> " + header +
                        "</h2> </div><div class='body'>";
            var total = @" <h3 class='m-b-0'>" + totalData + "</h3>";
            // var middle = @" <small class='displayblock'>" + midWord + " <i class='zmdi zmdi-trending-up'></i></small>";
            var middle = @" <small class='displayblock'>" + midWord + " </small>";
            var line =
                @"<div class='sparkline' data-type='line' data-spot-radius='1' data-highlight-spot-color='rgb(63, 81, 181)' data-highlight-line-color='#222'
                                data-min-spot-color='rgb(233, 30, 99)' data-max-spot-color='rgb(63, 81, 181)' data-spot-color='rgb(63, 81, 181, 0.7)'
                                data-offset='90' data-width='100%' data-height='60px' data-line-width='1' data-line-color='rgb(63, 81, 181, 0.7)'
                                data-fill-color='rgba(221,94,137, 0.2)'>
                                " + lineData + " </div>";
            var env02 = @"</div> </div> </div>";

            return env01 + total + middle + line + env02;
        }
    }
}