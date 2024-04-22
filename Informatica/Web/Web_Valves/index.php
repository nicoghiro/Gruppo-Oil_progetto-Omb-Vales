<?php

// Connessione al database
$servername = "localhost";
$username = "ADMIN";
$password = "12345";
$dbname = "my_ombvalvesdata";
try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    if ($_SERVER['REQUEST_METHOD'] == 'GET') {
        $array = explode('/', $_SERVER['REQUEST_URI']);
        $last_segment = end($array);
        if ($last_segment == 'serial_number') {
            $sql = "SELECT SERIAL_NUMBER FROM `valvola`";
            $stmt = $conn->query($sql);
            $serial_numbers = $stmt->fetchAll(PDO::FETCH_COLUMN);
            http_response_code(200);
            echo json_encode($serial_numbers);
            exit();
        }
        if ($last_segment == 'type_vales') {
            $sql = "SELECT * FROM `tipo`";
            $stmt = $conn->query($sql);
            $tipo = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $tipo_array = array();
            foreach ($tipo as $row) {
                $tipo_array[] = $row;
            }
            $json_tipo = json_encode($tipo_array);
            header('Content-Type: application/json');
            http_response_code(200);
            echo $json_tipo;
             exit();
        }
        if ($array[2] =='valves' && $last_segment != '') {
            $sql = "SELECT * FROM `valvola` WHERE Tipo_valvola=:valv";
            $stmt = $conn->prepare($sql);
            $inp = $last_segment . '%'; 
            $stmt->bindParam(':valv', $inp, PDO::PARAM_STR);
            $stmt->execute();
            $tipo = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $tipo_array = array();
            foreach ($tipo as $row) {
                $tipo_array[] = $row;
            }
            $json_tipo = json_encode($tipo_array);
            header('Content-Type: application/json');
            http_response_code(200);
            echo $json_tipo;
             exit();
        }
        if ($last_segment != '' && $array[2] == 'type_vales') {
            $sql = "SELECT * FROM `tipo` WHERE `VALVE CODE` LIKE :inp";
            $stmt = $conn->prepare($sql);
            $inp = $last_segment . '%'; 
            $stmt->bindParam(':inp', $inp, PDO::PARAM_STR);
            $stmt->execute();
            $tipo = $stmt->fetchAll(PDO::FETCH_ASSOC);
            $tipo_array = array();
            foreach ($tipo as $row) {
                $tipo_array[] = $row;
            }
            $json_tipo = json_encode($tipo_array);
            header('Content-Type: application/json');
            http_response_code(200);
            echo $json_tipo;
            exit();
            
        }
        if ($last_segment != '' && $array[2] == 'misuration') {
            $sql = "SELECT * FROM `misurazioni` WHERE ser_valvola = :serial";
            $stmt = $conn->prepare($sql);
            $stmt->bindParam(':serial', $last_segment, PDO::PARAM_STR);
            $stmt->execute();
            $mis = $stmt->fetchAll(PDO::FETCH_ASSOC);

            $mis_array = array();
            foreach ($mis as $row) {
                $mis_array[] = $row;
            }

            $json_mis = json_encode($mis_array);  
            http_response_code(200);
            header('Content-Type: application/json');
          
            echo $json_mis;
            exit();

        } 
        if ($last_segment != '' && $array[2] == 'values') {
           
            $sql = "SELECT * FROM `valori` WHERE id_misurazione = :id_mis ORDER BY angolo";
            $stmt = $conn->prepare($sql);
            $stmt->bindParam(':id_mis', $last_segment, PDO::PARAM_STR);
            $stmt->execute();
            $values = $stmt->fetchAll(PDO::FETCH_ASSOC);

            $values_array = array();
            foreach ($values as $row) {
                $values_array[] = $row;
            }

            $json_values = json_encode($values_array);
            header('Content-Type: application/json');
           echo $json_values;
            exit();

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
            $id = $row['id_misurazione'];
        }

        // Inserisci i valori nella tabella 'valori'
        foreach ($misurazioni as $misurazione) {
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

} catch (PDOException $ex) {
    echo $ex;
    http_response_code(500);
}
$conn = null;
?>