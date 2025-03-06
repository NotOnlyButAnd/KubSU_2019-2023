<?php
$phone = $_POST["phone"];

if (isset($_POST["phone"])) {

    // Чтение JSON файла
    $json_str = file_get_contents("phones.json");
    // Преобразование строки JSON в массив
    $phones = json_decode($json_str, true);

    $flag = 0;

    // Проверка телефонов
    foreach ($phones as $key => $value) {
        if ($value == $phone){
            echo "Владелец телефона: " . (string)$key;   // конкатенируем строки
            $flag = 1;
        }
    }
    if ($flag == 0)
        echo "Владелец телефона не найден в файле :-(";   // конкатенируем строки
}
?>