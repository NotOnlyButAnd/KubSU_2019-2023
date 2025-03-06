<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer7 = $_POST['answer7'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 7'] = $answer7; 
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 8\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 8</h3>
   <form action="task9.php" method="post">
      <p><b>Что такое протокол HTTP?</b></p>
       <p><input type="radio" name='answer8' value="1">Базовый протокол сети гипертекстовых ресурсов</p>
       <p><input type="radio" name='answer8' value="2">Протокол режима командной строки</p>
       <p><input type="radio" name='answer8' value="3">Первый обозреватель с графическим интерфейсом</p>
       <p><input type="radio" name='answer8' value="4">Протокол коммутации пакетов, предполагающий разбиение запросов данных на небольшие фрагменты</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>