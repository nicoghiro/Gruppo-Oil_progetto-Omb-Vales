$(document).ready(function() {
    // Get the serial number from the URL query parameters
    var serialNumber = new URLSearchParams(window.location.search).get('serial_number');
    alert(serialNumber);
    fetchMeasurements("https://ombvalvesdata.altervista.org/Web_Valves/index.php/misuration/" + serialNumber);
  });
  
  function fetchMeasurements(url) {
    $.get(url, function(measurements) {
      $("#measurementsTableBody").empty();
      measurements.forEach(function(measurement) {
        var row = "<tr>" +
                    "<td>" + measurement.id_misurazione + "</td>" +
                    "<td>" + measurement.data_misurazione + "</td>" +
                    "<td>" + measurement.ser_valvola + "</td>" +
                  "</tr>";
        $("#measurementsTableBody").append(row);
      });
    });
  }
  