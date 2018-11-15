function showReceipt() {
    var temp = document.getElementById("succesTemplate");
    var clon = temp.content.cloneNode(true);
    document.getElementById("confirmationPage").appendChild(clon);
}

function initSucces() {
    showReceipt();
}