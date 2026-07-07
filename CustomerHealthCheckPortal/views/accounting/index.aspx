<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.accounting.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title>บัญชีรายรับรายจ่าย</title>
    <style>
        .acct-page { background-color: whitesmoke; min-height: 100vh; padding-bottom: 80px; }
        .acct-page > div:first-child { margin-top: 0 !important; }

        @keyframes acct-icon-pulse {
            0%,100% { transform: scale(1); filter: drop-shadow(0 0 6px rgba(5,150,105,0.4)); }
            50%      { transform: scale(1.10); filter: drop-shadow(0 0 18px rgba(5,150,105,0.85)); }
        }
        .acct-header { padding: 10px 16px 16px; text-align: center; position: relative; }
        .acct-header-icon { font-size: 64px; display: block; margin-bottom: 6px; animation: acct-icon-pulse 2.5s ease-in-out infinite; }
        .acct-title    { font-size: 20px; font-weight: 800; color: darkblue; margin: 0; }
        .acct-subtitle { font-size: 11px; color: darkblue; margin-top: 1px; }
        .acct-date-badge {
            display: inline-block; background: rgba(255,255,255,0.88);
            border: 1px solid rgba(19,68,160,0.18); border-radius: 20px;
            padding: 4px 14px; font-size: 12px; font-weight: 700;
            color: #1344a0; margin-top: 8px;
        }
        .rank-badge {
            display: inline-flex; align-items: center; gap: 5px;
            margin-top: 6px; padding: 4px 12px; border-radius: 20px;
            font-size: 12px; font-weight: 800; border: 1.5px solid transparent;
        }
        .rank-0 { background: #f1f5f9; color: #64748b; border-color: #e2e8f0; }
        .rank-1 { background: #dcfce7; color: #166534; border-color: #22c55e; }
        .rank-2 { background: #dbeafe; color: #1e40af; border-color: #3b82f6; }
        .rank-3 { background: #fef3c7; color: #92400e; border-color: #fbbf24; }
        .rank-4 { background: linear-gradient(135deg,#fef9c3,#fde68a); color: #78350f; border-color: #f59e0b;
                  animation: rank-glow 3s ease-in-out infinite; }
        .rank-5 { background: linear-gradient(135deg,#ede9fe,#c4b5fd); color: #4c1d95; border-color: #8b5cf6;
                  animation: rank-glow 2.5s ease-in-out infinite; }
        @keyframes rank-glow {
            0%,100% { box-shadow: 0 0 0 0 rgba(245,158,11,0.25); }
            50%      { box-shadow: 0 0 0 5px rgba(245,158,11,0); }
        }

        /* Tabs */
        .acct-tabs { display: flex; gap: 4px; padding: 0 14px 12px; }
        .acct-tab {
            flex: 1; text-align: center; padding: 7px 2px; font-size: 11px; font-weight: 700;
            border-radius: 18px; cursor: pointer; border: none;
            background: #e8f0fe; color: #1344a0; transition: all 0.18s;
        }
        .acct-tab.active { background: #1344a0; color: #fff; box-shadow: 0 2px 8px rgba(19,68,160,0.3); }

        /* Balance hero card */
        .balance-card {
            background: linear-gradient(135deg,#1344a0 0%,#059669 100%);
            border-radius: 18px; padding: 18px; margin: 0 14px 12px; color: #fff;
            box-shadow: 0 4px 16px rgba(19,68,160,0.25);
        }
        .balance-net  { font-size: 30px; font-weight: 900; letter-spacing: -1px; }
        .balance-lbl  { font-size: 11px; opacity: 0.85; margin-bottom: 2px; }
        .balance-row  { display: flex; gap: 10px; margin-top: 12px; }
        .balance-col  { flex: 1; background: rgba(255,255,255,0.15); border-radius: 12px; padding: 8px 10px; }
        .balance-col-amt { font-size: 15px; font-weight: 800; }
        .balance-col-lbl { font-size: 10px; opacity: 0.85; }

        /* Add buttons */
        .add-btn-row { display: flex; gap: 10px; padding: 0 14px 12px; }
        .add-btn {
            flex: 1; padding: 11px 8px; border-radius: 14px; font-size: 13px; font-weight: 700;
            border: none; cursor: pointer; display: flex; align-items: center; justify-content: center;
            gap: 6px; transition: transform 0.15s;
        }
        .add-btn:active { transform: scale(0.96); }
        .add-income  { background: #dcfce7; color: #166534; border: 1.5px solid #22c55e; }
        .add-expense { background: #fee2e2; color: #991b1b; border: 1.5px solid #ef4444; }

        /* Transaction list */
        .tx-card { background: #fff; border-radius: 14px; margin: 0 14px 8px; overflow: hidden; box-shadow: 0 2px 8px rgba(19,68,160,0.07); }
        .tx-date-hdr { font-size: 11px; font-weight: 700; color: #64748b; padding: 7px 14px 5px; background: #f8faff; }
        .tx-item {
            display: flex; align-items: center; gap: 12px;
            padding: 11px 14px; cursor: pointer; transition: background 0.12s;
        }
        .tx-item:active { background: #f8faff; }
        .tx-divider { height: 1px; background: #f0f6ff; margin: 0 14px; }
        .tx-icon { width: 40px; height: 40px; border-radius: 11px; flex-shrink: 0; display: flex; align-items: center; justify-content: center; font-size: 18px; }
        .tx-icon-inc { background: #dcfce7; }
        .tx-icon-exp { background: #fee2e2; }
        .tx-info { flex: 1; min-width: 0; }
        .tx-cat  { font-size: 13px; font-weight: 700; color: #0c1b3a; }
        .tx-note { font-size: 11px; color: #64748b; margin-top: 1px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; }
        .tx-amt  { font-size: 14px; font-weight: 800; flex-shrink: 0; }
        .tx-amt-inc { color: #16a34a; }
        .tx-amt-exp { color: #dc2626; }
        .tx-del-btn { font-size: 16px; color: #cbd5e1; flex-shrink: 0; padding: 4px; cursor: pointer; }

        /* Empty state */
        .empty-state { text-align: center; padding: 40px 20px; color: #94a3b8; }
        .empty-icon  { font-size: 48px; margin-bottom: 8px; }

        /* Section header */
        .sect-hdr { display: flex; justify-content: space-between; align-items: center; padding: 4px 14px 8px; }
        .sect-hdr-title { font-size: 13px; font-weight: 800; color: #0c1b3a; }
        .sect-hdr-sub   { font-size: 12px; color: #1344a0; font-weight: 600; }

        /* Period nav */
        .period-nav { display: flex; align-items: center; justify-content: center; gap: 18px; padding: 8px 14px 6px; }
        .period-btn { width: 34px; height: 34px; border-radius: 50%; background: #e8f0fe; border: none; cursor: pointer; font-size: 16px; color: #1344a0; }
        .period-lbl { font-size: 15px; font-weight: 800; color: #0c1b3a; min-width: 130px; text-align: center; }

        /* Summary card */
        .summary-card { background: #fff; border-radius: 14px; margin: 0 14px 10px; padding: 14px; box-shadow: 0 2px 8px rgba(19,68,160,0.07); }
        .summary-row { display: flex; gap: 8px; }
        .summary-col { flex: 1; border-radius: 10px; padding: 9px 10px; }
        .sum-inc { background: #f0fdf4; border: 1px solid #bbf7d0; }
        .sum-exp { background: #fff1f2; border: 1px solid #fecdd3; }
        .sum-net { background: #eff6ff; border: 1px solid #bfdbfe; }
        .sum-lbl { font-size: 10px; color: #64748b; font-weight: 600; }
        .sum-amt { font-size: 16px; font-weight: 800; margin-top: 2px; }
        .sum-inc .sum-amt { color: #16a34a; }
        .sum-exp .sum-amt { color: #dc2626; }
        .sum-net .sum-amt { color: #1e40af; }

        /* Month bar list */
        .month-day-item {
            display: flex; align-items: center; gap: 10px;
            padding: 9px 14px; border-bottom: 1px solid #f0f6ff;
        }
        .month-day-lbl { font-size: 12px; font-weight: 700; color: #475569; width: 48px; flex-shrink: 0; }
        .month-day-bar { flex: 1; height: 8px; background: #f1f5f9; border-radius: 4px; overflow: hidden; }
        .month-day-fill { height: 100%; border-radius: 4px; }
        .mbar-inc { background: #22c55e; }
        .mbar-exp { background: #ef4444; }
        .month-day-net { font-size: 11px; font-weight: 700; width: 62px; text-align: right; flex-shrink: 0; }
        .net-pos { color: #16a34a; }
        .net-neg { color: #dc2626; }
        .net-zero { color: #94a3b8; }

        /* Year month cards */
        .year-month-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 8px; margin: 0 14px 8px; }
        .ym-card { background: #fff; border-radius: 12px; padding: 10px 12px; box-shadow: 0 1px 6px rgba(19,68,160,0.07); cursor: pointer; }
        .ym-name { font-size: 12px; font-weight: 700; color: #0c1b3a; margin-bottom: 4px; }
        .ym-inc  { font-size: 11px; color: #16a34a; font-weight: 600; }
        .ym-exp  { font-size: 11px; color: #dc2626; font-weight: 600; }
        .ym-net  { font-size: 12px; font-weight: 800; margin-top: 2px; }

        /* ===== GARDEN ===== */
        .garden-scene {
            background: linear-gradient(180deg,#bfdbfe 0%,#dbeafe 38%,#e0f2fe 65%,#ecfdf5 100%);
            border-radius: 20px; margin: 0 14px 12px;
            padding: 16px 16px 0; position: relative;
            min-height: 230px; overflow: hidden;
            box-shadow: 0 2px 12px rgba(19,68,160,0.10);
        }
        .garden-sun {
            position: absolute; top: 14px; right: 18px;
            width: 34px; height: 34px; border-radius: 50%;
            background: radial-gradient(circle,#fde68a,#f59e0b);
            box-shadow: 0 0 16px rgba(245,158,11,0.55);
            animation: sun-pulse 4s ease-in-out infinite;
        }
        @keyframes sun-pulse { 0%,100%{box-shadow:0 0 10px rgba(245,158,11,0.35);} 50%{box-shadow:0 0 24px rgba(245,158,11,0.7);} }
        .garden-cloud {
            position: absolute; top: 20px; left: 16px;
            width: 62px; height: 24px;
            animation: cloud-drift 9s ease-in-out infinite alternate;
        }
        .garden-cloud::before,.garden-cloud::after {
            content:''; position:absolute; border-radius:50%;
            background:rgba(255,255,255,0.82);
        }
        .garden-cloud::before { width:40px;height:24px;bottom:0;left:8px; }
        .garden-cloud::after  { width:26px;height:18px;bottom:4px;left:2px; box-shadow:22px 0 0 rgba(255,255,255,0.82); }
        @keyframes cloud-drift { 0%{transform:translateX(0);} 100%{transform:translateX(14px);} }
        .garden-ground {
            position: absolute; bottom: 0; left: 0; right: 0; height: 44px;
            background: linear-gradient(180deg,#bbf7d0,#86efac);
            border-radius: 0 0 20px 20px;
        }
        .garden-ground::before {
            content:''; position:absolute; top:-10px; left:0; right:0;
            height:18px; background:#4ade80; border-radius:50%;
        }
        .tree-display { display: flex; align-items: flex-end; justify-content: center; padding-bottom: 44px; position: relative; z-index: 2; }
        .no-tree-msg { text-align: center; padding: 30px; color: #94a3b8; font-size: 13px; }
        @keyframes tree-sway {
            0%,100% { transform-origin: bottom center; transform: rotate(0deg); }
            33%      { transform-origin: bottom center; transform: rotate(1.5deg); }
            66%      { transform-origin: bottom center; transform: rotate(-1.5deg); }
        }
        .tree-svg-wrap { animation: tree-sway 3.5s ease-in-out infinite; }
        @keyframes fruit-bounce { 0%,100%{transform:scale(1);} 50%{transform:scale(1.2);} }
        .fb { animation: fruit-bounce 2s ease-in-out infinite; transform-origin: center; }

        /* Tree info + XP bar */
        .tree-info-card { background: #fff; border-radius: 14px; margin: 0 14px 10px; padding: 14px; box-shadow: 0 2px 8px rgba(19,68,160,0.07); }
        .tree-title-row { display: flex; align-items: center; gap: 10px; margin-bottom: 8px; }
        .tree-type-tag { display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 10px; font-weight: 700; }
        .tree-stage-row { display: flex; align-items: center; justify-content: space-between; font-size: 11px; color: #64748b; margin-bottom: 4px; }
        .xp-bar-wrap { background: #f1f5f9; border-radius: 6px; height: 10px; overflow: hidden; }
        .xp-bar-fill { height: 100%; background: linear-gradient(90deg,#22c55e,#16a34a); border-radius: 6px; transition: width 0.5s ease; }
        .tree-action-row { display: flex; gap: 8px; margin-top: 10px; }
        .tree-action-btn {
            flex: 1; padding: 8px; border-radius: 10px; font-size: 12px; font-weight: 700;
            border: none; cursor: pointer; transition: transform 0.15s;
        }
        .tree-action-btn:active { transform: scale(0.96); }
        .btn-tree-info   { background: #eff6ff; color: #1e40af; }
        .btn-change-tree { background: #f0fdf4; color: #166534; }

        /* Basket */
        .basket-card { background: #fff; border-radius: 14px; margin: 0 14px 10px; padding: 14px; box-shadow: 0 2px 8px rgba(19,68,160,0.07); }
        .basket-hdr { display: flex; justify-content: space-between; align-items: center; margin-bottom: 10px; }
        .basket-hdr-title { font-size: 13px; font-weight: 800; color: #0c1b3a; }
        .basket-items { display: flex; gap: 8px; }
        .bsk-item {
            flex: 1; background: #f8faff; border-radius: 12px; padding: 10px 6px;
            text-align: center; border: 1.5px solid #e8f0fe; position: relative;
        }
        .bsk-item.has-stock { border-color: #22c55e; background: #f0fdf4; cursor: pointer; transition: transform 0.15s; }
        .bsk-item.has-stock:active { transform: scale(0.95); }
        .bsk-icon  { font-size: 26px; }
        .bsk-name  { font-size: 9px; color: #64748b; margin-top: 2px; font-weight: 600; }
        .bsk-count { font-size: 18px; font-weight: 900; color: #64748b; }
        .bsk-item.has-stock .bsk-count { color: #16a34a; }
        .bsk-xp    { font-size: 9px; color: #94a3b8; }
        .bsk-item.has-stock .bsk-xp { color: #059669; }

        /* Daily reward toast */
        .reward-toast {
            position: fixed; top: 70px; left: 50%; transform: translateX(-50%) translateY(-120px);
            background: #fff; border-radius: 16px; padding: 12px 18px;
            box-shadow: 0 8px 28px rgba(0,0,0,0.18); z-index: 9999;
            display: flex; align-items: center; gap: 10px;
            transition: transform 0.4s cubic-bezier(0.34,1.56,0.64,1);
            pointer-events: none; border: 1.5px solid #bbf7d0;
        }
        .reward-toast.show { transform: translateX(-50%) translateY(0); }
        .reward-toast-icon { font-size: 30px; }
        .reward-toast-text strong { display: block; font-size: 13px; color: #0c1b3a; }
        .reward-toast-text span { font-size: 11px; color: #64748b; }

        /* Modal */
        .acct-modal .modal-content { border-radius: 20px 20px 0 0; border: none; }
        .acct-modal .modal-dialog  { margin: 0; position: absolute; bottom: 0; width: 100%; max-width: 100%; }
        .modal-title-acct { font-size: 16px; font-weight: 800; color: #0c1b3a; }
        .form-lbl { font-size: 12px; font-weight: 700; color: #475569; margin-bottom: 4px; }
        .cat-chips { display: flex; flex-wrap: wrap; gap: 6px; }
        .cat-chip {
            padding: 5px 12px; border-radius: 16px; font-size: 12px; font-weight: 600;
            border: 1.5px solid #e2e8f0; background: #f8faff; cursor: pointer;
            color: #475569; transition: all 0.15s;
        }
        .cat-chip.selected { border-color: #1344a0; background: #eff6ff; color: #1e40af; }

        /* Tree picker */
        .tree-pick-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 10px; }
        .tree-pick-card {
            border: 2px solid #e8f0fe; border-radius: 14px; padding: 12px 8px;
            text-align: center; cursor: pointer; transition: all 0.18s; background: #fff;
        }
        .tree-pick-card.sel { border-color: #1344a0; background: #eff6ff; }
        .tree-pick-card:active { transform: scale(0.96); }
        .tp-icon { font-size: 34px; margin-bottom: 4px; }
        .tp-name { font-size: 12px; font-weight: 800; color: #0c1b3a; }
        .tp-desc { font-size: 10px; color: #94a3b8; margin-top: 2px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="acct-page">

    <!-- Wave + Header -->
    <div style="position:relative;overflow:hidden;">
        <svg id="header-deco" viewBox="0 0 1440 600" xmlns="http://www.w3.org/2000/svg" class="transition duration-300 ease-in-out delay-150">
            <path id="header-deco-1" d="M 0,600 C 0,600 0,120 0,120 C 92.36363636363635,133.79904306220095 184.7272727272727,147.59808612440193 287,148 C 389.2727272727273,148.40191387559807 501.4545454545455,135.40669856459328 592,129 C 682.5454545454545,122.5933014354067 751.4545454545455,122.77511961722489 848,115 C 944.5454545454545,107.22488038277511 1068.7272727272727,91.49282296650718 1172,91 C 1275.2727272727273,90.50717703349282 1357.6363636363635,105.25358851674642 1440,120 C 1440,120 1440,600 1440,600 Z"></path>
            <path id="header-deco-2" d="M 0,600 C 0,600 0,240 0,240 C 98.97607655502392,258.2105263157895 197.95215311004785,276.4210526315789 278,282 C 358.04784688995215,287.5789473684211 419.16746411483257,280.5263157894737 524,265 C 628.8325358851674,249.4736842105263 777.377990430622,225.47368421052633 888,211 C 998.622009569378,196.52631578947367 1071.3205741626793,191.57894736842107 1157,198 C 1242.6794258373207,204.42105263157893 1341.3397129186603,222.21052631578948 1440,240 C 1440,240 1440,600 1440,600 Z"></path>
            <path id="header-deco-3" d="M 0,600 C 0,600 0,360 0,360 C 65.43540669856458,339.55023923444975 130.87081339712915,319.1004784688995 245,321 C 359.12918660287085,322.8995215311005 521.9521531100479,347.1483253588517 616,352 C 710.0478468899521,356.8516746411483 735.3205741626795,342.3062200956938 822,333 C 908.6794258373205,323.6937799043062 1056.7655502392345,319.62679425837325 1170,325 C 1283.2344497607655,330.37320574162675 1361.6172248803828,345.1866028708134 1440,360 C 1440,360 1440,600 1440,600 Z"></path>
            <path id="header-deco-4" d="M 0,600 C 0,600 0,480 0,480 C 70.90909090909093,494.91866028708137 141.81818181818187,509.8373205741627 239,499 C 336.18181818181813,488.1626794258373 459.6363636363636,451.5693779904306 567,446 C 674.3636363636364,440.4306220095694 765.6363636363636,465.88516746411483 862,465 C 958.3636363636364,464.11483253588517 1059.8181818181818,436.8899521531101 1157,435 C 1254.1818181818182,433.1100478468899 1347.090909090909,456.555023923445 1440,480 C 1440,480 1440,600 1440,600 Z"></path>
        </svg>
        <div class="pt-3" style="position:relative;z-index:1;">
            <a href="javascript:history.back()" style="display:inline-flex;align-items:center;gap:6px;
               padding:6px 14px;background:rgba(255,255,255,0.85);border-radius:20px;
               font-size:13px;font-weight:700;color:#1344a0;text-decoration:none;
               margin:0 14px;border:1px solid rgba(19,68,160,0.15);">
                <i class="bi bi-arrow-left"></i> กลับ
            </a>
        </div>
        <div class="acct-header" style="position:relative;z-index:1;">
            <i class="bi bi-journal-bookmark-fill acct-header-icon" style="color:#059669;"></i>
            <h1 class="acct-title">บัญชีรายรับรายจ่าย</h1>
            <h5 class="acct-subtitle">บันทึกรายวัน &bull; สรุปรายเดือน &bull; ดูย้อนหลัง</h5>
            <div class="acct-date-badge" id="todayLabel">กำลังโหลด...</div>
            <div id="rankBadge" class="rank-badge rank-0">📝 มือใหม่</div>
        </div>
    </div>

    <!-- Tab navigation -->
    <div class="acct-tabs">
        <button type="button" class="acct-tab active" onclick="switchTab('today')">วันนี้</button>
        <button type="button" class="acct-tab" onclick="switchTab('month')">เดือน</button>
        <button type="button" class="acct-tab" onclick="switchTab('year')">ปี</button>
        <button type="button" class="acct-tab" onclick="switchTab('garden')">🌱 สวน</button>
    </div>

    <!-- ====== TAB: วันนี้ ====== -->
    <div id="tab-today">
        <div class="balance-card" id="todayBalanceCard">
            <div class="balance-lbl">ยอดสุทธิวันนี้</div>
            <div class="balance-net" id="todayNet">฿0</div>
            <div class="balance-row">
                <div class="balance-col">
                    <div class="balance-col-lbl">รายรับ</div>
                    <div class="balance-col-amt" id="todayInc">฿0</div>
                </div>
                <div class="balance-col">
                    <div class="balance-col-lbl">รายจ่าย</div>
                    <div class="balance-col-amt" id="todayExp">฿0</div>
                </div>
            </div>
        </div>
        <div class="add-btn-row">
            <button type="button" class="add-btn add-income" onclick="openAddModal('income')">
                <i class="bi bi-plus-circle-fill"></i> + รายรับ
            </button>
            <button type="button" class="add-btn add-expense" onclick="openAddModal('expense')">
                <i class="bi bi-dash-circle-fill"></i> + รายจ่าย
            </button>
        </div>
        <div class="sect-hdr">
            <span class="sect-hdr-title">รายการวันนี้</span>
        </div>
        <div id="todayList"></div>
    </div>

    <!-- ====== TAB: เดือน ====== -->
    <div id="tab-month" style="display:none;">
        <div class="period-nav">
            <button type="button" class="period-btn" onclick="changeMonth(-1)">‹</button>
            <div class="period-lbl" id="monthLabel">—</div>
            <button type="button" class="period-btn" onclick="changeMonth(1)">›</button>
        </div>
        <div class="summary-card">
            <div class="summary-row">
                <div class="summary-col sum-inc">
                    <div class="sum-lbl">รายรับ</div>
                    <div class="sum-amt" id="monthInc">฿0</div>
                </div>
                <div class="summary-col sum-exp">
                    <div class="sum-lbl">รายจ่าย</div>
                    <div class="sum-amt" id="monthExp">฿0</div>
                </div>
                <div class="summary-col sum-net">
                    <div class="sum-lbl">สุทธิ</div>
                    <div class="sum-amt" id="monthNet">฿0</div>
                </div>
            </div>
        </div>
        <div class="sect-hdr">
            <span class="sect-hdr-title">รายวัน</span>
        </div>
        <div class="tx-card" id="monthDayList"></div>
    </div>

    <!-- ====== TAB: ปี ====== -->
    <div id="tab-year" style="display:none;">
        <div class="period-nav">
            <button type="button" class="period-btn" onclick="changeYear(-1)">‹</button>
            <div class="period-lbl" id="yearLabel">—</div>
            <button type="button" class="period-btn" onclick="changeYear(1)">›</button>
        </div>
        <div class="summary-card">
            <div class="summary-row">
                <div class="summary-col sum-inc">
                    <div class="sum-lbl">รายรับ</div>
                    <div class="sum-amt" id="yearInc">฿0</div>
                </div>
                <div class="summary-col sum-exp">
                    <div class="sum-lbl">รายจ่าย</div>
                    <div class="sum-amt" id="yearExp">฿0</div>
                </div>
                <div class="summary-col sum-net">
                    <div class="sum-lbl">สุทธิ</div>
                    <div class="sum-amt" id="yearNet">฿0</div>
                </div>
            </div>
        </div>
        <div class="sect-hdr">
            <span class="sect-hdr-title">รายเดือน</span>
        </div>
        <div class="year-month-grid" id="yearMonthGrid"></div>
    </div>

    <!-- ====== TAB: สวน ====== -->
    <div id="tab-garden" style="display:none;">
        <!-- Tree scene -->
        <div class="garden-scene">
            <div class="garden-sun"></div>
            <div class="garden-cloud"></div>
            <div class="garden-ground"></div>
            <div class="tree-display" id="treeDisplay">
                <div class="no-tree-msg">เลือกต้นไม้เพื่อเริ่มปลูก 🌱</div>
            </div>
        </div>
        <!-- Tree info -->
        <div class="tree-info-card" id="treeInfoCard" style="display:none;">
            <div class="tree-title-row">
                <span id="treeTypeEmoji" style="font-size:24px;"></span>
                <div>
                    <div style="font-size:15px;font-weight:800;color:#0c1b3a;" id="treeNameDisplay">—</div>
                    <span class="tree-type-tag" id="treeTypeTag">—</span>
                </div>
            </div>
            <div class="tree-stage-row">
                <span id="treeStageName">—</span>
                <span id="treeXpText">—</span>
            </div>
            <div class="xp-bar-wrap"><div class="xp-bar-fill" id="treeXpBar" style="width:0%"></div></div>
            <div class="tree-action-row">
                <button type="button" class="tree-action-btn btn-tree-info" onclick="showTreeDetail()">ℹ️ ข้อมูลต้นไม้</button>
                <button type="button" class="tree-action-btn btn-change-tree" id="btnChangTreeType" onclick="openTreePicker()" style="display:none;">🔄 เปลี่ยนพันธุ์</button>
            </div>
        </div>
        <!-- Pick tree (first time) -->
        <div id="treePickFirst" style="display:none;">
            <div style="text-align:center;padding:10px 14px 8px;">
                <div style="font-size:14px;font-weight:800;color:#0c1b3a;">เลือกพันธุ์ต้นไม้ของคุณ</div>
                <div style="font-size:11px;color:#64748b;margin-top:2px;">เมื่อเลือกแล้ว จะเปลี่ยนได้เฉพาะตอนที่ยังเป็นเมล็ด</div>
            </div>
            <div class="tree-pick-grid" style="padding:0 14px;" id="treePicker1"></div>
            <div style="padding:10px 14px;">
                <button type="button" onclick="confirmTreePick()" style="width:100%;padding:12px;background:#1344a0;color:#fff;border:none;border-radius:14px;font-size:14px;font-weight:800;cursor:pointer;">
                    เริ่มปลูก 🌱
                </button>
            </div>
        </div>
        <!-- Basket -->
        <div class="basket-card" id="basketCard">
            <div class="basket-hdr">
                <span class="basket-hdr-title">🧺 ตระกร้าของฉัน</span>
                <span style="font-size:11px;color:#94a3b8;">กดรดน้ำ → ต้นไม้โตขึ้น</span>
            </div>
            <div class="basket-items">
                <div class="bsk-item" id="bskCup" onclick="waterTree('cup')">
                    <div class="bsk-icon">🥤</div>
                    <div class="bsk-count" id="bskCupCount">0</div>
                    <div class="bsk-name">แก้วน้ำ</div>
                    <div class="bsk-xp">+1 XP</div>
                </div>
                <div class="bsk-item" id="bskCan" onclick="waterTree('can')">
                    <div class="bsk-icon">🪣</div>
                    <div class="bsk-count" id="bskCanCount">0</div>
                    <div class="bsk-name">บัวรดน้ำ</div>
                    <div class="bsk-xp">+2 XP</div>
                </div>
                <div class="bsk-item" id="bskBucket" onclick="waterTree('bucket')">
                    <div class="bsk-icon">🪤</div>
                    <div class="bsk-count" id="bskBucketCount">0</div>
                    <div class="bsk-name">ถังน้ำ</div>
                    <div class="bsk-xp">+4 XP</div>
                </div>
            </div>
            <div style="text-align:center;margin-top:8px;font-size:11px;color:#94a3b8;">
                บันทึกรายการทุกวัน → รับของรางวัล 1 ชิ้น
            </div>
        </div>
    </div>

</div>

<!-- Daily reward toast -->
<div class="reward-toast" id="rewardToast">
    <div class="reward-toast-icon" id="rewardToastIcon">🥤</div>
    <div class="reward-toast-text">
        <strong id="rewardToastTitle">ได้รับรางวัลประจำวัน!</strong>
        <span id="rewardToastSub">แก้วน้ำ 1 ใบ เพิ่มในตระกร้า</span>
    </div>
</div>

<!-- Modal: Add/Edit Transaction -->
<div class="modal fade acct-modal" id="txModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-acct" id="txModalTitle">เพิ่มรายรับ</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 18px;">
                <input type="hidden" id="txEditId" value="" />
                <input type="hidden" id="txEditType" value="income" />
                <div style="margin-bottom:12px;">
                    <div class="form-lbl">จำนวนเงิน (บาท)</div>
                    <input type="number" id="txAmount" class="form-control" placeholder="0.00" min="0" step="0.01" style="border-radius:10px;font-size:18px;font-weight:700;" />
                </div>
                <div style="margin-bottom:12px;">
                    <div class="form-lbl">หมวดหมู่</div>
                    <div class="cat-chips" id="catChips"></div>
                </div>
                <div style="margin-bottom:12px;">
                    <div class="form-lbl">วันที่</div>
                    <input type="date" id="txDate" class="form-control" style="border-radius:10px;" />
                </div>
                <div style="margin-bottom:16px;">
                    <div class="form-lbl">หมายเหตุ (ถ้ามี)</div>
                    <input type="text" id="txNote" class="form-control" placeholder="รายละเอียดเพิ่มเติม..." style="border-radius:10px;" maxlength="80" />
                </div>
                <button type="button" onclick="saveTx()" style="width:100%;padding:12px;border-radius:14px;border:none;background:#1344a0;color:#fff;font-size:14px;font-weight:800;cursor:pointer;">
                    บันทึก
                </button>
            </div>
        </div>
    </div>
</div>

<!-- Modal: Tree Picker -->
<div class="modal fade acct-modal" id="treePickerModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-acct">เลือกพันธุ์ต้นไม้</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 18px;">
                <div style="font-size:11px;color:#94a3b8;margin-bottom:12px;text-align:center;">
                    เปลี่ยนได้เฉพาะตอนที่ยังเป็นเมล็ด (stage 0)
                </div>
                <div class="tree-pick-grid" id="treePicker2"></div>
                <div style="margin-top:12px;">
                    <button type="button" onclick="confirmTreePick()" style="width:100%;padding:12px;background:#1344a0;color:#fff;border:none;border-radius:14px;font-size:14px;font-weight:800;cursor:pointer;">
                        เลือกต้นนี้
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal: Tree Detail -->
<div class="modal fade acct-modal" id="treeDetailModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-acct" id="treeDetailTitle">ข้อมูลต้นไม้</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 24px;" id="treeDetailBody"></div>
        </div>
    </div>
</div>

<script>
// ===== DATA DEFINITIONS =====
var CATS_INCOME  = ['เงินเดือน','ขายสินค้า','รับจ้าง','โอนเงิน','ดอกเบี้ย','อื่นๆ'];
var CATS_EXPENSE = ['อาหาร','เดินทาง','ค่าเช่า','ค่าน้ำค่าไฟ','สุขภาพ','บันเทิง','ช้อปปิ้ง','อื่นๆ'];

var TREES = [
    { name:'ดาวเรือง',  desc:'ส่องแสงแห่งความมั่งคั่ง',  emoji:'🌻', shape:'round',   c1:'#f59e0b',c2:'#fde68a',cf:'#dc2626',ct:'#92400e', tagBg:'#fef3c7',tagColor:'#92400e' },
    { name:'แก้วมังกร', desc:'พลังลึกลับจากมังกร',        emoji:'🌵', shape:'cactus',  c1:'#059669',c2:'#6ee7b7',cf:'#f43f5e',ct:'#065f46', tagBg:'#dcfce7',tagColor:'#166534' },
    { name:'ซากุระมิดี', desc:'ความงามและความอุดมสมบูรณ์', emoji:'🌸', shape:'cloud',   c1:'#fda4af',c2:'#fbcfe8',cf:'#ec4899',ct:'#9d174d', tagBg:'#fce7f3',tagColor:'#9d174d' },
    { name:'ต้นทองแถบ', desc:'โชคลาภทองคำไหลหลั่ง',       emoji:'🏆', shape:'layers',  c1:'#d97706',c2:'#fde68a',cf:'#eab308',ct:'#78350f', tagBg:'#fef9c3',tagColor:'#78350f' },
    { name:'มรกตลี้ลับ', desc:'ปัญญาและสรรพสิ่งแห่งจักรวาล',emoji:'💎', shape:'oval',   c1:'#0ea5e9',c2:'#bae6fd',cf:'#7c3aed',ct:'#1e3a8a', tagBg:'#eff6ff',tagColor:'#1e40af' }
];

var STAGES = ['เมล็ด','ต้นกล้า','ต้นรุ่น','กำลังออกดอก','ออกผลแล้ว'];
var STAGE_XP = [5, 12, 22, 30]; // XP needed to advance from stage 0,1,2,3
var ITEM_XP  = { cup:1, can:2, bucket:4 };
var ITEM_PROB = [0.50, 0.85, 1.0]; // cup<0.5, can<0.85, bucket<=1
var ITEM_NAMES = { cup:'แก้วน้ำ', can:'บัวรดน้ำ', bucket:'ถังน้ำ' };
var ITEM_EMOJI = { cup:'🥤', can:'🪣', bucket:'🪤' };

var RANKS = [
    { min:0,  label:'มือใหม่',     icon:'📝', cls:'rank-0' },
    { min:3,  label:'นักบันทึก',   icon:'✏️', cls:'rank-1' },
    { min:7,  label:'ผู้ขยัน',     icon:'📊', cls:'rank-2' },
    { min:14, label:'นักบัญชี',    icon:'💰', cls:'rank-3' },
    { min:30, label:'นักการเงิน',  icon:'💼', cls:'rank-4' },
    { min:60, label:'ผู้เชี่ยวชาญ',icon:'🏆', cls:'rank-5' }
];

var MONTH_TH = ['มกราคม','กุมภาพันธ์','มีนาคม','เมษายน','พฤษภาคม','มิถุนายน',
                'กรกฎาคม','สิงหาคม','กันยายน','ตุลาคม','พฤศจิกายน','ธันวาคม'];

// ===== STATE =====
var curTab   = 'today';
var curMonth, curYear;
var editingTreeType = 0;
var selectedCat = '';

// ===== STORAGE =====
function loadTx()     { try { return JSON.parse(localStorage.getItem('acct_tx') || '[]'); } catch(e){return[];} }
function saveTx(arr)  { localStorage.setItem('acct_tx', JSON.stringify(arr)); }
function loadGame()   {
    var g = null;
    try { g = JSON.parse(localStorage.getItem('acct_game')); } catch(e){}
    if (!g) g = { treeType:-1, stage:0, xp:0, basket:{cup:0,can:0,bucket:0}, totalEntryDays:0, lastEntryDate:null, lastRewardDate:null, totalWatered:0 };
    if (!g.basket) g.basket = {cup:0,can:0,bucket:0};
    return g;
}
function saveGame(g)  { localStorage.setItem('acct_game', JSON.stringify(g)); }

// ===== HELPERS =====
function toDateStr(d) { return d.getFullYear()+'-'+pad(d.getMonth()+1)+'-'+pad(d.getDate()); }
function pad(n)       { return n<10?'0'+n:String(n); }
function fmtAmt(n)    { return '฿'+Math.abs(n).toLocaleString('th-TH',{minimumFractionDigits:0,maximumFractionDigits:2}); }
function fmtAmtSigned(n) { return (n>=0?'+':'')+(n).toLocaleString('th-TH',{minimumFractionDigits:0,maximumFractionDigits:2})+' บาท'; }
function genId()      { return Date.now().toString(36)+Math.random().toString(36).slice(2,6); }

function getTodayStr() { return toDateStr(new Date()); }
function getMonthKey(y,m) { return y+'-'+pad(m+1); }

// ===== SUMMARY CALC =====
function calcSummary(txList) {
    var inc=0,exp=0;
    txList.forEach(function(t){ if(t.type==='income') inc+=t.amount; else exp+=t.amount; });
    return {inc:inc,exp:exp,net:inc-exp};
}

function getTxForDate(d)   { return loadTx().filter(function(t){return t.date===d;}); }
function getTxForMonth(y,m){ var k=getMonthKey(y,m); return loadTx().filter(function(t){return t.date.startsWith(k);}); }
function getTxForYear(y)   { return loadTx().filter(function(t){return t.date.startsWith(String(y))}); }

// ===== RANK =====
function getRank(days) {
    var r = RANKS[0];
    for (var i=0;i<RANKS.length;i++) { if(days>=RANKS[i].min) r=RANKS[i]; else break; }
    return r;
}
function updateRankBadge() {
    var g=loadGame(), r=getRank(g.totalEntryDays), el=document.getElementById('rankBadge');
    el.className='rank-badge '+r.cls;
    el.innerHTML=r.icon+' '+r.label+' <span style="font-weight:400;opacity:0.7;margin-left:3px;">'+g.totalEntryDays+' วัน</span>';
}

// ===== TAB SWITCH =====
function switchTab(tab) {
    curTab = tab;
    ['today','month','year','garden'].forEach(function(t){
        document.getElementById('tab-'+t).style.display = (t===tab)?'':'none';
        var btn = document.querySelector('.acct-tab[onclick*="\''+t+'\'"]');
        if (btn) btn.classList.toggle('active', t===tab);
    });
    if (tab==='today')  renderToday();
    if (tab==='month')  renderMonth();
    if (tab==='year')   renderYear();
    if (tab==='garden') renderGarden();
}

// ===== TODAY =====
function renderToday() {
    var today = getTodayStr();
    var txs   = getTxForDate(today);
    var s     = calcSummary(txs);
    document.getElementById('todayNet').innerHTML = (s.net>=0?'<span style="color:#fff">':'<span style="color:#fca5a5">')+fmtAmt(s.net)+'</span>';
    document.getElementById('todayInc').textContent = fmtAmt(s.inc);
    document.getElementById('todayExp').textContent = fmtAmt(s.exp);
    var el = document.getElementById('todayList');
    if (!txs.length) { el.innerHTML='<div class="empty-state"><div class="empty-icon">📋</div><div>ยังไม่มีรายการวันนี้</div><div style="font-size:11px;margin-top:4px;">กด + รายรับ หรือ + รายจ่าย เพื่อเริ่มบันทึก</div></div>'; return; }
    var html='<div class="tx-card">';
    txs.slice().reverse().forEach(function(t,i){
        var isInc=t.type==='income';
        if(i>0) html+='<div class="tx-divider"></div>';
        html+='<div class="tx-item" onclick="openEditModal(\'''+t.id+'\')">';
        html+='<div class="tx-icon '+(isInc?'tx-icon-inc':'tx-icon-exp')+'">'+(isInc?'💰':'💸')+'</div>';
        html+='<div class="tx-info"><div class="tx-cat">'+t.cat+'</div>';
        if(t.note) html+='<div class="tx-note">'+t.note+'</div>';
        html+='</div>';
        html+='<div class="tx-amt '+(isInc?'tx-amt-inc':'tx-amt-exp')+'">'+(isInc?'+':'−')+fmtAmt(t.amount)+'</div>';
        html+='<div class="tx-del-btn" onclick="event.stopPropagation();deleteTx(\'''+t.id+'\')">&times;</div>';
        html+='</div>';
    });
    html+='</div>';
    el.innerHTML=html;
}

// ===== MONTH =====
function renderMonth() {
    var now=new Date();
    if(curMonth===undefined){curMonth=now.getMonth();curYear=now.getFullYear();}
    document.getElementById('monthLabel').textContent=MONTH_TH[curMonth]+' '+( curYear+543);
    var txs=getTxForMonth(curYear,curMonth);
    var s=calcSummary(txs);
    document.getElementById('monthInc').textContent=fmtAmt(s.inc);
    document.getElementById('monthExp').textContent=fmtAmt(s.exp);
    document.getElementById('monthNet').textContent=fmtAmt(s.net);
    // Group by day
    var days={};
    txs.forEach(function(t){ if(!days[t.date]) days[t.date]={inc:0,exp:0}; if(t.type==='income')days[t.date].inc+=t.amount;else days[t.date].exp+=t.amount; });
    var sorted=Object.keys(days).sort().reverse();
    var maxAmt=0;
    sorted.forEach(function(d){ maxAmt=Math.max(maxAmt,days[d].inc,days[d].exp); });
    var html='';
    if(!sorted.length){html='<div class="empty-state"><div class="empty-icon">📅</div><div>ไม่มีรายการเดือนนี้</div></div>';}
    else sorted.forEach(function(d){
        var dy=days[d], net=dy.inc-dy.exp, parts=d.split('-');
        var incW=maxAmt?Math.round(dy.inc/maxAmt*100):0, expW=maxAmt?Math.round(dy.exp/maxAmt*100):0;
        html+='<div class="month-day-item" onclick="showDayDetail(\'''+d+'\')">';
        html+='<div class="month-day-lbl">'+(parts[2]||'')+' '+MONTH_TH[parseInt(parts[1]||1)-1].slice(0,3)+'</div>';
        html+='<div class="month-day-bar"><div class="month-day-fill mbar-inc" style="width:'+incW+'%"></div></div>';
        html+='<div class="month-day-bar" style="margin-top:2px;"><div class="month-day-fill mbar-exp" style="width:'+expW+'%"></div></div>';
        var nc=net>0?'net-pos':net<0?'net-neg':'net-zero';
        html+='<div class="month-day-net '+ nc +'">'+(net>=0?'+':'')+fmtAmt(net)+'</div>';
        html+='</div>';
    });
    document.getElementById('monthDayList').innerHTML=html;
}
function changeMonth(d) {
    curMonth+=d; if(curMonth<0){curMonth=11;curYear--;} if(curMonth>11){curMonth=0;curYear++;} renderMonth();
}
function showDayDetail(dateStr) {
    var txs=getTxForDate(dateStr); if(!txs.length) return;
    curTab='today'; // Switch to today effectively but show that date
    var parts=dateStr.split('-');
    var title='วันที่ '+parseInt(parts[2])+' '+MONTH_TH[parseInt(parts[1])-1]+' '+(parseInt(parts[0])+543);
    var html='<div class="tx-card" style="margin:0;">';
    txs.slice().reverse().forEach(function(t,i){
        var isInc=t.type==='income';
        if(i>0) html+='<div class="tx-divider"></div>';
        html+='<div class="tx-item">';
        html+='<div class="tx-icon '+(isInc?'tx-icon-inc':'tx-icon-exp')+'">'+(isInc?'💰':'💸')+'</div>';
        html+='<div class="tx-info"><div class="tx-cat">'+t.cat+'</div>'+(t.note?'<div class="tx-note">'+t.note+'</div>':'')+'</div>';
        html+='<div class="tx-amt '+(isInc?'tx-amt-inc':'tx-amt-exp')+'">'+(isInc?'+':'−')+fmtAmt(t.amount)+'</div></div>';
    });
    html+='</div>';
    // Show in a simple alert-style - just switch to today tab and show in modal
    showSimpleModal(title, html);
}
function showSimpleModal(title, bodyHtml) {
    document.getElementById('treeDetailTitle').textContent=title;
    document.getElementById('treeDetailBody').innerHTML=bodyHtml;
    var m=new bootstrap.Modal(document.getElementById('treeDetailModal'));m.show();
}

// ===== YEAR =====
function renderYear() {
    var now=new Date();
    if(curYear===undefined) curYear=now.getFullYear();
    document.getElementById('yearLabel').textContent='ปี '+(curYear+543);
    var txs=getTxForYear(curYear); var s=calcSummary(txs);
    document.getElementById('yearInc').textContent=fmtAmt(s.inc);
    document.getElementById('yearExp').textContent=fmtAmt(s.exp);
    document.getElementById('yearNet').textContent=fmtAmt(s.net);
    var html='';
    for(var m=0;m<12;m++){
        var mt=getTxForMonth(curYear,m), ms=calcSummary(mt);
        var nc=ms.net>0?'net-pos':ms.net<0?'net-neg':'net-zero';
        html+='<div class="ym-card" onclick="curMonth='+m+';curYear='+curYear+';switchTab(\'month\')">';
        html+='<div class="ym-name">'+MONTH_TH[m]+'</div>';
        html+='<div class="ym-inc">รายรับ '+fmtAmt(ms.inc)+'</div>';
        html+='<div class="ym-exp">รายจ่าย '+fmtAmt(ms.exp)+'</div>';
        html+='<div class="ym-net '+ nc +'">สุทธิ '+fmtAmtSigned(ms.net)+'</div></div>';
    }
    document.getElementById('yearMonthGrid').innerHTML=html;
}
function changeYear(d) { curYear+=d; renderYear(); }

// ===== ADD/EDIT TRANSACTION =====
function openAddModal(type) {
    document.getElementById('txEditId').value='';
    document.getElementById('txEditType').value=type;
    document.getElementById('txModalTitle').textContent=(type==='income'?'เพิ่มรายรับ':'เพิ่มรายจ่าย');
    document.getElementById('txAmount').value='';
    document.getElementById('txDate').value=getTodayStr();
    document.getElementById('txNote').value='';
    selectedCat='';
    renderCatChips(type);
    var m=new bootstrap.Modal(document.getElementById('txModal'));m.show();
}
function openEditModal(id) {
    var tx=loadTx().find(function(t){return t.id===id;}); if(!tx) return;
    document.getElementById('txEditId').value=id;
    document.getElementById('txEditType').value=tx.type;
    document.getElementById('txModalTitle').textContent='แก้ไข'+(tx.type==='income'?'รายรับ':'รายจ่าย');
    document.getElementById('txAmount').value=tx.amount;
    document.getElementById('txDate').value=tx.date;
    document.getElementById('txNote').value=tx.note||''
    selectedCat=tx.cat;
    renderCatChips(tx.type);
    var m=new bootstrap.Modal(document.getElementById('txModal'));m.show();
}
function renderCatChips(type) {
    var cats=type==='income'?CATS_INCOME:CATS_EXPENSE;
    var html='';
    cats.forEach(function(c){
        html+='<div class="cat-chip'+(c===selectedCat?' selected':'')+'" onclick="pickCat(\''+ c +'\')">'+c+'</div>';
    });
    document.getElementById('catChips').innerHTML=html;
}
function pickCat(c) {
    selectedCat=c;
    var type=document.getElementById('txEditType').value;
    renderCatChips(type);
}
function saveTx() {
    var amount=parseFloat(document.getElementById('txAmount').value);
    if(!amount||amount<=0){alert('กรุณากรอกจำนวนเงิน');return;}
    if(!selectedCat){alert('กรุณาเลือกหมวดหมู่');return;}
    var date=document.getElementById('txDate').value||getTodayStr();
    var note=document.getElementById('txNote').value.trim();
    var type=document.getElementById('txEditType').value;
    var id=document.getElementById('txEditId').value;
    var txs=loadTx();
    var isNew=!id;
    if(isNew){
        txs.push({id:genId(),type:type,amount:amount,cat:selectedCat,note:note,date:date,ts:Date.now()});
    } else {
        var idx=txs.findIndex(function(t){return t.id===id;});
        if(idx>=0) txs[idx]=Object.assign(txs[idx],{type:type,amount:amount,cat:selectedCat,note:note,date:date});
    }
    saveTx(txs);
    // Check daily reward
    if(isNew) checkDailyReward(date);
    // Update rank
    updateEntryDays();
    // Close modal
    bootstrap.Modal.getInstance(document.getElementById('txModal')).hide();
    // Re-render current tab
    if(curTab==='today') renderToday();
    else if(curTab==='month') renderMonth();
    else if(curTab==='year') renderYear();
}
function deleteTx(id) {
    if(!confirm('ลบรายการนี้?')) return;
    var txs=loadTx().filter(function(t){return t.id!==id;});
    saveTx(txs);
    updateEntryDays();
    if(curTab==='today') renderToday();
    else if(curTab==='month') renderMonth();
    else if(curTab==='year') renderYear();
}

// ===== ENTRY DAYS TRACKING =====
function updateEntryDays() {
    var txs=loadTx();
    var dates=new Set();
    txs.forEach(function(t){dates.add(t.date);});
    var g=loadGame();
    g.totalEntryDays=dates.size;
    saveGame(g);
    updateRankBadge();
}

// ===== DAILY REWARD =====
function checkDailyReward(date) {
    var g=loadGame();
    if(g.lastRewardDate===date) return; // Already got reward today
    // Give random item
    var r=Math.random();
    var item = r<0.50?'cup':r<0.85?'can':'bucket';
    g.basket[item]++;
    g.lastRewardDate=date;
    saveGame(g);
    // Show toast
    showRewardToast(item);
    // Update basket UI if on garden tab
    if(curTab==='garden') renderGarden();
}
function showRewardToast(item) {
    var toast=document.getElementById('rewardToast');
    document.getElementById('rewardToastIcon').textContent=ITEM_EMOJI[item];
    document.getElementById('rewardToastTitle').textContent='ได้รับรางวัลประจำวัน!';
    document.getElementById('rewardToastSub').textContent=ITEM_NAMES[item]+' 1 ชิ้น เพิ่มในตระกร้า';
    toast.classList.add('show');
    setTimeout(function(){toast.classList.remove('show');},3500);
}

// ===== GARDEN / TREE =====
function renderGarden() {
    var g=loadGame();
    updateBasketUI(g);
    if(g.treeType<0){
        // No tree chosen yet
        document.getElementById('treeDisplay').innerHTML='<div class="no-tree-msg">เลือกต้นไม้เพื่อเริ่มปลูก 🌱</div>';
        document.getElementById('treeInfoCard').style.display='none';
        document.getElementById('treePickFirst').style.display='';
        document.getElementById('basketCard').style.display='';
        renderTreePickerCards('treePicker1');
        return;
    }
    document.getElementById('treePickFirst').style.display='none';
    // Render tree SVG
    var tInfo=TREES[g.treeType];
    document.getElementById('treeDisplay').innerHTML='<div class="tree-svg-wrap">'+getTreeSVG(g.treeType,g.stage)+'</div>';
    // Info card
    document.getElementById('treeInfoCard').style.display='';
    document.getElementById('treeTypeEmoji').textContent=tInfo.emoji;
    document.getElementById('treeNameDisplay').textContent=tInfo.name;
    document.getElementById('treeTypeTag').textContent=tInfo.desc;
    document.getElementById('treeTypeTag').style.cssText='background:'+tInfo.tagBg+';color:'+tInfo.tagColor;
    document.getElementById('treeStageName').textContent=STAGES[g.stage];
    var xpNeeded=g.stage<4?STAGE_XP[g.stage]:null;
    var xpPct=xpNeeded?Math.min(100,Math.round(g.xp/xpNeeded*100)):100;
    document.getElementById('treeXpText').textContent=xpNeeded?'XP: '+g.xp+'/'+xpNeeded:'เต็มศักยภาพ ✨';
    document.getElementById('treeXpBar').style.width=xpPct+'%';
    // Can change tree only at stage 0
    document.getElementById('btnChangTreeType').style.display=g.stage===0?'':' none';
    updateBasketUI(g);
}
function updateBasketUI(g) {
    ['cup','can','bucket'].forEach(function(k){
        var cnt=g.basket[k]||0;
        document.getElementById('bsk'+k.charAt(0).toUpperCase()+k.slice(1)+'Count').textContent=cnt;
        var el=document.getElementById('bsk'+k.charAt(0).toUpperCase()+k.slice(1));
        el.classList.toggle('has-stock',cnt>0);
    });
}

function waterTree(item) {
    var g=loadGame();
    if(g.treeType<0){alert('เลือกต้นไม้ก่อนนะ 🌱');return;}
    if(g.stage>=4){alert('ต้นไม้ของคุณเติบโตเต็มที่แล้ว! \n'+TREES[g.treeType].emoji+' '+STAGES[4]);return;}
    if(!g.basket[item]||g.basket[item]<=0){alert('ไม่มี'+ITEM_NAMES[item]+'ในตระกร้า');return;}
    g.basket[item]--;
    g.xp+=ITEM_XP[item];
    g.totalWatered++;
    // Check stage up
    while(g.stage<4 && g.xp>=STAGE_XP[g.stage]){
        g.xp-=STAGE_XP[g.stage];
        g.stage++;
    }
    if(g.stage>=4) g.xp=0;
    saveGame(g);
    renderGarden();
    // Mini celebration if leveled up
    if(g.stage===4) showSimpleModal('🎉 ต้นไม้โตเต็มที่!','<div style="text-align:center;padding:16px;font-size:40px;">'+TREES[g.treeType].emoji+'</div><div style="text-align:center;font-size:14px;font-weight:700;color:#0c1b3a;">'+TREES[g.treeType].name+'</div><div style="text-align:center;font-size:12px;color:#64748b;margin-top:4px;">ออกผลและออกดอกเป็นที่เรียบร้อย<br>ขอแสดงความยินดี! 🎊</div>');
}

function openTreePicker() {
    editingTreeType=loadGame().treeType||0;
    renderTreePickerCards('treePicker2');
    var m=new bootstrap.Modal(document.getElementById('treePickerModal'));m.show();
}
function renderTreePickerCards(containerId) {
    var html='';
    TREES.forEach(function(t,i){
        html+='<div class="tree-pick-card'+(i===editingTreeType?' sel':'')+'" onclick="pickTreeType('+i+')">';
        html+='<div class="tp-icon">'+t.emoji+'</div>';
        html+='<div class="tp-name">'+t.name+'</div>';
        html+='<div class="tp-desc">'+t.desc+'</div></div>';
    });
    document.getElementById(containerId).innerHTML=html;
}
function pickTreeType(i) {
    editingTreeType=i;
    // Re-render both pickers
    ['treePicker1','treePicker2'].forEach(function(id){
        if(document.getElementById(id)){renderTreePickerCards(id);}
    });
}
function confirmTreePick() {
    var g=loadGame();
    if(g.stage>0&&g.treeType>=0){alert('เปลี่ยนพันธุ์ได้เฉพาะตอนที่ยังเป็นเมล็ด');return;}
    g.treeType=editingTreeType; g.stage=0; g.xp=0;
    saveGame(g);
    // Close modals
    ['treePickerModal'].forEach(function(id){
        var m=bootstrap.Modal.getInstance(document.getElementById(id));
        if(m) m.hide();
    });
    renderGarden();
}
function showTreeDetail() {
    var g=loadGame(); if(g.treeType<0) return;
    var t=TREES[g.treeType];
    var xpNeeded=g.stage<4?STAGE_XP[g.stage]:'—';
    var nextStage=g.stage<4?STAGES[g.stage+1]:'(เต็มศักยภาพ)';
    var html='<div style="text-align:center;padding:10px 0 16px;">';
    html+='<div style="font-size:52px;">'+t.emoji+'</div>';
    html+='<div style="font-size:17px;font-weight:800;color:#0c1b3a;margin-top:4px;">'+t.name+'</div>';
    html+='<div style="font-size:12px;color:#64748b;">'+t.desc+'</div></div>';
    html+='<div style="display:grid;grid-template-columns:1fr 1fr;gap:8px;margin-bottom:12px;">';
    var stats=[
        ['ระยะ',STAGES[g.stage]],
        ['XP ปัจจุบัน',g.xp],
        ['ขั้นต่อไป',nextStage],
        ['XP ที่ต้องการ',xpNeeded],
        ['รดน้ำทั้งหมด',g.totalWatered+' ครั้ง'],
        ['วันบันทึก',g.totalEntryDays+' วัน']
    ];
    stats.forEach(function(s){
        html+='<div style="background:#f8faff;border-radius:10px;padding:8px 10px;">';
        html+='<div style="font-size:10px;color:#94a3b8;font-weight:600;">'+s[0]+'</div>';
        html+='<div style="font-size:13px;font-weight:800;color:#0c1b3a;margin-top:1px;">'+s[1]+'</div></div>';
    });
    html+='</div>';
    // Stage progression
    html+='<div style="margin-top:4px;"><div style="font-size:12px;font-weight:700;color:#475569;margin-bottom:8px;">การเติบโต</div><div style="display:flex;justify-content:space-between;">';
    STAGES.forEach(function(sn,si){
        var done=si<=g.stage;
        html+='<div style="text-align:center;flex:1;">';
        html+='<div style="font-size:16px;">'+(done?'✅':'⬜')+'</div>';
        html+='<div style="font-size:8px;color:'+(done?'#059669':'#cbd5e1')+';font-weight:700;margin-top:2px;">'+sn+'</div></div>';
    });
    html+='</div></div>';
    document.getElementById('treeDetailTitle').textContent='ข้อมูล: '+t.name;
    document.getElementById('treeDetailBody').innerHTML=html;
    var m=new bootstrap.Modal(document.getElementById('treeDetailModal'));m.show();
}

// ===== TREE SVG DRAWING =====
function getTreeSVG(type, stage) {
    var t=TREES[type], W=140, H=190, cx=70;
    var c1=t.c1,c2=t.c2,cf=t.cf,ct=t.ct;
    var p=[];
    p.push('<svg width="'+W+'" height="'+H+'" viewBox="0 0 '+W+' '+H+'" xmlns="http://www.w3.org/2000/svg">');
    p.push('<ellipse cx="'+cx+'" cy="185" rx="50" ry="10" fill="'+ct+'" opacity="0.22"/>');
    if(stage===0){
        p.push('<ellipse cx="'+cx+'" cy="182" rx="14" ry="9" fill="'+ct+'"/>');
        p.push('<ellipse cx="'+cx+'" cy="180" rx="8" ry="5" fill="'+c1+'" opacity="0.85"/>');
        p.push('<path d="M'+cx+' 174 C'+(cx-3)+' 166 '+(cx-1)+' 160 '+cx+' 156" stroke="'+c1+'" stroke-width="2.5" fill="none" stroke-linecap="round"/>');
        p.push('<ellipse cx="'+cx+'" cy="154" rx="7" ry="4" fill="'+c1+'" opacity="0.9"/>');
    } else {
        var tH=[0,30,50,66,72][stage], tW=13, tY=183-tH;
        p.push('<rect x="'+(cx-tW/2)+'" y="'+tY+'" width="'+tW+'" height="'+tH+'" rx="5" fill="'+ct+'"/>');
        var cY=tY-6;
        if(t.shape==='round'){
            var r=[0,22,34,43,48][stage];
            p.push('<circle cx="'+cx+'" cy="'+cY+'" r="'+r+'" fill="'+c1+'"/>');
            p.push('<circle cx="'+(cx-r*0.22)+'" cy="'+(cY-r*0.18)+'" r="'+(r*0.42)+'" fill="'+c2+'" opacity="0.55"/>');
            if(stage>=3){ for(var i=0;i<8;i++){var a=i*45*Math.PI/180,px=cx+(r+5)*Math.cos(a),py=cY+(r+5)*Math.sin(a);p.push('<ellipse cx="'+px.toFixed(1)+'" cy="'+py.toFixed(1)+'" rx="6" ry="4" fill="'+c2+'" opacity="0.85" class="fb" transform="rotate('+(i*45+90)+' '+px.toFixed(1)+' '+py.toFixed(1)+')"/>');} }
            if(stage===4){p.push('<circle cx="'+cx+'" cy="'+cY+'" r="11" fill="'+cf+'" class="fb"/>');p.push('<circle cx="'+cx+'" cy="'+cY+'" r="6" fill="'+ct+'"/>',[0,1,2,3,4,5].forEach(function(j){var a2=(j*60+10)*Math.PI/180,px2=cx+(r+13)*Math.cos(a2),py2=cY+(r+13)*Math.sin(a2);p.push('<circle cx="'+px2.toFixed(1)+'" cy="'+py2.toFixed(1)+'" r="3.5" fill="'+cf+'" class="fb"/>');});}
        } else if(t.shape==='cactus'){
            var cH=[0,38,58,72,80][stage],cW=[0,15,17,19,21][stage],cTop=cY-cH*0.6;
            p.push('<rect x="'+(cx-cW/2)+'" y="'+cTop+'" width="'+cW+'" height="'+cH+'" rx="'+(cW/2)+'" fill="'+c1+'"/>');
            for(var si=0;si<4;si++){var sY=cTop+cH*(0.2+si*0.18);p.push('<line x1="'+(cx-cW/2)+'" y1="'+sY+'" x2="'+(cx-cW/2-5)+'" y2="'+(sY-2)+'" stroke="'+c2+'" stroke-width="1.5"/>');p.push('<line x1="'+(cx+cW/2)+'" y1="'+sY+'" x2="'+(cx+cW/2+5)+'" y2="'+(sY-2)+'" stroke="'+c2+'" stroke-width="1.5"/>');}
            if(stage>=2){var aY=cTop+cH*0.35;p.push('<rect x="'+(cx-cW/2-17)+'" y="'+aY+'" width="17" height="9" rx="4" fill="'+c1+'"/>');p.push('<rect x="'+(cx-cW/2-17)+'" y="'+(aY-17)+'" width="9" height="24" rx="4" fill="'+c1+'"/>');p.push('<rect x="'+(cx+cW/2)+'" y="'+aY+'" width="17" height="9" rx="4" fill="'+c1+'"/>');p.push('<rect x="'+(cx+cW/2+8)+'" y="'+(aY-17)+'" width="9" height="24" rx="4" fill="'+c1+'"/>');}
            if(stage>=3){p.push('<circle cx="'+cx+'" cy="'+cTop+'" r="9" fill="'+cf+'" class="fb"/>');p.push('<circle cx="'+cx+'" cy="'+cTop+'" r="5" fill="#fff" opacity="0.9"/>');}
            if(stage===4){p.push('<circle cx="'+cx+'" cy="'+cTop+'" r="13" fill="'+cf+'" class="fb"/>');p.push('<circle cx="'+cx+'" cy="'+cTop+'" r="7" fill="#fff"/>');var aY2=cTop-17;p.push('<circle cx="'+(cx-cW/2-13)+'" cy="'+aY2+'" r="7" fill="'+cf+'" class="fb"/>');p.push('<circle cx="'+(cx+cW/2+13)+'" cy="'+aY2+'" r="7" fill="'+cf+'" class="fb"/>')}
        } else if(t.shape==='cloud'){
            var cR=[0,20,30,38,42][stage];
            var offs=[[-cR*0.38,0],[cR*0.38,0],[0,-cR*0.3],[-cR*0.18,cR*0.22],[cR*0.18,cR*0.22]];
            offs.forEach(function(o){p.push('<circle cx="'+(cx+o[0]).toFixed(1)+'" cy="'+(cY+o[1]).toFixed(1)+'" r="'+(cR*0.74)+'" fill="'+c1+'" opacity="0.9"/>');});
            p.push('<circle cx="'+cx+'" cy="'+cY+'" r="'+(cR*0.6)+'" fill="'+c2+'" opacity="0.65"/>');
            if(stage>=3){for(var fi=0;fi<10;fi++){var fa=fi*36*Math.PI/180,fpx=cx+(cR*0.58)*Math.cos(fa),fpy=cY+(cR*0.58)*Math.sin(fa);p.push('<circle cx="'+fpx.toFixed(1)+'" cy="'+fpy.toFixed(1)+'" r="3.5" fill="'+cf+'" opacity="0.85" class="fb"/>');}}
            if(stage===4){for(var pi=0;pi<8;pi++){var pa=pi*45*Math.PI/180,ppx=cx+(cR+11)*Math.cos(pa),ppy=cY+(cR+11)*Math.sin(pa);p.push('<ellipse cx="'+ppx.toFixed(1)+'" cy="'+ppy.toFixed(1)+'" rx="5" ry="3" fill="'+cf+'" opacity="0.9" class="fb" transform="rotate('+(pi*45)+' '+ppx.toFixed(1)+' '+ppy.toFixed(1)+')"/>');}}
        } else if(t.shape==='layers'){
            var nl=Math.min(stage,3), mW=[0,36,52,68,74][stage], lH=26;
            for(var li=0;li<nl;li++){var lW=mW-li*11,lY2=cY+li*17-(nl-1)*8.5;var pts=[(cx-lW/2)+','+(lY2+lH),cx+','+lY2,(cx+lW/2)+','+(lY2+lH)];p.push('<polygon points="'+pts.join(' ')+'" fill="'+c1+'" opacity="'+(1-li*0.08)+'"/>');p.push('<polygon points="'+pts.join(' ')+'" fill="'+c2+'" opacity="0.3"/>');}
            if(stage===4){for(var gi=0;gi<6;gi++){var ga=gi*60*Math.PI/180,gpx=cx+(mW*0.42)*Math.cos(ga),gpy=cY+(mW*0.28)*Math.sin(ga);p.push('<circle cx="'+gpx.toFixed(1)+'" cy="'+gpy.toFixed(1)+'" r="4" fill="'+cf+'" class="fb"/>')};}
        } else { // oval (มรกต)
            var oRX=[0,19,29,37,41][stage], oRY=[0,29,46,58,64][stage];
            p.push('<ellipse cx="'+cx+'" cy="'+cY+'" rx="'+oRX+'" ry="'+oRY+'" fill="'+c1+'"/>');
            p.push('<ellipse cx="'+(cx-oRX*0.18)+'" cy="'+(cY-oRY*0.2)+'" rx="'+(oRX*0.52)+'" ry="'+(oRY*0.38)+'" fill="'+c2+'" opacity="0.55"/>');
            if(stage>=3){for(var di=0;di<5;di++){var da=(di*72+36)*Math.PI/180,dpx=cx+(oRX*0.7)*Math.cos(da),dpy=cY+(oRY*0.62)*Math.sin(da);p.push('<polygon points="'+(dpx)+','+(dpy-6)+' '+(dpx+4)+','+dpy+' '+dpx+','+(dpy+4)+' '+(dpx-4)+','+dpy+'" fill="'+cf+'" class="fb" opacity="0.9"/>');}}
            if(stage===4){for(var egi=0;egi<7;egi++){var ea=egi*360/7*Math.PI/180,epx=cx+(oRX+8)*Math.cos(ea),epy=cY+(oRY+8)*Math.sin(ea);p.push('<circle cx="'+epx.toFixed(1)+'" cy="'+epy.toFixed(1)+'" r="4" fill="'+cf+'" class="fb" opacity="0.85"/>')};}
        }
    }
    p.push('</svg>');
    return p.join('');
}

// ===== INIT =====
function init() {
    var now=new Date();
    var days=['อาทิตย์','จันทร์','อังคาร','พุธ','พฤหัสบดี','ศุกร์','เสาร์'];
    document.getElementById('todayLabel').textContent=
        'วัน'+days[now.getDay()]+' '+now.getDate()+' '+MONTH_TH[now.getMonth()]+' '+(now.getFullYear()+543);
    curMonth=now.getMonth(); curYear=now.getFullYear();
    editingTreeType=loadGame().treeType>=0?loadGame().treeType:0;
    updateRankBadge();
    renderToday();
}
document.addEventListener('DOMContentLoaded', init);
</script>
</asp:Content>
