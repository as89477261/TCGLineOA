<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.hora.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SME มีดวง - ดูดวงธุรกิจฟรี</title>
    <style>
        /* ========== HORA THEME ========== */
        .hora-page {
            background: linear-gradient(180deg, #0f0c29 0%, #1a0533 40%, #24074a 100%);
            min-height: 100vh;
            color: #fff;
            padding-bottom: 80px;
        }

        /* --- Header --- */
        .hora-header {
            background: linear-gradient(135deg, #1e0535 0%, #3b0764 50%, #6b21a8 100%);
            padding: 20px 16px 30px;
            text-align: center;
            position: relative;
            overflow: hidden;
        }
        .hora-header::before {
            content: "✦ ✧ ★ ✦ ✧ ★ ✦ ✧ ★ ✦ ✧ ★ ✦";
            position: absolute; top: 6px; left: 0; right: 0;
            font-size: 10px; color: rgba(255,215,0,0.3);
            letter-spacing: 4px; text-align: center;
        }
        .hora-header-back {
            position: absolute; left: 16px; top: 20px;
            background: rgba(255,255,255,0.1); border: none;
            color: #fde68a; width: 36px; height: 36px;
            border-radius: 50%; display: flex; align-items: center; justify-content: center;
            font-size: 16px; cursor: pointer; text-decoration: none;
        }
        .hora-moon-icon { font-size: 48px; display: block; margin-bottom: 6px;
            filter: drop-shadow(0 0 12px rgba(255,215,0,0.8)); }
        .hora-title { font-size: 22px; font-weight: 800; color: #fde68a;
            text-shadow: 0 0 12px rgba(255,215,0,0.6); margin: 0; }
        .hora-subtitle { font-size: 13px; color: #c4b5fd; margin-top: 4px; }
        .hora-date-badge {
            display: inline-block; margin-top: 10px;
            background: rgba(255,215,0,0.15); border: 1px solid rgba(255,215,0,0.4);
            color: #fde68a; font-size: 12px; font-weight: 600;
            padding: 4px 14px; border-radius: 20px;
        }

        /* --- Section Card --- */
        .hora-card {
            background: rgba(255,255,255,0.06);
            border: 1px solid rgba(255,255,255,0.1);
            border-radius: 16px; margin: 14px 16px 0; padding: 18px 16px;
            backdrop-filter: blur(4px);
        }
        .hora-card-title {
            font-size: 14px; font-weight: 700; color: #fde68a;
            display: flex; align-items: center; gap: 8px; margin-bottom: 14px;
        }
        .hora-card-title i { font-size: 18px; }

        /* --- Lucky Color Section --- */
        .lucky-color-row { display: flex; gap: 10px; flex-wrap: wrap; }
        .lucky-color-item {
            flex: 1; min-width: 130px;
            border-radius: 12px; overflow: hidden;
        }
        .lucky-color-swatch {
            height: 70px; display: flex; align-items: center; justify-content: center;
            font-size: 28px;
        }
        .lucky-color-info { background: rgba(0,0,0,0.3); padding: 8px 10px; }
        .lucky-color-name { font-size: 14px; font-weight: 700; color: #fff; }
        .lucky-color-desc { font-size: 11px; color: #c4b5fd; margin-top: 2px; }
        .lucky-color-tag {
            display: inline-block; font-size: 10px; font-weight: 700;
            padding: 2px 8px; border-radius: 10px; margin-top: 4px;
            background: rgba(255,215,0,0.25); color: #fde68a;
        }
        .hora-fortune-text {
            background: rgba(255,215,0,0.08); border-left: 3px solid #fbbf24;
            border-radius: 0 8px 8px 0; padding: 10px 12px; margin-top: 12px;
            font-size: 13px; color: #e9d5ff; line-height: 1.6;
        }

        /* --- Phone Fortune Section --- */
        .phone-input-wrap { position: relative; }
        .phone-input-wrap i {
            position: absolute; left: 12px; top: 50%; transform: translateY(-50%);
            color: #a78bfa; font-size: 18px;
        }
        .hora-input {
            width: 100%; background: rgba(255,255,255,0.08);
            border: 1px solid rgba(167,139,250,0.4); color: #fff;
            border-radius: 12px; padding: 12px 12px 12px 42px;
            font-size: 16px; outline: none;
        }
        .hora-input::placeholder { color: rgba(255,255,255,0.35); }
        .hora-input:focus { border-color: #a78bfa; box-shadow: 0 0 0 3px rgba(167,139,250,0.2); }
        .hora-btn {
            width: 100%; margin-top: 10px;
            background: linear-gradient(135deg, #7c3aed, #9333ea, #c026d3);
            border: none; color: #fff; font-size: 15px; font-weight: 700;
            padding: 13px; border-radius: 12px; cursor: pointer;
            box-shadow: 0 4px 15px rgba(147,51,234,0.5);
            transition: opacity 0.2s;
        }
        .hora-btn:active { opacity: 0.85; }
        .hora-btn i { margin-right: 6px; }

        .phone-result { display: none; }
        .numerology-circle {
            width: 72px; height: 72px; border-radius: 50%;
            background: linear-gradient(135deg, #7c3aed, #c026d3);
            display: flex; flex-direction: column; align-items: center;
            justify-content: center; margin: 0 auto 12px;
            box-shadow: 0 0 20px rgba(192,38,211,0.6);
            border: 2px solid rgba(255,215,0,0.4);
        }
        .numerology-number { font-size: 30px; font-weight: 900; color: #fde68a; line-height: 1; }
        .numerology-label { font-size: 9px; color: #e9d5ff; }
        .phone-fortune-text {
            text-align: center; font-size: 14px; color: #e9d5ff;
            line-height: 1.7; padding: 0 8px;
        }
        .phone-fortune-stars { color: #fbbf24; font-size: 16px; letter-spacing: 4px;
            display: block; text-align: center; margin: 8px 0; }

        /* --- Tarot Cards Section --- */
        .tarot-instruction {
            font-size: 12px; color: #c4b5fd; text-align: center; margin-bottom: 14px;
        }
        .tarot-grid {
            display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px;
        }
        .tarot-card-wrap { perspective: 600px; }
        .tarot-card {
            position: relative; width: 100%; padding-top: 160%;
            cursor: pointer; transform-style: preserve-3d;
            transition: transform 0.6s cubic-bezier(0.4,0,0.2,1);
        }
        .tarot-card.flipped { transform: rotateY(180deg); }
        .tarot-card.used { opacity: 0.5; pointer-events: none; }
        .tarot-face, .tarot-back {
            position: absolute; inset: 0;
            backface-visibility: hidden; border-radius: 10px; overflow: hidden;
        }
        /* Back side */
        .tarot-back {
            background: linear-gradient(145deg, #1e0535, #3b0764, #1e0535);
            border: 1px solid rgba(255,215,0,0.35);
            display: flex; flex-direction: column;
            align-items: center; justify-content: center; gap: 6px;
        }
        .tarot-back-pattern {
            position: absolute; inset: 4px; border-radius: 7px;
            border: 1px solid rgba(255,215,0,0.2);
            background: repeating-linear-gradient(
                45deg, rgba(255,215,0,0.03) 0px, rgba(255,215,0,0.03) 2px,
                transparent 2px, transparent 10px
            );
        }
        .tarot-back-icon { font-size: 26px; color: #fde68a; z-index: 1;
            filter: drop-shadow(0 0 6px rgba(255,215,0,0.8)); }
        .tarot-back-num { font-size: 10px; color: rgba(255,215,0,0.5); z-index: 1; }
        /* Front side */
        .tarot-face {
            background: linear-gradient(145deg, #f5f0ff, #ede9fe);
            border: 1px solid rgba(147,51,234,0.4);
            transform: rotateY(180deg);
            display: flex; flex-direction: column;
            align-items: center; justify-content: center;
            padding: 6px 4px; text-align: center;
        }
        .tarot-face-icon { font-size: 28px; margin-bottom: 4px; }
        .tarot-face-name { font-size: 9px; font-weight: 800;
            color: #3b0764; line-height: 1.2; margin-bottom: 3px; }
        .tarot-face-meaning { font-size: 8px; color: #6d28d9; line-height: 1.3; }
        .tarot-face-star { color: #f59e0b; font-size: 10px; margin-top: 3px; }

        /* --- Result Modal --- */
        .hora-result-overlay {
            display: none; position: fixed; inset: 0; z-index: 10000;
            background: rgba(0,0,0,0.75); align-items: center; justify-content: center;
            padding: 20px;
        }
        .hora-result-overlay.show { display: flex; }
        .hora-result-box {
            background: linear-gradient(145deg, #1e0535, #3b0764);
            border: 1px solid rgba(255,215,0,0.4);
            border-radius: 20px; padding: 28px 20px; max-width: 340px;
            width: 100%; text-align: center;
            box-shadow: 0 0 40px rgba(147,51,234,0.6);
        }
        .hora-result-icon { font-size: 52px; margin-bottom: 10px;
            filter: drop-shadow(0 0 10px rgba(255,215,0,0.8)); }
        .hora-result-card-name { font-size: 18px; font-weight: 800; color: #fde68a;
            margin-bottom: 6px; }
        .hora-result-divider { color: rgba(255,215,0,0.4); letter-spacing: 8px;
            font-size: 12px; margin: 8px 0; }
        .hora-result-text { font-size: 14px; color: #e9d5ff; line-height: 1.8; }
        .hora-result-close {
            margin-top: 18px; background: linear-gradient(135deg, #7c3aed, #c026d3);
            border: none; color: #fff; font-size: 14px; font-weight: 700;
            padding: 11px 30px; border-radius: 12px; cursor: pointer;
        }

        /* Stars bg animation */
        @keyframes twinkle { 0%,100% { opacity:0.3 } 50% { opacity:1 } }
        .hora-stars-bg {
            position: fixed; top: 0; left: 0; width: 100%; height: 100%;
            pointer-events: none; z-index: 0; overflow: hidden;
        }
        .hora-stars-bg span {
            position: absolute; color: rgba(255,215,0,0.4);
            font-size: 8px; animation: twinkle var(--d,3s) ease-in-out infinite;
            animation-delay: var(--delay,0s);
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hora-page">

    <!-- Stars Background -->
    <div class="hora-stars-bg" id="starsBg"></div>

    <!-- Header -->
    <div class="hora-header">
        <a href="<%= ResolveClientUrl("~/index.aspx") %>" class="hora-header-back">
            <i class="bi bi-chevron-left"></i>
        </a>
        <span class="hora-moon-icon">🌙</span>
        <h1 class="hora-title">SME มีดวง</h1>
        <p class="hora-subtitle">ดูดวงธุรกิจ • การเงิน • โชคชะตา</p>
        <span class="hora-date-badge" id="todayLabel"></span>
    </div>

    <!-- Section 1: Lucky Color -->
    <div class="hora-card" style="position:relative;z-index:1;">
        <div class="hora-card-title">
            <i class="bi bi-palette-fill" style="color:#f59e0b;"></i>
            สีมงคลด้านการเงินวันนี้
        </div>
        <div class="lucky-color-row" id="luckyColorRow"></div>
        <div class="hora-fortune-text" id="luckyColorFortune"></div>
    </div>

    <!-- Section 2: Phone Number Fortune -->
    <div class="hora-card" style="position:relative;z-index:1;">
        <div class="hora-card-title">
            <i class="bi bi-phone-fill" style="color:#a78bfa;"></i>
            ดูดวงจากเบอร์โทรศัพท์
        </div>
        <div class="phone-input-wrap">
            <i class="bi bi-telephone-fill"></i>
            <input type="tel" id="phoneInput" class="hora-input"
                   placeholder="กรอกเบอร์โทรศัพท์ของคุณ" maxlength="10"
                   oninput="this.value=this.value.replace(/[^0-9]/g,'')" />
        </div>
        <button class="hora-btn" onclick="readPhoneFortune()">
            <i class="bi bi-magic"></i> เปิดดวงชะตา
        </button>
        <div class="phone-result" id="phoneResult" style="margin-top:16px;">
            <div class="numerology-circle">
                <span class="numerology-number" id="phoneNumResult"></span>
                <span class="numerology-label">เลขชีวิต</span>
            </div>
            <span class="phone-fortune-stars" id="phoneStars"></span>
            <p class="phone-fortune-text" id="phoneFortuneText"></p>
        </div>
    </div>

    <!-- Section 3: Tarot Cards -->
    <div class="hora-card" style="position:relative;z-index:1;">
        <div class="hora-card-title">
            <i class="bi bi-suit-spade-fill" style="color:#c084fc;"></i>
            ไพ่ทาโรต์ประจำวัน
        </div>
        <p class="tarot-instruction">✨ เลือก 1 ใบ เพื่อรับพลังงานและคำทำนายประจำวันของคุณ ✨</p>
        <div class="tarot-grid" id="tarotGrid"></div>
    </div>

</div>

<!-- Tarot Result Overlay -->
<div class="hora-result-overlay" id="tarotResultOverlay">
    <div class="hora-result-box">
        <div class="hora-result-icon" id="resultIcon"></div>
        <div class="hora-result-card-name" id="resultCardName"></div>
        <div class="hora-result-divider">✦ ✧ ✦</div>
        <p class="hora-result-text" id="resultText"></p>
        <button class="hora-result-close" onclick="closeResult()">รับพลังงาน ✨</button>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
<script>
// ============================================================
// HORA - Fortune Page Script
// ============================================================

// --- Day data ---
var DAY_DATA = [
    { name: "วันอาทิตย์", colors: [
        { hex: "#dc2626", name: "แดง", emoji: "🔴", desc: "โชคลาภ อำนาจ", tag: "เงินทอง" },
        { hex: "#f97316", name: "ส้ม", emoji: "🟠", desc: "พลังงาน ความสำเร็จ", tag: "ธุรกิจ" }
    ], fortune: "วันนี้พลังงานสีแดงเสริมความกล้า เหมาะกับการตัดสินใจเรื่องการลงทุนและการขยายธุรกิจ ดวงการเงินอยู่ในเกณฑ์ดี ระวังรายจ่ายที่ไม่จำเป็น" },
    { name: "วันจันทร์", colors: [
        { hex: "#f59e0b", name: "เหลือง", emoji: "🟡", desc: "ปัญญา ความมั่งคั่ง", tag: "โชคลาภ" },
        { hex: "#fbbf24", name: "ครีม", emoji: "🌕", desc: "ความสงบ ราบรื่น", tag: "การงาน" }
    ], fortune: "สีเหลืองทองเป็นสีแห่งความมั่งคั่งในวันจันทร์ เหมาะกับการเจรจาธุรกิจและการขอสินเชื่อ ดวงดีในเรื่องเอกสารและสัญญา" },
    { name: "วันอังคาร", colors: [
        { hex: "#ec4899", name: "ชมพู", emoji: "🩷", desc: "ความรัก ความสัมพันธ์", tag: "มนุษยสัมพันธ์" },
        { hex: "#a855f7", name: "ม่วง", emoji: "🟣", desc: "สัญชาตญาณ ลึกลับ", tag: "ไหวพริบ" }
    ], fortune: "สีชมพูและม่วงเสริมพลังการเจรจาและความสัมพันธ์ทางธุรกิจ วันนี้เหมาะกับการพบปะพาร์ทเนอร์ใหม่ๆ หรือขยายเครือข่าย SME" },
    { name: "วันพุธ", colors: [
        { hex: "#16a34a", name: "เขียว", emoji: "🟢", desc: "เจริญเติบโต มั่นคง", tag: "การเงิน" },
        { hex: "#84cc16", name: "เขียวอ่อน", emoji: "💚", desc: "ความสดใส สุขภาพดี", tag: "โชคดี" }
    ], fortune: "เขียวคือสีแห่งความเจริญรุ่งเรืองในวันพุธ เหมาะกับการออมเงิน ลงทุนระยะยาว และขยายสาขาธุรกิจ ดวงการเงินมาแรง" },
    { name: "วันพฤหัสบดี", colors: [
        { hex: "#f97316", name: "ส้ม", emoji: "🟠", desc: "พลัง ความกล้า", tag: "ความสำเร็จ" },
        { hex: "#fde68a", name: "ทอง", emoji: "✨", desc: "ความมั่งคั่ง สิริมงคล", tag: "โชคลาภ" }
    ], fortune: "สีส้มทองวันพฤหัสฯ เสริมโชคลาภและความก้าวหน้า เหมาะกับการยื่นเรื่องขอสินเชื่อ หรือลงนามสัญญาสำคัญ ดวงธุรกิจดีมาก" },
    { name: "วันศุกร์", colors: [
        { hex: "#3b82f6", name: "ฟ้า", emoji: "🔵", desc: "สันติ ความไว้วางใจ", tag: "การค้า" },
        { hex: "#06b6d4", name: "ฟ้าอมเขียว", emoji: "💎", desc: "ความคิดสร้างสรรค์", tag: "นวัตกรรม" }
    ], fortune: "วันศุกร์สีฟ้าเสริมความน่าเชื่อถือและความไว้วางใจ เหมาะกับการนำเสนองานหรือพรีเซนต์ธุรกิจ ดวงการเจรจาดีเยี่ยม" },
    { name: "วันเสาร์", colors: [
        { hex: "#7c3aed", name: "ม่วงเข้ม", emoji: "🟣", desc: "อำนาจ ศักดิ์ศรี", tag: "ความมั่งคั่ง" },
        { hex: "#1e1b4b", name: "กรมท่า", emoji: "💜", desc: "ลึกลับ ปัญญา", tag: "วิสัยทัศน์" }
    ], fortune: "สีม่วงและกรมท่าในวันเสาร์เสริมพลังแห่งปัญญาและวิสัยทัศน์ เหมาะกับการวางแผนกลยุทธ์ธุรกิจระยะยาว หรือการฝึกอบรมพัฒนาตนเอง" }
];

// --- Numerology data ---
var NUMEROLOGY = {
    1: { stars: "★★★★★", text: "เลข 1 คือพลังแห่งผู้นำ คุณมีความสามารถในการบริหารและตัดสินใจที่แข็งแกร่ง ธุรกิจของคุณมีแนวโน้มเติบโตด้วยความมุ่งมั่นของตัวเอง การเงินมีทิศทางที่ดีหากคุณเป็นคนริเริ่มก่อน" },
    2: { stars: "★★★★☆", text: "เลข 2 คือพลังแห่งความร่วมมือ คุณเหมาะกับการทำธุรกิจแบบพาร์ทเนอร์ หรือการร่วมลงทุน ดวงการเงินดีจากความสัมพันธ์ที่ดีกับผู้อื่น อย่าตัดสินใจใหญ่คนเดียว" },
    3: { stars: "★★★★★", text: "เลข 3 คือพลังแห่งความสร้างสรรค์และการสื่อสาร คุณโดดเด่นด้านการตลาดและการนำเสนอ ธุรกิจดิจิทัลหรือสื่อสิ่งพิมพ์เหมาะกับคุณมาก ดวงการเงินดีจากทักษะการสื่อสาร" },
    4: { stars: "★★★☆☆", text: "เลข 4 คือพลังแห่งความมั่นคงและระเบียบ คุณเหมาะกับธุรกิจที่มีโครงสร้างชัดเจน ดวงการเงินมั่นคงแต่ช้า ต้องอดทนและวางแผนอย่างรอบคอบ" },
    5: { stars: "★★★★☆", text: "เลข 5 คือพลังแห่งการเปลี่ยนแปลงและอิสรภาพ คุณเหมาะกับธุรกิจที่ยืดหยุ่น เช่น ค้าขาย ท่องเที่ยว หรือที่ปรึกษา ดวงโชคลาภมาแบบไม่คาดฝัน" },
    6: { stars: "★★★★☆", text: "เลข 6 คือพลังแห่งความรับผิดชอบและการบริการ คุณเหมาะกับธุรกิจที่ดูแลผู้อื่น เช่น อาหาร สุขภาพ หรือการศึกษา ดวงการเงินดีจากความไว้วางใจของลูกค้า" },
    7: { stars: "★★★★☆", text: "เลข 7 คือพลังแห่งปัญญาและการวิเคราะห์ คุณเหมาะกับธุรกิจที่ใช้ความรู้เชิงลึก เช่น เทคโนโลยี กฎหมาย หรือการวิจัย ดวงการเงินดีจากความเชี่ยวชาญ" },
    8: { stars: "★★★★★", text: "เลข 8 คือพลังแห่งอำนาจและความมั่งคั่ง นี่คือตัวเลขนักธุรกิจแท้ๆ คุณมีพลังในการสะสมความมั่งคั่งและสร้างอาณาจักรธุรกิจ ดวงการเงินดีเยี่ยม" },
    9: { stars: "★★★★☆", text: "เลข 9 คือพลังแห่งความสมบูรณ์และมนุษยธรรม คุณเหมาะกับธุรกิจเพื่อสังคม หรือธุรกิจที่ช่วยเหลือผู้อื่น ดวงการเงินดีจากการแบ่งปันและการสร้างคุณค่า" }
};

// --- Tarot cards data ---
var TAROT_CARDS = [
    { emoji: "⭐", name: "The Star\nดวงดาว", meaning: "ความหวัง โชคลาภ พรหมลิขิต", detail: "ดวงดาวส่องแสงให้คุณ! วันนี้โชคชะตาเปิดทางให้ธุรกิจของคุณ มีโอกาสใหม่ที่กำลังจะเข้ามา จงมีความหวังและมองโลกในแง่ดี ดวงการเงินดีเยี่ยม อาจได้รับข่าวดีเรื่องสินเชื่อหรือการลงทุน" },
    { emoji: "☀️", name: "The Sun\nดวงอาทิตย์", meaning: "ความสำเร็จ ความสุข ชัยชนะ", detail: "พลังอาทิตย์เปล่งแสงให้คุณเด่นชัด! ธุรกิจกำลังเจริญรุ่งเรือง ลูกค้าให้ความไว้วางใจ รายได้มีแนวโน้มเพิ่มขึ้น เป็นวันที่เหมาะกับการตัดสินใจสำคัญและการลงนามสัญญา" },
    { emoji: "🌙", name: "The Moon\nดวงจันทร์", meaning: "ญาณทิพย์ ความลึกซึ้ง", detail: "ดวงจันทร์บอกให้คุณหยุดฟังเสียงภายใน มีบางอย่างที่ยังไม่ชัดเจนในธุรกิจ อย่าเพิ่งตัดสินใจใหญ่โดยขาดข้อมูล รอให้สถานการณ์ชัดขึ้นก่อน แต่ดวงการเงินยังคงสม่ำเสมอ" },
    { emoji: "🌍", name: "The World\nโลกกว้าง", meaning: "ความสมบูรณ์ ชัยชนะสูงสุด", detail: "คุณกำลังจะบรรลุเป้าหมายสำคัญ! ธุรกิจที่ลงทุนไปกำลังออกดอกออกผล การขยายตลาดหรือเปิดสาขาใหม่มีแนวโน้มสำเร็จ ดวงการเงินดีมาก โชคลาภมาจากทุกทิศทาง" },
    { emoji: "☸️", name: "The Wheel\nวงล้อแห่งโชคชะตา", meaning: "การเปลี่ยนแปลง โชคชะตา วนเวียน", detail: "วงล้อแห่งโชคชะตากำลังหมุน การเปลี่ยนแปลงครั้งสำคัญกำลังมา อาจเป็นโอกาสใหม่หรือความท้าทายใหม่ จงยืดหยุ่นและพร้อมรับมือ ดวงโชคลาภมาแบบไม่คาดฝัน" },
    { emoji: "👑", name: "The Emperor\nจักรพรรดิ", meaning: "อำนาจ ความมั่นคง โครงสร้าง", detail: "พลังจักรพรรดิอยู่ในมือคุณ! คุณมีอำนาจและความสามารถในการควบคุมทิศทางธุรกิจ เหมาะกับการวางโครงสร้างองค์กรและการบริหารทีม ดวงการเงินมั่นคงและแข็งแกร่ง" },
    { emoji: "🔮", name: "The High Priestess\nนักบวชหญิง", meaning: "ปัญญา ความลึกลับ สัญชาตญาณ", detail: "ปัญญาลึกลับนำทางคุณ วันนี้จงเชื่อสัญชาตญาณ มีข้อมูลสำคัญที่ยังซ่อนอยู่ ควรศึกษาข้อมูลให้ลึกก่อนตัดสินใจลงทุน ดวงการเงินดีหากคุณใช้ปัญญา" },
    { emoji: "🪄", name: "The Magician\nจอมเวทย์", meaning: "ความสามารถ พลังงาน ความเชี่ยวชาญ", detail: "คุณมีทุกอย่างที่จำเป็นสำหรับความสำเร็จ! ทักษะ ความรู้ และพลังงานพร้อมแล้ว ถึงเวลาลงมือทำโปรเจกต์ที่รอคอย ดวงการเงินดีเยี่ยมสำหรับผู้ที่กล้าลงมือ" }
];

// ============================================================
// Init
// ============================================================
document.addEventListener("DOMContentLoaded", function () {
    renderStars();
    renderTodayLabel();
    renderLuckyColor();
    renderTarotGrid();
});

function renderStars() {
    var bg = document.getElementById("starsBg");
    var positions = [
        [8,5],[20,15],[35,8],[55,12],[70,3],[85,18],[92,8],
        [15,25],[45,30],[75,22],[5,40],[25,45],[60,38],[80,42],[95,35],
        [10,55],[30,60],[50,52],[65,65],[90,58],[3,70],[22,75],[42,68],
        [68,72],[88,78],[12,85],[38,82],[58,88],[78,83],[95,90]
    ];
    var html = "";
    positions.forEach(function(p, i) {
        var d = (2 + (i % 5)) + "s";
        var del = (i * 0.2 % 3) + "s";
        html += '<span style="left:' + p[0] + '%;top:' + p[1] + '%;--d:' + d + ';--delay:' + del + '">' + (i % 3 === 0 ? "✦" : i % 3 === 1 ? "✧" : "★") + '</span>';
    });
    bg.innerHTML = html;
}

function renderTodayLabel() {
    var days = ["อาทิตย์","จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์"];
    var months = ["ม.ค.","ก.พ.","มี.ค.","เม.ย.","พ.ค.","มิ.ย.","ก.ค.","ส.ค.","ก.ย.","ต.ค.","พ.ย.","ธ.ค."];
    var d = new Date();
    var label = "วัน" + days[d.getDay()] + " ที่ " + d.getDate() + " " + months[d.getMonth()] + " " + (d.getFullYear() + 543);
    document.getElementById("todayLabel").textContent = label;
}

function renderLuckyColor() {
    var day = new Date().getDay();
    var data = DAY_DATA[day];
    var row = document.getElementById("luckyColorRow");
    var html = "";
    data.colors.forEach(function(c) {
        html += '<div class="lucky-color-item">' +
            '<div class="lucky-color-swatch" style="background:' + c.hex + ';">' + c.emoji + '</div>' +
            '<div class="lucky-color-info">' +
                '<div class="lucky-color-name">สี' + c.name + '</div>' +
                '<div class="lucky-color-desc">' + c.desc + '</div>' +
                '<span class="lucky-color-tag">' + c.tag + '</span>' +
            '</div>' +
        '</div>';
    });
    row.innerHTML = html;
    document.getElementById("luckyColorFortune").textContent = "✦ " + data.fortune;
}

function renderTarotGrid() {
    var grid = document.getElementById("tarotGrid");
    var html = "";
    var shuffled = TAROT_CARDS.slice().sort(function() { return Math.random() - 0.5; });
    shuffled.forEach(function(card, i) {
        html += '<div class="tarot-card-wrap"><div class="tarot-card" id="tarotCard' + i + '" onclick="flipTarot(this,' + i + ')">' +
            '<div class="tarot-back">' +
                '<div class="tarot-back-pattern"></div>' +
                '<span class="tarot-back-icon">🌙</span>' +
                '<span class="tarot-back-num">ใบที่ ' + (i + 1) + '</span>' +
            '</div>' +
            '<div class="tarot-face">' +
                '<div class="tarot-face-icon">' + card.emoji + '</div>' +
                '<div class="tarot-face-name">' + card.name.replace("\n","<br>") + '</div>' +
                '<div class="tarot-face-meaning">' + card.meaning + '</div>' +
                '<div class="tarot-face-star">✦ ✦ ✦</div>' +
            '</div>' +
        '</div></div>';
    });
    grid.innerHTML = html;
    window._shuffledTarot = shuffled;
}

var tarotPicked = false;
function flipTarot(el, idx) {
    if (tarotPicked) return;
    tarotPicked = true;
    el.classList.add("flipped");
    setTimeout(function() { showTarotResult(idx); }, 700);
    // Grey out other cards
    setTimeout(function() {
        var all = document.querySelectorAll(".tarot-card");
        all.forEach(function(c, i) { if (i !== idx) c.classList.add("used"); });
    }, 200);
}

function showTarotResult(idx) {
    var card = window._shuffledTarot[idx];
    document.getElementById("resultIcon").textContent = card.emoji;
    document.getElementById("resultCardName").textContent = card.name.replace("\n"," — ");
    document.getElementById("resultText").textContent = card.detail;
    document.getElementById("tarotResultOverlay").classList.add("show");
}

function closeResult() {
    document.getElementById("tarotResultOverlay").classList.remove("show");
}

// --- Phone numerology ---
function readPhoneFortune() {
    var phone = document.getElementById("phoneInput").value.replace(/\D/g, "");
    if (phone.length < 9) {
        alert("กรุณากรอกเบอร์โทรศัพท์ให้ครบถ้วน");
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
    document.getElementById("phoneStars").textContent = data.stars;
    document.getElementById("phoneFortuneText").textContent = data.text;
    var result = document.getElementById("phoneResult");
    result.style.display = "block";
    result.scrollIntoView({ behavior: "smooth", block: "nearest" });
}
</script>
</asp:Content>
