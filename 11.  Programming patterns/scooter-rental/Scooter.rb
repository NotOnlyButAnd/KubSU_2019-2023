require "yaml"

class Scooter
	attr_accessor :id
  	attr_reader :charge
  	attr_accessor :isEnable
    
	def initialize (id, charge, isEnable)	# конструктор класса
		self.id = id
		self.charge = charge	# уровень заряда
		self.isEnable = isEnable	# доступен или нет (были ли ошибки или нет)
	end

	def to_s	# преобразование объекта в строку
		"ID: \"#{self.id}\"; Charge: #{self.charge}; IsEnable: #{self.isEnable}"
	end

	# метод класса проверки корректности номера телефона (простая проверка в международном формате)
	def self.is_correct_charge (val)
		val >= 0 and val <= 100
	end

	# сеттер на номер телефона, с проверкой корректности
	def charge=(val)
		if self.class.is_correct_charge(val)
			@charge = val
		else
			puts val
			raise ArgumentError.new("Charge level is incorrect!")
		end
	end

	# читаем массив объектов Scooter из файла txt
	def self.read_from_txt(path)
		my_objs = []
		for strin in File.readlines(path)
			cur_fields = strin.chomp.split(';')
			my_objs.append(Scooter.new(cur_fields[0], cur_fields[1].to_i, cur_fields[2] == "true"))
		end
		return my_objs
	end

	# МЕТОДЫ ВЫВОДА МАССИВОВ ОДИНАКОВЫЕ (User, Scooter), ЧТО БЫ ТАКОГО СДЕЛАТЬ??
	# печатаем массив объектов Scooter
	def self.print_scooters_arr(us_arr)
		for us in us_arr
			puts us.to_s
		end
	end

	# метод класса для записи массива объектов Scooter sc_list в txt файл
	def self.write_to_txt(sc_list, path)
	    str = ""
	    for sc in sc_list
	        cur_u_s = sc.to_s.gsub(/[\"]|[\[]|[\]]/,'')
	        cur_u_s = cur_u_s.to_s.gsub('ID: ','')
	        cur_u_s = cur_u_s.to_s.gsub(' Charge: ','')
	        cur_u_s = cur_u_s.to_s.gsub(' IsEnable: ','')
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