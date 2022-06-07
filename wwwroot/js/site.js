$(document).ready(function () {


    $.getJSON('api/Frequency')
        .done(function (data) {
            let dataArray = data;
            let selectID = document.getElementById("frequencies");
            dataArray.forEach(function (value) {
                selectID.appendChild(new Option(value.frequency, value.frequencyId));
            });

        });

    $.getJSON('api/Gender')
        .done(function (data) {
            let dataArray = data;
            let selectID = document.getElementById("genders");
            dataArray.forEach(function (value) {
                selectID.appendChild(new Option(value.gender, value.genderId));
            });
        });

    $.getJSON('api/Age')
        .done(function (data) {
            let dataArray = data;
            let selectID = document.getElementById("ages");
            dataArray.forEach(function (value) {
                selectID.appendChild(new Option(value.ageRange, value.ageId));
            });
        });
});