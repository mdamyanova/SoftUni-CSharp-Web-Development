import java.util.Scanner;

public class Problem06_CompareCharArrays {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String[] arr1 = scan.nextLine().split(" "); 
		String[] arr2 = scan.nextLine().split(" ");
		
		if(arr1.length < arr2.length){
			System.out.print(String.join("", arr1) + "\n" + String.join("", arr2));
		} else if(arr2.length < arr1.length) {
			System.out.print(String.join("", arr2) + "\n" + String.join("", arr1));
		} else {		
			for(int i = 0; i < Math.min(arr1.length, arr2.length); i++){
				if(arr1[0].charAt(i) > arr2[0].charAt(i)){
					System.out.print(String.join("", arr2) + "\n" + String.join("", arr1));
					break;
				}
				if(arr2[0].charAt(i) > arr1[0].charAt(i)){
					System.out.print(String.join("", arr1) + "\n" + String.join("", arr2));
					break;
				}
				if(arr1[0].charAt(i) == arr2[0].charAt(i)){
					System.out.print(String.join("", arr1) + "\n" + String.join("", arr2));
					break;
				}
			}
		}
	}
}