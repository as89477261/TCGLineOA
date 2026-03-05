'use strict'
var myModal = new bootstrap.Modal(document.getElementById('updateModal'), {
    keyboard: false
});
var insertModal = new bootstrap.Modal(document.getElementById('InsertModal'), {
    keyboard: false
});
var deleteModal = new bootstrap.Modal(document.getElementById('DeleteModal'), {
    keyboard: false
});

$(window).on('load', function () {
    $('.datepickerInsert').datepicker({ language: 'th-th', format: 'dd/mm/yyyy' })
    $('.datepickerInsert').datepicker('update', new Date());
    $('.datepicker').datepicker({ language: 'th-th', format: 'dd/mm/yyyy' })

    /* table data master */
    $('.footable').footable({
        "paging": {
            "enabled": true,
            "container": '#footable-pagination',
            "countFormat": "{CP} of {TP}",
            "limit": 3,
            "position": "right",
            "size": 5
        },
        "sorting": {
            "enabled": true
        },
    }, function (ft) {
        $('#footablestot').html($('.footable-pagination-wrapper .label').html())

        $('.footable-pagination-wrapper ul.pagination li').on('click', function () {
            setTimeout(function () {
                $('#footablestot').html($('.footable-pagination-wrapper .label').html());
            }, 200);
        });

    });

    ///* Inline date picker  */
    //$('#daterangepickerinline').daterangepicker({
    //    "singleDatePicker": true,
    //    "timePicker": false,
    //    "alwaysShowCalendars": true,
    //    "startDate": "01/01/2022",
    //    "endDate": "01/07/2022",
    //    "parentEl": ".calendarinline",
    //    "opens": "center",
    //    "applyButtonClasses": "btn-theme",
    //    "cancelClass": "btn-outline-secondary border",
    //    "autoUpdateInput": true,
    //    locale: {
    //        format: 'DD/MM/YYYY hh:mm A'
    //    }
    //}, function (start, end, label) {
    //})
    //$('#daterangepickerinline').on('showCalendar.daterangepicker', function (ev, picker) {
    //    $('.todaysdate').text(picker.startDate.format('DD/MM/YYYY')); // this will return and set date selected/changed
    //});
    //$('#daterangepickerinline').click(); // this will open default


});
function GenDate(dateString, hour, min) {
 
    var date = dateString.split('/');


    console.log(date[0] + '++' + date[1] + '++' + date[2] +'++'+ hour +'++'+ min)
    var day = date[0];
    var month = parseInt(date[1]) - 1;
    var year = parseInt(date[2]) - 543;

    var result = new Date(year, month, day, hour, min, '00');
    result = new Date(result.setHours(result.getHours() + 7));
    console.log(result);
    return result;
}

function ShowInsertModel() {
    insertModal.show();
}
function ShowEditModal(id) {
    GetData(id);
    myModal.show();
}
function ShowDeleteModal(id) {
    $('#hddDeleteID').val(id)

    deleteModal.show();
}

function GenerateInsertObj() {
    var obj = {
        title: $('#txtInsertTitle').val(),
        body: $('#txtInsertBody').val(),
        seq: $('#txtInsertSeq').val(),
        status: ($('#chkInsertIsActive').is(":checked") === true ? "1" : "0"),
        start_date: GenDate($('#txtInsertStartDate').val(), $('#ddlInsertStartDateHour').val(), $('#ddlInsertStartDateMin').val()),
        end_date: GenDate($('#txtInsertEndDate').val(), $('#ddlInsertEndDateHour').val(), $('#ddlInsertEndDateMin').val()),
        full_name: '',
        create_by: 'system'

    };
    return obj;
}
function GenerateEditObj() {


    var obj = {
        id: $('#hddUpdateID').val(),
        title: $('#txtEditTitle').val(),
        body: $('#txtEditBody').val(),
        seq: $('#txtEditSeq').val(),
        start_date: GenDate($('#txtEditStartDate').val(), $('#ddlStartDateHour').val(), $('#ddlStartDateMin').val()),
        end_date: GenDate($('#txtEditEndDate').val(), $('#ddlEndDateHour').val(), $('#ddlEndDateMin').val()),
        status: ($('#chkEditIsActive').is(":checked") === true ? "1" : "0"),
        create_by: 'system'
    };
    return obj;
}

