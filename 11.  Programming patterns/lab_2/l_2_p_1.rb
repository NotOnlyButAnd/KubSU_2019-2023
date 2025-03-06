require "yaml"

class Department
	attr_accessor :name
  	attr_reader :phone
    
	def initialize (name, phone, *commitments)	# конструктор класса
		self.name = name	# поле объекта
		self.phone = phone
		@commitments = commitments
		@selected_comm_index = nil
	end

	# плохой геттер, лучше не получать массив целиком
	#def getCommitments	# Геттер на обязанности (целиком на массив)
	#	@commitments
	#end

	def to_s	# преобразование объекта в строку
		"Department: \"#{self.name}\"; Contact phone: #{self.phone}; Commitments: #{@commitments}"
	end

	def add_commitment(commitment)	# добавление обязанности
		@commitments.append(commitment)
	end

	def select_commitment_by_index(commitment_index)	# Выбор обязанности по индексу
		@selected_comm_index = commitment_index
	end

	def delete_selected_commitment	# удаление выделенной обязанности
		@commitments.delete_at(@selected_comm_index)
		# @selected_comm_index = 0
	end

	def get_selected_comm_text		# получение текста выделенной обязанности
		@commitments[@selected_comm_index]
	end

	def change_selected_comm_text(val)		# изменение текста выделенной обязанности
		@commitments[@selected_comm_index] = val
	end

	def get_commitments_info	# all commitments in string
		t_s = "Commitments of \"#{self.name}\": "
		@commitments.each { |x| t_s = t_s + x + "; "}
		return t_s
	end

	# метод класса проверки корректности номера телефона (простая проверка в международном формате)
	def self.is_correct_phone (val)
		/^((\+7)+([0-9]){10})$/.match(val).to_s == val
	end

	def phone=(val)
		if self.class.is_correct_phone(val)
			@phone = val
		else
			raise ArgumentError.new("Phone number is incorrect!")
		end
	end

	def self.read_from_txt(path)
		my_objs = []
		for strin in File.readlines(path)
			cur_fields = strin.chomp.split(';')
			my_objs.append(Department.new(cur_fields[0], cur_fields[1], *cur_fields[2].split(', ')))
		end
		return my_objs
	end

	def self.print_deps_arr(deps_arr)
		for dep in deps_arr
			puts dep.to_s
		end
	end

	# метод класса для записи массива объектов Department dep_list в txt файл
	def self.write_to_txt(dep_list, path)
	    str = ""
	    for dep in dep_list
	        cur_d_s = dep.to_s.gsub(/[\"]|[\[]|[\]]/,'')
	        cur_d_s = cur_d_s.to_s.gsub('Department: ','')
	        cur_d_s = cur_d_s.to_s.gsub(' Contact phone: ','')
	        cur_d_s = cur_d_s.to_s.gsub(' Commitments: ','')
	        str += cur_d_s + "\n"  # удалили все ненужные символы + на новую строку
	    end
	    file = File.new("./#{path}", "w:UTF-8")
	    file.print(str)
	    file.close()
	    return "#{path}"
	end

	def self.write_to_YAML(dep_list, path)
	    File.open( path, 'w' ) do |out|
  			YAML.dump( dep_list, out )
		end
	    return path
	end

	def self.read_from_YAML(path)
	    return File.open( "dep_data.yaml" ) { |yf| YAML::load( yf ) }
	end

end

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
dep_list_yaml.append(dep_3)
print "\nDep list were writed to ", Department.write_to_YAML(dep_list_yaml, "dep_data.yaml"), "\n"
dep_list_yaml = Department.read_from_YAML("dep_data.yaml")
Department.print_deps_arr(dep_list_yaml)
