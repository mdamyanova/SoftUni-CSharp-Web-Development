try:
    code_article = input()
    file_path = input()

    smallest_price = float('inf')
    town = None
    with open(file_path) as file:
        for line in file:
            current_line_args = line.split("\"")
            current_line_args.remove(',')
            current_line_args.remove('')
            current_code_article = current_line_args[0]
            if current_code_article == code_article:
                current_price_article = float(line[line.rindex(',') + 1:])
                if current_price_article < smallest_price:
                    smallest_price = current_price_article
                    town = current_line_args[3]

    print(town)
except ValueError:
    print()
