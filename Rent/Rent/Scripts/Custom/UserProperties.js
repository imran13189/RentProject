function GetProperties() {
    $.get($_GetUserProperties, { UserId: $("#userId").val() }, function (result) {
        debugger;
       
        var data = $('#userproperties').append(result);
     
    });
}

$(document).ready(function () {

    GetProperties();
});