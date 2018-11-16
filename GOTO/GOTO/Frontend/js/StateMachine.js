
// State Machine - The current page showing
// 0 = MainPage
// 1 = ResultPage
// 2 = PaymentPage
// 3 = ConfirmationPage
// 4 = mapPage
var currentPage = 0;

function init() {
    ShowMainPage();
    //Search();
}

// PUBLIC FUNCTIONS //
function GetCurrentPage() {
    return currentPage;
}

function ShowMainPage(clearPage = false) {
    hideAllPages();
    $("#mainPage").show();
    currentPage = 0;
    setProgressBar();
    if (clearPage) {
        $("#fromSearch").val("");
        $("#toSearch").val("");
        //TODO RESET THE REST //
    }
}

function closeMap() {
    ShowMainPage();
    $("#mapPage").hide();
}
function openMap() {
    hideAllPages();
    $("#mapPage").show();
}

function GetReadyToSearch() {
    Search();
    $("#mainPage").fadeOut(1000);
    insertOverviewRoutes();
    setTimeout(function () {
        showResultPage();
        console.log("t");
    }, 1000);
}

function GetReadyForReceipt() {
    $("#paymentPage").fadeOut(750);

    setTimeout(function () {
        ShowConfirmationPage();
    }, 1000);
}

function ShowPaymentPage(route) {
    hideAllPages();
    $("#paymentPage").fadeIn(750);
    insertPaymentinfomation();
    inserttos();
    insertOverviewPayment();
    currentPage = 2;
    setProgressBar();
}

function ShowConfirmationPage() {
    hideAllPages();
    $("#confirmationPage").fadeIn(750);
    currentPage = 3;
    setProgressBar();
}

// PRIVATE FUNCTIONS //
function hideAllPages() {
    $(".navigationPage").hide();
    $("#loadingScreen").hide();
    $("#mapPage").hide();
    $("#progressbarWrapper li").removeClass("active");
}

function setProgressBar() {
    var currentPage = GetCurrentPage();
    for (i = 0; i <= GetCurrentPage(); i++) {
        $("#progressbarWrapper li").eq(i).addClass("active");
    }
}

function showResultPage() {
    hideAllPages();
    $("#resultPage").fadeIn(500);
    currentPage = 1;
    setProgressBar();
}

function insertPaymentinfomation(parent) {
    var temp = document.getElementById("paymentTemplate");
    console.log(temp);
    var clone = temp.content.cloneNode(true);
    document.getElementById(parent).appendChild(clone);
}