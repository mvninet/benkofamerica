function showReceipt(route) {
    var temp = document.getElementById("succesTemplate");
    var clon = temp.content.cloneNode(true);
    document.getElementById("confirmationPage").appendChild(clon);
    console.log("receipt");

    var routeFrom = document.getElementsByClassName("succesFrom");
    routeFrom[0].textContent = route.from;
    var routeTo = document.getElementsByClassName("succesTo");
    routeTo[0].textContent = route.to;
    var routeTime = document.getElementsByClassName("succesTime");
    routeTime[0].textContent = route.time;
    var routePrice = document.getElementsByClassName("succesPrice");
    routePrice[0].textContent = route.price;




}

function initSucces() {
    var routes = [
        { from:"Denmark", to:"UK", price: 100, time: 12 }
    ];

    showReceipt(routes[0]);
}

