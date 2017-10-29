text = input("Enter text here: ")
word = input("Enter word here: ")


if text.find(word) != -1:
    index = text.index(word) + len(word)
    new_text = text[index:]
    print(new_text.strip())
