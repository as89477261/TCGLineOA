<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CouponManager.aspx.cs" Inherits="LineOABackend.views.CouponManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table tr td {padding:3px;}
        table tr th {padding:3px;}
    </style>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID="TabPanel0" runat="server" HeaderText="ภาพรวมคูปอง" ToolTip="Tooltip_TabPanel0" Style="padding: 10px; border: none;">
            <ContentTemplate>
                <label>ภาพรวมคูปอง</label>
                <asp:GridView ID="grdDashboardReward" runat="server" AutoGenerateColumns="false" >
                    <Columns>
                        <asp:BoundField DataField="RewardOwner" HeaderText="Partner บสย." />
                        <asp:BoundField DataField="RewardType" HeaderText="ประเภทคูปอง" />
                        <asp:BoundField DataField="RewardProgram" HeaderText="โครงการที่ร่วมกับ บสย." />
                        <asp:BoundField DataField="AllCoupon" HeaderText="จำนวนทั้งหมด" />
                    </Columns>
                </asp:GridView>
                <br />
                <label>คนลงทะเบียนรายการต่างๆ</label>
                <asp:GridView ID="grdRegister" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="RewardOwner" HeaderText="Partner บสย." />
                        <asp:BoundField DataField="RewardType" HeaderText="ประเภทคูปอง" />
                        <asp:BoundField DataField="RewardProgram" HeaderText="โครงการที่ร่วมกับ บสย." />
                        <asp:BoundField DataField="AllCoupon" HeaderText="จำนวนทั้งหมด" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="รายละเอียดคูปอง" ToolTip="Tooltip_TabPanel1" Style="padding: 10px;">
            <ContentTemplate>
                <div class="col-12">
                    <label>คูปองปัจจุบันในระบบ</label>

                </div>
                <div class="col-2">
                    <asp:RadioButtonList runat="server" ID="rdoIsUse" RepeatDirection="Horizontal">
                        <asp:ListItem Text="ทั้งหมด" Value="0" Selected="True" />
                        <asp:ListItem Text="ใช้งานแล้ว" Value="1" />
                        <asp:ListItem Text="ยังไม่ใช้งาน" Value="2" />
                    </asp:RadioButtonList>
                </div>
                <div class="col-10">
                    <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" OnClick="btnSearch_Click" />

                </div>

                <hr />
                <br />
                <div class="col-12">
                    <asp:Label ID="txtCountCurrentCoupon" Text="" runat="server" />
                </div>
                <div class="col-6" style="overflow-x: auto; max-height: 800px;">
                    <asp:GridView ID="grdCurrentDataCoupon" runat="server" AutoGenerateColumns="false" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="RewardOwner" HeaderText="RewardOwner" />
                            <asp:BoundField DataField="RewardTitle" HeaderText="RewardTitle" />
                            <asp:BoundField DataField="RewardDesc" HeaderText="RewardDesc" />
                            <asp:BoundField DataField="RewardType" HeaderText="RewardType" />
                            <asp:BoundField DataField="RewardCode" HeaderText="RewardCode" />
                            <asp:TemplateField HeaderText="StartDate">
                                <ItemTemplate>
                                    <asp:Label Text='<%# ((DateTime?)Eval("StartDate")).Value.ToString("dd/MM/yyyy",new System.Globalization.CultureInfo("th-TH")) %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EndDate">
                                <ItemTemplate>
                                    <asp:Label Text='<%# ((DateTime?)Eval("EndDate")).Value.ToString("dd/MM/yyyy",new System.Globalization.CultureInfo("th-TH")) %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="IsUse">
                                <ItemTemplate>
                                    <asp:Label Text='<%# ((bool?)Eval("IsUse")) == true ? "ใช้แล้ว":"ยังไม่ใช้" %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="IsActive">
                                <ItemTemplate>
                                    <asp:Label Text='<%# ((bool?)Eval("IsActive")) == true ? "ใช้งานได้":"ยกเลิก" %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="RewardProgram" HeaderText="RewardProgram" />
                            <asp:BoundField DataField="RewardCriteria" HeaderText="RewardCriteria" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="เพิ่มคูปอง" ToolTip="Tooltip_TabPanel2" Style="padding: 10px;">
            <ContentTemplate>
                <div class="row">
                    <div class="col-12" style="overflow-x: auto; max-height: 800px;">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <hr />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload Excel File" OnClick="btnUpload_Click" />
                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />

                        <asp:GridView ID="grdImportData" runat="server" CssClass="table">
                        </asp:GridView>
                    </div>
                    <div class="col-12">
                        <asp:Label ID="txtImportMessage" Text="" runat="server" />
                    </div>

                </div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="แจ้งคูปองใช้แล้ว" ToolTip="Tooltip_TabPanel3" Style="padding: 10px;">
            <ContentTemplate>
                Tab 3
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FooterScript" runat="server">
</asp:Content>
