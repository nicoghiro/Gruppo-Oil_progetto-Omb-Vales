function fetchData(path) {
  $.get(path, function(data) {
    data.forEach(function(valve) {
      var row = "<tr>" +
                  "<td>" + valve['VALVE CODE'] + "</td>" +
                  "<td>" + valve['VALVE DESCRIPTION'] + "</td>" +
                  "<td>" + valve['GEAR MODEL'] + "</td>" +
                  "<td>" + valve['M.A. GEAR'] + "</td>" +
                  "<td><a href='#' class='viewValveLink' data-toggle='modal' data-target='#valveModal' data-valve-id='" + valve.Id_valvola + "'>View valves</a></td>" +
                  "</tr>";
      $("#valvesTableBody").append(row);
    });
    $(".viewValveLink").click(function() {
      var valveId = $(this).data("valve-id");
      populateModalWithValveData(valveId);
    });
  });
}
;
function Cerca() {
    svuota_tbody();
    var input, filter;
    input = document.getElementById('myInput');
    filter = input.value.toUpperCase();
    if(filter==""){
      fetchData("http://localhost/web_valves/type_vales");
    }
    else
    fetchData("http://localhost/web_valves/"+filter); 
}
function svuota_tbody()
{
   var collezione = document.getElementById('valvesTableBody');
   collezione.innerHTML = ' '
}
function populateModalWithValveData(valveId) {
  $.get("http://localhost/web_valves/valves/" + valveId, function(valveDetails) {
    var modalBody = "<div class='container-fluid'>";
    valveDetails.forEach(function(detail) {
      modalBody += "<div class='row'>" +
                     "<div class='col-md-6'>" +
                       "<p><strong>SERIAL NUMBER:</strong> " + detail['SERIAL_NUMBER'] + "</p>" +
                       "<p><strong>OMB JOB NUMBER:</strong> " + detail['OMB JOB NUMBER'] + "</p>" +
                     "</div>" +
                     "<div class='col-md-6'>" +
                       "<a href='measurement.html?serial_number=" + detail['SERIAL_NUMBER'] + "' class='btn btn-primary'>View misurations</a>" +
                     "</div>" +
                   "</div>" +
                   "<hr>";
    });
    modalBody += "</div>";
    $("#valveDetails").html(modalBody);
  });
}

