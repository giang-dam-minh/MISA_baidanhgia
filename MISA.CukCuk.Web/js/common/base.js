
class BaseJS {
    constructor() {
        this.api = null;
        this.apiFilter = null;
        this.setDataUrl();
        this.initEvents();
        this.loadDataforCombobox();
        this.loadData();
    }
    setDataUrl() {

    }
    initEvents() {
        var me = this;
        //sự kiện click thi nhấn vào thêm ms
        $('#btnAdd').click(function () {
            //Hiển thị dialog thông tin chi tiết:
            $('.dialog-detail').show();
            $('input[focus]').focus();
            me.method = "POST";
            var inputId = $('input[apiGetId]');
            var apiGetId = $(inputId).attr('apiGetId');
            var newId = "";
            $.ajax({
                url: apiGetId,
                method: "GET"
            }).done(function (res) {
                var inputId = $('input[apiGetId]').val(res);
            }).fail(function (res) {
            })
        })

        $('table tbody').on('click', 'tr', function () {
            //$('table tbody tr').find('td').removeClass('selected-row');
            $('table tbody tr').removeClass('row-selected');
            //$(this).find('td').addClass('selected-row');
            $(this).addClass('row-selected');
            me.rowSelected = this;
        })

        //Load lại dữ liệu khi ấn button Load
        $('#btnRefresh').click(function () {
            me.Filter();

        })

        $('#btnDelete').click(function () {
            $('.noti').show();

        })
        //$('#btnDelete').click(function () {
        //    $('.noti').show();
        //    var recordId = $(me.rowSelected).data('recordId');
        //    debugger
        //    $.ajax({
        //        url: me.api + "/id?id=" + `${recordId}`,
        //        method: "DELETE",
        //    }).done(function (res) {
        //        debugger
        //        alert("Xóa thành công");
        //    }).fail(function (res) {
        //        debugger;
        //        alert("fail");
        //    })
        //}
        //Ẩn form chi tiết khi ấn X:
        $('#btnX').click(function () {
            $('.dialog-detail').hide();
            $('table tbody tr').removeClass('row-selected');
            resetInputDialog();
        })

        $('#btnCancel').click(function () {
            $('.dialog-detail').hide();
        })
        $('#btnSave').click(function () {
            var inputvaidates = $('input[required], input[type="email"]');
            $.each(inputvaidates, function (index, input) {
                $(input).trigger('blur');
            })
            var inputNotValids = $('input[validate="false"]');
            if (inputNotValids && inputNotValids.length > 0) {
                inputNotValids[0].focus();
                return;
            }

            var inputs = $('input[fieldName],select[fieldName]');
            var entity = {};
            $.each(inputs, function (index, input) {
                var propertyName = $(this).attr('fieldName');
                var value = $(this).val();
                var formatType = $(input).attr('formatType');
                if (formatType == "money")
                    value =value.split('.').join("");
                entity[propertyName] = value;
            })
            if (me.method == "PUT") {

                entity[me.keyId] = $(me.rowSelected).data('recordId');
            }
            console.log(me.method);
            debugger
            $.ajax({
                url: me.api,
                method: me.method,
                data: JSON.stringify(entity),
                contentType: 'application/json'
            }).done(function (res) {
                if (res.success) {
                    $('.dialog-detail').hide();
                    me.loadData();
                }
                else {
                    $.each(res.Message, function (index, obj) {
                        var contentMessage = $(`<div class="noti-content-detail-mess"></div>`);
                        contentMessage.append(obj);
                        $('.noti-content-mess').append(contentMessage);
                    })
                    $('.noti-mess').show();
                    debugger;
                }

            }).fail(function (res) {

            })

        })

        // Hiển thị thông tin chi tiết khi nhấn đúp chuột chọn 1 dòng
        $('table tbody').on('dblclick', 'tr', function () {
            me.rowSelected = this;
            $(this).addClass('row-selected');
            $('.dialog-detail').show();
            me.method = "PUT";
            var recordId = $(this).data('recordId');
            $.ajax({
                url: me.api + "/id?id=" + `${recordId}`,
                method: "GET"
            }).done(function (res) {
                var inputs = $('input[fieldName],select[fieldName]');
                $.each(inputs, function (index, input) {

                    var propertyName = $(this).attr('fieldName');
                    var value = res[0][propertyName];
                    if ($(this).attr('type') == "date") {
                        value = regenDate(value);
                    }

                    $(this).val(value);
                })
                
            }).fail(function (res) {

            })

        })
        $('#btnNext').click(function () {
            var recordId = $(me.rowSelected).data('recordId');
            $.ajax({
                url: me.api + "?id=" + `${recordId}`,
                method: "DELETE"
            }).done(function (res) {
                $('.noti').hide();
                me.loadData();
            }).fail(function (res) {
                alert("not done");

            })
        })
        $('#btnCancelMessage').click(function () {
            $('.noti').hide();
            return;
        })
        $('#btnXMessage').click(function () {
            $('.noti').hide();
            return;
        })

        $('#btnNextMess').click(function () {
            $('noti-content-mess').html("");
            $('.noti-mess').hide();

        })
        $('#btnXMessageMess').click(function () {
            $('.noti-mess').hide();
        })
        $('input[required]').blur(function () {

            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'trường này không được để trống');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })


        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
            if (!testEmail.test(value)) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Email không dúng định dạng Example: example@domain.com');
                $(this).attr('validate', false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })


    }
    loadData() {
        var me = this;
        try {
            var api = this.api;
            $.ajax({
                url: api,
                method: "GET",
            }).done(function (res) {
                me.BindDataToTable(res);
            }).fail(function (res) {

            })
        } catch (e) {
        }
    }
    BindDataToTable(res) {
        var me = this;
        var columns = $('table thead th');
        $('table tbody').empty();
        me.keyId = $('table[keyId]').attr('keyId');
        $.each(res, function (index, obj) {
            var tr = $(`<tr></tr>`);
            $(tr).data('recordId', obj[me.keyId]);
            $.each(columns, function (index, th) {
                var td = $(`<td><div><span></span></div></td>`);
                var fieldName = $(th).attr('fieldname');
                var value = obj[fieldName];
                var formatType = $(th).attr('formatType');
                switch (formatType) {
                    case "ddmmyyyy":
                        value = formatDate(value);
                        break;
                    case "Money":
                        value = formatMoney(value) + " VND";
                        break;
                    case "Gender":
                        value = formatGender(value);
                        break;
                    case "WorkStatus":
                        value = formatWorkStatus(value);
                        break;
                    default:
                }
                td.append(value);
                $(tr).append(td);
            })
            $('table tbody').append(tr);

        })
    }

    loadDataforCombobox() {
        var selects = $('select[api]');
        //selects.empty();
        $.each(selects, function (index, select) {
            var api = $(select).attr('api');
            var displayName = $(select).attr('displayName');
            var fieldValue = $(select).attr('fieldName');
            $.ajax({
                url: api,
                method: "GET"
            }).done(function (res) {
                if (res) {
                    $.each(res, function (index, obj) {
                        var o = new Option();
                        o.value = obj[fieldValue];
                        o.text = obj[displayName];
                        select.append(o);
                    })
                }
            }).fail(function (res) {

            })
        })
    }

    Filter() {
        var me = this;
        var fieldFilters = $('input[fieldFilter], select[fieldFilter]');
        //kiem tra xem co du lieu can tim ko
        var checkValue = "";
        $.each(fieldFilters, function (index, fieldFilter) {
            var value = $(fieldFilter).val();
            if (value)
                checkValue = "ok";
        })
        if (!checkValue) {
            me.loadData();
            return;
        }
        var api = me.api;
        //thu thập dữ liệu cần lọc built thành api

        $.each(fieldFilters, function (index, fieldFilter) {
            var fieldFilterName = $(fieldFilter).attr('fieldFilter');
            api = api + "/" + `${fieldFilterName}`;

        })
        api = api + "?";
        $.each(fieldFilters, function (index, fieldFilter) {
            var fieldFilterName = $(fieldFilter).attr('fieldFilter');
            var value = $(fieldFilter).val();
            api = api + `${fieldFilterName}=` + `${value}&`;

        })
        $.ajax({
            url: api,
            method: "GET"
        }).done(function (res) {
            //load lai data vo table
            me.BindDataToTable(res);
        })

    }



}

