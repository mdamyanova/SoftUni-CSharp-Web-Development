line = input("Give me value: ")
prices = []

while line != 'stop':
    price = float(line)
    prices.append(price)
    line = input("Give me value: ")

# find max and min
prices.sort()

maxValue = prices.pop(0)
minValue = prices.pop(len(prices) - 1)

count = 0
average = 0

# calculate average
if len(line) != 0:
    for price in prices:
        average += price
        count += 1

average /= count

print("Max value: ", maxValue)
print("Min value: ", minValue)
print("Average value: ", average)
