﻿function showRouteList() {

    var routes = [
        { price: 100, time: 12 },
        { price: 200, time: 6 }
    ];

    //foreach(route in routes) {
    createRouteTemplate(routes[0]);
    createRouteTemplate(routes[1]);
    //}
}

function createRouteTemplate(route) {
    var routeListWrapper = document.querySelector("#routeListWrapper");
    var routeWrapperTemplate = document.querySelector("#routeWrapperTemplate");
    var clone = document.importNode(routeWrapperTemplate.content, true);

    var header = clone.querySelectorAll("h2");
    if (route.isFastest) {
        header[0].textContent = "Fastest";        
    } else if (route.isQuickest) {
        header[0].textContent = "Quickest";
    }

    var routeTime = clone.querySelectorAll(".routeTime");
    routeTime[0].textContent = route.time;
    var routePrice = clone.querySelectorAll(".routePrice");
    routePrice[0].textContent = route.price;
  
    routeListWrapper.appendChild(clone);
}

function insertOverviewRoutes() {
    var temp = document.getElementById("routeOverviewTemplate");
    var clone = temp.content.cloneNode(true);

    document.getElementById("routeOverviewWrapper").innerHTML = "";
    document.getElementById("routeOverviewWrapper").appendChild(clone);
}