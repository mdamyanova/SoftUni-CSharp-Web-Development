import string
import sys

try:
    key = int(input())
    text = input()


    def main():
        crypt_alphabet = create_crypt_alphabet(key)
        print(encrypt_message(text, crypt_alphabet))
        return 0


    def encrypt_message(message, crypt_alphabet):
        result = []
        for character in message:
            if character in crypt_alphabet:
                result.append(crypt_alphabet[character])
            else:
                result.append(character)
        return ''.join(result)


    def create_crypt_alphabet(key):
        alphabet = string.ascii_uppercase

        ord_A = ord('A')
        crypt_alphabet = {}

        for character in alphabet:
            enc = ord(character) - ord_A + key
            enc %= len(alphabet)
            crypt_alphabet[character] = chr(enc + ord_A)

        return crypt_alphabet


    if __name__ == "__main__":
        sys.exit(main())

except ValueError:
    print("INVALID INPUT")
