import matplotlib.pyplot as plt

# Метод квадратов
# Вход: num - исходное число (INTEGER), n - кол-во повторений (INTEGER)
# Выход: random_numbers - массив сгенерированных (Array of Float)
def squares_method(num, n):
    random_numbers = []
    capacity = len(str(num))  # Разрядность числа

    for i in range(n):
        num_2 = str(num ** 2)

        # Незначащие нули в начале, если необходимо
        while len(num_2) != capacity * 2:
            num_2 = "0" + num_2

        # Берем только n средних разрядов
        new_num = num_2[int(capacity - capacity/2):int(capacity + capacity/2)]

        # Добавляем полученное случайное число в массив
        random_numbers.append(float("0." + new_num))

        num = int(new_num)

    plt.hist(random_numbers, color='green', edgecolor='black',
             bins=20)

    plt.title('Метод квадратов')
    plt.xlabel('Значение')
    plt.ylabel('Частота')
    plt.show()

    return random_numbers


# Метод произведений
# Вход: num - исходное число (INTEGER), core - ядро (INTEGER), n - кол-во повторений (INTEGER)
# Выход: random_numbers - массив сгенерированных (Array of Float)
def mul_method(num, core, n):
    random_numbers = []
    capacity = len(str(num))  # Разрядность числа

    for i in range(n):

        num_2 = str(int(num) * core)

        # Незначащие нули в начале, если необходимо
        while len(num_2) != capacity * 2:
            num_2 = "0" + num_2

        # Берем только n средних разрядов
        new_num = num_2[int(capacity - capacity / 2):int(capacity + capacity / 2)]

        # Добавляем полученное случайное число в массив
        random_numbers.append(float("0." + new_num))

        num = num_2[-capacity:]

    plt.hist(random_numbers, color='green', edgecolor='black',
             bins=20)

    plt.title('Метод произведений')
    plt.xlabel('Значение')
    plt.ylabel('Частота')
    plt.show()

    return random_numbers


# Мультипликативный конгруэнтный метод
def mul_congruent_method(num, multiplier, divider, n):
    random_numbers = []

    for i in range(n):
        new_num = num * multiplier % divider  # Берем остаток

        # Добавляем полученное случайное число в массив
        random_numbers.append(float("0." + str(new_num)))

        num = new_num

    plt.hist(random_numbers, color='green', edgecolor='black',
             bins=20)

    plt.title('Метод мультипликативный конгруэнтный')
    plt.xlabel('Значение')
    plt.ylabel('Частота')
    plt.show()

    return random_numbers


def shacked_cong_method(num, multiplier, divider, n, c):
    random_numbers = []

    for i in range(n):
        new_num = (num * multiplier + c) % divider  # Получаем остаток

        # Добавляем полученное случайное число в массив
        pull = '0.' + str(new_num)
        random_numbers.append(round(float(pull), 4))

        num = new_num

    plt.hist(random_numbers, color='green', edgecolor='black',
             bins=20)

    plt.title('Метод смешанный конгруэнтный')
    plt.xlabel('Значение')
    plt.ylabel('Частота')
    plt.show()

    return random_numbers


def main():
    n = 1500  # Количество повторений

    # Метод квадратов, исходные данные и вызов
    # num = 1357  # Исходное число плохое
    num = 7153  # Исходное число (тоже не очень уж крутое для большого числа)
    print(f"Generating square's method...")
    squares_method(num, n)

    # Метод произведений, исходные данные и вызов
    num = 3729  # Исходное число
    core = 5167     # Ядро
    print(f"Generating mul's method...")
    mul_method(num, core, n)

    # Мультипликативный конгруэнтный метод, исходные данные и вызов
    num = 1357  # Исходное число
    multiplier = 1357   # Множитель
    divider = 5689  # Делитель
    print(f"Generating mul congruent method...")
    mul_congruent_method(num, multiplier, divider, n)

    # Смешанный конгруэнтный метод, исходные данные и вызов
    num = 1357  # Исходное число
    multiplier = 106  # Множитель
    divider = 6075  # Делитель
    c = 1283  # Аддитивная константа
    print(f"Generating shacked congruent method...")
    shacked_cong_method(num, multiplier, divider, n, c)


if __name__ == '__main__':
    main()
