using System;

public class Program
{
    // Recursive method to calculate future value
    public static double Forecast(double presentValue, double growthRate, int years)
    {
        if (years == 0)
        {
            return presentValue;
        }
        return Forecast(presentValue, growthRate, years - 1) * (1 + growthRate);
    }

    public static void Main()
    {
        Console.WriteLine("=== Financial Forecasting Tool ===");

        Console.Write("Enter Present Value: ");
        double presentValue;
        while (!double.TryParse(Console.ReadLine(), out presentValue))
        {
            Console.Write("Invalid input. Enter a valid number for Present Value: ");
        }

        Console.Write("Enter Annual Growth Rate (as decimal, e.g., 0.05 for 5%): ");
        double growthRate;
        while (!double.TryParse(Console.ReadLine(), out growthRate))
        {
            Console.Write("Invalid input. Enter a valid number for Growth Rate: ");
        }

        Console.Write("Enter Number of Years to Forecast: ");
        int years;
        while (!int.TryParse(Console.ReadLine(), out years) || years < 0)
        {
            Console.Write("Invalid input. Enter a valid non-negative integer for Years: ");
        }

        double futureValue = Forecast(presentValue, growthRate, years);
        Console.WriteLine($"Predicted Future Value after {years} years: {futureValue:F2}");
    }
}
