<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master"
    AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CustomerHealthCheck.views.accounting.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="utf-8" />
<title>บัญชีรายรับรายจ่าย</title>
<style>
.acct-wrap { background: whitesmoke; min-height: 100vh; padding-bottom: 90px; }
.acct-wrap > div:first-child { margin-top: 0 !important; }

@keyframes acct-icon-pulse {
    0%,100%{ transform:scale(1); filter:drop-shadow(0 0 6px rgba(5,150,105,.4)); }
    50%     { transform:scale(1.10); filter:drop-shadow(0 0 20px rgba(5,150,105,.85)); }
}
.acct-header { padding:10px 16px 16px; text-align:center; position:relative; }
.acct-header-icon { font-size:60px; display:block; margin-bottom:6px;
    animation:acct-icon-pulse 2.5s ease-in-out infinite; }
.acct-title    { font-size:20px; font-weight:800; color:darkblue; margin:0; }
.acct-subtitle { font-size:11px; color:darkblue; margin-top:1px; }
.acct-date-badge {
    display:inline-block; background:rgba(255,255,255,.88);
    border:1px solid rgba(19,68,160,.18); border-radius:20px;
    padding:4px 14px; font-size:12px; font-weight:700;
    color:#1344a0; margin-top:8px;
}
.rank-wrap { margin-top:6px; }
.rank-lbl  { font-size:10px; color:darkblue; font-weight:600; margin-bottom:3px; }
.rank-badge {
    display:inline-flex; align-items:center; gap:5px;
    padding:4px 12px; border-radius:20px;
    font-size:12px; font-weight:800; border:1.5px solid transparent;
}
.rank-0{ background:#f1f5f9; color:#64748b; border-color:#e2e8f0; }
.rank-1{ background:#dcfce7; color:#166534; border-color:#22c55e; }
.rank-2{ background:#dbeafe; color:#1e40af; border-color:#3b82f6; }
.rank-3{ background:#fef3c7; color:#92400e; border-color:#fbbf24; }
.rank-4{ background:linear-gradient(135deg,#fef9c3,#fde68a); color:#78350f; border-color:#f59e0b;
         animation:rank-glow 3s ease-in-out infinite; }
.rank-5{ background:linear-gradient(135deg,#ede9fe,#c4b5fd); color:#4c1d95; border-color:#8b5cf6;
         animation:rank-glow 2.5s ease-in-out infinite; }
@keyframes rank-glow{
    0%,100%{ box-shadow:0 0 0 0 rgba(245,158,11,.25); }
    50%     { box-shadow:0 0 0 5px rgba(245,158,11,0); }
}

/* --- Daily Check-in --- */
.checkin-card {
    margin:0 14px 12px; border-radius:16px; padding:12px 16px;
    background:linear-gradient(135deg,#0c1b3a,#1344a0);
    display:flex; align-items:center; gap:12px;
    box-shadow:0 4px 14px rgba(19,68,160,.3);
}
.checkin-info { flex:1; min-width:0; }
.checkin-info strong { display:block; font-size:13px; font-weight:800; color:#fff; }
.checkin-info span   { font-size:11px; color:rgba(255,255,255,.75); }
.checkin-btn {
    padding:8px 16px; border-radius:20px; border:none; cursor:pointer;
    font-size:12px; font-weight:800; white-space:nowrap;
    background:#fbbf24; color:#78350f;
    box-shadow:0 2px 8px rgba(251,191,36,.4);
    transition:transform .15s;
}
.checkin-btn:active{ transform:scale(.95); }
.checkin-btn.claimed{ background:#f0fdf4; color:#166534; border:1.5px solid #22c55e; box-shadow:none; cursor:default; }

/* --- Tabs --- */
.tabs-row { display:flex; gap:4px; padding:0 14px 12px; }
.tab-btn {
    flex:1; text-align:center; padding:7px 2px; font-size:12px; font-weight:700;
    border-radius:18px; cursor:pointer; border:none;
    background:#e8f0fe; color:#1344a0; transition:all .18s;
}
.tab-btn.active{ background:#1344a0; color:#fff; box-shadow:0 2px 8px rgba(19,68,160,.3); }

/* --- Balance card --- */
.balance-card {
    background:linear-gradient(135deg,#1344a0 0%,#059669 100%);
    border-radius:18px; padding:18px; margin:0 14px 12px; color:#fff;
    box-shadow:0 4px 16px rgba(19,68,160,.25);
}
.balance-net { font-size:30px; font-weight:900; letter-spacing:-1px; }
.balance-lbl { font-size:11px; opacity:.85; margin-bottom:2px; }
.balance-row { display:flex; gap:10px; margin-top:12px; }
.balance-col { flex:1; background:rgba(255,255,255,.15); border-radius:12px; padding:8px 10px; }
.balance-col-amt{ font-size:15px; font-weight:800; }
.balance-col-lbl{ font-size:10px; opacity:.85; }

/* --- Add buttons --- */
.add-row { display:flex; gap:10px; padding:0 14px 12px; }
.add-btn {
    flex:1; padding:11px 8px; border-radius:14px; font-size:13px; font-weight:700;
    border:none; cursor:pointer; display:flex; align-items:center;
    justify-content:center; gap:6px; transition:transform .15s;
}
.add-btn:active{ transform:scale(.96); }
.btn-inc{ background:#dcfce7; color:#166534; border:1.5px solid #22c55e; }
.btn-exp{ background:#fee2e2; color:#991b1b; border:1.5px solid #ef4444; }

/* --- Transactions --- */
.tx-card { background:#fff; border-radius:14px; margin:0 14px 8px; overflow:hidden;
           box-shadow:0 2px 8px rgba(19,68,160,.07); }
.tx-date-hdr { font-size:11px; font-weight:700; color:#64748b; padding:7px 14px 5px;
               background:#f8faff; }
.tx-item { display:flex; align-items:center; gap:12px; padding:11px 14px;
           cursor:pointer; transition:background .12s; }
.tx-item:active{ background:#f8faff; }
.tx-divider{ height:1px; background:#f0f6ff; margin:0 14px; }
.tx-icon { width:40px; height:40px; border-radius:11px; flex-shrink:0;
           display:flex; align-items:center; justify-content:center; font-size:18px; }
.ti-inc{ background:#dcfce7; } .ti-exp{ background:#fee2e2; }
.tx-info{ flex:1; min-width:0; }
.tx-cat { font-size:13px; font-weight:700; color:#0c1b3a; }
.tx-note{ font-size:11px; color:#64748b; margin-top:1px; white-space:nowrap;
          overflow:hidden; text-overflow:ellipsis; }
.tx-amt  { font-size:14px; font-weight:800; flex-shrink:0; }
.ta-inc{ color:#16a34a; } .ta-exp{ color:#dc2626; }
.tx-del { font-size:18px; color:#cbd5e1; flex-shrink:0; padding:4px 6px;
          cursor:pointer; border:none; background:none; }
.empty-state{ text-align:center; padding:40px 20px; color:#94a3b8; }
.empty-icon{ font-size:44px; margin-bottom:8px; }

/* --- Section header --- */
.sect-hdr { display:flex; justify-content:space-between; align-items:center;
            padding:4px 14px 8px; }
.sect-hdr-title{ font-size:13px; font-weight:800; color:#0c1b3a; }

/* --- Period nav --- */
.period-nav { display:flex; align-items:center; justify-content:center;
              gap:18px; padding:8px 14px 6px; }
.period-btn { width:34px; height:34px; border-radius:50%; background:#e8f0fe;
              border:none; cursor:pointer; font-size:16px; color:#1344a0; }
.period-lbl { font-size:15px; font-weight:800; color:#0c1b3a;
              min-width:130px; text-align:center; }

/* --- Summary card --- */
.summary-card { background:#fff; border-radius:14px; margin:0 14px 10px;
                padding:14px; box-shadow:0 2px 8px rgba(19,68,160,.07); }
.summary-row { display:flex; gap:8px; }
.sum-col { flex:1; border-radius:10px; padding:9px 10px; }
.sc-inc{ background:#f0fdf4; border:1px solid #bbf7d0; }
.sc-exp{ background:#fff1f2; border:1px solid #fecdd3; }
.sc-net{ background:#eff6ff; border:1px solid #bfdbfe; }
.sum-lbl{ font-size:10px; color:#64748b; font-weight:600; }
.sum-amt{ font-size:16px; font-weight:800; margin-top:2px; }
.sc-inc .sum-amt{ color:#16a34a; }
.sc-exp .sum-amt{ color:#dc2626; }
.sc-net .sum-amt{ color:#1e40af; }

/* month day bar */
.day-bar-item { display:flex; align-items:center; gap:10px;
                padding:9px 14px; border-bottom:1px solid #f0f6ff; cursor:pointer; }
.day-bar-lbl { font-size:11px; font-weight:700; color:#475569; width:44px; flex-shrink:0; }
.day-bar-track{ flex:1; display:flex; flex-direction:column; gap:2px; }
.day-bar-bg { height:7px; background:#f1f5f9; border-radius:4px; overflow:hidden; }
.day-bar-fill{ height:100%; border-radius:4px; }
.dbf-inc{ background:#22c55e; } .dbf-exp{ background:#ef4444; }
.day-bar-net{ font-size:11px; font-weight:700; width:62px; text-align:right; flex-shrink:0; }
.dbn-pos{ color:#16a34a; } .dbn-neg{ color:#dc2626; } .dbn-z{ color:#94a3b8; }

/* year grid */
.year-grid { display:grid; grid-template-columns:1fr 1fr; gap:8px; margin:0 14px 8px; }
.ym-card { background:#fff; border-radius:12px; padding:10px 12px;
           box-shadow:0 1px 6px rgba(19,68,160,.07); cursor:pointer; }
.ym-name{ font-size:12px; font-weight:700; color:#0c1b3a; margin-bottom:4px; }
.ym-row { font-size:11px; font-weight:600; }
.ym-inc{ color:#16a34a; } .ym-exp{ color:#dc2626; }
.ym-net{ font-size:12px; font-weight:800; margin-top:2px; }

/* ============ GARDEN ============ */
.garden-section-sep {
    display:flex; align-items:center; gap:10px;
    padding:14px 14px 10px; font-size:14px; font-weight:800; color:#0c1b3a;
}
.garden-section-sep::before,.garden-section-sep::after {
    content:''; flex:1; height:1px; background:#e2e8f0;
}
.garden-wrap { padding:0 14px 10px; }

/* Tree scene */
.garden-scene {
    background:linear-gradient(180deg,#bfdbfe 0%,#dbeafe 38%,#e0f2fe 65%,#ecfdf5 100%);
    border-radius:20px; padding:16px 16px 0; position:relative;
    min-height:220px; overflow:hidden;
    box-shadow:0 2px 12px rgba(19,68,160,.10);
    margin-bottom:10px;
}
.gs-sun {
    position:absolute; top:14px; right:18px;
    width:32px; height:32px; border-radius:50%;
    background:radial-gradient(circle,#fde68a,#f59e0b);
    box-shadow:0 0 14px rgba(245,158,11,.55);
    animation:sun-p 4s ease-in-out infinite;
}
@keyframes sun-p{ 0%,100%{box-shadow:0 0 10px rgba(245,158,11,.35);}
                  50%{box-shadow:0 0 22px rgba(245,158,11,.7);} }
.gs-cloud {
    position:absolute; top:18px; left:16px;
    width:60px; height:22px;
    animation:cloud-d 9s ease-in-out infinite alternate;
}
.gs-cloud::before,.gs-cloud::after {
    content:''; position:absolute; border-radius:50%;
    background:rgba(255,255,255,.82);
}
.gs-cloud::before{ width:38px;height:22px;bottom:0;left:8px; }
.gs-cloud::after { width:24px;height:16px;bottom:4px;left:2px;
                   box-shadow:20px 0 0 rgba(255,255,255,.82); }
@keyframes cloud-d{ 0%{transform:translateX(0);} 100%{transform:translateX(12px);} }
.gs-ground {
    position:absolute; bottom:0; left:0; right:0; height:42px;
    background:linear-gradient(180deg,#bbf7d0,#86efac);
    border-radius:0 0 20px 20px;
}
.gs-ground::before {
    content:''; position:absolute; top:-9px; left:0; right:0;
    height:16px; background:#4ade80; border-radius:50%;
}
.tree-display { display:flex; align-items:flex-end; justify-content:center;
                padding-bottom:42px; position:relative; z-index:2; min-height:160px; }
@keyframes tree-sway {
    0%,100%{ transform-origin:bottom center; transform:rotate(0deg); }
    33%     { transform-origin:bottom center; transform:rotate(1.5deg); }
    66%     { transform-origin:bottom center; transform:rotate(-1.5deg); }
}
.tree-svg-anim { animation:tree-sway 3.5s ease-in-out infinite; }
@keyframes fb { 0%,100%{transform:scale(1);} 50%{transform:scale(1.2);} }
.fb { animation:fb 2s ease-in-out infinite; transform-origin:center; }

/* Tree info */
.tree-info-card {
    background:#fff; border-radius:14px; padding:14px;
    box-shadow:0 2px 8px rgba(19,68,160,.07); margin-bottom:10px;
}
.ti-row { display:flex; align-items:center; gap:10px; margin-bottom:8px; }
.ti-names { flex:1; }
.ti-name { font-size:15px; font-weight:800; color:#0c1b3a; }
.ti-type-tag { display:inline-block; padding:2px 8px; border-radius:10px;
               font-size:10px; font-weight:700; margin-top:2px; }
.ti-stage-row { display:flex; justify-content:space-between; font-size:11px;
                color:#64748b; margin-bottom:3px; }
.xp-bar-bg  { background:#f1f5f9; border-radius:6px; height:10px; overflow:hidden; }
.xp-bar-fg  { height:100%; background:linear-gradient(90deg,#22c55e,#16a34a);
              border-radius:6px; transition:width .5s ease; }
.ti-action-row{ display:flex; gap:8px; margin-top:10px; }
.ti-action-btn {
    flex:1; padding:8px; border-radius:10px; font-size:11px; font-weight:700;
    border:none; cursor:pointer; transition:transform .15s;
}
.ti-action-btn:active{ transform:scale(.96); }
.btn-ti-info  { background:#eff6ff; color:#1e40af; }
.btn-ti-change{ background:#f0fdf4; color:#166534; }

/* Tree picker in page */
.tree-pick-banner {
    background:#fff; border-radius:14px; padding:14px;
    box-shadow:0 2px 8px rgba(19,68,160,.07); margin-bottom:10px;
}
.tree-pick-title { font-size:14px; font-weight:800; color:#0c1b3a;
                   text-align:center; margin-bottom:4px; }
.tree-pick-sub   { font-size:11px; color:#94a3b8; text-align:center; margin-bottom:12px; }
.tree-pick-grid  { display:grid; grid-template-columns:1fr 1fr; gap:8px; margin-bottom:12px; }
.tp-card {
    border:2px solid #e8f0fe; border-radius:12px; padding:10px 8px;
    text-align:center; cursor:pointer; transition:all .18s; background:#fff;
}
.tp-card:active{ transform:scale(.96); }
.tp-card.sel{ border-color:#1344a0; background:#eff6ff; }
.tp-emoji{ font-size:30px; margin-bottom:3px; }
.tp-name { font-size:11px; font-weight:800; color:#0c1b3a; }
.tp-desc { font-size:9px; color:#94a3b8; margin-top:1px; }

/* Basket */
.basket-card {
    background:#fff; border-radius:14px; padding:14px;
    box-shadow:0 2px 8px rgba(19,68,160,.07);
}
.basket-hdr { display:flex; justify-content:space-between; align-items:center;
              margin-bottom:10px; }
.basket-hdr-title { font-size:13px; font-weight:800; color:#0c1b3a; }
.basket-items { display:flex; gap:8px; }
.bsk-item {
    flex:1; background:#f8faff; border-radius:12px; padding:10px 6px;
    text-align:center; border:1.5px solid #e8f0fe;
    transition:all .15s;
}
.bsk-item.active{ border-color:#22c55e; background:#f0fdf4; cursor:pointer; }
.bsk-item.active:active{ transform:scale(.95); }
.bsk-icon  { font-size:24px; }
.bsk-name  { font-size:9px; color:#64748b; margin-top:2px; font-weight:600; }
.bsk-count { font-size:18px; font-weight:900; color:#94a3b8; }
.bsk-item.active .bsk-count{ color:#16a34a; }
.bsk-xp    { font-size:9px; color:#cbd5e1; }
.bsk-item.active .bsk-xp{ color:#059669; }
.basket-hint{ font-size:11px; color:#94a3b8; text-align:center; margin-top:8px; }

/* Stage progress dots */
.stage-dots { display:flex; justify-content:center; gap:8px; margin-top:10px; }
.stage-dot { text-align:center; }
.stage-dot-circle {
    width:28px; height:28px; border-radius:50%; margin:0 auto 3px;
    display:flex; align-items:center; justify-content:center;
    font-size:12px; border:2px solid #e2e8f0; background:#f8faff; color:#94a3b8;
}
.stage-dot.done .stage-dot-circle{ background:#22c55e; border-color:#16a34a; color:#fff; }
.stage-dot.current .stage-dot-circle{ background:#fbbf24; border-color:#f59e0b; color:#fff; }
.stage-dot-lbl { font-size:8px; color:#94a3b8; font-weight:600; }
.stage-dot.done .stage-dot-lbl { color:#16a34a; }
.stage-dot.current .stage-dot-lbl { color:#f59e0b; }

/* Toast */
.reward-toast {
    position:fixed; top:70px; left:50%;
    transform:translateX(-50%) translateY(-120px);
    background:#fff; border-radius:16px; padding:12px 18px;
    box-shadow:0 8px 28px rgba(0,0,0,.18); z-index:9999;
    display:flex; align-items:center; gap:10px;
    transition:transform .4s cubic-bezier(0.34,1.56,0.64,1);
    pointer-events:none; border:1.5px solid #bbf7d0;
    white-space:nowrap;
}
.reward-toast.show{ transform:translateX(-50%) translateY(0); }
.r-toast-icon { font-size:28px; }
.r-toast-text strong { display:block; font-size:13px; color:#0c1b3a; }
.r-toast-text span   { font-size:11px; color:#64748b; }

/* Modal */
.modal-acct .modal-content { border-radius:20px 20px 0 0; border:none; }
.modal-acct .modal-dialog  { margin:0; position:absolute; bottom:0; width:100%; max-width:100%; }
.modal-title-txt { font-size:16px; font-weight:800; color:#0c1b3a; }
.form-lbl { font-size:12px; font-weight:700; color:#475569; margin-bottom:4px; }
.cat-chips{ display:flex; flex-wrap:wrap; gap:6px; }
.cat-chip {
    padding:5px 12px; border-radius:16px; font-size:12px; font-weight:600;
    border:1.5px solid #e2e8f0; background:#f8faff; cursor:pointer;
    color:#475569; transition:all .15s;
}
.cat-chip.sel{ border-color:#1344a0; background:#eff6ff; color:#1e40af; }
</style>
<!-- Modal: Random Seed -->
<div class="modal fade modal-acct" id="seedModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-txt">&#127922; สุ่มเมล็ดพันธุ์</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 28px;text-align:center;">
                <div id="seedSpinner" style="font-size:64px;margin:20px 0 8px;min-height:80px;display:flex;align-items:center;justify-content:center;transition:all .12s;">&#127807;</div>
                <div id="seedResultName" style="font-size:18px;font-weight:800;color:#1344a0;min-height:26px;margin-bottom:4px;"></div>
                <div id="seedResultDesc" style="font-size:12px;color:#64748b;min-height:18px;margin-bottom:20px;"></div>
                <button type="button" id="btnConfirmSeed" style="width:100%;padding:13px;background:#1344a0;color:#fff;border:none;border-radius:14px;font-size:14px;font-weight:800;cursor:pointer;display:none;">&#127807; ยืนยันปลูกต้นนี้!</button>
                <button type="button" id="btnRollAgain" style="width:100%;padding:11px;background:#f1f5f9;color:#475569;border:none;border-radius:14px;font-size:13px;font-weight:700;cursor:pointer;margin-top:8px;display:none;">&#127922; สุ่มใหม่อีกครั้ง</button>
            </div>
        </div>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="acct-wrap">

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
           padding:6px 14px;background:rgba(255,255,255,.85);border-radius:20px;
           font-size:13px;font-weight:700;color:#1344a0;text-decoration:none;
           margin:0 14px;border:1px solid rgba(19,68,160,.15);">
            <i class="bi bi-arrow-left"></i> กลับ
        </a>
    </div>
    <div class="acct-header" style="position:relative;z-index:1;">
        <i class="bi bi-journal-bookmark-fill acct-header-icon" style="color:#059669;"></i>
        <h1 class="acct-title">บัญชีรายรับรายจ่าย</h1>
        <h5 class="acct-subtitle">บันทึกรายวัน &bull; สรุปรายเดือน &bull; ดูย้อนหลัง</h5>
        <div class="acct-date-badge" id="todayLabel">—</div>
        <div class="rank-wrap">
            <div class="rank-lbl">ระดับความสม่ำเสมอ</div>
            <div id="rankBadge" class="rank-badge rank-0">📝 มือใหม่</div>
        </div>
    </div>
</div>

<!-- Daily Check-in Card -->
<div class="checkin-card">
    <div class="checkin-info">
        <strong>🎁 รับน้ำรดต้นไม้ประจำวัน</strong>
        <span id="checkinDesc">บันทึกครั้งแรกของวันนี้ หรือกดรับได้เลย</span>
    </div>
    <button type="button" class="checkin-btn" id="btnCheckin">รับเลย!</button>
</div>

<!-- 3 Tabs -->
<div class="tabs-row">
    <button type="button" class="tab-btn active" data-tab="today">วันนี้</button>
    <button type="button" class="tab-btn" data-tab="month">เดือน</button>
    <button type="button" class="tab-btn" data-tab="year">ปี</button>
</div>

<!-- Tab: วันนี้ -->
<div id="panel-today">
    <div class="balance-card">
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
    <div class="add-row">
        <button type="button" class="add-btn btn-inc" id="btnAddIncome">
            <i class="bi bi-plus-circle-fill"></i> + รายรับ
        </button>
        <button type="button" class="add-btn btn-exp" id="btnAddExpense">
            <i class="bi bi-dash-circle-fill"></i> + รายจ่าย
        </button>
    </div>
    <div class="sect-hdr">
        <span class="sect-hdr-title">รายการวันนี้</span>
    </div>
    <div id="txListToday"></div>
</div>

<!-- Tab: เดือน -->
<div id="panel-month" style="display:none;">
    <div class="period-nav">
        <button type="button" class="period-btn" id="btnMonthPrev">&#8249;</button>
        <div class="period-lbl" id="monthLabel">—</div>
        <button type="button" class="period-btn" id="btnMonthNext">&#8250;</button>
    </div>
    <div class="summary-card">
        <div class="summary-row">
            <div class="sum-col sc-inc">
                <div class="sum-lbl">รายรับ</div>
                <div class="sum-amt" id="mInc">฿0</div>
            </div>
            <div class="sum-col sc-exp">
                <div class="sum-lbl">รายจ่าย</div>
                <div class="sum-amt" id="mExp">฿0</div>
            </div>
            <div class="sum-col sc-net">
                <div class="sum-lbl">สุทธิ</div>
                <div class="sum-amt" id="mNet">฿0</div>
            </div>
        </div>
    </div>
    <div class="sect-hdr"><span class="sect-hdr-title">รายวัน</span></div>
    <div class="tx-card" id="monthDayList"></div>
</div>

<!-- Tab: ปี -->
<div id="panel-year" style="display:none;">
    <div class="period-nav">
        <button type="button" class="period-btn" id="btnYearPrev">&#8249;</button>
        <div class="period-lbl" id="yearLabel">—</div>
        <button type="button" class="period-btn" id="btnYearNext">&#8250;</button>
    </div>
    <div class="summary-card">
        <div class="summary-row">
            <div class="sum-col sc-inc">
                <div class="sum-lbl">รายรับ</div>
                <div class="sum-amt" id="yInc">฿0</div>
            </div>
            <div class="sum-col sc-exp">
                <div class="sum-lbl">รายจ่าย</div>
                <div class="sum-amt" id="yExp">฿0</div>
            </div>
            <div class="sum-col sc-net">
                <div class="sum-lbl">สุทธิ</div>
                <div class="sum-amt" id="yNet">฿0</div>
            </div>
        </div>
    </div>
    <div class="sect-hdr"><span class="sect-hdr-title">รายเดือน</span></div>
    <div class="year-grid" id="yearGrid"></div>
</div>

<!-- ======== GARDEN SECTION (always visible) ======== -->
<div class="garden-section-sep">🌱 สวนของฉัน</div>
<div class="garden-wrap">

    <!-- Tree scene -->
    <div class="garden-scene">
        <div class="gs-sun"></div>
        <div class="gs-cloud"></div>
        <div class="gs-ground"></div>
        <div class="tree-display" id="treeDisplay">
            <div style="text-align:center;padding:30px;color:#94a3b8;font-size:13px;">
                เลือกพันธุ์ต้นไม้เพื่อเริ่มปลูก &#127807;
            </div>
        </div>
    </div>

    <!-- Tree info card (hidden until tree chosen) -->
    <div class="tree-info-card" id="treeInfoCard" style="display:none;">
        <div class="ti-row">
            <span id="treeEmoji" style="font-size:28px;"></span>
            <div class="ti-names">
                <div class="ti-name" id="treeName">—</div>
                <span class="ti-type-tag" id="treeTypeTag">—</span>
            </div>
        </div>
        <div class="ti-stage-row">
            <span id="treeStageName">เมล็ด</span>
            <span id="treeXpText">XP: 0/5</span>
        </div>
        <div class="xp-bar-bg"><div class="xp-bar-fg" id="treeXpBar" style="width:0%"></div></div>
        <!-- Stage dots -->
        <div class="stage-dots" id="stageDots"></div>
        <div class="ti-action-row">
            <button type="button" class="ti-action-btn btn-ti-info" id="btnTreeInfo">&#8505;&#65039; ข้อมูลต้นไม้</button>
            <button type="button" class="ti-action-btn" id="btnUprootTree" style="background:#fee2e2;color:#dc2626;border:1px solid #fca5a5;">&#127804; ถอนปลูกใหม่</button>
        </div>
    </div>

    <!-- Start planting button (shown when no tree planted) -->
    <div class="tree-pick-banner" id="treePickBanner">
        <div style="text-align:center;padding:8px 0 4px;">
            <div style="font-size:36px;margin-bottom:8px;">&#127807;</div>
            <div style="font-size:15px;font-weight:800;color:#1344a0;margin-bottom:4px;">ยังไม่มีต้นไม้</div>
            <div style="font-size:12px;color:#64748b;margin-bottom:16px;">กดปุ่มเพื่อสุ่มเมล็ดพันธุ์ของคุณ</div>
        </div>
        <button type="button" id="btnStartPlant" style="width:100%;padding:13px;background:linear-gradient(135deg,#1344a0,#2563eb);color:#fff;border:none;border-radius:14px;font-size:15px;font-weight:800;cursor:pointer;letter-spacing:.3px;">
            &#127922; สุ่มเมล็ดพันธุ์ต้นไม้
        </button>
    </div>

    <!-- Basket -->
    <div class="basket-card" id="basketCard">
        <div class="basket-hdr">
            <span class="basket-hdr-title">&#129346; ตระกร้าของฉัน</span>
            <span style="font-size:11px;color:#94a3b8;">กดรดน้ำ &#8594; ต้นไม้โตขึ้น</span>
        </div>
        <div class="basket-items">
            <div class="bsk-item" id="bskCup" data-item="cup">
                <div class="bsk-icon">&#129380;</div>
                <div class="bsk-count" id="bskCupCnt">0</div>
                <div class="bsk-name">แก้วน้ำ</div>
                <div class="bsk-xp">+1 XP</div>
            </div>
            <div class="bsk-item" id="bskCan" data-item="can">
                <div class="bsk-icon">&#129635;</div>
                <div class="bsk-count" id="bskCanCnt">0</div>
                <div class="bsk-name">บัวรดน้ำ</div>
                <div class="bsk-xp">+2 XP</div>
            </div>
            <div class="bsk-item" id="bskBucket" data-item="bucket">
                <div class="bsk-icon">&#129508;</div>
                <div class="bsk-count" id="bskBucketCnt">0</div>
                <div class="bsk-name">ถังน้ำ</div>
                <div class="bsk-xp">+4 XP</div>
            </div>
        </div>
        <div class="basket-hint" id="basketHint">กดที่ช่องของในตระกร้าเพื่อรดน้ำต้นไม้</div>
    </div>

</div><!-- /garden-wrap -->

</div><!-- /acct-wrap -->

<!-- Toast -->
<div class="reward-toast" id="rewardToast">
    <div class="r-toast-icon" id="toastIcon">&#129380;</div>
    <div class="r-toast-text">
        <strong id="toastTitle">ได้รับรางวัลประจำวัน!</strong>
        <span id="toastSub">แก้วน้ำ 1 ใบ เพิ่มในตระกร้า</span>
    </div>
</div>

<!-- Modal: Add/Edit Transaction -->
<div class="modal fade modal-acct" id="txModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-txt" id="txModalTitle">เพิ่มรายรับ</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 24px;">
                <input type="hidden" id="txId" />
                <input type="hidden" id="txType" value="income" />
                <div style="margin-bottom:12px;">
                    <div class="form-lbl">จำนวนเงิน (บาท)</div>
                    <input type="number" id="txAmount" class="form-control"
                           placeholder="0.00" min="0" step="0.01"
                           style="border-radius:10px;font-size:18px;font-weight:700;" />
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
                    <input type="text" id="txNote" class="form-control"
                           placeholder="รายละเอียดเพิ่มเติม..." style="border-radius:10px;" maxlength="80" />
                </div>
                <button type="button" id="btnSaveTx"
                        style="width:100%;padding:13px;border-radius:14px;border:none;
                               background:#1344a0;color:#fff;font-size:14px;font-weight:800;cursor:pointer;">
                    บันทึก
                </button>
            </div>
        </div>
    </div>
</div>

<!-- Modal: Tree Detail -->
<div class="modal fade modal-acct" id="treeDetailModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-txt" id="treeDetailTitle">ข้อมูลต้นไม้</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 24px;" id="treeDetailBody"></div>
        </div>
    </div>
</div>

<script>
// ========= DATA =========
var CATS = {
    income:  ['เงินเดือน','ขายสินค้า','รับจ้าง','โอนเงิน','ดอกเบี้ย','อื่นๆ'],
    expense: ['อาหาร','เดินทาง','ค่าเช่า','ค่าน้ำค่าไฟ','สุขภาพ','บันเทิง','ช้อปปิ้ง','อื่นๆ']
};
var MONTH_TH = ['มกราคม','กุมภาพันธ์','มีนาคม','เมษายน','พฤษภาคม','มิถุนายน',
                'กรกฎาคม','สิงหาคม','กันยายน','ตุลาคม','พฤศจิกายน','ธันวาคม'];
var DAYS_TH  = ['อาทิตย์','จันทร์','อังคาร','พุธ','พฤหัสบดี','ศุกร์','เสาร์'];
var RANKS = [
    {min:0,  lbl:'มือใหม่',     icon:'📝', cls:'rank-0'},
    {min:3,  lbl:'นักบันทึก',   icon:'✏️', cls:'rank-1'},
    {min:7,  lbl:'ผู้ขยัน',     icon:'📊', cls:'rank-2'},
    {min:14, lbl:'นักบัญชี',    icon:'💰', cls:'rank-3'},
    {min:30, lbl:'นักการเงิน',  icon:'💼', cls:'rank-4'},
    {min:60, lbl:'ผู้เชี่ยวชาญ',icon:'🏆', cls:'rank-5'}
];
var TREES = [
    {name:'ดาวเรือง', desc:'ส่องแสงความมั่งคั่ง',   emoji:'🌻',
     shape:'round',  c1:'#f59e0b',c2:'#fde68a',cf:'#dc2626',ct:'#92400e',
     tagBg:'#fef3c7',tagC:'#92400e'},
    {name:'แก้วมังกร',desc:'พลังจากมังกร',          emoji:'🌵',
     shape:'cactus', c1:'#059669',c2:'#6ee7b7',cf:'#f43f5e',ct:'#065f46',
     tagBg:'#dcfce7',tagC:'#166534'},
    {name:'ซากุระมิดี',desc:'ความงามและความอุดม',    emoji:'🌸',
     shape:'cloud',  c1:'#fda4af',c2:'#fbcfe8',cf:'#ec4899',ct:'#9d174d',
     tagBg:'#fce7f3',tagC:'#9d174d'},
    {name:'ต้นทองแถบ', desc:'โชคลาภทองคำไหลหลั่ง',  emoji:'🏆',
     shape:'layers', c1:'#d97706',c2:'#fde68a',cf:'#eab308',ct:'#78350f',
     tagBg:'#fef9c3',tagC:'#78350f'},
    {name:'มรกตลี้ลับ',desc:'ปัญญาแห่งสรรพสิ่ง',    emoji:'💎',
     shape:'oval',   c1:'#0ea5e9',c2:'#bae6fd',cf:'#7c3aed',ct:'#1e3a8a',
     tagBg:'#eff6ff',tagC:'#1e40af'}
];
var STAGES   = ['เมล็ด','ต้นกล้า','ต้นรุ่น','กำลังออกดอก','ออกผลแล้ว'];
var STAGE_XP = [5, 12, 22, 30];
var ITEM_XP  = {cup:1, can:2, bucket:4};
var ITEM_EMO = {cup:'🥤', can:'🪣', bucket:'🪤'};
var ITEM_NAME= {cup:'แก้วน้ำ', can:'บัวรดน้ำ', bucket:'ถังน้ำ'};

// ========= STATE =========
var curTab   = 'today';
var curMonth, curYear, selectedCat = '';
var pickedTreeType = 0;

// ========= STORAGE =========
function loadTx() {
    try { return JSON.parse(localStorage.getItem('acct_tx') || '[]'); } catch(e){return [];}
}
function storeTxArr(arr) { localStorage.setItem('acct_tx', JSON.stringify(arr)); }
function loadGame() {
    var g;
    try { g = JSON.parse(localStorage.getItem('acct_game')); } catch(e){}
    if (!g) g = {treeType:-1,stage:0,xp:0,basket:{cup:0,can:0,bucket:0},
                  totalDays:0,lastCheckin:null,totalWatered:0};
    if (!g.basket) g.basket = {cup:0,can:0,bucket:0};
    return g;
}
function saveGame(g) { localStorage.setItem('acct_game', JSON.stringify(g)); }

// ========= HELPERS =========
function pad(n)   { return n < 10 ? '0' + n : '' + n; }
function todayStr(){ var n=new Date(); return n.getFullYear()+'-'+pad(n.getMonth()+1)+'-'+pad(n.getDate()); }
function fmtAmt(n){ return '฿' + Math.abs(n).toLocaleString('th-TH',{minimumFractionDigits:0,maximumFractionDigits:2}); }
function genId()  { return Date.now().toString(36) + Math.random().toString(36).slice(2,6); }

function calcSum(txArr) {
    var inc=0, exp=0;
    txArr.forEach(function(t){ if(t.type==='income') inc+=t.amount; else exp+=t.amount; });
    return {inc:inc, exp:exp, net:inc-exp};
}
function getTxDay(d)   { return loadTx().filter(function(t){return t.date===d;}); }
function getTxMonth(y,m){ var k=y+'-'+pad(m+1); return loadTx().filter(function(t){return t.date.slice(0,7)===k;}); }
function getTxYear(y)  { return loadTx().filter(function(t){return t.date.slice(0,4)===''+y;}); }

// ========= RANK =========
function getRankIdx(days) {
    var idx=0;
    for(var i=0;i<RANKS.length;i++){ if(days>=RANKS[i].min) idx=i; }
    return idx;
}
function updateRankBadge() {
    var g=loadGame(), ri=getRankIdx(g.totalDays), r=RANKS[ri];
    var el=document.getElementById('rankBadge');
    el.className = 'rank-badge ' + r.cls;
    el.innerHTML = r.icon + ' ' + r.lbl +
        ' <span style="font-weight:400;opacity:.7;margin-left:3px;">' + g.totalDays + ' วัน</span>';
}
function updateEntryDays() {
    var dates = new Set();
    loadTx().forEach(function(t){dates.add(t.date);});
    var g = loadGame();
    g.totalDays = dates.size;
    saveGame(g);
    updateRankBadge();
}

// ========= TAB SWITCHING =========
function switchTab(tab) {
    curTab = tab;
    document.querySelectorAll('.tab-btn').forEach(function(b){
        b.classList.toggle('active', b.getAttribute('data-tab') === tab);
    });
    document.getElementById('panel-today').style.display  = tab==='today'  ? '' : 'none';
    document.getElementById('panel-month').style.display  = tab==='month'  ? '' : 'none';
    document.getElementById('panel-year').style.display   = tab==='year'   ? '' : 'none';
    if(tab==='today')  renderToday();
    if(tab==='month')  renderMonth();
    if(tab==='year')   renderYear();
}

// ========= TODAY =========
function renderToday() {
    var d = todayStr(), txs = getTxDay(d), s = calcSum(txs);
    document.getElementById('todayNet').innerHTML =
        '<span style="color:' + (s.net >= 0 ? '#fff' : '#fca5a5') + '">' + fmtAmt(s.net) + '</span>';
    document.getElementById('todayInc').textContent = fmtAmt(s.inc);
    document.getElementById('todayExp').textContent = fmtAmt(s.exp);
    var el = document.getElementById('txListToday');
    if (!txs.length) {
        el.innerHTML = '<div class="empty-state"><div class="empty-icon">📋</div>' +
            '<div>ยังไม่มีรายการวันนี้</div>' +
            '<div style="font-size:11px;margin-top:4px;">กด + รายรับ หรือ + รายจ่าย เพื่อเริ่มบันทึก</div></div>';
        return;
    }
    var html = '<div class="tx-card">';
    var rev = txs.slice().reverse();
    rev.forEach(function(t, i) {
        var isInc = t.type === 'income';
        if (i > 0) html += '<div class="tx-divider"></div>';
        html += '<div class="tx-item" data-action="edit" data-id="' + t.id + '">';
        html += '<div class="tx-icon ' + (isInc ? 'ti-inc' : 'ti-exp') + '">' + (isInc ? '💰' : '💸') + '</div>';
        html += '<div class="tx-info"><div class="tx-cat">' + t.cat + '</div>';
        if (t.note) html += '<div class="tx-note">' + t.note + '</div>';
        html += '</div>';
        html += '<div class="tx-amt ' + (isInc ? 'ta-inc' : 'ta-exp') + '">' + (isInc ? '+' : '−') + fmtAmt(t.amount) + '</div>';
        html += '<button type="button" class="tx-del" data-action="del" data-id="' + t.id + '">&times;</button>';
        html += '</div>';
    });
    html += '</div>';
    el.innerHTML = html;
}

// ========= MONTH =========
function renderMonth() {
    var now = new Date();
    if (curMonth === undefined) { curMonth = now.getMonth(); curYear = now.getFullYear(); }
    document.getElementById('monthLabel').textContent = MONTH_TH[curMonth] + ' ' + (curYear + 543);
    var txs = getTxMonth(curYear, curMonth), s = calcSum(txs);
    document.getElementById('mInc').textContent = fmtAmt(s.inc);
    document.getElementById('mExp').textContent = fmtAmt(s.exp);
    document.getElementById('mNet').textContent = fmtAmt(s.net);
    var byDay = {};
    txs.forEach(function(t){
        if (!byDay[t.date]) byDay[t.date] = {inc:0,exp:0};
        if (t.type==='income') byDay[t.date].inc += t.amount;
        else byDay[t.date].exp += t.amount;
    });
    var dates = Object.keys(byDay).sort().reverse();
    var maxV = 0;
    dates.forEach(function(d){ maxV = Math.max(maxV, byDay[d].inc, byDay[d].exp); });
    var html = '';
    if (!dates.length) {
        html = '<div class="empty-state"><div class="empty-icon">📅</div><div>ไม่มีรายการเดือนนี้</div></div>';
    } else {
        dates.forEach(function(d) {
            var dy = byDay[d], net = dy.inc - dy.exp;
            var parts = d.split('-');
            var iW = maxV ? Math.round(dy.inc/maxV*100) : 0;
            var eW = maxV ? Math.round(dy.exp/maxV*100) : 0;
            var nc = net > 0 ? 'dbn-pos' : net < 0 ? 'dbn-neg' : 'dbn-z';
            var netTxt = (net >= 0 ? '+' : '') + fmtAmt(net);
            html += '<div class="day-bar-item" data-action="daydetail" data-date="' + d + '">';
            html += '<div class="day-bar-lbl">' + parseInt(parts[2]) + ' ' + MONTH_TH[parseInt(parts[1])-1].slice(0,3) + '</div>';
            html += '<div class="day-bar-track">';
            html += '<div class="day-bar-bg"><div class="day-bar-fill dbf-inc" style="width:' + iW + '%"></div></div>';
            html += '<div class="day-bar-bg" style="margin-top:2px;"><div class="day-bar-fill dbf-exp" style="width:' + eW + '%"></div></div>';
            html += '</div>';
            html += '<div class="day-bar-net ' + nc + '">' + netTxt + '</div>';
            html += '</div>';
        });
    }
    document.getElementById('monthDayList').innerHTML = html;
}

// ========= YEAR =========
function renderYear() {
    var now = new Date();
    if (curYear === undefined) curYear = now.getFullYear();
    document.getElementById('yearLabel').textContent = 'ปี ' + (curYear + 543);
    var txs = getTxYear(curYear), s = calcSum(txs);
    document.getElementById('yInc').textContent = fmtAmt(s.inc);
    document.getElementById('yExp').textContent = fmtAmt(s.exp);
    document.getElementById('yNet').textContent = fmtAmt(s.net);
    var html = '';
    for (var m = 0; m < 12; m++) {
        var mt = getTxMonth(curYear, m), ms = calcSum(mt);
        var nc = ms.net > 0 ? 'dbn-pos' : ms.net < 0 ? 'dbn-neg' : 'dbn-z';
        html += '<div class="ym-card" data-action="gotomonth" data-m="' + m + '">';
        html += '<div class="ym-name">' + MONTH_TH[m] + '</div>';
        html += '<div class="ym-row ym-inc">รายรับ ' + fmtAmt(ms.inc) + '</div>';
        html += '<div class="ym-row ym-exp">รายจ่าย ' + fmtAmt(ms.exp) + '</div>';
        html += '<div class="ym-net ' + nc + '">สุทธิ ' + (ms.net>=0?'+':'') + fmtAmt(ms.net) + '</div>';
        html += '</div>';
    }
    document.getElementById('yearGrid').innerHTML = html;
}

// ========= ADD / EDIT MODAL =========
function openAddModal(type) {
    document.getElementById('txId').value = '';
    document.getElementById('txType').value = type;
    document.getElementById('txModalTitle').textContent = type === 'income' ? 'เพิ่มรายรับ' : 'เพิ่มรายจ่าย';
    document.getElementById('txAmount').value = '';
    document.getElementById('txDate').value = todayStr();
    document.getElementById('txNote').value = '';
    selectedCat = '';
    renderCatChips(type);
    bootstrap.Modal.getOrCreateInstance(document.getElementById('txModal')).show();
}
function openEditModal(id) {
    var tx = loadTx().find(function(t){return t.id === id;});
    if (!tx) return;
    document.getElementById('txId').value = id;
    document.getElementById('txType').value = tx.type;
    document.getElementById('txModalTitle').textContent = tx.type==='income' ? 'แก้ไขรายรับ' : 'แก้ไขรายจ่าย';
    document.getElementById('txAmount').value = tx.amount;
    document.getElementById('txDate').value = tx.date;
    document.getElementById('txNote').value = tx.note || '';
    selectedCat = tx.cat;
    renderCatChips(tx.type);
    bootstrap.Modal.getOrCreateInstance(document.getElementById('txModal')).show();
}
function renderCatChips(type) {
    var html = '';
    CATS[type].forEach(function(c) {
        html += '<div class="cat-chip' + (c === selectedCat ? ' sel' : '') + '" data-cat="' + c + '">' + c + '</div>';
    });
    document.getElementById('catChips').innerHTML = html;
}
function saveTx() {
    var amount = parseFloat(document.getElementById('txAmount').value);
    if (!amount || amount <= 0) { alert('กรุณากรอกจำนวนเงิน'); return; }
    if (!selectedCat)           { alert('กรุณาเลือกหมวดหมู่'); return; }
    var type  = document.getElementById('txType').value;
    var date  = document.getElementById('txDate').value || todayStr();
    var note  = document.getElementById('txNote').value.trim();
    var id    = document.getElementById('txId').value;
    var txs   = loadTx();
    var isNew = !id;
    if (isNew) {
        txs.push({id:genId(), type:type, amount:amount, cat:selectedCat, note:note, date:date, ts:Date.now()});
    } else {
        var idx = txs.findIndex(function(t){return t.id===id;});
        if (idx >= 0) txs[idx] = Object.assign(txs[idx], {type:type,amount:amount,cat:selectedCat,note:note,date:date});
    }
    storeTxArr(txs);
    if (isNew && date === todayStr()) { doCheckinReward(true); }
    updateEntryDays();
    bootstrap.Modal.getOrCreateInstance(document.getElementById('txModal')).hide();
    if (curTab === 'today')  renderToday();
    if (curTab === 'month')  renderMonth();
    if (curTab === 'year')   renderYear();
}
function deleteTx(id) {
    if (!confirm('ลบรายการนี้?')) return;
    storeTxArr(loadTx().filter(function(t){return t.id!==id;}));
    updateEntryDays();
    if (curTab === 'today') renderToday();
    if (curTab === 'month') renderMonth();
    if (curTab === 'year')  renderYear();
}

// ========= DAILY CHECK-IN =========
function updateCheckinBtn() {
    var g = loadGame();
    var btn = document.getElementById('btnCheckin');
    var desc = document.getElementById('checkinDesc');
    if (g.lastCheckin === todayStr()) {
        btn.textContent = '✓ รับแล้ว';
        btn.className = 'checkin-btn claimed';
        desc.textContent = 'รับของวันนี้แล้ว • กลับมาพรุ่งนี้อีกครั้ง';
    } else {
        btn.textContent = 'รับเลย!';
        btn.className = 'checkin-btn';
        desc.textContent = 'บันทึกรายการแล้วหรือยัง? กดรับน้ำรดต้นไม้ 1 ชิ้น';
    }
}
function doCheckin() {
    var g = loadGame();
    if (g.lastCheckin === todayStr()) { return; }
    doCheckinReward(false);
}
function doCheckinReward(fromTx) {
    var g = loadGame();
    if (g.lastCheckin === todayStr()) return;
    var r = Math.random();
    var item = r < 0.50 ? 'cup' : r < 0.85 ? 'can' : 'bucket';
    g.basket[item]++;
    g.lastCheckin = todayStr();
    saveGame(g);
    showToast(item);
    updateCheckinBtn();
    renderGarden();
}
function showToast(item) {
    var toast = document.getElementById('rewardToast');
    document.getElementById('toastIcon').textContent  = ITEM_EMO[item];
    document.getElementById('toastTitle').textContent = 'ได้รับรางวัลประจำวัน!';
    document.getElementById('toastSub').textContent   = ITEM_NAME[item] + ' 1 ชิ้น เพิ่มในตระกร้าแล้ว';
    toast.classList.add('show');
    setTimeout(function(){ toast.classList.remove('show'); }, 3500);
}

// ========= GARDEN =========
function renderGarden() {
    var g = loadGame();
    updateBasket(g);
    if (g.treeType < 0) {
        document.getElementById('treeDisplay').innerHTML =
            '<div style="text-align:center;padding:30px;color:#94a3b8;font-size:13px;">เลือกพันธุ์ต้นไม้เพื่อเริ่มปลูก &#127807;</div>';
        document.getElementById('treeInfoCard').style.display = 'none';
        document.getElementById('treePickBanner').style.display = '';
        return;
    }
    document.getElementById('treePickBanner').style.display = 'none';
    document.getElementById('treeInfoCard').style.display   = '';
    // Render tree
    document.getElementById('treeDisplay').innerHTML =
        '<div class="tree-svg-anim">' + getTreeSVG(g.treeType, g.stage) + '</div>';
    // Info
    var t = TREES[g.treeType];
    document.getElementById('treeEmoji').textContent = t.emoji;
    document.getElementById('treeName').textContent  = t.name;
    document.getElementById('treeTypeTag').textContent = t.desc;
    document.getElementById('treeTypeTag').style.cssText = 'background:' + t.tagBg + ';color:' + t.tagC;
    document.getElementById('treeStageName').textContent = STAGES[g.stage];
    var xpNeed = g.stage < 4 ? STAGE_XP[g.stage] : null;
    var xpPct  = xpNeed ? Math.min(100, Math.round(g.xp / xpNeed * 100)) : 100;
    document.getElementById('treeXpText').textContent = xpNeed ? ('XP: ' + g.xp + '/' + xpNeed) : '✨ เต็มศักยภาพ';
    document.getElementById('treeXpBar').style.width = xpPct + '%';
    // Stage dots
    var dotsHtml = '';
    STAGES.forEach(function(sn, si) {
        var cls = si < g.stage ? 'done' : si === g.stage ? 'current' : '';
        var icon = si < g.stage ? '✓' : si === g.stage ? (g.stage === 4 ? '★' : '●') : '○';
        dotsHtml += '<div class="stage-dot ' + cls + '">' +
            '<div class="stage-dot-circle">' + icon + '</div>' +
            '<div class="stage-dot-lbl">' + sn + '</div></div>';
    });
    document.getElementById('stageDots').innerHTML = dotsHtml;
    // Change button only at stage 0
}
function updateBasket(g) {
    ['cup','can','bucket'].forEach(function(k){
        var cnt = g.basket[k] || 0;
        var capK = k.charAt(0).toUpperCase() + k.slice(1);
        document.getElementById('bsk' + capK + 'Cnt').textContent = cnt;
        document.getElementById('bsk' + capK).classList.toggle('active', cnt > 0);
    });
    var total = (g.basket.cup||0)+(g.basket.can||0)+(g.basket.bucket||0);
    var hint = document.getElementById('basketHint');
    if (g.treeType < 0) {
        hint.textContent = 'เลือกต้นไม้ก่อนแล้วค่อยรดน้ำ';
    } else if (total === 0) {
        hint.textContent = 'ตระกร้าว่าง — รับของผ่านปุ่มเช็คอินด้านบน';
    } else {
        hint.textContent = 'กดที่ช่องมีของในตระกร้าเพื่อรดน้ำต้นไม้ได้เลย';
    }
}
function waterTree(item) {
    var g = loadGame();
    if (g.treeType < 0) { alert('เลือกต้นไม้ก่อนนะ 🌱'); return; }
    if (g.stage >= 4) {
        alert('ต้นไม้โตเต็มที่แล้ว! ' + TREES[g.treeType].emoji + ' ' + STAGES[4]); return;
    }
    if (!g.basket[item] || g.basket[item] <= 0) {
        alert('ไม่มี' + ITEM_NAME[item] + 'ในตระกร้า'); return;
    }
    g.basket[item]--;
    g.xp += ITEM_XP[item];
    g.totalWatered++;
    var leveledUp = false;
    while (g.stage < 4 && g.xp >= STAGE_XP[g.stage]) {
        g.xp -= STAGE_XP[g.stage];
        g.stage++;
        leveledUp = true;
    }
    if (g.stage >= 4) g.xp = 0;
    saveGame(g);
    renderGarden();
    if (leveledUp && g.stage === 4) {
        showTreeDetailModal();
    }
}

// Tree picker
function renderTreePickCards() {
    var html = '';
    TREES.forEach(function(t, i) {
        html += '<div class="tp-card' + (i === pickedTreeType ? ' sel' : '') + '" data-action="picktree" data-idx="' + i + '">';
        html += '<div class="tp-emoji">' + t.emoji + '</div>';
        html += '<div class="tp-name">' + t.name + '</div>';
        html += '<div class="tp-desc">' + t.desc + '</div></div>';
    });
    document.getElementById('treePickGrid').innerHTML = html;
}
function confirmTree() {
    var g = loadGame();
    if (g.stage > 0 && g.treeType >= 0) { alert('เปลี่ยนพันธุ์ได้เฉพาะตอนที่ยังเป็นเมล็ด'); return; }
    g.treeType = pickedTreeType; g.stage = 0; g.xp = 0;
    saveGame(g);
    renderGarden();
}
function showTreeDetailModal() {
    var g = loadGame();
    if (g.treeType < 0) return;
    var t = TREES[g.treeType];
    var xpNeed = g.stage < 4 ? STAGE_XP[g.stage] : '—';
    var html = '<div style="text-align:center;padding:8px 0 16px;">';
    html += '<div style="font-size:52px;">' + t.emoji + '</div>';
    html += '<div style="font-size:17px;font-weight:800;color:#0c1b3a;margin-top:4px;">' + t.name + '</div>';
    html += '<div style="font-size:12px;color:#64748b;">' + t.desc + '</div></div>';
    html += '<div style="display:grid;grid-template-columns:1fr 1fr;gap:8px;margin-bottom:14px;">';
    var stats = [
        ['ระยะปัจจุบัน', STAGES[g.stage]],
        ['XP ปัจจุบัน',  g.xp],
        ['XP ที่ต้องการ', xpNeed],
        ['รดน้ำทั้งหมด',  (g.totalWatered||0) + ' ครั้ง'],
        ['วันที่บันทึก',   (g.totalDays||0) + ' วัน'],
        ['ระดับยศ',        RANKS[getRankIdx(g.totalDays||0)].lbl]
    ];
    stats.forEach(function(s){
        html += '<div style="background:#f8faff;border-radius:10px;padding:8px 10px;">';
        html += '<div style="font-size:10px;color:#94a3b8;font-weight:600;">' + s[0] + '</div>';
        html += '<div style="font-size:13px;font-weight:800;color:#0c1b3a;margin-top:1px;">' + s[1] + '</div></div>';
    });
    html += '</div>';
    html += '<div style="margin-top:4px;"><div style="font-size:12px;font-weight:700;color:#475569;margin-bottom:8px;">การเติบโต</div>';
    html += '<div style="display:flex;justify-content:space-around;">';
    STAGES.forEach(function(sn, si){
        var done = si <= g.stage;
        html += '<div style="text-align:center;">';
        html += '<div style="font-size:16px;">' + (done ? '✅' : '⬜') + '</div>';
        html += '<div style="font-size:8px;color:' + (done?'#059669':'#cbd5e1') + ';font-weight:700;margin-top:2px;">' + sn + '</div></div>';
    });
    html += '</div></div>';
    if (g.stage === 4) {
        html += '<div style="text-align:center;margin-top:14px;padding:12px;background:#fef9c3;border-radius:12px;">';
        html += '<div style="font-size:13px;font-weight:800;color:#78350f;">🎉 ต้นไม้โตเต็มที่แล้ว!</div>';
        html += '<div style="font-size:11px;color:#92400e;margin-top:4px;">ขอแสดงความยินดี คุณทำได้แล้ว!</div></div>';
    }
    document.getElementById('treeDetailTitle').textContent = 'ข้อมูล: ' + t.name;
    document.getElementById('treeDetailBody').innerHTML = html;
    bootstrap.Modal.getOrCreateInstance(document.getElementById('treeDetailModal')).show();
}

// ========= TREE SVG =========
function getTreeSVG(type, stage) {
    var t = TREES[type], W = 140, H = 190, cx = 70;
    var c1=t.c1, c2=t.c2, cf=t.cf, ct=t.ct, sh=t.shape;
    var p = [];
    p.push('<svg width="' + W + '" height="' + H + '" viewBox="0 0 ' + W + ' ' + H + '" xmlns="http://www.w3.org/2000/svg">');
    p.push('<ellipse cx="' + cx + '" cy="185" rx="50" ry="10" fill="' + ct + '" opacity="0.22"/>');
    if (stage === 0) {
        p.push('<ellipse cx="' + cx + '" cy="182" rx="14" ry="9" fill="' + ct + '"/>');
        p.push('<ellipse cx="' + cx + '" cy="180" rx="8" ry="5" fill="' + c1 + '" opacity="0.85"/>');
        p.push('<path d="M' + cx + ' 174 C' + (cx-3) + ' 166 ' + (cx-1) + ' 160 ' + cx + ' 156" stroke="' + c1 + '" stroke-width="2.5" fill="none" stroke-linecap="round"/>');
        p.push('<ellipse cx="' + cx + '" cy="154" rx="7" ry="4" fill="' + c1 + '" opacity="0.9"/>');
    } else {
        var tH = [0,32,52,68,74][stage], tW = 13, tY = 183 - tH;
        p.push('<rect x="' + (cx-tW/2) + '" y="' + tY + '" width="' + tW + '" height="' + tH + '" rx="5" fill="' + ct + '"/>');
        var cY = tY - 6;
        if (sh === 'round') {
            var r = [0,22,34,44,48][stage];
            p.push('<circle cx="' + cx + '" cy="' + cY + '" r="' + r + '" fill="' + c1 + '"/>');
            p.push('<circle cx="' + (cx-r*.22) + '" cy="' + (cY-r*.18) + '" r="' + (r*.42) + '" fill="' + c2 + '" opacity="0.55"/>');
            if (stage >= 3) {
                for (var i=0;i<8;i++) {
                    var a=i*45*Math.PI/180, px=cx+(r+5)*Math.cos(a), py=cY+(r+5)*Math.sin(a);
                    p.push('<ellipse cx="' + px.toFixed(1) + '" cy="' + py.toFixed(1) + '" rx="6" ry="4" fill="' + c2 + '" opacity="0.85" class="fb" transform="rotate(' + (i*45+90) + ' ' + px.toFixed(1) + ' ' + py.toFixed(1) + ')"/>');
                }
            }
            if (stage === 4) {
                p.push('<circle cx="' + cx + '" cy="' + cY + '" r="11" fill="' + cf + '" class="fb"/>');
                p.push('<circle cx="' + cx + '" cy="' + cY + '" r="6" fill="' + ct + '"/>');
                for (var j=0;j<6;j++) {
                    var a2=(j*60+10)*Math.PI/180, px2=cx+(r+13)*Math.cos(a2), py2=cY+(r+13)*Math.sin(a2);
                    p.push('<circle cx="' + px2.toFixed(1) + '" cy="' + py2.toFixed(1) + '" r="3.5" fill="' + cf + '" class="fb"/>');
                }
            }
        } else if (sh === 'cactus') {
            var cH=[0,38,58,72,80][stage], cW=[0,15,17,19,21][stage], cTop=cY-cH*.6;
            p.push('<rect x="' + (cx-cW/2) + '" y="' + cTop + '" width="' + cW + '" height="' + cH + '" rx="' + (cW/2) + '" fill="' + c1 + '"/>');
            for (var si=0;si<4;si++) {
                var sY=cTop+cH*(.2+si*.18);
                p.push('<line x1="' + (cx-cW/2) + '" y1="' + sY + '" x2="' + (cx-cW/2-5) + '" y2="' + (sY-2) + '" stroke="' + c2 + '" stroke-width="1.5"/>');
                p.push('<line x1="' + (cx+cW/2) + '" y1="' + sY + '" x2="' + (cx+cW/2+5) + '" y2="' + (sY-2) + '" stroke="' + c2 + '" stroke-width="1.5"/>');
            }
            if (stage >= 2) {
                var aY=cTop+cH*.35;
                p.push('<rect x="' + (cx-cW/2-17) + '" y="' + aY + '" width="17" height="9" rx="4" fill="' + c1 + '"/>');
                p.push('<rect x="' + (cx-cW/2-17) + '" y="' + (aY-17) + '" width="9" height="24" rx="4" fill="' + c1 + '"/>');
                p.push('<rect x="' + (cx+cW/2) + '" y="' + aY + '" width="17" height="9" rx="4" fill="' + c1 + '"/>');
                p.push('<rect x="' + (cx+cW/2+8) + '" y="' + (aY-17) + '" width="9" height="24" rx="4" fill="' + c1 + '"/>');
            }
            if (stage >= 3) {
                p.push('<circle cx="' + cx + '" cy="' + cTop + '" r="9" fill="' + cf + '" class="fb"/>');
                p.push('<circle cx="' + cx + '" cy="' + cTop + '" r="5" fill="#fff" opacity="0.9"/>');
            }
            if (stage === 4) {
                p.push('<circle cx="' + cx + '" cy="' + cTop + '" r="13" fill="' + cf + '" class="fb"/>');
                p.push('<circle cx="' + cx + '" cy="' + cTop + '" r="7" fill="#fff"/>');
                var aY2=cTop-20;
                p.push('<circle cx="' + (cx-cW/2-13) + '" cy="' + aY2 + '" r="7" fill="' + cf + '" class="fb"/>');
                p.push('<circle cx="' + (cx+cW/2+13) + '" cy="' + aY2 + '" r="7" fill="' + cf + '" class="fb"/>');
            }
        } else if (sh === 'cloud') {
            var cR=[0,20,30,38,42][stage];
            var offs=[[-cR*.38,0],[cR*.38,0],[0,-cR*.3],[-cR*.18,cR*.22],[cR*.18,cR*.22]];
            offs.forEach(function(o){
                p.push('<circle cx="' + (cx+o[0]).toFixed(1) + '" cy="' + (cY+o[1]).toFixed(1) + '" r="' + (cR*.74) + '" fill="' + c1 + '" opacity="0.9"/>');
            });
            p.push('<circle cx="' + cx + '" cy="' + cY + '" r="' + (cR*.6) + '" fill="' + c2 + '" opacity="0.65"/>');
            if (stage >= 3) {
                for (var fi=0;fi<10;fi++) {
                    var fa=fi*36*Math.PI/180, fpx=cx+(cR*.58)*Math.cos(fa), fpy=cY+(cR*.58)*Math.sin(fa);
                    p.push('<circle cx="' + fpx.toFixed(1) + '" cy="' + fpy.toFixed(1) + '" r="3.5" fill="' + cf + '" opacity="0.85" class="fb"/>');
                }
            }
            if (stage === 4) {
                for (var pi=0;pi<8;pi++) {
                    var pa=pi*45*Math.PI/180, ppx=cx+(cR+11)*Math.cos(pa), ppy=cY+(cR+11)*Math.sin(pa);
                    p.push('<ellipse cx="' + ppx.toFixed(1) + '" cy="' + ppy.toFixed(1) + '" rx="5" ry="3" fill="' + cf + '" opacity="0.9" class="fb" transform="rotate(' + (pi*45) + ' ' + ppx.toFixed(1) + ' ' + ppy.toFixed(1) + ')"/>');
                }
            }
        } else if (sh === 'layers') {
            var nl=Math.min(stage,3), mW=[0,36,52,68,74][stage], lH=26;
            for (var li=0;li<nl;li++) {
                var lW=mW-li*11, lY2=cY+li*17-(nl-1)*8.5;
                var pts=[(cx-lW/2)+','+(lY2+lH), cx+','+lY2, (cx+lW/2)+','+(lY2+lH)];
                p.push('<polygon points="' + pts.join(' ') + '" fill="' + c1 + '" opacity="' + (1-li*.08) + '"/>');
                p.push('<polygon points="' + pts.join(' ') + '" fill="' + c2 + '" opacity="0.3"/>');
            }
            if (stage === 4) {
                for (var gi=0;gi<6;gi++) {
                    var ga=gi*60*Math.PI/180, gpx=cx+(mW*.42)*Math.cos(ga), gpy=cY+(mW*.28)*Math.sin(ga);
                    p.push('<circle cx="' + gpx.toFixed(1) + '" cy="' + gpy.toFixed(1) + '" r="4" fill="' + cf + '" class="fb"/>');
                }
            }
        } else {
            var oRX=[0,19,29,37,41][stage], oRY=[0,29,46,58,64][stage];
            p.push('<ellipse cx="' + cx + '" cy="' + cY + '" rx="' + oRX + '" ry="' + oRY + '" fill="' + c1 + '"/>');
            p.push('<ellipse cx="' + (cx-oRX*.18) + '" cy="' + (cY-oRY*.2) + '" rx="' + (oRX*.52) + '" ry="' + (oRY*.38) + '" fill="' + c2 + '" opacity="0.55"/>');
            if (stage >= 3) {
                for (var di=0;di<5;di++) {
                    var da=(di*72+36)*Math.PI/180, dpx=cx+(oRX*.7)*Math.cos(da), dpy=cY+(oRY*.62)*Math.sin(da);
                    p.push('<polygon points="' + dpx + ',' + (dpy-6) + ' ' + (dpx+4) + ',' + dpy + ' ' + dpx + ',' + (dpy+4) + ' ' + (dpx-4) + ',' + dpy + '" fill="' + cf + '" class="fb" opacity="0.9"/>');
                }
            }
            if (stage === 4) {
                for (var egi=0;egi<7;egi++) {
                    var ea=egi*360/7*Math.PI/180, epx=cx+(oRX+8)*Math.cos(ea), epy=cY+(oRY+8)*Math.sin(ea);
                    p.push('<circle cx="' + epx.toFixed(1) + '" cy="' + epy.toFixed(1) + '" r="4" fill="' + cf + '" class="fb" opacity="0.85"/>');
                }
            }
        }
    }
    p.push('</svg>');
    return p.join('');
}

// ========= SEED MODAL =========
var rolledTreeType = -1;
function openSeedModal() {
    rolledTreeType = -1;
    document.getElementById('seedResultName').textContent = '';
    document.getElementById('seedResultDesc').textContent = '';
    document.getElementById('btnConfirmSeed').style.display = 'none';
    document.getElementById('btnRollAgain').style.display = 'none';
    document.getElementById('seedSpinner').textContent = String.fromCodePoint(127807);
    bootstrap.Modal.getOrCreateInstance(document.getElementById('seedModal')).show();
    setTimeout(rollSeed, 400);
}
function rollSeed() {
    var spinner = document.getElementById('seedSpinner');
    document.getElementById('btnConfirmSeed').style.display = 'none';
    document.getElementById('btnRollAgain').style.display = 'none';
    var idx = 0, count = 0, total = 24;
    var interval = setInterval(function() {
        spinner.textContent = TREES[idx % TREES.length].emoji;
        idx++;
        count++;
        if (count >= total) {
            clearInterval(interval);
            rolledTreeType = Math.floor(Math.random() * TREES.length);
            spinner.textContent = TREES[rolledTreeType].emoji;
            document.getElementById('seedResultName').textContent = '✨ ได้รับ: ' + TREES[rolledTreeType].name;
            document.getElementById('seedResultDesc').textContent = TREES[rolledTreeType].desc;
            document.getElementById('btnConfirmSeed').style.display = '';
            document.getElementById('btnRollAgain').style.display = '';
        }
    }, 100);
}
function confirmSeed() {
    if (rolledTreeType < 0) return;
    var g = loadGame();
    g.treeType = rolledTreeType; g.stage = 0; g.xp = 0;
    saveGame(g);
    bootstrap.Modal.getOrCreateInstance(document.getElementById('seedModal')).hide();
    renderGarden();
}
function uprootTree() {
    if (!confirm('ถอนต้นไม้ออก?\n\nต้นไม้และความก้าวหน้าทั้งหมดจะหายไป (\nตระกร้าน้ำจะยังอยู่ครบ)\n\nยืนยันหรือไม่?')) return;
    var g = loadGame();
    g.treeType = -1; g.stage = 0; g.xp = 0; g.totalWatered = 0;
    saveGame(g);
    renderGarden();
}

// ========= EVENT DELEGATION =========
document.addEventListener('click', function(e) {
    var el = e.target;
    // Tab switching
    if (el.classList.contains('tab-btn')) {
        switchTab(el.getAttribute('data-tab'));
        return;
    }
    // Cat chips
    if (el.classList.contains('cat-chip')) {
        selectedCat = el.getAttribute('data-cat');
        document.querySelectorAll('.cat-chip').forEach(function(c){
            c.classList.toggle('sel', c.getAttribute('data-cat') === selectedCat);
        });
        return;
    }
    // Dynamic actions
    var target = el.closest('[data-action]');
    if (!target) return;
    var action = target.getAttribute('data-action');
    var id     = target.getAttribute('data-id');
    var date   = target.getAttribute('data-date');
    if (action === 'edit')       { openEditModal(id); return; }
    if (action === 'del')        { e.stopPropagation(); deleteTx(id); return; }
    if (action === 'daydetail')  { showDayDetail(date); return; }
    if (action === 'gotomonth')  {
        curMonth = parseInt(target.getAttribute('data-m'));
        switchTab('month');
        return;
    }
    if (action === 'picktree')   {
        pickedTreeType = parseInt(target.getAttribute('data-idx'));
        document.querySelectorAll('.tp-card').forEach(function(c){
            c.classList.toggle('sel', parseInt(c.getAttribute('data-idx')) === pickedTreeType);
        });
        return;
    }
    if (action === 'water')      { waterTree(target.getAttribute('data-item')); return; }
});

// Basket click (delegated differently since bsk-item has children)
document.getElementById('basketCard') && document.querySelector('.basket-items').addEventListener('click', function(e) {
    var item = e.target.closest('.bsk-item');
    if (item && item.classList.contains('active')) {
        waterTree(item.getAttribute('data-item'));
    }
});

function showDayDetail(dateStr) {
    var txs = getTxDay(dateStr);
    if (!txs.length) return;
    var parts = dateStr.split('-');
    var title = 'วันที่ ' + parseInt(parts[2]) + ' ' + MONTH_TH[parseInt(parts[1])-1] + ' ' + (parseInt(parts[0])+543);
    var html = '<div class="tx-card" style="margin:0;">';
    txs.forEach(function(t, i) {
        var isInc = t.type === 'income';
        if (i > 0) html += '<div class="tx-divider"></div>';
        html += '<div class="tx-item"><div class="tx-icon ' + (isInc?'ti-inc':'ti-exp') + '">' + (isInc?'💰':'💸') + '</div>';
        html += '<div class="tx-info"><div class="tx-cat">' + t.cat + '</div>' + (t.note?'<div class="tx-note">'+t.note+'</div>':'') + '</div>';
        html += '<div class="tx-amt ' + (isInc?'ta-inc':'ta-exp') + '">' + (isInc?'+':'−') + fmtAmt(t.amount) + '</div></div>';
    });
    html += '</div>';
    document.getElementById('treeDetailTitle').textContent = title;
    document.getElementById('treeDetailBody').innerHTML = html;
    bootstrap.Modal.getOrCreateInstance(document.getElementById('treeDetailModal')).show();
}

// ========= INIT =========
function init() {
    var now = new Date();
    var d = DAYS_TH[now.getDay()] + ' ' + now.getDate() + ' ' + MONTH_TH[now.getMonth()] + ' ' + (now.getFullYear()+543);
    document.getElementById('todayLabel').textContent = 'วัน' + d;
    curMonth = now.getMonth();
    curYear  = now.getFullYear();
    pickedTreeType = Math.max(0, loadGame().treeType) || 0;

    // Static button events
    document.getElementById('btnAddIncome').addEventListener('click', function(){ openAddModal('income'); });
    document.getElementById('btnAddExpense').addEventListener('click', function(){ openAddModal('expense'); });
    document.getElementById('btnSaveTx').addEventListener('click', saveTx);
    document.getElementById('btnCheckin').addEventListener('click', doCheckin);
    document.getElementById('btnTreeInfo').addEventListener('click', showTreeDetailModal);
    document.getElementById('btnStartPlant').addEventListener('click', openSeedModal);
    document.getElementById('btnConfirmSeed').addEventListener('click', confirmSeed);
    document.getElementById('btnRollAgain').addEventListener('click', rollSeed);
    document.getElementById('btnUprootTree').addEventListener('click', uprootTree);
    document.getElementById('btnMonthPrev').addEventListener('click', function(){ curMonth--; if(curMonth<0){curMonth=11;curYear--;} renderMonth(); });
    document.getElementById('btnMonthNext').addEventListener('click', function(){ curMonth++; if(curMonth>11){curMonth=0;curYear++;} renderMonth(); });
    document.getElementById('btnYearPrev').addEventListener('click',  function(){ curYear--; renderYear(); });
    document.getElementById('btnYearNext').addEventListener('click',  function(){ curYear++; renderYear(); });

    updateRankBadge();
    updateCheckinBtn();
    renderToday();
    renderGarden();
}
document.addEventListener('DOMContentLoaded', init);
</script>
<!-- Modal: Random Seed -->
<div class="modal fade modal-acct" id="seedModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header" style="border:none;padding:18px 18px 8px;">
                <span class="modal-title-txt">&#127922; สุ่มเมล็ดพันธุ์</span>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body" style="padding:0 18px 28px;text-align:center;">
                <div id="seedSpinner" style="font-size:64px;margin:20px 0 8px;min-height:80px;display:flex;align-items:center;justify-content:center;transition:all .12s;">&#127807;</div>
                <div id="seedResultName" style="font-size:18px;font-weight:800;color:#1344a0;min-height:26px;margin-bottom:4px;"></div>
                <div id="seedResultDesc" style="font-size:12px;color:#64748b;min-height:18px;margin-bottom:20px;"></div>
                <button type="button" id="btnConfirmSeed" style="width:100%;padding:13px;background:#1344a0;color:#fff;border:none;border-radius:14px;font-size:14px;font-weight:800;cursor:pointer;display:none;">&#127807; ยืนยันปลูกต้นนี้!</button>
                <button type="button" id="btnRollAgain" style="width:100%;padding:11px;background:#f1f5f9;color:#475569;border:none;border-radius:14px;font-size:13px;font-weight:700;cursor:pointer;margin-top:8px;display:none;">&#127922; สุ่มใหม่อีกครั้ง</button>
            </div>
        </div>
    </div>
</div>

</asp:Content>
