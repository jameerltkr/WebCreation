//var userid,websitename;
var url = window.location.pathname + "/delete";
var url2 = window.location.pathname + "/edit";
function delete_data(userid, websitename,username) {

    $.ajax({
        type: "POST",
        url: url,
        data: "{userid:'" + userid + "',websitename:'" + websitename + "',username:'"+username+"'}",
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
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        },
        error: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        }
    });
}
url3 = window.location.pathname + "/show";
function show(userid, username, websitename) {
    $("#hf_website_preview").val(websitename);
    $.ajax({
        type: "POST",
        url: url3,
        data: "{userid:'" + userid + "', username:'" + username + "',websitename:'" + websitename + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            if ((response.d) == "nothing") {
                // show_div();
                // alert(response.d);
                $("#tbl_pages tbody tr").remove();
                $("#website_name a").remove();
                addTextBox(userid, username, websitename);
            }
            else
                if (response.d == "data") {
                    $("#website_div input").remove();
                    $("#website_div div").remove();
                    document.getElementById("tbl_pages").style.display = "block";
                    get_page_name(username, websitename,userid);
                }

            //  alert(response.d);
            //alert("H");
        },
        failure: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        },
        error: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        }
    });
}
//   uncomment below function when create.aspx page will be run

//function run(pagename) {
//    $("#hf_page_name").val(pagename);
//    //document.getElementById('<%= Button1.ClientID %>').click();
//    $("#Button1").click();
//    return false;
//}

function run(pagename, websitename) {
    $("#hf_website_name").val(websitename);
    $("#hf_page_name").val(pagename);
  //  $('#<%= Button1.ClientID %>').click();
    $("#btn_write_page").click();
    return false;
}

function show_div() {
    document.getElementById("div_create_page").style.display = "block";
}
$(document).ready(function () {
    $("#txt_page_name").keydown(function (event) {
        if (event.keyCode == 32) {
            event.preventDefault();
        }
    });
});
function create_div(userid, username, websitename) {

    return '<p id="error" style="color: Red; display: none">* Special Characters not allowed</p><br/>' +
        '<p id="empty_error" style="color:red; display:none;">* Please enter a page name</p><br/>' +
    '<input type="text" id="txt_page_name" placeholder="Page name" onkeypress="return IsAlphaNumeric(event);" ondrop="return false;" onpaste="return false;"/>' +
        '<input type="button" id="btn_create_page" onclick="add_page(\'' + userid + '\',\'' + username + '\',\'' + websitename + '\'); return false;" value="Create Page"/>'
}
function addTextBox(userid, username, websitename) {
    $("#website_div input").remove();
    $("#website_div div").remove();
    var div = document.createElement('div');
    div.innerHTML = create_div(userid, username, websitename);
    document.getElementById("website_div").appendChild(div);
}
function add_page(userid, username, websitename) {
    if (document.getElementById("txt_page_name").value == "") {
        document.getElementById("empty_error").style.display = "inline";
        //document.getElementById("error").value = "Please enter a page name.";
    }
    else {
        document.getElementById("empty_error").style.display = "none";
        document.getElementById("btn_create_page").value = "Creating...";
        var page = document.getElementById("txt_page_name").value;
        var pagename = document.getElementById("txt_page_name").value + ".aspx";
        url_add_page = window.location.pathname + "/add_page";
        $.ajax({
            type: "POST",
            url: url_add_page,
            data: "{userid:'" + userid + "', username: '" + username + "',websitename:'" + websitename + "', pagename: '" + pagename + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "jsondata",
            async: "true",
            success: function (response) {
                if (response.d == "") {
                    alert('An error occurred');
                }
                else
                    if (response.d == "error") {
                        alert('error while inserting');
                    }
                    else
                        if (response.d == "inserted") {

                            run(page, websitename);      //  run the c# method to create page...........

                            document.getElementById("first_window").innerHTML = "Page created successfully.";
                            show_modal("first_window");
                            document.getElementById("btn_create_page").value = "Create Page";
                            document.getElementById("txt_page_name").value = "";
                            document.getElementById("website_div").style.display = "none";

                        }
            },
            failure: function (response) {
                document.getElementById("first_window").innerHTML = response.d;
                show_modal("first_window");
            },
            error: function (response) {
                document.getElementById("first_window").innerHTML = response.d;
                show_modal("first_window");
            }
        });
        show(userid, username, websitename);    //getting websites from db............
    }
}

