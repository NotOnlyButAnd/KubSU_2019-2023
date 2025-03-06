import numpy as np


def gen_errors(start):
    return np.random.normal(20, 2) + start


def gen_orders(start):
    return np.random.exponential(1) + start


def get_time_details(start):
    return (np.random.rand() * 0.3 + 0.2) + np.random.normal(0.5, 0.1) + start


def err_or_ord_in(start, end, num):
    return start <= num <= end


def get_time_errors(start):
    return (np.random.rand() * 0.4 + 0.1) + start


def is_err_or_ord_one(arr):
    return len(arr) == 1


# счетчики обнулили
time = 0
queue = 0
detail = 0
errors = 0
errors_time = 0

arr_orders = [gen_orders(0)]
arr_errors = [gen_errors(0)]
arr_errors.append(gen_errors(arr_errors[0]))
arr_orders.append(gen_orders(arr_orders[0]))

while detail < 500:
    if queue == 0:
        if arr_errors[0] > arr_orders[0]:
            time = arr_orders[0]
            queue += 1
            if is_err_or_ord_one(arr_orders):
                arr_orders.append(gen_orders(arr_orders[0]))
            arr_orders.pop(0)
            print("Новое задание получено в ", time)
        else:
            new_error = get_time_errors(arr_errors[0])
            if err_or_ord_in(time, new_error, arr_orders[0]):
                while err_or_ord_in(time, new_error, arr_orders[0]):
                    if is_err_or_ord_one(arr_orders):
                        arr_orders.append(gen_orders(arr_orders[0]))
                    queue += 1
                    arr_orders.pop(0)
            errors_time = errors_time + (new_error - arr_errors[0])
            time = new_error
            arr_errors.pop(0)
            arr_errors.append(gen_errors(arr_errors[0]))
            errors += 1
            print("Произошла поломка в ", time)
    else:
        new_details = get_time_details(time)
        if err_or_ord_in(time, new_details, arr_orders[0]):
            while err_or_ord_in(time, new_details, arr_orders[0]):
                if is_err_or_ord_one(arr_orders):
                    arr_orders.append(gen_orders(arr_orders[0]))
                queue += 1
                arr_orders.pop(0)
        if err_or_ord_in(time, new_details, arr_errors[0]):
            new_error = get_time_errors(arr_errors[0])
            if err_or_ord_in(time, new_error, arr_orders[0]):
                while err_or_ord_in(time, new_error, arr_orders[0]):
                    if is_err_or_ord_one(arr_orders):
                        arr_orders.append(gen_orders(arr_orders[0]))
                    queue += 1
                    arr_orders.pop(0)
            errors_time = errors_time + (new_error - arr_errors[0])
            time = new_error
            arr_errors.pop(0)
            arr_errors.append(gen_errors(arr_errors[0]))
            errors += 1
            print("Произошла поломка в ", time)
        else:
            time = new_details
            queue -= 1
            detail += 1
            print("Задание готово в ", time)

print(f"\nВремя работы станка: {time}")
print(f"Кол-во оставшихся заданий в очереди: {queue}")
print(f"Кол-во поломок: {errors}")
print(f"Общее время нахождения в поломках: {errors_time}")
