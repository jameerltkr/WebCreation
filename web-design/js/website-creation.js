//   below function are being used to generate the asp.net button click event when user wants to edit database
function edit_database(databaseid) {
    $("#hf_db_id").val(databaseid);
    $("#btn_edit_db").click();
  //  return false;
}
//  end of click event generation function
function delete_db(databaseid) {
    var url = window.location.pathname + "/delete_database";
    $.ajax({
        type: "POST",
        url: url,
        data: "{databaseid:'" + databaseid + "'}",
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

function manage_tables(databaseid) {
    //  alert('jk');
    $("#hf_db_id_for_tbl").val(databaseid);
    $("#btn_manage_tables").click();
}





