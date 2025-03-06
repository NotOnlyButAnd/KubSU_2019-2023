import random
import matplotlib.pyplot as plt
import numpy as np
import math

# function 1 (n = 11)
def f_1(cur_x):
    return round(10 * cur_x / 11, 3)


# function 2 (n = 11)
def f_2(cur_x):
    return round(10 * (cur_x - 20) / -9 + 20, 3)


def is_in_triangle(cur_x, cur_y, intersect = [20.9, 19]):
    if cur_x <= intersect[0]:
        # print(f"{cur_y}; {f_1(cur_x)}")
        if cur_y < f_1(cur_x) and cur_y > 0:
            return True
        else:
            return False
    else:
        # print(f"{cur_y}; {f_2(cur_x)}")
        if cur_y < f_2(cur_x) and cur_y > 0:
            return True
        else:
            return False


def is_in_fun_2(cur_x, cur_y):
    if 0 <= cur_x <= 7:
        if cur_y < fun_task_2(cur_x) and cur_y > 0:
            return True
        else:
            return False
    else:
        return False


def is_in_circle(cur_x, cur_y):
    if 0 <= cur_x <= 22  and cur_y > 0:
        if math.pow(cur_x - 11, 2) + math.pow(cur_y - 11, 2) < 121:
            return True
        else:
            return False
    else:
        return False


def square_7(M_points, N_points, a_rect, b_rect):
    return round(M_points / N_points * a_rect * b_rect, 3)


def square_5(N_points, a_rect, intersect = [20.9, 19]):
    sum = 0
    step = a_rect / N_points
    print(f"\nStep: {step}")
    cur_x = 0
    for i in range(N_points):
        if cur_x <= intersect[0]:
            sum += f_1(cur_x)
            cur_x += step
        else:
            sum += f_2(cur_x)
            cur_x += step
    return round(a_rect / N_points * sum, 3)


def draw_graphics(x_points, y_points, a_rect, b_rect):
    # рисуем графики
    x = np.linspace(0, a_rect, num=100)  # Точки по которым строятся графики
    y_rect = np.linspace(0, b_rect, num=100)
    fig, ax = plt.subplots()

    my_f_1 = 10 * x / 11
    my_f_2 = 10 * (x - 20) / -9 + 20
    rect_x = [a_rect] * 100
    rect_y = [b_rect] * 100

    ax.plot(x, my_f_1, label=f"f(x) = 10 * x / 11")
    ax.plot(x, my_f_2, label=f"f(x) = 10 * (x - 20) / -9 + 20")
    ax.plot(x, rect_y)
    ax.plot(rect_x, y_rect)

    ax.legend(fontsize=13,
              ncol=1,  # Количество столбцов
              facecolor='yellowgreen',  # Цвет области
              edgecolor='green',  # Цвет грани
              title='Функции',  # Заголовок
              title_fontsize='18',  # Размер шрифта заголовка
              loc="upper right" # местонахождение
              )

    fig.set_figwidth(12)
    fig.set_figheight(12)

    for i in range(len(x_points)):
        if is_in_triangle(x_points[i], y_points[i]):
            plt.scatter(x_points[i], y_points[i], s=20, color='blue')  # scatter - метод для нанесения маркера в точке
        else:
            plt.scatter(x_points[i], y_points[i], s=20, color='black')

    plt.axhline(y = 0, color = 'k')
    plt.axvline(x = 0, color = 'k')
    plt.show()


def fun_task_2(cur_x):
    return round(math.sqrt(29 - 11 * math.pow((math.cos(cur_x)), 2)), 3)


def draw_graphics_2(x_points, y_points, a_rect, b_rect):
    # рисуем графики
    x = np.linspace(0, a_rect, num=100)  # Точки по которым строятся графики
    y_rect = np.linspace(0, b_rect, num=100)
    fig, ax = plt.subplots()

    my_f_1 = np.sqrt(29 - 11 * np.power((np.cos(x)), 2))
    rect_x = [a_rect] * 100
    rect_y = [b_rect] * 100

    ax.plot(x, my_f_1, label=f"f(x) = sqrt(29 - 11 * cos^2(x))")
    ax.plot(x, rect_y)
    ax.plot(rect_x, y_rect)

    fig.legend(fontsize=13,
              ncol=1,  # Количество столбцов
              facecolor='yellowgreen',  # Цвет области
              edgecolor='green',  # Цвет грани
              title='Функции',  # Заголовок
              title_fontsize='18',  # Размер шрифта заголовка
              loc="upper right" # местонахождение
              )

    fig.set_figwidth(12)
    fig.set_figheight(12)

    for i in range(len(x_points)):
        if is_in_fun_2(x_points[i], y_points[i]):
            plt.scatter(x_points[i], y_points[i], s=20, color='blue')  # scatter - метод для нанесения маркера в точке
        else:
            plt.scatter(x_points[i], y_points[i], s=20, color='black')

    plt.axhline(y = 0, color = 'k')
    plt.axvline(x = 0, color = 'k')
    plt.show()


