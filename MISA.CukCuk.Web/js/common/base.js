
class BaseJS {
    constructor() {
        this.api = null;
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
            $('#txtCustomerCode').focus();
            me.method = "POST";
           // me.loadDataforCombobox();
        })

        $('table tbody').on('click', 'tr', function () {
            //$('table tbody tr').find('td').removeClass('selected-row');
            $('table tbody tr').removeClass('row-selected');
            //$(this).find('td').addClass('selected-row');
            $(this).addClass('row-selected');
            me.rowSelected = this;
        })

        //Load lại dữ liệu khi ấn button Load
        //$('#btnRefresh').click(function () {
        //    //Hiểnthị customer thông tin chi tiết sau khi Load data:
        //    $('#table').remove('tr');
        //    me.loadData();
        //})
        $('#btnDelete').click(function () {
            var recordId = $(me.rowSelected).data('recordId');
            debugger
            $.ajax({
                url: me.api + "/id?id=" + `${recordId}`,
                method: "DELETE",               
            }).done(function (res) {
                debugger
                alert("Xóa thành công");
            }).fail(function (res) {
                debugger;
                alert("fail");
            })
        })
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
                alert("Dữ liệu không hợp lệ vui lòng kiểm tra lại.");
                inputNotValids[0].focus;
                return;
            }

            var inputs = $('input[fieldName],select[fieldName]');
            var entity = {};
            $.each(inputs, function (index, input) {
                var propertyName = $(this).attr('fieldName');
                var value = $(this).val();
                entity[propertyName] = value;
            })
            if (me.method == "PUT") {
                entity.EmployeeId = $(me.rowSelected).data('recordId');
            }
            console.log(me.method);
            debugger
            $.ajax({
                url: me.api,
                method: me.method,
                data: JSON.stringify(entity),
                contentType: 'application/json'
            }).done(function (res) {
                $('.dialog-detail').hide();
                me.loadData();
                console.log("done");
                debugger
            }).fail(function (res) {
                console.log("fail");
                debugger
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
                        value=regenDate(value);
                    }
                    
                    $(this).val(value);
                })
                debugger
            }).fail(function (res) {

            })

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
        $('table tbody').empty();
        try {
            var columns = $('table thead th');
            var api = this.api;
            $.ajax({
                url: api,
                method: "GET",
            }).done(function (res) {
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $(tr).data('recordId', obj["EmployeeId"]);
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
                                value = formatMoney(value);
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
            }).fail(function (res) {

            })
        } catch (e) {
        }

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
}

