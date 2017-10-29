try:
    file_path = input()
    word = input()

    with open(file_path) as f:
        words = [l.strip() for l in f.readlines()]

    word_sorted_letters = sorted(word)
    word_len = len(word)

    anagrams = []
    for current_word in words:
        if len(current_word) == word_len and current_word != word:
            if sorted(current_word) == word_sorted_letters:
                anagrams.append(current_word)
    anagrams.sort()

    if len(anagrams) == 0:
        print("NO ANAGRAMS")
    else:
        for word in anagrams:
            print(word)


except ValueError:
    print("INVALID INPUT")
