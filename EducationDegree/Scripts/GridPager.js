
function refereshPager(tbodyID, functionReadCount, functionLoadRecords, page) {
    $(document).data('CurrentTbodyID', tbodyID);
    $('#' + tbodyID).data('functionReadRecords', functionLoadRecords);
    $('#' + tbodyID).data('functionReadCount', functionReadCount);
    var countRecords = functionReadCount();
    $('#' + tbodyID).data('CountRecords', countRecords);
    page(page);
}
function refereshGridWithFirstRow(firstRow) {
    load(firstRow, getFunctionReadCount(), getFunctionReadRecords());
}
function refereshGrid() {
    load(getCurrentFirstRow(), getFunctionReadCount(), getFunctionReadRecords());
}
function loadGrid(tbodyID, functionReadCount, functionLoadRecords) {
    $(document).data('CurrentTbodyID', tbodyID);
    $('#' + tbodyID).data('functionReadRecords', functionLoadRecords);
    $('#' + tbodyID).data('functionReadCount', functionReadCount);
    if (page() == null || page() == undefined) {
        page(1);
    }
    load(getCurrentFirstRow(), functionReadCount, functionLoadRecords);
}
function load(firstRow, functionReadCount, functionLoadRecords) {
    functionLoadRecords(firstRow);//tesssssssssssssssst
    var countRecords = functionReadCount();
    var tbodyID = getCurrentTbodyID();
    $('#' + tbodyID).data('CountRecords', countRecords);
    //if (countRecords > 0) {
    //    //functionLoadRecords(firstRow);
    //}
    if (countRecords <= 0) {
        $('#' + tbodyID).empty();
        $('#' + tbodyID).append('<tr><td class="borderNone" colspan="100%">هیچ موردی یافت نشد</td></tr>');
        addEmptyRecords(9, tbodyID);
        addEmptyRecords(5, tbodyID);
    }
    setPager();
}
function bindPager(pagerID) {
    $('#' + pagerID + ' input[name=BtnFirst]').on('click', function () {
        btnFirstClick();
    });
    $('#' + pagerID + ' input[name=BtnPrevius]').on('click', function () {
        btnPreviusClick();
    });
    $('#' + pagerID + ' input[name=BtnNext]').on('click', function () {
        btnNextClick();
    });
    $('#' + pagerID + ' input[name=BtnLast]').on('click', function () {
        btnLastClick();
    });
}
//----------------------------------------------------------------
function getCurrentTbodyID() {
    return $(document).data('CurrentTbodyID');
}
function getCountRecords() {
    return $('#' + getCurrentTbodyID()).data('CountRecords');
}
function getFunctionReadCount() {
    return $('#' + getCurrentTbodyID()).data('functionReadCount');
}
function getFunctionReadRecords() {
    return $('#' + getCurrentTbodyID()).data('functionReadRecords');
}
function getCurrentFirstRow() {
    if (getCountRecords() == 0) {
        return 0;
    }
    else {
        return ((page() - 1) * getCountFetch()) + 1;
    }
}
function getCountFetch() {
    return 6;
}
function getSelector(name) {
    var container = '#' + $('#' + getCurrentTbodyID()).closest('div').next('div').attr('id');
    return $('input[name=' + name + ']', container);
}
function page(number) {
    if (number) {
        $('#' + getCurrentTbodyID()).data('Page', number);
    }
    else {
        return $('#' + getCurrentTbodyID()).data('Page');
    }
}
function lastPage(lastPage) {
    if (lastPage) {
        $('#' + getCurrentTbodyID()).data('LastPage', lastPage);
    }
    else {
        return $('#' + getCurrentTbodyID()).data('LastPage');
    }
}
function refereshCurrentGrid() {
    refereshGridWithFirstRow(getCurrentFirstRow());
}
function setText() {
    var countRecords = getCountRecords();
    var countFetch = getCountFetch();
    if (countRecords > 1) {
        var firstRecordInPage = getCurrentFirstRow();
        var lastRecordInPage = 0;
        if (page() == lastPage()) {
            var countInLastPage = (countRecords <= countFetch) ? countRecords : countRecords % countFetch;
            countInLastPage = (countInLastPage == 0) ? countFetch : countInLastPage;
            lastRecordInPage = (countRecords == 0) ? 0 : (firstRecordInPage + countInLastPage) - 1;
        }
        else {
            lastRecordInPage = (countRecords == 0) ? 0 : firstRecordInPage + countFetch - 1;
        }
        $('#TxtPager').val(firstRecordInPage + ' تا ' + lastRecordInPage + ' از ' + countRecords);
    }
    else {
        $('#TxtPager').val('0 رکورد');
    }
}
function setPager() {
    var countFetch = getCountFetch();
    var countRecords = getCountRecords(getCountRecords());
    lastPage(Math.ceil(countRecords / countFetch));
    setStatus(false, false, false, false);
    setText();
}
function btnFirstClick() {
    if (page() > 1) {
        page(1);
        refereshCurrentGrid();
        setStatus(true, true, false, false);
        setText();
    }
}
function btnPreviusClick() {
    var pageNo = page();
    if (pageNo > 1) {
        page(--pageNo);
        refereshCurrentGrid();
        setStatus(true, true, true, true);
        setText();
    }
    else if (pageNo == 1) {
        setStatus(false, false, true, true);
    }
}
function btnNextClick() {
    var countRecords = getCountRecords();
    var pageNo = page();
    var countPages = (countRecords == 0) ? 0 : countRecords / getCountFetch();
    if (pageNo < countPages) {
        page(++pageNo);
        refereshCurrentGrid();
        setStatus(true, true, true, true);
        setText();
    }
    else if (pageNo == countPages) {
        setStatus(false, false, true, true);
    }
}
function btnLastClick() {
    var pageNo = page();
    var lastPageNo = lastPage();
    if (pageNo < lastPageNo) {
        page(lastPageNo);
        refereshCurrentGrid();
        setStatus(false, false, true, true)
        setText();
    }
}
function setStatus(first, previus, last, next) {
    //    getSelector('BtnFirst').attr('disabled', true);
    //    getSelector('BtnLast').attr('disabled', false);
    //    getSelector('BtnPrevius').attr('disabled', true);
    //    getSelector('BtnNext').attr('disabled', false);
}
