<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerHealthCheck.views.NDID.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .css-i6s8oy{
            display:none !important;
        }
    </style>
    <div style="text-align:right;">
        <img src="../../images/logos/Logo.png" alt="" style="max-width: 70px; margin-left: auto;"/>
    </div>

    <div id="root">
        <div class="MuiContainer-root MuiContainer-maxWidthLg css-1qsxih2">
            <div class="MuiPaper-root MuiPaper-outlined MuiPaper-rounded css-du0t4a">
                <div class="MuiStepper-root MuiStepper-horizontal MuiStepper-alternativeLabel css-1187icl">
                    <div class="MuiStep-root MuiStep-horizontal MuiStep-alternativeLabel css-166ciyp">
                        <span class="MuiStepLabel-root MuiStepLabel-horizontal MuiStepLabel-alternativeLabel css-1abj2s5">
                            <span class="MuiStepLabel-iconContainer Mui-active MuiStepLabel-alternativeLabel css-a5nipc">
                                <svg class="MuiSvgIcon-root MuiSvgIcon-fontSizeMedium MuiStepIcon-root Mui-active css-4ff9q7" focusable="false" aria-hidden="true" viewBox="0 0 24 24">
                                    <circle cx="12" cy="12" r="12"></circle><text class="MuiStepIcon-text css-1w2plts" x="12" y="12" text-anchor="middle" dominant-baseline="central">1</text>
                                </svg>
                            </span>
                            <span class="MuiStepLabel-labelContainer MuiStepLabel-alternativeLabel css-h2cmlr">
                                <span class="MuiStepLabel-label Mui-active MuiStepLabel-alternativeLabel css-15xlymi">กรอกเลขบัตรประชาชน​และยอมรับเงื่อนไขบริการ NDID</span>
                            </span>
                        </span>
                    </div>
                    <div class="MuiStep-root MuiStep-horizontal MuiStep-alternativeLabel css-166ciyp">
                        <div class="MuiStepConnector-root MuiStepConnector-horizontal MuiStepConnector-alternativeLabel Mui-disabled css-15oeqyl">
                            <span class="MuiStepConnector-line MuiStepConnector-lineHorizontal css-95m0ql"></span>
                        </div>
                        <span class="MuiStepLabel-root MuiStepLabel-horizontal Mui-disabled MuiStepLabel-alternativeLabel css-1abj2s5">
                            <span class="MuiStepLabel-iconContainer Mui-disabled MuiStepLabel-alternativeLabel css-a5nipc">
                                <svg class="MuiSvgIcon-root MuiSvgIcon-fontSizeMedium MuiStepIcon-root css-4ff9q7" focusable="false" aria-hidden="true" viewBox="0 0 24 24">
                                    <circle cx="12" cy="12" r="12"></circle><text class="MuiStepIcon-text css-1w2plts" x="12" y="12" text-anchor="middle" dominant-baseline="central">2</text>
                                </svg>
                            </span>
                            <span class="MuiStepLabel-labelContainer MuiStepLabel-alternativeLabel css-h2cmlr">
                                <span class="MuiStepLabel-label Mui-disabled MuiStepLabel-alternativeLabel css-15xlymi">เลือกธนาคารผู้ให้บริการ</span>
                            </span>
                        </span>
                    </div>
                    <div class="MuiStep-root MuiStep-horizontal MuiStep-alternativeLabel css-166ciyp">
                        <div class="MuiStepConnector-root MuiStepConnector-horizontal MuiStepConnector-alternativeLabel Mui-disabled css-15oeqyl">
                            <span class="MuiStepConnector-line MuiStepConnector-lineHorizontal css-95m0ql"></span>
                        </div>
                        <span class="MuiStepLabel-root MuiStepLabel-horizontal Mui-disabled MuiStepLabel-alternativeLabel css-1abj2s5">
                            <span class="MuiStepLabel-iconContainer Mui-disabled MuiStepLabel-alternativeLabel css-a5nipc">
                                <svg class="MuiSvgIcon-root MuiSvgIcon-fontSizeMedium MuiStepIcon-root css-4ff9q7" focusable="false" aria-hidden="true" viewBox="0 0 24 24">
                                    <circle cx="12" cy="12" r="12"></circle><text class="MuiStepIcon-text css-1w2plts" x="12" y="12" text-anchor="middle" dominant-baseline="central">3</text>
                                </svg>
                            </span>
                            <span class="MuiStepLabel-labelContainer MuiStepLabel-alternativeLabel css-h2cmlr">
                                <span class="MuiStepLabel-label Mui-disabled MuiStepLabel-alternativeLabel css-15xlymi">เข้าสู่แอปธนาคาร​</span>
                            </span>
                        </span>
                    </div>
                    <div class="MuiStep-root MuiStep-horizontal MuiStep-alternativeLabel css-166ciyp">
                        <div class="MuiStepConnector-root MuiStepConnector-horizontal MuiStepConnector-alternativeLabel Mui-disabled css-15oeqyl">
                            <span class="MuiStepConnector-line MuiStepConnector-lineHorizontal css-95m0ql"></span>
                        </div>
                        <span class="MuiStepLabel-root MuiStepLabel-horizontal Mui-disabled MuiStepLabel-alternativeLabel css-1abj2s5">
                            <span class="MuiStepLabel-iconContainer Mui-disabled MuiStepLabel-alternativeLabel css-a5nipc">
                                <svg class="MuiSvgIcon-root MuiSvgIcon-fontSizeMedium MuiStepIcon-root css-4ff9q7" focusable="false" aria-hidden="true" viewBox="0 0 24 24">
                                    <circle cx="12" cy="12" r="12"></circle><text class="MuiStepIcon-text css-1w2plts" x="12" y="12" text-anchor="middle" dominant-baseline="central">4</text>
                                </svg>
                            </span>
                            <span class="MuiStepLabel-labelContainer MuiStepLabel-alternativeLabel css-h2cmlr">
                                <span class="MuiStepLabel-label Mui-disabled MuiStepLabel-alternativeLabel css-15xlymi">กลับเข้าระบบงาน บสย.</span>
                            </span>
                        </span>
                    </div>
                </div>
                <div class="MuiGrid-root MuiGrid-container MuiGrid-spacing-xs-2 css-isbt42">
                    <div class="MuiGrid-root MuiGrid-item MuiGrid-grid-xs-6 css-g83kv">
                        <div class="MuiFormControl-root MuiFormControl-fullWidth MuiTextField-root css-feqhe6">
                            <label class="MuiFormLabel-root MuiInputLabel-root MuiInputLabel-formControl MuiInputLabel-animated MuiInputLabel-outlined MuiFormLabel-colorPrimary Mui-required MuiInputLabel-root MuiInputLabel-formControl MuiInputLabel-animated MuiInputLabel-outlined css-14c4hu5" data-shrink="false" for="mui-1" id="mui-1-label">เลขประจำตัวประชาชน<span aria-hidden="true" class="MuiFormLabel-asterisk MuiInputLabel-asterisk css-sp68t1"> *</span></label>
                            <div class="MuiInputBase-root MuiOutlinedInput-root MuiInputBase-colorPrimary MuiInputBase-fullWidth MuiInputBase-formControl css-1dma646">
                                <input aria-invalid="false" required="" type="text" class="MuiInputBase-input MuiOutlinedInput-input css-1x5jdmq" value="" id="mui-1">
                                <fieldset aria-hidden="true" class="MuiOutlinedInput-notchedOutline css-igs3ac">
                                    <legend class="css-yjsfm1">
                                        <span>เลขประจำตัวประชาชน&nbsp;*</span>
                                    </legend>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="MuiPaper-root MuiPaper-elevation MuiPaper-rounded MuiPaper-elevation1 css-18aqzmk">
                    <div class="MuiBox-root css-xi606m">
                        <h6 class="MuiTypography-root MuiTypography-h6 css-1xqmx99">เงื่อนไขข้อบังคับขั้นต่ำการใช้บริการ NDID</h6>
                    </div>
                    <div class="MuiBox-root css-154zku0" id="ndid-terms-box">
                        <ol>
                            <li>
                                <p>ข้อตกลงและเงื่อนไขนี้ (“ข้อตกลง”) ถือเป็นสัญญาให้บริการที่ใช้บังคับกับการใช้บริการและการเข้าร่วมของผู้เสียภาษีในบริการพิสูจน์และยืนยันตัวตนทางดิจิทัลและการทำธุรกรรมอื่น ๆ ที่เกี่ยวเนื่องกับกรมสรรพากรในฐานะที่เป็นผู้ให้บริการ ("กรมสรรพากร") (ซึ่งต่อไปนี้จะเรียกว่า "บริการพิสูจน์และยืนยันตัวตนทางดิจิทัล" หรือ “NDID Services”) โดยที่การให้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัลของกรมสรรพากรนี้จะดำเนินการผ่านระบบการพิสูจน์และยืนยันตัวตนทางดิจิทัล (“Digital ID Platform”) ที่บริษัท เนชั่นแนลดิจิทัล ไอดี จำกัด ("NDID") เป็นผู้จัดให้มีขึ้น โดยมีนโยบายและเงื่อนไขการใช้ บริการระบบการพิสูจน์และยืนยันตัวตนทางดิจิทัล เป็นไปตามที่ NDID กำหนด ทั้งนี้ ผู้เสียภาษีสามารถศึกษารายละเอียดเพิ่มเติมที่ได้ website: https://www.ndid.co.th/termandcon.html</p>
                                <p>ผู้เสียภาษีรับทราบและตกลงว่า การยอมรับข้อตกลงนี้ให้ถือว่าผู้เสียภาษีได้อ่าน เข้าใจ และตกลงที่จะผูกพันตามหลักเกณฑ์ และเงื่อนไขที่กำหนดในข้อตกลงนี้ รวมถึงนโยบายและเงื่อนไขการใช้บริการระบบการพิสูจน์และยืนยันตัวตนทางดิจิทัลของ NDID ทั้งนี้ หากผู้เสียภาษีไม่ยอมรับข้อตกลงดังกล่าวนี้ โปรดอย่าเข้าถึง หรือใช้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัล</p>
                            </li>
                            <li>
                                <p>ผู้เสียภาษีรับทราบว่าก่อนที่ผู้เสียภาษีจะสามารถใช้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัลได้ ผู้เสียภาษีจะต้องลงทะเบียนเพื่อพิสูจน์ตัวตนกับผู้ให้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัลรายอื่น ("Identity Provider" หรือ "IdP") ซึ่งเป็นบุคคลที่ผู้เสียภาษีได้ทำความตกลงที่มีผลทางกฎหมายโดยมีข้อกำหนดในลักษณะเดียวกันกับข้อตกลงนี้</p>
                            </li>
                            <li>
                                <p>เมื่อผู้เสียภาษีขอรับบริการพิสูจน์และยืนยันตัวตนทางดิจิทัลจากกรมสรรพากรแล้ว ผู้เสียภาษีตกลงต่อกรมสรรพากรดังต่อไปนี้</p>
                                <ul>
                                    <li>(1) กรมสรรพากรมีสิทธิใช้ผลการพิสูจน์และยืนยันตัวตนทางดิจิทัลของผู้เสียภาษีที่ Identity Provider อื่น ได้ดำเนินการผ่าน Digital ID Platform</li>
                                    <li>(2) กรมสรรพากรมีสิทธิที่จะรวบรวม ได้รับ ใช้ ประมวลผล และจัดเก็บข้อมูลส่วนบุคคลของผู้เสียภาษีจากผู้ให้ข้อมูลที่น่าเชื่อถือที่เกี่ยวข้อง (authoritative source)</li>
                                    <li>(3) เมื่อ Identity Provider ดำเนินการพิสูจน์และยืนยันตัวตนทางดิจิทัลเสร็จสิ้น และผู้ให้ข้อมูลที่น่าเชื่อถือ (authoritative source) ได้รับอนุญาตในการเข้าถึงข้อมูลของผู้เสียภาษีเรียบร้อยแล้ว ผู้เสียภาษีตกลงว่าจะดำเนินการผ่านกรมสรรพากรเพื่ออนุญาตให้ผู้ให้ข้อมูลที่น่าเชื่อถือ (authoritative source) ส่งข้อมูลส่วนบุคคลของผู้เสียภาษีให้กับกรมสรรพากร ตามรายละเอียดที่ระบุในนโยบายความเป็นส่วนตัวของผู้ให้บริการ (Privacy Policy/Notice) ทั้งนี้ ผู้เสียภาษีรับทราบและตกลงว่า หากผู้เสียภาษีปฏิเสธที่จะดำเนินการดังกล่าวและทำให้ผู้ให้ข้อมูลที่น่าเชื่อถือ (authoritative source) ไม่สามารถส่งข้อมูลส่วนบุคคลของผู้เสียภาษีให้กับกรมสรรพากรได้ ผู้เสียภาษีจะไม่สามารถทำธุรกรรมต่อไปได้ และกรมสรรพากรอาจไม่สามารถที่จะมอบผลิตภัณฑ์หรือบริการตามที่ผู้เสียภาษีต้องการได้</li>
                                    <li>(4) กรมสรรพากรอาจอนุมัติหรือปฏิเสธคำขอของผู้เสียภาษีในการสมัครเข้าใช้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัลของกรมสรรพากรก็ได้ หาก Identity Provider ไม่สามารถพิสูจน์และยืนยันตัวตน หรือผู้ให้ข้อมูลที่น่าเชื่อถือ (authoritative source) ไม่ได้รับอนุญาตให้เข้าถึงข้อมูลหรือไม่สามารถส่งข้อมูลส่วนบุคคลของผู้เสียภาษีตามเงื่อนไข (requirement) ที่กำหนด ทั้งนี้ ไม่ว่าจะด้วยเหตุใดก็ตาม</li>
                                    <li>(5) คำขอสมัครใช้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัลของกรมสรรพากรจะมีผลสมบูรณ์เมื่อ Identity Provider ได้พิสูจน์และยืนยันตัวตน และผู้ให้ข้อมูลที่น่าเชื่อถือ (authoritative source) ได้รับอนุญาตให้เข้าถึงข้อมูลและได้ส่งข้อมูลส่วนบุคคลของผู้เสียภาษีแก่กรมสรรพากรแล้ว</li>
                                </ul>
                            </li>
                            <li>
                                <p>ผู้เสียภาษีรับทราบและตกลงว่า NDID เป็นเพียงผู้ให้บริการระบบ Digital ID Platform ซึ่งเป็นระบบงานสำหรับการส่งต่อข้อมูลและ/หรือจัดเก็บบันทึก Logs ข้อมูลระหว่างสมาชิกของ NDID ตามข้อตกลงและเงื่อนไขของ NDID เท่านั้น โดย NDID จะไม่สามารถเข้าถึงและ/หรือแทรกแซงเนื้อหาของข้อมูลที่มีการแลกเปลี่ยนในระหว่างสมาชิกด้วยกันได้</p>
                                <p>อนึ่ง ผู้เสียภาษีรับทราบและตกลงว่าสมาชิกของ NDID ที่เป็นส่วนหนึ่งของระบบ Digital ID Platform อาจมีการส่งต่อและ/หรือจัดเก็บบันทึก Logs ตามวรรคหนึ่งได้ ทั้งนี้ ข้อมูล Logs ดังกล่าวอาจประกอบไปด้วยข้อมูลที่เกี่ยวข้องกับการทำรายการต่าง ๆ บนระบบ Digital ID Platform แต่จะเป็นข้อมูลที่ไม่สามารถระบุถึงบุคคลที่เป็นเจ้าของข้อมูลได้</p>
                            </li>
                            <li>ผู้เสียภาษีตกลงที่จะผูกพันตามบริการพิสูจน์และยืนยันตัวตนทางดิจิทัล และ/หรือธุรกรรมใด ๆ ที่ได้ดำเนินการหรือเข้าทำผ่าน Digital ID Platform</li>
                            <li>ผู้เสียภาษีรับรองว่าข้อมูลและเอกสารทั้งหมด (รวมทั้งสำเนาของข้อมูลและเอกสารดังกล่าว) ที่มอบให้แก่กรมสรรพากร (ถ้ามี) เพื่อเป็นการพิสูจน์และยืนยันตัวตน และ/หรือการอนุญาต (authorization) นั้น เป็นจริง ถูกต้อง ครบถ้วนและเป็นข้อมูลที่เป็นปัจจุบัน และรับรองว่าผู้เสียภาษีมีความสามารถในการใช้บริการพิสูจน์และยืนยันตัวตนทางดิจิทัลได้ ซึ่งรวมถึงมีความสามารถในการทำธุรกรรมต่าง ๆ ไม่ว่าบางส่วนหรือทั้งหมด ที่เกี่ยวข้องกับบริการพิสูจน์และยืนยันตัวตนทางดิจิทัลด้วย</li>
                            <li>ผู้เสียภาษีตกลงว่าจะมอบข้อมูลเพิ่มเติมใด ๆ ก็ตามให้แก่กรมสรรพากรเมื่อได้รับการร้องขอ และ/หรือจะปรับปรุงข้อมูลดังกล่าวให้เป็นปัจจุบัน พร้อมแจ้งให้กรมสรรพากรทราบทันทีหากมีการเปลี่ยนแปลงข้อมูลนั้น</li>
                            <li>
                                <p>ผู้เสียภาษีรับทราบและตกลงว่า กรมสรรพากรอาจเก็บรวบรวมและใช้ข้อมูลที่ผู้เสียภาษีมอบให้แก่กรมสรรพากรซึ่งรวมถึงข้อมูลส่วนบุคคลของผู้เสียภาษี เช่น ข้อมูลชีวภาพ (ยกตัวอย่างเช่น ลายพิมพ์นิ้วมือ, การจดจำใบหน้า) เพื่อดำเนินการตามสัญญาระหว่างกรมสรรพากรกับผู้เสียภาษี และ/หรือ ดำเนินการใด ๆ ภายใต้วัตถุประสงค์ที่มีอยู่ในสัญญาดังกล่าว</p>
                                <p>นอกจากนี้ ผู้เสียภาษีรับทราบและตกลงว่า เพื่อการปฏิบัติตามสัญญาซึ่งผู้เสียภาษีได้เข้าไปเป็นคู่สัญญา กรมสรรพากรอาจเปิดเผยข้อมูลของผู้เสียภาษีตามวรรคหนึ่งแก่ผู้ให้บริการรายอื่น NDID สมาชิกรายอื่นใดของ NDID และ/หรือบุคคลภายนอกเท่าที่จำเป็น เพื่อประโยชน์ในการรับรองความถูกต้องของข้อมูล การบริการพิสูจน์และยืนยันตัวตนทางดิจิทัล การอนุญาต (authorization) และการทำธุรกรรมอื่น ๆ ที่เกี่ยวเนื่อง</p>
                            </li>
                            <li>
                                <p>เมื่อผู้เสียภาษีได้ยืนยันตัวตนทางดิจิทัลผ่าน NDID Platform เพื่อเข้าใช้บริการอิเล็กทรอนิกส์ของกรมสรรพากรแล้ว ตกลงที่จะผูกพันและปฏิบัติ ตามเงื่อนไขดังต่อไปนี้</p>
                                <ul>
                                    <li>
                                        9.1 การยื่นแบบแสดงรายการและชำระภาษี
                                        <ul>
                                            <li>(1) เมื่อผู้เสียภาษียื่นรายการข้อมูลตามแบบแสดงรายการ และชำระภาษีผ่านระบบอิเล็กทรอนิกส์ เมื่อผู้เสียภาษีได้ยืนยันการส่งข้อมูล และกรมสรรพากรตอบรับการยื่นรายการข้อมูลตามแบบแสดงรายการและรับชำระภาษีแล้ว ถือว่าเป็นการทำรายการโดยผู้เสียภาษี และยอมรับที่จะผูกพันในรายการนั้นว่าเป็นการยื่นแบบแสดงรายการและชำระภาษีของผู้เสียภาษี และรับรองว่ารายการข้อมูลดังกล่าวถูกต้องเป็นจริงทุกประการ รวมถึงจะผูกพันแบบแสดงรายการภาษีที่จัดพิมพ์ขึ้นโดยระบบคอมพิวเตอร์ในรายการข้อมูลตามการยื่นแบบแสดงรายการและชำระภาษีผ่านระบบอิเล็กทรอนิกส์</li>
                                            <li>(2) ผู้เสียภาษีจะต้องชำระภาษีภายในกำหนดเวลาตามกฎหมาย โดยจะต้องชำระภาษีผ่านหน่วยรับชำระภาษีและช่องทางการชำระภาษีที่กรมสรรพากรกำหนด หากยื่นรายการข้อมูลตามแบบแสดงรายการและชำระภาษีเกินกำหนดเวลาดังกล่าวผู้เสียภาษียอมรับว่าเป็นการยื่นแบบแสดงรายการและชำระภาษีในวันถัดไป</li>
                                            <li>(3) จำนวนเงินที่ผู้เสียภาษีชำระภาษีโดยการโอนเข้าบัญชีเงินฝากธนาคารของกรมสรรพากรจะต้องมีจำนวนเท่ากับจำนวนภาษีที่ต้องชำระตามแบบแสดงรายการภาษี</li>
                                            <li>(4) กรณีที่ธนาคารแจ้งว่าจำนวนเงินในบัญชีเงินฝากของผู้เสียภาษีมีไม่เพียงพอสำหรับการชำระภาษีตามแบบแสดงรายการภาษี หรือผู้เสียภาษีมิได้ชำระภาษีตามแบบแสดงรายการ จะถือว่าไม่มีการยื่นแบบแสดงรายการและชำระภาษีในครั้งนั้น</li>
                                            <li>(5) กรณีที่เกิดเหตุขัดข้องเป็นเหตุให้มีการหยุดการรับแบบแสดงรายการและรับชำระภาษีเป็นการชั่วคราวหรือกรณีอื่นใด ที่ทำให้ผู้เสียภาษีไม่สามารถยื่นรายการข้อมูลตามแบบแสดงรายการและชำระภาษีผ่านเครือข่ายอินเทอร์เน็ตได้ ผู้เสียภาษียังคงมีหน้าที่ต้องไปยื่นแบบแสดงรายการและชำระภาษี ณ สำนักงานสรรพากรพื้นที่สาขา</li>
                                        </ul>
                                    </li>
                                </ul>
                                <ul>
                                    <li>9.2 บริการอิเล็กทรอนิกส์อื่น ๆ ของกรมสรรพากร</li>
                                    <ul>
                                        <p>การใช้บริการอิเล็กทรอนิกส์อื่น ๆ ของกรมสรรพากรเป็นไปตามหลักเกณฑ์และเงื่อนไขที่ระบบให้บริการนั้น ๆ กำหนด</p>
                                    </ul>
                                </ul>
                            </li>
                        </ol>
                    </div>
                    <div style="text-align: center;">
                        <a class="MuiButtonBase-root MuiButton-root MuiButton-contained MuiButton-containedPrimary MuiButton-sizeMedium MuiButton-containedSizeMedium Mui-disabled MuiButton-root MuiButton-contained MuiButton-containedPrimary MuiButton-sizeMedium MuiButton-containedSizeMedium css-1r27nmu" tabindex="-1" aria-disabled="true" href="https://efiling.rd.go.th/rd-efiling-web/login">ปฏิเสธ</a>
                        <button class="MuiButtonBase-root MuiButton-root MuiButton-contained MuiButton-containedPrimary MuiButton-sizeMedium MuiButton-containedSizeMedium Mui-disabled MuiButton-root MuiButton-contained MuiButton-containedPrimary MuiButton-sizeMedium MuiButton-containedSizeMedium css-y9zlou" tabindex="-1" type="button" disabled="">ตกลง</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- NDID Process--%>
    <%--<iframe name="myIframe" id="myIframe" style="width: 100%; height: 100%; padding: 0px !important;" class="page-content footer-clear" runat="server"></iframe>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script>!function (e) { function r(r) { for (var n, i, a = r[0], c = r[1], l = r[2], p = 0, s = []; p < a.length; p++)i = a[p], Object.prototype.hasOwnProperty.call(o, i) && o[i] && s.push(o[i][0]), o[i] = 0; for (n in c) Object.prototype.hasOwnProperty.call(c, n) && (e[n] = c[n]); for (f && f(r); s.length;)s.shift()(); return u.push.apply(u, l || []), t() } function t() { for (var e, r = 0; r < u.length; r++) { for (var t = u[r], n = !0, a = 1; a < t.length; a++) { var c = t[a]; 0 !== o[c] && (n = !1) } n && (u.splice(r--, 1), e = i(i.s = t[0])) } return e } var n = {}, o = { 1: 0 }, u = []; function i(r) { if (n[r]) return n[r].exports; var t = n[r] = { i: r, l: !1, exports: {} }; return e[r].call(t.exports, t, t.exports, i), t.l = !0, t.exports } i.e = function (e) { var r = [], t = o[e]; if (0 !== t) if (t) r.push(t[2]); else { var n = new Promise((function (r, n) { t = o[e] = [r, n] })); r.push(t[2] = n); var u, a = document.createElement("script"); a.charset = "utf-8", a.timeout = 120, i.nc && a.setAttribute("nonce", i.nc), a.src = function (e) { return i.p + "static/js/" + ({}[e] || e) + "." + { 3: "dcb8d26c" }[e] + ".chunk.js" }(e); var c = new Error; u = function (r) { a.onerror = a.onload = null, clearTimeout(l); var t = o[e]; if (0 !== t) { if (t) { var n = r && ("load" === r.type ? "missing" : r.type), u = r && r.target && r.target.src; c.message = "Loading chunk " + e + " failed.\n(" + n + ": " + u + ")", c.name = "ChunkLoadError", c.type = n, c.request = u, t[1](c) } o[e] = void 0 } }; var l = setTimeout((function () { u({ type: "timeout", target: a }) }), 12e4); a.onerror = a.onload = u, document.head.appendChild(a) } return Promise.all(r) }, i.m = e, i.c = n, i.d = function (e, r, t) { i.o(e, r) || Object.defineProperty(e, r, { enumerable: !0, get: t }) }, i.r = function (e) { "undefined" != typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, { value: "Module" }), Object.defineProperty(e, "__esModule", { value: !0 }) }, i.t = function (e, r) { if (1 & r && (e = i(e)), 8 & r) return e; if (4 & r && "object" == typeof e && e && e.__esModule) return e; var t = Object.create(null); if (i.r(t), Object.defineProperty(t, "default", { enumerable: !0, value: e }), 2 & r && "string" != typeof e) for (var n in e) i.d(t, n, function (r) { return e[r] }.bind(null, n)); return t }, i.n = function (e) { var r = e && e.__esModule ? function () { return e.default } : function () { return e }; return i.d(r, "a", r), r }, i.o = function (e, r) { return Object.prototype.hasOwnProperty.call(e, r) }, i.p = "/", i.oe = function (e) { throw console.error(e), e }; var a = this["webpackJsonprd-rp-client"] = this["webpackJsonprd-rp-client"] || [], c = a.push.bind(a); a.push = r, a = a.slice(); for (var l = 0; l < a.length; l++)r(a[l]); var f = c; t() }([])</script>
    <script src="<%= ResolveClientUrl("~/scripts/Page/NDID.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/2.437bdeed.chunk.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
    <script src="<%= ResolveClientUrl("~/scripts/main.86d61be3.chunk.js") + "?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss") %>"></script>
</asp:Content>