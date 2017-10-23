import java.util.Scanner;

public class _01_MirrorNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        String[] nums = sc.nextLine().split(" ");
        boolean isFound = false;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                String a = nums[i];
                String b = nums[j];

                if(a.charAt(0) == b.charAt(3) &&
                        a.charAt(1) == b.charAt(2) &&
                        a.charAt(2) == b.charAt(1) &&
                        a.charAt(3) == b.charAt(0)){
                    isFound = true;
                    System.out.println(a + "<!>" + b);
                }
            }
        }
        if(!isFound){
            System.out.println("No");
        }
    }
}