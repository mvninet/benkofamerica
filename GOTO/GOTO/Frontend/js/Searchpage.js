function showInput_field() {
    var temp = document.getElementsId("#fromSearch");
    var item = temp.content.querySelector("#mainPage");
    var a = document.importNode(item, true);
    document.body.appendChild(a);

}

function showRouteList() {
    var temp = document.getElementById("routeWrapperTemplate");
    var clon = temp.content.cloneNode(true);
    document.getElementById("routeListWrapper").appendChild(clon);
} 

function createRouteTemplate(route) {

}