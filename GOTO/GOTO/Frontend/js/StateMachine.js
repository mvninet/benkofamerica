
// State Machine - The current page showing
// 0 = MainPage
// 1 = ResultPage
// 2 = PaymentPage
// 3 = ConfirmationPage
var currentPage = 0;
var routeparametersglobal = "";

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

function GetReadyToSearch() {
    var routeParams = checkAll();

    if (routeParams !== false) {
        routeparametersglobal = routeParams;
        Search();
        $("#mainPage").fadeOut(1000);
        insertOverviewRoutes(routeparametersglobal);
        setTimeout(function () {
            showResultPage();
        }, 1000);
    }
}

function GetReadyForReceipt() {
    $("#paymentPage").fadeOut(750);

    setTimeout(function () {
        ShowConfirmationPage();
    }, 1000);
}

function ShowPaymentPage(route) {

    var routeParams = checkAll();
    if (routeParams !== "") {
        hideAllPages();
        $("#paymentPage").fadeIn(750);
        insertPaymentinfomation();
        inserttos();
        insertOverviewPayment(routeParams);
        currentPage = 2;
        setProgressBar();
    }
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