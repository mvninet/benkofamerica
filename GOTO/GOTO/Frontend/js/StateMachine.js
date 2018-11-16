
// State Machine - The current page showing
// 0 = MainPage
// 1 = ResultPage
// 2 = PaymentPage
// 3 = ConfirmationPage
var currentPage = 0;


function init() {
    //ShowMainPage();
    Search();
}

// PUBLIC FUNCTIONS //
function GetCurrentPage() {
    return currentPage;
}

function ShowMainPage() {
    hideAllPages();
    $("#mainPage").show();
    currentPage = 0;
}

function Search() {
    showResultPage();
}

function ShowPaymentPage(route) {
    hideAllPages();
    $("#paymentPage").show();
    insertPaymentinfomation("paymentwrapper");
    currentPage = 2;
}

function ShowConfirmationPage() {
    hideAllPages();
    $("#confirmationPage").show();
    currentPage = 3;
}

function ShowLoadingScreen(_show) {
    if (_show) {
        $("#loadingScreen").show();
    } else {
        $("#loadingScreen").hide();
    }
}


// PRIVATE FUNCTIONS //
function hideAllPages() {
    $(".navigationPage").hide();
    $("#loadingScreen").hide();
}

function showResultPage() {
    hideAllPages();
    $("#resultPage").show();
    currentPage = 1;
    createRouteListWhileSearching();

}

function insertPaymentinfomation(parent) {
    var temp = document.getElementById("paymentTemplate");
    console.log(temp);
    var clone = temp.content.cloneNode(true);
    document.getElementById(parent).appendChild(clone);
}