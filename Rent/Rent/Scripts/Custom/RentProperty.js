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
            },
            CityId: {
                required: true
            },
            Locality: {
                required: true
            },
            PropertyType: {
                required: true
            },
            Mobile: {
                required: true,
                number: true
            },
            Area: {
                required: true,
                number: true
            }
            ,
            ExpectedPrice:
            {
                required: true,
                number: true
            },
            aggreement:
            {
                required: true
            }

        },
        // Specify validation error messages
        messages: {
            PropertyName: "Please enter property name",
            CityId: "Please select city",
            Locality: "Please enter locality",
            PropertyType: "Please select property type",
            Mobile: {
                required: "Please enter valid mobile number",
                    number: "Enter number only"
            },
            Area: {
                required: "Please enter area",
                number: "Enter numeric value only"
            },
            ExpectedPrice: {
                required: "Please enter expected price for property",
                number:"Decimal Numbers Only"
                }
            
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form, e) {
           

            //var formData = new FormData(form1[0]);
            var usermodel = JSON.parse(JSON.stringify($(form).serializeArray()));
           
            debugger;

            
            $.ajax({
                type: "POST",
                url: $_SaveProperty,
                data: usermodel,
                success: function (data) {
                    debugger;
                    window.location.href = $_SavePropertyFile+"?PropertyId="+data.PropertyId;
                    //window.open($_Login + "?Email=" + usermodel[1].value + "&Password=" + usermodel[3].value+"&RoleId="+2);
                }
            });
        }
    });
});