function nospace() {

}
function alpha(e) {
    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
}
function validate(event) {

    if (!((event.keyCode >= 65) && (event.keyCode <= 90) || (event.keyCode >= 97) && (event.keyCode <= 122) || (event.keyCode >= 48) && (event.keyCode <= 57))) {

        document.getElementById("first_window").innerHTML = "Space is not allowed.";
        show_modal("first_window");
        var value = $("#txt_page_name").val();
        value = value.replaceAll(" ", "");
        $("#txt_page_name").val() = value;
        return false;
    }
    event.returnValue = true;
}
var specialKeys = new Array();
specialKeys.push(8); //Backspace
specialKeys.push(9); //Tab
specialKeys.push(46); //Delete
specialKeys.push(36); //Home
specialKeys.push(35); //End
specialKeys.push(37); //Left
specialKeys.push(39); //Right
function IsAlphaNumeric(e) {
    var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
    var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
    document.getElementById("error").style.display = ret ? "none" : "inline";
    document.getElementById("empty_error").style.display = ret ? "none" : "inline";
    return ret;
}
function check(e) {
    var keynum
    var keychar
    var numcheck
    // For Internet Explorer  
    //if (window.event) {
    //    keynum = e.keyCode
    //}
    //    // For Netscape/Firefox/Opera  
    //else if (e.which) {
    //    keynum = e.which
    //}
    //keychar = String.fromCharCode(keynum)
    ////List of special characters you want to restrict  
    //if (keychar == "'" || keychar == "`") {

    //    return false;
    //}
    //else {
    //    return true;
    //}

    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '32') {
        document.getElementById("first_window").innerHTML = "Space is not allowed.";
        show_modal("first_window");
        return false;
    }

}

//$(document).keypress(function (event) {

//    var keycode = (event.keyCode ? event.keyCode : event.which);
//    if (keycode == '32') {
//        document.getElementById("first_window").innerHTML = "Space is not allowed.";
//        show_modal("first_window");
//        return false;
//    }
//});

function get_page_name(username, websitename,userid) {
    $("#tbl_pages tbody tr").remove();
    $("#website_name a").remove();

    var url_get_page = window.location.pathname + "/getpage";
    $.ajax({
        type: "POST",
        url: url_get_page,
        data: "{username:'" + username + "',websitename:'" + websitename + "',userid:'"+userid+"'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            ($.map(data.d, function (item) {
              //  var url = "\'" + username + "\'" + "/" + "\'" + item.PageName + "\'";
                //$("#website_name").append("<a href='#'>" + item.WebsiteName + "</a>");
                var rows = "<tr>"
                
                + "<td>" + "<a href='#' onclick='edit_page(\"" + username + "\",\"" + websitename + "\",\"" + item.PageName + "\"); return false;' id=" + "\'" + item.PageName + "\'" + " >" + item.PageName + "</a></td>"
                //+ "<td>" + item.WebsiteName + "</td>"
                + "</tr>";
                $('#tbl_pages').append(rows);
            }))
        },
        failure: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        },
        error: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        }
    });
}
function get_websites_name(username) {
    $("#tbl_created_websites tbody tr").remove();
   // $("#website_name a").remove();

    var url_get_page = window.location.pathname + "/getwebsites";
    $.ajax({
        type: "POST",
        url: url_get_page,
        data: "{username:'" + username + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            ($.map(data.d, function (item) {
                //  var url = "\'" + username + "\'" + "/" + "\'" + item.PageName + "\'";
                //$("#website_name").append("<a href='#'>" + item.WebsiteName + "</a>");
                var rows = "<tr>"
                    + "<td>" + item.Name + "</td>"
                + "<td>" + "<a class='btn' title='Edit your application name'><i class='fa fa-edit'></i></a></td>"
                + "<td>" + "<a class='btn' title='Delete your application' onclick='if(confirm(Are you sure you want to delete website?)) delete(" + item.Name + ")'><i class='fa fa-times'></i></a></td>"
                //+ "<td>" + item.WebsiteName + "</td>"
                + "</tr>";
                $('#tbl_created_websites').append(rows);
            }))
        },
        failure: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        },
        error: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        }
    });
}
function edit_page(username, websitename, pagename) {
    //document.getElementById("website_details").Attributes["class"] = "display-none";  // hiding website details page
    //document.getElementById("create_website").Attributes["class"] = "display-block";    // show create website page
    //document.getElementById("create_database").Attributes["class"] = "display-none";   // creatign datavase page  // show
    document.getElementById('website_details').style.display = "none";
    document.getElementById('create_database').style.display = "none";

    document.getElementById('iframe_edit_page').style.display = "block";
    var address = username + "/" + websitename + "/" + pagename;
    var iframe = document.getElementById('iframe_edit_page');
    iframe.src = address;

    //   maximize
    var maximize = document.createElement("input");
    //Set the attributes
    maximize.setAttribute("onclick", "maximize()");
    maximize.setAttribute("type", "button");
    maximize.setAttribute("value", "Maximize");
    maximize.setAttribute("id", "maximize");
    maximize.style.position = "absolute";
    maximize.style.top = "4px";
    maximize.style.right = "15px";
    maximize.style.height = "30px";
    maximize.style.width = "67px";
    document.body.appendChild(maximize);
}

