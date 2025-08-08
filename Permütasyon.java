import java.util.Scanner;

public class PermutationGenerator {
  public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);

    System.out.print("Enter first number: ");
    int num1 = scanner.nextInt();

    System.out.print("Enter second number: ");
    int num2 = scanner.nextInt();

    System.out.print("Enter third number: ");
    int num3 = scanner.nextInt();

    System.out.println("All permutations: ");
    printPermutations(num1, num2, num3);
  }

  public static void printPermutations(int a, int b, int c) {
    printPermutations("", a, b, c);
  }

  private static void printPermutations(String prefix, int a, int b, int c) {
    if (a == 0 && b == 0 && c == 0) {
      System.out.println(prefix);
      return;
    }

    if (a != 0) {
      printPermutations(prefix + a, a - 1, b, c);
    }
    if (b != 0) {
      printPermutations(prefix + b, a, b - 1, c);
    }
    if (c != 0) {
      printPermutations(prefix + c, a, b, c - 1);
    }
  }
}