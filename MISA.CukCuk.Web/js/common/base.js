
class BaseJS {
    constructor() {
        this.api = null;
        this.apiFilter = null;
        this.setDataUrl();
        this.initEvents();
        this.LoadDataforCombobox();
        this.LoadData();
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

            //lấy api trả về mã lớn nhất + 1
            var inputId = $('input[apiGetId]');
            var apiGetId = $(inputId).attr('apiGetId');
            var newId = "";
            $.ajax({
                url: apiGetId,
                method: "GET"
            }).done(function (res) {
                //gán mã lấy được vào ô nhập liệu
                var inputId = $('input[apiGetId]').val(res);
            }).fail(function (res) {

            })
        })
        //sự kiện khi  click vào 1 bản ghi
        $('table tbody').on('click', 'tr', function () {
            
            $('table tbody tr').removeClass('row-selected');         
            $(this).addClass('row-selected');

            //gán bản ghi đã chọn
            me.rowSelected = this;
        })

        //Load lại dữ liệu khi ấn button Load
        $('#btnRefresh').click(function () {
            me.Filter();
        })
        //sự kiện khi nhấn nút delete
        $('#btnDelete').click(function () {
            $('.noti').show();
        })
        
        //Ẩn form chi tiết khi ấn X:
        $('#btnX').click(function () {
            $('.dialog-detail').hide();
            $('table tbody tr').removeClass('row-selected');
            resetInputDialog();
        })
        //Ẩn form chi tiết khi nhấn nút cancel
        $('#btnCancel').click(function () {
            $('.dialog-detail').hide();
        })
        //Sự kiện khi bấm nút lưu
        $('#btnSave').click(function () {
            me.SaveOnClick();
            resetInputDialog();
        })

        // Hiển thị thông tin chi tiết khi nhấn đúp chuột chọn 1 dòng
        $('table tbody').on('dblclick', 'tr', function () {
            
            me.rowSelected = this;
            $(this).addClass('row-selected');
            $('.dialog-detail').show();
            me.method = "PUT";
            //lấy dữ liệu khóa chính của bản ghi được tác động
            var recordId = $(this).data('recordId');
            //Tiến hành map các thông tin tương ứng
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
        //Sự kiện khi nhấn nút tiếp tục trên form xác nhận xóa
        $('#btnNext').click(function () {
            var recordId = $(me.rowSelected).data('recordId');
            $.ajax({
                url: me.api + "?id=" + `${recordId}`,
                method: "DELETE"
            }).done(function (res) {
                $('.noti').hide();
                me.LoadData();
            }).fail(function (res) {
                alert("not done");

            })
        })
        //Sự kiện khi nhấn nút cancel trên thông báo xác nhận xóa
        $('#btnCancelMessage').click(function () {
            $('.noti').hide();
            return;
        })
        //Sự kiện khi nhấn nút X trên thông báo xác nhận xóa
        $('#btnXMessage').click(function () {
            $('.noti').hide();
            return;
        })
        //Sự kiện khi nhấn tiếp tục trên thông báo lỗi dữ liệu(trùng mã, ...)
        $('#btnNextMess').click(function () {
            //Xóa các dòng thông báo trên form
            $('noti-content-mess').html("");
            $('.noti-mess').hide();

        })
        //Đóng thông báo lỗi dữ liệu
        $('#btnXMessageMess').click(function () {
            //Xóa các dòng thông báo trên form
            $('noti-content-mess').html("");
            $('.noti-mess').hide();
        })
        //Sự kiện blur khỏi các trường bắt buộc nhập
        $('input[required]').blur(function () {

            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'trường này không được để trống');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
                $(this).attr('title', null);
            }
        })

        //Sự kiên blur tại các trường là email
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
                $(this).attr('title', null);

                $(this).attr('validate', true);
            }
        })


    }
    //Load tất cả dữ liệu
    LoadData() {
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
    /**
     * Đổ dữ liệu ra table
     * 
     * @param {any} res: dữ liệu từ server trả về
     */
    BindDataToTable(res) {
        var me = this;
        //Lấy ra tên các cột của table
        var columns = $('table thead th');
        $('table tbody').empty();
        //Lấy ra tên khóa chính cần thao tác
        me.keyId = $('table[keyId]').attr('keyId');
        //Duyệt tất cả các obj trả về để đổ ra table
        $.each(res, function (index, obj) {
            var tr = $(`<tr></tr>`);
            debugger;
            $(tr).data('recordId', obj[me.keyId]);
            //duyệt tất cả các cột để map dữ liệu
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
    //Load dữ liệu cho các combobox
    LoadDataforCombobox() {
        //Lấy ra tất cả các combobox cần đổ dữ liệu
        var selects = $('select[api]');
        //Duyệt tất cả các combobox để đổ dữ liệu tương ứng
        $.each(selects, function (index, select) {
            //Lấy api tương ứng
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
    //Lọc dữ liệu
    Filter() {
        var me = this;
        //Lấy ra các ô nhập liệu cần filter
        var fieldFilters = $('input[fieldFilter], select[fieldFilter]');
        //kiem tra xem co du lieu can tim ko
        var checkValue = "";
        $.each(fieldFilters, function (index, fieldFilter) {
            var value = $(fieldFilter).val();
            if (value)
                checkValue = "ok";
        })
        //Nếu không có dữ liệu cần tìm thì gọi hàm loadData(load tất cả)
        if (!checkValue) {
            me.LoadData();
            return;
        }
        //Nếu có thông tin cần tìm
        var api = me.api;
        //Thu thập dữ liệu cần lọc built thành api
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
        //Sử dụng api vừa built được để lấy dữ liệu
        $.ajax({
            url: api,
            method: "GET"
        }).done(function (res) {
            //load dữ liệu vào table
            me.BindDataToTable(res);
        })

    }

    SaveOnClick() {
        var me = this;
        //Lấy ra tất cả các ô nhập liệu cần validate
        var inputvaidates = $('input[required], input[type="email"]');
        //Tự động gọi sự kiện blur(Tránh trường hợp người dùng không nhập mà ấn lưu luôn)
        $.each(inputvaidates, function (index, input) {
            $(input).trigger('blur');
        })
        //Kiểm tra xem dữ liệu đã hợp lệ hết chưa(nếu chưa thì return luôn)
        var inputNotValids = $('input[validate="false"]');
        if (inputNotValids && inputNotValids.length > 0) {
            inputNotValids[0].focus();
            return;
        }
        //Lấy ra tất cả các ô nhập liệu trên form
        var inputs = $('input[fieldName],select[fieldName]');
        var entity = {};
        //Thu thập dữ liệu built thành object
        $.each(inputs, function (index, input) {
            var propertyName = $(this).attr('fieldName');
            var value = $(this).val();
            var formatType = $(input).attr('formatType');
            //Nếu là kiểu money thì format lại(loại bỏ các dấu . trước khi thêm,sửa)
            if (formatType == "money")
                value = value.split('.').join("");
            entity[propertyName] = value;
        })
        debugger;
        //Nếu đang ở trạng thái sửa thì lấy thông tin id cần sửa
        if (me.method == "PUT") {
            entity[me.keyId] = $(me.rowSelected).data('recordId');
        }
        //Thực thi
        $.ajax({
            url: me.api,
            method: me.method,
            data: JSON.stringify(entity),
            contentType: 'application/json'
        }).done(function (res) {
            if (res.success) {
                $('.dialog-detail').hide();
                me.LoadData();
            }
            else {
                //Trường hợp ko thực thi được thì thu thập lỗi, hiển thị cho người dùng biết
                $.each(res.Message, function (index, obj) {
                    //Built lỗi lên form thông báo
                    var contentMessage = $(`<div class="noti-content-detail-mess"></div>`);
                    contentMessage.append(obj);
                    $('.noti-content-mess').append(contentMessage);
                })
                $('.noti-mess').show();
            }

        }).fail(function (res) {

        })
    }
    //Mở form chi tiết và map dữ liệu khi double click
    DoubleClickOnRowTable() {
        
    }
}

