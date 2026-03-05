<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerHealthCheck.V6_DGA.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>บสย. - คํานวณสุขภาพทางการเงิน</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="author" content="colorlib.com" />

    <!-- MATERIAL DESIGN ICONIC FONT -->
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/fonts/material-design-iconic-font/css/material-design-iconic-font.css") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />

    <!-- STYLE CSS -->
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/style.css") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/modal.css") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />

    <link rel="shortcut icon" href="images/favicon/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="images/favicon/favicon.ico" type="image/x-icon" />
</head>
<body>
    <div class="wrapper">
        <div class="image-holder">
            <!--<img src="images/form-wizard.png" alt="">-->
            <asp:Image ImageUrl="~/images/bg.jpg" runat="server" alt="" class="noPrint" Style="padding: 5px;" />

        </div>
        <form action="Default.aspx" id="formRegister" name="formRegister" runat="server">
            <div id="wizard2">
                <!-- SECTION 1 -->
                <h4></h4>

                <section id="divStep1" style="display: block; padding: 20px;">
                    <div class="form-row form-group">
                        <div class="form-holder" id="radioPersonType">
                            <label id="lblPersonType" for="">
                                กิจการคุณจดทะเบียนรูปแบบใด
                            </label>
                            <label>
                                <asp:RadioButton ID="radioPerson" runat="server" GroupName="personType" Checked/>บุคคลธรรมดา
                            </label>
                            <label>
                                <asp:RadioButton ID="radioBusiness" runat="server" GroupName="personType" />นิติบุคคล
                            </label>
                        </div>
                    </div>
                    <div class="form-row form-group">
                        <div class="form-holder">
                            <label id="lblOfficeType" for="">
                                กรรมสิทธิ์ของสถานที่ประกอบกิจการ
                            </label>
                            <label>
                                <asp:RadioButton ID="radioOfficeOwner" runat="server" GroupName="officeType" Checked/>เป็นเจ้าของ
                            </label>
                            <label>
                                <asp:RadioButton ID="radioOfficeRental" runat="server" GroupName="officeType" />เป็นผู้เช่า
                            </label>
                            <label>
                                <asp:RadioButton ID="radioOfficeOther" runat="server" GroupName="officeType" />อื่นๆ
                            </label>
                        </div>
                    </div>
                    <div class="form-row">
                        <label for="" id="lblYearIncorporate">
                            อายุกิจการ (ปี)
                        </label>
                        <asp:TextBox ID="txtYearIncorporate" Text="15" runat="server" class="form-control" placeholder="ระบุจำนวนปีตั้งแต่ก่อตั้งกิจการมา"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblIndustry" for="">
                            ประเภทกิจการ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddIndustry" runat="server"  class="form-control"></asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblProvince" for="">
                            จังหวัดที่ตั้งกิจการ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddProvince" runat="server" class="form-control"></asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>

                    <div class="form-row">
                        <input type="button" id="btnStep1Next" onclick="Step1Submit();"
                            style="background: #88cfef; padding: 10px; float: right; border: 1px solid grey; margin-bottom: 20px;" value="ถัดไป" />
                    </div>
                </section>





                <!-- SECTION 2 -->
                <h4></h4>
                <section id="divStep2" style="display: none;">
                    <div class="form-row">
                        <label id="lblOwnerAge" for="">
                            อายุผู้บริหารหลัก (ปี)
                        </label>
                        <asp:TextBox ID="txtOwnerAge" Text="35" runat="server" class="form-control" placeholder="ระบุจำนวนปี"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblMaritalStatus" for="">
                            สถานะภาพการสมรสของผู้บริหารหลัก
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddMaritalStatus" runat="server" class="form-control">
                                <asp:ListItem Value="0" Text="กรุณาเลือกสถานะ"></asp:ListItem>
                                <asp:ListItem Selected Value="1" Text="โสด"></asp:ListItem>
                                <asp:ListItem Value="2" Text="สมรส"></asp:ListItem>
                                <asp:ListItem Value="3" Text="หย่าร้าง"></asp:ListItem>
                                <asp:ListItem Value="4" Text="หม้าย"></asp:ListItem>
                            </asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblYearExperience" for="">
                            ประสบการณ์โดยตรงในการทําธุรกิจนี้ (ปี)
                        </label>
                        <asp:TextBox ID="txtYearExperience" Text="10" runat="server" class="form-control" placeholder="ระบุจำนวนปี"></asp:TextBox>
                    </div>

                    <div class="form-row">
                        <input type="button" id="btnStep2Previous" onclick="Step2Back();"
                            style="background: whitesmoke; padding: 10px; float: left; border: 1px solid grey; margin-bottom: 20px; margin-right: 20px;" value="ย้อนกลับ" />
                        <input type="button" id="btnStep2Next" onclick="Step2Submit();"
                            style="background: #88cfef; padding: 10px; float: right; border: 1px solid grey; margin-bottom: 20px;" value="ถัดไป" />
                    </div>
                </section>

                <!-- SECTION 3 -->
                <h4></h4>
                <section id="divStep3" style="display: none;">
                    <div class="form-row">
                        <label id="lblDebtStatus" for="">
                            สถานะหนี้ของกิจการ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddDebtStatus" runat="server" class="form-control">
                                <asp:ListItem Selected Value="0" Text="ไม่มีหนี้"></asp:ListItem>
                                <asp:ListItem Value="5" Text="ผ่อนปกติ"></asp:ListItem>
                                <asp:ListItem Value="1" Text="ค้างชําระไม่เกิน 90 วัน"></asp:ListItem>
                                <asp:ListItem Value="2" Text="ค้างชําระเกิน 90 วัน"></asp:ListItem>
                                <asp:ListItem Value="3" Text="ปรับโครงสร้างหนี้"></asp:ListItem>
                                <asp:ListItem Value="4" Text="อยู่ในกระบวนการทางกฏหมาย"></asp:ListItem>
                            </asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div id="divTDR" class="form-row form-group" style="display: none;">
                        <div class="form-holder">
                            <label id="lblTdrAmount" for="">
                                จำนวน (ครั้ง)
                            </label>
                            <asp:TextBox ID="txtTdrAmount" Text="1" runat="server" class="form-control" placeholder="ระบุตัวเลข"></asp:TextBox>
                        </div>
                        <div class="form-holder">
                            <label id="lblTdrYear" for="">
                                ล่าสุดปี (พ.ศ.)
                            </label>
                            <asp:TextBox ID="txtTdrYear" runat="server" class="form-control" placeholder="ระบุตัวเลข"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblAssetValue" for="">
                            มูลค่าสินทรัพย์รวมของกิจการ
                        </label>
                        <asp:TextBox ID="txtAssetValue" Text="1,000,000" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblDebtValue" for="">
                            หนี้สินรวมของกิจการ
                        </label>
                        <asp:TextBox ID="txtDebtValue" Text="10,000" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <input type="button" id="btnStep3Previous" onclick="Step3Back();"
                            style="background: whitesmoke; padding: 10px; float: left; border: 1px solid grey; margin-bottom: 20px; margin-right: 20px;" value="ย้อนกลับ" />
                        <input type="button" id="btnStep3Next" onclick="Step3Submit();"
                            style="background: #88cfef; padding: 10px; float: right; border: 1px solid grey; margin-bottom: 20px;" value="ถัดไป" />
                    </div>
                </section>

                <!-- SECTION 4 -->
                <h4></h4>
                <section id="divStep4" style="display: none;">
                    <div class="form-row">
                        <label id="lblIncome" for="">
                            รายได้รวมของกิจการ (ต่อเดือน)
                        </label>
                        <asp:TextBox ID="txtIncome" Text="50,000" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblExpense" for="">
                            กิจการคุณมีค่าใช้จ่าย (ต่อเดือน)
                        </label>
                        <asp:TextBox ID="txtExpense" Text="10,000" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblInstallmentAmount" for="">
                            ภาระหนี้ที่ต้องผ่อนชําระ (ต่อเดือน)
                        </label>
                        <asp:TextBox ID="txtInstallmentAmount" Text="1,000" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <input type="button" id="btnStep4Previous" onclick="Step4Back();"
                            style="background: whitesmoke; padding: 10px; float: left; border: 1px solid grey; margin-bottom: 20px; margin-right: 20px;" value="ย้อนกลับ" />
                        <input type="button" id="btnStep4Next" onclick="Step4Submit();"
                            style="background: #88cfef; padding: 10px; float: right; border: 1px solid grey; margin-bottom: 20px;" value="ถัดไป" />
                    </div>
                </section>

                <!-- SECTION 5 -->
                <h4></h4>
                <section id="divStep5" style="display: none;">
                    <div class="form-row form-group">
                        <div class="form-holder">
                            <label id="lblGetProfitYes" for="">
                                3 ปีที่ผ่านมา กิจการคุณมีรายได้เพิ่มขึ้น
                            </label>
                            <label>
                                <asp:RadioButton ID="radioGetProfitYes" Checked runat="server" GroupName="radioIsGetProfit" />ใช่
                            </label>
                            <label>
                                <asp:RadioButton ID="radioGetProfitNo" runat="server" GroupName="radioIsGetProfit" />ไม่ใช่
                            </label>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblObjTerm" for="ddObjTerm">
                            วัตถุประสงค์ในการขอสินเชื่อ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddObjTerm"  runat="server" class="form-control"></asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblLoanAmount" for="">
                            วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท)
                        </label>
                        <asp:TextBox ID="txtLoanAmount" Text="1,000,000" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblInstallmentYear" for="">
                            ระยะเวลาในการผ่อนชําระที่คุณต้องการ (ปี)
                        </label>
                        <asp:TextBox ID="txtInstallmentYear" Text="15" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">

                        <asp:Button Text="คำนวณสุขภาพ" runat="server"
                            Style=" background: #88cfef; padding: 10px; float: right;"
                            ClientIDMode="Static"
                            ID="btnSubmitForm"
                            OnClientClick="return valStep5();"
                            CssClass="btn btn-primary"
                            OnClick="btnSubmitForm_Click" />
                    </div>
                </section>
                <!--<div class="actions clearfix">
                    <ul role="menu" aria-label="Pagination" class="step-last">
                        <li aria-hidden="false" style="">
                            <a href="#" role="menuitem">test</a>
                        </li>
                    </ul>
                </div>-->
            </div>


            <!-- Modal -->
            <div id="modalResult" class="modal" runat="server">
                <div class="modal-window">
                    <span class="close" data-dismiss="modal">&times;</span>
                    <h3>
                        <%--<asp:Label ID="lblSaveSuccess" runat="server" Text="บันทึกข้อมูลสำเร็จ <br/>เจ้าหน้าที่จะติดต่อท่านภายใน 2 วันทำการครับผม" Visible="False"></asp:Label>--%>
                        <asp:Label ID="lblSaveSuccess" runat="server" Visible="False">
                          	บันทึกข้อมูลสำเร็จ <br/>เจ้าหน้าที่จะติดต่อท่านภายใน 2 วันทำการครับ
                            <%--<br/> หากมีข้อเสนอแนะเพิ่มเติม คลิก <a href="https://www.tcg.or.th/contactus_form.php?Channel=HealthCheckPGS10">"Click"</a>--%>
                        </asp:Label>
                        <asp:Label ID="lblSaveFail" runat="server" Text="เกิดข้อผิดพลาด ไม่สามารถบันทึกข้อมูลได้ <br/>กรุณาติดต่อเจ้าหน้าที่ 02-8909779 ครับ" Visible="False"></asp:Label>
                    </h3>
                </div>
            </div>

        </form>
    </div>

    <script src="<%= ResolveClientUrl("~/js/jquery-3.3.1.min.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>

    <!-- JQUERY STEP -->
    <script src="<%= ResolveClientUrl("~/js/jquery.steps.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

    <script src="<%= ResolveClientUrl("~/js/main.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <!-- Template created and distributed by Colorlib -->

    <script src="<%= ResolveClientUrl("~/js/accounting.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/js/validatecontrol.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/js/modal.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

    <script>
        $(document).ready(function () {
            $('#ddDebtStatus').on('change', function () {
                if (this.value == '3') {
                    $("#divTDR").show();
                    //alert('show');
                }
                else {
                    $("#divTDR").hide();
                    //alert('hide');
                }
            });
        });
    </script>
</body>
</html>
