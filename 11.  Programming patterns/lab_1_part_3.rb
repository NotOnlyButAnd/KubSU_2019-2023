def min_elem_arr my_array
	len = my_array.length
	if len == 0
		return nil
	else
		minim = my_array[0]
		for i in 1..len-1
			if my_array[i] < minim
				minim = my_array[i]
			end
		end
		return minim
	end
end

def max_elem_arr my_array
	len = my_array.length
	if len == 0
		return nil
	else
		maxim = my_array[0]
		for i in 1..len-1
			if my_array[i] > maxim
				maxim = my_array[i]
			end
		end
		return maxim
	end
end

def sum_elem_arr my_array
	len = my_array.length
	if len == 0
		return nil
	else
		sum = 0
		for el in my_array
			sum += el
		end
		return sum
	end
end

def mul_elem_arr my_array
	len = my_array.length
	if len == 0
		return nil
	else
		mul = 1
		for el in my_array
			mul *= el
		end
		return mul
	end
end

# Playing with array...
# puts "#{arr[3]}, #{arr2[0].class}, length: #{arr.length}, ARR: #{arr}"

# 1 #
=begin
arr = [2, 3, 1, 6]
arr2 = []
puts "arr: #{arr}"
puts "min: #{min_elem_arr(arr)}"
puts "max: #{max_elem_arr(arr)}"
puts "sum: #{sum_elem_arr(arr)}"
puts "mul: #{mul_elem_arr(arr)}"
=end


# 2 #
# main func for task 2 part 3 lab 1
def my_main my_arr, num_meth
	puts "your array: #{my_arr} #{my_arr.class} of #{my_arr[0].class}"
	case num_meth
	when 1
		print "Min elem : ", min_elem_arr(my_arr)
	when 2
		print "Max elem : ", max_elem_arr(my_arr)
	when 3
		print "Sum elems : ", sum_elem_arr(my_arr)
	when 4
		print "Mul elems : ", mul_elem_arr(my_arr)
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
	puts "Sorry, too less arguments. Try to put 2 (or 3) arguments."
else
	puts "Sorry, too much (less) arguments. Try to put 2 (or 3) arguments."
end
