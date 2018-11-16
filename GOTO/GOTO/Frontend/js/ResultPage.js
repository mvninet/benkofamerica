function chooseRoute(element) {
    var route = JSON.parse($(element).attr("data-route"));
    element.className += " routeClicked";
    
    setTimeout(function () {
        $("#resultPage").fadeOut(750);
        setTimeout(function () {
            ShowPaymentPage(route);
        }, 1000);
    }, 1250);

}

function Search(routeparametersglobal) {
    // SEARCH IN API //
    $(".routeWrapper").remove();
    createRouteListWhileSearching();

    $.post("/Home/getRoutes", {
        weight: routeparametersglobal.Weight,
        type: routeparametersglobal.Type,
        height: routeparametersglobal.Height,
        width: routeparametersglobal.Width,
        depth: routeparametersglobal.Depth,
        from: routeparametersglobal.From,
        to: routeparametersglobal.To
    }, function (data) {
        selectedRoute = JSON.parse(data);
        console.log("Return: " + selectedRoute);
        var routes = [];

        for (i = 0; i < selectedRoute.length; i++) {
            var route = {};
            var price = 0;
            var time = 0;
            selectedRoute[i].forEach(function (x) {
                price += x.Price;
                time += x.Time;
            });
            route.from = selectedRoute[i][0].FromCity;
            route.to = selectedRoute[i][selectedRoute[i].length-1].ToCity;
            route.price = price;
            route.time = time;
            routes.push(route);
        }
        routesFound(routes);
    });

}

function createRouteListWhileSearching() {
    for (i = 0; i < 2; i++) {
       createSearchingRouteTemplate();
    }
}

function routesFound(routes) {
    var fadeoutTime = 750;
    $(".routeWrapper").each(function (index) {
        $(this).fadeOut(fadeoutTime, function () { $(this).remove(); });
    });

    setTimeout(function () {
        createRoutesInList(routes);
    }, fadeoutTime);
}

function createRoutesInList(routes) {
    console.log("Routes: " + routes);
    if (routes.length > 0) {
        var fastestRoute = routes.reduce(function (prev, current) {
            return (prev.time < current.time) ? prev : current;
        })
        fastestRoute.isFastest = true;
        var cheapestRoute = routes.reduce(function (prev, current) {
            return (prev.price < current.price) ? prev : current;
        })
        cheapestRoute.isCheapest = true;

        for (i = 0; i < routes.length; i++) {
            createRouteTemplate(routes[i]);
        }
    } else {
        noRoutesFound();
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

function noRoutesFound() {
    var routeListWrapper = document.querySelector("#routeListWrapper");
    var routeWrapperTemplate = document.querySelector("#noRoutesFoundTemplate");
    var clone = document.importNode(routeWrapperTemplate.content, true);

    routeListWrapper.appendChild(clone);
}

function insertOverviewRoutes(params) {
    var temp = document.getElementById("routeOverviewTemplate");
    var clone = temp.content.cloneNode(true);

    document.getElementById("routeOverviewWrapper").innerHTML = "";
    document.getElementById("routeOverviewWrapper").appendChild(clone);

    console.log($("#routeFrom"));

    var span1 = document.getElementById("routeFrom");
    span1.textContent = params.From;
    var span2 = document.getElementById("routeTo");
    span2.textContent = params.To;
    
}