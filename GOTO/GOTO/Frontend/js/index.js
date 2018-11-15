
// State Machine - The current page showing
// 0 = MainPage
// 1 = ResultPage
// 2 = PaymentPage
// 3 = ConfirmationPage
var currentPage = 0;


function init() {
    ShowMainPage();
console.log("init");
}

// PUBLIC FUNCTIONS //
function ShowMainPage() {
hideAllPages();
$("#mainPage").show();
    currentPage = 0;
    showInput_field();
    showParcelType();
}

function ShowResultPage() {
hideAllPages();
$("#resultPage").show();
currentPage = 1;
}

function ShowPaymentPage() {
hideAllPages();
$("#paymentPage").show();
currentPage = 2;
}

function ShowConfirmationPage() {
hideAllPages();
$("#confirmationPage").show();
currentPage = 3;
}


// FOR TEMPLATES //
function showInput_field() {
    var temp = document.getElementById("fromSearch");
    var clon = temp.content.cloneNode(true);
    document.body.appendChild(clon);

    var temp1 = document.getElementById("toSearch");
    var clon1 = temp1.content.cloneNode(true);
    document.body.appendChild(clon1);

}

function showParcelType() {
    var temp = document.getElementById("ParcelType");
    var clon = temp.content.cloneNode(true);
    document.body.appendChild(clon);
}


// PRIVATE FUNCTIONS //
function hideAllPages() {
$("#mainPage").hide();
$("#resultPage").hide();
$("#paymentPage").hide();
$("#confirmationPage").hide();
}