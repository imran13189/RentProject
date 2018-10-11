$(document).ready(function () {



    $('#ddlcity').selectpicker({
    });

    $.get($_GetState, function (data) {

        $.each(data, function (i, item) {
            $("#ddlstate").append("<option value=" + item.StateId + ">" + item.StateName+"</option>")

        });
        $('#ddlstate').selectpicker({
        });
    });

    $("#ddlstate").change(function () {
        var url = $_GetCities + "?StateId=" + $(this).val();
        $.get(url, function (data) {
            $("#ddlcity").empty();
            $.each(data, function (i, item) {
                $("#ddlcity").append("<option value=" + item.CityId + ">" + item.CityName + "</option>")
            });
            $('#ddlcity').selectpicker('refresh');
        });
    });
   
    $.get($_GetProperty, function (data) {
        $.each(data, function (i, item) {
            $("#ddlproperty").append("<option value=" + item.PropertyTypeId + ">" + item.PropertyTypeName + "</option>")
            
        });
        $('.selectpicker').selectpicker({
        });
    });


    $("#frmpropertyrent").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            PropertyName: {
                required: true

            }
           
        },
        // Specify validation error messages
        messages: {
            Name: "Please enter your full name",
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form, e) {
           

            //var formData = new FormData(form1[0]);
            var usermodel = JSON.parse(JSON.stringify($(form).serializeArray()));
            //var files = $("#propertyimages").get(0).files;  
            //for (var i = 0; i < files.length; i++) {
            //    var file = files[i];

            //    // Check the file type.
            //    if (!file.type.match('image.*')) {
            //        continue;
            //    }

            //    // Add the file to the request.
            //    formData.append('Photos', file, file.name);
               
               
            //}
            debugger;

            
            $.ajax({
                type: "POST",
                url: $_SaveProperty,
                data: usermodel,
                success: function (data) {
                    debugger;
                    window.location.href = "Property/PropertyFiles?PropertyId="+data.PropertyId;
                    //window.open($_Login + "?Email=" + usermodel[1].value + "&Password=" + usermodel[3].value+"&RoleId="+2);
                }
            });
        }
    });
});





