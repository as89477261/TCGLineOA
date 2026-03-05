<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_EventBanner.ascx.cs" Inherits="CustomerHealthCheck.UserControl.UC_EventBanner" %>

<link rel="stylesheet" type="text/css" href="<%= ResolveClientUrl("~/styles/AttentionWizard.css") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>">


<asp:Literal Text="" ID="Header" runat="server"/>

<asp:Literal Text="" ID="SubHeader" runat="server"/>

<div class="row">
    <%--<h3>สถานะลงทะเบียน</h3>--%>
    <div class="column-md-1 verticalWizard" style="z-index: 0;">
        <div class="verticalWizard">
            <%--<ul style="margin: 0px;">--%>
            <asp:Literal Text="" ID="ltlStepEvent" runat="server"/>

            <%-- <li class="complete" data-target="#step5">
                                        <a href="#tab5" data-toggle="tab" class="active" aria-expanded="true">
                                            <span class="round-tab"></span>
                                            <span class="title">Step 1</span>
                                        </a>
                                    </li>
                                    <li class="active" data-target="#step6">
                                        <a href="#tab6" data-toggle="tab" aria-expanded="false">
                                            <span class="round-tab"></span>
                                            <span class="title">Step 2</span>
                                        </a>
                                    </li>
                                    <li class="reject" data-target="#step7">
                                        <a href="#tab7" data-toggle="tab" aria-expanded="false">
                                            <span class="round-tab"></span>
                                            <span class="title">Step 3</span>
                                        </a>
                                    </li>
                                    <li data-target="#step8">
                                        <a href="#tab8" data-toggle="tab" aria-expanded="false">
                                            <span class="round-tab"></span>
                                            <span class="title">Step 4</span>
                                        </a>
                                    </li>--%>
            <%--</ul>--%>
            <div class="clearfix"></div>
        </div>
    </div>
</div>