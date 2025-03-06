#################################
#			  LAB 1				#
#################################

# 1 #
# Hello World in Ruby + Comment
puts "Hello, slaves!"
# puts - ставит в конце символ новой строки
# print - не делает этого

# 2.1 #
# Welcome the user by name from command line
if ARGV.length == 1
	puts "Ky-ky, #{ARGV[0]}"
else
	puts "Sorry, too much(less) arguments. Try to put only one."
end

puts "#{ARGV}"

# 2.2 #
# Welcome the user
# puts "What's your name? (⌐■_■)"

# input_name = gets

# puts "Ky-ky, #{input_name}"


# 3 #
# About language...
puts "\nWhat's your favourite language (programming, of course)?"

input_language = STDIN.gets
inp_down = input_language.chomp.downcase

# 3.1 #
# if inp_down == 'ruby' then
# 	puts "Oh, what's a toady!"
# elsif inp_down == 'c#'
# 	puts "Ruby will be soon... But Windows apps is cool"
# elsif inp_down == "java"
# 	puts "Ruby will be soon... However, your pain is too hard"
# elsif inp_down == "sql"
# 	puts "Ruby will be soon... And your database will die"
# else
# 	puts "Ruby will be soon... And please, learn some other language"
# end

# проверка "типа" объектов
# puts "\nNOT downcase - #{input_language.class}, down - #{inp_down.class}"

# 3.2 #
# unless inp_down != 'ruby' then
# 	puts "Oh, what's a toady!"
# else
# 	puts "Ruby will be soon... And please, learn some other language"
# 	if 	inp_down == 'c#'
# 		puts "/But Windows apps is cool/"
# 	elsif inp_down == "java"
#  		puts "/However, your pain is too hard/"
# 	elsif inp_down == "sql"
# 	 	puts "/And your database will die/"
# 	end
# end

# 3.3 #
case inp_down
	when 'ruby'
		puts "Oh, what's a toady!"
	when 'c#'
		puts "Ruby will be soon... But Windows apps is cool"
	when "java"
		puts "Ruby will be soon... However, your pain is too hard"
	when "sql"
		puts "Ruby will be soon... And your database will die"
	else
		puts "Ruby will be soon... And please, learn some other language"
end

# 4 #	 	
# About RUBY command...
puts "\nPlease, input some Ruby command"
inp_ruby_com = STDIN.gets.chomp
puts "Result: "
eval(inp_ruby_com)	# интрепретирует строку как код на Ruby, напр: puts "Hey you..."

# About OS command...
puts "\nPlease, input some OS command"
inp_os_com = STDIN.gets.chomp
puts "Result: "
exec inp_os_com	# выполняет команду системы, напр: help
				# тут можно использовать system inp_os_com, вроде как она в подоболочке запустится
