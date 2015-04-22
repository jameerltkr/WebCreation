function add_anchor() {
    //    alert('Hi');
    var iframe = document.getElementById('iframe_edit_page');
    var anchor = create_anchor();
    // iframe.contentWindow.document.getElementById('body').appendChild(anchor);

    document.getElementById('iframe_edit_page').contentWindow.document.getElementById('body').innerHtml = anchor;

}
function create_anchor() {
    return '<a href="a1">Link1</a>'
}



