import turtle

length = int(input("Enter length of the square: "))
count = int(input("Enter count of iterations: "))
angle = 90

turtle.color('red')
turtle.speed('slow')

while count > 0:
    turtle.forward(length)
    turtle.right(angle)
    count -= 1
