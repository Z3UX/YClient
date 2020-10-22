function saveNumber() {

    let numObj = { value: parseFloat($('#number').val()) };

    $.ajax({
        method: "POST",
        url: window.location.origin + "/v1/numbers",
        data: JSON.stringify(numObj),
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            alert("O número " + response.value + " foi guardado com o ID # " + response.id);
        },
        error: function (xhr) {
            alert("Error " + xhr.responseJSON.status + ": " + xhr.responseJSON.title);
        }
    });
}

// Copyright 2008 Bontrager Connection, LLC
// https://www.willmaster.com/

// When no form field name is provided, it is assumed
//   to be the default name with the default name
//   increment number appended.

var DefaultName = "sum";
var DefaultNameIncrementNumber = 1;

// No further customizations required.

function AddFormField(id, type, name, value, tag) {
    if (!document.getElementById && document.createElement) { return; }
    var inhere = document.getElementById(id);
    var formfield = document.createElement("input");
    if (name.length < 1) {
        DefaultNameIncrementNumber++;
        name = String(DefaultName + DefaultNameIncrementNumber);
    }
    formfield.type = type;
    formfield.value = value;
    formfield.id = name;
    formfield.className = "form-control";
    if (tag.length > 0) {
        var thetag = document.createElement(tag);
        thetag.appendChild(formfield);
        inhere.appendChild(thetag);
    }
    else { inhere.appendChild(formfield); }
} // function AddFormField()


function sumNumbers() {

    let numArr = [];

    for (let i = 0; i <= DefaultNameIncrementNumber; i++) {
        if ($('#sum' + i).val() != "") {
            numArr.push(parseInt($('#sum' + i).val(), 10));
        }
    }

    $.ajax({
        method: "POST",
        url: window.location.origin + "/v1/sum",
        data: JSON.stringify(numArr),
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            document.getElementById("result").innerHTML = "O total da soma é " + response;
        },
        error: function (xhr) {
            alert("Error " + xhr.responseJSON.status + ": " + xhr.responseJSON.title);
        }
    });
}