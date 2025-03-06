<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer6 = $_POST['answer6'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 6'] = $answer6; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 7\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 7</h3>
   <form action="task8.php" method="post">
      <p><b>Что такое AJAX?</b></p>
       <p><input type="radio" name='answer7' value="1">Java-Script-библиотека</p>
       <p><input type="radio" name='answer7' value="2">Сетевой протокол передачи данных на сервер</p>
       <p><input type="radio" name='answer7' value="3">Технология обмена данными с сервером  без перезагрузки страницы</p>
       <p><input type="radio" name='answer7' value="4">Текстовый формат обмена данными</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>