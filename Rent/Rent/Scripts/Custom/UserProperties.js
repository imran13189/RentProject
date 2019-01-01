function GetProperties(pagelink) {
    var params = { UserId: $("#userId").val(), PageSize: 1, PageNumber: $(".pagelink").length == 0 ? 1 : $(pagelink).attr('value') }
    $.get($_GetUserProperties, params, function (result) {
      
        if ($("#userproperties .section").length>2)
            $("#userproperties .section").slice(-2).remove();

        $('#userproperties').append(result);
        InitPaging();
    });
}

function InitPaging() {
    $(".pagelink").click(function () {
        GetProperties(this);
    });
}

$(document).ready(function () {
    GetProperties();
});