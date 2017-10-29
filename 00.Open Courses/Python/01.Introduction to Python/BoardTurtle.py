import turtle

side = 40
x = 0
y = 0

for i in range(8):
    y -=  side
    turtle.penup()
    turtle.goto(x, y)
    turtle.pendown()

    for j in range(8):
        if(i % 2 == 0 and j % 2 == 0) or (i % 2 == 1 and j % 2 == 1):
            turtle.begin_fill()

        for k in range(4):
            turtle.forward(side)
            turtle.left(90)

        turtle.end_fill()
        turtle.forward(side)

turtle.exitonclick()

