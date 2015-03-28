//var userid,websitename;
var url = window.location.pathname + "/delete";
var url2 = window.location.pathname + "/edit";
function delete_data(userid, websitename) {

    $.ajax({
        type: "POST",
        url: url,
        data: "{userid:'" + userid + "',websitename:'" + websitename + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            var myObject = eval('(' + response.d + ')');
         //   if (myObject > 0)
            {
              //  alert("deleted");
            }
        }
    });
}
url3 = window.location.pathname + "/show";
function show(username, websitename) {
    $.ajax({
        type: "POST",
        url: url3,
        data: "{username:'" + username + "',websitename:'" + websitename + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            //alert("H");
        }
    });
}

function edit_data(userid, websitename) {
    document.getElementById('txt_rename_website').value = websitename;
    $.ajax({
        type: "POST",
        url: url2,
        data: "{userid:'" + userid + "',websitename:'" + websitename + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            var myObject = eval('(' + response.d + ')');
            //   if (myObject > 0)
            {
                //  alert("deleted");
            }
        }
    });
}


function Hello() {
    var userid = document.getElementById('<%=userid %>').value;
    PageMethods.Print(onSuccess, onError);
    function onSucess(result) {
        alert(result);
    }
    function onError(result) {
        alert('Something wrong.');
    }
}