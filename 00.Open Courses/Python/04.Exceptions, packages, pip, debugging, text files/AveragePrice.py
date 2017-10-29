sum = 0
counter_lines = 0

#
try:
    with open("././catalog_sample.csv") as file:
        for line in file:
            price = float(line[line.rindex(',') + 1:].strip())
            sum += price
            counter_lines += 1

    average_price = sum / counter_lines

    print("Average price is: {:.2f}".format(average_price))

except FileNotFoundError:
    print("Incorrect file path")
