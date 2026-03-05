<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultInfo.aspx.cs" Inherits="CustomerHealthCheck.ResultInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>บสย. - คํานวณสุขภาพทางการเงิน</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="author" content="colorlib.com"/>

    <!-- MATERIAL DESIGN ICONIC FONT -->
    <link rel="stylesheet" href="fonts/material-design-iconic-font/css/material-design-iconic-font.css"/>

    <!-- STYLE CSS -->
    <link rel="stylesheet" href="css/result.css"/>
    <link rel="stylesheet" href="css/modal.css"/>

    <link rel="shortcut icon" href="images/favicon/favicon.ico" type="image/x-icon"/>
    <link rel="icon" href="images/favicon/favicon.ico" type="image/x-icon"/>
    <style>
        #wizard .actions a {
            display: none;
        }

        .btn {
            font-family: "Prompt", sans-serif;
            text-transform: uppercase;
            font-weight: 700;
            border-radius: 12px;
            font-size: 13px;
            padding: 14px 20px;
            box-shadow: 0 5px 14px 0 rgb(0 0 0 / 10%);
            border: none;
            background-image: linear-gradient(to bottom, #A0D468, #8CC152);
        }
    </style>
</head>
<body>
<div class="wrapper">
    <div class="image-holder">
        <!--<img src="images/form-wizard.png" alt="">-->
        <%--<img src="images/tae.png" alt="">--%>
        <asp:Image ID="imageBG" runat="server" ImageUrl="~/images/score/group-1C.png"/>
    </div>
    <form id="formResult" name="formResult" runat="server">
        <div id="wizard">
            <!-- SECTION 3 -->
            <h4></h4>
            <section>
                <div class="product">
                    <div class="item">
                        <div class="left">
                            <a href="#" class="thumb">
                                <%--<img src="images/score/score-1.png" alt="">--%>
                                <asp:Image ID="imageScore" runat="server" ImageUrl="~/images/score/score-1.png"/>
                            </a>
                        </div>
                        <span class="price">
                            <asp:Label ID="lblResultText" runat="server" Text="กิจการของคุณมีสุขภาพทางการเงินแข็งแรง มีโอกาสในการขอสินเชื่อเพื่อให้ธุรกิจเติบโตได้  เพื่อให้คุณมีสุขภาพทางการเงินที่ดียิ่งขึ้น สนใจรับคําแนะนําเพิ่มเติม" CssClass="resulttext">
                            </asp:Label>
                            <br/>
                            <br/>
                            <asp:Button class="btn" Text="กลับสู้หน้าหลัก" runat="server" ID="btnRedirectMain" OnClick="btnRedirectMain_Click"/>

                        </span>
                    </div>
                </div>
                <div class="form-row result">
                </div>

            </section>
        </div>


        <div class="row">
            <div class="col-12" style="text-align: center;">
            </div>
        </div>


    </form>
</div>

<script src="js/jquery-3.3.1.min.js" type="text/javascript"></script>

<!-- JQUERY STEP -->
<script src="js/jquery.steps.js"></script>
<script src="js/jquery.result.js"></script>
<script src="js/modal.js"></script>
<script src="js/validatecontrol.js" type="text/javascript"></script>
</body>
</html>