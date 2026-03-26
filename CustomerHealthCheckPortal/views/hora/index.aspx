<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.hora.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>SME �մǧ - �ٴǧ��áԨ���</title>
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
        /* 2-row horizontal scroll */
        .tarot-scroll-hint {
            font-size: 11px; color: #8fa3c8; text-align: center; margin-bottom: 6px;
        }
        .tarot-scroll-wrap {
            overflow-x: auto; -webkit-overflow-scrolling: touch;
            margin: 0 -4px; padding: 0 4px 8px;
        }
        .tarot-scroll-wrap::-webkit-scrollbar { height: 4px; }
        .tarot-scroll-wrap::-webkit-scrollbar-track { background: #f0f6ff; border-radius: 2px; }
        .tarot-scroll-wrap::-webkit-scrollbar-thumb { background: #c7d8f7; border-radius: 2px; }
        .tarot-grid {
            display: grid;
            grid-template-rows: repeat(2, auto);
            grid-auto-flow: column;
            gap: 8px;
            width: max-content;
        }
        .tarot-card-wrap { width: 66px; perspective: 600px; }
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
        /* Warning box for bad cards */
        .tarot-warning-box {
            background: #fef2f2; border-left: 3px solid #dc2626;
            border-radius: 0 8px 8px 0; padding: 10px 12px; margin: 10px 0 0;
            text-align: left;
        }
        .tarot-warning-title {
            font-size: 12px; font-weight: 700; color: #dc2626;
            margin-bottom: 5px; display: flex; align-items: center; gap: 5px;
        }
        .tarot-warning-text { font-size: 12px; color: #7f1d1d; line-height: 1.65; margin: 0; }
        /* Consult BSY button */
        .hora-btn-consult {
            border: none; cursor: pointer;
            background: linear-gradient(135deg, #1344a0, #1a6fdd);
            color: #fff; font-size: 12px; font-weight: 700;
            padding: 11px 14px; border-radius: 12px; flex: 1; min-width: 140px;
            box-shadow: 0 4px 12px rgba(19,68,160,0.35);
            transition: opacity 0.2s; line-height: 1.4;
        }
        .hora-btn-consult:active { opacity: 0.85; }
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
                <h1 class="color-theme mb-0 font-18">��͹��Ѻ</h1>
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
        <h1 class="hora-title">SME �մǧ</h1>
        <p class="hora-subtitle">�ٴǧ��áԨ &bull; ����Թ &bull; ⪤�е�</p>
        <span class="hora-date-badge" id="todayLabel">���ѧ��Ŵ...</span>
    </div>

    <!-- Section 1: �����š���Թ -->
    <div class="hora-card">
        <div class="hora-card-title">
            <i class="bi bi-palette-fill"></i>
            �����Ŵ�ҹ����Թ�ѹ���
        </div>
        <div class="lucky-color-row" id="luckyColorRow"></div>
        <div class="hora-fortune-text" id="luckyColorFortune"></div>
    </div>

    <!-- Section 2+3: Tabs � �ٴǧ���� + ����õ� -->
    <div class="hora-card">
        <div class="hora-tabs">
            <button type="button" class="hora-tab active" id="tab-btn-phone" onclick="switchTab('phone')">
                <i class="bi bi-telephone-fill"></i> �ٴǧ������
            </button>
            <button type="button" class="hora-tab" id="tab-btn-tarot" onclick="switchTab('tarot')">
                <i class="bi bi-layers-fill"></i> ����õ�
            </button>
        </div>

        <!-- Tab: Phone -->
        <div class="hora-tab-content active" id="tab-phone">
            <div class="hora-card-title" style="margin-top:0;">
                <i class="bi bi-telephone-fill"></i>
                �ٴǧ�ҡ�������Ѿ��
            </div>
            <div class="phone-input-wrap">
                <i class="bi bi-telephone"></i>
                <input type="tel" id="phoneInput" class="hora-input"
                       placeholder="��͡�������Ѿ��ͧ�س" maxlength="10"
                       oninput="this.value=this.value.replace(/[^0-9]/g,'')" />
            </div>
            <button type="button" class="hora-btn-gold" onclick="readPhoneFortune()">
                <i class="bi bi-search"></i> �Դ�ǧ�е�
            </button>
            <div class="phone-result" id="phoneResult"
                 style="margin-top:16px; padding-top:14px; border-top:1px solid #e8f0fe;">
                <div class="numerology-circle">
                    <span class="numerology-number" id="phoneNumResult"></span>
                    <span class="numerology-label">�Ţ���Ե</span>
                </div>
                <span class="phone-fortune-stars" id="phoneStars"></span>
                <p class="phone-fortune-text" id="phoneFortuneText"></p>
                <button type="button" class="hora-btn-reset" onclick="resetPhone()" style="margin-top:14px;">
                    <i class="bi bi-arrow-counterclockwise"></i> �ٴǧ�������
                </button>
            </div>
        </div>

        <!-- Tab: Tarot -->
        <div class="hora-tab-content" id="tab-tarot">
            <div class="hora-card-title" style="margin-top:0;">
                <i class="bi bi-layers-fill"></i>
                ����õ��Ш��ѹ
            </div>
            <div class="tarot-instruction">
                <i class="bi bi-hand-index-thumb"></i>
                ���͡ 1 � �����Ѻ��ѧ�ҹ��Фӷӹ�»�Ш��ѹ�ͧ�س
            </div>
            <p class="tarot-scroll-hint"><i class="bi bi-arrows-expand-vertical"></i> เลื่อนซ้าย-ขวาเพื่อดูไพ่ทั้ง 22 ใบ</p>
            <div class="tarot-scroll-wrap">
                <div class="tarot-grid" id="tarotGrid"></div>
            </div>
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
        <div class="tarot-warning-box" id="resultWarning" style="display:none;">
            <div class="tarot-warning-title"><i class="bi bi-exclamation-triangle-fill"></i> ข้อควรระวัง</div>
            <p class="tarot-warning-text" id="resultWarningText"></p>
        </div>
        <div style="display:flex; gap:10px; justify-content:center; flex-wrap:wrap; margin-top:16px;">
            <button type="button" class="hora-btn-consult" onclick="closeResult()">
                <i class="bi bi-person-check-fill"></i> ปรึกษาผู้เชี่ยวชาญทางการเงินกับ บสย.
            </button>
            <button type="button" class="hora-btn-reset" onclick="resetTarot()" style="width:auto; padding:10px 16px; margin-top:0;">
                <i class="bi bi-arrow-counterclockwise"></i> เปิดใหม่
            </button>
        </div>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
<script>
// HORA - Fortune Page

var DAY_DATA = [
    { name: "�ѹ�ҷԵ��",
      colors: [
          { hex: "#dc2626", name: "��ᴧ",   icon: "bi-droplet-fill",    desc: "⪤��� �ӹҨ",          tag: "�Թ�ͧ" },
          { hex: "#f97316", name: "�����",    icon: "bi-brightness-high", desc: "��ѧ�ҹ ���������",    tag: "��áԨ" }
      ],
      fortune: "�ѹ����ѧ�ҹ��ᴧ������������� ����СѺ��õѴ�Թ�����ͧ���ŧ�ع��С�â��¸�áԨ �ǧ����Թ�����ࡳ��� ���ѧ��¨��·��������"
    },
    { name: "�ѹ�ѹ���",
      colors: [
          { hex: "#f59e0b", name: "������ͧ", icon: "bi-sun-fill",        desc: "�ѭ�� ������觤��",    tag: "⪤���" },
          { hex: "#fbbf24", name: "�դ���",   icon: "bi-circle-half",     desc: "����ʧ� �Һ���",       tag: "��çҹ" }
      ],
      fortune: "������ͧ�ͧ������觤�����觤����ѹ�ѹ��� ����СѺ����èҸ�áԨ��С�â��Թ���� �ǧ�������ͧ�͡�������ѭ��"
    },
    { name: "�ѹ�ѧ���",
      colors: [
          { hex: "#ec4899", name: "�ժ���",   icon: "bi-heart-fill",      desc: "�����ѡ ��������ѹ��",  tag: "���������ѹ��" },
          { hex: "#a855f7", name: "����ǧ",   icon: "bi-gem",             desc: "�ѭ�ҵ�ҳ ��Ǿ�Ժ",    tag: "��Ǿ�Ժ" }
      ],
      fortune: "�ժ��������ǧ�������ѧ����è���Ф�������ѹ��ҧ��áԨ �ѹ�������СѺ��þ��о����������� ���͢������͢��� SME"
    },
    { name: "�ѹ�ظ",
      colors: [
          { hex: "#16a34a", name: "������",   icon: "bi-tree-fill",      desc: "��ԭ�Ժ� ��蹤�",   tag: "����Թ" },
          { hex: "#84cc16", name: "������͹", icon: "bi-flower1",        desc: "����ʴ�� �آ�Ҿ��",    tag: "⪤��" }
      ],
      fortune: "�����Ǥ������觤�����ԭ������ͧ��ѹ�ظ ����СѺ�������Թ ŧ�ع������� ��Т����ҢҸ�áԨ �ǧ����Թ���ç"
    },
    { name: "�ѹ����ʺ��",
      colors: [
          { hex: "#f97316", name: "�����",  icon: "bi-fire",              desc: "��ѧ ��������",         tag: "���������" },
          { hex: "#d97706", name: "�շͧ",  icon: "bi-stars",             desc: "������觤�� ��������", tag: "⪤���" }
      ],
      fortune: "������ͧ�ѹ����������⪤�����Ф�������˹�� ����СѺ����������ͧ���Թ���� ����ŧ����ѭ���Ӥѭ �ǧ��áԨ���ҡ"
    },
    { name: "�ѹ�ء��",
      colors: [
          { hex: "#3b82f6", name: "�տ��",      icon: "bi-water",         desc: "�ѹ�� ��������ҧ�",    tag: "��ä��" },
          { hex: "#06b6d4", name: "���������", icon: "bi-wind",          desc: "�����Դ���ҧ��ä�",     tag: "��ѵ����" }
      ],
      fortune: "�ѹ�ء���տ�����������������Ͷ����Ф�������ҧ� ����СѺ��ù��ʹͧҹ���;��ૹ���áԨ �ǧ����èҴ�������"
    },
    { name: "�ѹ�����",
      colors: [
          { hex: "#7c3aed", name: "��ǧ���",  icon: "bi-moon-stars-fill", desc: "�ӹҨ �ѡ������",    tag: "������觤��" },
          { hex: "#1e3a8a", name: "�ա�����",  icon: "bi-shield-fill",     desc: "�֡�Ѻ �ѭ��",       tag: "����·�ȹ�" }
      ],
      fortune: "����ǧ��С�������ѹ������������ѧ��觻ѭ���������·�ȹ� ����СѺ����ҧἹ���ط���áԨ������� ���͡�ý֡ͺ���Ѳ�ҵ��ͧ"
    }
];

var NUMEROLOGY = {
    1: { stars:5, text:"�Ţ 1 ��;�ѧ��觼��� �س�դ�������ö㹡�ú�������еѴ�Թ㨷������� ��áԨ�ͧ�س��������Ժ⵴��¤��������蹢ͧ����ͧ ����Թ�շ�ȷҧ�����ҡ�س�繤����������͹" },
    2: { stars:4, text:"�Ţ 2 ��;�ѧ��觤���������� �س����СѺ��÷Ӹ�áԨẺ�������� ���͡������ŧ�ع �ǧ����Թ�ըҡ��������ѹ����աѺ������ ���ҵѴ�Թ��˭褹����" },
    3: { stars:5, text:"�Ţ 3 ��;�ѧ��觤������ҧ��ä���С��������� �سⴴ�蹴�ҹ��õ�Ҵ��С�ù��ʹ� ��áԨ�ԨԷ������������觾��������СѺ�س�ҡ �ǧ����Թ�ըҡ�ѡ�С���������" },
    4: { stars:3, text:"�Ţ 4 ��;�ѧ��觤�����蹤��������º �س����СѺ��áԨ������ç���ҧ�Ѵਹ �ǧ����Թ��蹤�������繤���� ��ͧʹ������ҧἹ���ҧ�ͺ�ͺ" },
    5: { stars:4, text:"�Ţ 5 ��;�ѧ��觡������¹�ŧ��������Ҿ �س����СѺ��áԨ����״���� �� ��Ң�� ��ͧ����� ���ͷ���֡�� �ǧ⪤�����Ẻ���Ҵ�ѹ" },
    6: { stars:4, text:"�Ţ 6 ��;�ѧ��觤����Ѻ�Դ�ͺ��С�ú�ԡ�� �س����СѺ��áԨ�����ż����� �� ����� �آ�Ҿ ���͡���֡�� �ǧ����Թ�ըҡ��������ҧ㨢ͧ�١���" },
    7: { stars:4, text:"�Ţ 7 ��;�ѧ��觻ѭ����С���������� �س����СѺ��áԨ������������ԧ�֡ �� ෤����� ������ ���͡���Ԩ�� �ǧ����Թ�ըҡ��������Ǫҭ" },
    8: { stars:5, text:"�Ţ 8 ��;�ѧ����ӹҨ��Ф�����觤�� ����͵���Ţ�ѡ��áԨ�� �س�վ�ѧ㹡������������觤��������ҧ�ҳҨѡø�áԨ �ǧ����Թ��������" },
    9: { stars:4, text:"�Ţ 9 ��;�ѧ��觤�������ó��������¸��� �س����СѺ��áԨ�����ѧ�� ���͸�áԨ����������ͼ����� �ǧ����Թ�ըҡ����觻ѹ��С�����ҧ�س���" }
};

var TAROT_CARDS = [
    { icon:"bi-star-fill",             name:"�ǧ���",          meaning:"������ѧ ⪤���",     detail:"�ǧ�����ͧ�ʧ���س! �ѹ���⪤�е��Դ�ҧ����áԨ�ͧ�س ���͡����������ѧ������� ���դ�����ѧ����ͧ�š���� �ǧ����Թ�������� �Ҩ���Ѻ���Ǵ�����ͧ�Թ�������͡��ŧ�ع" },
    { icon:"bi-sun-fill",              name:"�ǧ�ҷԵ��",      meaning:"��������� ��ª��",   detail:"��ѧ�ҷԵ������ʧ���س�蹪Ѵ! ��áԨ���ѧ��ԭ������ͧ �١�������������ҧ� ������������������� ���ѹ�������СѺ��õѴ�Թ��Ӥѭ��С��ŧ����ѭ��" },
    { icon:"bi-moon-stars-fill",       name:"�ǧ�ѹ���",       meaning:"�ҳ�Ծ�� �֡���",   detail:"�ǧ�ѹ���͡���س��ش�ѧ���§���� �պҧ���ҧ����ѧ���Ѵਹ㹸�áԨ ������觵Ѵ�Թ��˭��¢Ҵ������ �����ʶҹ��ó�Ѵ��鹡�͹ ��ǧ����Թ�ѧ����������" },
    { icon:"bi-globe",                 name:"�š���ҧ",        meaning:"��������ó� ��ª��", detail:"�س���ѧ�к������������Ӥѭ! ��áԨ���ŧ�ع仡��ѧ�͡�͡�͡�� ��â��µ�Ҵ�����Դ�Ң����������������� �ǧ����Թ���ҡ ⪤����Ҩҡ�ء��ȷҧ" },
    { icon:"bi-arrow-repeat",          name:"ǧ���⪤�е�",   meaning:"����¹�ŧ �͡��",  detail:"ǧ������⪤�еҡ��ѧ��ع �������¹�ŧ�����Ӥѭ���ѧ�� �Ҩ���͡���������ͤ�����ҷ������ ���״������о�����Ѻ��� �ǧ⪤�����Ẻ���Ҵ�ѹ" },
    { icon:"bi-shield-fill",           name:"��������ӹҨ",  meaning:"�ӹҨ ������蹤�",   detail:"�س���ӹҨ��Ф�������ö㹡�äǺ�����ȷҧ��áԨ ����СѺ����ҧ�ç���ҧͧ�����С�ú����÷�� �ǧ����Թ��蹤���������" },
    { icon:"bi-eye-fill",              name:"��������",       meaning:"�ѭ�� �ѭ�ҵ�ҳ",    detail:"�ѭ���֡�ӷҧ�س �ѹ��騧�����ѭ�ҵ�ҳ �բ������Ӥѭ����ѧ��͹���� ����֡�Ң���������֡��͹�Ѵ�Թ�ŧ�ع �ǧ����Թ���ҡ�س��ѭ��" },
    { icon:"bi-lightning-charge-fill", name:"�ѡ�Ƿ������",    meaning:"��ѧ�ҹ ��������ö",  detail:"�س�շء���ҧ����������Ѻ���������! �ѡ�� ������� ��о�ѧ�ҹ��������� �֧����ŧ��ͷ���ਡ�����ͤ�� �ǧ����Թ������������Ѻ��������ŧ���" }
];

// Init
document.addEventListener("DOMContentLoaded", function () {
    renderTodayLabel();
    renderLuckyColor();
    renderTarotGrid();
});

function renderTodayLabel() {
    var days = ["�ѹ�ҷԵ��","�ѹ�ѹ���","�ѹ�ѧ���","�ѹ�ظ","�ѹ����ʺ��","�ѹ�ء��","�ѹ�����"];
    var months = ["�.�.","�.�.","��.�.","��.�.","�.�.","��.�.","�.�.","�.�.","�.�.","�.�.","�.�.","�.�."];
    var d = new Date();
    document.getElementById("todayLabel").textContent =
        days[d.getDay()] + " ��� " + d.getDate() + " " + months[d.getMonth()] + " " + (d.getFullYear() + 543);
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
                    '<span class="tarot-back-num">㺷�� ' + (i + 1) + '</span>' +
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
        alert("��سҡ�͡�������Ѿ�����ú��ǹ");
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