function show_toolbox() {
    $("#div").remove();
    var div = document.createElement('div');
    document.getElementById("toolbox").style.position = "absolute";
    document.getElementById("toolbox").style.height = "550px";
    document.getElementById("toolbox").style.width = "230px";
    div.innerHTML = document.getElementById("toolbox");
    document.body.appendChild(div);
}

function hello() {
    var iframe = document.getElementById('iframe_edit_page');
    //alert(iframe.contentWindow.document.getElementById('lb').val());
    var btn = iframe.contentWindow.document.getElementById('lb');
    alert(btn.val());
}

function maximize() {

    if (document.getElementById('maximize').value == "Close") {
        var iframe = document.getElementById('iframe_edit_page');
        iframe.style.border = "1px groove black";
        iframe.style.position = "static";
        iframe.height = 450;
        iframe.width = 855;
        document.getElementById('maximize').value = "Maximize";
    }
    else
    {
        show_toolbox();
      //  document.getElementById('bd1').style.display = "none";
        var iframe = document.getElementById('iframe_edit_page');
        iframe.style.backgroundColor = "#f3f4f5";
        iframe.style.position = "absolute";
        iframe.style.left = "-20px";
        iframe.style.border = "1px groove black";
        iframe.style.top = "-104px";
        iframe.height = height();
        iframe.width = width() - 10;
        document.getElementById('maximize').value = "Close";
    }

    // hello();
    //Show close button
 //   var close = document.createElement("input");
 //   //Set the attributes
 //   close.setAttribute("onclick", "close()");
 //   close.setAttribute("type", "button");
 //   close.setAttribute("value", "Close");
 ////   close.style.position = "absolute";
 //  // close.style.top = "-114px";
 //   //close.style.right = "0pxx";
 //   close.style.height = "49px";
 //   close.style.width = "200px";
 //   document.body.appendChild(close);

}

function close() {

}

function height() {
    var viewportHeight;
    if (document.compatMode === 'BackCompat') {
        viewportHeight = document.body.clientHeight;
    } else {
        viewportHeight = document.documentElement.clientHeight;
    }
    return viewportHeight;
}
function width() {
    var viewportWidth;
    if (document.compatMode === 'BackCompat') {
        viewportWidth = document.body.clientWidth;
    } else {
        viewportWidth = document.documentElement.clientWidth;
    }
    return viewportWidth;
}
function close_modal() {

    //hide the mask  
    $('#mask').fadeOut(500);

    //hide modal window(s)  
    $('.modal_window').fadeOut(500);

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
        },
        failure: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        },
        error: function (response) {
            document.getElementById("first_window").innerHTML = response.d;
            show_modal("first_window");
        }
    });
}


//function Hello() {
//    var userid = document.getElementById('<%=userid %>').value;
//    PageMethods.Print(onSuccess, onError);
//    function onSucess(result) {
//        alert(result);
//    }
//    function onError(result) {
//        alert('Something wrong.');
//    }
//}