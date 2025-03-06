<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer8 = $_POST['answer8'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 8'] = $answer8;
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 9\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 9</h3>
   <form action="results.php" method="post">
      <p><b>Что такое JQUERY?</b></p>
       <p><input type="radio" name='answer9' value="1">CSS-библиотека</p>
       <p><input type="radio" name='answer9' value="2">Java-Script-библиотека</p>
       <p><input type="radio" name='answer9' value="3">Java-Script фреймворк</p>
       <p><input type="radio" name='answer9' value="4">CSS-фреймворк</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>