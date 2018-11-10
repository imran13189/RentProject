$(document).ready(function () {

    $.get($_GetProperties, { UserId: $("#userId").val() }, function (result) {
        var rentproperties = jQuery.parseJSON(result);
        $('#serverTemplate').tmpl(rentproperties).appendTo('#list-type');
    });

});