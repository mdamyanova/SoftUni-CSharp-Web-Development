line = input('Enter name:')

for letter in line:
    if letter.isupper():
        print(letter + '. ', end="")
