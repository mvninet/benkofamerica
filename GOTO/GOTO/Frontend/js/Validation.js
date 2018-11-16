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

var checkAll = function () {

    var cities = [];
    var routeParams = {
        Weight: "",
        Type: "Standard",
        Height: "",
        Width: "",
        Depth: "",
        From: "",
        To: ""
    };
    var selected = $('input[name=type]:checked');
    if (selected.length > 0) {
        var id = selected[0].id;
        routeParams.Type = id;
        console.log(id);
    }
    var from = $("#autoFrom").val();
    var to = $("#autoTo").val();

    if (from !== null) {
        routeParams.From = from;
    } 
    if (to !== null) {
        routeParams.To = to;
    }

    var height = $("#Height").val();
    var width = $("#Width").val();
    var depth = $("#Depth").val();

    if (height !== null) {
        routeParams.Height = height;
    }
    if (width !== null) {
        routeParams.Width = width;
    }
    if (depth !== null) {
        routeParams.Depth = depth;
    }
    var weight = $("#weight").val();

    if (weight !== null) {
        routeParams.Weight = weight;
    }

    if (routeParams.Depth !== "" &&
        routeParams.From !== "" &&
        routeParams.Height !== "" &&
        routeParams.Type !== "" &&
        routeParams.Weight !== "" &&
        routeParams.Width !== "" &&
        routeParams.To !== "") {
        return routeParams;
    } else {
        return false;
    }
}
