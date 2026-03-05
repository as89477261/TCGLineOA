<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ProductRegister.aspx.cs"
Inherits="CustomerHealthCheck.viewx.Extend.ProductRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="padding: 15px;">
        <div class="col-12">
            <asp:Literal ID="ltlFullName" Text="" runat="server"/>
        </div>
    </div>

    <div class="row" style="padding: 15px;">
        <div class="col-7 ">
            <asp:GridView runat="server" ID="grdRegistedProduct" runat="server" CssClass="table "
                          AutoGenerateColumns="False" DataKeyNames="ApprochID" OnSelectedIndexChanged="OnSelectedIndexChanged">
                <Columns>
                    <asp:ButtonField Text="เลือก" CommandName="Select"/>
                    <asp:BoundField DataField="ProductName" HeaderText="ผลิตภัณฑ์ที่ลงทะเบียน" SortExpression="ProductName"/>
                    <asp:BoundField DataField="BankName" HeaderText="แบงค์ที่ลงทะเบียน" HtmlEncode="False" SortExpression="BankName"/>

                    <asp:TemplateField HeaderText="Country" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("ApprochBody") %>' Style="display: none;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วันที่ลงทะเบียน">
                        <ItemTemplate>
                            <asp:Label ID="lblCreatedTime" runat="server" Text='<%# Eval("CreatedTime") %>' Style="display: block;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="col-5">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="false" Style="border: none;">
                <Fields>
                    <asp:BoundField DataField="Description" HeaderText="" HeaderStyle-Font-Bold="true" HtmlEncode="false"/>
                </Fields>
            </asp:DetailsView>
        </div>
    </div>

    <asp:Literal ID="lblCustomerID" Text="" runat="server"/>
    <a href="#" class="btn btn-sm btn-success" id="btnShowProduct" onclick="ShowProductRegisterPage()">Click</a>

    <style>
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%= ResolveClientUrl("~/scripts/Page/Extend_ProductRegister.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>