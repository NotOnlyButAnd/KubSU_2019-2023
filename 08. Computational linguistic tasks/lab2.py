from pymorphy2 import MorphAnalyzer


def write_file(filename, text_list):
    file = open(filename, 'w')
    for item in text_list:
        file.write(str(item))
        file.write('\n')
    file.close()


def hasAnyDigit(str):
    return any (substr.isdigit() for substr in str)


def hasAnySpace(str):
    return any (substr.isspace() for substr in str)

# пример 1. Разбор слова
# morph = MorphAnalyzer()
# print(morph.parse('стали'))

# пример 2, 3. Получение нормальной формы и тэга
# morph = MorphAnalyzer()
# p = morph.parse('стали')[0]
# print(p.normal_form)    # нормалная
# print(p.normalized)     # форма
# print(p.tag)    # тэг. содержит инфу о слове: глагол, вид, число, время и тд - это все граммемы

# пример 4. Разбор несловарного слова
# работает на основе предсказателя, применяемого автоматически
# morph = MorphAnalyzer()
# print(morph.parse('бутявкоедами'))

# пример 5. Проверка, есть ли в теге граммема или все граммемы из сн-ва
# morph = MorphAnalyzer()
# p = morph.parse('стали')[0]
# print('HI!!!')
# print('VERB' in p.tag)
# print('NOUN' in p.tag)
# print({'plur', 'past'} in p.tag)
# print({'NOUN', 'plur'} in p.tag)

# пример 6. Получение характеристик слова. (None если не определена)
# morph = MorphAnalyzer()
# p = morph.parse('стали')[0]
# # часть речи
# print(p.tag.POS) # VERB
# # одушевленность
# print(p.tag.animacy) # None
# # вид: совершенный или несовершенный
# print(p.tag.aspect) # perf
# # падеж
# print(p.tag.case) # None
# # род (мужской, женский, средний)
# print(p.tag.gender) # None
# # включенность говорящего в действие
# print(p.tag.involvement) # None
# # наклонение (повелительное, изъявительное)
# print(p.tag.mood) # indc
# # число (единственное, множественное)
# print(p.tag.number) # plur
# # лицо (1, 2, 3)
# print(p.tag.person) # None
# # время (настоящее, прошедшее, будущее)
# print(p.tag.tense) # past
# # переходность (переходный, непереходный)
# print(p.tag.transitivity) # intr
# # залог (действительный, страдательный)
# print(p.tag.voice) # None

# пример 7. недопустимая граммема
# morph = MorphAnalyzer()
# p = morph.parse('стали')[0]
# print('foobar' in p.tag) # ValueError: Grammeme is unknown: foobar
# print({'NOUN', 'foo', 'bar'} in p.tag) # ValueError: Grammemes are unknown: {'bar', 'foo'}

# пример 8. недопустимый атрибут
# morph = MorphAnalyzer()
# p = morph.parse('стали')[0]
# print(p.tag.POS == 'plur') # 'plur' is not a valid grammeme for this attribute


# пример 9. Разбор слова
# morph = MorphAnalyzer()
# butyavka = morph.parse('бутявка')[0]
# print(butyavka)

# пример 10. Склонение
# morph = MorphAnalyzer()
# butyavka = morph.parse('бутявка')[0]
# # нет кого? (родительный падеж)
# print(butyavka.inflect({'gent'}))
# # кого много?
# print(butyavka.inflect({'plur', 'gent'}))

# пример 11. Лексема слова
# morph = MorphAnalyzer()
# butyavka = morph.parse('бутявка')[0]
# print(butyavka.lexeme)

# пример 12. Постановка слов в начальную форму
# ищет начальную форму с минимальными затратами по времени
# m = MorphAnalyzer()
# print(m.parse('думающий')[0].normal_form)

# пример 13. Склонение слов
# со склонением
# m = MorphAnalyzer()
# print(m.parse('топать')[0].inflect({'sing', 'nomn'}).word)

# пример 14. формы в зависимости от числительного
# morph = MorphAnalyzer()
# butyavka = morph.parse('бутявка')[0]
# print(butyavka.make_agree_with_number(1).word) # бутявка
# print(butyavka.make_agree_with_number(6).word) # бутявки
# print(butyavka.make_agree_with_number(22).word) # бутявки

print("Вас приветствует морфологический анализатор!\n\nВведите слово, которое хотите анализировать: ")
word = input()
# анализируем введенную строку, это рил слово (хотя б примитивно)
flag = True  # флаг для цикла ввода

while flag:
    if not hasAnySpace(word) and not hasAnyDigit(word):
        print(f"Ok, ваше слово: {word}")
        ####################
        # обрабатываем слово
        ####################
        morph = MorphAnalyzer()
        print("\nКакое действие хотите выполнить?"
              "\n1 - полная информация по каждому из предполагаемых разборов слова"
              "\n2 - нормальная форма слова"
              "\n3 - часть речи, род, число, лицо, время (если хар-ки нет: None)"
              "\n4 - просклонять слово (падежи)"
              "\n5 - разные формы в зависимости от числительного")
        choice = int(input())
        if choice == 1:
            print('\nМинуту, сейчас сделаю...')
            full_analysis_word = morph.parse(word)
            for i in full_analysis_word:
                print(i)
        elif choice == 2:
            print('\nМинуту, сейчас сделаю...')
            analysis_word = morph.parse(word)[0]
            print(analysis_word.normal_form)    # нормалная форма слова - одно слово
            print(analysis_word.normalized)     # разбор нормальной формы - ТЕГ, граммемы
        elif choice == 3:
            print('\nМинуту, сейчас сделаю...')
            analysis_word = morph.parse(word)[0]
            print(f"Слово: {word}; часть речи: {analysis_word.tag.POS}, род: {analysis_word.tag.gender},"
                  f" число: {analysis_word.tag.number}, лицо: {analysis_word.tag.person}, время: {analysis_word.tag.tense}")
        elif choice == 4:
            print('\nМинуту, сейчас сделаю...')
            cases = {'nomn': 'именительный', 'gent': 'родительный', 'datv': 'дательный', 'accs': 'винительный',
                     'ablt': 'творительный', 'loct': 'предложный'}  # падежи
            analysis_word = morph.parse(word)[0]
            print(f"Слово {word}. Падежируем...")
            for k, v in cases.items():
                print(f"{v}: {analysis_word.inflect({k})[0]}")
        elif choice == 5:
            print('\nМинуту, сейчас сделаю...')
            print(f"Слово {word}. Падежируем...")
            analysis_word = morph.parse(word)[0]
            for i in range(0, 6):
                print(f"Число {i} - {analysis_word.make_agree_with_number(i).word}")
        else:
            print('\nТакой команды я не знаю :-(')
        flag = False
    else:
        print("Кажется, с вашим словом что-то не так, повторите ввод...")
        word = input()
