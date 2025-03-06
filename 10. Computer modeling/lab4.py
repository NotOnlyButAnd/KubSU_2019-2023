import matplotlib.pyplot as plt
import numpy as np


####### 1 #######
# x'=-2x+4y, x(0)=3
def fun_x1(x, y):
    return -2 * x + 4 * y


# y'=-x+3y, y(0)=0
def fun_y1(x, y):
    return -x + 3 * y


####### 2 #######
# x'=y, x(0)=2
def fun_x2(x, y):
    return y


# y'=2y, y(0)=2
def fun_y2(x, y):
    return 2 * y


# подсчет коэффициетов для двух фкункций
def delta(fun_x, fun_y, x, y, h):
    k1 = h * fun_x(x, y)
    l1 = h * fun_y(x, y)

    k2 = h * fun_x(x + k1 / 2.0, y + l1 / 2.0)
    l2 = h * fun_y(x + k1 / 2.0, y + l1 / 2.0)

    k3 = h * fun_x(x + k2 / 2.0, y + l2 / 2.0)
    l3 = h * fun_y(x + k2 / 2.0, y + l2 / 2.0)

    k4 = h * fun_x(x + k3, y + l3)
    l4 = h * fun_y(x + k3, y + l3)

    d_x = (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0
    d_y = (l1 + 2.0 * l2 + 2.0 * l3 + l4) / 6.0
    return d_x, d_y


def runge_kutta(fun_x, fun_y, x0, y0, c_d, h, t0):
    x = [x0]
    y = [y0]
    t = [t0]

    # Считаем координаты
    for i in range(c_d):
        d_x, d_y = delta(fun_x, fun_y, x0, y0, h)
        x0 = x0 + d_x
        y0 = y0 + d_y
        t0 = t0 + h
        x.append(x0)
        y.append(y0)
        t.append(t0)

    return x, y, t


####### точное 1 #######
def exact_x1(t):
    return 4 * np.exp(-t) - np.exp(2 * t)


def exact_y1(t):
    return np.exp(-t) - np.exp(2 * t)


####### точное 2 #######
def exact_x2(t):
    return np.exp(2 * t) + 1


def exact_y2(t):
    return 2 * np.exp(2 * t)


# для отрисовки точного решения
def exact_solution(exact_x, exact_y, t0, b):
    N = 100
    x, y = [], []
    t = np.linspace(t0, b, N)
    for i in t:
        x.append(exact_x(i))
        y.append(exact_y(i))
    return x, y, t


def make_chart(fun_x, fun_y, exact_x, exact_y, x0, y0, t0, c_d, h, title):
    x, y, t = runge_kutta(fun_x, fun_y, x0, y0, c_d, h, t0)
    x1, y1, t1 = exact_solution(exact_x, exact_y, t0, h*c_d)

    fig, ax = plt.subplots()
    ax.plot(t1, x1, label='Точное решение, x(t)')
    ax.plot(t1, y1, label='Точное решение, y(t)')

    ax.plot(t, x, label='Метод Рунге-Кутта \n4 порядка x(t)')
    ax.plot(t, y, label='Метод Рунге-Кутта \n4 порядка y(t)')

    ax.legend(fontsize=12, ncol=2, facecolor='oldlace', edgecolor='green', title_fontsize='12')
    fig.set_figwidth(10)
    fig.set_figheight(10)
    plt.title(title)
    plt.show()


count_dots = 5  # кол-во точек
my_h = 0.1  # шаг
make_chart(fun_x1, fun_y1, exact_x1, exact_y1, 3, 0, 0, count_dots, my_h, "Пример 1")
make_chart(fun_x2, fun_y2, exact_x2, exact_y2, 2, 2, 0, count_dots, my_h, "Пример 2")
