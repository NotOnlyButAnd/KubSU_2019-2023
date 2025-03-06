require File.dirname(__FILE__) + "/User.rb"
require File.dirname(__FILE__) + "/Scooter.rb"

# Создаем несколько пользователей
user_1 = User.new("s0153478", "+79529762139")
print "\nUser were created: ", user_1.to_s

user_2 = User.new("s0153612", "+79892805802")
print "\nUser were created: ", user_2.to_s

user_3 = User.new("s0142987", "+79996332237")
print "\nUser were created: ", user_3.to_s 

# добавляем созданных пользователей в массив
my_users = [user_1, user_2, user_3]

# запишем пользователей в файлы txt и YAML
puts "\n\nWriting users to txt and YAML..."
User.write_to_txt(my_users, "users_data.txt")
User.write_to_YAML(my_users, "users_data.yaml")
puts "Writed successfully!!"

# читаем из txt, выводим (checked)
new_users = User.read_from_txt("users_data.txt")
puts "\nReaded from txt: "
User.print_users_arr(new_users)

###################################################
# читаем из YAML, выводим (!!!ERROR!!!), почему???
# на стационарном компе версия руби 3.0.3p157 (2021-11-24), там метод отрабатывает
# на ноуте версия руби 3.1.2p20 (2022-04-12), тут выдает ошибку что недопустимый класс User
# пытался запускать код из лабы 2, Department класс - там то же так же
###################################################
#new_users_1 = User.read_from_YAML("users_data.yaml")
#puts "\nReaded from YAML: ", User.print_users_arr(new_users_1)

# Создаем несколько самокатов
scooter_1 = Scooter.new("0001", 90, true)
print "\nScooter were created: ", scooter_1.to_s

scooter_2 = Scooter.new("0002", 87, true)
print "\nScooter were created: ", scooter_2.to_s

scooter_3 = Scooter.new("0003", 0, false)
print "\nScooter were created: ", scooter_3.to_s 

# добавляем созданных пользователей в массив
my_scooters = [scooter_1, scooter_2, scooter_3]

# запишем пользователей в файлы txt и YAML
puts "\n\nWriting scooters to txt and YAML..."
Scooter.write_to_txt(my_scooters, "scooters_data.txt")
Scooter.write_to_YAML(my_scooters, "scooters_data.yaml")
puts "Writed successfully!!"

# читаем из txt, выводим (checked)
new_scooters = Scooter.read_from_txt("scooters_data.txt")
puts "\nReaded from txt: "
Scooter.print_scooters_arr(new_scooters)

#new_scooters_1 = Scooter.read_from_YAML("scooters_data.yaml")
#puts "\nReaded from YAML: ", Scooter.print_scooters_arr(new_scooters_1)