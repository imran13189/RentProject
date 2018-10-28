$(document).ready(function () {

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmlogin").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side

            Email: {
                required: true,
                // Specify that email should be validated
                // by the built-in "email" rule
                email: true
            },
            Password: {
                required: true,
                minlength: 5
            }
        },
        // Specify validation error messages
        messages: {
            //firstname: "Please enter your firstname",
            //lastname: "Please enter your lastname",
            Password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            Email: "Please enter a valid email address"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            debugger;
            ee.preventDefault();
            debugger;
            var usermodel = JSON.parse(JSON.stringify($(form).serializeArray()));
            Login(usermodel);
        }
    });


    $("#formregister").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Name: {
                required: true
               
            },
            Email: {
                required: true,
                // Specify that email should be validated
                // by the built-in "email" rule
                email: true,
                remote: {
                    url: $_IsEmailExist,
                    type: "get"
                }
            },
            Mobile: {
                matches: "[0-9]+",  // <-- no such method called "matches"!
                minlength: 10,
                maxlength: 10,
                remote: {
                    url: $_IsMobileExist,
                    type: "get"
                }
            },
            Password: {
                required: true,
                minlength: 5
            },
            
        },
        // Specify validation error messages
        messages: {
            Name: "Please enter your full name",
            //lastname: "Please enter your lastname",
            Password: {
                required: "Please provide a password",
                maxlength: "Your password must be at least 5 characters long"
            },
            Email: {
                required: "Please enter a valid email address",
                remote: "Email already in use!"
            },
            Mobile: {
                maxlength: "Enter 10 digit mobile number",
                minlength: "Enter 10 digit mobile number",
                remote:"Mobile already exist"
            }
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form, e) {
            debugger;
            e.preventDefault();
            debugger;
            var usermodel = JSON.parse(JSON.stringify($(form).serializeArray()));
            $.ajax({
                type: "POST",
                url: $_AddUser,
                data: usermodel,
                success: function (data) {
                    debugger;
                    Login(usermodel);
                    //window.open($_Login + "?Email=" + usermodel[1].value + "&Password=" + usermodel[3].value+"&RoleId="+2);
                }
            });
        }
    });


 

    function Login(usermodel) {
        $.ajax({
            type: "POST",
            url: $_Login,
            data: usermodel,
            success: function (data) {
                if (data) {
                    location.href = "/";
                }
                else {
                    location.href = "/Account/Login";
                }
            }
        });
    }



});