<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" 
    Inherits="LineOABackend.views.Register.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="container">
                <div class="row form-group">
                    <div class="col-md-12">
                        <div data-role="appendRow">
                            <div class="form-inline form-row">

                                <asp:TextBox ID="txtIdCardSearch" runat="server" class="form-control mb-2 mr-sm-2 col-sm-4"
                                    placeholder="ค้นหาด้วยเลขบัตรประจำตัวประชาชน"></asp:TextBox>

                                <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-primary  mb-2" Text="ค้นหา"
                                    Style="margin-left: 10px;" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView
                                CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="false"
                                OnPageIndexChanging="grdPersonalRegister_PageIndexChanging"
                                AllowPaging="true"
                                OnSorting="grdPersonalRegister_Sorting"
                                AllowSorting="true"
                                ID="grdPersonalRegister"
                                OnRowCommand="grdPersonalRegister_RowCommand"
                                DataKeyNames="DummyID"
                                PageSize="15"
                                runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnGrdDtail" Text="รายละเอียด"
                                                CommandName="detail" CommandArgument='<%# Eval("DummyID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FirstName"
                                        SortExpression="FirstName" HeaderText="ชื่อ" />

                                    <asp:BoundField DataField="LastName"
                                        SortExpression="LastName" HeaderText="นามสกุล" />

                                    <asp:BoundField DataField="IdentityID"
                                        SortExpression="IdentityID" HeaderText="เลขบัตรประจำตัวประชาชน" />

                                    <asp:BoundField DataField="MobilePhone"
                                        SortExpression="MobilePhone" HeaderText="เบอร์โทร" />

                                      <asp:BoundField DataField="CreatedDate"
                                        SortExpression="CreatedDate" HeaderText="วันที่ลงทะเบียน" />

                                    <asp:TemplateField HeaderText="สถานะลงทะเบียน" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("IsDummy").ToString() == "True" ? "เสร็จสิ้น" : "ยังไม่เสร็จสิ้น" %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                                <EmptyDataTemplate>
                                    There are currently no items in this table.
                                </EmptyDataTemplate>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

    <div id="detailModal" class="modal " tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">รายละเอียดผู้ลงทะเบียน</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                           

                            <asp:DetailsView ID="DetailsView1"
                                runat="server" CssClass="table table-bordered table-hover"
                                BackColor="White" ForeColor="Black"
                                FieldHeaderStyle-Wrap="false"
                                FieldHeaderStyle-Font-Bold="true"
                                FieldHeaderStyle-BackColor="LavenderBlush"
                                FieldHeaderStyle-ForeColor="Black"
                                BorderStyle="Groove" AutoGenerateRows="False">
                                <Fields>
                                    <asp:BoundField DataField="DummyID"
                                        HeaderText="รหัสการยืนยันตัวตน" />
                                    <asp:BoundField DataField="FirstName"
                                        HeaderText="FirstName" />
                                    <asp:BoundField DataField="LastName"
                                        HeaderText="LastName" />
                                    <asp:BoundField DataField="IdentityID"
                                        HeaderText="IdentityID" />
                                    <asp:BoundField DataField="MobilePhone"
                                        HeaderText="MobilePhone" />
                                    <asp:TemplateField HeaderText="สถานะลงทะเบียน">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("IsDummy").ToString() == "True" ? "เสร็จสิ้น" : "ยังไม่เสร็จสิ้น" %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="CreatedDate">
                                        <ItemTemplate>
                                            <%# (DateTime)Eval("CreatedDate") == 
                                                    (DateTime.MinValue) ? "" : string.Format
                                                    ("{0:dd/MM/yyyy hh:mm:ss tt}", 
                                                    (DateTime)Eval("CreatedDate")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                            </asp:DetailsView>

                            <label>สถานะการยืนยันตัวตน</label>
                           <asp:GridView
                                CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="false"                              
                                AllowPaging="true"                              
                                AllowSorting="true"
                                ID="grdVerifyPersonal" 
                                PageSize="15"
                                runat="server">
                                <Columns>                                   
                                
                                    
                                    <asp:TemplateField HeaderText="ประเภทการตรวจสอบ" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("VerifyType").ToString() == "PERSONAL" ? "ตรวจชื่อนามสกุล" : "ตรวจ OTP" %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="KeyInValue"
                                        SortExpression="KeyInValue" HeaderText="ข้อมูลที่กรอกยืนยัน" />
                                    <asp:BoundField DataField="KeyInDate"
                                        SortExpression="KeyInDate" HeaderText="วันที่กรอกข้อมูลยืนยัน" />   
                                     <asp:BoundField DataField="IsSuccess"
                                        SortExpression="IsSuccess" HeaderText="สถานะยืนยัน" />              
                                     <asp:BoundField DataField="RefNumber"
                                        SortExpression="RefNumber" HeaderText="รหัสอ้างอิง" />              
                                     <asp:BoundField DataField="Status"
                                        SortExpression="Status" HeaderText="สถานะข้อมูล" />              

                                </Columns>
                                <EmptyDataTemplate>
                                    There are currently no items in this table.
                                </EmptyDataTemplate>
                            </asp:GridView>

                          
                        </ContentTemplate>

                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FooterScript" runat="server">
</asp:Content>
