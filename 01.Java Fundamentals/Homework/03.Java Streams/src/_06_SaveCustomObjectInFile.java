//Write a program that saves and loads the information from a custom
// Object that you have created to a file using ObjectInputStream,
// ObjectOutputStream. Create a class Course that has a String field containing
// the name and an integer field containing the number of students attending
// the course. Set the name of the new file as course.save.

import java.io.*;

class Course implements Serializable{
    String name;
    int numberOfStudents;
}
public class _06_SaveCustomObjectInFile {

    public static void main(String[] args) throws IOException, ClassNotFoundException {
        Course course = new Course() {{
            name = "Java";
            numberOfStudents = 457;
        }};

        ObjectOutputStream oos = new ObjectOutputStream(
                new FileOutputStream(
                        "resources//course.save"));
        oos.writeObject(course);
        oos.close();

        Course output = new Course();
        ObjectInputStream ois = new ObjectInputStream(
                new FileInputStream(
                        "resources//course.save"));

       output = (Course)ois.readObject();
        System.out.println("Course name: " + output.name +
                ", Number of students: " + output.numberOfStudents);
       oos.close();
    }
}