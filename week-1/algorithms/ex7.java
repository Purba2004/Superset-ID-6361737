import java.util.Scanner;

public class ex7 {

    // Recursive method to calculate future value
    public static double forecast(double presentValue, double growthRate, int years) {
        if (years == 0) {
            return presentValue;
        }
        return forecast(presentValue, growthRate, years - 1) * (1 + growthRate);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("=== Financial Forecasting Tool ===");

        System.out.print("Enter Present Value: ");
        double presentValue = scanner.nextDouble();

        System.out.print("Enter Annual Growth Rate (as decimal, e.g., 0.05 for 5%): ");
        double growthRate = scanner.nextDouble();

        System.out.print("Enter Number of Years to Forecast: ");
        int years = scanner.nextInt();

        double futureValue = forecast(presentValue, growthRate, years);
        System.out.printf("Predicted Future Value after %d years: %.2f\n", years, futureValue);

        scanner.close();
    }
}
