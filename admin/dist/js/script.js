function close() {
    document.getElementById('msg').style.display = "none";
    return false;
}

var url = window.location.pathname + "/delete_data";
function delete_data(username, email) {

    $.ajax({
        type: "POST",
        url: url,
        data: "{username:'" + username + "',email:'" + email + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            var myObject = eval('(' + response.d + ')');
            //   if (myObject > 0)
            {
                //  alert("deleted");
            }
        },
        failure: function (response) {
         //   document.getElementById("first_window").innerHTML = response.d;
           // show_modal("first_window");
        },
        error: function (response) {
         //   document.getElementById("first_window").innerHTML = response.d;
           // show_modal("first_window");
        }
    });
}