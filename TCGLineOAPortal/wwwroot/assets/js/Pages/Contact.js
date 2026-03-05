'use strict'
var myModal = new bootstrap.Modal(document.getElementById('exampleModal'), {
    keyboard: false
});
var insertModal = new bootstrap.Modal(document.getElementById('InsertModal'), {
    keyboard: false
});
var deleteModal = new bootstrap.Modal(document.getElementById('DeleteModal'), {
    keyboard: false
});


$(window).on('load', function () {

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

    /* Inline date picker  */
    $('#daterangepickerinline').daterangepicker({
        "singleDatePicker": true,
        "timePicker": false,
        "alwaysShowCalendars": true,
        "startDate": "01/01/2022",
        "endDate": "01/07/2022",
        "parentEl": ".calendarinline",
        "opens": "center",
        "applyButtonClasses": "btn-theme",
        "cancelClass": "btn-outline-secondary border",
        "autoUpdateInput": true,
        locale: {
            format: 'DD/MM/YYYY hh:mm A'
        }
    }, function (start, end, label) {
    })
    $('#daterangepickerinline').on('showCalendar.daterangepicker', function (ev, picker) {
        $('.todaysdate').text(picker.startDate.format('DD/MM/YYYY')); // this will return and set date selected/changed
    });
    $('#daterangepickerinline').click(); // this will open default


});


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
        phone1: $('#txtInsertPhone').val(),
        phone2: $('#txtInsertPhone').val(),
        status: ($('#chkInsertIsActive').is(":checked") === true ? "1" : "0"),
        full_name: '',
        create_by: 'system'

    };
    return obj;
}
function GenerateEditObj() {
    var obj = {
        id: $('#hddID').val(),
        title: $('#txtTitle').val(),
        phone1: $('#txtPhone').val(),
        phone2: $('#txtPhone').val(),
        status: ($('#chkIsActive').is(":checked") === true ? "1" : "0"),
        full_name: '',
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
        url: host + "/Config/Contact?handler=ContactByID",
        contentType: 'application/json',
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: { id: contactID },
        success: function (response) {
            if (response !== 'undefined') {
                $('#txtTitle').val(response.title);
                $('#txtPhone').val(response.phonE1);
                $('#chkIsActive').prop('checked', response.status === "1" ? true : false);
                $('#hddID').val(response.id);

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
        url: host + "/Config/Contact?handler=Insert",
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
        url: host + "/Config/Contact?handler=UpdateByID",
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
        url: host + "/Config/Contact?handler=DeleteByID",
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