function fetchData(path) {
  $.get(path, function(data) {
      data.forEach(function(valve) {
          var row = "<tr>" +
              "<td>" + valve['VALVE CODE'] + valve['materiale'] + "</td>" +
              "<td>" + valve['VALVE DESCRIPTION'] + "</td>" +
              "<td>" + valve['GEAR MODEL'] + "</td>" +
              "<td>" + valve['M.A. GEAR'] + "</td>" +
              "<td><a href='#' class='btn btn-primary viewValveLink' data-toggle='modal' data-target='#valveModal' data-valve-id='" + valve.Id_valvola + "'>View valves</a></td>" +
              "<td><button class='btn btn-primary viewValuesBtn' data-toggle='modal' data-target='#valuesModal' data-valve-id='" + valve.Id_valvola + "'>Expected Values</button></td>" +
              "</tr>";
          $("#valvesTableBody").append(row);
      });

      $(".viewValveLink").click(function() {
          var valveId = $(this).data("valve-id");
          populateModalWithValveData(valveId);
      });

      $(".viewValuesBtn").click(function() {
          var valveId = $(this).data("valve-id");
          populateModalWithExpectedValues(valveId);
      });
  });
}

function Cerca() {
  svuota_tbody();
  var input, filter;
  input = document.getElementById('myInput');
  filter = input.value.toUpperCase();
  if(filter == ""){
      fetchData("http://localhost/Web_Valves/type_vales");
  } else {
      fetchData("http://localhost/Web_Valves/type_vales/" + filter); 
  }
}

function svuota_tbody() {
  var collezione = document.getElementById('valvesTableBody');
  collezione.innerHTML = '';
}

function populateModalWithValveData(valveId) {
  $.get("http://localhost/Web_Valves/valves/" + valveId, function(valveDetails) {
      var modalBody = "<div class='container-fluid'>";
      valveDetails.forEach(function(detail) {
          modalBody += "<div class='row'>" +
              "<div class='col-md-6'>" +
              "<p><strong>SERIAL NUMBER:</strong> " + detail['SERIAL_NUMBER'] + "</p>" +
              "<p><strong>OMB JOB NUMBER:</strong> " + detail['OMB JOB NUMBER'] + "</p>" +
              "</div>" +
              "<div class='col-md-6'>" +
              "<a href='measurement.html?serial_number=" + detail['SERIAL_NUMBER'] + "' class='btn btn-primary'>View measurements</a>" +
              "</div>" +
              "</div>" +
              "<hr>";
      });
      modalBody += "</div>";
      $("#valveDetails").html(modalBody);
  });
}

function populateModalWithExpectedValues(valveId) {
  $.get("http://localhost/Web_Valves/specifiche/" + valveId, function(expectedValues) {
      var modalBody = "<div class='container-fluid'>";
      modalBody += "<table class='table'>";
      modalBody += "<thead class='thead-dark'>";
      modalBody += "<tr>";
      modalBody += "<th>BTO</th>";
      modalBody += "<th>RUN</th>";
      modalBody += "<th>ETO</th>";
      modalBody += "<th>BTC</th>";
      modalBody += "<th>RUN</th>";
      modalBody += "<th>ETC</th>";
      modalBody += "</tr>";
      modalBody += "</thead>";
      modalBody += "<tbody>";
      
      expectedValues.forEach(function(value) {
          modalBody += "<tr>";
          modalBody += "<td>" + value['BTO'] + "</td>";
          modalBody += "<td>" + value['RUN_op'] + "</td>";
          modalBody += "<td>" + value['ETO'] + "</td>";
          modalBody += "<td>" + value['BTC'] + "</td>";
          modalBody += "<td>" + value['RUN_cl'] + "</td>";
          modalBody += "<td>" + value['ETC'] + "</td>";
          modalBody += "</tr>";
      });
      
      modalBody += "</tbody>";
      modalBody += "</table>";
      modalBody += "</div>";

      $("#valuesModalBody").html(modalBody);
  });
}
$(document).ready(function() {
  fetchData("http://localhost/Web_Valves/type_vales");
});
