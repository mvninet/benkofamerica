var runCreditCard = function () {
    var value = $("#creditcard").val();
    isCreditCardValid(value);
};

var isCreditCardValid = function (input) {
    var saniInput = input.value.replace(/-/g, " ");
    var regex = /[0-9]{4} {0,1}[0-9]{4} {0,1}[0-9]{4} {0,1}[0-9]{4}/;
    var noIlligalChars = regex.test(saniInput);
    var rightLength = (saniInput.length === 19);
    if (noIlligalChars && rightLength) {
        input.style.border = "2px solid green";
    } else {
        input.style.border = "2px solid red";
    }
};
var isNumberValid = function(input, length) {
    var regex = /^\d+$/;
    var isvalidformat = regex.test(input.value)
    var rightLength = (input.value.length === length);
    if (isvalidformat && rightLength) {
        input.style.border = "2px solid green";
    } else {
        input.style.border = "2px solid red";
    }
};
