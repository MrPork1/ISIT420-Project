﻿$(document).ready(function () {


    $.getJSON('api/Frequency')
        .done(function (data) {
            let dataArray = data;
            let selectID = document.getElementById("frequencies");
            dataArray.forEach(function (value) {
                selectID.appendChild(new Option(value.frequency, value.id));
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

    $.getJSON('api/Region')
        .done(function (data) {
            let dataArray = data;
            let selectID = document.getElementById("regions");
            dataArray.forEach(function (value) {
                selectID.appendChild(new Option(value.region, value.id));
            });
        });

    $.getJSON('api/Region')
        .done(function (data) {
            let dataArray = data;
            let selectID = document.getElementById("regions2");
            dataArray.forEach(function (value) {
                selectID.appendChild(new Option(value.region, value.id));
            });
        });

        $.getJSON('api/Query3')
            .done(function (data) {
                console.log(data);
                var result = document.getElementById('query3Result');
                //result.innerHTML = ("Highest: " + data.region + " " + data.percentage);
                result.innerHTML = "Highest: " + data
            });
});

function deleteTable1() {
    $('#query1Table tr').slice(1).remove();
    var table = document.getElementById('query1Table');
    var hidden = table.getAttribute("hidden");
    if (!hidden) {
        table.setAttribute("hidden", "hidden");
    }
}

function deleteTable2() {
    $('#query2Table tr').slice(1).remove();
    var table = document.getElementById('query2Table');
    var hidden = table.getAttribute("hidden");
    if (!hidden) {
        table.setAttribute("hidden", "hidden");
    }
}

function deleteTable3() {
    $('#query1Table tr').slice(1).remove();
    var table = document.getElementById('query1Table');
    var hidden = table.getAttribute("hidden");
    if (!hidden) {
        table.setAttribute("hidden", "hidden");
    }
}

function deleteTable4() {
    $('#query4Table tr').slice(1).remove();
    var table = document.getElementById('query4Table');
    var hidden = table.getAttribute("hidden");
}

function participationQuery() {
    $.getJSON('api/Query')
        .done(function (data) {
            console.log(data);
            var table = document.getElementById('query1Table');
            var hidden = table.getAttribute("hidden");
            if (hidden) {
                table.removeAttribute("hidden");
                // creating rows
                for (var r = 0; r < data.length; r++) {
                    var row = document.createElement("tr");

                    var cell0 = document.createElement("td");
                    var cell1 = document.createElement("td");
                    var cell2 = document.createElement("td");

                    cell0.appendChild(document.createTextNode(data[r].region));
                    row.appendChild(cell0);
                    cell1.appendChild(document.createTextNode(data[r].percentage1));
                    row.appendChild(cell1);
                    cell2.appendChild(document.createTextNode(data[r].percentage2));
                    row.appendChild(cell2);

                    table.appendChild(row); // add the row to the end of the table body
                }
            } else {
                deleteTable1();
            }
        })
}

function query2Function() {
    $.getJSON('api/SecondQuery')
        .done(function (data) {
            console.log(data);
            var table = document.getElementById('query2Table');
            var hidden = table.getAttribute("hidden");
            if (hidden) {
                table.removeAttribute("hidden");
                for (var r = 0; r < data.length; r++) {
                    var row = document.createElement("tr");

                    var cell0 = document.createElement("td");
                    var cell1 = document.createElement("td");

                    cell0.appendChild(document.createTextNode(data[r].gender));
                    row.appendChild(cell0);
                    cell1.appendChild(document.createTextNode(data[r].percentage));
                    row.appendChild(cell1);

                    table.appendChild(row); // add the row to the end of the table body
                }
            } else {
                deleteTable2();
            }
        })
}

function query3FunctionSelectRegion() {

    let selectRegion = document.getElementById('regions');
    let regionValue = selectRegion.options[selectRegion.selectedIndex].text;
    console.log(regionValue);

    $.getJSON('api/Query3' + '/' + regionValue)
        .done(function (data) {
            console.log(data);
            $('#query3Result2').text("");
            $('#query3Result2').text(data)
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#query3Result2').text('Error');
        });
}

function query4FunctionSelectRegionAndFrequency() {

    let selectRegion = document.getElementById('regions2');
    let regionValue = selectRegion.options[selectRegion.selectedIndex].text;
    console.log(regionValue);

    let selectFrequency = document.getElementById("frequencies");
    let frequencyId = selectFrequency.options[selectFrequency.selectedIndex].value;
    console.log(frequencyId);
    //'api/Query4/?regionValue=' + regionValue + '&frequencyId=' + frequencyId
    $.getJSON('api/Query4' + '/' + regionValue + '/' + frequencyId)
        .done(function (data) {
            console.log(data);
            var table = document.getElementById('query4Table');
            var hidden = table.getAttribute("hidden");
                deleteTable4();
                table.removeAttribute("hidden");
                // creating rows
                for (var r = 0; r < data.length; r++) {
                    var row = document.createElement("tr");

                    var cell0 = document.createElement("td");
                    var cell1 = document.createElement("td");
                    var cell2 = document.createElement("td");

                    cell0.appendChild(document.createTextNode(data[r].region));
                    row.appendChild(cell0);
                    cell1.appendChild(document.createTextNode(data[r].percentage));
                    row.appendChild(cell1);
                    cell2.appendChild(document.createTextNode(data[r].gender));
                    row.appendChild(cell2);

                    table.appendChild(row); // add the row to the end of the table body
                }
        })
        .fail(function (jqXHR, textStatus, err) {
        });
}
