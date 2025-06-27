using System;

public class Program
{
    public class Logger
    {
        private static Logger instance;

        // Private constructor prevents instantiation from outside
        private Logger()
        {
            Console.WriteLine("Logger Initialized");
        }

        // Public method to get the singleton instance
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        // Logging method
        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }

    public static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First log message");
        logger2.Log("Second log message");

        if (logger1 == logger2)
        {
            Console.WriteLine("Both logger instances are the same. Singleton confirmed.");
        }
        else
        {
            Console.WriteLine("Logger instances are different. Singleton failed.");
        }
    }
}
