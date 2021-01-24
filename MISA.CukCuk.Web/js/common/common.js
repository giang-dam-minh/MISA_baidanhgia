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

function formatMoney(money) {
    if (money == null)
        return " ";
    var num = money.toFixed(1).replace(/(\d)(?=(\d{3})+\.)/g, '1,');
    return num;
}
function formatGender(gender) {
    if (gender == 1)
        return "Nam";
    else
        return "Nữ";
}
function formatWorkStatus(status) {
    if (status == 1)
        return "Đang làm việc";
    else if (status == 0)
        return "Đã nghỉ việc";
}
function resetInputDialog() { 
    $('input[type="text"], input[type="date"], input[type="email"]').val(null);
    $('input').removeClass('border-red');
   // $('select[fieldName]').empty();
}

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