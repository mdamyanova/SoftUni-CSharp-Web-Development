import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem09_MostFrequentNumber {

	public static void main(String[] args){
		Scanner scanner = new Scanner(System.in);
		String[] input = scanner.nextLine().split(" ");
		List<Integer> numbers = new ArrayList<Integer>();
		for(int i = 0; i < input.length; i++){
			numbers.add(Integer.parseInt(input[i]));
		}
		
		int max = 0;
		int mostFrequentNumber = 0;
		
		for(int i = 0; i < numbers.size(); i++){
			int count = 0;
			int currNum = numbers.get(i);
			for(int j = 0; j < numbers.size(); j++){
				if(numbers.get(j) == currNum){
					count++;
				}
			}
			if(count > max){
				max = count;
				mostFrequentNumber = currNum;
			}
		}
		
		System.out.println(mostFrequentNumber);
	}
}