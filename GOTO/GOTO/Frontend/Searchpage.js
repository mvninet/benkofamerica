function showInput_field() {
    var temp = document.getElementsId("#fromSearch");
    var item = temp.content.querySelector("#mainPage");
    var a = document.importNode(item, true);
    document.body.appendChild(a);

}