<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer2 = $_POST['answer2'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 2'] = $answer2; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 3\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 3</h3>
   <form action="task4.php" method="post">
      <p><b>Что такое сессия?</b></p>
       <p><input type="radio" name='answer3' value="1">механизм походов к психологу</p>
       <p><input type="radio" name='answer3' value="2">механизм находждения в игре</p>
       <p><input type="radio" name='answer3' value="3">механизм идентификации браузера</p>
       <p><input type="radio" name='answer3' value="4">механизм сдачи экзаменов</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>