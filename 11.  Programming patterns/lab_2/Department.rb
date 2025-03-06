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
		@selected_comm_index = nil
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