def draw_graphics_3(x_points, y_points, a_rect, b_rect):
    # рисуем график
    x = np.linspace(0, 2 * np.pi, num=150)  # Точки по которым строится график
    y_rect = np.linspace(0, b_rect, num=150)
    fig, ax = plt.subplots()

    my_circle_x = 11 + 11 * np.cos(x)
    my_circle_y = 11 + 11 * np.sin(x)
    rect_x = [a_rect] * 150
    rect_y = [b_rect] * 150

    ax.plot(my_circle_x, my_circle_y, label=f"x = 11+11cos(phi); y = 11+11sin(phi);")
    ax.plot(y_rect, rect_y)
    ax.plot(rect_x, y_rect)

    fig.legend(fontsize=13,
              ncol=1,  # Количество столбцов
              facecolor='yellowgreen',  # Цвет области
              edgecolor='green',  # Цвет грани
              title='Функции',  # Заголовок
              title_fontsize='18',  # Размер шрифта заголовка
              loc="upper right" # местонахождение
              )

    fig.set_figwidth(9)
    fig.set_figheight(9)

    for i in range(len(x_points)):
        if is_in_circle(x_points[i], y_points[i]):
            plt.scatter(x_points[i], y_points[i], s=20, color='blue')
        else:
            plt.scatter(x_points[i], y_points[i], s=20, color='black')  # scatter - метод для нанесения маркера в точке

    plt.axhline(y = 0, color = 'k')
    plt.axvline(x = 0, color = 'k')
    plt.show()


def ro_fun(cur_phi, A, B):
    return np.sqrt(A * np.power(np.cos(cur_phi), 2) + b * np.power(np.sin(cur_phi), 2))


def r_i(cur_x, cur_y):
    return np.sqrt(np.power(cur_x, 2) + np.power(cur_y, 2))


def phi_i(cur_x, cur_y):
    if cur_x > 0:
        return np.arctan(cur_y/cur_x)
    elif cur_x < 0:
        return np.pi + np.arctan(cur_y / cur_x)
    elif cur_x == 0 and cur_y > 0:
        return np.pi / 2
    elif cur_x == 0 and cur_y < 0:
        return - np.pi / 2
    elif cur_x == 0 and cur_y == 0:
        return 0
    else:
        return "Error"


def is_in_polar(cur_x, cur_y, A, B):
    if r_i(cur_x, cur_y) < ro_fun(phi_i(cur_x, cur_y), A, B):
        return True
    else:
        return False


# Task 1 #
print("-----------\nTASK 1\n-----------\n")
n = 11

# точка пересечения f_1 и f_2 [x, y]
inter_point = [20.9, 19]
print(f"f_1 intersect f_2: [{inter_point[0]}, {inter_point[1]}]")

# точка пересечения f_1 и y
# f_1_y = round(f_1(0), 3)
# print(f"f_1 intersect y: [0, {f_1_y}]")

# точка пересечения f_2 и y
# f_2_y = round(f_2(0), 3)
# print(f"f_2 intersect y: [0, {f_2_y}]")

# точка пересечения f_1 и x
f_1_x = 0
f_2_x = 38

# следовательно прямоугольник будет иметь размеры (a - по x, b - по y)
# 1 - абсцисса точки пересечения 2 графика с OX, 2 - ордината точки пересечения графиков
a, b = f_2_x, inter_point[1]
print(f"Rectangle size: {a}, {b}\n")

#####
# строим графики и прямоугольник
#####

# print(f"Is [5, 30] in triangle? -> {is_in_triangle(5, 30)}")
# print(f"Is [30, 5] in triangle? -> {is_in_triangle(30, 5)}")

print("Input amount N of random points: ")
N = int(input())

# создаем рандомные точки в пределах прямоугольника
rand_x = []
rand_y = []

for i in range(N):
    rand_x.append(round(random.uniform(0, a), 3))
    rand_y.append(round(random.uniform(0, b), 3))

# считаем кол-во точек рандомных, лежащих в треугольнике
M = 0
for i in range(N):
    M += 1 if is_in_triangle(rand_x[i], rand_y[i]) else 0
print(f"M = {M}\n")

# вычисляем площадь
sq_7 = square_7(M, N, a, b)
print(f"Square by 7 formula: {sq_7}")
print(f"Accurate square: 361")

# формула 5 которая всегда выдает точный результат одинаковый
# sq_5 = square_5(N, a)
# print(f"Square by 5 formula: {sq_5}")

# считаем погрешности
abs_err = round(abs(361 - sq_7), 3)
rel_err = round(abs_err / sq_7, 3)
print(f"\nAbsolute error: {abs_err}\nRelative error: {rel_err}\n")

# рисуем график
draw_graphics(rand_x, rand_y, a, b)

print("\nContinue?")
input()

# Task 2 #
print("-----------\nTASK 2\n-----------\n")

