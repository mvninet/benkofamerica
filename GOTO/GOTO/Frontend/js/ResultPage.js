﻿function chooseRoute(element) {
    var route = JSON.parse($(element).attr("data-route"));
    element.className += " routeClicked";
    var timeoutTime = 500;

    setTimeout(function () {
        $(".routeWrapper").each(function (index) {
            $(this).fadeOut(timeoutTime, function () { $(this).remove(); });
        });

        setTimeout(function () {
           ShowPaymentPage(route);
        }, 900);
    }, 1000);

}

function Search() {
    // SEARCH IN API //
    console.log("SEARCH");
    createRouteListWhileSearching();
}

function getPopulatedRoutes() {
    return [
        { price: 100, time: 12 },
        { price: 200, time: 6 }
    ];
}

function createRouteListWhileSearching() {
    for (i = 0; i < 2; i++) {
       createSearchingRouteTemplate();
    }

    setTimeout(routesFound, 5000);
}

function routesFound() {
    var fadeoutTime = 750;
    $(".routeWrapper").each(function (index) {
        $(this).fadeOut(fadeoutTime, function () { $(this).remove(); });
    });

    setTimeout(function () {
        var dummyData = getPopulatedRoutes();
        createRoutesInList(dummyData);
    }, fadeoutTime);
}

function createRoutesInList(routes) {
    const fastestRoute = routes.reduce(function (prev, current) {
        return (prev.time < current.time) ? prev : current
    })
    fastestRoute.isFastest = true;
    const cheapestRoute = routes.reduce(function (prev, current) {
        return (prev.price < current.price) ? prev : current
    })
    cheapestRoute.isCheapest = true;
    
    for (i = 0; i < routes.length; i++) {
        createRouteTemplate(routes[i]);
    }
}

function createRouteTemplate(route) {
    var routeListWrapper = document.querySelector("#routeListWrapper");
    var routeWrapperTemplate = document.querySelector("#routeWrapperTemplate");
    var clone = document.importNode(routeWrapperTemplate.content, true);

    var header = clone.querySelectorAll("h2");
    if (route.isFastest) {
        header[0].textContent = "Fastest";        
    } else if (route.isCheapest) {
        header[0].textContent = "Cheapest";
    }

    var routeTime = clone.querySelectorAll(".routeTime");
    routeTime[0].textContent = route.time;
    var routePrice = clone.querySelectorAll(".routePrice");
    routePrice[0].textContent = route.price;

    var routeWrapper = clone.querySelectorAll(".routeWrapper");
    routeWrapper[0].setAttribute('data-route', JSON.stringify(route));
    
  
    routeListWrapper.appendChild(clone);
}

function createSearchingRouteTemplate() {
    var routeListWrapper = document.querySelector("#routeListWrapper");
    var routeWrapperTemplate = document.querySelector("#searchingRouteWrapperTemplate");
    var clone = document.importNode(routeWrapperTemplate.content, true);

    routeListWrapper.appendChild(clone);
}