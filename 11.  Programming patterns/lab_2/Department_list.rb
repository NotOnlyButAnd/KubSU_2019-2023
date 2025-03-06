# подключаем классы
require File.dirname(__FILE__) + "/Department.rb"

class Department_list
    
    # ЗНАЧЕНИЕ ПО УМОЛЧАНИЮ - это просто a=[]? почему он выдает ошибку на равно(
	def initialize (*deps_list)	# конструктор класса
		@departments = deps_list
		@selected_dep_index = nil
	end

	def to_s	# преобразование объекта в строку
		str = "Department list:\n"
		for dep in @departments
			str += dep.to_s + "\n"
		end
		return str
	end

	# надо ли здесь эксепшены прописывать, чи нет?
	def add_note(dep)
		@departments.append(dep)
	end

	# здесь надо бы проверить, а вообще можно ли с таким индексом выбрать запись
	# причем отрицательные индексы тоже учесть
	def choose_note(ind)
		@selected_dep_index = ind
	end

	def change_note(new_dep)
		@departments[@selected_dep_index] = new_dep
	end

	def get_note
		@departments[@selected_dep_index]
	end

	# после удаления надо заново перевыбирать запись, например
	def delete_note
		@departments.delete_at(@selected_dep_index)
		@selected_dep_index = nil
	end

end
