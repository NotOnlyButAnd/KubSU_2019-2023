#################################
#	LAB 1 PART 2		#
#################################
# 1 #
=begin
if ARGV.length == 1
	input_number = ARGV[0].to_i
else
	puts "Sorry, too much(less) arguments. Try to put only one."
end

puts "your number: #{input_number}"
=end

# sum of number digits
# number_copy is USLESS!
=begin
num_copy = input_number
# puts num_copy.class	# Number? Integer! Fixnum????
sum_dig = 0
while num_copy > 0
	sum_dig += num_copy % 10
  #puts "остаток #{num_copy % 10}"
	num_copy /= 10
  #puts "новое число #{num_copy}"
end
puts "Sum by code: ", sum_dig
=end

# 2 #
# Finding sum of number digits
def sum_of_digits number
	sum_dig = 0
	while number > 0
		sum_dig += number % 10
		number /= 10
	end
	return sum_dig
end

# Finding max nujmber digit
def max_digit number
	max_dig = 0
	while number > 0
		cur_dig = number % 10
		if cur_dig > max_dig
			max_dig = cur_dig
		end
		number /= 10
	end
	return max_dig
end

# Finding min nujmber digit
def min_digit number
	min_dig = 9
	while number > 0
		cur_dig = number % 10
		if cur_dig < min_dig
			min_dig = cur_dig
		end
		number /= 10
	end
	return min_dig
end

# Finding mul of number digits
def mul_of_digits number
	mul_dig = 1
	while number > 0
		mul_dig *= number % 10
		number /= 10
	end
	return mul_dig
end

# 3 #
# main func for task 3 part 2 lab 1
def my_main number, num_meth
	puts "your number: #{number}"
	case num_meth
	when 1
		print "Min digit by fun: ", min_digit(number)
	when 2
		print "Max digit by fun: ", max_digit(number)
	when 3
		print "Sum by function: ", sum_of_digits(number)
	when 4
		print "Mul by function: ", mul_of_digits(number)
	when 5
		print "Count of divider, that is not divide by 3: ", count_div_not_by_3(number)
	when 6
		print "Min uneven (odd) digit: ", min_uneven_dig(number)
	when 7
		print "Sum div, mutually simple with sum dig and !mut simple with mul dig: ", sum_div_mut_simp(number)
	else
		print "Hey, i haven't such method :("
	end
end

# Variant 11
# Finding count of divider, that is not divide by 3
def count_div_not_by_3 number
	count = 0
	for div in 1..number/2
		if number % div == 0 && div % 3 != 0
			count += 1
		end
	end
	if number % 3 != 0
		count += 1
	end
	return count
end

# Finding min uneven (odd) digit
def min_uneven_dig number
	min = 11
	while number > 0
		cur_dig = number % 10
		cur_dig % 2 != 0 ? (cur_dig < min ? min = cur_dig : min) : min # Костыльно??
		number /= 10
	end
	if min == 11
		return -1
	else
		return min
	end
end

# Finding NOD num1 and num2
def my_nod number1, number2
	while number1 != 0 && number2 !=0
		if number1 > number2
			number1 %= number2
		else
			number2 %= number1
		end
	end
	return number1 + number2
end

# Finding sum div, mutually simple with sum dig and !mut simple with mul dig
def sum_div_mut_simp number
	sum_div = 0
	sum_dig = sum_of_digits(number)
	mul_dig = mul_of_digits(number)
	for div in 1..number/2
		if my_nod(div, sum_dig) == 1 && my_nod(div, mul_dig) != 1 && number % div == 0
			sum_div += div
		end
	end
	if my_nod(number, sum_dig) == 1 && my_nod(number, mul_dig) != 1
		sum_div += div
	end
	return sum_div
end

if ARGV.length == 2 then
	# print "So... There are methods:\n1.Min digit\n2.Max digit\n3.Sum digits\n4.Mul digits\n"
	my_main(ARGV[0].to_i, ARGV[1].to_i)
elsif ARGV.length == 1	
	puts "Sorry, too less arguments. Try to put 2 arguments."
elsif ARGV.length == 0
	puts "Hello world!"
else
	puts "Sorry, too much arguments. Try to put 2 arguments."
end
