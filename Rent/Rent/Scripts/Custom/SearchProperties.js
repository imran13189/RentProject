var pagenumber = 1;

function GetProperties(pagelink) {
    debugger;
    var params = GetPrams();
    $.post($_SearchProperties, params, function (result) {
      
        if ($("#searchproperties .section").length>2)
            $("#searchproperties .section").slice(-2).remove();

        $('#searchproperties').append(result);
        InitPaging();
    });
}

function InitPaging() {
    $(".pagelink").click(function () {
        pagenumber = $(this).attr('value');
        GetProperties();
    });
}

function GetPrams() {
   var params = {
        PageSize: 3,
        PageNumber: pagenumber ,
        Locality: $("#Locality").val(),
        PropertyTypeId: $("#ddlproperty").val(),
        'PriceRange[]': $('#price-range').data('slider').getValue() 
        //Locality: $("#Locality").val(),
        //Locality: $("#Locality").val(),
        //Locality: $("#Locality").val(),

    }
    return params;
}
$(document).ready(function () {
    $('#price-range').slider();
    GetProperties();

    $('#ddlproperty').selectpicker({});
    $.get($_GetProperty, function (data) {
        $.each(data, function (i, item) {
            $("#ddlproperty").append("<option value=" + item.PropertyTypeId + ">" + item.PropertyTypeName + "</option>")
        });
        $('#ddlproperty').selectpicker('refresh');
    });

    $('#btnsearch').click(function (e) {
        e.preventDefault();
        GetProperties();
        //var params = { PageSize: 10, PageNumber:1}
        //$.get($_SearchProperties, params, function (result) {

        //    if ($("#searchproperties .section").length > 2)
        //        $("#searchproperties .section").slice(-2).remove();

        //    $('#searchproperties').append(result);
        //    InitPaging();
        //});
    });
});