from math import ceil

weight = float(input())
height = float(input())

paint = 1.76

wall = weight * height
needed = ceil(wall / paint)

print(needed)
