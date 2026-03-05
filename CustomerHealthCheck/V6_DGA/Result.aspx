<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="CustomerHealthCheck.V6_DGA.Result" %>

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
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/result.css") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/modal.css") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />

    <link rel="shortcut icon" href="images/favicon/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="images/favicon/favicon.ico" type="image/x-icon" />

</head>
<body>
    <div class="wrapper">
        <div class="image-holder">
            <!--<img src="images/form-wizard.png" alt="">-->
            <%--<img src="images/tae.png" alt="">--%>
            <asp:Image ID="imageBG" runat="server" ImageUrl="~/images/score/group-1C.png" Style="padding: 10px;" />
        </div>
        <form action="Result.aspx" id="formResult" name="formResult" runat="server">
            <div id="wizard1">
                <!-- SECTION 3 -->
                <h4></h4>
                <section>
                    <!-- เพิ่มการแสดงผล Score หลังการคำนวณ -->
                    <div class="resulttext" style="text-align: right;">
                        <asp:Label ID="lblScore" runat="server" Text="" CssClass="resulttext">
                        </asp:Label>
                    </div>
                    <br />
                    <div class="product">
                        <div class="item">
                            <div class="left">
                                <a href="#" class="thumb">
                                    <%--<img src="images/score/score-1.png" alt="">--%>
                                    <asp:Image ID="imageScore" Visible="false" runat="server" ImageUrl="~/images/score/score-1.png" />
                                    <asp:Image ID="image1" runat="server" ImageUrl="~/images/score/score-1.png" />
                                </a>
                            </div>
                            <div class="d-flex">

                                <div class="ps-3 me-auto">
                                    <strong class="opacity-30 color-theme font-11">ผลการประเมิน</strong>
                                    <h3 class="mt-n2 pb-2">TCG Score</h3>
                                    <h3 style="color: green;">805 แข็งแรง</h3>
                                    <p>
                                        ผลการพิจารณาของท่านดีเยี่ยม สถานะทางการเงินของท่านพร้อมที่จะขอสินเชื่อกับธนาคาร
                                    </p>
                                </div>
                            </div>

                            <span class="price" style="display: none;">
                                <asp:Label ID="lblResultText" runat="server" Text="กิจการของคุณมีสุขภาพทางการเงินแข็งแรง มีโอกาสในการขอสินเชื่อเพื่อให้ธุรกิจเติบโตได้  เพื่อให้คุณมีสุขภาพทางการเงินที่ดียิ่งขึ้น สนใจรับคําแนะนําเพิ่มเติม" CssClass="resulttext">
                                    
                                </asp:Label>
                            </span>
                        </div>
                    </div>

                    <div class="form-row">
                        <style>
                            #customers {
                                font-family: Arial, Helvetica, sans-serif;
                                border-collapse: collapse;
                                width: 100%;
                            }

                                #customers td, #customers th {
                                    border: 1px solid #ddd;
                                    padding: 8px;
                                    text-align:center;
                                }

                                #customers tr:nth-child(even) {
                                    background-color: #f2f2f2;
                                }

                                #customers tr:hover {
                                    background-color: #ddd;
                                }

                                #customers th {
                                    padding-top: 12px;
                                    padding-bottom: 12px;
                                    text-align: left;
                                    background-color: darkgrey;
                                    color: white;
                                }
                        </style>

                        <div style="padding: 0px 15px;">
                            <h3>ตารางข้อมูลคะแนนวัดผลสุขภาพทางการเงิน</h3>

                            <table id="customers">
                                <tr>
                                    <th style="width: 20%">ระดับกลุ่ม</th>
                                    <th style="width: 35%">ช่วงคะแนน</th>
                                    <th style="width: 35%">ความหมาย</th>
                                </tr>
                                <tr style="color:g;">
                                    <td>กลุ่มที่ 1</td>
                                    <td>มากกว่า หรือเท่ากับ 805</td>
                                    <td>สุขภาพทางการเงินแข็งแรง</td>
                                </tr>
                                <tr>
                                    <td>กลุ่มที่ 2</td>
                                    <td>742 - 804</td>
                                    <td>สุขภาพทางการเงินปานกลาง</td>
                                </tr>
                                <tr>
                                    <td>กลุ่มที่ 3</td>
                                    <td>น้อยกว่า หรือเท่ากับ 741</td>
                                    <td>สุขภาพทางการเงินอ่อนแอ</td>
                                </tr>

                            </table>
                        </div>
                    </div>


                    <div class="form-row result" style="text-align: center;">
                        <a href="Default.aspx" type="button" name="name"
                            style="background: #88cfef; padding: 10px; border: 1px solid grey; margin-bottom: 20px;">กลับสู่หน้าหลัก
                        </a>
                        <%--<label class="resulttext">
                            กิจการของคุณมีสุขภาพทางการเงินแข็งแรง มีโอกาสในการขอสินเชื่อเพื่อให้ธุรกิจเติบโตได้  เพื่อให้คุณมีสุขภาพทางการเงินที่ดียิ่งขึ้น สนใจรับคําแนะนําเพิ่มเติม
                        </label>--%>
                    </div>


                    <div style="display: none;" id="pnlForm">
                        <!-- นิติบุคคล begin -->
                        <div id="divCorporate" runat="server" style="display: none">
                            <div class="form-row">
                                <div class="form-holder">
                                    <label for="ddTitleCorporate">
                                        คำนำหน้า
                                    </label>
                                    <div>
                                        <asp:DropDownList ID="ddTitleCorporate" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <i class="zmdi zmdi-caret-down"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-holder">
                                    <label for="txtBusinessNameCorporate">
                                        ชื่อกิจการ
                                    </label>
                                    <asp:TextBox ID="txtBusinessNameCorporate" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- นิติบุคคล end -->

                        <!-- บุคคลธรรมดา begin -->
                        <div id="divPerson" runat="server" style="display: block">
                            <div class="form-row form-group">
                                <div class="form-holder">
                                    <label for="ddTitlePerson">
                                        คำนำหน้าชื่อ
                                    </label>
                                    <div>
                                        <asp:DropDownList ID="ddTitlePerson" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <i class="zmdi zmdi-caret-down"></i>
                                    </div>
                                </div>
                                <div class="form-holder">
                                    <label for="txtName">
                                        ชื่อ
                                    </label>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row form-group">
                                <div class="form-holder">
                                    <label for="txtSurname">
                                        นามสกุล
                                    </label>
                                    <asp:TextBox ID="txtSurname" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-holder">
                                    <label for="txtBusinessNamePerson">
                                        ชื่อกิจการ
                                    </label>
                                    <asp:TextBox ID="txtBusinessNamePerson" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- บุคคลธรรมดา end -->
                        <div class="form-row form-group">
                            <div class="form-holder">
                                <label id="lblPhone" for="txtPhone">
                                    เบอร์โทรศัพท์เคลื่อนที่
                                </label>
                                <asp:TextBox ID="txtPhone" MaxLength="10" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-holder">
                                <asp:Label ID="lblIDCard" runat="server" Text="เลขประจำตัวประชาชน" for="txtIDCard">
                                </asp:Label>
                                <asp:TextBox ID="txtIDCard" MaxLength="13" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hdIDCard" runat="server" Value="0" />
                            </div>
                        </div>
                        <div class="form-row">
                            <label id="lblChannel" for="ddChannel">
                                <%-- ที่มาของการติดต่อ--%>
                            ช่องทางการติดต่อ
                            </label>
                            <div class="form-holder">
                                <asp:DropDownList ID="ddChannel" runat="server" class="form-control"></asp:DropDownList>
                                <i class="zmdi zmdi-caret-down"></i>
                            </div>
                        </div>
                        <div class="form-row">
                            <label for="txtEmail">
                                อีเมล์
                            </label>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-row">
                            <label for="txtRemark">
                                ข้อความเพื่อติดต่อกลับ
                            </label>
                            <asp:TextBox ID="txtRemark" runat="server" class="form-control" Rows="3" TextMode="MultiLine" Style="height: 90px"></asp:TextBox>
                        </div>

                    </div>
                </section>
            </div>


            <!-- Modal -->
            <div id="modalResult" class="modal" runat="server">
                <div class="modal-window">
                    <%--<span class="close" data-dismiss="modal">&times;</span>--%>
                    <h3>
                        <asp:Label ID="lblSaveSuccess" runat="server" Text="ระบบกำลังบันทึกข้อมูล <br/>เจ้าหน้าที่จะติดต่อท่านภายใน 2 วันทำการ และสามารถตรวจสอบสถานะได้ผ่าน Line OA ของ บสย.ครับ" Visible="False"></asp:Label>
                        <asp:Label ID="lblSaveFail" runat="server" Text="เกิดข้อผิดพลาด ไม่สามารถบันทึกข้อมูลได้ <br/>กรุณาติดต่อเจ้าหน้าที่ 02-8909779 ครับ" Visible="False"></asp:Label>
                    </h3>
                </div>
            </div>



            <div id="modalConsent" class="modal" runat="server" noclose="noclose">
                <div class="modal-window">

                    <h3>หนังสือให้ความยินยอมในการเก็บรวบรวม / ใช้ / เปิดเผย ข้อมูลส่วนบุคคล เพื่อการวิจัยและพัฒนาผลิตภัณฑ์ของ บสย.</h3>
                    <br />
                    บรรษัทประกันสินเชื่ออุตสาหกรรมขนาดย่อม (บสย.) จัดทำหนังสือขอความยินยอมจากท่านในการเก็บรวบรวม ใช้ เปิดเผยข้อมูลส่วนบุคคล หรือข้อมูลทางการเงินอื่นๆ ของท่าน ที่ท่านได้ให้ไว้แก่ บสย. หรือที่ บสย. อาจเข้าถึงได้จากแหล่งอื่น เพื่อวัตถุประสงค์ดังต่อไปนี้<br />
                    <br />
                    1. เพื่อใช้สำหรับการวิเคราะห์ วิจัยและ/หรือพัฒนาผลิตภัณฑ์ของ บสย. ให้เหมาะสมกับความต้องการของท่าน<br />
                    2. เพื่อการสำรวจความพึงพอใจด้านผลิตภัณฑ์และบริการของ บสย.<br />
                    3. เพื่อขยายสิทธิประโยชน์ให้ท่านมากขึ้นผ่านการนำเสนอผลิตภัณฑ์ บริการ การแจ้งข่าวสารต่างๆ เชิญชวนเข้าร่วมกิจกรรม ข้อมูลการตลาดที่ตรงตามความความต้องการของท่าน<br />
                    <br />
                    โดยติดต่อผ่านช่องทางเบอร์โทรศัพท์และ/หรืออีเมล์<br />
                    <br />
                    ท่านสามารถดูรายละเอียดเพิ่มเติมได้ที่ https://www.tcg.or.th/privacy_policy.php และคำยินยอมนี้จะมีผล 10 ปี<br />
                    หลังจากท่านได้ยกเลิกการใช้ผลิตภัณฑ์หรือบริการจาก บสย. หากท่านประสงค์จะเพิกถอนความยินยอมนี้ หรือทำการยื่นข้อร้องเรียนใดๆ เกี่ยวกับการละเมิดสิทธิของท่าน สามารถดำเนินการผ่านช่องทางตามที่ระบุไว้<br />
                    https://www.tcg.or.th/privacy_policy.php
                    <br />
                    <br />
                    ท่านมีสิทธิเลือกให้ความยินยอมหรือไม่ก็ได้ โดยไม่ส่งผลต่อการพิจารณาการใช้ผลิตภัณฑ์หรือบริการของ บสย.
                    <div class="pad-tb">
                        <label class="pad-r">
                            <asp:RadioButton ID="radioAccept" runat="server" GroupName="radioConsent" Checked="True" />ยินยอม
                        </label>
                        <label>
                            <asp:RadioButton ID="radioReject" runat="server" GroupName="radioConsent" />ไม่ยินยอม
                        </label>
                    </div>
                    <div class="pad-tb">
                        <asp:Button ID="btnSubmit" runat="server" Text="ตกลง" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </div>




        </form>
    </div>

    <script src="<%= ResolveClientUrl("~/js/jquery-3.3.1.min.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>

    <!-- JQUERY STEP -->
    <script src="<%= ResolveClientUrl("~/js/jquery.steps.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/js/jquery.result.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/js/modal.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/js/validatecontrol.js") + "?v="+DateTime.Now.ToString("ddMMyyyyHHmmss") %>" type="text/javascript"></script>
</body>
</html>
