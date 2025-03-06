# подключаем классы
require File.dirname(__FILE__) + "/Department.rb"
require File.dirname(__FILE__) + "/Department_list.rb"

=begin
# создаем объекты класса
dep_1 = Department.new('First Department', '+79996332237')
puts "#{dep_1.getName} with phone: #{dep_1.getPhone} were created..."
# puts "#{dep_1.name} with phone: #{dep_1.phone} were created..." - так не получится

dep_2 = Department.new('Second Department', '+78612541231')
puts "#{dep_2.getName} with phone: #{dep_2.getPhone} were created..."
=end

# создаем объект и выводим инфу более красиво
=begin
dep_3 = Department.new('Third Department', '+78613991111')
print "Were created: "
puts dep_3.to_s
dep_3.addCommitment("Work for BOSS")
dep_3.addCommitment("Sitting at the chair")
dep_3.addCommitment("Drinking tea")
dep_3.printCommitments
=end

# создаем объект с обязанностями
=begin
sales_dep = Department.new('Sales department', '+78612341122', 'Making reports', 'Realizating sales', 'Changing tariffs')
puts sales_dep.to_s
sales_dep.selectCommitmentByIndex(1)
sales_dep.changeSelectedCommText("Making paper planes")
puts sales_dep.getSelectedCommText
sales_dep.deleteSelectedCommitment
puts sales_dep.to_s
=end

# testing new to_s...
#dep_3 = Department.new('Third Department', '+78613991111')
dep_3 = Department.new('Third Department', '+78613991111', 'W1', 'W2', 'W3')
puts "Were created: " + dep_3.to_s
#dep_3.add_commitment("Making reports")
#dep_3.add_commitment("Work for BOSS")
#dep_3.add_commitment("Drinking tea")
puts dep_3.get_commitments_info

dep_4 = Department.new('Fourth Department', '+78005553535', 'W1', 'W2', 'W3')
puts "\nWere created: " + dep_4.to_s
puts dep_4.get_commitments_info

# чтение из файла
path = File.dirname(__FILE__) + '/dep_data.txt' # Получили путь к файлу рядом с исполняемым
puts "\nReaded deps:"
my_deps = Department.read_from_txt(path)
Department.print_deps_arr(my_deps)

# запись в файл txt
=begin
my_deps.append(dep_4)
puts "\nYour array:"
my_deps.each { |dep|  puts dep.to_s}

puts "\nYour array were printed to: " + Department.write_to_txt(my_deps, "dep_data.txt")
=end

# запись в файл yaml
print "\nDep list were writed to ", Department.write_to_YAML(my_deps, "dep_data.yaml"), "\n"

# чтение из yaml
dep_list_yaml = Department.read_from_YAML("dep_data.yaml")
Department.print_deps_arr(dep_list_yaml)

# добавим новый департамент и перезапишем и прочитаем
=begin
dep_list_yaml.append(dep_3)
print "\nDep list were writed to ", Department.write_to_YAML(my_deps, "dep_data.yaml"), "\n"
dep_list_yaml = Department.read_from_YAML("dep_data.yaml")
Department.print_deps_arr(dep_list_yaml)
=end

puts "--------------"
arr = ["a", "b", "c", "d", "e"]
puts "0: #{arr[0]};\n-1: #{arr[-1]};\n-5: #{arr[-5]};"
puts "--------------"

dep_list_obj = Department_list.new(*dep_list_yaml)
dep_list_obj.choose_note(0)

print dep_list_obj.class, " of ", dep_list_obj.get_note.class, "\n"
puts dep_list_obj.to_s

# ПРОВЕРКА НА принадлежность объекта к классу для add_note()
if (dep_3.class == Department)
    puts "YAY"
else
    puts "no("
end
