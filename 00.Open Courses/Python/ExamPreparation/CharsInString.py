input_str = input()
dict_chars = {}

if input_str is None or input_str is '':
    print("INVALID INPUT")

else:
    for char in input_str:
        if char in dict_chars:
            dict_chars[char] += 1
        else:
            dict_chars[char] = 0

    counter_max = 0
    most_common_char = ''
    for key, value in dict_chars.items():
        if value > counter_max:
            counter_max = value
            most_common_char = key

    print(most_common_char)
