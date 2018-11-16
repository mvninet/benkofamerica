function insertPaymentinfomation() {
    var temp = document.getElementById("paymentTemplate");
    var clone = temp.content.cloneNode(true);

    document.getElementById("paymentwrapper").innerHTML = "";
    document.getElementById("paymentwrapper").appendChild(clone);
}

function inserttos() {
    var temp = document.getElementById("tosTemplste");
    var clone = temp.content.cloneNode(true);

    document.getElementById("tos").innerHTML = "";
    document.getElementById("tos").appendChild(clone);
}

function insertOverviewPayment() {
    var temp = document.getElementById("paymentOverviewTemplate");
    var clone = temp.content.cloneNode(true);

    document.getElementById("paymentOverviewWrappper").innerHTML = "";
    document.getElementById("paymentOverviewWrappper").appendChild(clone);
}