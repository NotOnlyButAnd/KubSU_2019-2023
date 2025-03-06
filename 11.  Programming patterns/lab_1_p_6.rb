# 1 # Делаем без учета переносов строки
path = "F:/Кирилл/003 УНИВЕР/3 курс/004 2 семестр/Ruby/lab_1_p_6.txt"
my_strings = File.readlines(path).map{ |i| i.chomp }.sort_by{|i| i.length}
puts "Sorted by len(str):\n#{my_strings}"

# 2 # Добавил в файл строку а а а а а а, там много "слов" но она короткая
my_strings = my_strings.sort_by{|i| i.split(' ').length}
puts "Sorted by count words:\n#{my_strings}"

# puts "#{'а'.ord}" - ord для получения аски кода символа

# Variant 11. Tasks: 2, 6, 9, 12
# 2 #
=begin
Отсортировать строки в указанном порядке:
В порядке увеличения среднего веса ASCII-кода символОВ? строки
i.split('').length - кол-во символов в строке
i.sum - сумма кодов символов строки
.to_f - чтобы в итоге получилось (если необходимо) число вещественное
=end
def task_1 my_strs
    return my_strs.sort_by{ |i| i.sum.to_f/i.split('').length }
end

puts "Sorted by middle value of str's symbols: #{task_1(my_strings)}"
