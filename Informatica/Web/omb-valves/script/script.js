$(document).ready(function() {
    // Get the serial number from the URL query parameters
    var serialNumber = new URLSearchParams(window.location.search).get('serial_number');
    fetchMeasurements("http://localhost/Web_Valves/misuration/" + serialNumber);
  });
  
  function fetchMeasurements(url) {
    $.get(url, function(measurements) {
      $("#measurementsTableBody").empty();
      measurements.forEach(function(measurement) {
        var row = "<tr>" +
                    "<td>" + measurement.data_misurazione + "</td>" +
                    "<td><a href='values.html?measurement=" + measurement.id_misurazione + "' class='btn btn-primary'>View values</a></td>"  +
                  "</tr>";
        $("#measurementsTableBody").append(row);
      });
    });
  }
  