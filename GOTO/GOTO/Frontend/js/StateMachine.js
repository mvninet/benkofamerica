
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
function GetCurrentPage() {
    return currentPage;
}

function ShowMainPage() {
    hideAllPages();
    $("#mainPage").show();
    currentPage = 0;
}

function ShowResultPage() {
    hideAllPages();
    insertOverviewRoutes();
    $("#resultPage").show();
    currentPage = 1;
}

function ShowPaymentPage() {
    hideAllPages();
    $("#paymentPage").show();
    insertPaymentinfomation();
    inserttos();
    insertOverviewPayment();
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

