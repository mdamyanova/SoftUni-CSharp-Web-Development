from math import sqrt

try:
    a = float(input())
    b = float(input())
    c = float(input())

    p = (a + b + c) / 2
    s = sqrt(p * (p - a) * (p - b) * (p - c))
    print("{:.2f}".format(s))

except ValueError:
    print("INVALID INPUT")
