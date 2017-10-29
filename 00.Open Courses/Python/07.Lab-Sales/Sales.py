from decimal import Decimal
from datetime import timezone
import iso8601

counter_lines = 0
sum_sales = Decimal(0)

with open("sales-10K.csv") as file:
    for line in file:
        current_price = Decimal(line[line.rindex(',') + 1:].strip())
        sum_sales += current_price
        counter_lines += 1
        sale_timestamp_min = None
        sale_timestamp_max = None
        arguments = line.split(',')
        datetime = arguments[3].strip('\"')
        sale_timestamp = iso8601.parse_date(str(datetime))
        sale_timestamp = sale_timestamp.astimezone(timezone.utc)

        # TODO: Fix the dates
        if sale_timestamp_min is None or sale_timestamp < sale_timestamp_min:
            sale_timestamp_min = sale_timestamp
        if sale_timestamp_max is None or sale_timestamp > sale_timestamp_max:
            sale_timestamp_max = sale_timestamp

    average_price = sum_sales / counter_lines
    print("""
    Обобщение
    ---------"
    Общ брой продажби: {}
    Общо сума продажби: {} €
    Средна цена на продажба: {} €
    Начало на период на данните: {}
    Край на период на данните: {}
    """.format(counter_lines, sum_sales, average_price, sale_timestamp_min, sale_timestamp_max))
