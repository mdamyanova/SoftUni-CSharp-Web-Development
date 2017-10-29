sum_kids = 0
counter_lines_kids = 0
average_price_kids = 0

sum_men = 0
counter_lines_men = 0
average_price_men = 0

sum_women = 0
counter_lines_women = 0
average_price_women = 0

sum_unisex = 0
counter_lines_unisex = 0
average_price_unisex = 0

#
try:
    with open("././catalog_full.csv") as file:
        for line in file:
            price = float(line[line.rindex(',') + 1:].strip())
            if 'Kid' in line:
                sum_kids += price
                counter_lines_kids += 1
            elif 'Men' in line:
                sum_men += price
                counter_lines_men += 1
            elif 'Woman' in line:
                sum_women += price
                counter_lines_women += 1
            elif 'Unisex' in line:
                sum_unisex += price
                counter_lines_unisex += 1

    average_price_kids = sum_kids / counter_lines_kids
    average_price_men = sum_men / counter_lines_men
    average_price_women = sum_women / counter_lines_women
    average_price_unisex = sum_unisex / counter_lines_unisex

    print("Average price for kids is: {:.2f}".format(average_price_kids))
    print("Average price for men is: {:.2f}".format(average_price_men))
    print("Average price for women is: {:.2f}".format(average_price_women))
    print("Average price for unisex is: {:.2f}".format(average_price_unisex))

except FileNotFoundError:
    print("Incorrect file path")
