<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer5 = $_POST['answer5'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 5'] = $answer5; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 6\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 6</h3>
   <form action="task7.php" method="post">
      <p><b>Какой механизм позволяет серверу хранить информацию на компьютере клиента и извлекать её оттуда?</b></p>
       <p><input type="radio" name='answer6' value="1">Механизм Cookie</p>
       <p><input type="radio" name='answer6' value="2">Механизм World Wide Web</p>
       <p><input type="radio" name='answer6' value="3">Механизм Session</p>
       <p><input type="radio" name='answer6' value="4">Механизм Frame</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>