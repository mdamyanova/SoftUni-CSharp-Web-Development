//You are given a painting canvas of size 10 x 10, divided into 100 cells.Initially, 
//the canvas is white(all cells have a value of 1). You shoot black and white paint 
//balls with different sizes at the canvas.White is represented by 1s and black is represented 
//by 0s.You alternate between black and white paint after each shot; the first shot is always 
//with black paint(0s), the second is white(1s), the third is black again and so on.You will be 
//given each shot's impact row and column coordinates as well as the ball's radius.The impact area 
//is a square, its center is the impact cell; all cells in the impact area change values to either 0 or 1, 
//depending on the color of the paint. After you run out of ammo(when you receive the string "End" from t
//he console) the canvas will be some combination of 1s and 0s.Each row of the canvas represents a binary 
//integer number.Your task is to find the sum of the 10 numbers and print it to the console.An example 
//where a single shot with parameters "4 5 2" was fired is shown below. The impact cell is shaded black, 
//the splashed cells in the impact area are shaded grey.

using System;

class PaintBall
{
    public static void Main()
    {
        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = 1023;

        }
        string shot = Console.ReadLine();
        bool isBlack = true;

        do
        {
            int radius = int.Parse(shot.Substring(4));
            int row = int.Parse(shot[0].ToString());
            int bitPosition = int.Parse(shot[2].ToString());

            for (int i = GetStartPos(row, radius); i <= GetEndPos(row, radius, numbers.Length); i++)
            {

                if (isBlack)
                {
                    for (int j = GetStartPos(bitPosition, radius); j <= GetEndPos(bitPosition, radius, numbers.Length); j++)
                    {
                        numbers[i] &= ~(1 << j);
                    }
                }
                else
                {
                    for (int j = GetStartPos(bitPosition, radius); j <= GetEndPos(bitPosition, radius, numbers.Length); j++)
                    {
                        numbers[i] |= (1 << j);
                    }
                }
            }

            isBlack = !isBlack;
            shot = Console.ReadLine();

        } while (shot != "End");

        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        Console.WriteLine(sum);
    }

    static int GetStartPos(int n, int radius)
    {
        if (n - radius >= 0)
        {
            return n - radius;
        }
        else
        {
            return 0;
        }
    }

    static int GetEndPos(int n, int radius, int lenght)
    {
        if (n + radius < lenght)
        {
            return n + radius;
        }
        else
        {
            return lenght - 1;
        }
    }
}