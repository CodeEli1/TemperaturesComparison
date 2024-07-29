using System;

class Program {
  public static void Main (string[] args) {
    const int numTemperatures = 5;
    int[] temperatures = new int[numTemperatures];
    bool isGettingWarmer = true;
    bool isGettingCooler = true;
    double sum = 0;

    for (int i = 0; i < numTemperatures; i++)
    {
      int temp;
      while (true)
      {
        Console.Write($"Enter temperature {i + 1} (between -30 and 130): ");
        if (int.TryParse(Console.ReadLine(), out temp) && temp >= -30 && temp <= 130)
        {
          temperatures[i] = temp;
          sum += temp;
          break;
        }
        else
        {
          Console.WriteLine("Invalid temperature. Please enter a valid temperature between -30 and 130.");
        }
      }

      if (i > 0)
      {
        if (temperatures[i] > temperatures[i - 1])
        {
          isGettingCooler = false;
        }
        else if (temperatures[i] < temperatures[i - 1])
        {
          isGettingWarmer = false;
        }
      }
    }

    if (isGettingWarmer && !isGettingCooler)
    {
      Console.WriteLine("Getting Warmer");
    }
    else if (isGettingCooler && !isGettingWarmer)
    {
      Console.WriteLine("Getting Colder");
    }
    else
    {
      Console.WriteLine("It's a mixed bag");
    }

    Console.WriteLine("5-day Temperature [" + string.Join(", ", temperatures) + "]");
    Console.WriteLine($"Average Temperature is {sum / numTemperatures:F1} degrees");
  }
}