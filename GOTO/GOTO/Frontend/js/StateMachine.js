
// State Machine - The current page showing
// 0 = MainPage
// 1 = ResultPage
// 2 = PaymentPage
// 3 = ConfirmationPage
var currentPage = 0;


function init() {
    ShowMainPage();
    //Search();
}

// PUBLIC FUNCTIONS //
function GetCurrentPage() {
    return currentPage;
}

function ShowMainPage() {
    hideAllPages();
    $("#mainPage").show();
    currentPage = 0;
    setProgressBar();
}

function GetReadyToSearch() {
    Search();
    $("#mainPage").fadeOut(1000);

    setTimeout(function () {
        showResultPage();
    }, 1000);
}

function ShowPaymentPage(route) {
    hideAllPages();
    $("#paymentPage").show();
    insertPaymentinfomation("paymentwrapper");
    currentPage = 2;
    setProgressBar();
}

function ShowConfirmationPage() {
    hideAllPages();
    $("#confirmationPage").show();
    currentPage = 3;
    setProgressBar();
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
    $("#progressbarWrapper li").removeClass("active");
}

function setProgressBar() {
    var currentPage = GetCurrentPage();
    for (i = 0; i < GetCurrentPage(); i++) {
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