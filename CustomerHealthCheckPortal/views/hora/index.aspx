<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.hora.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>SME มีดวง - ดูดวงธุรกิจฟรี</title>
    <style>
        /* ========== HORA PAGE ========== */
        .hora-page { background-color: whitesmoke; min-height: 100vh; padding-bottom: 80px; }

        /* --- Header icon twinkling --- */
        @keyframes icon-twinkle {
            0%, 100% { opacity: 0.85; transform: scale(1);    filter: drop-shadow(0 0 6px rgba(251,191,36,0.55)); }
            50%       { opacity: 1;    transform: scale(1.10); filter: drop-shadow(0 0 18px rgba(251,191,36,1)); }
        }
        .hora-header { padding: 10px 16px 20px; text-align: center; position: relative; }
        .hora-header-icon {
            font-size: 72px; display: block; margin-bottom: 6px;
            color: #f59e0b;
            animation: icon-twinkle 2.2s ease-in-out infinite;
        }
        .hora-title    { font-size: 22px; font-weight: 800; color: darkblue; margin: 0; }
        .hora-subtitle { font-size: 13px; color: darkblue; margin-top: 4px; }
        .hora-date-badge {
            display: inline-block; margin-top: 10px;
            background: #e8f0fe; border: 1px solid #1344a0;
            color: #1344a0; font-size: 12px; font-weight: 600;
            padding: 4px 14px; border-radius: 20px;
        }

        /* --- Cards --- */
        .hora-card {
            background: #fff; border-radius: 16px;
            margin: 0 16px 16px; padding: 18px 16px;
            box-shadow: 0 2px 12px rgba(0,0,0,0.08);
        }
        .hora-card-title {
            font-size: 15px; font-weight: 700; color: #0a2463;
            display: flex; align-items: center; gap: 8px;
            margin-bottom: 14px; padding-bottom: 10px;
            border-bottom: 2px solid #e8f0fe;
        }
        .hora-card-title i { font-size: 20px; color: #1344a0; }

        /* --- Lucky Color (smaller) --- */
        .lucky-color-row { display: flex; gap: 10px; }
        .lucky-color-item { flex: 1; border-radius: 10px; overflow: hidden; border: 1px solid #e8f0fe; }
        .lucky-color-swatch {
            height: 54px; display: flex; align-items: center; justify-content: center;
        }
        .lucky-color-swatch i { font-size: 22px; color: rgba(255,255,255,0.85); }
        .lucky-color-info { background: #f8faff; padding: 6px 8px; }
        .lucky-color-name { font-size: 12px; font-weight: 700; color: #0a2463; }
        .lucky-color-desc { font-size: 10px; color: #5a6b8a; margin-top: 1px; }
        .lucky-color-tag {
            display: inline-block; font-size: 9px; font-weight: 700;
            padding: 1px 6px; border-radius: 8px; margin-top: 3px;
            background: #e8f0fe; color: #1344a0;
        }
        .hora-fortune-text {
            background: #f0f6ff; border-left: 3px solid #1344a0;
            border-radius: 0 8px 8px 0; padding: 10px 12px; margin-top: 12px;
            font-size: 13px; color: #334155; line-height: 1.7;
        }

        /* --- Tabs --- */
        .hora-tabs {
            display: flex; gap: 0; margin-bottom: 16px;
            background: #f0f6ff; border-radius: 10px; padding: 4px;
        }
        .hora-tab {
            flex: 1; border: none; background: transparent;
            color: #5a6b8a; font-size: 13px; font-weight: 600;
            padding: 9px 6px; border-radius: 7px; cursor: pointer;
            transition: all 0.2s; display: flex; align-items: center;
            justify-content: center; gap: 5px;
        }
        .hora-tab.active {
            background: #fff; color: #0a2463;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
        }
        .hora-tab i { font-size: 14px; }
        .hora-tab-content { display: none; }
        .hora-tab-content.active { display: block; }

        /* --- Phone fortune --- */
        .phone-input-wrap { position: relative; }
        .phone-input-wrap > i {
            position: absolute; left: 12px; top: 50%; transform: translateY(-50%);
            color: #1344a0; font-size: 18px; pointer-events: none;
        }
        .hora-input {
            width: 100%; background: #f8faff; border: 1px solid #c7d8f7;
            color: #0a2463; border-radius: 12px; padding: 12px 12px 12px 42px;
            font-size: 16px; outline: none; box-sizing: border-box;
        }
        .hora-input::placeholder { color: #a0aec0; }
        .hora-input:focus { border-color: #1344a0; box-shadow: 0 0 0 3px rgba(19,68,160,0.12); }

        /* Gold button */
        .hora-btn-gold {
            width: 100%; margin-top: 10px; border: none; cursor: pointer;
            background: linear-gradient(135deg, #b45309, #d97706, #f59e0b, #fbbf24);
            color: #fff; font-size: 15px; font-weight: 700;
            padding: 13px; border-radius: 12px;
            box-shadow: 0 4px 14px rgba(217,119,6,0.4);
            transition: opacity 0.2s;
        }
        .hora-btn-gold:active { opacity: 0.85; }
        .hora-btn-gold i { margin-right: 6px; }

        .phone-result { display: none; }
        .numerology-circle {
            width: 76px; height: 76px; border-radius: 50%;
            background: linear-gradient(135deg, #0a2463, #1a6fdd);
            display: flex; flex-direction: column; align-items: center;
            justify-content: center; margin: 0 auto 12px;
            box-shadow: 0 4px 16px rgba(19,68,160,0.4);
        }
        .numerology-number { font-size: 32px; font-weight: 900; color: #fff; line-height: 1; }
        .numerology-label  { font-size: 9px; color: rgba(255,255,255,0.8); }
        .phone-fortune-stars { color: #d97706; font-size: 18px; display: block; text-align: center; margin: 8px 0; }
        .phone-fortune-text  { text-align: center; font-size: 14px; color: #334155; line-height: 1.75; padding: 0 8px; }

        /* --- Tarot --- */
        .tarot-instruction {
            font-size: 12px; color: #5a6b8a; text-align: center;
            background: #f0f6ff; border-radius: 8px; padding: 8px 10px; margin-bottom: 14px;
        }
        .tarot-grid { display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px; }
        .tarot-card-wrap { perspective: 600px; }
        .tarot-card {
            position: relative; width: 100%; padding-top: 155%;
            cursor: pointer; transform-style: preserve-3d;
            transition: transform 0.6s cubic-bezier(0.4,0,0.2,1);
        }
        .tarot-card.flipped { transform: rotateY(180deg); }
        .tarot-card.used    { opacity: 0.4; pointer-events: none; }
        .tarot-face, .tarot-back {
            position: absolute; inset: 0;
            backface-visibility: hidden; border-radius: 10px; overflow: hidden;
        }
        .tarot-back {
            background: linear-gradient(145deg, #0a2463, #1344a0, #0a2463);
            border: 2px solid rgba(255,255,255,0.2);
            display: flex; flex-direction: column; align-items: center; justify-content: center; gap: 6px;
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
        .tarot-back-num  { font-size: 9px; color: rgba(255,255,255,0.6); z-index: 1; }
        .tarot-face {
            background: linear-gradient(145deg, #f0f6ff, #e8f0fe);
            border: 2px solid #c7d8f7; transform: rotateY(180deg);
            display: flex; flex-direction: column; align-items: center;
            justify-content: center; padding: 6px 4px; text-align: center;
        }
        .tarot-face-icon    { font-size: 26px; margin-bottom: 3px; }
        .tarot-face-name    { font-size: 8px; font-weight: 800; color: #0a2463; line-height: 1.3; margin-bottom: 2px; }
        .tarot-face-meaning { font-size: 7px; color: #1344a0; line-height: 1.3; }
        .tarot-face-star    { color: #1344a0; font-size: 9px; margin-top: 3px; }

        /* --- Result Modal --- */
        .hora-result-overlay {
            display: none; position: fixed; inset: 0; z-index: 10000;
            background: rgba(0,0,0,0.6); align-items: center; justify-content: center; padding: 20px;
        }
        .hora-result-overlay.show { display: flex; }
        .hora-result-box {
            background: #fff; border: 2px solid #c7d8f7;
            border-radius: 20px; padding: 28px 20px; max-width: 340px;
            width: 100%; text-align: center; box-shadow: 0 8px 40px rgba(19,68,160,0.25);
        }
        .hora-result-icon      { font-size: 52px; margin-bottom: 10px; }
        .hora-result-card-name { font-size: 18px; font-weight: 800; color: #0a2463; margin-bottom: 6px; }
        .hora-result-divider   { color: #c7d8f7; letter-spacing: 8px; font-size: 14px; margin: 8px 0; }
        .hora-result-text      { font-size: 14px; color: #334155; line-height: 1.8; text-align: left; }
        /* Gold close button */
        .hora-result-close {
            margin-top: 18px; border: none; cursor: pointer;
            background: linear-gradient(135deg, #b45309, #d97706, #f59e0b, #fbbf24);
            color: #fff; font-size: 14px; font-weight: 700;
            padding: 11px 30px; border-radius: 12px;
            box-shadow: 0 4px 12px rgba(217,119,6,0.35);
            transition: opacity 0.2s;
        }
        .hora-result-close:active { opacity: 0.85; }
        /* Reset button */
        .hora-btn-reset {
            width: 100%; margin-top: 10px; border: 2px solid #d97706; cursor: pointer;
            background: #fff; color: #b45309; font-size: 14px; font-weight: 700;
            padding: 10px; border-radius: 12px; transition: all 0.2s;
            display: flex; align-items: center; justify-content: center; gap: 6px;
        }
        .hora-btn-reset:active { background: #fef3c7; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hora-page">

    <!-- Back button -->
    <div class="pt-3">
        <div class="page-title d-flex">
            <div class="align-self-center">
                <a href="#" onclick="redirectToMain()"
                   class="me-3 ms-0 icon icon-xxs bg-theme rounded-s shadow-m">
                    <i class="bi bi-chevron-left color-theme font-14"></i>
                </a>
            </div>
            <div class="align-self-center me-auto">
                <h1 class="color-theme mb-0 font-18">ย้อนกลับ</h1>
            </div>
        </div>
    </div>

    <!-- Header SVG wave -->
    <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg"
         class="transition duration-300 ease-in-out delay-150">
        <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92,134 185,148 287,148 C 389,148 501,135 592,129 C 683,123 751,123 848,115 C 945,107 1069,91 1172,91 C 1275,91 1358,105 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
        <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 99,258 198,276 278,282 C 358,288 419,281 524,265 C 629,249 777,225 888,211 C 999,197 1071,192 1157,198 C 1243,204 1341,222 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
        <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65,340 131,319 245,321 C 359,323 522,347 616,352 C 710,357 735,342 822,333 C 909,324 1057,320 1170,325 C 1283,330 1362,345 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
        <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 71,495 142,510 239,499 C 336,488 460,452 567,446 C 674,440 766,466 862,465 C 958,464 1060,437 1157,435 C 1254,433 1347,457 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
    </svg>

    <!-- Header -->
    <div class="hora-header">
        <i class="bi bi-stars hora-header-icon"></i>
        <h1 class="hora-title">SME มีดวง</h1>
        <p class="hora-subtitle">ดูดวงธุรกิจ &bull; การเงิน &bull; โชคชะตา</p>
        <span class="hora-date-badge" id="todayLabel">กำลังโหลด...</span>
    </div>

    <!-- Section 1: สีมงคลการเงิน -->
    <div class="hora-card">
        <div class="hora-card-title">
            <i class="bi bi-palette-fill"></i>
            สีมงคลด้านการเงินวันนี้
        </div>
        <div class="lucky-color-row" id="luckyColorRow"></div>
        <div class="hora-fortune-text" id="luckyColorFortune"></div>
    </div>

    <!-- Section 2+3: Tabs — ดูดวงเบอร์ + ไพ่ทาโรต์ -->
    <div class="hora-card">
        <div class="hora-tabs">
            <button type="button" class="hora-tab active" id="tab-btn-phone" onclick="switchTab('phone')">
                <i class="bi bi-telephone-fill"></i> ดูดวงเบอร์โทร
            </button>
            <button type="button" class="hora-tab" id="tab-btn-tarot" onclick="switchTab('tarot')">
                <i class="bi bi-layers-fill"></i> ไพ่ทาโรต์
            </button>
        </div>

        <!-- Tab: Phone -->
        <div class="hora-tab-content active" id="tab-phone">
            <div class="hora-card-title" style="margin-top:0;">
                <i class="bi bi-telephone-fill"></i>
                ดูดวงจากเบอร์โทรศัพท์
            </div>
            <div class="phone-input-wrap">
                <i class="bi bi-telephone"></i>
                <input type="tel" id="phoneInput" class="hora-input"
                       placeholder="กรอกเบอร์โทรศัพท์ของคุณ" maxlength="10"
                       oninput="this.value=this.value.replace(/[^0-9]/g,'')" />
            </div>
            <button type="button" class="hora-btn-gold" onclick="readPhoneFortune()">
                <i class="bi bi-search"></i> เปิดดวงชะตา
            </button>
            <div class="phone-result" id="phoneResult"
                 style="margin-top:16px; padding-top:14px; border-top:1px solid #e8f0fe;">
                <div class="numerology-circle">
                    <span class="numerology-number" id="phoneNumResult"></span>
                    <span class="numerology-label">เลขชีวิต</span>
                </div>
                <span class="phone-fortune-stars" id="phoneStars"></span>
                <p class="phone-fortune-text" id="phoneFortuneText"></p>
                <button type="button" class="hora-btn-reset" onclick="resetPhone()" style="margin-top:14px;">
                    <i class="bi bi-arrow-counterclockwise"></i> ดูดวงเบอร์อื่น
                </button>
            </div>
        </div>

        <!-- Tab: Tarot -->
        <div class="hora-tab-content" id="tab-tarot">
            <div class="hora-card-title" style="margin-top:0;">
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

</div>

<!-- Tarot Result Modal -->
<div class="hora-result-overlay" id="tarotResultOverlay">
    <div class="hora-result-box">
        <div class="hora-result-icon" id="resultIcon"></div>
        <div class="hora-result-card-name" id="resultCardName"></div>
        <div class="hora-result-divider">- - -</div>
        <p class="hora-result-text" id="resultText"></p>
        <div style="display:flex; gap:10px; justify-content:center; flex-wrap:wrap;">
            <button type="button" class="hora-result-close" onclick="closeResult()">
                <i class="bi bi-check2-circle"></i> รับพลังงาน
            </button>
            <button type="button" class="hora-btn-reset" onclick="resetTarot()" style="width:auto; padding:10px 20px;">
                <i class="bi bi-arrow-counterclockwise"></i> เปิดไพ่ใหม่
            </button>
        </div>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
<script>
// HORA - Fortune Page

var DAY_DATA = [
    { name: "วันอาทิตย์",
      colors: [
          { hex: "#dc2626", name: "สีแดง",   icon: "bi-droplet-fill",    desc: "โชคลาภ อำนาจ",          tag: "เงินทอง" },
          { hex: "#f97316", name: "สีส้ม",    icon: "bi-brightness-high", desc: "พลังงาน ความสำเร็จ",    tag: "ธุรกิจ" }
      ],
      fortune: "วันนี้พลังงานสีแดงเสริมความกล้า เหมาะกับการตัดสินใจเรื่องการลงทุนและการขยายธุรกิจ ดวงการเงินอยู่ในเกณฑ์ดี ระวังรายจ่ายที่ไม่จำเป็น"
    },
    { name: "วันจันทร์",
      colors: [
          { hex: "#f59e0b", name: "สีเหลือง", icon: "bi-sun-fill",        desc: "ปัญญา ความมั่งคั่ง",    tag: "โชคลาภ" },
          { hex: "#fbbf24", name: "สีครีม",   icon: "bi-circle-half",     desc: "ความสงบ ราบรื่น",       tag: "การงาน" }
      ],
      fortune: "สีเหลืองทองเป็นสีแห่งความมั่งคั่งในวันจันทร์ เหมาะกับการเจรจาธุรกิจและการขอสินเชื่อ ดวงดีในเรื่องเอกสารและสัญญา"
    },
    { name: "วันอังคาร",
      colors: [
          { hex: "#ec4899", name: "สีชมพู",   icon: "bi-heart-fill",      desc: "ความรัก ความสัมพันธ์",  tag: "มนุษยสัมพันธ์" },
          { hex: "#a855f7", name: "สีม่วง",   icon: "bi-gem",             desc: "สัญชาตญาณ ไหวพริบ",    tag: "ไหวพริบ" }
      ],
      fortune: "สีชมพูและม่วงเสริมพลังการเจรจาและความสัมพันธ์ทางธุรกิจ วันนี้เหมาะกับการพบปะพาร์ทเนอร์ใหม่ หรือขยายเครือข่าย SME"
    },
    { name: "วันพุธ",
      colors: [
          { hex: "#16a34a", name: "สีเขียว",   icon: "bi-tree-fill",      desc: "เจริญเติบโต มั่นคง",   tag: "การเงิน" },
          { hex: "#84cc16", name: "เขียวอ่อน", icon: "bi-flower1",        desc: "ความสดใส สุขภาพดี",    tag: "โชคดี" }
      ],
      fortune: "สีเขียวคือสีแห่งความเจริญรุ่งเรืองในวันพุธ เหมาะกับการออมเงิน ลงทุนระยะยาว และขยายสาขาธุรกิจ ดวงการเงินมาแรง"
    },
    { name: "วันพฤหัสบดี",
      colors: [
          { hex: "#f97316", name: "สีส้ม",  icon: "bi-fire",              desc: "พลัง ความกล้า",         tag: "ความสำเร็จ" },
          { hex: "#d97706", name: "สีทอง",  icon: "bi-stars",             desc: "ความมั่งคั่ง สิริมงคล", tag: "โชคลาภ" }
      ],
      fortune: "สีส้มทองวันพฤหัสเสริมโชคลาภและความก้าวหน้า เหมาะกับการยื่นเรื่องขอสินเชื่อ หรือลงนามสัญญาสำคัญ ดวงธุรกิจดีมาก"
    },
    { name: "วันศุกร์",
      colors: [
          { hex: "#3b82f6", name: "สีฟ้า",      icon: "bi-water",         desc: "สันติ ความไว้วางใจ",    tag: "การค้า" },
          { hex: "#06b6d4", name: "ฟ้าอมเขียว", icon: "bi-wind",          desc: "ความคิดสร้างสรรค์",     tag: "นวัตกรรม" }
      ],
      fortune: "วันศุกร์สีฟ้าเสริมความน่าเชื่อถือและความไว้วางใจ เหมาะกับการนำเสนองานหรือพรีเซนต์ธุรกิจ ดวงการเจรจาดีเยี่ยม"
    },
    { name: "วันเสาร์",
      colors: [
          { hex: "#7c3aed", name: "ม่วงเข้ม",  icon: "bi-moon-stars-fill", desc: "อำนาจ ศักดิ์ศรี",    tag: "ความมั่งคั่ง" },
          { hex: "#1e3a8a", name: "สีกรมท่า",  icon: "bi-shield-fill",     desc: "ลึกลับ ปัญญา",       tag: "วิสัยทัศน์" }
      ],
      fortune: "สีม่วงและกรมท่าในวันเสาร์เสริมพลังแห่งปัญญาและวิสัยทัศน์ เหมาะกับการวางแผนกลยุทธ์ธุรกิจระยะยาว หรือการฝึกอบรมพัฒนาตนเอง"
    }
];

var NUMEROLOGY = {
    1: { stars:5, text:"เลข 1 คือพลังแห่งผู้นำ คุณมีความสามารถในการบริหารและตัดสินใจที่แข็งแกร่ง ธุรกิจของคุณมีแนวโน้มเติบโตด้วยความมุ่งมั่นของตัวเอง การเงินมีทิศทางที่ดีหากคุณเป็นคนริเริ่มก่อน" },
    2: { stars:4, text:"เลข 2 คือพลังแห่งความร่วมมือ คุณเหมาะกับการทำธุรกิจแบบพาร์ทเนอร์ หรือการร่วมลงทุน ดวงการเงินดีจากความสัมพันธ์ที่ดีกับผู้อื่น อย่าตัดสินใจใหญ่คนเดียว" },
    3: { stars:5, text:"เลข 3 คือพลังแห่งความสร้างสรรค์และการสื่อสาร คุณโดดเด่นด้านการตลาดและการนำเสนอ ธุรกิจดิจิทัลหรือสื่อสิ่งพิมพ์เหมาะกับคุณมาก ดวงการเงินดีจากทักษะการสื่อสาร" },
    4: { stars:3, text:"เลข 4 คือพลังแห่งความมั่นคงและระเบียบ คุณเหมาะกับธุรกิจที่มีโครงสร้างชัดเจน ดวงการเงินมั่นคงแต่ค่อยเป็นค่อยไป ต้องอดทนและวางแผนอย่างรอบคอบ" },
    5: { stars:4, text:"เลข 5 คือพลังแห่งการเปลี่ยนแปลงและอิสรภาพ คุณเหมาะกับธุรกิจที่ยืดหยุ่น เช่น ค้าขาย ท่องเที่ยว หรือที่ปรึกษา ดวงโชคลาภมาแบบไม่คาดฝัน" },
    6: { stars:4, text:"เลข 6 คือพลังแห่งความรับผิดชอบและการบริการ คุณเหมาะกับธุรกิจที่ดูแลผู้อื่น เช่น อาหาร สุขภาพ หรือการศึกษา ดวงการเงินดีจากความไว้วางใจของลูกค้า" },
    7: { stars:4, text:"เลข 7 คือพลังแห่งปัญญาและการวิเคราะห์ คุณเหมาะกับธุรกิจที่ใช้ความรู้เชิงลึก เช่น เทคโนโลยี กฎหมาย หรือการวิจัย ดวงการเงินดีจากความเชี่ยวชาญ" },
    8: { stars:5, text:"เลข 8 คือพลังแห่งอำนาจและความมั่งคั่ง นี่คือตัวเลขนักธุรกิจแท้ คุณมีพลังในการสะสมความมั่งคั่งและสร้างอาณาจักรธุรกิจ ดวงการเงินดีเยี่ยม" },
    9: { stars:4, text:"เลข 9 คือพลังแห่งความสมบูรณ์และมนุษยธรรม คุณเหมาะกับธุรกิจเพื่อสังคม หรือธุรกิจที่ช่วยเหลือผู้อื่น ดวงการเงินดีจากการแบ่งปันและการสร้างคุณค่า" }
};

var TAROT_CARDS = [
    { icon:"bi-star-fill",             name:"ดวงดาว",          meaning:"ความหวัง โชคลาภ",     detail:"ดวงดาวส่องแสงให้คุณ! วันนี้โชคชะตาเปิดทางให้ธุรกิจของคุณ มีโอกาสใหม่ที่กำลังจะเข้ามา จงมีความหวังและมองโลกในแง่ดี ดวงการเงินดีเยี่ยม อาจได้รับข่าวดีเรื่องสินเชื่อหรือการลงทุน" },
    { icon:"bi-sun-fill",              name:"ดวงอาทิตย์",      meaning:"ความสำเร็จ ชัยชนะ",   detail:"พลังอาทิตย์เปล่งแสงให้คุณเด่นชัด! ธุรกิจกำลังเจริญรุ่งเรือง ลูกค้าให้ความไว้วางใจ รายได้มีแนวโน้มเพิ่มขึ้น เป็นวันที่เหมาะกับการตัดสินใจสำคัญและการลงนามสัญญา" },
    { icon:"bi-moon-stars-fill",       name:"ดวงจันทร์",       meaning:"ญาณทิพย์ ลึกซึ้ง",   detail:"ดวงจันทร์บอกให้คุณหยุดฟังเสียงภายใน มีบางอย่างที่ยังไม่ชัดเจนในธุรกิจ อย่าเพิ่งตัดสินใจใหญ่โดยขาดข้อมูล รอให้สถานการณ์ชัดขึ้นก่อน แต่ดวงการเงินยังคงสม่ำเสมอ" },
    { icon:"bi-globe",                 name:"โลกกว้าง",        meaning:"ความสมบูรณ์ ชัยชนะ", detail:"คุณกำลังจะบรรลุเป้าหมายสำคัญ! ธุรกิจที่ลงทุนไปกำลังออกดอกออกผล การขยายตลาดหรือเปิดสาขาใหม่มีแนวโน้มสำเร็จ ดวงการเงินดีมาก โชคลาภมาจากทุกทิศทาง" },
    { icon:"bi-arrow-repeat",          name:"วงล้อโชคชะตา",   meaning:"เปลี่ยนแปลง โอกาส",  detail:"วงล้อแห่งโชคชะตากำลังหมุน การเปลี่ยนแปลงครั้งสำคัญกำลังมา อาจเป็นโอกาสใหม่หรือความท้าทายใหม่ จงยืดหยุ่นและพร้อมรับมือ ดวงโชคลาภมาแบบไม่คาดฝัน" },
    { icon:"bi-shield-fill",           name:"ผู้นำแห่งอำนาจ",  meaning:"อำนาจ ความมั่นคง",   detail:"คุณมีอำนาจและความสามารถในการควบคุมทิศทางธุรกิจ เหมาะกับการวางโครงสร้างองค์กรและการบริหารทีม ดวงการเงินมั่นคงและแข็งแกร่ง" },
    { icon:"bi-eye-fill",              name:"ผู้รู้แจ้ง",       meaning:"ปัญญา สัญชาตญาณ",    detail:"ปัญญาลึกนำทางคุณ วันนี้จงเชื่อสัญชาตญาณ มีข้อมูลสำคัญที่ยังซ่อนอยู่ ควรศึกษาข้อมูลให้ลึกก่อนตัดสินใจลงทุน ดวงการเงินดีหากคุณใช้ปัญญา" },
    { icon:"bi-lightning-charge-fill", name:"นักเวทย์มนต์",    meaning:"พลังงาน ความสามารถ",  detail:"คุณมีทุกอย่างที่จำเป็นสำหรับความสำเร็จ! ทักษะ ความรู้ และพลังงานพร้อมแล้ว ถึงเวลาลงมือทำโปรเจกต์ที่รอคอย ดวงการเงินดีเยี่ยมสำหรับผู้ที่กล้าลงมือ" }
];

// Init
document.addEventListener("DOMContentLoaded", function () {
    renderTodayLabel();
    renderLuckyColor();
    renderTarotGrid();
});

function renderTodayLabel() {
    var days = ["วันอาทิตย์","วันจันทร์","วันอังคาร","วันพุธ","วันพฤหัสบดี","วันศุกร์","วันเสาร์"];
    var months = ["ม.ค.","ก.พ.","มี.ค.","เม.ย.","พ.ค.","มิ.ย.","ก.ค.","ส.ค.","ก.ย.","ต.ค.","พ.ย.","ธ.ค."];
    var d = new Date();
    document.getElementById("todayLabel").textContent =
        days[d.getDay()] + " ที่ " + d.getDate() + " " + months[d.getMonth()] + " " + (d.getFullYear() + 543);
}

function renderLuckyColor() {
    var data = DAY_DATA[new Date().getDay()];
    var html = "";
    data.colors.forEach(function (c) {
        html += '<div class="lucky-color-item">' +
            '<div class="lucky-color-swatch" style="background:' + c.hex + ';">' +
                '<i class="bi ' + c.icon + '"></i>' +
            '</div>' +
            '<div class="lucky-color-info">' +
                '<div class="lucky-color-name">' + c.name + '</div>' +
                '<div class="lucky-color-desc">' + c.desc + '</div>' +
                '<span class="lucky-color-tag">' + c.tag + '</span>' +
            '</div>' +
        '</div>';
    });
    document.getElementById("luckyColorRow").innerHTML = html;
    document.getElementById("luckyColorFortune").textContent = data.fortune;
}

function buildStars(n) {
    var s = "";
    for (var i = 0; i < 5; i++) {
        s += '<i class="bi bi-star' + (i < n ? "-fill" : "") + '" style="font-size:16px;color:#d97706;margin:0 1px;"></i>';
    }
    return s;
}

function switchTab(tab) {
    ["phone","tarot"].forEach(function(t) {
        document.getElementById("tab-" + t).classList.toggle("active", t === tab);
        document.getElementById("tab-btn-" + t).classList.toggle("active", t === tab);
    });
}

function renderTarotGrid() {
    var shuffled = TAROT_CARDS.slice().sort(function () { return Math.random() - 0.5; });
    var html = "";
    shuffled.forEach(function (card, i) {
        html += '<div class="tarot-card-wrap">' +
            '<div class="tarot-card" id="tc' + i + '" onclick="flipTarot(this,' + i + ')">' +
                '<div class="tarot-back">' +
                    '<div class="tarot-back-pattern"></div>' +
                    '<i class="bi bi-stars tarot-back-icon"></i>' +
                    '<span class="tarot-back-num">ใบที่ ' + (i + 1) + '</span>' +
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
    document.getElementById("tarotGrid").innerHTML = html;
    window._shuffledTarot = shuffled;
}

var tarotPicked = false;
function flipTarot(el, idx) {
    if (tarotPicked) return;
    tarotPicked = true;
    el.classList.add("flipped");
    setTimeout(function () { showTarotResult(idx); }, 700);
    setTimeout(function () {
        document.querySelectorAll(".tarot-card").forEach(function (c, i) {
            if (i !== idx) c.classList.add("used");
        });
    }, 200);
}

function showTarotResult(idx) {
    var card = window._shuffledTarot[idx];
    document.getElementById("resultIcon").innerHTML =
        '<i class="bi ' + card.icon + '" style="font-size:52px;color:#1344a0;"></i>';
    document.getElementById("resultCardName").textContent = card.name;
    document.getElementById("resultText").textContent = card.detail;
    document.getElementById("tarotResultOverlay").classList.add("show");
}

function closeResult() {
    document.getElementById("tarotResultOverlay").classList.remove("show");
}

function resetPhone() {
    document.getElementById("phoneInput").value = "";
    document.getElementById("phoneResult").style.display = "none";
    document.getElementById("phoneInput").focus();
}

function resetTarot() {
    document.getElementById("tarotResultOverlay").classList.remove("show");
    tarotPicked = false;
    renderTarotGrid();
}

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
    document.getElementById("phoneStars").innerHTML = buildStars(data.stars);
    document.getElementById("phoneFortuneText").textContent = data.text;
    var result = document.getElementById("phoneResult");
    result.style.display = "block";
    result.scrollIntoView({ behavior: "smooth", block: "nearest" });
}
</script>
</asp:Content>
