<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_EventTitle.ascx.cs" Inherits="CustomerHealthCheck.UserControl.UC_EventTitle" %>


<div class="accordion-item  border-fade-highlight border-bottom-0 rounded-top rounded-m">
    <%-- <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#accordion">
        <i class="bi bi-calendar-event color-violet-dark pe-3 font-30" style="color: white;"></i>
        <span class="font-600 font-18 color-theme">
            </span>
        <i class="bi bi-check-circle-fill font-20 color-green-dark"></i>
    </button>
    <div id="accordion1-2" class="accordion-collapse collapse p-2 show" data-bs-parent="#accordion-group-7"> --%>


    <asp:Literal ID="ltlTitle" Text="" runat="server"/>


    <asp:Literal ID="ltlSubTitle" Text="" runat="server"/>
    <%--<p style="margin-bottom: 10px !important; color: black;">&nbsp; &nbsp;วันที่ 28 พ.ย. 65 เวลา 14.00 - 15.30 น ผ่านระบบการประชุมออนไลน์ รับลิงค์ประชุมหลังการลงทะเบียน</p>
        <p style="margin-bottom: 10px !important; color: black;">หมายเหตุ : สามารถเข้าลิงค์ประชุมได้ในวันที่ 28 พ.ย. 65 ตั้งแต่เวลา 13.45 น. เป็นต้นไป</p>
        <p style="margin-bottom: 10px !important; color: black;">กิจกรรมภายในงานท่านจะได้พบกับ</p>--%>

    <br/>
    <asp:Panel runat="server" ID="pnlIsBodyIsText" Visible="false">
        <asp:Literal ID="ltlBody" Text="" runat="server"/>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlIsBodyIsPicture" Visible="false">
        <asp:Image Style="width: 100%; margin-bottom: 15px; border-radius: 15px;" runat="server" ID="imgImageBody"/>
    </asp:Panel>


    <%-- <table class=" color-theme mb-2" style="margin-left: 20px;">

            <tbody>
                <tr class="border-fade-blue">
                    <td class="text-center" style="vertical-align: top;"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                    <td>1. สัมมนาออนไลน์ SMEs อยากกู้เงินแบงค์ทั้งที ทำไมต้องมี บสย. คํ้าฯ</td>
                </tr>
                <tr class="border-fade-blue">
                    <td class="text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                    <td>2. สินเชื่อเพื่อ SMEs โปรโมชันดี มี บสย. คํ้าฯ</td>
                </tr>
                <tr class="border-fade-blue">
                    <td class="border-0 text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                    <td>3. ผลิตภัณฑ์คํ้าประกันสินเชื่อที่หลากหลายของ บสย.</td>
                </tr>
                <tr class="border-fade-blue">
                    <td class="border-0 text-center"><i class="bi bi-check-circle-fill color-green-dark"></i></td>
                    <td>4. จับคู่ SMEs ที่ต้องการขอสินเชื่อกับธนาคาร</td>
                </tr>
            </tbody>
        </table>--%>
    <asp:Literal ID="ltlRegisterButton" Text="" runat="server"/>
    <%-- <a href="#" onclick="ChooseEvent('001')" id="btnRegis001" class="btn btn-full mx-3 gradient-blue shadow-bg shadow-bg-s">ลงทะเบียนกิจกรรม</a>--%>
</div>

<br/>