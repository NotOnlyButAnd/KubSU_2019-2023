# Variant 11. Tasks: 5, 7, 14

# 5 #
=begin
Дана строка. Необходимо перемешать все символы строки в
случайном порядке
=end
def task_1 my_str
	return my_str.split('').sort_by{rand}.join
end

# 7 #
=begin
Дана строка, состоящая из символов латиницы. Необходимо проверить, 
образуют ли прописные символы этой строки палиндром
=end
def task_2 my_str
	t = my_str.scan(/[A-Z]/)
	return t == t.reverse
end

# 14 #
=begin
Дана строка в которой записаны слова через пробел. Необходимо
упорядочить слова по количеству букв в каждом слове
=end
def task_3 my_str
	return my_str.split(' ').sort_by{|i| i.length}
end

puts "Input some string: "
first_str = STDIN.gets.chomp
puts "Choose task\n1 - Random shake str symbol's;\n2 - Is BIG latin palindrom\n3 - Sort words by letter's count"
choice = STDIN.gets.chomp.to_i
case choice
	when 1
		print "Shake: ", task_1(first_str)
	when 2
		print "Palindrom? -> ", task_2(first_str)
	when 3
		print "Sorted words: ", task_3(first_str)
	else
		print "Hey, i haven't such method :("
	end
