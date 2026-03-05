<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MyBill.ascx.cs" Inherits="CustomerHealthCheck.UserControl.MyBill.UC_MyBill" %>
<div class="card card-style">
    <div class="content">
        <div class="accordion-item">
            <button class="accordion-button px-0 ps-1 collapsed" type="button" style="box-shadow: none;"
                data-bs-toggle="collapse" aria-expanded="<%= Index == 0 ? "true" : "false" %>"
                data-bs-target="#BillLGList<%= IndexPlus %>">
                <i class="bi bi-file-earmark-text color-blue-dark pe-3 font-16"></i>
                <% // LgNo %>
                <span class="font-600 font-16">
                    <strong>
                        LG No
                        <asp:Literal ID="L_LgNo" runat="server" />
                    </strong>
                </span>
                <i class="bi bi-arrow-down-short font-20"></i>
            </button>
            <div id="BillLGList<%= IndexPlus %>" class="accordion-collapse collapse <%= Index == 0 ? "show" : "" %>">
                <div class="collapse show" id="Bill-1-Tab-History" data-bs-parent="#LGBillgroup-<%= IndexPlus %>">
                    <hr style="margin: 5px;">
                    <div class="list-group list-custom list-group-m list-group-flush rounded-xs">

                        <asp:Repeater ID="RepeaterMyBillGroup" runat="server" OnItemDataBound="RepeaterMyBillGroup_ItemDataBound">
                            <ItemTemplate>
                                <div class="list-group-item"
                                    href="#Bill-<%# Eval("ReceiptNumberPay") %>-Tab-History-List"
                                    data-bs-toggle="offcanvas"
                                    data-bs-target="#Bill-<%# Eval("ReceiptNumberPay") %>-Tab-History-List">
                                    <a class="has-bg ms-2 me-2 bi bi-view-list font-16"></a>
                                    <div class="ms-2">
                                        <strong>ชำระเลขที่ :
                                            <asp:Literal ID="L_ReceiptNumberPay" runat="server" />
                                        </strong>
                                        <span>
                                            <asp:Literal ID="L_PayFor" runat="server" />
                                        </span>
                                    </div>
                                    <div class="flex-fill text-end">
                                        <strong>
                                            <asp:Literal ID="L_DatePay" runat="server" />
                                        </strong><span>วันที่ตรวจรับ</span>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Panel runat="server" Visible="<%# RepeaterMyBillGroup.Items.Count == 0 %>">
                                    <div class="text-center">
                                        ไม่พบประวัติ
                                    </div>
                                </asp:Panel>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<asp:Repeater ID="RepeaterMyBillHistory" runat="server" OnItemDataBound="RepeaterMyBillHistory_ItemDataBound">
    <ItemTemplate>
        <div id="Bill-<%# Eval("ReceiptNumberPay") %>-Tab-History-List"
            class="offcanvas offcanvas-bottom offcanvas-detached rounded-m" style="height: max-content">
            <div class="menu-size" style="height: max-content">
                <div class="d-flex mx-3 mt-3 py-1">
                    <div class="align-self-center">
                        <h1 class="mb-0">ใบเสร็จรับเงิน</h1>
                        <a>ค่าธรรมเนียมดำเนินการค้ำประกัน LG :
                            <asp:Literal ID="L_ReceiptNumberPay1" runat="server" />
                        </a>
                    </div>
                    <div class="align-self-center ms-auto">
                        <a href="#" class="ps-4 shadow-0 me-n2" data-bs-dismiss="offcanvas">
                            <i class="bi bi-x color-red-dark font-26 line-height-xl"></i>
                        </a>
                    </div>
                </div>
                <div class="divider divider-margins mt-3 mb-2"></div>
                <div class="content mt-0">
                    <div class="row mb-3 mt-4">
                        <h5 class="col-5 text-start font-15">วันที่ชำระ</h5>
                        <h5 class="col-7 text-end font-14 font-400">
                            <span class="bg-green-dark px-2 rounded-s">
                                <asp:Literal ID="L_ReceiptPayDate" runat="server" />
                            </span>
                        </h5>
                        <h5 class="col-5 text-start font-15">ชำระโดย</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">
                            <asp:Literal ID="L_ReceivePayFor" runat="server" />
                        </h5>
                        <h5 class="col-5 text-start font-15">ได้รับเงินจาก</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">
                            <asp:Literal ID="L_RecieveFromChannal" runat="server" />
                        </h5>
                        <h5 class="col-5 text-start font-15">เลขที่ทำรายการ</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">
                            <asp:Literal ID="L_ReceiptNumberPay2" runat="server" />
                        </h5>

                        <h5 class="col-5 text-start font-15">ประเภทใบเสร็จ</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">
                            <asp:Literal ID="L_ReceiptType" runat="server" />
                        </h5>

                        <h5 class="col-5 text-start font-15">จำนวนเงิน</h5>
                        <h5 class="col-7 text-end font-14 opacity-60 font-400">
                            <asp:Literal ID="L_FeeAmountSME" runat="server" />
                        </h5>

                       

                    </div>
                    <%--                    <div class="divider my-2"></div>--%>
                </div>
                <%--                <div class="content">
                    <asp:HyperLink ID="B_Download" runat="server" class="btn btn-full gradient-blue shadow-bg shadow-bg-s" Target="_blank">Download</asp:HyperLink>
                </div>--%>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
