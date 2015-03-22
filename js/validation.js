function UpdateUserValidation() {
    var valid = true;
    
    if ($("#Tname").val() == "") {
        $("#error_name").html("Name Required");
        //$("#Tname").css({ "border": "1px groove red" });
        valid = false;
    }
    else {
        $("#error_name").html("");
    }

    if ($("#Temail").val() == "") {
        $("#error_email").html("Email Required");

        valid = false;
    }
    else {
        $("#error_email").html("");
    }


    if ($("#Tpassword").val() == "") {
        $("#error_password").html("Password Required");
        valid = false;
    }
    else {
        $("#error_password").html("");
    }

    if ($("#Tconfirmpassword").val() == "") {
        $("#error_conf_pass").html("Confirm Password Required");
        valid = false;
    }
    else {
        $("#error_conf_pass").html("");
    }


    if ($("#TAnswer").val() == "") {
        $("#error_security_ans").html("Security Answer Required");
        valid = false;
    }
    else {
        $("#error_security_ans").html("");
    }

    if ($("#Tdob").val() == "") {
        $("#error_dob").html("Date of Birth Required");
        valid = false;
    }
    else {
        $("#error_dob").html("");
    }
    if ($("#Tmobile").val() == "") {
        $("#error_mobile").html("Mobile Number Required");
        valid = false;
    }
    else {
        $("#error_mobile").html("");
    }


    if ($("#Tcity").val() == "") {
        $("#error_city").html("City Required");
        valid = false;
    }
    else {
        $("#error_city").html("");
    }

    if ($("#Taddress").val() == "") {
        $("#error_address").html("Address Required");
        valid = false;
    }
    else {
        $("#error_address").html("");
    }



    if ($("#Temail").val() !== "") {
        if (isValidEmailAddress($("#Temail").val())) {
            $("#error_email").html("");
        }
        else {
            $("#error_email").html("Email is not valid");
            valid = false;
        }
    }


    if ($("#Tmobile").val() !== "") {
        if (isValidMobile($("#Tmobile").val())) {
            $("#error_mobile").html("");
        }
        else {
            $("#error_mobile").html("Mobile Number is not valid");
            valid = false;
        }
    }

    if (!valid) {
        return false;
    }
    else { return true; }
}


function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/);
    // alert( pattern.test(emailAddress) );
    return pattern.test(emailAddress);
};

function isValidMobile(Mobile) {
    var pattern = new RegExp(/^\d+(-\d+)*$/);
    // alert( pattern.test(emailAddress) );
    return pattern.test(Mobile);
};



function LoginValidation() {
    var valid = true;

    if ($("#TextBox1").val() == "") {
        $("#error_email").html("Email Required");
        valid = false;
    }
    else {
        $("#error_email").html("");
    }
    if ($("#TextBox2").val() == "") {
        $("#error_password").html("Password Required");
        valid = false;
    }
    else {
        $("#error_password").html("");
    }
    if ($("#TextBox1").val() !== "") {
        if (isValidEmailAddress($("#TextBox1").val())) {
            $("#error_email").html("");
        }
        else {
            $("#error_email").html("Email is not valid");
            valid = false;
        }
    }



    if (!valid) {
        return false;
    }
    else { return true; }
}