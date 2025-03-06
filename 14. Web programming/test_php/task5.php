<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer4 = $_POST['answer4'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 4'] = $answer4; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 5\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 5</h3>
   <form action="task6.php" method="post">
      <p><b>Как получить данные POST-запроса в PHP?</b></p>
       <p><input type="radio" name='answer5' value="1">Через функцию getPostData()</p>
       <p><input type="radio" name='answer5' value="2">Через константу POST</p>
       <p><input type="radio" name='answer5' value="3">Через переменную $_POST</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>