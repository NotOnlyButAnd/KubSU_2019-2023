# XXX/ Этот код необходим только при использовании русских букв на Windows
if (Gem.win_platform?)
  Encoding.default_external = Encoding.find(Encoding.locale_charmap)
  Encoding.default_internal = __ENCODING__

  [STDIN, STDOUT].each do |io|
    io.set_encoding(Encoding.default_external, Encoding.default_internal)
  end
end
# /XXX

=begin
Дана строка. Необходимо найти все даты, которые описаны в
виде "31 февраля 2007"
=end
def all_data my_str
    return my_str.scan(/([0-2]\d|3[0-1]) (января|февраля|марта|апреля|мая|июня|июля|августа|сентября|октября|ноября|декабря) (\d{4})/).map{|e| e.join(' ')}.join("; ")
end

# Variant 11. Tasks: 5, 7, 14

# 5 #
=begin
Дана строка. Необходимо найти наибольшее количество идущих
подряд символов кириллицы
аФаЯсФasdA12иии*фыв(!"ФАФЯмяофл -> max = ФАФЯмяофл
=end
def task_1 my_str
    return my_str.scan(/[а-яёА-ЯЁ]+/).max{|a,b| a.length <=> b.length }
end

# 7 #
=begin
Дана строка. Необходимо найти минимальное из имеющихся в ней
натуральных чисел
предположим, что раз НАТУРАЛЬНЫЕ ЧИСЛА, то разделены хоть чем-то (пробел)
12 4 28 3 84 -> 3
=end
def task_2 my_str
    return my_str.split(' ').min { |a, b| a.to_i <=> b.to_i }
end

# 14 #
=begin
Дана строка. Необходимо найти наибольшее количество идущих
подряд цифр
аФа1054ЯсФasdA12иии*ф_)*0019284ыв(!"ФАФЯмяофл -> 0019284
=end
def task_3 my_str
    return my_str.scan(/[0-9]+/).max{|a,b| a.length <=> b.length }
end

puts "Input some string: "
first_str = STDIN.gets.chomp
puts "Choose task\n1 - Get all date's;\n2 - Get max kyrillic sequence\n3 - Get min natural numb\n4 - Get max num sequence"
choice = STDIN.gets.chomp.to_i
case choice
    when 1
        print "Date's: ", all_data(first_str)
    when 2
        print "Max kyrillic: ", task_1(first_str)
    when 3
        print "Min natural num: ", task_2(first_str)
    when 4
        print "Max num: ", task_3(first_str)
    else
        print "Hey, i haven't such method :("
    end
