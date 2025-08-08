import java.util.Scanner;

public class MaxDifferenceFinder {
  public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);

    System.out.print("Dizinin buyuklugunu giriniz: ");
    int size = scanner.nextInt();

    int[] array = new int[size];
    for (int i = 0; i < size; i++) {
      System.out.printf("Eleman giriniz %d: ", i + 1);
      array[i] = scanner.nextInt();
    }

    int maxDifference = findMaxDifference(array);
    System.out.printf("Sirali 2 eleman arasindaki max fark: %d", maxDifference);
  }

  public static int findMaxDifference(int[] array) {
    int maxDifference = 0;
    for (int i = 1; i < array.length; i++) {
      int difference = Math.abs(array[i] - array[i - 1]);
      if (difference > maxDifference) {
        maxDifference = difference;
      }
    }
    return maxDifference;
  }
}