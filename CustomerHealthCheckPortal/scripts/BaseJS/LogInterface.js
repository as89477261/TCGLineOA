function CreateLogObject(type, UID, ref) {

    const mapping = {
        HEALTH_CHECK: { ApplicationCode: "APP05", SubApplicationCode: "SAPP05001", Remark: "" },
        FA_DOCTOR: { ApplicationCode: "APP10", SubApplicationCode: "SAPP10001", Remark: "" },
        EVENT_ATTENTION_PGS10: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04004", Remark: "" },
        EVENT_ATTENTION_PGS11: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04005", Remark: "PGS11" },
        EVENT_TCGXGSB: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04009", Remark: "" },
        EVENT_TCGXEXIM: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04006", Remark: "" },
        EVENT_TCGXSET: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04007", Remark: "" },
        EVENT_TCC_PROJECT: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04008", Remark: "" },
        DEBT_DOCTOR: { ApplicationCode: "APP10", SubApplicationCode: "SAPP10001", Remark: "" },
        REWARD: { ApplicationCode: "APP14", SubApplicationCode: "SAPP14001", Remark: "" },
        MYGUARANTEE: { ApplicationCode: "APP12", SubApplicationCode: "SAPP12001", Remark: "" },
        EVENT_PREAPP_OR: { ApplicationCode: "APP13", SubApplicationCode: "SAPP13001", Remark: ref },
        EVENT_PREAPP_KORSO: { ApplicationCode: "APP13", SubApplicationCode: "SAPP13002", Remark: ref },
        EVENT_PREAPP_REGISTERREWARD: { ApplicationCode: "APP13", SubApplicationCode: "SAPP13003", Remark: ref },
        DCU_CalLoanPayment: { ApplicationCode: "APP14", SubApplicationCode: "SAPP14001", Remark: ref },
        DCU_CalDebt: { ApplicationCode: "APP14", SubApplicationCode: "SAPP14002", Remark: ref },
        EVENT_PREAPP_TCGREGISTER: { ApplicationCode: "APP13", SubApplicationCode: "SAPP13004", Remark: ref },
        EVENT_ATTENTION_PICKUP: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04006", Remark: "SMEsPickUp" },
        EVENT_PREAPP_CAMPAIGNCONFIG: { ApplicationCode: "APP13", SubApplicationCode: "SAPP13005", Remark: ref },
        EVENT_GOOD_MONEY_CAMPAIGN: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04011", Remark: ref },
        EVENT_SPECIAL_EVENT: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04012", Remark: ref },
        EVENT_PICKUP_CAMPAIGN: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04013", Remark: ref },
        EVENT_PROMPTKHUM: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04014", Remark: ref },
        EVENT_CENTRAL_LAB: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04015", Remark: ref },
        EVENT_HEALTCHECK: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04016", Remark: ref },
        EVENT_KORORCHOR: { ApplicationCode: "APP04", SubApplicationCode: "SAPP04017", Remark: ref },
        CALCULATOR_MAIN: { ApplicationCode: "APP12", SubApplicationCode: "SAPP12001", Remark: ref },
        CALCULATOR_LEASING: { ApplicationCode: "APP12", SubApplicationCode: "SAPP12002", Remark: ref },
        CALCULATOR_LOAN: { ApplicationCode: "APP12", SubApplicationCode: "SAPP12003", Remark: ref },
        CALCULATOR_DEBT: { ApplicationCode: "APP12", SubApplicationCode: "SAPP12004", Remark: ref },
    }

    const defaultMapping = { ApplicationCode: "", SubApplicationCode: "", Remark: "" };

    const selectedMapping = mapping[type] || defaultMapping;

    return {
        UID: UID,
        ApplicationCode: selectedMapping.ApplicationCode,
        SubApplicationCode: selectedMapping.SubApplicationCode,
        ActivityCode: "ACT001",
        Remark: selectedMapping.Remark,
        CreateBy: "system",
        Status: true
    };
}


function KeepLogActivity(type, UID, ref) {
    console.log("Keep log : " + type + " UID : " + UID + " Ref : " + ref);

    var obj = CreateLogObject(type, UID, ref);
    CreateLogActivity(obj);
}