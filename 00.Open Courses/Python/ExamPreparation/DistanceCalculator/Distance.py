try:
    file_path = input()
    all_time = 0

    with open(file_path) as file:
        for line in file:
            arguments = line.split(',')
            distance = int(arguments[1]) - int(arguments[0]) + 1
            speed = int(arguments[2])
            time = float(distance / speed)
            all_time += time

    print("{:.2f}".format(all_time))

except FileNotFoundError:
    print("INCORRECT VALUE")
