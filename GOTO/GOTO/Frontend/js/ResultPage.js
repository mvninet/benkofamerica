function chooseRoute(element) {
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

    setTimeout(routesFound, 2000);
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
    var headerIcon = clone.querySelectorAll("#iconResult");
    
    if (route.isFastest) {
        var IconPic = "/Frontend/Images/rabbit-light.svg";
        header[0].textContent = "Fastest";
        headerIcon[0].setAttribute("src", IconPic);
    } else if (route.isCheapest) {
        var IconPic1 = "/Frontend/Images/dollar-sign-solid.svg";
        header[0].textContent = "Cheapest";
        headerIcon[0].setAttribute("src", IconPic1);
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

function insertOverviewRoutes() {
    var temp = document.getElementById("routeOverviewTemplate");
    var clone = temp.content.cloneNode(true);

    document.getElementById("routeOverviewWrapper").innerHTML = "";
    document.getElementById("routeOverviewWrapper").appendChild(clone);
}