require "yaml"

class User
	attr_accessor :login
  	attr_reader :phone
    
	def initialize (login, phone)	# конструктор класса
		self.login = login	# поле объекта
		self.phone = phone
	end

	def to_s	# преобразование объекта в строку
		"Login: \"#{self.login}\"; Contact phone: #{self.phone};"
	end

	# метод класса проверки корректности номера телефона (простая проверка в международном формате)
	def self.is_correct_phone (val)
		/^((\+7)+([0-9]){10})$/.match(val).to_s == val
	end

	# сеттер на номер телефона, с проверкой корректности
	def phone=(val)
		if self.class.is_correct_phone(val)
			@phone = val
		else
			raise ArgumentError.new("Phone number is incorrect!")
		end
	end

	# читаем массив объектов User из файла txt
	def self.read_from_txt(path)
		my_objs = []
		for strin in File.readlines(path)
			cur_fields = strin.chomp.split(';')
			my_objs.append(User.new(cur_fields[0], cur_fields[1]))
		end
		return my_objs
	end

	# печатаем массив объектов User
	def self.print_users_arr(us_arr)
		for us in us_arr
			puts us.to_s
		end
	end

	# метод класса для записи массива объектов User us_list в txt файл
	def self.write_to_txt(us_list, path)
	    str = ""
	    for us in us_list
	        cur_u_s = us.to_s.gsub(/[\"]|[\[]|[\]]/,'')
	        cur_u_s = cur_u_s.to_s.gsub('Login: ','')
	        cur_u_s = cur_u_s.to_s.gsub(' Contact phone: ','')
	        str += cur_u_s + "\n"  # удалили все ненужные символы + на новую строку
	    end
	    file = File.new("./#{path}", "w:UTF-8")
	    file.print(str)
	    file.close()
	    return "#{path}"
	end

	# запись в YAML
	def self.write_to_YAML(us_list, path)
	    File.open( path, 'w' ) do |out|
  			YAML.dump( us_list, out )
		end
	    return path
	end

	# чтение из YAML
	def self.read_from_YAML(path)
	    return File.open( path ) { |yf| YAML::load( yf ) }
	end

end