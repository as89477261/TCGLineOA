<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.hora.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>SME มีดวง - ดูดวงธุรกิจฟรี</title>
    <style>
        /* ========== HORA BLUE-WHITE THEME ========== */
        .hora-page {
            background-color: whitesmoke;
            min-height: 100vh;
            padding-bottom: 80px;
        }

        /* --- Header --- */
        .hora-header {
            background: linear-gradient(135deg, #0a2463 0%, #1344a0 50%, #1a6fdd 100%);
            padding: 20px 16px 50px;
            text-align: center;
            position: relative;
            overflow: hidden;
        }
        .hora-header-back {
            position: absolute; left: 16px; top: 18px;
            background: rgba(255,255,255,0.15); border: none;
            color: #fff; width: 36px; height: 36px;
            border-radius: 50%; display: flex; align-items: center; justify-content: center;
            font-size: 16px; cursor: pointer; text-decoration: none;
        }
        .hora-header-back:hover { color: #fff; text-decoration: none; }
        .hora-header-icon { font-size: 44px; display: block; margin-bottom: 8px; color: #fff; }
        .hora-title { font-size: 22px; font-weight: 800; color: #fff; margin: 0; }
        .hora-subtitle { font-size: 13px; color: rgba(255,255,255,0.8); margin-top: 4px; }
        .hora-date-badge {
            display: inline-block; margin-top: 10px;
            background: rgba(255,255,255,0.2); border: 1px solid rgba(255,255,255,0.4);
            color: #fff; font-size: 12px; font-weight: 600;
            padding: 4px 14px; border-radius: 20px;
        }
        /* SVG wave separator */
        .hora-wave {
            display: block; margin-top: -1px;
            background: transparent;
        }

        /* --- Section Card --- */
        .hora-card {
            background: #fff;
            border-radius: 16px;
            margin: 0 16px 16px;
            padding: 18px 16px;
            box-shadow: 0 2px 12px rgba(0,0,0,0.08);
        }
        .hora-card-first { margin-top: -24px; }
        .hora-card-title {
            font-size: 15px; font-weight: 700; color: #0a2463;
            display: flex; align-items: center; gap: 8px; margin-bottom: 14px;
            padding-bottom: 10px; border-bottom: 2px solid #e8f0fe;
        }
        .hora-card-title i { font-size: 20px; color: #1344a0; }

        /* --- Lucky Color --- */
        .lucky-color-row { display: flex; gap: 10px; }
        .lucky-color-item {
            flex: 1; border-radius: 12px; overflow: hidden;
            border: 1px solid #e8f0fe;
        }
        .lucky-color-swatch {
            height: 68px; display: flex; align-items: center; justify-content: center;
            font-size: 26px;
        }
        .lucky-color-info { background: #f8faff; padding: 8px 10px; }
        .lucky-color-name { font-size: 13px; font-weight: 700; color: #0a2463; }
        .lucky-color-desc { font-size: 11px; color: #5a6b8a; margin-top: 2px; }
        .lucky-color-tag {
            display: inline-block; font-size: 10px; font-weight: 700;
            padding: 2px 8px; border-radius: 10px; margin-top: 4px;
            background: #e8f0fe; color: #1344a0;
        }
        .hora-fortune-text {
            background: #f0f6ff; border-left: 3px solid #1344a0;
            border-radius: 0 8px 8px 0; padding: 10px 12px; margin-top: 12px;
            font-size: 13px; color: #334155; line-height: 1.7;
        }

        /* --- Phone Fortune --- */
        .phone-input-wrap { position: relative; }
        .phone-input-wrap i {
            position: absolute; left: 12px; top: 50%; transform: translateY(-50%);
            color: #1344a0; font-size: 18px;
        }
        .hora-input {
            width: 100%; background: #f8faff;
            border: 1px solid #c7d8f7; color: #0a2463;
            border-radius: 12px; padding: 12px 12px 12px 42px;
            font-size: 16px; outline: none;
        }
        .hora-input::placeholder { color: #a0aec0; }
        .hora-input:focus { border-color: #1344a0; box-shadow: 0 0 0 3px rgba(19,68,160,0.12); }
        .hora-btn {
            width: 100%; margin-top: 10px;
            background: linear-gradient(135deg, #0a2463, #1344a0, #1a6fdd);
            border: none; color: #fff; font-size: 15px; font-weight: 700;
            padding: 13px; border-radius: 12px; cursor: pointer;
            box-shadow: 0 4px 14px rgba(19,68,160,0.35);
            transition: opacity 0.2s;
        }
        .hora-btn:active { opacity: 0.85; }
        .hora-btn i { margin-right: 6px; }

        .phone-result { display: none; }
        .numerology-circle {
            width: 76px; height: 76px; border-radius: 50%;
            background: linear-gradient(135deg, #0a2463, #1a6fdd);
            display: flex; flex-direction: column; align-items: center;
            justify-content: center; margin: 0 auto 12px;
            box-shadow: 0 4px 16px rgba(19,68,160,0.4);
        }
        .numerology-number { font-size: 32px; font-weight: 900; color: #fff; line-height: 1; }
        .numerology-label { font-size: 9px; color: rgba(255,255,255,0.8); }
        .phone-fortune-stars { color: #1344a0; font-size: 18px; letter-spacing: 4px;
            display: block; text-align: center; margin: 8px 0; }
        .phone-fortune-text {
            text-align: center; font-size: 14px; color: #334155;
            line-height: 1.75; padding: 0 8px;
        }

        /* --- Tarot Cards --- */
        .tarot-instruction {
            font-size: 12px; color: #5a6b8a; text-align: center; margin-bottom: 14px;
            background: #f0f6ff; border-radius: 8px; padding: 8px 10px;
        }
        .tarot-grid { display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px; }
        .tarot-card-wrap { perspective: 600px; }
        .tarot-card {
            position: relative; width: 100%; padding-top: 155%;
            cursor: pointer; transform-style: preserve-3d;
            transition: transform 0.6s cubic-bezier(0.4,0,0.2,1);
        }
        .tarot-card.flipped { transform: rotateY(180deg); }
        .tarot-card.used { opacity: 0.4; pointer-events: none; }
        .tarot-face, .tarot-back {
            position: absolute; inset: 0;
            backface-visibility: hidden; border-radius: 10px; overflow: hidden;
        }
        .tarot-back {
            background: linear-gradient(145deg, #0a2463, #1344a0, #0a2463);
            border: 2px solid rgba(255,255,255,0.2);
            display: flex; flex-direction: column;
            align-items: center; justify-content: center; gap: 6px;
        }
        .tarot-back-pattern {
            position: absolute; inset: 5px; border-radius: 7px;
            border: 1px solid rgba(255,255,255,0.15);
            background: repeating-linear-gradient(
                45deg, rgba(255,255,255,0.03) 0px, rgba(255,255,255,0.03) 2px,
                transparent 2px, transparent 10px
            );
        }
        .tarot-back-icon { font-size: 24px; color: #fff; z-index: 1; }
        .tarot-back-num { font-size: 9px; color: rgba(255,255,255,0.6); z-index: 1; }
        .tarot-face {
            background: linear-gradient(145deg, #f0f6ff, #e8f0fe);
            border: 2px solid #c7d8f7;
            transform: rotateY(180deg);
            display: flex; flex-direction: column;
            align-items: center; justify-content: center;
            padding: 6px 4px; text-align: center;
        }
        .tarot-face-icon { font-size: 26px; margin-bottom: 3px; }
        .tarot-face-name { font-size: 8px; font-weight: 800; color: #0a2463; line-height: 1.3; margin-bottom: 2px; }
        .tarot-face-meaning { font-size: 7px; color: #1344a0; line-height: 1.3; }
        .tarot-face-star { color: #1344a0; font-size: 9px; margin-top: 3px; }

        /* --- Result Modal --- */
        .hora-result-overlay {
            display: none; position: fixed; inset: 0; z-index: 10000;
            background: rgba(0,0,0,0.6); align-items: center; justify-content: center;
            padding: 20px;
        }
        .hora-result-overlay.show { display: flex; }
        .hora-result-box {
            background: #fff;
            border: 2px solid #c7d8f7;
            border-radius: 20px; padding: 28px 20px; max-width: 340px;
            width: 100%; text-align: center;
            box-shadow: 0 8px 40px rgba(19,68,160,0.25);
        }
        .hora-result-icon { font-size: 52px; margin-bottom: 10px; }
        .hora-result-card-name { font-size: 18px; font-weight: 800; color: #0a2463; margin-bottom: 6px; }
        .hora-result-divider { color: #c7d8f7; letter-spacing: 8px; font-size: 14px; margin: 8px 0; }
        .hora-result-text { font-size: 14px; color: #334155; line-height: 1.8; text-align: left; }
        .hora-result-close {
            margin-top: 18px;
            background: linear-gradient(135deg, #0a2463, #1a6fdd);
            border: none; color: #fff; font-size: 14px; font-weight: 700;
            padding: 11px 30px; border-radius: 12px; cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hora-page">

    <!-- Header -->
    <div class="hora-header">
        <a href="<%= ResolveClientUrl("~/index.aspx") %>" class="hora-header-back">
            <i class="bi bi-chevron-left"></i>
        </a>
        <i class="bi bi-stars hora-header-icon"></i>
        <h1 class="hora-title">SME มีดวง</h1>
        <p class="hora-subtitle">ดูดวงธุรกิจ &bull; การเงิน &bull; โชคชะตา</p>
        <span class="hora-date-badge" id="todayLabel">กำลังโหลด...</span>
    </div>

    <!-- Wave Divider -->
    <svg class="hora-wave" viewBox="0 0 360 28" xmlns="http://www.w3.org/2000/svg"
         preserveAspectRatio="none" style="width:100%;height:28px;display:block;margin-top:-1px;">
        <path d="M0,0 C60,28 120,28 180,14 C240,0 300,0 360,14 L360,28 L0,28 Z"
              fill="whitesmoke"/>
    </svg>

    <!-- Section 1: สีมงคลการเงิน -->
    <div class="hora-card hora-card-first">
        <div class="hora-card-title">
            <i class="bi bi-palette-fill"></i>
            สีมงคลด้านการเงินวันนี้
        </div>
        <div class="lucky-color-row" id="luckyColorRow"></div>
        <div class="hora-fortune-text" id="luckyColorFortune"></div>
    </div>

    <!-- Section 2: ดูดวงเบอร์โทร -->
    <div class="hora-card">
        <div class="hora-card-title">
            <i class="bi bi-telephone-fill"></i>
            ดูดวงจากเบอร์โทรศัพท์
        </div>
        <div class="phone-input-wrap">
            <i class="bi bi-telephone"></i>
            <input type="tel" id="phoneInput" class="hora-input"
                   placeholder="กรอกเบอร์โทรศัพท์ของคุณ" maxlength="10"
                   oninput="this.value=this.value.replace(/[^0-9]/g,'')" />
        </div>
        <button type="button" class="hora-btn" onclick="readPhoneFortune()">
            <i class="bi bi-search"></i> เปิดดวงชะตา
        </button>
        <div class="phone-result" id="phoneResult" style="margin-top:16px; padding-top:14px; border-top:1px solid #e8f0fe;">
            <div class="numerology-circle">
                <span class="numerology-number" id="phoneNumResult"></span>
                <span class="numerology-label">เลขชีวิต</span>
            </div>
            <span class="phone-fortune-stars" id="phoneStars"></span>
            <p class="phone-fortune-text" id="phoneFortuneText"></p>
        </div>
    </div>

    <!-- Section 3: ไพ่ทาโรต์ -->
    <div class="hora-card">
        <div class="hora-card-title">
            <i class="bi bi-layers-fill"></i>
            ไพ่ทาโรต์ประจำวัน
        </div>
        <div class="tarot-instruction">
            <i class="bi bi-hand-index-thumb"></i>
            เลือก 1 ใบ เพื่อรับพลังงานและคำทำนายประจำวันของคุณ
        </div>
        <div class="tarot-grid" id="tarotGrid"></div>
    </div>

</div>

<!-- Tarot Result Modal -->
<div class="hora-result-overlay" id="tarotResultOverlay">
    <div class="hora-result-box">
        <div class="hora-result-icon" id="resultIcon"></div>
        <div class="hora-result-card-name" id="resultCardName"></div>
        <div class="hora-result-divider">- - -</div>
        <p class="hora-result-text" id="resultText"></p>
        <button type="button" class="hora-result-close" onclick="closeResult()">
            <i class="bi bi-check2-circle"></i> รับพลังงาน
        </button>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
<script>
// ============================================================
// HORA - Fortune Page Script (UTF-8 safe, blue-white theme)
// ============================================================

var DAY_DATA = [
    {
        name: "วันอาทิตย์",
        colors: [
            { hex: "#dc2626", name: "แดง", icon: "bi-circle-fill", desc: "โชคลาภ อำนาจ", tag: "เงินทอง" },
            { hex: "#f97316", name: "สีส้ม", icon: "bi-circle-fill", desc: "พลังงาน ความสำเร็จ", tag: "ธุรกิจ" }
        ],
        fortune: "วันนี้พลังงานสีแดงเสริมความกล้า เหมาะกับการตัดสินใจเรื่องการลงทุนและการขยายธุรกิจ ดวงการเงินอยู่ในเกณฑ์ดี ระวังรายจ่ายที่ไม่จำเป็น"
    },
    {
        name: "วันจันทร์",
        colors: [
            { hex: "#f59e0b", name: "สีเหลือง", icon: "bi-circle-fill", desc: "ปัญญา ความมั่งคั่ง", tag: "โชคลาภ" },
            { hex: "#fbbf24", name: "สีครีม", icon: "bi-circle-fill", desc: "ความสงบ ราบรื่น", tag: "การงาน" }
        ],
        fortune: "สีเหลืองทองเป็นสีแห่งความมั่งคั่งในวันจันทร์ เหมาะกับการเจรจาธุรกิจและการขอสินเชื่อ ดวงดีในเรื่องเอกสารและสัญญา"
    },
    {
        name: "วันอังคาร",
        colors: [
            { hex: "#ec4899", name: "สีชมพู", icon: "bi-circle-fill", desc: "ความรัก ความสัมพันธ์", tag: "มนุษยสัมพันธ์" },
            { hex: "#a855f7", name: "สีม่วง", icon: "bi-circle-fill", desc: "สัญชาตญาณ ไหวพริบ", tag: "ไหวพริบ" }
        ],
        fortune: "สีชมพูและม่วงเสริมพลังการเจรจาและความสัมพันธ์ทางธุรกิจ วันนี้เหมาะกับการพบปะพาร์ทเนอร์ใหม่ หรือขยายเครือข่าย SME"
    },
    {
        name: "วันพุธ",
        colors: [
            { hex: "#16a34a", name: "สีเขียว", icon: "bi-circle-fill", desc: "เจริญเติบโต มั่นคง", tag: "การเงิน" },
            { hex: "#84cc16", name: "เขียวอ่อน", icon: "bi-circle-fill", desc: "ความสดใส สุขภาพดี", tag: "โชคดี" }
        ],
        fortune: "สีเขียวคือสีแห่งความเจริญรุ่งเรืองในวันพุธ เหมาะกับการออมเงิน ลงทุนระยะยาว และขยายสาขาธุรกิจ ดวงการเงินมาแรง"
    },
    {
        name: "วันพฤหัสบดี",
        colors: [
            { hex: "#f97316", name: "สีส้ม", icon: "bi-circle-fill", desc: "พลัง ความกล้า", tag: "ความสำเร็จ" },
            { hex: "#d97706", name: "สีทอง", icon: "bi-circle-fill", desc: "ความมั่งคั่ง สิริมงคล", tag: "โชคลาภ" }
        ],
        fortune: "สีส้มทองวันพฤหัสเสริมโชคลาภและความก้าวหน้า เหมาะกับการยื่นเรื่องขอสินเชื่อ หรือลงนามสัญญาสำคัญ ดวงธุรกิจดีมาก"
    },
    {
        name: "วันศุกร์",
        colors: [
            { hex: "#3b82f6", name: "สีฟ้า", icon: "bi-circle-fill", desc: "สันติ ความไว้วางใจ", tag: "การค้า" },
            { hex: "#06b6d4", name: "ฟ้าเขียว", icon: "bi-circle-fill", desc: "ความคิดสร้างสรรค์", tag: "นวัตกรรม" }
        ],
        fortune: "วันศุกร์สีฟ้าเสริมความน่าเชื่อถือและความไว้วางใจ เหมาะกับการนำเสนองานหรือพรีเซนต์ธุรกิจ ดวงการเจรจาดีเยี่ยม"
    },
    {
        name: "วันเสาร์",
        colors: [
            { hex: "#7c3aed", name: "ม่วงเข้ม", icon: "bi-circle-fill", desc: "อำนาจ ศักดิ์ศรี", tag: "ความมั่งคั่ง" },
            { hex: "#1e3a8a", name: "สีกรมท่า", icon: "bi-circle-fill", desc: "ลึกลับ ปัญญา", tag: "วิสัยทัศน์" }
        ],
        fortune: "สีม่วงและกรมท่าในวันเสาร์เสริมพลังแห่งปัญญาและวิสัยทัศน์ เหมาะกับการวางแผนกลยุทธ์ธุรกิจระยะยาว หรือการฝึกอบรมพัฒนาตนเอง"
    }
];

var NUMEROLOGY = {
    1: { stars: 5, text: "เลข 1 คือพลังแห่งผู้นำ คุณมีความสามารถในการบริหารและตัดสินใจที่แข็งแกร่ง ธุรกิจของคุณมีแนวโน้มเติบโตด้วยความมุ่งมั่นของตัวเอง การเงินมีทิศทางที่ดีหากคุณเป็นคนริเริ่มก่อน" },
    2: { stars: 4, text: "เลข 2 คือพลังแห่งความร่วมมือ คุณเหมาะกับการทำธุรกิจแบบพาร์ทเนอร์ หรือการร่วมลงทุน ดวงการเงินดีจากความสัมพันธ์ที่ดีกับผู้อื่น อย่าตัดสินใจใหญ่คนเดียว" },
    3: { stars: 5, text: "เลข 3 คือพลังแห่งความสร้างสรรค์และการสื่อสาร คุณโดดเด่นด้านการตลาดและการนำเสนอ ธุรกิจดิจิทัลหรือสื่อสิ่งพิมพ์เหมาะกับคุณมาก ดวงการเงินดีจากทักษะการสื่อสาร" },
    4: { stars: 3, text: "เลข 4 คือพลังแห่งความมั่นคงและระเบียบ คุณเหมาะกับธุรกิจที่มีโครงสร้างชัดเจน ดวงการเงินมั่นคงแต่ค่อยเป็นค่อยไป ต้องอดทนและวางแผนอย่างรอบคอบ" },
    5: { stars: 4, text: "เลข 5 คือพลังแห่งการเปลี่ยนแปลงและอิสรภาพ คุณเหมาะกับธุรกิจที่ยืดหยุ่น เช่น ค้าขาย ท่องเที่ยว หรือที่ปรึกษา ดวงโชคลาภมาแบบไม่คาดฝัน" },
    6: { stars: 4, text: "เลข 6 คือพลังแห่งความรับผิดชอบและการบริการ คุณเหมาะกับธุรกิจที่ดูแลผู้อื่น เช่น อาหาร สุขภาพ หรือการศึกษา ดวงการเงินดีจากความไว้วางใจของลูกค้า" },
    7: { stars: 4, text: "เลข 7 คือพลังแห่งปัญญาและการวิเคราะห์ คุณเหมาะกับธุรกิจที่ใช้ความรู้เชิงลึก เช่น เทคโนโลยี กฎหมาย หรือการวิจัย ดวงการเงินดีจากความเชี่ยวชาญ" },
    8: { stars: 5, text: "เลข 8 คือพลังแห่งอำนาจและความมั่งคั่ง นี่คือตัวเลขนักธุรกิจแท้ คุณมีพลังในการสะสมความมั่งคั่งและสร้างอาณาจักรธุรกิจ ดวงการเงินดีเยี่ยม" },
    9: { stars: 4, text: "เลข 9 คือพลังแห่งความสมบูรณ์และมนุษยธรรม คุณเหมาะกับธุรกิจเพื่อสังคม หรือธุรกิจที่ช่วยเหลือผู้อื่น ดวงการเงินดีจากการแบ่งปันและการสร้างคุณค่า" }
};

var TAROT_CARDS = [
    {
        icon: "bi-star-fill",
        name: "ดวงดาว (The Star)",
        meaning: "ความหวัง โชคลาภ",
        detail: "ดวงดาวส่องแสงให้คุณ! วันนี้โชคชะตาเปิดทางให้ธุรกิจของคุณ มีโอกาสใหม่ที่กำลังจะเข้ามา จงมีความหวังและมองโลกในแง่ดี ดวงการเงินดีเยี่ยม อาจได้รับข่าวดีเรื่องสินเชื่อหรือการลงทุน"
    },
    {
        icon: "bi-sun-fill",
        name: "ดวงอาทิตย์ (The Sun)",
        meaning: "ความสำเร็จ ชัยชนะ",
        detail: "พลังอาทิตย์เปล่งแสงให้คุณเด่นชัด! ธุรกิจกำลังเจริญรุ่งเรือง ลูกค้าให้ความไว้วางใจ รายได้มีแนวโน้มเพิ่มขึ้น เป็นวันที่เหมาะกับการตัดสินใจสำคัญและการลงนามสัญญา"
    },
    {
        icon: "bi-moon-stars-fill",
        name: "ดวงจันทร์ (The Moon)",
        meaning: "ญาณทิพย์ ความลึกซึ้ง",
        detail: "ดวงจันทร์บอกให้คุณหยุดฟังเสียงภายใน มีบางอย่างที่ยังไม่ชัดเจนในธุรกิจ อย่าเพิ่งตัดสินใจใหญ่โดยขาดข้อมูล รอให้สถานการณ์ชัดขึ้นก่อน แต่ดวงการเงินยังคงสม่ำเสมอ"
    },
    {
        icon: "bi-globe",
        name: "โลกกว้าง (The World)",
        meaning: "ความสมบูรณ์ ชัยชนะ",
        detail: "คุณกำลังจะบรรลุเป้าหมายสำคัญ! ธุรกิจที่ลงทุนไปกำลังออกดอกออกผล การขยายตลาดหรือเปิดสาขาใหม่มีแนวโน้มสำเร็จ ดวงการเงินดีมาก โชคลาภมาจากทุกทิศทาง"
    },
    {
        icon: "bi-arrow-repeat",
        name: "วงล้อโชคชะตา",
        meaning: "การเปลี่ยนแปลง โอกาส",
        detail: "วงล้อแห่งโชคชะตากำลังหมุน การเปลี่ยนแปลงครั้งสำคัญกำลังมา อาจเป็นโอกาสใหม่หรือความท้าทายใหม่ จงยืดหยุ่นและพร้อมรับมือ ดวงโชคลาภมาแบบไม่คาดฝัน"
    },
    {
        icon: "bi-shield-fill",
        name: "ผู้นำแห่งอำนาจ",
        meaning: "อำนาจ ความมั่นคง",
        detail: "คุณมีอำนาจและความสามารถในการควบคุมทิศทางธุรกิจ เหมาะกับการวางโครงสร้างองค์กรและการบริหารทีม ดวงการเงินมั่นคงและแข็งแกร่ง"
    },
    {
        icon: "bi-eye-fill",
        name: "ผู้รู้แจ้ง",
        meaning: "ปัญญา สัญชาตญาณ",
        detail: "ปัญญาลึกนำทางคุณ วันนี้จงเชื่อสัญชาตญาณ มีข้อมูลสำคัญที่ยังซ่อนอยู่ ควรศึกษาข้อมูลให้ลึกก่อนตัดสินใจลงทุน ดวงการเงินดีหากคุณใช้ปัญญา"
    },
    {
        icon: "bi-lightning-charge-fill",
        name: "นักเวทย์มนต์",
        meaning: "พลังงาน ความสามารถ",
        detail: "คุณมีทุกอย่างที่จำเป็นสำหรับความสำเร็จ! ทักษะ ความรู้ และพลังงานพร้อมแล้ว ถึงเวลาลงมือทำโปรเจกต์ที่รอคอย ดวงการเงินดีเยี่ยมสำหรับผู้ที่กล้าลงมือ"
    }
];

// ============================================================
// Init
// ============================================================
document.addEventListener("DOMContentLoaded", function () {
    renderTodayLabel();
    renderLuckyColor();
    renderTarotGrid();
});

function renderTodayLabel() {
    var days = ["\u0e27\u0e31\u0e19\u0e2d\u0e32\u0e17\u0e34\u0e15\u0e22\u0e4c","\u0e27\u0e31\u0e19\u0e08\u0e31\u0e19\u0e17\u0e23\u0e4c","\u0e27\u0e31\u0e19\u0e2d\u0e31\u0e07\u0e04\u0e32\u0e23","\u0e27\u0e31\u0e19\u0e1e\u0e38\u0e18","\u0e27\u0e31\u0e19\u0e1e\u0e24\u0e2b\u0e31\u0e2a\u0e1a\u0e14\u0e35","\u0e27\u0e31\u0e19\u0e28\u0e38\u0e01\u0e23\u0e4c","\u0e27\u0e31\u0e19\u0e40\u0e2a\u0e32\u0e23\u0e4c"];
    var months = ["\u0e21.\u0e04.","\u0e01.\u0e1e.","\u0e21\u0e35.\u0e04.","\u0e40\u0e21.\u0e22.","\u0e1e.\u0e04.","\u0e21\u0e34.\u0e22.","\u0e01.\u0e04.","\u0e2a.\u0e04.","\u0e01.\u0e22.","\u0e15.\u0e04.","\u0e1e.\u0e22.","\u0e18.\u0e04."];
    var d = new Date();
    document.getElementById("todayLabel").textContent = days[d.getDay()] + " \u0e17\u0e35\u0e48 " + d.getDate() + " " + months[d.getMonth()] + " " + (d.getFullYear() + 543);
}

function renderLuckyColor() {
    var day = new Date().getDay();
    var data = DAY_DATA[day];
    var row = document.getElementById("luckyColorRow");
    var html = "";
    data.colors.forEach(function (c) {
        html += '<div class="lucky-color-item">' +
            '<div class="lucky-color-swatch" style="background:' + c.hex + ';">' +
                '<i class="bi bi-circle-fill" style="font-size:32px;color:rgba(255,255,255,0.5);"></i>' +
            '</div>' +
            '<div class="lucky-color-info">' +
                '<div class="lucky-color-name">' + c.name + '</div>' +
                '<div class="lucky-color-desc">' + c.desc + '</div>' +
                '<span class="lucky-color-tag">' + c.tag + '</span>' +
            '</div>' +
        '</div>';
    });
    row.innerHTML = html;
    document.getElementById("luckyColorFortune").textContent = data.fortune;
}

function buildStars(n) {
    var s = "";
    for (var i = 0; i < 5; i++) {
        s += '<i class="bi bi-star' + (i < n ? "-fill" : "") + '" style="font-size:16px;color:#1344a0;"></i> ';
    }
    return s;
}

function renderTarotGrid() {
    var grid = document.getElementById("tarotGrid");
    var html = "";
    var shuffled = TAROT_CARDS.slice().sort(function () { return Math.random() - 0.5; });
    shuffled.forEach(function (card, i) {
        html += '<div class="tarot-card-wrap">' +
            '<div class="tarot-card" id="tc' + i + '" onclick="flipTarot(this,' + i + ')">' +
                '<div class="tarot-back">' +
                    '<div class="tarot-back-pattern"></div>' +
                    '<i class="bi bi-stars tarot-back-icon"></i>' +
                    '<span class="tarot-back-num">\u0e43\u0e1a\u0e17\u0e35\u0e48 ' + (i + 1) + '</span>' +
                '</div>' +
                '<div class="tarot-face">' +
                    '<i class="bi ' + card.icon + ' tarot-face-icon" style="color:#1344a0;"></i>' +
                    '<div class="tarot-face-name">' + card.name + '</div>' +
                    '<div class="tarot-face-meaning">' + card.meaning + '</div>' +
                    '<div class="tarot-face-star"><i class="bi bi-three-dots"></i></div>' +
                '</div>' +
            '</div>' +
        '</div>';
    });
    grid.innerHTML = html;
    window._shuffledTarot = shuffled;
}

var tarotPicked = false;
function flipTarot(el, idx) {
    if (tarotPicked) return;
    tarotPicked = true;
    el.classList.add("flipped");
    setTimeout(function () { showTarotResult(idx); }, 700);
    setTimeout(function () {
        var all = document.querySelectorAll(".tarot-card");
        all.forEach(function (c, i) { if (i !== idx) c.classList.add("used"); });
    }, 200);
}

function showTarotResult(idx) {
    var card = window._shuffledTarot[idx];
    document.getElementById("resultIcon").innerHTML = '<i class="bi ' + card.icon + '" style="font-size:52px;color:#1344a0;"></i>';
    document.getElementById("resultCardName").textContent = card.name;
    document.getElementById("resultText").textContent = card.detail;
    document.getElementById("tarotResultOverlay").classList.add("show");
}

function closeResult() {
    document.getElementById("tarotResultOverlay").classList.remove("show");
}

function readPhoneFortune() {
    var phone = document.getElementById("phoneInput").value.replace(/\D/g, "");
    if (phone.length < 9) {
        alert("\u0e01\u0e23\u0e38\u0e13\u0e32\u0e01\u0e23\u0e2d\u0e01\u0e40\u0e1a\u0e2d\u0e23\u0e4c\u0e42\u0e17\u0e23\u0e28\u0e31\u0e1e\u0e17\u0e4c\u0e43\u0e2b\u0e49\u0e04\u0e23\u0e1a\u0e16\u0e49\u0e27\u0e19");
        return;
    }
    var sum = 0;
    for (var i = 0; i < phone.length; i++) { sum += parseInt(phone[i]); }
    while (sum > 9) {
        var s2 = 0;
        while (sum > 0) { s2 += sum % 10; sum = Math.floor(sum / 10); }
        sum = s2;
    }
    var data = NUMEROLOGY[sum];
    document.getElementById("phoneNumResult").textContent = sum;
    document.getElementById("phoneStars").innerHTML = buildStars(data.stars);
    document.getElementById("phoneFortuneText").textContent = data.text;
    var result = document.getElementById("phoneResult");
    result.style.display = "block";
    result.scrollIntoView({ behavior: "smooth", block: "nearest" });
}
</script>
</asp:Content>
