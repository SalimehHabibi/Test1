function checkLenght() {
    $(".lenght").keydown(function (event) {
        var lenght = $(this).data('lenght');
        var count = $(this).val().length;
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
        (event.keyCode == 65 && event.ctrlKey === true)) {
            return;
        }
        if (lenght > 0 && count == lenght) {
            event.preventDefault();
        }
    })
}
function onlyNumber() {
    $(".onlyNumber").keydown(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 110 ||
        (event.keyCode == 65 && event.ctrlKey === true)) {
            return;
        }
        else if (event.keyCode >= 35 && event.keyCode <= 39) {
            return;
        }
        else {
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });
}
function valid(containerid) {
    var strContainer = '#' + containerid;
    var isValid = true;
    $('input[type=text][class*=required], input[type=file][class*=required], input[type=checkbox][class*=required], select[class*=required], input[type=password][class*=required]', strContainer).each(function (index, element) {
        if ($(this).val() == '' || $(this).val() == undefined) {
            isValid = false;
            $(this).addClass('errReq').prop('style', 'border: 1px solid #f00;');
        }
    });
    if (isValid == false) {
        alert('فیلدهای قرمز را پر نمایید');
    }
    return isValid;
}
function changeValid(containerid) {
    var strContainer = '#' + containerid;
    $('input[type=text]').on('change', function () {
        $(this).removeClass('errReq').prop('style', '');
    });
    $('input[type=password]').on('change', function () {
        $(this).removeClass('errReq').prop('style', '');
    });
    $('select').on('change', function () {
        $(this).removeClass('errReq').prop('style', '');
    });
}
function emptyElements(container) {
    var strContainer = '#' + container;
    $('input[type=text], input[type=file], input[type=password],input[type=checkbox], select', strContainer).each(function (index, element) {
        $(this).val('');
    });
   
}
function validBack(containerid) {
    var strContainer = '#' + containerid;
    $('input[type=text][class*=errReq], input[type=file][class*=errReq], input[type=checkbox][class*=errReq], select[class*=errReq], input[type=password][class*=errReq]', strContainer).each(function (index, element) {
        $(this).removeClass('errReq').prop('style', '');
    });
};

function validNationalCode(value) {
    var isValidNCode = true;
    if (value.length == 10) {
        var a = value.substring(10, 9);
        var b = (value.substring(1, 0) * 10) +
        (value.substring(2, 1) * 9) +
        (value.substring(3, 2) * 8) +
        (value.substring(4, 3) * 7) +
        (value.substring(5, 4) * 6) +
        (value.substring(6, 5) * 5) +
        (value.substring(7, 6) * 4) +
        (value.substring(8, 7) * 3) +
        (value.substring(9, 8) * 2);
        var c = b % 11;
        if (!((c < 2 && c == a) || (c >= 2 && (11 - c) == a))) {
            alert('کدملی نامعتبر است');
            isValidNCode = false;
        }
    }
    else {
        alert('کدملی باید 10 رقم باشد');
        isValidNCode = false;
    }
    return isValidNCode;
}