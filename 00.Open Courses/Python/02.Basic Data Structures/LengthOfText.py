sentence = input("Enter text here: ")

if len(sentence) != 10:
    print(sentence[:10] + '...')
else:
    print(sentence)
