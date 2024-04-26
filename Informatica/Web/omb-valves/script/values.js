$(document).ready(function() {
  var measurementId = new URLSearchParams(window.location.search).get('measurement');
  fetchValues("https://ombvalvesdata.altervista.org/Web_Valves/index.php/values/" + measurementId + "/a", "apertura", "aperturaChart");
  fetchValues("https://ombvalvesdata.altervista.org/Web_Valves/index.php/values/" + measurementId + "/c", "chiusura", "chiusuraChart");
});

function fetchValues(url, type, chartId) {
  $.get(url, function(values) {
    var labels = values.map(function(value) {
      return value['angolo'];
    });
    var data = values.map(function(value) {
      return value['coppia'];
    });

    // Populate table with values
    var tableBody = $("#" + type + "TableBody");
    tableBody.empty(); // Clear previous table data
    values.forEach(function(value) {
      var row = "<tr>" +
                  "<td>" + value['angolo'] + "</td>" +
                  "<td>" + value['coppia'] + "</td>" +
                  "<td>" + value['orario_valore'] + "</td>" +
                "</tr>";
      tableBody.append(row);
    });

    // Create line chart
    var ctx = document.getElementById(chartId).getContext('2d');
    var myChart = new Chart(ctx, {
      type: 'line',
      data: {
        labels: labels,
        datasets: [{
          label: type,
          data: data,
          borderColor: 'rgb(75, 192, 192)',
          borderWidth: 1,
          fill: false
        }]
      },
      options: {
        scales: {
          xAxes: [{
            scaleLabel: {
              display: true,
              labelString: 'Angolo'
            }
          }],
          yAxes: [{
            scaleLabel: {
              display: true,
              labelString: 'Coppia'
            }
          }]
        }
      }
    });
  });
}
