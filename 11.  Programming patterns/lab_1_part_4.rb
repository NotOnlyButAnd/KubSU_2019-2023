# Variant 11. Tasks: 11, 23, 35, 47, 59

# 11 #
=begin
Дан целочисленный массив, в котором лишь один элемент
отличается от остальных. Необходимо найти значение этого элемента
[1 1 1 2 1 1], [4 4 4 2 4 4 4]...
=end
def task_1 my_arr
	return my_arr.select{ |i| my_arr.count(i) == 1 }[0]
end

# 23 #
=begin
Дан целочисленный массив. Необходимо найти два наименьших
элемента
[1 2 3 4 5] -> 1, 2; [4 1 6 3 6 3] -> 1, 3...
=end
def task_2 my_arr
	min_1 = my_arr.min
	my_arr.delete(min_1)
	min_2 = my_arr.min
	return min_1, min_2
end

# 35 #
=begin
Дано вещественное число R и массив вещественных чисел. Найти
элемент массива, который наиболее близок к данному числу
[1.25 1.2 1.75 2.2 0.79] 1.6 -> 1.75...
ЗАДАНИЕ 3 ПРИ АЛЬТЕРНАТИВЕ "1 АРГУМЕНТ" - любой
=end
def task_3 my_arr
	puts "Ok, input some FLOAT number:"
	numb = STDIN.gets.chomp.to_f
	return my_arr.sort_by{ |i| (i-numb).abs }[0]
end


# 47 #
=begin
Для введенного списка положительных чисел построить список всех
положительных делителей элементов списка без повторений
[4, 6, 9, 15] -> [1, 2, 3, 4, 5, 6, 9, 15]...
=end
def task_4 my_arr
	t_arr = my_arr.map{ |i| (1..i)}
	t_arr = t_arr.map{ |i| i.select{ |n| (i.max%n==0) } }
	return t_arr.flatten.uniq.sort
end

# 59 #
=begin
Дан список. Построить новый список из квадратов
неотрицательных чисел, меньших 100 и встречающихся в массиве
больше 2 раз.
[-1 2 101 2 102 2 -2 3 -101 -100 3 -3 3 3] -> [4, 9]...
=end
def task_5 my_arr
	# Или не uniq, по заданию? По красоте конечно uniq
	return my_arr.select{ |i| i < 100 && i >= 0 && my_arr.count(i) > 2}.uniq.map{ |i| i*i}
end

def my_main my_arr, num_meth
	case num_meth
	when 1
		print "Еhe only one elem: ", task_1(my_arr)
	when 2
		print "2 min elems: ", task_2(my_arr)
	when 3
		print "Nearest elem: ", task_3(my_arr)
	when 4
		print "Dividers: ", task_4(my_arr)
	when 5
		print "Rectangles: ", task_5(my_arr)
	else
		print "Hey, i haven't such method :("
	end
end

# ARGV[0] - method (1\2\3\4), ARGV[1] - input type (k\f), ARGV[2] - file path
if ARGV.length == 3 then
	if ARGV[1] == "f"
		puts "Reading array from file #{ARGV[2]}..."
		arr = File.read(ARGV[2]).split(' ').map(&:to_i)
		puts "your array: #{arr} #{arr.class} of #{arr[0].class}"
		my_main(arr, ARGV[0].to_i)
	elsif ARGV[1] == "k"
		puts "Huh? there are 3 args, but read from keyboard? Ok, input elems:"
		input_str = STDIN.gets.chomp
		arr = input_str.split(' ').map(&:to_i)
		my_main(arr, ARGV[0].to_i)
	else
		puts "Huh? I don't know such 2-nd arg..."
	end
elsif ARGV.length == 2
	if ARGV[1] == "f"
		puts "Huh? From file? But there's no path..."
	elsif ARGV[1] == "k"
		puts "Ok, input some array elements (SPACE BETWEEN ELEMS!!!):"
		input_str = STDIN.gets.chomp
		arr = input_str.split(' ').map(&:to_i)
		my_main(arr, ARGV[0].to_i)
	else
		puts "Huh? I don't know such 2-nd arg..."
	end
elsif ARGV.length == 1
	if ARGV[0] == "3"
		puts "Ok, doing task 3..."
		puts "Ok, input some FLOAT array elements (SPACE BETWEEN ELEMS!!!):"
		input_str = STDIN.gets.chomp
		arr = input_str.split(' ').map(&:to_f)
		my_main(arr, ARGV[0].to_i)
	else
		puts "Sorry, too less arguments. Try to put 2 (or 3) arguments."
	end
else
	puts "Sorry, too much (less) arguments. Try to put 2 (or 3) arguments."
end
