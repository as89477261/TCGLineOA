<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="CustomerHealthCheck.Landing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <title>TCG OneStopService - Landing</title>
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/bootstrap.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/fonts/bootstrap-icons.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/style.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>" />

    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Source+Sans+Pro:wght@500;600;700&family=Roboto:wght@400;500;700&display=swap" rel="stylesheet" />
    <link rel="manifest" href="_manifest.json" />

    <link rel="apple-touch-icon" sizes="180x180" href="app/icons/icon-192x192.png" />

    <style>
        @keyframes spin3D {
            from {
                transform: rotateY(0deg)
            }

            to {
                transform: rotateY(360deg)
            }
        }

        .spinhov3D {
            animation-name: spin3D;
            animation-duration: 1s;
            animation-iteration-count: 1;
            /* linear | ease | ease-in | ease-out | ease-in-out */
            animation-timing-function: ease-in-out;
        }
    </style>

</head>
<body>
    <form runat="server">
        <asp:HiddenField runat="server" ID="hddIsDebug" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hddLiffKey" ClientIDMode="Static" />

 
        <asp:HiddenField runat="server" ID="hddShowProfile" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hddHomeUrl" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hddIsHttpManagerDubug" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hddAPIPartialCode" ClientIDMode="Static" />

        <asp:HiddenField runat="server" ID="hddPDPAConsentPoint" ClientIDMode="Static" />


        <div id="preloader">
            <div class="spinner-border color-highlight" role="status"></div>
        </div>

        <!-- Page Wrapper-->
        <div id="page">

            <!-- Page Content - Only Page Elements Here-->
            <div class="page-content footer-clear">
                <!-- Page Title-->

                <div class="card card-style" style="background-color: #fff0; top: 150px; box-shadow: none;">

                    <asp:Image ImageUrl="~/images/logos/Logo.png" CssClass="spinhov3D" runat="server" Style="background-color: #fff0 !important; width: 80%; margin: 0 auto; max-width: 200px;" />
                    <asp:Image ImageUrl="~/images/logos/FF.png" runat="server" Style="background-color: #fff0 !important; width: 80%; margin: 0 auto; max-width: 200px;" />
                    <div class="progress rounded-xxs bg-theme border border-blue-light mb-3" style="height: 20px; width: 80%; margin: 0 auto;">
                        <div class="progress-bar gradient-blue" role="progressbar"
                            id="progressBar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                        </div>
                    </div>
                    <div style="text-align: center;">
                        Version 4.10.04
                    </div>
                </div>


            </div>
        </div>


    </form>
    <!-- Modal Window-->

</body>
<script src="https://static.line-scdn.net/liff/edge/2.1/sdk.js"></script>
<script src="<%= ResolveClientUrl("~/scripts/BaseJS/GlobalParameter.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/BaseJS/SiteMap.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/BaseJS/ServiceInterface.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/BaseJS/LogInterface.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

<script src="<%= ResolveClientUrl("~/scripts/bootstrap.min.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/custom.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/Lib/CookieManager.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/Lib/HttpManager.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
<script src="<%= ResolveClientUrl("~/scripts/Lib/UtilityManager.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

<script src="<%= ResolveClientUrl("~/scripts/Lib/aes.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

<script src="<%= ResolveClientUrl("~/scripts/Page/Landing.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>

</html>