function SaveInsert() {
    var obj = GenerateInsertObj();
    var result = InsertData(obj);
}
function SaveEdit() {
    var obj = GenerateEditObj();
    var result = UpdateData(obj);
}
function SaveDelete() {
    var id = $('#hddDeleteID').val()
    var result = DeleteData(id);
}

function CheckInsertResult(status) {
    if (status === 200) {
        insertModal.hide();
        swal("เสร็จสิ้น", "บันทึกข้อมูลเสร็จสิ้น", "success").then((value) => {
            location.reload()
        });

    } else {
        insertModal.hide();
        swal("แจ้งเตือน", "ไม่สามารถบันทึกข้อมูลได้", "error");
    }
}
function CheckUpdateResult(status) {
    if (status === 200) {
        myModal.hide();
        swal("เสร็จสิ้น", "บันทึกข้อมูลเสร็จสิ้น", "success").then((value) => {
            location.reload()
        });
    } else {
        myModal.hide();
        swal("แจ้งเตือน", "ไม่สามารถบันทึกข้อมูลได้", "error");
    }
}
function CheckDeleteResult(status) {
    if (status === 200) {
        deleteModal.hide();
        swal("เสร็จสิ้น", "บันทึกข้อมูลเสร็จสิ้น", "success").then((value) => {
            location.reload()
        });
    } else {
        deleteModal.hide();
        swal("แจ้งเตือน", "ไม่สามารถบันทึกข้อมูลได้", "error");
    }

}

function GetData(contactID) {
    $.ajax({
        type: "GET",
        url: host + "/Config/News?handler=NewsByID",
        contentType: 'application/json',
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: { id: contactID },
        success: function (response) {
            if (response !== 'undefined') {
                $('#txtEditTitle').val(response.title);

                $('#txtEditBody').val(response.body);
                $('#txtEditSeq').val(response.seq);

                var strDate = new Date(response.starT_DATE);
                var strDateValue = strDate.getDate().toString() + '/' + strDate.getMonth().toString() + '/' + (strDate.getFullYear()+543).toString();
                $('#txtEditStartDate').val(strDateValue);
                console.log(strDate.getHours().toString());
                $('#ddlStartDateHour').val(strDate.getHours().toString());
                $('#ddlStartDateMin').val(strDate.getMinutes().toString());


                var endDate = new Date(response.enD_DATE);
                var endDateValue = endDate.getDate().toString() + '/' + endDate.getMonth().toString() + '/' + (endDate.getFullYear() + 543).toString();
                $('#txtEditEndDate').val(endDateValue);
                console.log(endDate.getHours().toString());
                $('#ddlEndDateHour').val(endDate.getHours().toString());
                $('#ddlEndDateMin').val(endDate.getMinutes().toString());

             
                $('#chkEditIsActive').prop('checked', response.status === "1" ? true : false);
                $('#hddUpdateID').val(response.id);

            }

        },
        failure: function (response) {
            //alert(response.responseText);
        },
        error: function (response) {
            //alert(response.responseText);
        }
    });
}
function InsertData(obj) {
    $.ajax({
        type: "POST",
        url: host + "/Config/News?handler=Insert",
        contentType: 'application/json',
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(obj),
        success: function (response) {
            CheckInsertResult(response.status);

        },
        failure: function (response) {
            CheckInsertResult(response.status);
        },
        error: function (response) {
            CheckInsertResult(response.status);
        }
    });
}
function UpdateData(obj) {

    $.ajax({
        type: "POST",
        url: host + "/Config/News?handler=UpdateByID",
        contentType: 'application/json',
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(obj),
        success: function (response) {

            CheckUpdateResult(response.status);
        },
        failure: function (response) {
            CheckUpdateResult(response.status);
        },
        error: function (response) {
            CheckUpdateResult(response.status);
        }
    });
}
function DeleteData(contactID) {

    $.ajax({
        type: "GET",
        url: host + "/Config/News?handler=DeleteByID",
        contentType: 'application/json',
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: { id: contactID.toString() }
        ,
        success: function (response) {
            CheckDeleteResult(response.status);
        },
        failure: function (response) {
            CheckDeleteResult(response.status);
        },
        error: function (response) {
            CheckDeleteResult(response.status);
        }
    });
}