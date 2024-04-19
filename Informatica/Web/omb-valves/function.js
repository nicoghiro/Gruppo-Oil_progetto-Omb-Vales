function fetchData(path) {
  $.get(path, function(data) {
    data.forEach(function(valve) {
      var row = "<tr>" +
                  "<td>" + valve['VALVE CODE'] + "</td>" +
                  "<td>" + valve['VALVE DESCRIPTION'] + "</td>" +
                  "<td>" + valve['GEAR MODEL'] + "</td>" +
                  "<td>" + valve['M.A. GEAR'] + "</td>" +
                  "<td><a href='another_page.html?id=" + valve.Id_valvola + "'>View Valves</a></td>" +
                "</tr>";
      $("#valvesTableBody").append(row);
    });
  });
}
;
function Cerca() {
    svuota_tbody();
    var input, filter;
    input = document.getElementById('myInput');
    filter = input.value.toUpperCase();
    fetchData("http://localhost/web_valves/type_vales/"+filter); 
}
function svuota_tbody()
{
   var collezione = document.getElementById('valvesTableBody');
   collezione.innerHTML = ' '
}