# прямоугольник - по х и у
# max по y - 5,385 => можно взять прямоугольник 5.5
a_2, b_2 = 7, 5.5
print(f"Rectangle size: {a_2}, {b_2}\n")

print("Input amount N of random points: ")
N = int(input())

# создаем рандомные точки в пределах прямоугольника
rand_x = []
rand_y = []

for i in range(N):
    rand_x.append(round(random.uniform(0, a_2), 3))
    rand_y.append(round(random.uniform(0, b_2), 3))

# считаем кол-во точек рандомных, лежащих под графиком
M = 0
for i in range(N):
    M += 1 if is_in_fun_2(rand_x[i], rand_y[i]) else 0
print(f"M = {M}\n")

# вычисляем площадь
sq_7 = square_7(M, N, a_2, b_2)
print(f"Square by 7 formula: {sq_7}")
print("Accurate square: 33.532")

# считаем погрешности (значение интеграла из онлайн калькулятора)
abs_err = round(abs(33.532 - sq_7), 3)
rel_err = round(abs_err / sq_7, 3)
print(f"\nAbsolute error: {abs_err}\nRelative error: {rel_err}\n")

# рисуем график
draw_graphics_2(rand_x, rand_y, a_2, b_2)

print("\nContinue?")
input()

# Task 3 #
print("-----------\nTASK 3\n-----------\n")

# R = n = 11!!! прямоугольник - 2*R - 22
a_3, b_3 = 22, 22
print(f"Rectangle size: {a_3}, {b_3}\n")

print("Input amount N of random points: ")
N = int(input())

# создаем рандомные точки в пределах прямоугольника
rand_x = []
rand_y = []

for i in range(N):
    rand_x.append(round(random.uniform(0, a_3), 3))
    rand_y.append(round(random.uniform(0, b_3), 3))

# считаем кол-во точек рандомных, лежащих под графиком
M = 0
for i in range(N):
    M += 1 if is_in_circle(rand_x[i], rand_y[i]) else 0
print(f"M = {M}\n")

my_pi = 4 * M / N
print(f"My PI = {my_pi}")
print("PI: 3,1415926535")

draw_graphics_3(rand_x, rand_y, a_3, b_3)

print("\nContinue?")
input()

# Task 4 #
print("-----------\nTASK 4\n-----------\n")

# т.к. n = 11 >= 11:
A = n + 10
B = n - 10

# [0; 2pi] - составили значения фи
phi = np.linspace(0, 2 * np.pi, num=150)

# определяем x и y
x_4 = []
y_4 = []
for i in range(len(phi)):
   x_4.append(ro_fun(phi[i], A, B) * np.cos(phi[i]))
   y_4.append(ro_fun(phi[i], A, B) * np.sin(phi[i]))

x_4_min = round(min(x_4), 3)
x_4_max = round(max(x_4), 3)
y_4_min = round(min(y_4), 3)
y_4_max = round(max(y_4), 3)

print(f"X min max: {x_4_min}; {x_4_max}\nY min max: {y_4_min}; {y_4_max}")

print("\nInput amount N of random points: ")
N = int(input())

# создаем рандомные точки в пределах прямоугольника
rand_x = []
rand_y = []

for i in range(N):
    rand_x.append(round(random.uniform(x_4_min, x_4_max), 3))
    rand_y.append(round(random.uniform(y_4_min, y_4_max), 3))


# считаем кол-во точек рандомных, лежащих под графиком
M = 0
for i in range(N):
    M += 1 if is_in_polar(rand_x[i], rand_y[i], A, B) else 0
print(f"M = {M}\n")

sq_7 = square_7(M, N, x_4_max - x_4_min, y_4_max - y_4_min)
print(f"Square by 7 formula: {sq_7}")
print("Accurate square: 63.585")


fig, ax = plt.subplots()

# график рисуем
ax.plot(x_4, y_4, label=f"ro^2 = {A}cos^2(phi) + {B}sin^2(phi);")

fig.legend(fontsize=13,
              ncol=1,  # Количество столбцов
              facecolor='yellowgreen',  # Цвет области
              edgecolor='green',  # Цвет грани
              title='Функции',  # Заголовок
              title_fontsize='18',  # Размер шрифта заголовка
              loc="upper right" # местонахождение
              )

fig.set_figwidth(9)
fig.set_figheight(9)

# точки рисуем
for i in range(len(rand_x)):
    if is_in_polar(rand_x[i], rand_y[i], A, B):
        plt.scatter(rand_x[i], rand_y[i], s=20, color='blue')
    else:
        plt.scatter(rand_x[i], rand_y[i], s=20, color='black')

# прямоугольник рисуем
ax.plot([x_4_min, x_4_max, x_4_max, x_4_min, x_4_min], [y_4_max, y_4_max, y_4_min, y_4_min, y_4_max])

plt.axhline(y = 0, color = 'k')
plt.axvline(x = 0, color = 'k')
plt.show()
