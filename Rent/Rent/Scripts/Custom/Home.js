$(document).ready(function () {



    //$('#ddlcity').selectpicker({});
    $('#ddlproperty').selectpicker({});
    //$.get($_GetState, function (data) {

    //    $.each(data, function (i, item) {
    //        $("#ddlstate").append("<option value=" + item.StateId + ">" + item.StateName+"</option>")

    //    });
    //    $('#ddlstate').selectpicker({});
    //});

    //$("#ddlstate").change(function () {
    //    var url = $_GetCities + "?StateId=" + $(this).val();
    //    $.get(url, function (data) {
    //        $("#ddlcity").empty();
    //        $.each(data, function (i, item) {
    //            $("#ddlcity").append("<option value=" + item.CityId + ">" + item.CityName + "</option>")
    //        });
    //        $('#ddlcity').selectpicker('refresh');
    //    });
    //});
   
    $.get($_GetProperty, function (data) {
        $.each(data, function (i, item) {
            $("#ddlproperty").append("<option value=" + item.PropertyTypeId + ">" + item.PropertyTypeName + "</option>")
            
        });
        $('#ddlproperty').selectpicker('refresh');
    });


    $("#frmsearch").validate({
        // Specify validation rules
        rules: {
            Locality: {
                required: true
            },
        },
        // Specify validation error messages
        messages: {
            Locality: "Please enter locality"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid

        showErrors: function (errorMap, errorList) {

            // Clean up any tooltips for valid elements
            $.each(this.validElements(), function (index, element) {
                var $element = $(element);

                $element.data("title", "") // Clear the title - there is no error associated anymore
                    .removeClass("error")
                    .tooltip("destroy");
            });

            // Create new tooltips for invalid elements
            $.each(errorList, function (index, error) {
                var $element = $(error.element);

                $element.tooltip("destroy") // Destroy any pre-existing tooltip so we can repopulate with new tooltip content
                    .data("title", error.message)
                    .addClass("error")
                    .tooltip(); // Create a new tooltip based on the error messsage we just set in the title
            });
        },
        submitHandler: function (form, e) {
            debugger;
            form.submit();
          
        }
    });
});





