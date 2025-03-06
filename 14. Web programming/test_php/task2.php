<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer1 = $_POST['answer1'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 1'] = $answer1; 
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 2\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 2</h3>
   <form action="task3.php" method="post">
       <p><b>Программа для просмотра гипертекстовых страниц называется:</b></p>
       <p><input type="radio" name='answer2' value="1">Сервер</p>
       <p><input type="radio" name='answer2' value="2">Протокол</p>
       <p><input type="radio" name='answer2' value="3">HTML</p>
       <p><input type="radio" name='answer2' value="4">Браузер</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>