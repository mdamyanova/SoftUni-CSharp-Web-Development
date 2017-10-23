import java.util.Scanner;

public class Problem20_URLParser {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String protocol = "";
		String server = "";
		String resource = "";
		
		if(input.contains("://")){
			protocol = input.substring(0, input.indexOf("://"));
			input = input.substring(input.indexOf("://") + 3);
		}
		
		if(input.contains("/")){
			server = input.substring(0, input.indexOf('/'));
			resource = input.substring(input.indexOf('/') + 1);
		} else {
			server = input;
		}
		
		System.out.println("[protocol] = \"" + protocol + 
				"\"\n" + "[server] = \"" + server + 
				"\"\n" + "[resource] = \"" + resource + "\"");
	}
}