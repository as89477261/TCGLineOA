<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.hora.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>SME ดูดวง - ดูดวงธุรกิจ</title>
    <style>
        /* ========== HORA PAGE ========== */
        .hora-page { background-color: whitesmoke; min-height: 100vh; padding-bottom: 80px; }
        .hora-page > div:first-child { margin-top: 0 !important; }

        /* --- Header Animations (3 levels) --- */
        @keyframes icon-twinkle {
            0%, 100% { opacity: 0.85; transform: scale(1); filter: drop-shadow(0 0 6px rgba(251,191,36,0.55)); }
            50%       { opacity: 1;    transform: scale(1.10); filter: drop-shadow(0 0 18px rgba(251,191,36,1)); }
        }
        @keyframes icon-twinkle-good {
            0%, 100% { opacity: 0.9; transform: scale(1); filter: drop-shadow(0 0 10px rgba(34,197,94,0.6)) drop-shadow(0 0 6px rgba(251,191,36,0.5)); }
            50%      { opacity: 1;   transform: scale(1.15); filter: drop-shadow(0 0 28px rgba(34,197,94,0.9)) drop-shadow(0 0 14px rgba(251,191,36,1)); }
        }
        @keyframes icon-twinkle-great {
            0%   { opacity: 0.9; transform: scale(1) rotate(0deg); filter: drop-shadow(0 0 10px rgba(251,191,36,0.8)); }
            25%  { opacity: 1;   transform: scale(1.12) rotate(3deg); filter: drop-shadow(0 0 24px rgba(255,215,0,1)); }
            50%  { opacity: 1;   transform: scale(1.22) rotate(0deg); filter: drop-shadow(0 0 36px rgba(255,215,0,1)) drop-shadow(0 0 60px rgba(251,191,36,0.4)); }
            75%  { opacity: 1;   transform: scale(1.12) rotate(-3deg); filter: drop-shadow(0 0 24px rgba(255,215,0,1)); }
            100% { opacity: 0.9; transform: scale(1) rotate(0deg); filter: drop-shadow(0 0 10px rgba(251,191,36,0.8)); }
        }
        @keyframes sparkle-float {
            0%   { opacity: 0; transform: translateY(0) scale(0); }
            40%  { opacity: 1; transform: translateY(-18px) scale(1); }
            100% { opacity: 0; transform: translateY(-40px) scale(0); }
        }
        .hora-header { padding: 10px 16px 20px; text-align: center; position: relative; }
        .hora-header-icon {
            font-size: 72px; display: block; margin-bottom: 6px;
            color: #f59e0b; position: relative;
            animation: icon-twinkle 2.2s ease-in-out infinite;
        }
        .hora-sparkles {
            position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%);
            width: 100px; height: 100px; pointer-events: none; display: none;
        }
        .hora-sparkle {
            position: absolute; width: 6px; height: 6px; border-radius: 50%;
            background: #fbbf24;
        }
        .hora-sparkle:nth-child(1) { left:10%; top:20%; animation: sparkle-float 2.0s 0.0s infinite; }
        .hora-sparkle:nth-child(2) { left:80%; top:15%; animation: sparkle-float 2.2s 0.4s infinite; }
        .hora-sparkle:nth-child(3) { left:50%; top:10%; animation: sparkle-float 1.8s 0.8s infinite; }
        .hora-sparkle:nth-child(4) { left:25%; top:70%; animation: sparkle-float 2.4s 1.2s infinite; }
        .hora-sparkle:nth-child(5) { left:75%; top:65%; animation: sparkle-float 2.0s 0.6s infinite; }

        .hora-icon-area { position: relative; display: inline-block; padding: 18px 28px; }
        .hora-mini-star {
            position: absolute; pointer-events: none; color: #fbbf24; opacity: 0;
        }
        @keyframes mini-star-good {
            0%, 100% { opacity: 0.25; transform: scale(0.6); }
            50% { opacity: 0.85; transform: scale(1.15); }
        }
        @keyframes mini-star-great {
            0%, 100% { opacity: 0.3; transform: scale(0.5) rotate(0deg); }
            50% { opacity: 1; transform: scale(1.35) rotate(25deg); }
        }

        .day-quality-badge {
            display: none; margin: 8px auto 0; padding: 5px 16px;
            border-radius: 20px; font-size: 12px; font-weight: 700;
            justify-content: center; align-items: center; gap: 5px; width: fit-content;
            animation: badge-pulse 2s ease-in-out infinite;
        }
        @keyframes badge-pulse {
            0%, 100% { transform: scale(1); }
            50% { transform: scale(1.05); }
        }
        .day-quality-badge.good { background: #dcfce7; color: #166534; border: 1px solid #22c55e; }
        .day-quality-badge.great { background: linear-gradient(135deg, #fef3c7, #fde68a); color: #92400e; border: 1px solid #fbbf24; }

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

        /* --- Lucky Color --- */
        .lucky-color-row { display: flex; gap: 10px; }
        .lucky-color-item { flex: 1; border-radius: 10px; overflow: hidden; border: 1px solid #e8f0fe; }
        .lucky-color-swatch { height: 54px; display: flex; align-items: center; justify-content: center; }
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

        /* --- Tabs (shared) --- */
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
        .hora-tab.active { background: #fff; color: #0a2463; box-shadow: 0 2px 8px rgba(0,0,0,0.1); }
        .hora-tab i { font-size: 14px; }
        .hora-tab-content { display: none; }
        .hora-tab-content.active { display: block; }

        /* --- Calendar --- */
        .cal-nav { display: flex; align-items: center; justify-content: space-between; margin-bottom: 12px; }
        .cal-nav-btn {
            border: none; background: #e8f0fe; color: #1344a0;
            width: 32px; height: 32px; border-radius: 8px; font-size: 14px;
            cursor: pointer; display: flex; align-items: center; justify-content: center;
        }
        .cal-nav-btn:active { background: #c7d8f7; }
        .cal-month-label { font-size: 15px; font-weight: 700; color: #0a2463; }
        .cal-weekdays {
            display: grid; grid-template-columns: repeat(7, 1fr);
            text-align: center; font-size: 11px; font-weight: 600; color: #8fa3c8; margin-bottom: 4px;
        }
        .cal-grid { display: grid; grid-template-columns: repeat(7, 1fr); gap: 3px; }
        .cal-day {
            aspect-ratio: 1; display: flex; align-items: center; justify-content: center;
            font-size: 12px; font-weight: 600; border-radius: 8px; cursor: pointer; transition: all 0.15s;
        }
        .cal-day.empty { cursor: default; }
        .cal-day.great { background: #fef3c7; color: #92400e; }
        .cal-day.good { background: #dcfce7; color: #166534; }
        .cal-day.normal { background: #f0f6ff; color: #1344a0; }
        .cal-day.caution { background: #fee2e2; color: #991b1b; }
        .cal-day.today { box-shadow: inset 0 0 0 2px #1344a0; font-weight: 900; }
        .cal-day:not(.empty):active { transform: scale(0.9); }
        .cal-legend {
            display: flex; justify-content: center; gap: 10px; margin-top: 10px; flex-wrap: wrap;
            font-size: 10px; color: #64748b;
        }
        .cal-legend-item { display: flex; align-items: center; gap: 3px; }
        .cal-legend-dot { width: 10px; height: 10px; border-radius: 3px; }
        .cal-legend-dot.great { background: #fef3c7; border: 1px solid #fbbf24; }
        .cal-legend-dot.good { background: #dcfce7; border: 1px solid #22c55e; }
        .cal-legend-dot.normal { background: #f0f6ff; border: 1px solid #93c5fd; }
        .cal-legend-dot.caution { background: #fee2e2; border: 1px solid #f87171; }
        .cal-detail {
            margin-top: 12px; background: #f8faff; border-radius: 12px;
            padding: 14px; border: 1px solid #e8f0fe; display: none;
        }

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
        .hora-btn-gold {
            width: 100%; margin-top: 10px; border: none; cursor: pointer;
            background: linear-gradient(135deg, #b45309, #d97706, #f59e0b, #fbbf24);
            color: #fff; font-size: 15px; font-weight: 700;
            padding: 13px; border-radius: 12px;
            box-shadow: 0 4px 14px rgba(217,119,6,0.4); transition: opacity 0.2s;
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
        .tarot-scroll-hint { font-size: 11px; color: #8fa3c8; text-align: center; margin-bottom: 6px; }
        .tarot-scroll-wrap {
            overflow-x: auto; -webkit-overflow-scrolling: touch;
            margin: 0 -4px; padding: 0 4px 8px;
        }
        .tarot-scroll-wrap::-webkit-scrollbar { height: 4px; }
        .tarot-scroll-wrap::-webkit-scrollbar-track { background: #f0f6ff; border-radius: 2px; }
        .tarot-scroll-wrap::-webkit-scrollbar-thumb { background: #c7d8f7; border-radius: 2px; }
        .tarot-grid {
            display: grid; grid-template-rows: repeat(2, auto);
            grid-auto-flow: column; gap: 8px; width: max-content;
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
            background: repeating-linear-gradient(45deg, rgba(255,255,255,0.03) 0px, rgba(255,255,255,0.03) 2px, transparent 2px, transparent 10px);
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
            max-height: 90vh; overflow-y: auto;
        }
        .hora-result-icon      { font-size: 52px; margin-bottom: 10px; }
        .hora-result-card-name { font-size: 18px; font-weight: 800; color: #0a2463; margin-bottom: 6px; }
        .hora-result-divider   { color: #c7d8f7; letter-spacing: 8px; font-size: 14px; margin: 8px 0; }
        .hora-result-text      { font-size: 14px; color: #334155; line-height: 1.8; text-align: left; }
        .tarot-warning-box {
            background: #fef2f2; border-left: 3px solid #dc2626;
            border-radius: 0 8px 8px 0; padding: 10px 12px; margin: 10px 0 0; text-align: left;
        }
        .tarot-warning-title {
            font-size: 12px; font-weight: 700; color: #dc2626;
            margin-bottom: 5px; display: flex; align-items: center; gap: 5px;
        }
        .tarot-warning-text { font-size: 12px; color: #7f1d1d; line-height: 1.65; margin: 0; }
        .hora-btn-consult {
            border: none; cursor: pointer;
            background: linear-gradient(135deg, #1344a0, #1a6fdd);
            color: #fff; font-size: 12px; font-weight: 700;
            padding: 11px 14px; border-radius: 12px; flex: 1; min-width: 140px;
            box-shadow: 0 4px 12px rgba(19,68,160,0.35); transition: opacity 0.2s; line-height: 1.4;
        }
        .hora-btn-consult:active { opacity: 0.85; }
        .hora-btn-reset {
            width: 100%; margin-top: 10px; border: 2px solid #d97706; cursor: pointer;
            background: #fff; color: #b45309; font-size: 14px; font-weight: 700;
            padding: 10px; border-radius: 12px; transition: all 0.2s;
            display: flex; align-items: center; justify-content: center; gap: 6px;
        }
        .hora-btn-reset:active { background: #fef3c7; }

        /* --- Temple Recommendations --- */
        .temple-item {
            background: #f8faff; border: 1px solid #e8f0fe; border-radius: 10px;
            padding: 10px; margin-bottom: 8px; display: flex; align-items: flex-start; gap: 10px;
        }
        .temple-img-wrap {
            width: 64px; height: 64px; border-radius: 10px; overflow: hidden; flex-shrink: 0;
            background: linear-gradient(135deg, #fbbf24, #f59e0b);
            display: flex; align-items: center; justify-content: center;
        }
        .temple-img-wrap img { width: 100%; height: 100%; object-fit: cover; display: block; }
        .temple-img-fallback { font-size: 26px; color: #fff; }
        .temple-name { font-size: 12px; font-weight: 700; color: #0a2463; }
        .temple-desc { font-size: 11px; color: #64748b; margin-top: 2px; }
        .temple-location { font-size: 10px; color: #8fa3c8; margin-top: 2px; }
        .temple-map-link {
            display: inline-flex; align-items: center; gap: 3px;
            font-size: 10px; font-weight: 600; color: #1344a0; text-decoration: none; margin-top: 4px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hora-page">

    <!-- Header + Wave wrapper (back button inside so wave starts flush to top) -->
    <div style="position:relative; overflow:hidden;">
        <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
            <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
            <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
            <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
            <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
        </svg>

        <!-- Back button (inside wrapper so wave goes behind it) -->
        <div class="pt-3" style="position:relative;z-index:1;">
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

        <!-- Header -->
        <div class="hora-header" style="position:relative;z-index:1;">
            <div class="hora-icon-area" id="headerIconArea">
                <div id="headerMiniStars"></div>
                <i class="bi bi-stars hora-header-icon" id="headerIcon"></i>
                <div class="hora-sparkles" id="headerSparkles">
                    <div class="hora-sparkle"></div><div class="hora-sparkle"></div>
                    <div class="hora-sparkle"></div><div class="hora-sparkle"></div>
                    <div class="hora-sparkle"></div>
                </div>
            </div>
            <h1 class="hora-title">SME ดูดวง</h1>
            <p class="hora-subtitle">ดูดวงธุรกิจ &bull; การเงิน &bull; โชคชะตา</p>
            <span class="hora-date-badge" id="todayLabel">กำลังโหลด...</span>
            <div class="day-quality-badge" id="dayQualityBadge"></div>
        </div>
    </div>

    <!-- Section 1: สีมงคล + ปฏิทินดวง (Tabs) -->
    <div class="hora-card">
        <div class="hora-tabs">
            <button type="button" class="hora-tab active" id="top-btn-color" onclick="switchTopTab('color')">
                <i class="bi bi-palette-fill"></i> สีมงคล
            </button>
            <button type="button" class="hora-tab" id="top-btn-calendar" onclick="switchTopTab('calendar')">
                <i class="bi bi-calendar-check"></i> ปฏิทินดวง
            </button>
        </div>

        <!-- Tab: Lucky Color -->
        <div class="hora-tab-content active" id="top-tab-color">
            <div class="hora-card-title" style="margin-top:0;">
                <i class="bi bi-palette-fill"></i> สีมงคลทางการเงินวันนี้
            </div>
            <div class="lucky-color-row" id="luckyColorRow"></div>
            <div class="hora-fortune-text" id="luckyColorFortune"></div>
        </div>

        <!-- Tab: Calendar -->
        <div class="hora-tab-content" id="top-tab-calendar">
            <div class="cal-nav">
                <button type="button" class="cal-nav-btn" onclick="calPrev()"><i class="bi bi-chevron-left"></i></button>
                <span class="cal-month-label" id="calMonthLabel"></span>
                <button type="button" class="cal-nav-btn" onclick="calNext()"><i class="bi bi-chevron-right"></i></button>
            </div>
            <div class="cal-weekdays">
                <div>จ</div><div>อ</div><div>พ</div><div>พฤ</div><div>ศ</div><div>ส</div><div>อา</div>
            </div>
            <div class="cal-grid" id="calGrid"></div>
            <div class="cal-legend">
                <span class="cal-legend-item"><span class="cal-legend-dot great"></span> ดีมาก</span>
                <span class="cal-legend-item"><span class="cal-legend-dot good"></span> ดี</span>
                <span class="cal-legend-item"><span class="cal-legend-dot normal"></span> ปกติ</span>
                <span class="cal-legend-item"><span class="cal-legend-dot caution"></span> ระวัง</span>
            </div>
            <div class="cal-detail" id="calDetail"></div>
        </div>
    </div>

    <!-- Section 2: ดูดวงเบอร์ + ไพ่ทาโรต์ -->
    <div class="hora-card">
        <div class="hora-tabs">
            <button type="button" class="hora-tab active" id="tab-btn-phone" onclick="switchTab('phone')">
                <i class="bi bi-telephone-fill"></i> ดูดวงเบอร์
            </button>
            <button type="button" class="hora-tab" id="tab-btn-tarot" onclick="switchTab('tarot')">
                <i class="bi bi-layers-fill"></i> ไพ่ทาโรต์
            </button>
        </div>

        <!-- Tab: Phone -->
        <div class="hora-tab-content active" id="tab-phone">
            <div class="hora-card-title" style="margin-top:0;">
                <i class="bi bi-telephone-fill"></i> ดูดวงจากเบอร์โทรศัพท์
            </div>
            <div class="phone-input-wrap">
                <i class="bi bi-telephone"></i>
                <input type="tel" id="phoneInput" class="hora-input"
                       placeholder="กรอกเบอร์โทรศัพท์ของคุณ" maxlength="10"
                       oninput="this.value=this.value.replace(/[^0-9]/g,'')" />
            </div>
            <button type="button" class="hora-btn-gold" onclick="readPhoneFortune()">
                <i class="bi bi-search"></i> คิดดวงชะตา
            </button>
            <div class="phone-result" id="phoneResult"
                 style="margin-top:16px; padding-top:14px; border-top:1px solid #e8f0fe;">
                <div class="numerology-circle">
                    <span class="numerology-number" id="phoneNumResult"></span>
                    <span class="numerology-label">เลขชีวิต</span>
                </div>
                <span class="phone-fortune-stars" id="phoneStars"></span>
                <p class="phone-fortune-text" id="phoneFortuneText"></p>
                <div class="temple-recommend" id="phoneTemples" style="display:none; margin-top:12px; text-align:left;">
                    <div style="font-size:13px; font-weight:700; color:#0a2463; margin-bottom:8px; display:flex; align-items:center; gap:5px;">
                        <i class="bi bi-geo-alt-fill" style="color:#d97706;"></i> สถานที่เสริมดวงที่เหมาะกับคุณ
                    </div>
                    <div id="phoneTempleList"></div>
                </div>
                <button type="button" class="hora-btn-reset" onclick="resetPhone()" style="margin-top:14px;">
                    <i class="bi bi-arrow-counterclockwise"></i> ดูดวงใหม่
                </button>
            </div>
        </div>

        <!-- Tab: Tarot -->
        <div class="hora-tab-content" id="tab-tarot">
            <div class="hora-card-title" style="margin-top:0;">
                <i class="bi bi-layers-fill"></i> ไพ่ทาโรต์ประจำวัน
            </div>
            <div class="tarot-instruction">
                <i class="bi bi-hand-index-thumb"></i>
                เลือก 1 ใบ เพื่อรับพลังงานและคำทำนายประจำวันของคุณ
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
        <div class="temple-recommend" id="resultTemples" style="display:none; margin-top:12px; text-align:left;">
            <div style="font-size:13px; font-weight:700; color:#0a2463; margin-bottom:8px; display:flex; align-items:center; gap:5px;">
                <i class="bi bi-geo-alt-fill" style="color:#d97706;"></i> สถานที่เสริมดวงที่เหมาะกับคุณ
            </div>
            <div id="templeList"></div>
        </div>
        <div style="display:flex; gap:10px; justify-content:center; flex-wrap:wrap; margin-top:16px;">
            <button type="button" class="hora-btn-consult" onclick="closeResult()">
                <i class="bi bi-person-check-fill"></i> ขอคำแนะนำที่ปรึกษาทางการเงิน
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
    /* ========== TEMPLES (36 แห่ง) ========== */
    var TEMPLES = [
        /* --- เสริมโชคลาภ (18) --- */
        { id:"wat-suthat", name:"วัดสุทัศนเทพวราราม", desc:"เสริมโชคลาภ ความมั่งคั่ง", location:"เขตพระนคร กรุงเทพฯ", icon:"bi-bank2", type:"good" },
        { id:"san-phra-phrom", name:"ศาลพระพรหมเอราวัณ", desc:"ขอพรธุรกิจรุ่งเรือง", location:"แยกราชประสงค์ กรุงเทพฯ", icon:"bi-stars", type:"good" },
        { id:"wat-sothon", name:"วัดหลวงพ่อโสธร", desc:"เสริมบารมี การค้าขาย", location:"จ.ฉะเชิงเทรา", icon:"bi-gem", type:"good" },
        { id:"san-phra-phikanet", name:"ศาลพระพิฆเนศ", desc:"ขจัดอุปสรรค เปิดโชค", location:"สี่แยกราชประสงค์ กรุงเทพฯ", icon:"bi-trophy-fill", type:"good" },
        { id:"wat-traimit", name:"วัดไตรมิตรวิทยาราม", desc:"พระทองคำ เสริมโชคลาภ", location:"เขตสัมพันธวงศ์ กรุงเทพฯ", icon:"bi-coin", type:"good" },
        { id:"wat-mangkon", name:"วัดมังกรกมลาวาส", desc:"เสริมดวงการค้า ธุรกิจ", location:"เขตป้อมปราบฯ กรุงเทพฯ", icon:"bi-shop", type:"good" },
        { id:"san-lak-mueang", name:"ศาลหลักเมือง", desc:"เสริมบารมี ค้าขายรุ่งเรือง", location:"เขตพระนคร กรุงเทพฯ", icon:"bi-building", type:"good" },
        { id:"wat-doi-suthep", name:"วัดพระธาตุดอยสุเทพ", desc:"เสริมดวงชะตา โชคลาภ", location:"จ.เชียงใหม่", icon:"bi-brightness-high", type:"good" },
        { id:"wat-arun", name:"วัดอรุณราชวราราม", desc:"เสริมสิริมงคล ชื่อเสียง", location:"เขตบางกอกใหญ่ กรุงเทพฯ", icon:"bi-sunrise", type:"good" },
        { id:"wat-phra-pathom", name:"วัดพระปฐมเจดีย์", desc:"เสริมบุญบารมี ค้าขาย", location:"จ.นครปฐม", icon:"bi-disc", type:"good" },
        { id:"wat-sawang", name:"วัดสว่างอารมณ์", desc:"ขอโชคลาภ ค้าขาย", location:"จ.นครปฐม", icon:"bi-cash-coin", type:"good" },
        { id:"wat-bowon", name:"วัดบวรนิเวศวิหาร", desc:"เสริมสติปัญญา ธุรกิจ", location:"เขตพระนคร กรุงเทพฯ", icon:"bi-book", type:"good" },
        { id:"wat-tha-mai", name:"วัดท่าไม้", desc:"หลวงพ่อเงิน เสริมโชคลาภ", location:"จ.นครปฐม", icon:"bi-currency-exchange", type:"good" },
        { id:"wat-mahathat-nakhon", name:"วัดพระมหาธาตุวรมหาวิหาร", desc:"เสริมบุญ การค้า", location:"จ.นครศรีธรรมราช", icon:"bi-bell", type:"good" },
        { id:"wat-chedi-luang", name:"วัดเจดีย์หลวง", desc:"เสริมอำนาจ บารมี", location:"จ.เชียงใหม่", icon:"bi-columns-gap", type:"good" },
        { id:"wat-phra-that-panom", name:"วัดพระธาตุพนม", desc:"เสริมบุญบารมี โชคลาภ", location:"จ.นครพนม", icon:"bi-award", type:"good" },
        { id:"wat-lampang-luang", name:"วัดพระธาตุลำปางหลวง", desc:"เสริมดวงชะตา", location:"จ.ลำปาง", icon:"bi-cone-striped", type:"good" },
        { id:"wat-kalyanamitr", name:"วัดกัลยาณมิตร", desc:"เสริมมิตรภาพ ธุรกิจ", location:"เขตธนบุรี กรุงเทพฯ", icon:"bi-people", type:"good" },
        /* --- แก้เคล็ด/คุ้มครอง (18) --- */
        { id:"wat-rakhang", name:"วัดระฆังโฆสิตาราม", desc:"แก้เคล็ด ปัดเป่าสิ่งไม่ดี", location:"เขตบางกอกน้อย กรุงเทพฯ", icon:"bi-shield-fill", type:"warn" },
        { id:"wat-bang-phli", name:"วัดบางพลีใหญ่ใน", desc:"หลวงพ่อโต คุ้มครอง", location:"จ.สมุทรปราการ", icon:"bi-heart-fill", type:"warn" },
        { id:"wat-si-mahathat", name:"วัดพระศรีมหาธาตุ", desc:"เสริมกำลังใจ ฝ่าวิกฤต", location:"เขตบางเขน กรุงเทพฯ", icon:"bi-lightning-charge-fill", type:"warn" },
        { id:"wat-saket", name:"วัดสระเกศ (ภูเขาทอง)", desc:"แก้ดวง เสริมสิริมงคล", location:"เขตป้อมปราบฯ กรุงเทพฯ", icon:"bi-triangle", type:"warn" },
        { id:"wat-pho", name:"วัดพระเชตุพนฯ (วัดโพธิ์)", desc:"แก้เคล็ด เสริมสุขภาพ", location:"เขตพระนคร กรุงเทพฯ", icon:"bi-tree", type:"warn" },
        { id:"wat-paknam", name:"วัดปากน้ำภาษีเจริญ", desc:"สะเดาะเคราะห์ เสริมดวง", location:"เขตภาษีเจริญ กรุงเทพฯ", icon:"bi-water", type:"warn" },
        { id:"wat-ratchanadda", name:"วัดราชนัดดาราม", desc:"แก้ปีชง เสริมดวง", location:"เขตพระนคร กรุงเทพฯ", icon:"bi-pentagon", type:"warn" },
        { id:"wat-hua-lamphong", name:"วัดหัวลำโพง", desc:"แก้เคล็ด สะเดาะเคราะห์", location:"เขตบางรัก กรุงเทพฯ", icon:"bi-hammer", type:"warn" },
        { id:"wat-tham-suea", name:"วัดถ้ำเสือ", desc:"เสริมกำลังใจ พลังจิต", location:"จ.กาญจนบุรี", icon:"bi-diamond", type:"warn" },
        { id:"wat-khao-wang", name:"วัดเขาวัง", desc:"แก้ดวงตก เสริมบารมี", location:"จ.ราชบุรี", icon:"bi-cloud-sun", type:"warn" },
        { id:"wat-phra-bat-namphu", name:"วัดพระบาทน้ำพุ", desc:"แก้เคล็ด ทำบุญใหญ่", location:"จ.สระบุรี", icon:"bi-droplet", type:"warn" },
        { id:"wat-pa-luang-ta-bua", name:"วัดป่าหลวงตาบัว", desc:"เสริมกำลังใจ สมาธิ", location:"จ.กาญจนบุรี", icon:"bi-flower2", type:"warn" },
        { id:"wat-kasem-samran", name:"วัดเกษมสำราญ", desc:"แก้ดวง เปลี่ยนชะตา", location:"จ.อุดรธานี", icon:"bi-arrow-clockwise", type:"warn" },
        { id:"wat-doi-tung", name:"วัดพระธาตุดอยตุง", desc:"แก้ดวง เสริมบุญ", location:"จ.เชียงราย", icon:"bi-flag", type:"warn" },
        { id:"wat-chana-songkhram", name:"วัดชนะสงคราม", desc:"ชนะอุปสรรค ศัตรู", location:"เขตพระนคร กรุงเทพฯ", icon:"bi-trophy", type:"warn" },
        { id:"wat-cho-hae", name:"วัดพระธาตุช่อแฮ", desc:"แก้ดวงปีเกิด", location:"จ.แพร่", icon:"bi-star", type:"warn" },
        { id:"wat-pho-chai", name:"วัดโพธิ์ชัย", desc:"แก้เคล็ด ป้องกันภัย", location:"จ.หนองคาย", icon:"bi-shield-check", type:"warn" },
        { id:"wat-pa-mok", name:"วัดป่าโมกข์วรวิหาร", desc:"สะเดาะเคราะห์", location:"จ.อ่างทอง", icon:"bi-feather", type:"warn" }
    ];

    /* ========== DAY DATA ========== */
    var DAY_DATA = [
        { name:"วันอาทิตย์", colors:[
            { hex:"#dc2626", name:"สีแดง", icon:"bi-droplet-fill", desc:"โชคลาภ อำนาจ", tag:"การเงิน" },
            { hex:"#f97316", name:"สีส้ม", icon:"bi-brightness-high", desc:"พลังงาน ความสำเร็จ", tag:"ธุรกิจ" }
        ], fortune:"วันแห่งพลังงานสีแดงแรงกล้า เหมาะกับการตัดสินใจเรื่องการลงทุนและการขยายธุรกิจ ดวงการเงินต้องใช้วิจารณญาณ ระวังอย่าใจร้อน" },
        { name:"วันจันทร์", colors:[
            { hex:"#f59e0b", name:"สีเหลือง", icon:"bi-sun-fill", desc:"ปัญญา ความรู้สึกดี", tag:"โชคลาภ" },
            { hex:"#fbbf24", name:"สีครีม", icon:"bi-circle-half", desc:"ผ่อนคลาย สงบใจ", tag:"การงาน" }
        ], fortune:"สีเหลืองของปัญญาส่องความสว่างวันจันทร์ เหมาะกับการจัดการธุรกิจและการขยายลงทุน ดวงการเงินต้องใจเย็นและมีปัญญา" },
        { name:"วันอังคาร", colors:[
            { hex:"#ec4899", name:"สีชมพู", icon:"bi-heart-fill", desc:"ความรัก มนุษยสัมพันธ์", tag:"มนุษยสัมพันธ์" },
            { hex:"#a855f7", name:"สีม่วง", icon:"bi-gem", desc:"ปัญญาตราสาร ความพิเศษ", tag:"ความพิเศษ" }
        ], fortune:"สีชมพูและม่วงส่องสว่างให้ก้าวหน้าในการสร้างความสัมพันธ์ทางธุรกิจ วันนี้เหมาะกับการพบปะเครือข่ายธุรกิจ ระวังการใช้จ่ายเกินตัว" },
        { name:"วันพุธ", colors:[
            { hex:"#16a34a", name:"สีเขียว", icon:"bi-tree-fill", desc:"เจริญรุ่งเรือง มั่งคั่ง", tag:"การเงิน" },
            { hex:"#84cc16", name:"สีเขียวอ่อน", icon:"bi-flower1", desc:"ความสดใหม่ สุขภาพดี", tag:"โชคดี" }
        ], fortune:"สีเขียวแห่งความมั่งคั่งส่องพลังวันพุธ เหมาะกับการบริหารเงิน ลงทุนอสังหาริมทรัพย์ และขยายช่องทางธุรกิจ ดวงการเงินสดใส" },
        { name:"วันพฤหัสบดี", colors:[
            { hex:"#f97316", name:"สีส้ม", icon:"bi-fire", desc:"พลัง ความกล้าหาญ", tag:"ความกล้าหาญ" },
            { hex:"#d97706", name:"สีทอง", icon:"bi-stars", desc:"ความร่ำรวย โชคลาภ", tag:"โชคลาภ" }
        ], fortune:"สีทองของวันพฤหัสนำโชคลาภและความก้าวหน้ามาให้ เหมาะกับการเจรจาสินเชื่อและการลงทุนสำคัญ บริหารเงินอย่างรอบคอบ ดวงการเงินดี" },
        { name:"วันศุกร์", colors:[
            { hex:"#3b82f6", name:"สีฟ้า", icon:"bi-water", desc:"สันติ ความสมดุลทางใจ", tag:"การค้า" },
            { hex:"#06b6d4", name:"สีฟ้าเขียว", icon:"bi-wind", desc:"ช่องทางการค้าใหม่", tag:"อนาคต" }
        ], fortune:"วันศุกร์สีฟ้าเปิดความสงบและความสมดุลทางใจ เหมาะกับการนำเสนองานและโปรเซนต์ธุรกิจ ดวงการจัดการงานที่ดี" },
        { name:"วันเสาร์", colors:[
            { hex:"#7c3aed", name:"สีม่วงเข้ม", icon:"bi-moon-stars-fill", desc:"อำนาจ ผู้นำทีม", tag:"ผู้นำความคิด" },
            { hex:"#1e3a8a", name:"สีกรมท่า", icon:"bi-shield-fill", desc:"มั่นคง ปัญญา", tag:"ความน่าเชื่อถือ" }
        ], fortune:"สีม่วงเข้มส่งพลังให้วันเสาร์เหมาะกับการวางแผนระยะยาวและความน่าเชื่อถือ เหมาะกับการวางแผนยุทธศาสตร์ธุรกิจระยะยาว" }
    ];

    /* ========== NUMEROLOGY ========== */
    var NUMEROLOGY = {
        1: { stars:5, text:"เลข 1 มีพลังแห่งผู้นำ คุณมีความสามารถในการบริหารจัดการและตัดสินใจที่ยอดเยี่ยม ธุรกิจของคุณกำลังเติบโต ดวงการเงินแรงมาก เหมาะกับการขยายธุรกิจและการลงทุนใหม่" },
        2: { stars:4, text:"เลข 2 มีพลังแห่งความร่วมมือ คุณเหมาะกับการทำธุรกิจแบบหุ้นส่วน หาพันธมิตรลงทุน ดวงการเงินจะมาจากความร่วมมือกับผู้อื่น เหมาะกับการเจรจาต่อรองและสร้างเครือข่าย" },
        3: { stars:5, text:"เลข 3 มีพลังแห่งความคิดสร้างสรรค์และการสื่อสาร คุณโดดเด่นด้านการตลาดและการนำเสนอ ธุรกิจดิจิทัลและโซเชียลมีเดียเหมาะกับคุณมาก ดวงการเงินสดใส" },
        4: { stars:3, text:"เลข 4 มีพลังแห่งความมั่นคงและความละเอียดรอบคอบ คุณเหมาะกับธุรกิจที่มีโครงสร้างชัดเจน ดวงการเงินมั่นคงแต่ต้องอดทน ค่อยๆ สร้างฐานให้แข็งแกร่ง" },
        5: { stars:4, text:"เลข 5 มีพลังแห่งการปรับตัวและความหลากหลาย คุณเหมาะกับธุรกิจที่เปลี่ยนแปลงได้เร็ว เช่น ค้าขาย นำเข้า-ส่งออก ดวงการเงินมีโอกาสจากหลายช่องทาง" },
        6: { stars:4, text:"เลข 6 มีพลังแห่งการรับผิดชอบและการบริการ คุณเหมาะกับธุรกิจดูแลผู้คน เช่น อาหาร สุขภาพ ท่องเที่ยว ดวงการเงินดีจากการให้บริการที่ยอดเยี่ยม" },
        7: { stars:4, text:"เลข 7 มีพลังแห่งปัญญาและการวิเคราะห์ คุณเหมาะกับธุรกิจด้านความรู้เชิงลึก เช่น เทคโนโลยี วิจัย ที่ปรึกษา ดวงการเงินมาจากความเชี่ยวชาญ" },
        8: { stars:5, text:"เลข 8 มีพลังแห่งอำนาจและความมั่งคั่ง ถือเป็นเลขนักธุรกิจโดยแท้ คุณมีพลังในการบริหารสร้างความมั่งคั่ง ดวงการเงินแรงมาก เหมาะกับการลงทุนขนาดใหญ่" },
        9: { stars:4, text:"เลข 9 มีพลังแห่งความเสียสละและความมีน้ำใจ คุณเหมาะกับธุรกิจสร้างสรรค์สังคม หรือธุรกิจที่ดูแลรักษาผู้อื่น ดวงการเงินดีจากบุญบารมี" }
    };

    /* ========== TAROT CARDS (22 ใบ) ========== */
    var TAROT_CARDS = [
        { icon:"bi-person-walking", num:"0", name:"คนโง่", meaning:"เริ่มต้นใหม่ โอกาส", isWarning:false,
          detail:"ไพ่คนโง่ส่องความหวังใหม่ นี่คือโอกาสทองในการเริ่มต้นธุรกิจหรือโปรเจกต์ใหม่ กล้าก้าวออกจากพื้นที่ปลอดภัย ความกล้าและความสดใหม่จะนำผลตอบแทนทางการเงินที่ดีมาให้คุณ" },
        { icon:"bi-lightning-charge-fill", num:"I", name:"นักมายากล", meaning:"ทักษะ ความสามารถ", isWarning:false,
          detail:"คุณมีทุกอย่างที่จำเป็นสำหรับความสำเร็จ ทักษะ ความคิดสร้างสรรค์ และพลังงานล้วนอยู่ในมือคุณ ถึงเวลาลงมือทำโปรเจกต์ที่วางแผนไว้ การเงินจะตอบสนองต่อความพยายามของคุณ" },
        { icon:"bi-flower1", num:"III", name:"จักรพรรดินี", meaning:"ความอุดม ผลิดอก", isWarning:false,
          detail:"ความอุดมสมบูรณ์กำลังมาหาคุณ ธุรกิจมีการเติบโตอย่างต่อเนื่องและมั่นคง รายได้หลายช่องทางกำลังพัฒนา เหมาะสำหรับการขยายกิจการ รับสินค้าใหม่ หรือลงทุนระยะยาว" },
        { icon:"bi-shield-fill", num:"IV", name:"จักรพรรดิ", meaning:"ความมั่นคง อำนาจ", isWarning:false,
          detail:"คุณมีความมั่นคงและอำนาจในการควบคุมทิศทางธุรกิจ เหมาะกับการวางโครงสร้างองค์กรและการบริหารทีม การเงินมีความแข็งแกร่ง เหมาะสำหรับการขอสินเชื่อหรือขยายธุรกิจในระยะยาว" },
        { icon:"bi-heart-fill", num:"VI", name:"คนรัก", meaning:"พันธมิตร ตัดสินใจ", isWarning:false,
          detail:"การร่วมมือกับพันธมิตรทางธุรกิจจะนำมาซึ่งผลลัพธ์ที่ดี ช่วงนี้เหมาะสำหรับการเจรจาต่อรอง ลงนามสัญญา หรือหาพันธมิตรใหม่ การเงินได้รับแรงสนับสนุนจากความสัมพันธ์ที่ดี" },
        { icon:"bi-trophy-fill", num:"VII", name:"รถม้าศึก", meaning:"ชัยชนะ มุ่งหน้า", isWarning:false,
          detail:"ชัยชนะอยู่ตรงหน้าคุณ ความมุ่งมั่นและวินัยจะพาธุรกิจไปถึงเป้าหมาย เหมาะกับการขยายตลาดและแข่งขัน การเงินจะดีขึ้นจากความพยายามที่สม่ำเสมอ จงก้าวต่อไปไม่หยุดยั้ง" },
        { icon:"bi-gem", num:"VIII", name:"ความแข็งแกร่ง", meaning:"พลังใจ ความอดทน", isWarning:false,
          detail:"พลังใจและความอดทนของคุณคือกุญแจสู่ความสำเร็จ ธุรกิจอาจมีความท้าทาย แต่คุณมีพลังที่จะผ่านมันได้ การเงินต้องการความมุ่งมั่นต่อเนื่อง ผลตอบแทนจะมาตามเวลา" },
        { icon:"bi-arrow-repeat", num:"X", name:"วงล้อโชคชะตา", meaning:"โชค โอกาส", isWarning:false,
          detail:"วงล้อโชคชะตากำลังหมุนมาหาคุณ โอกาสทองทางธุรกิจและการเงินกำลังจะมาถึง เปิดรับสิ่งใหม่ๆ และจับโอกาสให้ทัน การเงินมีแนวโน้มบวกอย่างน่าตื่นเต้น" },
        { icon:"bi-bank2", num:"XI", name:"ความยุติธรรม", meaning:"สัญญา ข้อตกลง", isWarning:false,
          detail:"สัญญาและข้อตกลงทางธุรกิจจะเป็นผลดีสำหรับคุณ เหมาะสำหรับการลงนามในเอกสารสำคัญ เจรจาสินเชื่อ หรือยุติข้อพิพาท การเงินจะมีความโปร่งใสและยุติธรรม" },
        { icon:"bi-water", num:"XIV", name:"ความสุขุม", meaning:"สมดุล ปรับตัว", isWarning:false,
          detail:"ความสมดุลระหว่างการลงทุนและการใช้จ่ายคือกุญแจสำคัญตอนนี้ บริหารกระแสเงินสดอย่างรอบคอบ ค่อยๆ ปรับกลยุทธ์ธุรกิจ การเงินจะมีเสถียรภาพจากการวางแผนที่ดี" },
        { icon:"bi-stars", num:"XVII", name:"ดาว", meaning:"ความหวัง อนาคต", isWarning:false,
          detail:"ดาวแห่งความหวังส่องทางคุณ มีโอกาสทางธุรกิจใหม่ๆ รออยู่ข้างหน้า ความพยายามที่ผ่านมาจะเริ่มให้ผลตอบแทน การเงินมีแนวโน้มดีขึ้นอย่างต่อเนื่อง จงมุ่งมั่นต่อไป" },
        { icon:"bi-sun-fill", num:"XIX", name:"ดวงอาทิตย์", meaning:"ความสำเร็จ รุ่งเรือง", isWarning:false,
          detail:"แสงแห่งความสำเร็จส่องสว่างให้คุณ ธุรกิจกำลังเติบโตอย่างแข็งแกร่ง ลูกค้าและคู่ค้าให้ความไว้วางใจ การเงินมีทิศทางที่ดีเยี่ยม โอกาสขยายธุรกิจกำลังใกล้เข้ามา" },
        { icon:"bi-award-fill", num:"XX", name:"การพิพากษา", meaning:"ประเมิน ตัดสิน", isWarning:false,
          detail:"ถึงเวลาประเมินผลและตัดสินใจสำคัญ ทบทวนธุรกิจและแผนการเงิน สิ่งที่ทำมาอย่างถูกต้องจะได้รับผลตอบแทน โอกาสใหม่จะเปิดขึ้นจากการตัดสินใจที่ถูกต้องและมีวิสัยทัศน์" },
        { icon:"bi-globe", num:"XXI", name:"โลก", meaning:"สมบูรณ์ สำเร็จ", isWarning:false,
          detail:"คุณกำลังอยู่ในช่วงสมบูรณ์แบบที่สุด ธุรกิจที่ลงทุนไปกำลังผลิดอกออกผล โอกาสขยายตลาดหรือช่องทางใหม่กำลังเปิดรับ การเงินมีความมั่นคงสูง โชคมาจากทุกทิศทาง" },
        /* --- ไพ่ควรระวัง (8) --- */
        { icon:"bi-eye-fill", num:"II", name:"นักบวชหญิง", meaning:"ข้อมูลซ่อนเร้น ระวัง", isWarning:true,
          detail:"ธุรกิจมีศักยภาพแต่ยังมีข้อมูลที่ยังไม่ชัดเจน ควรศึกษาข้อมูลให้ครบก่อนตัดสินใจลงทุน การเงินต้องการความรอบคอบ อย่าเพิ่งใจร้อน",
          warning:"ระวังสัญญาที่มีเงื่อนไขซ่อนเร้น ตรวจสอบเอกสารทางการเงินให้ครบถ้วนก่อนลงนาม หลีกเลี่ยงการตัดสินใจโดยขาดข้อมูลที่สมบูรณ์" },
        { icon:"bi-book-fill", num:"V", name:"พระสงฆ์", meaning:"กฎระเบียบ ข้อบังคับ", isWarning:true,
          detail:"ช่วงนี้ธุรกิจต้องเผชิญกับข้อกำหนดและกฎระเบียบต่างๆ อาจมีภาระด้านเอกสารหรือการขออนุมัติ การเงินต้องผ่านขั้นตอนที่ซับซ้อน",
          warning:"ระวังการละเมิดกฎระเบียบทางธุรกิจหรือสัญญาที่ผูกมัดระยะยาว ตรวจสอบเงื่อนไขดอกเบี้ยและค่าธรรมเนียมก่อนรับสินเชื่อ" },
        { icon:"bi-lightbulb-fill", num:"IX", name:"ผู้สันโดษ", meaning:"ถดถอย หยุดพัก", isWarning:true,
          detail:"ช่วงนี้เหมาะกับการทบทวนแผนธุรกิจมากกว่าการขยายตัว การเงินยังไม่เอื้ออำนวยต่อการลงทุนใหญ่ ควรรักษากระแสเงินสดให้มั่นคงก่อน",
          warning:"ระวังการโดดเดี่ยวตัวเองจากพันธมิตรทางธุรกิจ ไม่ควรตัดสินใจทางการเงินครั้งใหญ่ในช่วงนี้ ระมัดระวังการลงทุนในสินทรัพย์เสี่ยง" },
        { icon:"bi-hourglass-split", num:"XII", name:"ชายถูกแขวน", meaning:"ชะงักงัน รอคอย", isWarning:true,
          detail:"ธุรกิจอาจต้องหยุดชะงักชั่วคราวหรือรอผลตอบแทนที่ล่าช้า ยังไม่ใช่เวลาเร่งรีบตัดสินใจ การเงินต้องการความอดทน",
          warning:"ระวังการนำเงินสดออกจากธุรกิจในช่วงที่สภาพคล่องต่ำ ไม่ควรกู้ยืมเพิ่มเติมในขณะที่กระแสเงินสดยังไม่เสถียร" },
        { icon:"bi-activity", num:"XIII", name:"มรณะ", meaning:"เปลี่ยนแปลง สิ้นสุด", isWarning:true,
          detail:"การเปลี่ยนแปลงครั้งใหญ่กำลังจะเกิดขึ้น ธุรกิจบางส่วนอาจต้องยุติหรือปรับเปลี่ยนอย่างมีนัยสำคัญ แต่นี่คือโอกาสเริ่มต้นใหม่ที่ดีกว่า",
          warning:"ระวังการสูญเสียรายได้หลักหรือคู่ค้าสำคัญ วางแผนสำรองทางการเงินไว้ล่วงหน้า ควรพบที่ปรึกษาทางการเงินเพื่อวางแผนรับมือ" },
        { icon:"bi-lock-fill", num:"XV", name:"ปีศาจ", meaning:"ติดกับดัก หนี้สิน", isWarning:true,
          detail:"ระวังการติดกับดักทางการเงินหรือความสัมพันธ์ทางธุรกิจที่ไม่ดี อาจมีแรงกดดันด้านหนี้สินหรือภาระที่หนักเกินไป ต้องหาทางออกอย่างรอบคอบ",
          warning:"ระวังหนี้สินที่สะสม ดอกเบี้ยที่พอกพูน และสัญญาที่ผูกมัดอย่างไม่เป็นธรรม หลีกเลี่ยงการกู้ยืมนอกระบบ บสย. พร้อมให้คำปรึกษาด้านการจัดการหนี้" },
        { icon:"bi-buildings-fill", num:"XVI", name:"หอคอย", meaning:"วิกฤต ความไม่คาดฝัน", isWarning:true,
          detail:"อาจมีเหตุการณ์ไม่คาดฝันกระทบธุรกิจและการเงินอย่างฉับพลัน ต้องเตรียมแผนรับมือวิกฤตให้พร้อม การเงินต้องระมัดระวังเป็นพิเศษ",
          warning:"ระวังการสูญเสียเงินลงทุนก้อนใหญ่จากเหตุการณ์ที่ไม่คาดฝัน สำรองเงินฉุกเฉิน 3-6 เดือน รีบปรึกษาผู้เชี่ยวชาญทางการเงินทันทีหากพบสัญญาณอันตราย" },
        { icon:"bi-moon-stars-fill", num:"XVIII", name:"ดวงจันทร์", meaning:"ภาพลวงตา ความไม่แน่นอน", isWarning:true,
          detail:"สถานการณ์ทางธุรกิจยังไม่ชัดเจน อาจมีข้อมูลที่เข้าใจผิดหรือถูกหลอกลวง การเงินต้องการความระมัดระวังเป็นพิเศษ ตรวจสอบทุกอย่างสองชั้น",
          warning:"ระวังการถูกหลอกลวงทางการเงิน การลงทุนที่ให้ผลตอบแทนสูงผิดปกติ และสัญญาที่ไม่โปร่งใส ควรปรึกษาผู้เชี่ยวชาญก่อนตัดสินใจทุกครั้ง" }
    ];

    /* ========== CALENDAR ALGORITHM ========== */
    var THAI_MONTHS = ["มกราคม","กุมภาพันธ์","มีนาคม","เมษายน","พฤษภาคม","มิถุนายน",
                       "กรกฎาคม","สิงหาคม","กันยายน","ตุลาคม","พฤศจิกายน","ธันวาคม"];
    var calYear, calMonth;

    function getMoonAge(date) {
        var knownNewMoon = new Date(2000, 0, 6, 0, 18, 0);
        var lunarCycle = 29.530588853;
        var diffDays = (date.getTime() - knownNewMoon.getTime()) / 86400000;
        var age = diffDays % lunarCycle;
        return age < 0 ? age + lunarCycle : age;
    }

    function getDayScore(date) {
        var score = 0;
        var dowScores = [0, 2, -1, 1, 2, 1, 0];
        score += dowScores[date.getDay()];
        var moonAge = getMoonAge(date);
        if (moonAge <= 14.76) {
            score += moonAge >= 13 ? 3 : moonAge >= 7 ? 2 : 1;
        } else {
            score += moonAge >= 28 ? 1 : 0;
        }
        var dn = date.getDate(), ds = dn;
        while (ds > 9) { var s=0; while(ds>0){s+=ds%10;ds=Math.floor(ds/10);} ds=s; }
        if ([1,3,6,8,9].indexOf(ds) >= 0) score += 1;
        else if ([4,7].indexOf(ds) >= 0) score -= 1;
        var lunarDay = Math.floor(moonAge);
        if (lunarDay===7||lunarDay===14||lunarDay===22||lunarDay===29) score += 1;
        return score;
    }

    function getDayLevel(score) {
        if (score >= 5) return "great";
        if (score >= 3) return "good";
        if (score >= 1) return "normal";
        return "caution";
    }

    /* ========== INIT ========== */
    document.addEventListener("DOMContentLoaded", function () {
        renderTodayLabel();
        renderLuckyColor();
        renderTarotGrid();
        initCalendar();
        updateDayQuality();
    });

    /* ========== HEADER & DAY QUALITY ========== */
    function updateDayQuality() {
        var score = getDayScore(new Date());
        var level = getDayLevel(score);
        var icon = document.getElementById("headerIcon");
        var badge = document.getElementById("dayQualityBadge");
        var sparkles = document.getElementById("headerSparkles");
        var miniStars = document.getElementById("headerMiniStars");
        var goodStars = [
            {x:-30,y:10,sz:18},{x:95,y:15,sz:20},{x:-22,y:60,sz:16},{x:100,y:55,sz:17},{x:40,y:-12,sz:15}
        ];
        var greatStars = [
            {x:-38,y:5,sz:22},{x:105,y:10,sz:24},{x:-30,y:58,sz:18},{x:110,y:52,sz:20},
            {x:40,y:-18,sz:19},{x:-15,y:85,sz:16},{x:85,y:82,sz:18},{x:55,y:90,sz:15},
            {x:-35,y:35,sz:14},{x:112,y:35,sz:16}
        ];
        miniStars.innerHTML = "";
        if (level === "great") {
            icon.style.animation = "icon-twinkle-great 1.8s ease-in-out infinite";
            badge.className = "day-quality-badge great";
            badge.innerHTML = '<i class="bi bi-star-fill"></i> วันนี้วันดีมาก!';
            badge.style.display = "flex";
            sparkles.style.display = "block";
            for (var i=0; i<greatStars.length; i++) {
                var p = greatStars[i];
                miniStars.innerHTML += '<i class="bi bi-star-fill hora-mini-star" style="left:'+p.x+'px;top:'+p.y+'px;font-size:'+p.sz+'px;animation:mini-star-great '+(1.6+i*0.25)+'s '+(i*0.2)+'s ease-in-out infinite;"></i>';
            }
        } else if (level === "good") {
            icon.style.animation = "icon-twinkle-good 2s ease-in-out infinite";
            badge.className = "day-quality-badge good";
            badge.innerHTML = '<i class="bi bi-star-fill"></i> วันนี้เป็นวันดี';
            badge.style.display = "flex";
            sparkles.style.display = "none";
            for (var j=0; j<goodStars.length; j++) {
                var q = goodStars[j];
                miniStars.innerHTML += '<i class="bi bi-star-fill hora-mini-star" style="left:'+q.x+'px;top:'+q.y+'px;font-size:'+q.sz+'px;animation:mini-star-good '+(2+j*0.3)+'s '+(j*0.3)+'s ease-in-out infinite;"></i>';
            }
        } else {
            icon.style.animation = "icon-twinkle 2.2s ease-in-out infinite";
            badge.style.display = "none";
            sparkles.style.display = "none";
        }
    }

    function renderTodayLabel() {
        var days = ["วันอาทิตย์","วันจันทร์","วันอังคาร","วันพุธ","วันพฤหัสบดี","วันศุกร์","วันเสาร์"];
        var months = ["ม.ค.","ก.พ.","มี.ค.","เม.ย.","พ.ค.","มิ.ย.","ก.ค.","ส.ค.","ก.ย.","ต.ค.","พ.ย.","ธ.ค."];
        var d = new Date();
        document.getElementById("todayLabel").textContent =
            days[d.getDay()] + " วันที่ " + d.getDate() + " " + months[d.getMonth()] + " " + (d.getFullYear()+543);
    }

    /* ========== LUCKY COLOR ========== */
    function renderLuckyColor() {
        var data = DAY_DATA[new Date().getDay()];
        var html = "";
        data.colors.forEach(function(c) {
            html += '<div class="lucky-color-item"><div class="lucky-color-swatch" style="background:'+c.hex+';"><i class="bi '+c.icon+'"></i></div>' +
                '<div class="lucky-color-info"><div class="lucky-color-name">'+c.name+'</div><div class="lucky-color-desc">'+c.desc+'</div>' +
                '<span class="lucky-color-tag">'+c.tag+'</span></div></div>';
        });
        document.getElementById("luckyColorRow").innerHTML = html;
        document.getElementById("luckyColorFortune").textContent = data.fortune;
    }

    /* ========== CALENDAR ========== */
    function initCalendar() {
        var now = new Date();
        calYear = now.getFullYear();
        calMonth = now.getMonth();
        renderCalendar();
    }
    function calPrev() { calMonth--; if(calMonth<0){calMonth=11;calYear--;} renderCalendar(); document.getElementById("calDetail").style.display="none"; }
    function calNext() { calMonth++; if(calMonth>11){calMonth=0;calYear++;} renderCalendar(); document.getElementById("calDetail").style.display="none"; }

    function renderCalendar() {
        document.getElementById("calMonthLabel").textContent = THAI_MONTHS[calMonth] + " " + (calYear+543);
        var firstDay = new Date(calYear, calMonth, 1).getDay();
        var startOffset = (firstDay + 6) % 7;
        var daysInMonth = new Date(calYear, calMonth+1, 0).getDate();
        var today = new Date();
        var html = "";
        for (var i=0; i<startOffset; i++) html += '<div class="cal-day empty"></div>';
        for (var d=1; d<=daysInMonth; d++) {
            var date = new Date(calYear, calMonth, d);
            var level = getDayLevel(getDayScore(date));
            var isToday = (date.toDateString() === today.toDateString());
            html += '<div class="cal-day '+level+(isToday?' today':'')+'" onclick="showDayDetail('+calYear+','+calMonth+','+d+')">'+d+'</div>';
        }
        document.getElementById("calGrid").innerHTML = html;
    }

    function showDayDetail(y, m, d) {
        var date = new Date(y, m, d);
        var score = getDayScore(date);
        var level = getDayLevel(score);
        var moonAge = getMoonAge(date);
        var isWaxing = moonAge <= 14.76;
        var lunarDay = Math.floor(isWaxing ? moonAge : moonAge - 14.76) + 1;
        var days = ["อาทิตย์","จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์"];
        var levelNames = {great:"ดีมาก",good:"ดี",normal:"ปกติ",caution:"ควรระวัง"};
        var levelColors = {great:"#92400e",good:"#166534",normal:"#1344a0",caution:"#991b1b"};
        var activities = {
            great:["เปิดร้าน เปิดธุรกิจใหม่","ลงนามสัญญาสำคัญ","ยื่นขอสินเชื่อ","ขยายธุรกิจ ลงทุนใหญ่"],
            good:["เจรจาธุรกิจ พบลูกค้า","ลงทุนระยะสั้น","ปรับปรุงร้าน","ยื่นเอกสารสำคัญ"],
            normal:["ทำงานตามปกติ","วางแผนธุรกิจ","เตรียมเอกสาร","ศึกษาข้อมูลก่อนลงทุน"],
            caution:["ทบทวนแผนธุรกิจ","หลีกเลี่ยงการลงนามสัญญา","ระวังการใช้จ่าย","ปรึกษาผู้เชี่ยวชาญก่อนตัดสินใจ"]
        };
        var starCount = score>=5?5:score>=3?4:score>=1?3:2;

        var dn = date.getDate(), ds = dn;
        while (ds > 9) { var s=0; while(ds>0){s+=ds%10;ds=Math.floor(ds/10);} ds=s; }
        var numScore = ([1,3,6,8,9].indexOf(ds)>=0) ? 1 : ([4,7].indexOf(ds)>=0) ? -1 : 0;
        var rawLunarDay = Math.floor(moonAge);
        var isWanPhra = (rawLunarDay===7||rawLunarDay===14||rawLunarDay===22||rawLunarDay===29);

        var html = '<div style="text-align:center; margin-bottom:10px; padding-bottom:10px; border-bottom:1px solid #e8f0fe;">';
        html += '<div style="font-size:14px; font-weight:700; color:#0a2463;">วัน'+days[date.getDay()]+'ที่ '+d+' '+THAI_MONTHS[m]+' '+(y+543)+'</div>';
        html += '<div style="font-size:12px; font-weight:600; color:'+levelColors[level]+'; margin-top:4px;"><i class="bi '+(level==="caution"?"bi-exclamation-triangle-fill":"bi-star-fill")+'"></i> '+levelNames[level]+' (คะแนนรวม '+score+')</div>';
        html += '<div style="margin-top:4px;">'+buildStars(starCount)+'</div>';
        html += '</div>';

        html += '<div style="font-size:12px; font-weight:700; color:#0a2463; margin-bottom:6px; display:flex; align-items:center; gap:5px;"><i class="bi bi-clipboard-data" style="color:#1344a0;"></i> ปัจจัยที่ประเมิน</div>';
        var numLabel = numScore>0?"เลขมงคล":numScore<0?"เลขควรระวัง":"เลขปานกลาง";
        var factors = ['วัน'+days[date.getDay()], (isWaxing?'ข้างขึ้น':'ข้างแรม')+' '+lunarDay+' ค่ำ', numLabel];
        if (isWanPhra) factors.push('วันพระ');
        html += '<div style="display:flex; flex-wrap:wrap; gap:6px; margin-bottom:10px;">';
        factors.forEach(function(f) {
            html += '<span style="font-size:10px; background:#e8f0fe; color:#1344a0; padding:3px 8px; border-radius:12px; font-weight:600;">'+f+'</span>';
        });
        html += '</div>';

        html += '<div style="font-size:12px; font-weight:600; color:#0a2463; margin-bottom:6px;">'+(level==="caution"?"สิ่งที่ควรระวัง":"กิจกรรมที่แนะนำ")+'</div>';
        var acts = activities[level];
        var actIcon = level==="caution"?"bi-exclamation-circle":"bi-check-circle-fill";
        acts.forEach(function(a) {
            html += '<div style="font-size:11px; color:#334155; padding:3px 0; display:flex; align-items:center; gap:5px;">' +
                '<i class="bi '+actIcon+'" style="color:'+levelColors[level]+'; font-size:12px;"></i> '+a+'</div>';
        });
        var el = document.getElementById("calDetail");
        el.innerHTML = html;
        el.style.display = "block";
    }

    /* ========== TABS ========== */
    function switchTopTab(tab) {
        ["color","calendar"].forEach(function(t) {
            document.getElementById("top-tab-"+t).classList.toggle("active", t===tab);
            document.getElementById("top-btn-"+t).classList.toggle("active", t===tab);
        });
    }
    function switchTab(tab) {
        ["phone","tarot"].forEach(function(t) {
            document.getElementById("tab-"+t).classList.toggle("active", t===tab);
            document.getElementById("tab-btn-"+t).classList.toggle("active", t===tab);
        });
    }

    /* ========== TEMPLES ========== */
    function getFixedTemples(seed, type, count) {
        var filtered = TEMPLES.filter(function(t) { return t.type === type; });
        var indices = [];
        var h = Math.abs(seed) % filtered.length;
        for (var i = 0; i < count; i++) {
            while (indices.indexOf(h) !== -1) h = (h + 1) % filtered.length;
            indices.push(h);
            h = (h * 7 + 3) % filtered.length;
        }
        return indices.map(function(idx) { return filtered[idx]; });
    }

    function renderTemples(temples) {
        var basePath = "views/hora/images/temples/";
        var html = "";
        temples.forEach(function(t) {
            var mapUrl = "https://www.google.com/maps/search/?api=1&query=" + encodeURIComponent(t.name + " " + t.location);
            html += '<div class="temple-item">' +
                '<div class="temple-img-wrap">' +
                '<img src="'+basePath+t.id+'.jpg" onerror="this.style.display=\'none\';this.nextElementSibling.style.display=\'flex\';" />' +
                '<div class="temple-img-fallback" style="display:none;"><i class="bi '+t.icon+'"></i></div>' +
                '</div>' +
                '<div>' +
                '<div class="temple-name">'+t.name+'</div>' +
                '<div class="temple-desc">'+t.desc+'</div>' +
                '<div class="temple-location"><i class="bi bi-geo-alt" style="font-size:9px;"></i> '+t.location+'</div>' +
                '<a class="temple-map-link" href="'+mapUrl+'" target="_blank"><i class="bi bi-map"></i> ดูแผนที่</a>' +
                '</div></div>';
        });
        return html;
    }

    /* ========== UTILITIES ========== */
    function buildStars(n) {
        var s = "";
        for (var i=0; i<5; i++) s += '<i class="bi bi-star'+(i<n?"-fill":"")+'" style="font-size:16px;color:#d97706;margin:0 1px;"></i>';
        return s;
    }

    /* ========== TAROT ========== */
    function renderTarotGrid() {
        var shuffled = TAROT_CARDS.slice().sort(function(){return Math.random()-0.5;});
        var html = "";
        shuffled.forEach(function(card,i) {
            html += '<div class="tarot-card-wrap"><div class="tarot-card" id="tc'+i+'" onclick="flipTarot(this,'+i+')">' +
                '<div class="tarot-back"><div class="tarot-back-pattern"></div><i class="bi bi-stars tarot-back-icon"></i><span class="tarot-back-num">'+card.num+'</span></div>' +
                '<div class="tarot-face"><i class="bi '+card.icon+' tarot-face-icon" style="color:#1344a0;"></i>' +
                '<div class="tarot-face-name">'+card.name+'</div><div class="tarot-face-meaning">'+card.meaning+'</div>' +
                '<div class="tarot-face-star"><i class="bi bi-three-dots"></i></div></div></div></div>';
        });
        document.getElementById("tarotGrid").innerHTML = html;
        window._shuffledTarot = shuffled;
    }

    var tarotPicked = false;
    function flipTarot(el, idx) {
        if (tarotPicked) return;
        tarotPicked = true;
        el.classList.add("flipped");
        setTimeout(function(){showTarotResult(idx);}, 700);
        setTimeout(function(){
            document.querySelectorAll(".tarot-card").forEach(function(c,i){if(i!==idx)c.classList.add("used");});
        }, 200);
    }

    function showTarotResult(idx) {
        var card = window._shuffledTarot[idx];
        var iconColor = card.isWarning ? "#dc2626" : "#1344a0";
        document.getElementById("resultIcon").innerHTML = '<i class="bi '+card.icon+'" style="font-size:52px;color:'+iconColor+';"></i>';
        document.getElementById("resultCardName").textContent = "ไพ่ " + card.name + " (" + card.num + ")";
        document.getElementById("resultText").textContent = card.detail;
        var warnEl = document.getElementById("resultWarning");
        if (card.isWarning && card.warning) {
            document.getElementById("resultWarningText").textContent = card.warning;
            warnEl.style.display = "block";
        } else { warnEl.style.display = "none"; }
        var cardSeed = TAROT_CARDS.indexOf(card);
        var temples = getFixedTemples(cardSeed, card.isWarning ? "warn" : "good", 2);
        document.getElementById("templeList").innerHTML = renderTemples(temples);
        document.getElementById("resultTemples").style.display = "block";
        document.getElementById("tarotResultOverlay").classList.add("show");
    }

    function closeResult() { document.getElementById("tarotResultOverlay").classList.remove("show"); }

    function resetTarot() {
        document.getElementById("tarotResultOverlay").classList.remove("show");
        tarotPicked = false;
        renderTarotGrid();
    }

    /* ========== PHONE FORTUNE ========== */
    function resetPhone() {
        document.getElementById("phoneInput").value = "";
        document.getElementById("phoneResult").style.display = "none";
        document.getElementById("phoneTemples").style.display = "none";
        document.getElementById("phoneInput").focus();
    }

    function readPhoneFortune() {
        var phone = document.getElementById("phoneInput").value.replace(/\D/g, "");
        if (phone.length < 9) { alert("กรุณากรอกเบอร์โทรให้ครบถ้วน"); return; }
        var sum = 0;
        for (var i=0; i<phone.length; i++) sum += parseInt(phone[i]);
        while (sum > 9) { var s2=0; while(sum>0){s2+=sum%10;sum=Math.floor(sum/10);} sum=s2; }
        var data = NUMEROLOGY[sum];
        document.getElementById("phoneNumResult").textContent = sum;
        document.getElementById("phoneStars").innerHTML = buildStars(data.stars);
        document.getElementById("phoneFortuneText").textContent = data.text;
        var temples = getFixedTemples(sum, data.stars >= 4 ? "good" : "warn", 2);
        document.getElementById("phoneTempleList").innerHTML = renderTemples(temples);
        document.getElementById("phoneTemples").style.display = "block";
        var result = document.getElementById("phoneResult");
        result.style.display = "block";
        result.scrollIntoView({behavior:"smooth",block:"nearest"});
    }
</script>
</asp:Content>
