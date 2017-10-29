all_sales = dict()

try:
    with open(".\\.\\sales.csv") as file:
        for line in file:
            string_args = line.split()
            string_date = string_args[0]
            string_price = string_args[1].split(",")
            price = all_sales[string_date]
            all_sales[string_date] = price + string_price[1]
        key, value = max(all_sales.iteritems(), key=lambda x: x[1])

except FileNotFoundError:
    print("File is not found")

