var runCreditCard = function () {
    var value = $("#creditcard").val();
    isCreditCardValid(value);
};

var isCreditCardValid = function (input) {
    var saniInput = input.replace(/-/g, " ");
    var regex = /[0-9]{4} {0,1}[0-9]{4} {0,1}[0-9]{4} {0,1}[0-9]{4}/;
    var noIlligalChars = regex.test(saniInput);
    var rightLength = (saniInput.length === 19);
    return noIlligalChars && rightLength ? true : false;
};


$(document).ready(function () {
    console.log(isCreditCardValid("1234-1234-1234-1234"));
});