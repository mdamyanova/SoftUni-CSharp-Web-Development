import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem11_EqualSums {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String[] input = scanner.nextLine().split(" ");
		List<Integer> numbers = new ArrayList<Integer>();
		for(int i = 0; i < input.length; i++){
			numbers.add(Integer.parseInt(input[i]));
		}

		boolean isIndexFound = false;
		for(int i = 0; i < numbers.size(); i++){
			int sumLeft = 0;
			int sumRight = 0;
			for(int j = i + 1; j < numbers.size(); j++){
				sumRight += numbers.get(j);
			}
			for(int j = 0; j < i; j++){
				sumLeft += numbers.get(j);
			}
			if(sumRight == sumLeft){
				System.out.println(i);
				isIndexFound = true;
				break;
			}
		}
		
		if(!isIndexFound){
			System.out.println("no");
		}
	}
}