<?php

// Connessione al database
$servername = "localhost";
$username = "ADMIN";
$password = "12345";
$dbname = "omb-valves";
try{
$conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);


// Verifica della richiesta GET e del percorso dell'URL
if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $array = explode('/', $_SERVER['REQUEST_URI']); 
    $last_segment = end($array);
    if ($last_segment == 'serial_number') {
        $sql = "SELECT SERIAL_NUMBER FROM `valvola`";
        $stmt = $conn->query($sql);
        $serial_numbers = $stmt->fetchAll(PDO::FETCH_COLUMN);
        echo json_encode($serial_numbers);
        exit(); // Termina lo script dopo aver inviato la risposta
    } 
    if ($last_segment == 'type_vales') {
        $sql = "SELECT * FROM `tipo`";
        $stmt = $conn->query($sql);
        $tipo = $stmt->fetchAll(PDO::FETCH_COLUMN);
        echo json_encode($tipo);
        exit(); // Termina lo script dopo aver inviato la risposta
    } 
    else {
        http_response_code(404);
        exit();
    }
}
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $body = file_get_contents('php://input');
        $data = json_decode($body, true);
        $serialNumber = $data['Codice_seriale']['Codice_ser'];
        $data_ini = $data['inf_misurazioni']['Ini_mis'];
        $misurazioni = $data['mis']['misurazioni'];
    
        // Inserisci nella tabella 'misurazioni'
        $sql = "INSERT INTO misurazioni (data_misurazione, ser_valvola) VALUES (:data, :serial)";
        $statement = $conn->prepare($sql);
        $statement->bindParam(':data', $data_ini, PDO::PARAM_STR);
        $statement->bindParam(':serial', $serialNumber, PDO::PARAM_STR);
        $statement->execute();
    
        // Ottieni l'ID della misurazione appena inserita
        $sql = "SELECT id_misurazione FROM misurazioni WHERE data_misurazione=:data AND ser_valvola=:serial";
        $statement = $conn->prepare($sql);
        $statement->bindParam(':data', $data_ini, PDO::PARAM_STR);
        $statement->bindParam(':serial', $serialNumber, PDO::PARAM_STR);
        $statement->execute();
        $result = $statement->fetchAll();
        foreach ($result as $row) {
            $id= $row['id_misurazione'];
        }
    
        // Inserisci i valori nella tabella 'valori'
        foreach($misurazioni as $misurazione){
            $parts = explode(';', $misurazione);
            $coppia = $parts[0];
            $angolo = $parts[1];
            $data_valore = $parts[2];
            
            // Crea un nuovo statement per ogni inserimento
            $sql = "INSERT INTO valori (coppia, angolo, orario_valore, id_misurazione) VALUES (:coppia, :angolo, :data_valore, :id)";
            $statement_valori = $conn->prepare($sql);
            $statement_valori->bindParam(':coppia', $coppia, PDO::PARAM_STR);
            $statement_valori->bindParam(':angolo', $angolo, PDO::PARAM_STR);
            $statement_valori->bindParam(':data_valore', $data_valore, PDO::PARAM_STR);
            $statement_valori->bindParam(':id', $id, PDO::PARAM_STR);
            $statement_valori->execute();
        }
    }
    
}
catch(PDOException $ex){
    echo $ex;
    http_response_code(500);
}
$conn=null;
?>
