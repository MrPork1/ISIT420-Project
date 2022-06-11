//$(document).ready(function () {


//    $.getJSON('api/Frequency')
//        .done(function (data) {
//            let dataArray = data;
//            let selectID = document.getElementById("frequencies");
//            dataArray.forEach(function (value) {
//                selectID.appendChild(new Option(value.frequency, value.frequencyId));
//            });

//        });

//    $.getJSON('api/Gender')
//        .done(function (data) {
//            let dataArray = data;
//            let selectID = document.getElementById("genders");
//            dataArray.forEach(function (value) {
//                selectID.appendChild(new Option(value.gender, value.genderId));
//            });
//        });

//    $.getJSON('api/Age')
//        .done(function (data) {
//            let dataArray = data;
//            let selectID = document.getElementById("ages");
//            dataArray.forEach(function (value) {
//                selectID.appendChild(new Option(value.ageRange, value.ageId));
//            });
//        });
//});

function participationQuery() {
    $.getJSON('api/Query')
        .done(function (data) {
            console.log(data);
            var table = document.getElementById('query1Table');
            // creating rows
            for (var r = 0; r < data.length; r++) {
                var row = document.createElement("tr");

                var cell0 = document.createElement("td");
                var cell1 = document.createElement("td");
                var cell2 = document.createElement("td");
               // var cell3 = document.createElement("td");

                cell0.appendChild(document.createTextNode(data[r].region));
                row.appendChild(cell0);
                cell1.appendChild(document.createTextNode(data[r].percentage1));
                row.appendChild(cell1);
                cell2.appendChild(document.createTextNode(data[r].percentage2));
                row.appendChild(cell2);
              //  cell3.appendChild(document.createTextNode(data[r].percentage3));
              //  row.appendChild(cell3);

                table.appendChild(row); // add the row to the end of the table body
            }
        })
}

function query2Function() {
    $.getJSON('api/Query2')
        .done(function (data) {
            console.log(data);
        })
}