<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerHealthCheck.V1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>บสย. - คํานวณสุขภาพทางการเงิน</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="author" content="colorlib.com" />

    <!-- MATERIAL DESIGN ICONIC FONT -->
    <link rel="stylesheet" href="fonts/material-design-iconic-font/css/material-design-iconic-font.css" />

    <!-- STYLE CSS -->
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/style.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/modal.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />

    <link rel="shortcut icon" href="images/favicon/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="images/favicon/favicon.ico" type="image/x-icon" />
</head>
<body>
    <div class="wrapper">
        <div class="image-holder">
            <!--<img src="images/form-wizard.png" alt="">-->
            <img src="images/bg.jpg" alt="" class="noPrint">
        </div>
        <form action="Default.aspx" id="formRegister" name="formRegister" runat="server">
            <div id="wizard">
                <!-- SECTION 1 -->
                <h4></h4>
                <section>
                    <div class="form-row form-group">
                        <div class="form-holder" id="radioPersonType">
                            <label id="lblPersonType" for="">
                                กิจการคุณจดทะเบียนรูปแบบใด
                            </label>
                            <label>
                                <asp:RadioButton ID="radioPerson" runat="server" GroupName="personType" />บุคคลธรรมดา
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
                                <asp:RadioButton ID="radioOfficeOwner" runat="server" GroupName="officeType" />เป็นเจ้าของ
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
                        <asp:TextBox ID="txtYearIncorporate" runat="server" class="form-control" placeholder="ระบุจำนวนปีตั้งแต่ก่อตั้งกิจการมาไม่เกิน (150 ปี)"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblIndustry" for="">
                            ประเภทกิจการ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddIndustry" runat="server" class="form-control"></asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblProvince" for="">
                            จังหวัดที่จดทะเบียนกิจการ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddProvince" runat="server" class="form-control"></asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                </section>

                <!-- SECTION 2 -->
                <h4></h4>
                <section>
                    <div class="form-row">
                        <label id="lblOwnerAge" for="">
                            อายุผู้มีอำนาจลงนาม (ปี)
                        </label>
                        <asp:TextBox ID="txtOwnerAge" runat="server" class="form-control" placeholder="ระบุจำนวนปีไม่เกิน (80 ปี)"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblMaritalStatus" for="">
                            สถานะภาพของผู้มีอำนาจลงนาม
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddMaritalStatus" runat="server" class="form-control">
                                <asp:ListItem Value="0" Text="กรุณาเลือกสถานะ"></asp:ListItem>
                                <asp:ListItem Value="1" Text="โสด"></asp:ListItem>
                                <asp:ListItem Value="2" Text="สมรส"></asp:ListItem>
                                <asp:ListItem Value="3" Text="หย่าร้าง"></asp:ListItem>
                                <asp:ListItem Value="4" Text="หม้าย"></asp:ListItem>
                            </asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblYearExperience" for="">
                            ประสบการณ์ในการทําธุรกิจนี้ (ปี)
                        </label>
                        <asp:TextBox ID="txtYearExperience" runat="server" class="form-control" placeholder="ระบุจำนวนปีไม่เกิน (150 ปี)"></asp:TextBox>
                    </div>
                </section>

                <!-- SECTION 3 -->
                <h4></h4>
                <section>
                    <div class="form-row">
                        <label id="lblDebtStatus" for="">
                            <%--สถานะหนี้ของกิจการ--%>
                            สถานะหนี้ปัจจุบันของกิจการ

                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddDebtStatus" runat="server" class="form-control">
                                <asp:ListItem Value="0" Text="ไม่มีหนี้"></asp:ListItem>
                                <asp:ListItem Value="5" Text="ผ่อนปกติ"></asp:ListItem>
                                <asp:ListItem Value="1" Text="ค้างชําระไม่เกิน 90 วัน"></asp:ListItem>
                                <asp:ListItem Value="2" Text="ค้างชําระเกิน 90 วัน"></asp:ListItem>
                                <asp:ListItem Value="3" Text="ปรับโครงสร้างหนี้ล่าสุด"></asp:ListItem>
                                <asp:ListItem Value="4" Text="อยู่ในกระบวนการทางกฏหมาย"></asp:ListItem>
                            </asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>
                    <div id="divTDR" class="form-row form-group" style="display: none;">
                        <div class="form-holder">
                            <label id="lblTdrAmount" for="">
                                <%--จำนวน (ครั้ง)--%>
                                ปัจจุบัน กิจการปรับโครงสร้างหนี้มาแล้ว (ครั้ง)
                            </label>
                            <asp:TextBox ID="txtTdrAmount" runat="server" class="form-control" placeholder="ระบุตัวเลขไม่เกิน (10 ครั้ง)"></asp:TextBox>
                        </div>
                        <div class="form-holder">
                            <label id="lblTdrYear" for="">
                                <%--ล่าสุดปี (พ.ศ.)--%>
                                ปัจจุบัน กิจการปรับโครงสร้างหนี้ล่าสุดปี (พ.ศ.)
                            </label>
                            <asp:TextBox ID="txtTdrYear" runat="server" class="form-control" placeholder="ระบุตัวเลขปี พ.ศ. ไม่เกินปีปัจจุบัน"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblAssetValue" for="">
                            มูลค่าสินทรัพย์รวมของกิจการ (บาท)
                        </label>

                        <asp:TextBox ID="txtAssetValue" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                     <div class="form-row">
                        <label id="lblLandAssetValue" for="">
                            ที่ดินมูลค่า (บาท) (ถ้ามี)
                        </label>

                        <asp:TextBox ID="txtLandAsset" min="0" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblDebtValue" for="">
                            หนี้สินรวมของกิจการ (บาท)
                        </label>
                        <asp:TextBox ID="txtDebtValue" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                </section>

                <!-- SECTION 4 -->
                <h4></h4>
                <section>
                    <div class="form-row">
                        <label id="lblIncome" for="">
                            รายได้รวมของกิจการ (บาทต่อเดือน)
                        </label>
                        <asp:TextBox ID="txtIncome" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblExpense" for="">
                            <%-- กิจการคุณมีค่าใช้จ่าย (บาทต่อเดือน)--%>
                            ค่าใช้จ่ายกิจการ (บาทต่อเดือน) (ไม่รวมต้นทุนขาย)
                        </label>
                        <asp:TextBox ID="txtExpense" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblCostSale" for="">
                            <%-- กิจการคุณมีค่าใช้จ่าย (บาทต่อเดือน)--%>
                            ต้นทุนขาย (บาทต่อเดือน)
                        </label>
                        <asp:TextBox ID="txtCostSale" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <label id="lblInstallmentAmount" for="">
                            ภาระหนี้ทั้งหมดที่ต้องผ่อนชําระ (ต่อเดือน)
                        </label>
                        <asp:TextBox ID="txtInstallmentAmount" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>
                </section>

                <!-- SECTION 5 -->
                <h4></h4>
                <section>
                    <div class="form-row form-group">
                        <div class="form-holder">
                            <label id="lblGetProfitYes" for="">
                                3 ปีที่ผ่านมา กิจการมีรายได้เพิ่มขึ้น
                            </label>
                            <label>
                                <asp:RadioButton ID="radioGetProfitYes" runat="server" GroupName="radioIsGetProfit" />ใช่
                            </label>
                            <label>
                                <asp:RadioButton ID="radioGetProfitNo" runat="server" GroupName="radioIsGetProfit" />ไม่ใช่
                            </label>
                        </div>
                    </div>
                    <div class="form-row">
                        <label id="lblObjTerm" for="ddObjTerm">
                            <%--วัตถุประสงค์ในการขอสินเชื่อ--%>
                            วัตถุประสงค์ของการติดต่อ
                        </label>
                        <div class="form-holder">
                            <asp:DropDownList ID="ddObjTerm" runat="server" class="form-control"></asp:DropDownList>
                            <i class="zmdi zmdi-caret-down"></i>
                        </div>
                    </div>


                    <div class="form-row">
                        <label id="lblLoanAmount" for="">
                            <%--วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท)--%>
                            วงเงินสินเชื่อที่ต้องการ (บาท)
                        </label>
                        <asp:TextBox ID="txtLoanAmount" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลข"></asp:TextBox>
                    </div>



                    <div class="form-row">
                        <label id="lblInstallmentYear" for="">
                            ระยะเวลาในการผ่อนชําระที่ต้องการ (ปี)
                        </label>
                        <asp:TextBox ID="txtInstallmentYear" runat="server" class="form-control" placeholder="ระบุจำนวนเงินเป็นตัวเลขไม่เกิน (30 ปี)"></asp:TextBox>
                    </div>


                    <div class="form-row">
                        <div class="form-holder">
                        </div>
                    </div>

                    <label id="lblLoanTaget" for="">
                        ประเภทของวงเงินสินเชื่อที่ต้องการ (เลือกมากกว่า 1 ข้อ)
                    </label>
                    <br />

                    <label>- สินเชื่อหมุนเวียน โปรดระบุตัวเลขรวมให้เท่ากับวงเงินสินเชื่อ </label>
                    <div style="padding-left: 20px;">
                        <asp:CheckBox ID="chkLCTR" name="chkLoan" CssClass="cssLoan" Text="L/C,T/R" runat="server" onchange="valStep5Checked('LCTR')" ClientIDMode="Static"/>
                        <asp:TextBox min="0" ID="txtLCTR" runat="server" class="form-control disableElement" placeholder="โปรดระบุตัวเลข" 
                            style="margin-bottom:10px;" ClientIDMode="Static"></asp:TextBox>
                        
                        <asp:CheckBox ID="chkLG" name="chkLoan" CssClass="cssLoan" Text="หนังสือค้ำประกัน (L/G)" runat="server" onchange="valStep5Checked('LG')" ClientIDMode="Static" />
                        <asp:TextBox min="0" ID="txtLG" runat="server" class="form-control disableElement" placeholder="โปรดระบุตัวเลข" 
                            style="margin-bottom:10px;" ClientIDMode="Static"></asp:TextBox>
                        
                        <asp:CheckBox ID="chkPN" name="chkLoan" CssClass="cssLoan" Text="ตั๋วสัญญาใช้เงิน (PN)" runat="server" onchange="valStep5Checked('PN')" ClientIDMode="Static" />
                        <asp:TextBox min="0" ID="txtPN" runat="server" class="form-control disableElement" placeholder="โปรดระบุตัวเลข" 
                            style="margin-bottom:10px;" ClientIDMode="Static"></asp:TextBox>
                        
                        <asp:CheckBox ID="chkOD" name="chkLoan" CssClass="cssLoan" Text="วงเงินเบิกเกินบัญชี (O/D)" runat="server" onchange="valStep5Checked('OD')" ClientIDMode="Static" />
                        <asp:TextBox min="0" ID="txtOD" runat="server" class="form-control disableElement" placeholder="โปรดระบุตัวเลข" 
                            style="margin-bottom:10px;" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <label>- สินเชื่อระยะยาว โปรดระบุตัวเลขรวมให้เท่ากับวงเงินสินเชื่อ </label>
                    <div style="padding-left: 20px;">
                        <asp:CheckBox ID="chkLoan" name="chkLoan" CssClass="cssLoan" Text="เงินกู้ (Loan)" runat="server" onchange="valStep5Checked('Loan')" ClientIDMode="Static" />
                        <asp:TextBox min="0" ID="txtLoan" runat="server" class="form-control disableElement" placeholder="โปรดระบุตัวเลข" 
                            style="margin-bottom:10px;" ClientIDMode="Static"></asp:TextBox>
                        
                        <asp:CheckBox ID="chkOther" name="chkLoan" CssClass="cssLoan" Text="อื่นๆ" runat="server" onchange="valStep5Checked('Other')" ClientIDMode="Static" />
                        <asp:TextBox min="0" ID="txtOther" runat="server" class="form-control disableElement" placeholder="โปรดระบุตัวเลข" 
                            style="margin-bottom:10px;" ClientIDMode="Static"></asp:TextBox>
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
                        <asp:Label ID="lblSaveSuccess" runat="server" Text="บันทึกข้อมูลสำเร็จ <br/>เจ้าหน้าที่จะติดต่อท่านภายใน 2 วันทำการครับผม" Visible="False"></asp:Label>
                        <asp:Label ID="lblSaveFail" runat="server" Text="เกิดข้อผิดพลาด ไม่สามารถบันทึกข้อมูลได้ <br/>กรุณาติดต่อเจ้าหน้าที่ 02-8909779 ครับ" Visible="False"></asp:Label>
                    </h3>
                </div>
            </div>

        </form>
    </div>


    <script src="<%= ResolveClientUrl("~/js/jquery-3.3.1.min.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>

    <!-- JQUERY STEP -->
    <script src="<%= ResolveClientUrl("~/js/jquery.steps.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

    <script src="<%= ResolveClientUrl("~/js/main.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <!-- Template created and distributed by Colorlib -->

    <script src="<%= ResolveClientUrl("~/js/accounting.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/js/validatecontrol.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/js/modal.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

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
