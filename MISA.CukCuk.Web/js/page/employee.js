$(document).ready(function () {
    new employeejs();
})
/**
 * Class quan ly su kien cho trang Employee
 * CreatedBy: abc (29/12/2020)
 * */
class employeejs extends BaseJS {
    //ham khoi tao đc chạy đầu tiên
    constructor() {
        super();
        this.initEvent();
    }

    setDataUrl() {
        this.api = "http://localhost:56094/api/v1/Employees";
    }
    initEvent() {
        var employee = this;
        $('#btnRefresh').click(function () {
            //Hiểnthị customer thông tin chi tiết sau khi Load data:
            $('#table').remove('tr');
            employee.filter();
        })
    }
    filter() {
        $('table tbody').empty();
        var employeeCode = $('#txtFilter').val();
        var fullName = $('#txtFilter').val();
        var positionId = $('#cbxPosition').val();
        var departmentId = $('#cbxDepartment').val();
        debugger
        try {
            var columns = $('table thead th');
            var api = this.api;
              api = api + "/code/fullname/position/department?employeeCode=" + `${employeeCode}` + "&fullName=" + `${fullName}` + "&positionId=" +`${positionId}` + "&departmentId=" + `${departmentId}`;
            debugger
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
            console.log(e);
        }
    }
}




