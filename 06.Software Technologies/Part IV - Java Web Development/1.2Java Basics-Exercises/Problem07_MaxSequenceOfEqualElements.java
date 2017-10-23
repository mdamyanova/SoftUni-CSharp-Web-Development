import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem07_MaxSequenceOfEqualElements {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String[] input = scanner.nextLine().split(" ");
		List<Integer> numbers = new ArrayList<Integer>();
		for(int i = 0; i < input.length; i++){
			numbers.add(Integer.parseInt(input[i]));
		}
		
		int start = 0;
		int len = 1;
		int bestStart = 0;
		int bestLen = 0;
		
		for(int i = 1; i < numbers.size(); i++){
			if(numbers.get(i) == numbers.get(i - 1)){
				len++;
				if(len > bestLen){
					bestLen = len;
					bestStart = start;
				}
			}
			else {
				start = i;
				len = 1;
			}
		}
		
		for(int i = bestStart; i < bestLen + bestStart; i++){
			System.out.print(numbers.get(i) + " ");
		}
		System.out.println();
	}
}