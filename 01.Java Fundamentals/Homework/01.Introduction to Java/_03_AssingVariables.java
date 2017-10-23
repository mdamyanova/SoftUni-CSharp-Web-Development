//Find suitable types for variables. You are given
// the following types: byte, short, int, long, char,
// boolean, float, double, and String. Assign the
// following values to them false, “Palo Alto, CA”,
// 32767, 2000000000, 0.1234567891011, 0.5f, 919827112351L,
// 127, ‘c’. Try to assign 32768 to short and see what happens.

public class _03_AssingVariables {

    public static void main(String[] args) {

        boolean isTrue = false;
        String text = "Palo Alto, CA";
        short shortNumber = 32767;
        int intNumber = 2000000000;
        double doubleNumber = 0.1234567891011;
        float floatNumber = 0.5f;
        long longNumber = 919827112351L;
        byte byteNumber = 127;
        char letter = 'c';

        short test = (short) 32768;
        System.out.println(test);
    }
}