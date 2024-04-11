<?php

// Connessione al database
$servername = "localhost";
$username = "Operatore";
$password = "12345";
$dbname = "omb-valves";
$conn = new mysqli($servername, $username, $password, $dbname);

// Verifica della connessione
if ($conn->connect_error) {
    http_response_code(500); 
    exit();
}

// Verifica della richiesta GET e del percorso dell'URL
if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $array = explode('/', $_SERVER['REQUEST_URI']); 
    if (count($array) == 4 && $array[3] == 'serial_number') {
        $sql = "SELECT SERIAL_NUMBER FROM `valvola`";
        $result = $conn->query($sql);   
        if ($result) {
            $serial_numbers = array();
            while ($row = $result->fetch_assoc()) {
                $serial_numbers[] = $row['SERIAL_NUMBER'];
            }
            echo json_encode($serial_numbers);
        } else {
            http_response_code(500);
            exit();
        }
    } else {
    http_response_code(404);
        exit();
    }
}

$conn->close();
?>
