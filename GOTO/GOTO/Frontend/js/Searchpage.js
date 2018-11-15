// TEMPLATES //
function showInput_field() {
    var temp = document.getElementById("fromSearch");
    var clon = temp.content.cloneNode(true);
    document.getElementById("SearchFrom").appendChild(clon);

    var temp1 = document.getElementById("toSearch");
    var clon1 = temp1.content.cloneNode(true);
    document.getElementById("SearchTo").appendChild(clon1);

}

function showParcelType() {
    var temp = document.getElementById("ParcelType");
    var clon = temp.content.cloneNode(true);
    document.getElementById("parcelType").appendChild(clon);
}

function showRouteList() {
    var temp = document.getElementById("routeWrapperTemplate");
    var clon = temp.content.cloneNode(true);
    document.getElementById("routeListWrapper").appendChild(clon);
} 

function createRouteTemplate(route) {

}
function initialize() {
    showInput_field();
    showParcelType();
}
