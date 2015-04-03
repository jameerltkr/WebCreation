function add_anchor() {
    //    alert('Hi');
    var anchor = create_anchor();
    document.getElementById('body').appendChild(anchor);

}
function create_anchor() {
    return '<a href="a1">Link1</a>'
}

