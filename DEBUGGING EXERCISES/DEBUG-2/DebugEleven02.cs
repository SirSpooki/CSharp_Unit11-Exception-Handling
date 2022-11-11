using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebugEleven02 {
// Prevents non-numeric data entry
// Then prevents division by 0
class DebugEleven02 {

  public static int num, denom;

  static void Main()
  {
    // int num = 0, denom = 0;
    string dataEntry;
    double result = 0;
    bool dataEntryIsValid = false;
    DataEntry();
    while (!dataEntryIsValid) {
      try {
        // Console.WriteLine("Enter a number");
        // dataEntry = Console.ReadLine();

        result = num * 1.0 / denom;
        dataEntryIsValid = true;
      } catch (FormatException) {
        Console.WriteLine("Invalid entry - please enter numbers");
      }
    }
    try {
      // if (denom != 0)
      //{
      if (denom == 0)
        throw new System.DivideByZeroException();
      else {
        result = num * 1.0 / denom;
        Console.WriteLine(result + "Division is successful");
      }
    } catch (DivideByZeroException) {
      Console.WriteLine("Division failed");
      result = 0;
    }
    Console.WriteLine("Result is {0}", result);
    Console.ReadKey();
  }
  public static void DataEntry()
  {
    Console.Write("Enter a number ");
    if (!int.TryParse(Console.ReadLine(), out num))
      Console.WriteLine("Numerator was set to 0");
    Console.Write("Enter a number to divide into the first ");
    if (!int.TryParse(Console.ReadLine(), out denom))
      Console.WriteLine("Denominator was set to 0");
  }
}
}
