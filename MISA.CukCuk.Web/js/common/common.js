/**
 * Định dạng lại ngày tháng
 * ví dụ: 2020/12/01 => 01/12/2020
 * @param {any} date
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return " ";
    }
    else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? "0" + day : day;
        month = month < 10 ? "0" + month : month;
        return day + '/' + month + '/' + year;
    }
}
/**
 * Định dạng lại kiểu money
 * ví dụ: 2000000 => 2.000.000
 * @param {any} money
 */
function formatMoney(money) {
    if (money == null)
        return "";
    var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
    return num;
}
/**
 * Định dạng kiểu giới tính
 * 1 => nam
 * 0 => nữ
 * @param {any} gender
 */
function formatGender(gender) {
    if (gender == 1)
        return "Nam";
    else
        return "Nữ";
}
/**
 * Định dạng kiểu trang thái công việc
 * 1 => Đang làm việc
 * 0 => Đã nghỉ việc
 * @param {any} status
 */
function formatWorkStatus(status) {
    if (status == 1)
        return "Đang làm việc";
    else if (status == 0)
        return "Đã nghỉ việc";
}
/**
 * Làm mới các ô nhập liệu
 * */
function resetInputDialog() {
    $('input[type="text"], input[type="date"], input[type="email"]').val(null);
    $('input').removeClass('border-red');
    // $('select[fieldName]').empty();
}
/**
 * định dạng lại kiểu date để đẩy ra combobox
 * @param {any} dateInput
 */
function regenDate(dateInput) {
    if (dateInput) {
        let year = parseInt(dateInput.substr(0, 4));
        let mon = parseInt(dateInput.substr(5, 2));
        let day = parseInt(dateInput.substr(8, 2));

        day = day >= 10 ? day : '0' + day;
        mon = mon >= 10 ? mon : '0' + mon;

        var date = `${year}-${mon}-${day}`;
        return date;
    }
    return "";
}
/**
 * format kiểu money khi nhập
 * @param {any} input
 */
function onChange(input) {
    var value = $(input).val();
    value = value.split('.').join("");
    value = formatMoney(parseFloat(value));
    debugger
    $(input).val(value);
    debugger;
}