<?php
    // Открытие доступа к сессионным переменным
    session_start();
    $answer3 = $_POST['answer3'];
    
    // $_SESSION - массив сессионных переменных
    $_SESSION['Ответ 3'] = $answer3; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Задание 4\9</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
   <header>Тест по дисциплине: "Программирование в компьютерных сетях"</header>
   <h3>Задание 4</h3>
   <form action="task5.php" method="post">
      <p><b>Cookies это:</b></p>
       <p><input type="radio" name='answer4' value="1">расширение протокола HTTP</p>
       <p><input type="radio" name='answer4' value="2">расширение протокола FTP</p>
       <p><input type="radio" name='answer4' value="3">расширение протокола TELNET</p>
       <input type="submit" value="Ответить">
   </form>
</body>
</html>