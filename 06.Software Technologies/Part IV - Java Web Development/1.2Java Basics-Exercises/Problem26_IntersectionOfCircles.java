import java.util.Scanner;

public class Problem26_IntersectionOfCircles {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Circle c1 = Circle.ReadCircle(scanner);
        Circle c2 = Circle.ReadCircle(scanner);
        System.out.println(Circle.Intersect(c1, c2) ? "Yes" : "No");
    }
}

class Circle{

    public Circle(Point Center, double Radius){
        this.Center = Center;
        this.Radius = Radius;
    }
    private Point Center;

    private double Radius;

    public Point getCenter(){return Center;}

    public void setCenter(Point Center){this.Center = Center;}

    public double getRadius(){return Radius;}

    public void setRadius(double Radius){this.Radius = Radius;}

    public static Circle ReadCircle(Scanner scanner){
        String[] tokens = scanner.nextLine().split(" ");
        Circle circle = new Circle(
                new Point(Double.parseDouble(tokens[0]),
                        Double.parseDouble(tokens[1])),
                Double.parseDouble(tokens[2]));

        return circle;
    }

    public static boolean Intersect(Circle c1, Circle c2){
        double x = Math.pow(c2.Center.getX() - c1.Center.getX(), 2);
        double y = Math.pow(c2.Center.getY() - c1.Center.getY(), 2);
        double distance = Math.sqrt(x + y);
        if(distance <= c1.Radius + c2.Radius){
            return true;
        }
        return false;
    }
}

class Point{
    public Point(double X, double Y){
        this.X = X;
        this.Y = Y;
    }
    private double X;

    private double Y;

    public double getX(){return X;}

    public void setX(double X) {this.X = X;}

    public double getY(){return Y;}

    public void setY(double Y) {this.Y = Y;}
}